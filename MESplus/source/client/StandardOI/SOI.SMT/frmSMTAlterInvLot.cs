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
    public partial class frmSMTAlterInvLot : SOIBaseForm02
    {
        #region Property

        // (Required)
        private bool bIsShown = false;

        #endregion

        #region Constructor

        public frmSMTAlterInvLot()
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
                MPCF.SetFocus(cdvLine);                

                // (Required) 
                bIsShown = true;
            }
        }

        /// <summary>
        /// Line CodeView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cdvLine_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                MPCF.FieldClear(this, cdvLine);

                // In Node Setup
                TRSNode in_node = new TRSNode("VIEW_GCM_TABLE_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", "SUB_AREA");
                in_node.AddString("DATA_2", "SMT");

                // CodeView Column Header Setup
                string[] header = new string[] { "Line ID", "Line Description" };

                // CodeView Display Column Setup
                string[] display = new string[] { "KEY_1", "DATA_1"};

                // Show
                cdvLine.Text = cdvLine.Show(cdvLine, "Work Line", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "KEY_1");
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Inv Lot Id (Old) Enter Key
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtInvLotOld_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (MPCF.Trim(txtInvLotOld.Text) != "")
                {
                    // CheckValue
                    if (MPCF.CheckValue(cdvLine, false) == false)
                    {
                        return;
                    }

                    if (ViewInvLotData() == false)
                    {
                        MPCF.SetFocus(txtInvLotOld);
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// Inv Lot ID (NEW) Enter Key
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtInvLotNew_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (MPCF.Trim(txtInvLotNew.Text) != "")
                {
                    if (AlterInvLot() == false)
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
            if (AlterInvLot() == false)
            {
                return;
            }
        }

        /// <summary>
        /// Resource ID CodeView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cdvSlotResId_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                if (MPCF.CheckValue(cdvLine, false) == false)
                {
                    return;
                }

                MPCF.FieldClear(tlpSlotInfo, cdvSlotResId);

                // In Node Setup
                TRSNode in_node = new TRSNode("VIEW_RESOURCE_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LINE_ID", cdvLine.Text);

                // CodeView Column Header Setup
                string[] header = new string[] { "Resource ID", "Resource Description" };

                // CodeView Display Column Setup
                string[] display = new string[] { "RES_ID", "RES_DESC" };

                // Show
                cdvSlotResId.Text = cdvSlotResId.Show(cdvSlotResId, "Resource", "RAS", "Ras_View_Resource_List_By_Line", in_node, "RES_LIST", display, header, "RES_ID");
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Slot TextBox Enter Key
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSlotSlot_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (MPCF.Trim(txtSlotSlot.Text) != "")
                {
                    if (ViewInvLotDataBySlot() == false)
                    {
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// Slot Inv Lot New ID Enter Key
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSlotInvLotNew_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (MPCF.Trim(txtSlotInvLotNew.Text) != "")
                {
                    if (AlterInvLot() == false)
                    {
                        return;
                    }
                }
            }
        }

        #endregion

        #region Function

        /// <summary>
        /// View Inv Lot Data
        /// </summary>
        /// <param name="sLotId"></param>
        /// <returns></returns>
        private bool ViewInvLotData()
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_INV_LOT_DATA_IN");
                TRSNode out_node = new TRSNode("VIEW_INV_LOT_DATA_OUT");

                // Call Service
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '2';
                in_node.AddString("LINE_ID", cdvLine.Text);
                in_node.AddString("INV_LOT_ID", txtInvLotOld.Text);

                if (MPCF.CallService("SMT", "SMT_View_Slot_Info", in_node, ref out_node) == false)
                {
                    return false;
                }

                // Field Clear
                MPCF.FieldClear(grbInvLotInfo);

                txtInvLotResId.Text = out_node.GetString("RES_ID");
                txtInvLotSlot.Text = out_node.GetString("SLOT");
                txtInvLotFeeder.Text = out_node.GetString("IN_FEEDER_ID");
                txtInvLotInvMat.Text = out_node.GetString("PART_NAME");
                txtInvLotQty.Text = out_node.GetDouble("QTY").ToString("#,###,##0.###");

                MPCF.SetFocus(txtInvLotNew);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }

            return true;
        }

        /// <summary>
        /// View Inv Lot Data By Slot
        /// </summary>
        /// <param name="sLotId"></param>
        /// <returns></returns>
        private bool ViewInvLotDataBySlot()
        {
            try
            {
                // Check Value
                if (MPCF.CheckValue(cdvSlotResId, false) == false)
                {
                    return false;
                }

                TRSNode in_node = new TRSNode("VIEW_INV_LOT_DATA_IN");
                TRSNode out_node = new TRSNode("VIEW_INV_LOT_DATA_OUT");

                // Call Service
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("RES_ID", cdvSlotResId.Text);
                in_node.AddString("SLOT", txtSlotSlot.Text);

                if (MPCF.CallService("SMT", "SMT_View_Slot_Info", in_node, ref out_node) == false)
                {
                    return false;
                }

                // Field Clear
                MPCF.FieldClear(grbSlotInvLotInfo);

                txtSlotResId.Text = out_node.GetString("RES_ID");
                txtSlotFeederId.Text = out_node.GetString("IN_FEEDER_ID");
                txtSlotInvLotOld.Text = out_node.GetString("INV_LOT_ID");
                txtSlotInvMatId.Text = out_node.GetString("PART_NAME");
                txtSlotQty.Text = out_node.GetDouble("QTY").ToString("#,###,##0.###");

                MPCF.SetFocus(txtSlotInvLotNew);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Alter Inv Lot
        /// </summary>
        /// <param name="sLotId"></param>
        /// <returns></returns>
        private bool AlterInvLot()
        {
            try
            {
                // CheckValue
                if (MPCF.CheckValue(cdvLine, false) == false)
                {
                    return false;
                }

                // Inventory Lot
                if (tabAlter.SelectedTab.Index == 0)
                {
                    if (MPCF.CheckValue(txtInvLotOld, false) == false)
                    {
                        return false;
                    }

                    if (MPCF.CheckValue(txtInvLotNew, false) == false)
                    {
                        return false;
                    }
                }
                // Slot
                else
                {
                    if (MPCF.CheckValue(cdvSlotResId, false) == false)
                    {
                        return false;
                    }

                    if (MPCF.CheckValue(txtSlotSlot, false) == false)
                    {
                        return false;
                    }

                    if (MPCF.CheckValue(txtSlotInvLotNew, false) == false)
                    {
                        return false;
                    }
                }

                TRSNode in_node = new TRSNode("VIEW_ALTER_INV_LOT_IN");
                TRSNode out_node = new TRSNode("VIEW_ALTER_INV_LOT_OUT");

                // Call Service
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LINE_ID", cdvLine.Text);
                in_node.AddString("STORE_ID", "LSTO");

                // Inventory Lot
                if (tabAlter.SelectedTab.Index == 0)
                {
                    in_node.AddString("FEEDER_ID", txtInvLotFeeder.Text);
                    in_node.AddString("ALTER_INV_LOT", txtInvLotNew.Text);
                    in_node.AddString("OLD_INV_LOT", txtInvLotOld.Text);
                }
                // Slot
                else
                {
                    in_node.AddString("FEEDER_ID", txtSlotFeederId.Text);
                    in_node.AddString("ALTER_INV_LOT", txtSlotInvLotNew.Text);
                    in_node.AddString("OLD_INV_LOT", txtSlotInvLotOld.Text);
                }

                if (MPCF.CallService("SMT", "SMT_Alter_Change_Inv_Lot", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCF.ShowSuccessMessage(out_node, false);

                // Inventory Lot
                if (tabAlter.SelectedTab.Index == 0)
                {
                    txtInvLotNew.Text = string.Empty;
                    MPCF.SetFocus(txtInvLotNew);
                }
                // Slot
                else
                {
                    txtSlotInvLotNew.Text = string.Empty;
                    MPCF.SetFocus(txtSlotInvLotNew);
                }                
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }

            return true;
        }

        #endregion
    }
}
