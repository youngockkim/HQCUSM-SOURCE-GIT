using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;

using SOI.CliFrx;
using SOI.DNM;
using SOI.OIFrx;
using BOI.OIFrx;

using Miracom.TRSCore;

namespace BOI.WIPCus
{
    public partial class frmMaterialInputInPacking : BOI.OIFrx.BOIBaseForm.BOIBasePopup02
    {
        public frmMaterialInputInPacking()
        {
            InitializeComponent();
        }

        public List<string> s_order_list;

        private enum WRKORD
        {
            ORDER_ID,
            ORDER_DATE,
            MAT_ID,
            MAT_DESC,
            BOM_TYPE,
            ORDER_QTY,
            LINE_ID,
            RES_ID,
            STATUS
        }

        private enum INPUT
        {
            LOT_ID,
            MAT_ID,
            MAT_DESC,
            UNIT,
            STATUS,
            INPUT_QTY,
            REMAIN_QTY,
            SHELF_LIFE
        }

        private enum BOM
        {
            MAT_ID,
            MAT_DESC,
            BOM_TYPE,
            QTY,
            UNIT
        }
        /// <summary>
        /// 작업지시 조회
        /// </summary>
        /// <param name="s_order_list"></param>
        /// <returns></returns>
        private bool View_Order(List<string> s_order_list)
        {
            TRSNode in_node = new TRSNode("View_Order_In");
            TRSNode out_node = new TRSNode("View_Order_Out");

            int i = 0;
            int i_row = 0;

            try
            {
                for (i = 0; i < s_order_list.Count; i++)
                {
                    in_node.Init();
                    MPCF.SetInMsg(in_node);
                    in_node.ProcStep = '2';
                    in_node.AddString("ORDER_ID", s_order_list[i]);

                    if (MPCF.CallService("BWIP", "BWIP_View_Order_List", in_node, ref out_node) == false)
                        return false;

                    i_row = spdWorkOrder_Sheet1.RowCount;
                    spdWorkOrder_Sheet1.RowCount++;

                    spdWorkOrder_Sheet1.Cells[0, (int)WRKORD.ORDER_ID].Value = out_node.GetString("ORDER_ID");
                    spdWorkOrder_Sheet1.Cells[0, (int)WRKORD.ORDER_DATE].Value = MPCF.MakeDateFormat(out_node.GetString("ORD_DATE"), DATE_TIME_FORMAT.DATE);
                    spdWorkOrder_Sheet1.Cells[0, (int)WRKORD.MAT_ID].Value = out_node.GetString("MAT_ID");
                    spdWorkOrder_Sheet1.Cells[0, (int)WRKORD.MAT_DESC].Value = out_node.GetString("MAT_DESC");
                    spdWorkOrder_Sheet1.Cells[0, (int)WRKORD.BOM_TYPE].Value = out_node.GetChar("MAT_BOM_TYPE");
                    spdWorkOrder_Sheet1.Cells[0, (int)WRKORD.ORDER_QTY].Value = out_node.GetDouble("ORD_QTY");
                    spdWorkOrder_Sheet1.Cells[0, (int)WRKORD.LINE_ID].Value = out_node.GetString("LINE_DESC");
                    spdWorkOrder_Sheet1.Cells[0, (int)WRKORD.LINE_ID].Tag = out_node.GetString("LINE_ID");
                    spdWorkOrder_Sheet1.Cells[0, (int)WRKORD.RES_ID].Value = out_node.GetString("RES_DESC");
                    spdWorkOrder_Sheet1.Cells[0, (int)WRKORD.RES_ID].Tag = out_node.GetString("RES_ID");
                    spdWorkOrder_Sheet1.Cells[0, (int)WRKORD.STATUS].Value = out_node.GetString("ORDER_STATUS_DESC");
                    spdWorkOrder_Sheet1.Cells[0, (int)WRKORD.STATUS].Tag = out_node.GetChar("ORDER_STATUS");
                }
            }
            catch (System.Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }

            return true;
        }
        
        // 자재 투입 및 투입 해제 시 상태 검사
        private bool Create_Input_List(string sKind, char c_check)
        {
            TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[4];
            DataTable dt = null;
            string sSql = "";
            StringBuilder s_msg = null;

            int i_row = 0, i_col = 0;

            try
            {
                i_row = spdWorkOrder_Sheet1.ActiveRowIndex;

                dvcArgu[0].sCondtion_ID = "FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "LOT_ID";
                dvcArgu[1].sCondition_Value = txtMaterialLot.Text;

                dvcArgu[2].sCondtion_ID = "RES_ID";
                dvcArgu[2].sCondition_Value = spdWorkOrder_Sheet1.Cells[i_row, (int)WRKORD.RES_ID].Tag.ToString();

                dvcArgu[3].sCondtion_ID = "ITEM_ID";
                dvcArgu[3].sCondition_Value = spdWorkOrder_Sheet1.Cells[i_row, (int)WRKORD.MAT_ID].Value;

                if (TPDR.GetDataOne("", ref dt, "CWIP2401-001", dvcArgu, false, false, ref sSql) == false)
                {
                    if (dt != null)
                        dt.Dispose();

                    MPCF.ShowMessage(MPCF.GetMessage(154), MSG_LEVEL.ERROR, false);

                    GC.Collect();
                    return false;
                }

                if (dt.Rows[0]["WIP_LOT_ID"].ToString() == string.Empty)
                {
                    // 자재 Lot이 없음
                    MPCF.ShowMessage(MPCF.GetMessage(404), MSG_LEVEL.ERROR, false);
                    return false;
                }

                if (sKind == "Input")
                {
                    if (dt.Rows[0]["INV_OPER"].ToString() == "NULL")
                    {
                        MPCF.ShowMessage(MPCF.GetMessage(467), MSG_LEVEL.ERROR, true);
                        return false;
                    }

                    if (dt.Rows[0]["INV_OPER"].ToString() != dt.Rows[0]["OPER"].ToString())
                    {
                        // 자재가 현재 이 {0}에 있습니다. {1}로 이동시킨 후에 다시 하세요.
                        s_msg = new StringBuilder();
                        s_msg.AppendFormat(MPCF.GetMessage(466), dt.Rows[0]["OPER"].ToString(), dt.Rows[0]["INV_OPER"].ToString());
                        MPCF.ShowMessage(s_msg.ToString(), MSG_LEVEL.ERROR, true);
                        MPCF.ShowMessageClear();
                        return false;
                    }

                    // D : 투입중, I : 투입, P : 생산중, C : 투입해제
                    spdPredetermin.Search(0, txtMaterialLot.Text, true, true, false, false, 0, (int)INPUT.LOT_ID, ref i_row, ref i_col);
                    //i_row = Search_Lot(txtMaterialLot.Text, sKind);

                    // 투입 중인 데이터가 있는 투입량을 합산한다.
                    if (i_row > -1)
                    {
                        MPCF.ShowMessage(MPCF.GetMessage(403), MSG_LEVEL.ERROR, false);
                        return false;
                    }
                    else
                    {
                        i_row = spdPredetermin_Sheet1.RowCount;
                        spdPredetermin_Sheet1.RowCount++;

                        spdPredetermin_Sheet1.Cells[i_row, (int)INPUT.LOT_ID].Value = txtMaterialLot.Text;
                        spdPredetermin_Sheet1.Cells[i_row, (int)INPUT.MAT_ID].Value = dt.Rows[0]["MAT_ID"];
                        spdPredetermin_Sheet1.Cells[i_row, (int)INPUT.MAT_DESC].Value = dt.Rows[0]["MAT_DESC"];
                        spdPredetermin_Sheet1.Cells[i_row, (int)INPUT.UNIT].Value = dt.Rows[0]["UNIT_1"];
                        spdPredetermin_Sheet1.Cells[i_row, (int)INPUT.STATUS].Value = MPCF.FindLanguage("During Input");
                        spdPredetermin_Sheet1.Cells[i_row, (int)INPUT.STATUS].Tag = 'D';
                        spdPredetermin_Sheet1.Cells[i_row, (int)INPUT.INPUT_QTY].Value = dt.Rows[0]["QTY_1"];
                        spdPredetermin_Sheet1.Cells[i_row, (int)INPUT.REMAIN_QTY].Value = dt.Rows[0]["QTY_1"];
                        spdPredetermin_Sheet1.Cells[i_row, (int)INPUT.SHELF_LIFE].Value = MPCF.MakeDateFormat(dt.Rows[0]["SHELF_LIFE"].ToString(), DATE_TIME_FORMAT.DATE);
                    }

                    txtMaterialLot.Clear();
                }
                else if (sKind == "Cancel")
                {
                    if (dt.Rows[0]["LOAD_LOT_ID"].ToString() == "NULL")
                    {
                        MPCF.ShowMessage(MPCF.GetMessage(154), MSG_LEVEL.ERROR, true);
                        return false;
                    }

                    //spdPredetermin.Search(0, txtMaterialLot.Text, true, true, false, false, 0, (int)INPUT.LOT_ID, spdPredetermin_Sheet1.RowCount, (int)INPUT.LOT_ID, ref i_row, ref i_col);
                    i_row = Search_Lot(txtMaterialLot.Text, sKind);
                    if (i_row > -1)
                    {
                        spdPredetermin_Sheet1.Cells[i_row, (int)INPUT.STATUS].Tag = 'C';
                        spdPredetermin_Sheet1.Cells[i_row, (int)INPUT.STATUS].Value = MPCF.FindLanguage("Cancel Input");

                        txtMaterialLot.Clear();
                    }
                    else
                    {
                        MPCF.ShowMessage(MPCF.GetMessage(111), MSG_LEVEL.ERROR, false);
                        txtMaterialLot.Focus();
                        return false;
                    }
                }

                txtMaterialLot.Focus();
            }
            catch (System.Exception ex)
            {
                MPCF.ShowMessage("Check_Whether_The_Input() : " + ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }

            return true;
        }

        private int Search_Lot(string s_lot_id, string s_kind)
        {
            int i = 0;
            bool b_check = false;
            string s_status = "";

            // 상태(D : 투입중, I : 투입, P : 생산중, C : 투입해제)

            if (s_kind == "Input")
            {                
                for (i = 0; i < spdPredetermin_Sheet1.RowCount; i++)
                {
                    s_status = spdPredetermin_Sheet1.Cells[i, (int)INPUT.STATUS].Tag.ToString();
                    if (spdPredetermin_Sheet1.Cells[i, (int)INPUT.LOT_ID].Text == s_lot_id && s_status == "D")
                    {
                        b_check = true;
                        break;
                    }
                }
            }
            else if (s_kind == "Cancel")
            {
                for (i = 0; i < spdPredetermin_Sheet1.RowCount; i++)
                {
                    s_status = spdPredetermin_Sheet1.Cells[i, (int)INPUT.STATUS].Tag.ToString();
                    if (spdPredetermin_Sheet1.Cells[i, (int)INPUT.LOT_ID].Text == s_lot_id && (s_status == "I" || s_status == "D"))
                    {
                        b_check = true;
                        break;
                    }
                }

            }

            return b_check ? i : -1;
        }

        /// <summary>
        /// 투입 리스트에서 자재 존재 여부 확인
        /// </summary>
        /// <returns></returns>
        private bool Check_Input_List(string sKind)
        {
            //int i_col = 0;
            int i_row = 0;

            try
            {
                if (MPCF.Trim(txtMaterialLot.Text) == string.Empty)
                {
                    MPCF.ShowMessage(MPCF.GetMessage(108), MSG_LEVEL.ERROR, false);
                    txtMaterialLot.Focus();
                    return false;
                }

                //spdPredetermin.Search(0, txtMaterialLot.Text, true, true, false, false, 0, (int)INPUT.LOT_ID, ref i_row, ref i_col);

                i_row = Search_Lot(txtMaterialLot.Text, sKind);

                //if (sKind == "Input" && i_row > -1)
                //{
                //    if (MPCF.Trim(spdPredetermin_Sheet1.Cells[i_row, (int)INPUT.STATUS].Tag) != "D")
                //    {
                //        MPCF.ShowMessage(MPCF.GetMessage(407), MSG_LEVEL.ERROR, false);
                //        return false;
                //    }
                //}
                //else 
                if (sKind == "Cancel")
                {
                    if (i_row == -1)
                    {
                        MPCF.ShowMessage(MPCF.GetMessage(405), MSG_LEVEL.ERROR, false);
                        return false;
                    }
                    else if (i_row > -1 && spdPredetermin_Sheet1.Cells[i_row, (int)INPUT.STATUS].Tag.ToString() == "P")
                    {
                        MPCF.ShowMessage(MPCF.GetMessage(408), MSG_LEVEL.ERROR, false);
                        return false;
                    }
                }
            }
            catch (System.Exception ex)
            {
                MPCF.ShowMessage("Check_Input_List() : " + ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }

            return true;
        }

        /// <summary>
        /// 자재를 투입, 투입해제 처리를 한다.
        /// </summary>
        /// <param name="sKind"></param>
        /// <returns></returns>
        private bool Input_Material(string sKind)
        {
            TRSNode in_node = new TRSNode("Input_Material_In");
            TRSNode out_node = new TRSNode("Input_Material_Out");

            TRSNode data_list = null;

            int i = 0;
            int i_row = spdWorkOrder_Sheet1.ActiveRowIndex;

            try
            {
                MPCF.SetInMsg(in_node);

                in_node.ProcStep = '1';
                in_node.AddString("RES_ID", spdWorkOrder_Sheet1.Cells[i_row, (int)WRKORD.RES_ID].Tag);
                in_node.AddString("LINE_ID", spdWorkOrder_Sheet1.Cells[i_row, (int)WRKORD.LINE_ID].Tag);

                for (i = 0; i < spdPredetermin_Sheet1.RowCount; i++)
                {
                    if (MPCF.Trim(spdPredetermin_Sheet1.Cells[i, (int)INPUT.STATUS].Tag) == "D" ||
                       MPCF.Trim(spdPredetermin_Sheet1.Cells[i, (int)INPUT.STATUS].Tag) == "C")
                    {
                        data_list = in_node.AddNode("DATA_LIST");
                        data_list.AddChar("STATUS", MPCF.ToChar(spdPredetermin_Sheet1.Cells[i, (int)INPUT.STATUS].Tag));
                        data_list.AddString("LOT_ID", spdPredetermin_Sheet1.Cells[i, (int)INPUT.LOT_ID].Text);
                        data_list.AddString("MAT_ID", spdPredetermin_Sheet1.Cells[i, (int)INPUT.MAT_ID].Text);
                        data_list.AddDouble("QTY", spdPredetermin_Sheet1.Cells[i, (int)INPUT.REMAIN_QTY].Value);
                    }
                }

                if (MPCF.CallService("BWIP", "BWIP_Input_Material", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCF.ShowSuccessMessage(out_node, false);
            }
            catch (System.Exception ex)
            {
                MPCF.ShowMessage("Input_Material() : " + ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }

            return true;
        }

        /// <summary>
        /// 자재 소요량 계산
        /// </summary>
        /// <returns></returns>
        private bool Material_Reqirement_Calculation()
        {
            TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[4];
            DataTable dt = null;
            string sSql = "";

            int i = 0, j = 0;
            int i_row = 0, i_col = 0;

            try
            {
                spdTargetMaterial_Sheet1.RowCount = 0;

                dvcArgu[0].sCondtion_ID = "FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                for (i = 0; i < spdWorkOrder_Sheet1.RowCount; i++)
                {
                    i_row = 0;
                    i_col = 0;

                    dvcArgu[1].sCondtion_ID = "MAT_ID";
                    dvcArgu[1].sCondition_Value = spdWorkOrder_Sheet1.Cells[i, (int)WRKORD.MAT_ID].Text;

                    dvcArgu[2].sCondtion_ID = "BOM_TYPE";
                    dvcArgu[2].sCondition_Value = spdWorkOrder_Sheet1.Cells[i, (int)WRKORD.BOM_TYPE].Text;

                    dvcArgu[3].sCondtion_ID = "ORD_QTY";
                    dvcArgu[3].sCondition_Value = spdWorkOrder_Sheet1.Cells[i, (int)WRKORD.ORDER_QTY].Value;

                    if (TPDR.GetDataOne("", ref dt, "CWIP2401-002", dvcArgu, false, false, ref sSql) == false)
                    {
                        if (dt != null)
                            dt.Dispose();

                        GC.Collect();
                        return false;
                    }

                    for (j = 0; j < dt.Rows.Count; j++)
                    {
                        spdTargetMaterial.Search(0, dt.Rows[j]["MAT_ID"].ToString(), true, true, false, false, 0, (int)BOM.MAT_ID, ref i_row, ref i_col);
                        if (i_row == -1)
                        {
                            i_row = spdTargetMaterial_Sheet1.RowCount;
                            spdTargetMaterial_Sheet1.RowCount++;
                            spdTargetMaterial_Sheet1.Cells[i_row, (int)BOM.MAT_ID].Value = dt.Rows[j]["MAT_ID"];
                            spdTargetMaterial_Sheet1.Cells[i_row, (int)BOM.MAT_DESC].Value = dt.Rows[j]["MAT_DESC"];
                            spdTargetMaterial_Sheet1.Cells[i_row, (int)BOM.BOM_TYPE].Value = dt.Rows[j]["P_MAT_BOM_TYPE"];
                            spdTargetMaterial_Sheet1.Cells[i_row, (int)BOM.QTY].Value = dt.Rows[j]["REQ_QTY"];
                            spdTargetMaterial_Sheet1.Cells[i_row, (int)BOM.UNIT].Value = dt.Rows[j]["UNIT_1"];
                        }
                        else
                        {
                            spdTargetMaterial_Sheet1.Cells[i_row, (int)BOM.QTY].Value = MPCF.ToInt(dt.Rows[0]["REQ_QTY"]) + MPCF.ToInt(spdTargetMaterial_Sheet1.Cells[i_row, (int)BOM.QTY].Value);
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                MPCF.ShowMessage("Material_Reqirement_Calculation() : " + ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }

            return true;
        }

        /// <summary>
        /// 설비에 투입한 자재 정보를 조회
        /// </summary>
        /// <returns></returns>
        private bool View_Input_Info()
        {
            TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[2];
            DataTable dt = null;
            string sSql = "";

            int i = 0;

            try
            {
                spdPredetermin_Sheet1.RowCount = 0;

                dvcArgu[0].sCondtion_ID = "FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "RES_ID";
                dvcArgu[1].sCondition_Value = MPCF.Trim(spdWorkOrder_Sheet1.Cells[0, (int)WRKORD.RES_ID].Tag);

                if (TPDR.GetDataOne("", ref dt, "CWIP2401-003", dvcArgu, false, false, ref sSql) == false)
                {
                    if (dt != null)
                        dt.Dispose();

                    GC.Collect();
                    return false;
                }

                for (i = 0; i < dt.Rows.Count; i++)
                {
                    spdPredetermin_Sheet1.RowCount++;

                    spdPredetermin_Sheet1.Cells[i, (int)INPUT.LOT_ID].Value = dt.Rows[i]["LOT_ID"];
                    spdPredetermin_Sheet1.Cells[i, (int)INPUT.MAT_ID].Value = dt.Rows[i]["MAT_ID"];
                    spdPredetermin_Sheet1.Cells[i, (int)INPUT.MAT_DESC].Value = dt.Rows[i]["MAT_DESC"];
                    spdPredetermin_Sheet1.Cells[i, (int)INPUT.UNIT].Value = dt.Rows[i]["UNIT_1"];
                    spdPredetermin_Sheet1.Cells[i, (int)INPUT.STATUS].Value = dt.Rows[i]["STATUS_DESC"];
                    spdPredetermin_Sheet1.Cells[i, (int)INPUT.STATUS].Tag = dt.Rows[i]["STATUS"];
                    spdPredetermin_Sheet1.Cells[i, (int)INPUT.INPUT_QTY].Value = MPCF.ToDbl(dt.Rows[i]["INPUT_QTY"]); // 설비에 최초 투입 수량
                    spdPredetermin_Sheet1.Cells[i, (int)INPUT.REMAIN_QTY].Value = MPCF.ToDbl(dt.Rows[i]["REMAIN_QTY"]);
                    spdPredetermin_Sheet1.Cells[i, (int)INPUT.SHELF_LIFE].Value = MPCF.MakeDateFormat(dt.Rows[i]["SHELF_LIFE"].ToString(), DATE_TIME_FORMAT.DATE);
                }

                MPCF.FitColumnHeader(spdPredetermin);
            }
            catch (System.Exception ex)
            {
                MPCF.ShowMessage("View_Input_Info() : " + ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }

            return true;
        }

        /// <summary>
        /// 투입/투입 해제 처리 전 데이터의 유효성을 검사
        /// </summary>
        /// <returns></returns>
        private bool Check_Data()
        {
            int i = 0, i_cnt = 0;

            try
            {
                if (spdWorkOrder_Sheet1.RowCount == 0)
                {
                    MPCF.ShowMessage(MPCF.GetMessage(401), MSG_LEVEL.ERROR, false);
                    return false;
                }

                for (i = 0; i < spdPredetermin_Sheet1.RowCount; i++)
                {
                    // Status가 D(투입 중), C(투입 해제)인 경우만 반영
                    if(MPCF.Trim(spdPredetermin_Sheet1.Cells[i, (int)INPUT.STATUS].Tag) == "D" ||
                       MPCF.Trim(spdPredetermin_Sheet1.Cells[i, (int)INPUT.STATUS].Tag) == "C")
                    {
                        i_cnt++;
                    }
                }

                if (i_cnt == 0)
                {
                    MPCF.ShowMessage(MPCF.GetMessage(409), MSG_LEVEL.ERROR, false);
                    return false;
                }
            }
            catch (System.Exception ex)
            {
                MPCF.ShowMessage("Check_Data() : " + ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
            return true;
        }

        private void btnViewWorkOrder_Click(object sender, EventArgs e)
        {
            frmWIPViewWorkOrderList frm = new frmWIPViewWorkOrderList();
            int i = 0;

            if (frm.ShowDialog() == DialogResult.OK)
            {
                spdWorkOrder_Sheet1.RowCount = 0;

                i = frm.mspdWorkOrder.ActiveRowIndex;
                
                spdWorkOrder_Sheet1.RowCount++;
                spdWorkOrder_Sheet1.Cells[0, (int)WRKORD.ORDER_ID].Value = frm.mspdWorkOrder.Cells[i, (int)frmWIPViewWorkOrderList.ORD.ORDER_ID].Value;
                spdWorkOrder_Sheet1.Cells[0, (int)WRKORD.ORDER_DATE].Value = frm.mspdWorkOrder.Cells[i, (int)frmWIPViewWorkOrderList.ORD.ORDER_DATE].Value; ;
                spdWorkOrder_Sheet1.Cells[0, (int)WRKORD.MAT_ID].Value = frm.mspdWorkOrder.Cells[i, (int)frmWIPViewWorkOrderList.ORD.MAT_ID].Value;
                spdWorkOrder_Sheet1.Cells[0, (int)WRKORD.MAT_DESC].Value = frm.mspdWorkOrder.Cells[i, (int)frmWIPViewWorkOrderList.ORD.MAT_DESC].Value;
                spdWorkOrder_Sheet1.Cells[0, (int)WRKORD.BOM_TYPE].Value = frm.mspdWorkOrder.Cells[i, (int)frmWIPViewWorkOrderList.ORD.BOM_TYPE].Value;
                spdWorkOrder_Sheet1.Cells[0, (int)WRKORD.ORDER_QTY].Value = frm.mspdWorkOrder.Cells[i, (int)frmWIPViewWorkOrderList.ORD.ORDER_QTY].Value;
                spdWorkOrder_Sheet1.Cells[0, (int)WRKORD.RES_ID].Value = frm.mspdWorkOrder.Cells[i, (int)frmWIPViewWorkOrderList.ORD.RES_ID].Value;
                spdWorkOrder_Sheet1.Cells[0, (int)WRKORD.RES_ID].Tag = frm.mspdWorkOrder.Cells[i, (int)frmWIPViewWorkOrderList.ORD.RES_ID].Tag;
                spdWorkOrder_Sheet1.Cells[0, (int)WRKORD.LINE_ID].Value = frm.mspdWorkOrder.Cells[i, (int)frmWIPViewWorkOrderList.ORD.LINE_ID].Value;
                spdWorkOrder_Sheet1.Cells[0, (int)WRKORD.LINE_ID].Tag = frm.mspdWorkOrder.Cells[i, (int)frmWIPViewWorkOrderList.ORD.LINE_ID].Tag;

                spdWorkOrder_Sheet1.Cells[0, (int)WRKORD.STATUS].Value = frm.mspdWorkOrder.Cells[i, (int)frmWIPViewWorkOrderList.ORD.STATUS].Value;
                spdWorkOrder_Sheet1.Cells[0, (int)WRKORD.STATUS].Tag = frm.mspdWorkOrder.Cells[i, (int)frmWIPViewWorkOrderList.ORD.STATUS].Tag;

                MPCF.FitColumnHeader(spdWorkOrder);

                // 자재 소요량 계산
                Material_Reqirement_Calculation();

                // 설비에 투입한 자재 정보를 조회
                View_Input_Info();
            }
        }

        private void txtMaterialLot_KeyDown(object sender, KeyEventArgs e)
        {
            string sKind = "";

            try
            {
                if (e.KeyData == Keys.Enter)
                {
                    if (spdWorkOrder_Sheet1.RowCount == 0)
                    {
                        MPCF.ShowMessage(MPCF.GetMessage(401), MSG_LEVEL.ERROR, false);
                        return;
                    }

                    spdPredetermin.SuspendLayout();

                    if (chkOutSelection.OnOffState == SOI.OIFrx.SOICheckBoxOnOffState.OffState)
                    {
                        sKind = "Cancel";

                        // 자재 투입 예정 목록에 존재 유무 확인
                        if (!Check_Input_List(sKind))
                            return;

                        if (!Create_Input_List(sKind, 'N'))
                            return;

                        btnInput_Click(sender, null);
                    }
                    else
                    {
                        if (Create_Input_List("Input", 'Y'))
                        {
                            btnInput_Click(sender, null);
                        }
                        else
                            return;
                    }

                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            finally
            {
                spdPredetermin.ResumeLayout();
            }
        }

        private void btnInput_Click(object sender, EventArgs e)
        {
            string sKind = "";

            if (chkOutSelection.OnOffState == SOI.OIFrx.SOICheckBoxOnOffState.OnState)
            {
                sKind = "Input";
            }
            else if (chkOutSelection.OnOffState == SOI.OIFrx.SOICheckBoxOnOffState.OffState)
            {
                sKind = "Cancel";
            }

            if (!Check_Data())
                return;
            
            // 자재 투입, 투입 해제 처리
            if (!Input_Material(sKind))
                return;

            // 설비에 투입한 자재 정보를 조회
            View_Input_Info();
        }

        private void numInputQty_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void spdPredetermin_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (spdWorkOrder_Sheet1.RowCount > 0)
            {
                // 자재 소요량 계산
                Material_Reqirement_Calculation();

                // 설비에 투입한 자재 정보를 조회
                View_Input_Info();
            }
            else
                MPCF.ShowMessageClear();

            //string[] sPorts = SerialPort.GetPortNames();
        }

        private void frmMaterialInputInPacking_Load(object sender, EventArgs e)
        {
            View_Order(s_order_list);
            // 자재 소요량 계산
            Material_Reqirement_Calculation();

            // 설비에 투입한 자재 정보를 조회
            View_Input_Info();
        }
    }
}
