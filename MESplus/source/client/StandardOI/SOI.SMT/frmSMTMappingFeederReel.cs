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
    // SOIBaseForm04 Common Role    
    // - Convert Theme 
    // - Register Favorite 
    // - Default Bottom Button : Process, Cancel, Print Option
    // - Default CMF Tab Control
    // - (option) Help Information Button
    // - (option for SE) Standard Operation Button
    public partial class frmSMTMappingFeederReel : SOIBaseForm02
    {
        #region Property

        // (Required)
        private bool bIsShown = false;

        #endregion

        #region Constructor

        public frmSMTMappingFeederReel()
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
            // Grid Init
            gridBind.InitDataSource();
            gridUnbind.InitDataSource();

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
                // Field Clear
                MPCF.FieldClear(this);
                FieldClearInForm();

                // In Node Setup
                TRSNode in_node = new TRSNode("VIEW_GCM_TABLE_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", "SUB_AREA");
                in_node.AddString("DATA_2", "SMT");

                // CodeView Column Header Setup
                string[] header = new string[] { "Line ID", "Line Description", "Lane Type" };

                // CodeView Display Column Setup
                string[] display = new string[] { "KEY_1", "DATA_1", "DATA_4" };

                // Show
                cdvLine.Text = cdvLine.Show(cdvLine, "Work Line", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "KEY_1");
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
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
                // Check Value
                if (MPCF.CheckValue(cdvLine, false) == false)
                {
                    return;
                }

                // In Node Setup
                TRSNode in_node = new TRSNode("VIEW_WORK_ORDER_LIST_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LINE_ID", cdvLine.Text);

                // CodeView Column Header Setup
                string[] header = new string[] { "Order ID", "Description", "Order Type"};

                // CodeView Display Column Setup
                string[] display = new string[] { "ORDER_ID", "ORDER_DESC", "ORDER_TYPE" };

                // Show
                cdvOrderID.Text = cdvOrderID.Show(cdvOrderID, "Order ID", "SMT", "SMT_View_Work_Order_List", in_node, "ORDER_LIST", display, header, "ORDER_ID");

                // Field Clear
                MPCF.FieldClear(this, cdvLine, cdvOrderID, null, null, null, true);

                if (string.IsNullOrEmpty(cdvOrderID.Text) == false)
                {
                    if (ViewWorkOrder(cdvOrderID.Text) == false)
                    {
                        return;
                    }

                    MPCF.SetFocus(txtFeederId);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Feeder ID Enter Key
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtFeederId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (MPCF.Trim(txtFeederId.Text) != "")
                {
                    // View Int Lost
                    if (CheckFeederInvLot() == false)
                    {
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// Inventory Lot ID Enter Key
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtInvLotId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (MPCF.Trim(txtInvLotId.Text) != "")
                {
                    // Check Int Lot
                    if (CheckInvLot() == false)
                    {
                        return;
                    }

                    // Bind
                    if (BindFeeder() == false)
                    {
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// Mapping Feeder and Reel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProcess_Click(object sender, EventArgs e)
        {
            // Bind
            if (tabMapping.SelectedTab.Index == 0)
            {
                if (BindFeeder() == false)
                {
                    return;
                }
            }
            // Unbind
            else
            {
                if (UnBindFeeder() == false)
                {
                    return;
                }
            }
        }

        /// <summary>
        /// Unbind Feeder ID Enter Key
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUnbindFeederID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (MPCF.Trim(txtUnbindFeederID.Text) != "")
                {
                    // View Int Lost
                    if (ViewFeederInfo() == false)
                    {
                        return;
                    }
                }
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
                
                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage("View Work Order() : " + ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        /// <summary>
        /// View Feeder Info
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        private bool ViewFeederInfo()
        {
            try
            {
                // Clear Field
                MPCF.FieldClear(tlpUnbind, txtUnbindFeederID);
                
                TRSNode in_node = new TRSNode("VIEW_FEEDER_INFO_IN");
                TRSNode out_node = new TRSNode("VIEW_FEEDER_INFO_OUT");

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("FEEDER_ID", txtUnbindFeederID.Text);

                if (MPCF.CallService("SMT", "Smt_View_Feeder", in_node, ref out_node) == false)
                {
                    return false;
                }

                txtUnbindFeederType.Text = out_node.GetString("FEEDER_TYPE");

                DataTable dt = gridUnbind.GetDataSource();
                DataRow dr;
                foreach (TRSNode data in out_node.GetList("INV_LOT_LIST"))
                {
                    dr = dt.NewRow();

                    dr[0] = data.GetString("INV_LOT_ID");
                    dr[1] = MPCF.MakeDateFormat(data.GetString("BIND_TIME"));
                    
                    dt.Rows.Add(dr);
                }
                gridUnbind.DataBind();

                if (gridUnbind.Rows.Count > 0)
                {
                    gridUnbind.Rows[0].Selected = true;
                }

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage("ViewFeederInfo() : " + ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        /// <summary>
        /// Check Feeder
        /// </summary>
        /// <returns></returns>
        private bool CheckFeederInvLot()
        {
            try
            {
                // CheckValue
                TRSNode in_node = new TRSNode("VIEW_CHECK_FEEDER_IN");
                TRSNode out_node = new TRSNode("VIEW_CHECK_FEEDER_OUT");

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("FEEDER_ID", txtFeederId.Text);

                if (MPCF.CallService("SMT", "SMT_Check_Feeder_Inv_Lot", in_node, ref out_node) == false)
                {
                    return false;
                }

                txtInvLotId.Text = string.Empty;
                MPCF.SetFocus(txtInvLotId);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage("View Work Order() : " + ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        /// <summary>
        /// Check Inv Lot
        /// </summary>
        /// <returns></returns>
        private bool CheckInvLot()
        {
            try
            {
                // CheckValue
                if (MPCF.CheckValue(txtFeederId, false) == false)
                {
                    return false;
                }

                TRSNode in_node = new TRSNode("VIEW_CHECK_INV_LOT_IN");
                TRSNode out_node = new TRSNode("VIEW_CHECK_INV_LOT_OUT");

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '2';
                in_node.AddString("FEEDER_ID", txtFeederId.Text);
                in_node.AddString("INV_LOT_ID", txtInvLotId.Text);

                if (MPCF.CallService("SMT", "SMT_Check_Feeder_Inv_Lot", in_node, ref out_node) == false)
                {
                    return false;
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
        /// Unbind Feeder
        /// </summary>
        /// <returns></returns>
        private bool UnBindFeeder()
        {
            try
            {
                //Check Value
                if (MPCF.CheckValue(txtUnbindFeederID, false) == false)
                {
                    return false;
                }

                TRSNode in_node = new TRSNode("MAPPING_FEEDER_AND_REEL_IN");
                TRSNode out_node = new TRSNode("MAPPING_FEEDER_AND_REEL_OUT");

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("FEEDER_ID", txtUnbindFeederID.Text);
                in_node.AddString("STORE_ID", "LSTO");
                if (gridUnbind.Selected.Rows.Count > 0)
                {
                    in_node.AddString("INV_LOT_ID", gridUnbind.Selected.Rows[0].Cells[0].Value);
                }

                if (MPCF.CallService("SMT", "SMT_Unbind_Feeder_Inv_Lot", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCF.ShowSuccessMessage(out_node, false);

                MPCF.FieldClear(tlpUnbind);
                MPCF.SetFocus(txtUnbindFeederID);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage("UnBindFeeder() : " + ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        /// <summary>
        /// Bind Feeder
        /// </summary>
        /// <returns></returns>
        private bool BindFeeder()
        {
            try
            {
                // CheckValue
                if (MPCF.CheckValue(cdvLine, false) == false)
                {
                    return false;
                }
                if (MPCF.CheckValue(cdvOrderID, false) == false)
                {
                    return false;
                }
                if (MPCF.CheckValue(txtFeederId, false) == false)
                {
                    return false;
                }
                if (MPCF.CheckValue(txtInvLotId, false) == false)
                {
                    return false;
                }

                TRSNode in_node = new TRSNode("MAPPING_FEEDER_AND_REEL_IN");
                TRSNode out_node = new TRSNode("MAPPING_FEEDER_AND_REEL_OUT");

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("STORE_ID", "LSTO");
                in_node.AddString("FEEDER_ID", txtFeederId.Text);
                in_node.AddString("INV_LOT_ID", txtInvLotId.Text);
                in_node.AddString("LINE_ID", cdvLine.Text);
                in_node.AddString("ORDER_ID", cdvOrderID.Text);

                if (MPCF.CallService("SMT", "SMT_Bind_Feeder_Inv_Lot", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCF.ShowSuccessMessage(out_node, false);

                // List Clear
                MPCF.FieldClear(pnlPCBList);

                DataTable dt = gridBind.GetDataSource();
                DataRow dr = dt.NewRow();
                dr["RES_ID"] = out_node.GetString("RES_ID");
                dr["SLOT_NO"] = out_node.GetString("SLOT_NO");
                dr["INV_LOT_ID"] = out_node.GetString("INV_LOT_ID");
                dr["FEEDER_ID"] = out_node.GetString("FEEDER_ID");
                dt.Rows.Add(dr);
                gridBind.DataBind();

                txtFeederId.Text = string.Empty;
                txtInvLotId.Text = string.Empty;

                MPCF.SetFocus(txtFeederId);
                                
                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage("BindFeeder() : " + ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        #endregion
    }
}
