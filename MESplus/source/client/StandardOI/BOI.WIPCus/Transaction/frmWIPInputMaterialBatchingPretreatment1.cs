using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using SOI.CliFrx;
using SOI.DNM;
using SOI.OIFrx;
using BOI.OIFrx;

using Miracom.TRSCore;

namespace BOI.WIPCus
{
    public partial class frmWIPInputMaterialBatchingPretreatment : BOI.OIFrx.BOIBaseForm.BOIBaseForm02
    {
        public frmWIPInputMaterialBatchingPretreatment()
        {
            InitializeComponent();
        }
       
        private enum BOM
        {
            MAT_ID,
            MAT_DESC,
            BOM_TYPE,
            QTY,
            INPUT_QTY,
            BONUS_QTY
        }

        private enum INPUT
        {
            INPUT_DATETIME,
            SEQ,
            LOT_ID,
            MAT_ID,
            MAT_DESC,
            STATUS,
            QTY,
            REMAIN_QTY,
            LOSS_QTY,
            SHELF_LIFE
        }

        

        // 자재 투입 및 투입 해제 시 상태 검사
        private bool Create_Input_List(string sKind)
        {
            TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[4];
            DataTable dt = null;
            string sSql = "";

            int i_row = 0, i_col = 0;
            double dInputQty = 0;
            double dAddQty = 0;

            try
            {
                dvcArgu[0].sCondtion_ID = "$FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "$LOT_ID";
                dvcArgu[1].sCondition_Value = txtMaterialLot.Text;

                dvcArgu[2].sCondtion_ID = "$RES_ID";
                //dvcArgu[2].sCondition_Value = spdWordOrder_Sheet1.Cells[0, (int)WRKORD.RES_ID].Tag.ToString();

                dvcArgu[3].sCondtion_ID = "$ITEM_ID";
                //for (i_row = 0; i_row < spdWordOrder_Sheet1.RowCount; i_row++)
                //{
                //    if (i_row != spdWordOrder_Sheet1.RowCount - 1)
                //        dvcArgu[3].sCondition_Value += "'" + spdWordOrder_Sheet1.Cells[i_row, (int)WRKORD.MAT_ID].Value + "'" + ",";
                //    else
                //        dvcArgu[3].sCondition_Value += "'" + spdWordOrder_Sheet1.Cells[i_row, (int)WRKORD.MAT_ID].Value + "'";
                //}

                if (TPDR.GetDataOne("", ref dt, "CWIP2401-001", dvcArgu, false, false, ref sSql) == false)
                {
                    if (dt != null)
                        dt.Dispose();

                    GC.Collect();
                    return false;
                }

                if (dt.Rows[0]["WIP_LOT_ID"].ToString() == string.Empty)
                {
                    // 자재 Lot이 없음
                    MPCF.ShowMessage(MPCF.GetMessage(404), MSG_LEVEL.ERROR, false);
                    return false;
                }

                // 자재 투입 시
                if (sKind == "Input")
                {
                    if (dt.Rows[0]["LOAD_LOT_ID"].ToString() != string.Empty)
                    {
                        // 이미 투입되었음.
                        MPCF.ShowMessage(MPCF.GetMessage(403), MSG_LEVEL.ERROR, false);
                        return false;
                    }

                    // 자재 Lot의 수량보다 투입 수량이 큰 경우
                    if (MPCF.ToDbl(dt.Rows[0]["QTY_1"]) < MPCF.ToDbl(numInputQty.Value))
                    {
                        MPCF.ShowMessage(MPCF.GetMessage(418), MSG_LEVEL.ERROR, false);
                        numInputQty.Focus();
                        return false;
                    }
                }
                // 자재 투입 해제 시
                else if (sKind == "Cancel")
                {
                    //if (dt.Rows[0]["LOAD_LOT_ID"].ToString() == string.Empty)
                    //{
                    //    // 투입된 자재 없음.
                    //    MPCF.ShowMessage(MPCF.GetMessage(405), MSG_LEVEL.ERROR, false);
                    //    return false;
                    //}
                }

                if (sKind == "Input")
                {
                    // D : 투입중, I : 투입, P : 생산중, C : 투입해제
                    spdPredetermin.Search(0, txtMaterialLot.Text, true, true, false, false, 0, (int)INPUT.LOT_ID, ref i_row, ref i_col);

                    // 투입 중인 데이터가 있는 투입량을 합산한다.
                    if (i_row > -1)
                    {
                        dInputQty = MPCF.ToDbl(spdPredetermin_Sheet1.Cells[i_row, (int)INPUT.QTY].Value);
                        dAddQty = MPCF.ToDbl(numInputQty.Value);
                        if (MPCF.ToDbl(dt.Rows[0]["QTY_1"]) < dInputQty + dAddQty)
                        {
                            MPCF.ShowMessage(MPCF.GetMessage(418), MSG_LEVEL.ERROR, false);
                            numInputQty.Focus();
                            return false;
                        }

                        spdPredetermin_Sheet1.Cells[i_row, (int)INPUT.QTY].Value = dInputQty + dAddQty;
                        spdPredetermin_Sheet1.Cells[i_row, (int)INPUT.REMAIN_QTY].Value = dInputQty + dAddQty;
                    }
                    else
                    {
                        i_row = spdPredetermin_Sheet1.RowCount;
                        spdPredetermin_Sheet1.RowCount++;

                        spdPredetermin_Sheet1.Cells[i_row, (int)INPUT.LOT_ID].Value = txtMaterialLot.Text;
                        spdPredetermin_Sheet1.Cells[i_row, (int)INPUT.MAT_ID].Value = dt.Rows[0]["MAT_ID"];
                        spdPredetermin_Sheet1.Cells[i_row, (int)INPUT.MAT_DESC].Value = dt.Rows[0]["MAT_DESC"];
                        spdPredetermin_Sheet1.Cells[i_row, (int)INPUT.STATUS].Value = MPCF.FindLanguage("During Input");
                        spdPredetermin_Sheet1.Cells[i_row, (int)INPUT.STATUS].Tag = 'D';
                        spdPredetermin_Sheet1.Cells[i_row, (int)INPUT.QTY].Value = numInputQty.Value;
                        spdPredetermin_Sheet1.Cells[i_row, (int)INPUT.REMAIN_QTY].Value = numInputQty.Value;
                        spdPredetermin_Sheet1.Cells[i_row, (int)INPUT.LOSS_QTY].Value = dt.Rows[0]["LOSS_QTY"];
                        spdPredetermin_Sheet1.Cells[i_row, (int)INPUT.SHELF_LIFE].Value = MPCF.MakeDateFormat(dt.Rows[0]["SHELF_LIFE"].ToString(), DATE_TIME_FORMAT.DATE);
                    }

                    txtMaterialLot.Clear();
                    numInputQty.Value = 0;
                }
                else if (sKind == "Cancel")
                {
                    spdPredetermin.Search(0, txtMaterialLot.Text, true, true, false, false, 0, (int)INPUT.LOT_ID, spdPredetermin_Sheet1.RowCount, (int)INPUT.LOT_ID, ref i_row, ref i_col);
                    if (i_row > -1)
                    {
                        spdPredetermin_Sheet1.Cells[i_row, (int)INPUT.STATUS].Tag = 'C';
                        spdPredetermin_Sheet1.Cells[i_row, (int)INPUT.STATUS].Value = MPCF.FindLanguage("Cancel Input");

                        txtMaterialLot.Clear();
                        numInputQty.Value = 0;
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

        /// <summary>
        /// 투입 리스트에서 자재 존재 여부 확인
        /// </summary>
        /// <returns></returns>
        private bool Check_Input_List(string sKind)
        {
            int i_col = 0;
            int i_row = 0;

            try
            {
                if (MPCF.Trim(txtMaterialLot.Text) == string.Empty)
                {
                    MPCF.ShowMessage(MPCF.GetMessage(108), MSG_LEVEL.ERROR, false);
                    txtMaterialLot.Focus();
                    return false;
                }

                if (sKind == "Input" && MPCF.ToDbl(numInputQty.Value) == 0)
                {
                    MPCF.ShowMessage(MPCF.GetMessage(114), MSG_LEVEL.ERROR, false);
                    txtMaterialLot.Focus();
                    return false;
                }

                spdPredetermin.Search(0, txtMaterialLot.Text, true, true, false, false, 0, (int)INPUT.LOT_ID, ref i_row, ref i_col);

                if (sKind == "Input" && i_row > -1)
                {
                    if (MPCF.Trim(spdPredetermin_Sheet1.Cells[i_row, (int)INPUT.STATUS].Tag) != "D")
                    {
                        MPCF.ShowMessage(MPCF.GetMessage(407), MSG_LEVEL.ERROR, false);
                        return false;
                    }
                }
                else if (sKind == "Cancel")
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
            int i_row = 0;//spdWordOrder_Sheet1.ActiveRowIndex;

            try
            {
                MPCF.SetInMsg(in_node);

                in_node.ProcStep = '1';
                //in_node.AddString("RES_ID", spdWordOrder_Sheet1.Cells[0, (int)WRKORD.RES_ID].Tag);
                //in_node.AddString("LINE_ID", spdWordOrder_Sheet1.Cells[0, (int)WRKORD.LINE_ID].Tag);

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

            int i = 0;
            int i_row = 0, i_col = 0;

            try
            {
                spdTargetMaterial_Sheet1.RowCount = 0;

                dvcArgu[0].sCondtion_ID = "$FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                i_row = 0;
                i_col = 0;

                dvcArgu[1].sCondtion_ID = "$MAT_ID";
                dvcArgu[1].sCondition_Value = MPCF.Trim(boiOrderInfo.spdOrderInfo.Sheets[0].GetValue(i_row, (int)BIGC.ORDER.MAT_ID));

                //dvcArgu[2].sCondtion_ID = "$BOM_TYPE";
                //dvcArgu[2].sCondition_Value = spdWordOrder_Sheet1.Cells[0, (int)WRKORD.BOM_TYPE].Text;

                //dvcArgu[3].sCondtion_ID = "$ORD_QTY";
                //dvcArgu[3].sCondition_Value = spdWordOrder_Sheet1.Cells[0, (int)WRKORD.ORDER_QTY].Text.Replace(",", "");

                if (TPDR.GetDataOne("", ref dt, "CWIP2401-002", dvcArgu, false, false, ref sSql) == false)
                {
                    if (dt != null)
                        dt.Dispose();

                    GC.Collect();
                    return false;
                }

                spdTargetMaterial.Search(0, dt.Rows[0]["MAT_ID"].ToString(), true, true, false, false, 0, (int)BOM.MAT_ID, ref i_row, ref i_col);
                if (i_row == -1)
                {
                    i_row = spdTargetMaterial_Sheet1.RowCount;
                    spdTargetMaterial_Sheet1.RowCount++;
                    spdTargetMaterial_Sheet1.Cells[i_row, (int)BOM.MAT_ID].Value = dt.Rows[0]["MAT_ID"];
                    spdTargetMaterial_Sheet1.Cells[i_row, (int)BOM.MAT_DESC].Value = dt.Rows[0]["MAT_DESC"];
                    spdTargetMaterial_Sheet1.Cells[i_row, (int)BOM.BOM_TYPE].Value = dt.Rows[0]["P_MAT_BOM_TYPE"];
                    spdTargetMaterial_Sheet1.Cells[i_row, (int)BOM.QTY].Value = dt.Rows[0]["REQ_QTY"];
                }
                else
                {
                    spdTargetMaterial_Sheet1.Cells[i_row, (int)BOM.QTY].Value = MPCF.ToInt(dt.Rows[0]["REQ_QTY"]) + MPCF.ToInt(spdTargetMaterial_Sheet1.Cells[i_row, (int)BOM.QTY].Value);
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

                dvcArgu[0].sCondtion_ID = "$FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "$RES_ID";
                //dvcArgu[1].sCondition_Value = MPCF.Trim(spdWordOrder_Sheet1.Cells[0, (int)WRKORD.RES_ID].Tag);

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
                    spdPredetermin_Sheet1.Cells[i, (int)INPUT.STATUS].Value = dt.Rows[i]["STATUS_DESC"];
                    spdPredetermin_Sheet1.Cells[i, (int)INPUT.STATUS].Tag = dt.Rows[i]["STATUS"];
                    spdPredetermin_Sheet1.Cells[i, (int)INPUT.QTY].Value = MPCF.ToDbl(dt.Rows[i]["INPUT_QTY"]); // 설비에 최초 투입 수량
                    spdPredetermin_Sheet1.Cells[i, (int)INPUT.REMAIN_QTY].Value = MPCF.ToDbl(dt.Rows[i]["REMAIN_QTY"]);
                    spdPredetermin_Sheet1.Cells[i, (int)INPUT.LOSS_QTY].Value = dt.Rows[i]["LOSS_QTY"];
                    spdPredetermin_Sheet1.Cells[i, (int)INPUT.SHELF_LIFE].Value = MPCF.MakeDateFormat(dt.Rows[i]["SHELF_LIFE"].ToString(), DATE_TIME_FORMAT.DATE);
                }
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
                //if (spdWordOrder_Sheet1.RowCount == 0)
                //{
                //    MPCF.ShowMessage(MPCF.GetMessage(401), MSG_LEVEL.ERROR, false);
                //    return false;
                //}

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
            int i = 0, i_row = 0;

            if (frm.ShowDialog() == DialogResult.OK)
            {
                //spdWordOrder_Sheet1.RowCount = 0;

                //for (i = 0; i < frm.mspdWorkOrder.RowCount; i++)
                //{
                //    if(Convert.ToBoolean(frm.mspdWorkOrder.Cells[i, (int)frmWIPViewWorkOrderList.ORD.SEL].Value))
                //    {
                //        i_row = spdWordOrder_Sheet1.RowCount;
                //        spdWordOrder_Sheet1.RowCount++;
                //        spdWordOrder_Sheet1.Cells[i_row, (int)WRKORD.ORDER_ID].Value = frm.mspdWorkOrder.Cells[i, (int)frmWIPViewWorkOrderList.ORD.ORDER_ID].Value;
                //        spdWordOrder_Sheet1.Cells[i_row, (int)WRKORD.ORDER_DATE].Value = frm.mspdWorkOrder.Cells[i, (int)frmWIPViewWorkOrderList.ORD.ORDER_DATE].Value; ;
                //        spdWordOrder_Sheet1.Cells[i_row, (int)WRKORD.MAT_ID].Value = frm.mspdWorkOrder.Cells[i, (int)frmWIPViewWorkOrderList.ORD.MAT_ID].Value;
                //        spdWordOrder_Sheet1.Cells[i_row, (int)WRKORD.MAT_DESC].Value = frm.mspdWorkOrder.Cells[i, (int)frmWIPViewWorkOrderList.ORD.MAT_DESC].Value;
                //        spdWordOrder_Sheet1.Cells[i_row, (int)WRKORD.BOM_TYPE].Value = frm.mspdWorkOrder.Cells[i, (int)frmWIPViewWorkOrderList.ORD.BOM_TYPE].Value;
                //        spdWordOrder_Sheet1.Cells[i_row, (int)WRKORD.ORDER_QTY].Value = frm.mspdWorkOrder.Cells[i, (int)frmWIPViewWorkOrderList.ORD.ORDER_QTY].Value;
                //        spdWordOrder_Sheet1.Cells[i_row, (int)WRKORD.RES_ID].Value = frm.mspdWorkOrder.Cells[i, (int)frmWIPViewWorkOrderList.ORD.RES_ID].Value;
                //        spdWordOrder_Sheet1.Cells[i_row, (int)WRKORD.RES_ID].Tag = frm.mspdWorkOrder.Cells[i, (int)frmWIPViewWorkOrderList.ORD.RES_ID].Tag;
                //        spdWordOrder_Sheet1.Cells[i_row, (int)WRKORD.LINE_ID].Value = frm.mspdWorkOrder.Cells[i, (int)frmWIPViewWorkOrderList.ORD.LINE_ID].Value;
                //        spdWordOrder_Sheet1.Cells[i_row, (int)WRKORD.LINE_ID].Tag = frm.mspdWorkOrder.Cells[i, (int)frmWIPViewWorkOrderList.ORD.LINE_ID].Tag;

                //        spdWordOrder_Sheet1.Cells[i_row, (int)WRKORD.STATUS].Value = frm.mspdWorkOrder.Cells[i, (int)frmWIPViewWorkOrderList.ORD.STATUS].Value;
                //        spdWordOrder_Sheet1.Cells[i_row, (int)WRKORD.STATUS].Tag = frm.mspdWorkOrder.Cells[i, (int)frmWIPViewWorkOrderList.ORD.STATUS].Tag;
                //    }
                //}

                //// 자재 소요량 계산
                //Material_Reqirement_Calculation();

                //// 설비에 투입한 자재 정보를 조회
                //View_Input_Info();
            }
        }

        private void txtMaterialLot_KeyDown(object sender, KeyEventArgs e)
        {
            string sKind = "";

            if (e.KeyData == Keys.Enter)
            {
                //if (chkOutSelection.OnOffState == SOI.OIFrx.SOICheckBoxOnOffState.OffState)
                //{
                //    sKind = "Cancel";

                //    // 자재 투입 예정 목록에 존재 유무 확인
                //    if (!Check_Input_List(sKind))
                //        return;

                //    if (!Create_Input_List(sKind))
                //        return;
                //}
                //else
                //{
                //    this.SelectNextControl(this.GetNextControl(sender as Control, true), true, true, true, true);
                //}
            }
        }

        private void btnReqInsp_Click(object sender, EventArgs e)
        {
            string sKind = "";

            //if (chkOutSelection.OnOffState == SOI.OIFrx.SOICheckBoxOnOffState.OnState)
            //{
            //    sKind = "Input";
            //}
            //else if (chkOutSelection.OnOffState == SOI.OIFrx.SOICheckBoxOnOffState.OffState)
            //{
            //    sKind = "Cancel";
            //}

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
            string sKind = "";

            if (e.KeyData == Keys.Enter)
            {
                //if (chkOutSelection.OnOffState == SOI.OIFrx.SOICheckBoxOnOffState.OnState)
                //{
                //    sKind = "Input";
                //}
                //else if (chkOutSelection.OnOffState == SOI.OIFrx.SOICheckBoxOnOffState.OffState)
                //{
                //    sKind = "Cancel";
                //}

                // 자재 투입 예정 목록에 존재 유무 확인
                if (!Check_Input_List(sKind))
                    return;

                if (!Create_Input_List(sKind))
                    return;

                MPCF.ShowMessageClear();
            }
        }

        private void spdPredetermin_KeyDown(object sender, KeyEventArgs e)
        {            
            if (e.Control == true && e.KeyCode == Keys.C)
            {
                if (spdPredetermin.ActiveSheet.SelectionCount == 0)
                {
                    Clipboard.SetDataObject(spdPredetermin_Sheet1.Cells[0, (int)INPUT.LOT_ID].Text, true);
                }
                else
                {
                    Clipboard.SetDataObject(spdPredetermin_Sheet1.Cells[spdPredetermin.ActiveSheet.ActiveRowIndex, (int)INPUT.LOT_ID].Text, true);
                }
            }
        }

        private void frmWIPInputMaterialBatchingPretreatment_Load(object sender, EventArgs e)
        {
            boiOrderInfo.View_Order_Info("000001");
            
        }

        private void boiOrderInfo_WorkOrderButtonClick(object sender, EventArgs e)
        {
            
        }
    }
}
