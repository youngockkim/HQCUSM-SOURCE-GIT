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
    public partial class frmSMTSlotMappingMat : SOIBaseForm02
    {
        #region Property

        // (Required)
        private bool bIsShown = false;

        #endregion

        #region Constructor

        public frmSMTSlotMappingMat()
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
        private void frmTempSOIBaseForm04_Load(object sender, EventArgs e)
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
        private void frmTempSOIBaseForm04_Shown(object sender, EventArgs e)
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
        /// Order ID CodeView
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
                string[] header = new string[] { "Order ID", "Order Description", "Order Type" };

                // CodeView Display Column Setup
                string[] display = new string[] { "ORDER_ID", "ORDER_DESC", "ORDER_TYPE" };

                // Show
                cdvOrderID.Text = cdvOrderID.Show(cdvOrderID, "Order ID", "SMT", "SMT_View_Work_Order_List", in_node, "ORDER_LIST", display, header, "ORDER_ID");

                // Field Clear
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
        /// Resource ID CodeView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cdvResID_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                // In Node Setup
                TRSNode in_node = new TRSNode("VIEW_RESOURCE_LIST_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '2';
                in_node.AddString("RES_GRP", "MOUNT");

                // CodeView Column Header Setup
                string[] header = new string[] { "Resource ID", "Resource Description" };

                // CodeView Display Column Setup
                string[] display = new string[] { "RES_ID", "RES_DESC" };

                // Show
                cdvResID.Text = cdvResID.Show(cdvResID, "Resource", "RAS", "RAS_View_Resource_List_Detail", in_node, "RES_LIST", display, header, "RES_ID");
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Slot Search
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSlotSearch_Click(object sender, EventArgs e)
        {
            try
            {
                // Check Value
                if (MPCF.CheckValue(cdvOrderID, false) == false)
                {
                    return;
                }
                if (MPCF.CheckValue(txtSlot, false) == false)
                {
                    return;
                }

                if (ViewSlotInfo() == false)
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
        /// Slot Enter Key
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSlot_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter
                && MPCF.Trim(txtSlot.Text) != "")
            {
                // Check Value
                if (MPCF.CheckValue(cdvOrderID, false) == false)
                {
                    return;
                }
                if (MPCF.CheckValue(txtSlot, false) == false)
                {
                    return;
                }

                if (ViewSlotInfo() == false)
                {
                    MPCF.SetFocus(txtSlot);
                    txtSlot.SelectAll();
                    return;
                }
            }
        }

        /// <summary>
        /// Slot Mapping Material
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProcess_Click(object sender, EventArgs e)
        {
            if (SlotMappingMat() == false)
            {
                return;
            }
        }

        #endregion

        #region Function

        /// <summary>
        /// Field Clear
        /// </summary>
        /// <returns></returns>
        private void FieldClearInForm()
        {
            lblPlanLineTopKey.Text = MPCF.FindLanguage("Plan Line Top");
            tlpPlanLineBottom.Visible = true;
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

                lblDescription.Text = out_node.GetString("ORDER_DESC");
                lblMaterial.Text = out_node.GetString("MAT_ID");
                lblPlanLineTop.Text = out_node.GetString("LINE_A_ID");
                lblPlanLineBottom.Text = out_node.GetString("LINE_B_ID");
                lblOrderQty.Text = out_node.GetDouble("ORDER_QTY").ToString("#,###,##0.###");
                lblInQty.Text = out_node.GetDouble("IN_QTY").ToString("#,###,##0.###");
                lblOutQty.Text = out_node.GetDouble("OUT_QTY").ToString("#,###,##0.###");
                lblLossQty.Text = out_node.GetDouble("LOSS_QTY").ToString("#,###,##0.###");

                if (out_node.GetChar("SAME_LINE_FLAG") == 'Y')
                {
                    lblPlanLineTopKey.Text = MPCF.FindLanguage("Plan Line");
                    tlpPlanLineBottom.Visible = false;
                }
                else
                {
                    lblPlanLineTopKey.Text = MPCF.FindLanguage("Plan Line Top");
                    tlpPlanLineBottom.Visible = true;
                }

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage("ViewWorkOrder() : " + ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        /// <summary>
        /// View Slot Info
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        private bool ViewSlotInfo()
        {
            try
            {
                // Field Clear
                MPCF.FieldClear(grbSlotInfo);

                TRSNode in_node = new TRSNode("VIEW_SLOT_INFO_IN");
                TRSNode out_node = new TRSNode("VIEW_SLOT_INFO_OUT");

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("ORDER_ID", cdvOrderID.Text);
                in_node.AddString("RES_ID", cdvResID.Text);
                in_node.AddString("SLOT", txtSlot.Text);

                if (MPCF.CallService("SMT", "SMT_View_Slot_Info", in_node, ref out_node) == false)
                {
                    return false;
                }

                lblSlotLine.Text = out_node.GetString("LINE_ID");
                lblSlotInvMatId.Text = out_node.GetString("PART_NAME");

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage("ViewWorkOrder() : " + ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        /// <summary>
        /// Slot Mapping Magerial
        /// </summary>
        /// <returns></returns>
        private bool SlotMappingMat()
        {
            try
            {
                // CheckValue
                if (MPCF.CheckValue(cdvOrderID, false) == false)
                {
                    return false;
                }
                if (MPCF.CheckValue(cdvResID, false) == false)
                {
                    return false;
                }
                if (MPCF.CheckValue(txtSlot, false) == false)
                {
                    return false;
                }
                
                // Feeder
                if (tabSlotMapMat.SelectedTab.Index == 0)
                {
                    if (MPCF.CheckValue(txtFeederID, false) == false)
                    {
                        return false;
                    }
                }
                // Inventory Lot 
                else
                {
                    if (MPCF.CheckValue(txtInvLotID, false) == false)
                    {
                        return false;
                    }
                }

                TRSNode in_node = new TRSNode("MAPPING_SLOT_FEEDER_IN");
                TRSNode out_node = new TRSNode("MAPPING_SLOT_FEEDER_OUT");

                MPCF.SetInMsg(in_node);

                if (tabSlotMapMat.SelectedTab.Index == 0)
                {
                    in_node.ProcStep = '1';
                    in_node.AddString("FEEDER_ID", txtFeederID.Text);
                }
                else
                {
                    in_node.ProcStep = '2';
                    in_node.AddString("INV_LOT_ID", txtInvLotID.Text);
                }
                
                in_node.AddString("ORDER_ID", cdvOrderID.Text);
                in_node.AddString("RES_ID", cdvResID.Text);
                in_node.AddString("SLOT_ID", txtSlot.Text);
                in_node.AddString("LINE_ID", lblSlotLine.Text);                

                if (MPCF.CallService("SMT", "SMT_Mapping_Slot_Feeder", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCF.ShowSuccessMessage(out_node, false);

                // Field Clear
                MPCF.FieldClear(tlpSlotTextBox);
                MPCF.FieldClear(grbSlotInfo);
                MPCF.FieldClear(tlpFeederIDTextBox);
                MPCF.FieldClear(tlpInvLotIdTextBox);

                MPCF.SetFocus(txtSlot);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage("ViewWorkOrder() : " + ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        #endregion
    }
}
