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

namespace SOI.SMT
{
    // (Required) Inherit Base Form
    // SOIBaseForm02 Common Role    
    // - Convert Theme 
    // - Register Favorite 
    // - Default Bottom Button : Process, Cancel 
    // - (option) Help Information Button
    // - (option for SE) Standard Operation Button
    public partial class frmSMTInputPCB : SOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;

        #endregion

        #region Constructor

        public frmSMTInputPCB()
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
        private void frmTempSOIBaseForm02_Load(object sender, EventArgs e)
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
        private void frmTempSOIBaseForm02_Shown(object sender, EventArgs e)
        {
            // (Required) 
            if (bIsShown == false)
            {
                // (Required) Init Focus Control
                MPCF.SetFocus(cdvOrderID);                

                // (Required) 
                bIsShown = true;
            }
        }

        /// <summary>
        /// Work Order ID CodeView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cdvOrderID_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                // In Node Setup
                TRSNode in_node = new TRSNode("VIEW_WORK_ORDER_LIST_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';

                // CodeView Column Header Setup
                string[] header = new string[] { "Order ID", "Order Description" };

                // CodeView Display Column Setup
                string[] display = new string[] { "ORDER_ID", "ORDER_DESC" };

                // Show
                cdvOrderID.Text = cdvOrderID.Show(cdvOrderID, "Order ID", "SMT", "SMT_View_Work_Order_List", in_node, "ORDER_LIST", display, header, "ORDER_ID");

                // Clear 
                FieldClearInForm();
                MPCF.FieldClear(this, cdvOrderID);                

                if (string.IsNullOrEmpty(cdvOrderID.Text) == false)
                {
                    if (ViewWorkOrder(cdvOrderID.Text) == false)
                    {
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
        /// Board Side Changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboBoardSide_SelectionChanged(object sender, EventArgs e)
        {
            if (ViewWorkOrderInput() == false)
            {
                return;
            }
        }

        /// <summary>
        /// Work Line CodeView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cdvWorkLine_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                if (MPCF.CheckValue(cdvOrderID, false) == false)
                {
                    return;
                }

                // In Node Setup
                TRSNode in_node = new TRSNode("VIEW_GCM_TABLE_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", "SUB_AREA");

                // CodeView Column Header Setup
                string[] header = new string[] { "Line ID", "Line Description", "Lane Type" };

                // CodeView Display Column Setup
                string[] display = new string[] { "KEY_1", "DATA_1", "DATA_4" };

                // Show
                cdvWorkLine.Text = cdvWorkLine.Show(cdvWorkLine, "Work Line", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "KEY_1");

                if (ViewWorkOrderInput() == false)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Lane Changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboLane_SelectionChanged(object sender, EventArgs e)
        {
            ViewWorkOrderInput();
        }

        /// <summary>
        /// Bare PCB Enter Key
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtBarePCB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Field Clear
                MPCF.FieldClear(pnlBarePCBField, txtBarePCB);

                if (MPCF.Trim(txtBarePCB.Text) != "")
                {
                    // Check Value
                    if (MPCF.CheckValue(cdvOrderID, false) == false)
                    {
                        txtBarePCB.Text = string.Empty;
                    }

                    // View Int Lost
                    if (ViewInvLot(txtBarePCB.Text) == false)
                    {
                        MPCF.SetFocus(txtBarePCB);
                        return;
                    }
                }
            }
        }

        /// <summary>
        ///  Lot ID Enter Key
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtLotID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (MPCF.Trim(txtLotID.Text) != "")
                {
                    // View Int Lost
                    if (InputPCB() == false)
                    {
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// Process Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProcess_Click(object sender, EventArgs e)
        {
            if (InputPCB() == false)
            {
                return;
            }
        }

        #endregion

        #region Function

        /// <summary>
        /// Field Clear
        /// </summary>
        private void FieldClearInForm()
        {
            lblPlanLineTopKey.Text = MPCF.FindLanguage("Plan Line Top");
            //tlpPlanLineBottom.Visible = true;
            tlpPlanLineBottomVisible.Visible = true;
            underLineBottomVisible.Visible = true;
            txtLotID.Enabled = false;

             lblOrderQty.Text = "0";
             lblInQty.Text = "0";
             lblOutQty.Text = "0";
             lblLossQty.Text = "0";
        }

        /// <summary>
        /// View Work Order by work order ID
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        private bool ViewWorkOrder(string orderId)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_ORDER_IN");
                TRSNode out_node = new TRSNode("VIEW_ORDER_OUT");

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("ORDER_ID", orderId);

                if (MPCF.CallService("SMT", "SMT_View_Work_Order", in_node, ref out_node) == false)
                {
                    return false;
                }

                txtDescription.Text = out_node.GetString("ORDER_DESC");
                txtMatID.Text = out_node.GetString("MAT_ID");
                txtPlanLineTop.Text = out_node.GetString("LINE_A_ID");
                txtPlanLineBottom.Text = out_node.GetString("LINE_B_ID");
                lblOrderQty.Text = out_node.GetDouble("ORDER_QTY").ToString("#,###,##0.###");
                lblInQty.Text = out_node.GetDouble("IN_QTY").ToString("#,###,##0.###");
                lblOutQty.Text = out_node.GetDouble("OUT_QTY").ToString("#,###,##0.###");
                lblLossQty.Text = out_node.GetDouble("LOSS_QTY").ToString("#,###,##0.###");

                if (out_node.GetChar("SAME_LINE_FLAG") == 'Y')
                {
                    lblPlanLineTopKey.Text = MPCF.FindLanguage("Plan Line");
                    tlpPlanLineBottomVisible.Visible = false;
                    underLineBottomVisible.Visible = false;
                }
                else
                {
                    lblPlanLineTopKey.Text = MPCF.FindLanguage("Plan Line Top");
                    tlpPlanLineBottomVisible.Visible = true;
                    underLineBottomVisible.Visible = true;
                }

                if (out_node.GetChar("BOARD_TYPE") == 'M')
                {
                    txtLotID.Enabled = true;
                }
                else
                {
                    txtLotID.Enabled = false;
                }

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage("View Work Order() : " + ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        /// <summary>
        /// View Work Order Input
        /// </summary>
        /// <returns></returns>
        private bool ViewWorkOrderInput()
        {
            try
            {
                // Clear Field
                MPCF.FieldClear(tlpInputOperation);
                MPCF.FieldClear(tlpInputResID);

                if (cboBoardSide.SelectedIndex < 0)
                {
                    return false;
                }

                if (string.IsNullOrEmpty(cdvWorkLine.Text) == true)
                {
                    return false;
                }

                if (cboLane.SelectedIndex < 0)
                {
                    return false;
                }

                // Check Value
                if (MPCF.CheckValue(cdvOrderID, false) == false)
                {
                    return false;
                }

                // Call Service
                TRSNode in_node = new TRSNode("VIEW_FIRST_OPER_IN");
                TRSNode out_node = new TRSNode("VIEW_FIRST_OPER_OUT");

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("ORDER_ID", cdvOrderID.Text);
                in_node.AddChar("BOARD_SIDE", MPCF.ToChar(cboBoardSide.SelectedItem.DataValue));
                in_node.AddString("LINE_ID", cdvWorkLine.Text);
                in_node.AddString("LANE_ID", cboLane.SelectedItem.DataValue.ToString());

                if (MPCF.CallService("SMT", "SMT_View_First_Oper", in_node, ref out_node) == false)
                {
                    return false;
                }

                txtInputOper.Text = out_node.GetString("INPUT_OPER");
                txtInputResID.Text = out_node.GetString("INPUT_RES_ID");

                MPCF.SetFocus(txtBarePCB);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage("ViewWorkOrderInput() : " + ex.Message, MSG_LEVEL.ERROR, false);
                return false;                    
            }
        }

        /// <summary>
        /// View Inv Lot
        /// </summary>
        /// <returns></returns>
        private bool ViewInvLot(string invLotId)
        {
            try
            {
                // Call Service
                TRSNode in_node = new TRSNode("VIEW_FIRST_OPER_IN");
                TRSNode out_node = new TRSNode("VIEW_FIRST_OPER_OUT");

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("STORE_ID", "LSTO");
                in_node.AddString("INV_LOT_ID", invLotId);

                if (MPCF.CallService("INV", "INV_View_Inv_Lot", in_node, ref out_node) == false)
                {
                    return false;
                }

                txtBarePCBDesc.Text = out_node.GetString("INV_LOT_DESC");
                txtBarePCBQty.Text = out_node.GetDouble("QTY_1").ToString("#,###,##0.###");

                MPCF.SetFocus(txtLotID);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage("ViewWorkOrderInput() : " + ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        /// <summary>
        /// Input PCB
        /// </summary>
        /// <returns></returns>
        private bool InputPCB()
        {
            try
            {
                // Check Value
                if (MPCF.CheckValue(cdvOrderID, false) == false)
                {
                    return false;
                }
                if (MPCF.CheckValue(cboBoardSide, false) == false)
                {
                    return false;
                }
                if (MPCF.CheckValue(cdvWorkLine, false) == false)
                {
                    return false;
                }
                if (MPCF.CheckValue(cboLane, false) == false)
                {
                    return false;
                }
                if (MPCF.CheckValue(txtLotID, false) == false)
                {
                    return false;
                }

                // Call Service
                TRSNode in_node = new TRSNode("INPUT_PCB_IN");
                TRSNode out_node = new TRSNode("INPUT_PCB_OUT");

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("ORDER_ID", cdvOrderID.Text);
                in_node.AddString("LOT_ID", txtLotID.Text);
                in_node.AddString("OPER", txtInputOper.Text);
                in_node.AddString("RES_ID", txtInputResID);
                in_node.AddString("LINE_ID", cdvWorkLine.Text);
                in_node.AddString("LANE_ID", cboLane.SelectedItem.DataValue.ToString());
                in_node.AddChar("IN_BOARD_SIDE", MPCF.ToChar(cboBoardSide.SelectedItem.DataValue));
                in_node.AddString("BARE_PCB", txtBarePCB.Text);
                
                if (MPCF.CallService("SMT", "SMT_Input_Pcb", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCF.ShowSuccessMessage(out_node, false);

                txtLotID.Text = string.Empty;
                txtBarePCBQty.Text = out_node.GetDouble("QTY_1").ToString("#,###,##0.###");

                MPCF.SetFocus(txtLotID);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage("ViewWorkOrderInput() : " + ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        #endregion
    }
}
