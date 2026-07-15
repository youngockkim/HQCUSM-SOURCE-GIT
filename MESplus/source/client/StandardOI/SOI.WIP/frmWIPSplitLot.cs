using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Miracom.TRSCore;
using SOI.OIFrx;
using SOI.OIFrx.SOIBaseForm;
using SOI.OIFrx.SOIControls;
using SOI.OIFrx.SOIPopup;
using SOI.OIFrx.SOIModel;
using SOI.CliFrx;
using Infragistics.Win.UltraWinGrid;

namespace SOI.WIP
{
    // (Required) Inherit Base Form
    // SOIBaseForm02 Common Role    
    // - Convert Theme 
    // - Register Favorite 
    // - Default Bottom Button : Process, Cancel 
    // - (option) Help Information Button
    // - (option for SE) Standard Operation Button
    public partial class frmWIPSplitLot : SOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;

        private TRSNode ORDER = new TRSNode("ORDER_INFO");
        private TRSNode LOT = new TRSNode("LOT_INFO");

        private enum COL_CHILD_LOT_LIST
        {
            CHK = 0,
            SEQ,
            CHILD_LOT_ID,
            QTY
        }

        #endregion

        #region Constructor

        public frmWIPSplitLot()
        {
            InitializeComponent();
        }

        #endregion

        #region Event Handler

        /// <summary>
        /// (Required) Form Load
        /// - Convert Caption
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmWIPSplitLot_Load(object sender, EventArgs e)
        {
            // (Required) Convert Caption
            // 모든 로드가 완료되면 Caption 변환을 위해 아래 구문을 추가해야 합니다.
            MPCF.ConvertCaption(this);            
        }

        /// <summary>
        /// (Required) Form Shown
        /// - Focus Control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmWIPSplitLot_Shown(object sender, EventArgs e)
        {
            // 최초 1회 실행
            if (bIsShown == false)
            {
                MPCF.SetFocus(txtLotID);
                
                bIsShown = false;
            }
        }

        /// <summary>
        /// Lot ID에서 엔터키 입력 시 조회합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtLotID_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                // Validation (Enter Key)
                if (e.KeyCode == Keys.Enter)
                {
                    // Validation (Lot ID)
                    if (MPCF.CheckValue(txtLotID, false) == false)
                    {
                        return;
                    }

                    // View Lot
                    if (ViewLot(txtLotID.Text) == false)
                    {
                        MPCF.SetFocus(txtLotID);
                        txtLotID.SelectAll();
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Search 버튼 클릭 시
        /// Lot 정보 조회
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLotIDSearch_Click(object sender, EventArgs e)
        {
            try
            {
                // Validation
                if (MPCF.CheckValue(txtLotID, false) == false)
                {
                    return;
                }

                // View Lot
                if (ViewLot(txtLotID.Text) == false)
                {
                    MPCF.SetFocus(txtLotID);
                    txtLotID.SelectAll();
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// View Lot Status
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnViewLotStatus_Click(object sender, EventArgs e)
        {
            try
            {
                // Validation
                if (MPCF.CheckValue(txtLotID, false) == false)
                {
                    return;
                }

                frmWIPViewLotStatusPopup f = new frmWIPViewLotStatusPopup(txtLotID.Text);
                f.Owner = MPGV.gfrmMDI;
                f.ShowDialog();
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// View Lot History
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnViewLotHistory_Click(object sender, EventArgs e)
        {
            try
            {
                // Validation
                if (MPCF.CheckValue(txtLotID, false) == false)
                {
                    return;
                }

                frmWIPViewLotHistoryPopup f = new frmWIPViewLotHistoryPopup(txtLotID.Text);
                f.Owner = MPGV.gfrmMDI;
                f.ShowDialog();
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// View Work Order 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnViewWorkOrder_Click(object sender, EventArgs e)
        {
            try
            {
                // Validation
                if (ORDER.GetString("ORDER_ID") == null 
                    || ORDER.GetString("ORDER_ID") == "")
                {
                    MPCF.SetFocus(txtLotID);
                    return;
                }

                frmWIPViewWorkOrderPopup f = new frmWIPViewWorkOrderPopup(ORDER.GetString("ORDER_ID"));
                f.Owner = MPGV.gfrmMDI;
                f.ShowDialog();
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Add Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Validation
                if (MPCF.CheckValue(txtLotID, false) == false)
                {
                    return;
                }
                if (MPCF.CheckValue(txtSplitQty, 0.0005, Double.MaxValue, false) == false)
                {
                    return;
                }

                // 2. Get Total Child Lot Qty
                double dChildQtyTotal = 0;
                for (int i = 0; i < spdChildLotList.ActiveSheet.RowCount; i++)
                {
                    dChildQtyTotal += MPCF.ToDbl(spdChildLotList.ActiveSheet.Cells[i, (int)COL_CHILD_LOT_LIST.QTY].Value);
                }

                // 3. 제한사항
                // Lot 수량보다 큰 값은 입력할 수 없음.
                if (((dChildQtyTotal + MPCF.ToDbl(txtSplitQty.Value)) - LOT.GetDouble("QTY_1")) > 0.0005)
                {
                    txtSplitQty.Value = 0;
                    // Input value exceeds limit value. Try another value.
                    MPCF.ShowMessage(MPCF.GetMessage(68), MSG_LEVEL.ERROR, false); 
                    return;
                }
                // Lot 수량을 초과하여 분리할 수 없음.
                if ((dChildQtyTotal + MPCF.ToDbl(txtSplitQty.Value)) > LOT.GetDouble("QTY_1"))
                {
                    txtSplitQty.Value = 0;
                    // Input value exceeds limit value. Try another value.
                    MPCF.ShowMessage(MPCF.GetMessage(68), MSG_LEVEL.ERROR, false);
                    return;
                }

                string sChildLotId = txtLotID.Text;
                if (chkGenChildLot.Checked == true)
                {
                    if (GenChildLotID(ref sChildLotId) == false)
                    {
                        return;
                    }
                }

                // Row 추가
                spdChildLotList.ActiveSheet.RowCount++;

                // 값 추가
                spdChildLotList.ActiveSheet.Cells[spdChildLotList.ActiveSheet.RowCount - 1, (int)COL_CHILD_LOT_LIST.CHK].Value = true;
                spdChildLotList.ActiveSheet.Cells[spdChildLotList.ActiveSheet.RowCount - 1, (int)COL_CHILD_LOT_LIST.SEQ].Value = spdChildLotList.ActiveSheet.RowCount;
                spdChildLotList.ActiveSheet.Cells[spdChildLotList.ActiveSheet.RowCount - 1, (int)COL_CHILD_LOT_LIST.CHILD_LOT_ID].Value = sChildLotId;
                spdChildLotList.ActiveSheet.Cells[spdChildLotList.ActiveSheet.RowCount - 1, (int)COL_CHILD_LOT_LIST.QTY].Value = MPCF.MakeNumberFormat(MPCF.ToDbl(txtSplitQty.Value));

                lblTotalSplitQty.Text = MPCF.MakeNumberFormat((MPCF.ToDbl(MPCF.DestroyNumberFormat(lblTotalSplitQty.Text)) + MPCF.ToDbl(txtSplitQty.Value)));
                lblLotRemainQty.Text = MPCF.MakeNumberFormat((LOT.GetDouble("QTY_1") - MPCF.ToDbl(MPCF.DestroyNumberFormat(lblTotalSplitQty.Text))));

                txtSplitQty.Text = "";
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Del Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                // 데이터가 없는 경우 종료
                if (spdChildLotList.ActiveSheet.RowCount < 1)
                {
                    return;
                }

                // Row 제거
                for (int i = 1; i <= spdChildLotList.ActiveSheet.RowCount; i++)
                {
                    if ((bool)spdChildLotList.ActiveSheet.Cells[spdChildLotList.ActiveSheet.RowCount - i, (int)COL_CHILD_LOT_LIST.CHK].Value == true)
                    {
                        spdChildLotList.ActiveSheet.RemoveRows(spdChildLotList.ActiveSheet.RowCount - i, (int)COL_CHILD_LOT_LIST.SEQ);
                    }
                }

                double dChildLotQtyTotal = 0;

                for (int i = 0; i < spdChildLotList.ActiveSheet.RowCount; i++)
                {
                    spdChildLotList.ActiveSheet.Cells[spdChildLotList.ActiveSheet.RowCount - 1, (int)COL_CHILD_LOT_LIST.SEQ].Value = i + 1;
                    dChildLotQtyTotal += MPCF.ToDbl(spdChildLotList.ActiveSheet.Cells[i, (int)COL_CHILD_LOT_LIST.QTY].Value);
                }

                lblTotalSplitQty.Text = MPCF.MakeNumberFormat(dChildLotQtyTotal);
                lblLotRemainQty.Text = MPCF.MakeNumberFormat((LOT.GetDouble("QTY_1") - dChildLotQtyTotal));
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Process Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                // Validation
                if (MPCF.CheckValue(txtLotID, false) == false)
                {
                    return;
                }

                if (spdChildLotList.ActiveSheet.RowCount < 1)
                {
                    MPCF.ShowMessage(MPCF.GetMessage(107), MSG_LEVEL.ERROR, false);
                    MPCF.SetFocus(txtSplitQty);
                    return;
                }

                if (MultiSplitLot() == false)
                {
                    MPCF.SetFocus(txtLotID);
                    txtLotID.SelectAll();                    
                    return;
                }

                MPCF.SetFocus(txtLotID);
                txtLotID.SelectAll();                
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Enter on Split Qty Text Box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSplitQty_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnAdd_Click(null, null);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        #endregion

        #region Functions

        /// <summary>
        /// View Lot
        /// </summary>
        /// <param name="sLotId"></param>
        /// <returns></returns>
        private bool ViewLot(string sLotId)
        {
            TRSNode in_node = new TRSNode("VIEW_LOT_IN");

            try
            {
                // Clear
                MPCF.FieldClear(this, txtLotID);
                LOT.Init();
                
                // Call Service
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LOT_ID", MPCF.Trim(sLotId));

                if (MPCF.CallService("WIP", "WIP_View_Lot", in_node, ref LOT) == false)
                {
                    return false;
                }
                
                // Bind
                txtMaterial.Text = LOT.GetString("MAT_ID") + " : " + LOT.GetString("MAT_DESC");
                txtOper.Text = LOT.GetString("OPER") + " : " + LOT.GetString("OPER_DESC");
                txtQty.Text = MPCF.MakeNumberFormat(LOT.GetDouble("QTY_1"));;

                if (ViewOrder(LOT.GetString("ORDER_ID")) == false)
                {
                    return false;
                }

                if (LOT.GetString("LOT_STATUS") == "PROC")
                {
                    pbStart.LotStatus = true;
                }
                else
                {
                    pbStart.LotStatus = false;
                }
                pbHold.LotStatus = (LOT.GetChar("HOLD_FLAG") == 'Y' ? true : false);
                pbRework.LotStatus = (LOT.GetChar("RWK_FLAG") == 'Y' ? true : false);
                pbRepair.LotStatus = (LOT.GetChar("REP_FLAG") == 'Y' ? true : false);
                pbInventory.LotStatus = (LOT.GetChar("INV_FLAG") == 'Y' ? true : false);
                pbTransit.LotStatus = (LOT.GetChar("TRANSIT_FLAG") == 'Y' ? true : false);

                lblTotalSplitQty.Text = lblLotRemainQty.Text = "";

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        /// <summary>
        /// View Order
        /// </summary>
        /// <param name="sOrderId"></param>
        /// <returns></returns>
        private bool ViewOrder(string sOrderId)
        {
            TRSNode in_node = new TRSNode("VIEW_ORDER_IN");
            TRSNode out_node = new TRSNode("VIEW_ORDER_OUT");

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("ORDER_ID", sOrderId);

                if (MPCF.CallService("ORD", "ORD_View_Order", in_node, ref out_node) == false)
                {
                    return false;
                }

                ORDER = out_node;
                txtWorkOrder.Text = out_node.GetString("ORDER_ID") + " : " + out_node.GetString("ORDER_DESC");
                txtCustomer.Text = out_node.GetString("CUSTOMER_ID");
                txtLine.Text = out_node.GetString("WORK_LINE") + " : " + out_node.GetString("WORK_LINE_DESC"); ;

                lblOrderQty.Text = MPCF.MakeNumberFormat(out_node.GetDouble("ORD_QTY"));
                lblInQty.Text = MPCF.MakeNumberFormat(out_node.GetDouble("ORD_IN_QTY"));
                lblOutQty.Text = MPCF.MakeNumberFormat(out_node.GetDouble("ORD_OUT_QTY"));
                lblLossQty.Text = MPCF.MakeNumberFormat(out_node.GetDouble("ORD_LOSS_QTY"));

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        /// <summary>
        /// Generate Child Lot ID
        /// </summary>
        /// <param name="sChildLotId"></param>
        /// <returns></returns>
        private bool GenChildLotID(ref string sChildLotId)
        {
            TRSNode in_node = new TRSNode("GENERATE_IN");
            TRSNode out_node = new TRSNode("GENERATE_OUT");

            try
            {
                // Call Service
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("MAT_ID", LOT.GetString("MAT_ID"));                
                in_node.AddString("FLOW", LOT.GetString("FLOW"));
                in_node.AddString("OPER", LOT.GetString("OPER"));
                in_node.AddChar("REL_LEVEL", '1');
                in_node.AddString("TRAN_CODE", "SPLIT");
                in_node.AddString("LOT_ID", txtLotID.Text);
                in_node.AddString("SEQ_KEY_2", txtLotID.Text);

                if (MPCF.CallService("WIP", "WIP_Generate_ID", in_node, ref out_node) == false)
                {
                    return false;
                }

                // Bind
                if (string.IsNullOrEmpty(out_node.GetString("GEN_ID")) == false)
                {
                    sChildLotId = out_node.GetString("GEN_ID");
                }

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        /// <summary>
        /// Multi Split Lot
        /// </summary>
        /// <returns></returns>
        private bool MultiSplitLot()
        {
            bool bFailed = false;
            List<int> successIndex = new List<int>();
            List<WIPSplitLotFailedModel> failedList = new List<WIPSplitLotFailedModel>();
            TRSNode in_node = new TRSNode("SPLIT_LOT_IN");
            TRSNode out_node = new TRSNode("SPLIT_LOT_OUT");

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';

                in_node.AddString("LOT_ID", txtLotID.Text);
                in_node.AddInt("LAST_ACTIVE_HIST_SEQ", LOT.GetInt("LAST_ACTIVE_HIST_SEQ"));
                in_node.AddString("MAT_ID", LOT.GetString("MAT_ID"));
                in_node.AddInt("MAT_VER", LOT.GetInt("MAT_VER"));
                in_node.AddString("FLOW", LOT.GetString("FLOW"));
                in_node.AddInt("FLOW_SEQ_NUM", LOT.GetInt("FLOW_SEQ_NUM"));
                in_node.AddString("OPER", LOT.GetString("OPER"));
                in_node.AddString("CHILD_MAT_ID", LOT.GetString("MAT_ID"));
                in_node.AddString("CHILD_FLOW", LOT.GetString("FLOW"));
                in_node.AddString("CHILD_OPER", LOT.GetString("OPER"));

                for (int i = 0; i < spdChildLotList.Sheets[0].Rows.Count; i++ )
                {   
                    in_node.SetString("CHILD_LOT_ID", spdChildLotList.Sheets[0].Cells[i, (int)COL_CHILD_LOT_LIST.CHILD_LOT_ID].Value);
                    in_node.SetDouble("MOVE_QTY_1", MPCF.ToDbl(spdChildLotList.Sheets[0].Cells[i, (int)COL_CHILD_LOT_LIST.QTY].Value));

                    if (MPCF.CallService("WIP", "WIP_Split_Lot", in_node, ref  out_node) == false)
                    {
                        bFailed = true;

                        for (int index = 0; index < spdChildLotList.Sheets[0].Rows.Count; index++)
                        {
                            if (successIndex.Contains(index) == true)
                            {
                                continue;
                            }
                            else
                            {
                                WIPSplitLotFailedModel failedModel = new WIPSplitLotFailedModel();
                                failedModel.Child_Lot_ID = spdChildLotList.Sheets[0].Cells[index, (int)COL_CHILD_LOT_LIST.CHILD_LOT_ID].Value != null ? spdChildLotList.Sheets[0].Cells[index, (int)COL_CHILD_LOT_LIST.CHILD_LOT_ID].Value.ToString() : string.Empty;
                                failedModel.Qty = spdChildLotList.Sheets[0].Cells[index, (int)COL_CHILD_LOT_LIST.QTY].Value != null ? spdChildLotList.Sheets[0].Cells[index, (int)COL_CHILD_LOT_LIST.QTY].Value.ToString() : string.Empty;
                                failedList.Add(failedModel);
                            }
                        }

                        break;
                    }

                    successIndex.Add(i);
                    in_node.SetInt("LAST_ACTIVE_HIST_SEQ", in_node.GetInt("LAST_ACTIVE_HIST_SEQ")+1);
                }

                // 한건이라도 실패한 경우
                if (bFailed == true)
                {
                    // 재조회
                    if (ViewLot(txtLotID.Text) == false)
                    {
                        return false;
                    }

                    // Out Message
                    MPCF.ShowMessage(out_node.GetString(TRSDefine.OUT_MSG), MSG_LEVEL.ERROR, false);

                    foreach (WIPSplitLotFailedModel mod in failedList)
                    {
                        // Row 추가
                        spdChildLotList.ActiveSheet.RowCount++;

                        // 값 추가
                        spdChildLotList.ActiveSheet.Cells[spdChildLotList.ActiveSheet.RowCount - 1, (int)COL_CHILD_LOT_LIST.CHK].Value = true;
                        spdChildLotList.ActiveSheet.Cells[spdChildLotList.ActiveSheet.RowCount - 1, (int)COL_CHILD_LOT_LIST.SEQ].Value = spdChildLotList.ActiveSheet.RowCount;
                        spdChildLotList.ActiveSheet.Cells[spdChildLotList.ActiveSheet.RowCount - 1, (int)COL_CHILD_LOT_LIST.CHILD_LOT_ID].Value = mod.Child_Lot_ID;
                        spdChildLotList.ActiveSheet.Cells[spdChildLotList.ActiveSheet.RowCount - 1, (int)COL_CHILD_LOT_LIST.QTY].Value = mod.Qty;

                        // 총 Split 수량
                        lblTotalSplitQty.Text = MPCF.MakeNumberFormat((MPCF.ToDbl(MPCF.DestroyNumberFormat(lblTotalSplitQty.Text)) + MPCF.ToDbl(MPCF.DestroyNumberFormat(mod.Qty))));
                        lblLotRemainQty.Text = MPCF.MakeNumberFormat((LOT.GetDouble("QTY_1") - MPCF.ToDbl(MPCF.DestroyNumberFormat(lblTotalSplitQty.Text))));

                    }

                    return false;
                }

                // 성공한 경우
                if (ViewLot(txtLotID.Text) == false)
                {
                    return false;
                }

                txtSplitQty.Value = 0;
                
                MPCF.ShowSuccessMessage(out_node, false);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        #endregion
    }

    public class WIPSplitLotFailedModel
    {
        private string child_Lot_ID;
        public string Child_Lot_ID
        {
            get { return child_Lot_ID; }
            set { child_Lot_ID = value; }
        }

        private string qty;
        public string Qty
        {
            get { return qty; }
            set { qty = value; }
        }
    }
}
