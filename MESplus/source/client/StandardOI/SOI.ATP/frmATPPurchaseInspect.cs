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

namespace SOI.ATP
{
    // (Required) Inherit Base Form
    // SOIBaseForm02 Common Role    
    // - Convert Theme 
    // - Register Favorite 
    // - Default Bottom Button : Process, Cancel 
    // - (option) Help Information Button
    // - (option for SE) Standard Operation Button
    public partial class frmATPPurchaseInspect : SOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;

        public ATPPurchaseInspectModel model = new ATPPurchaseInspectModel();

        private enum COL_SUM_LIST
        {
            SEQ = 0,
            INV_MAT_ID,
            INV_MAT_DESC,
            REQ_QTY,
            REMAIN_QTY,
            SCAN_QTY
        }

        private enum COL_SCAN_LIST
        {
            INVENTORY_LOT_ID = 1,
            INVENTORY_MAT_ID,
            QTY
        }

        #endregion

        #region Constructor

        public frmATPPurchaseInspect()
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
            // TEST DATA
            txtDeliveryNote.Text = model.DeliveryNote;
            txtDeliveryDate.Text = model.DeliveryDate;
            txtVendor.Text = model.Vendor;
            txtDeliveryStatus.Text = model.DeliveryStatusDesc;
            txtReqQty.Text = model.ReqQty;

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
                 MPCF.SetFocus(txtInvLotID);

                // (Required) 
                bIsShown = true;
            }
        }

        /// <summary>
        /// Inventory Lot ID Enter Key
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtInvLotID_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    // Check Value
                    if (MPCF.CheckValue(txtInvLotID, false) == false)
                    {
                        return;
                    }

                    // Add To List
                    if (AddToScanList(txtInvLotID.Text) == false)
                    {
                        return;
                    }

                    // Focus
                    MPCF.SetFocus(txtInvLotID);
                    txtInvLotID.SelectAll();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Select/Release All CheckBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void spdScanList_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            try
            {
                // First Column Header Cell
                if (e.Row == 0 && e.Column == 0 && e.ColumnHeader == true)
                {
                    // Select All
                    if (spdScanList.Sheets[0].ColumnHeader.Cells[0, 0].Value == null 
                        || ((bool)spdScanList.Sheets[0].ColumnHeader.Cells[0, 0].Value) == false)
                    {
                        spdScanList.Sheets[0].ColumnHeader.Cells[0, 0].Value = true;

                        for (int i = 0; i < spdScanList.Sheets[0].Rows.Count; i++)
                        {
                            spdScanList.Sheets[0].Cells[i, 0].Value = true;
                        }
                    }
                    // Release All
                    else
                    {
                        spdScanList.Sheets[0].ColumnHeader.Cells[0, 0].Value = false;

                        for (int i = 0; i < spdScanList.Sheets[0].Rows.Count; i++)
                        {
                            spdScanList.Sheets[0].Cells[i, 0].Value = false;
                        }
                    }
                }                
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Delete Inventory Lot in Scan List
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteScanInvLot_Click(object sender, EventArgs e)
        {
            try
            {
                // CheckBox Check -> Delete from Summary -> Delete from scanList
                for (int i = spdScanList.Sheets[0].Rows.Count - 1; i >= 0; i--)
                {
                    if ((bool)spdScanList.Sheets[0].Cells[i, 0].Value == true)
                    {
                        if (DelScanQty(MPCF.Trim(spdScanList.Sheets[0].Cells[i, (int)COL_SCAN_LIST.INVENTORY_MAT_ID].Value),
                            MPCF.ToDbl(spdScanList.Sheets[0].Cells[i, (int)COL_SCAN_LIST.QTY].Value)) == false)
                        {
                            return;
                        }

                        spdScanList.Sheets[0].Rows.Remove(i, 1);
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Refresh Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                if (PurchaseInspectRefresh() == false)
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
        /// Purchase Inspect
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                // Validation
                // No Scanned Data
                if (spdScanList.Sheets[0].Rows.Count < 1)
                {
                    MPCF.SetFocus(txtInvLotID);
                    return;
                }
                // No Checked Data
                bool bFound = false;
                for (int i = 0; i < spdScanList.Sheets[0].Rows.Count; i++)
                {
                    if ((bool)spdScanList.Sheets[0].Cells[i, 0].Value == true)
                    {
                        bFound = true;
                        break;
                    }
                }
                if (bFound == false)
                {
                    spdScanList.Sheets[0].ActiveRowIndex = 0;
                    spdScanList.Sheets[0].ActiveColumnIndex = 0;
                    return;
                }
                
                // Process
                if (PurchaseInspect() == false)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        #endregion

        #region Function

        /// <summary>
        /// Add To Scan List
        /// </summary>
        /// <param name="invLotID"></param>
        /// <returns></returns>
        private bool AddToScanList(string invLotID)
        {
            try
            {
                // Validation
                for (int i = 0; i < spdScanList.Sheets[0].Rows.Count; i++)
                {
                    // Same Inventory Lot ID Check
                    if (spdScanList.Sheets[0].Cells[i, (int)COL_SCAN_LIST.INVENTORY_LOT_ID].Value != null
                        && spdScanList.Sheets[0].Cells[i, (int)COL_SCAN_LIST.INVENTORY_LOT_ID].Value.ToString() == invLotID)
                    {
                        return true;
                    }
                }

                TRSNode in_node = new TRSNode("VIEW_INV_LOT_IN");
                TRSNode out_node = new TRSNode("VIEW_INV_LOT_OUT");

                // Call Service
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LABEL_ID", invLotID);
                in_node.AddString("DLV_NO", model.DeliveryNote);

                if (MPCF.CallService("ATP", "ATP_VIEW_DELIVERY_LABEL_INFO", in_node, ref out_node) == false)
                {
                    return false;
                }

                // Bind
                int iRow = spdScanList.Sheets[0].Rows.Count;
                spdScanList.Sheets[0].RowCount++;

                spdScanList.Sheets[0].Cells[iRow, 0].Value = true;
                spdScanList.Sheets[0].Cells[iRow, (int)COL_SCAN_LIST.INVENTORY_LOT_ID].Value = out_node.GetString("LABEL_ID");
                spdScanList.Sheets[0].Cells[iRow, (int)COL_SCAN_LIST.INVENTORY_MAT_ID].Value = out_node.GetString("INV_MAT_ID");
                spdScanList.Sheets[0].Cells[iRow, (int)COL_SCAN_LIST.QTY].Value = MPCF.MakeNumberFormat(out_node.GetDouble("DLV_QTY"));

                if (ChangeSummaryInfo(out_node.GetString("INV_MAT_ID"), out_node.GetDouble("DLV_QTY"), out_node.GetString("INV_MAT_DESC"), out_node.GetDouble("REQ_QTY")) == false)
                {
                    return false;
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
        /// View Summary Information
        /// </summary>
        /// <returns></returns>
        private bool ChangeSummaryInfo(string invMatID, double scanQty, string invMatDesc, double reqQty)
        {
            try
            {
                // Validation
                if (CheckInvMatIDInSumInfo(invMatID) == false)
                {
                    int iRow = spdSumInfo.Sheets[0].Rows.Count;
                    spdSumInfo.Sheets[0].RowCount++;

                    spdSumInfo.Sheets[0].Cells[iRow, (int)COL_SUM_LIST.SEQ].Value = (iRow + 1).ToString();
                    spdSumInfo.Sheets[0].Cells[iRow, (int)COL_SUM_LIST.INV_MAT_ID].Value = invMatID;
                    spdSumInfo.Sheets[0].Cells[iRow, (int)COL_SUM_LIST.INV_MAT_DESC].Value = invMatDesc;
                    spdSumInfo.Sheets[0].Cells[iRow, (int)COL_SUM_LIST.REQ_QTY].Value = MPCF.MakeNumberFormat(reqQty);
                    spdSumInfo.Sheets[0].Cells[iRow, (int)COL_SUM_LIST.REMAIN_QTY].Value = MPCF.MakeNumberFormat(reqQty - scanQty);
                    spdSumInfo.Sheets[0].Cells[iRow, (int)COL_SUM_LIST.SCAN_QTY].Value = MPCF.MakeNumberFormat(scanQty);
                }
                else
                {
                    // Remain Qty Recalculation
                    if (AddScanQty(invMatID, scanQty) == false)
                    {
                        return false;
                    }
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
        /// Refresh
        /// </summary>
        /// <returns></returns>
        private bool PurchaseInspectRefresh()
        {
            try
            {
                // Clear
                spdScanList.Sheets[0].Rows.Clear();
                spdSumInfo.Sheets[0].Rows.Clear();                
                MPCF.FieldClear(txtInvLotID);

                // Set Focus
                MPCF.SetFocus(txtInvLotID);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        /// <summary>
        /// Process Purchase Inspect
        /// </summary>
        /// <returns></returns>
        private bool PurchaseInspect()
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_SUMMARY_IN");
                TRSNode out_node = new TRSNode("VIEW_SUMMARY_OUT");
                TRSNode scanList;

                // Call Service
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddChar("ALL_FLAG", 'N');
                in_node.AddString("DLV_NO", model.DeliveryNote);

                if (chkOutSelection.OnOffState == SOICheckBoxOnOffState.OffState)
                {
                    in_node.AddChar("CANCEL_RECEIPT_FLAG", 'Y');
                }

                for (int i = 0; i < spdScanList.Sheets[0].Rows.Count; i++)
                {
                    scanList = in_node.AddNode("LABEL");

                    scanList.AddString("LABEL_ID", spdScanList.Sheets[0].Cells[i, (int)COL_SCAN_LIST.INVENTORY_LOT_ID].Value.ToString());
                    //scanList.AddString("INV_MAT_ID", spdScanList.Sheets[0].Cells[i, (int)COL_SCAN_LIST.INVENTORY_MAT_ID].Value.ToString());
                    //scanList.AddString("QTY", spdScanList.Sheets[0].Cells[i, (int)COL_SCAN_LIST.QTY].Value);                    
                }        

                if (MPCF.CallService("ATP", "ATP_INSPECT_DELIVERY_LABEL", in_node, ref out_node) == false)
                {
                    return false;
                }

                // Show Success Message
                MPCF.ShowSuccessMessage(out_node, false);

                if (PurchaseInspectRefresh() == false)
                {
                    return false;
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
        /// Add Scan Qty To Summay Information
        /// </summary>
        /// <returns></returns>
        private bool AddScanQty(string invMatID, double scanQty)
        {
            try
            {
                // Find Cell
                for (int i = 0; i < spdSumInfo.Sheets[0].Rows.Count; i++)
                {
                    if (spdSumInfo.Sheets[0].Cells[i, (int)COL_SUM_LIST.INV_MAT_ID].Value.ToString() == invMatID)
                    {
                        // Remain Qty - Scan Qty
                        spdSumInfo.Sheets[0].Cells[i, (int)COL_SUM_LIST.REMAIN_QTY].Value =
                            MPCF.MakeNumberFormat((MPCF.ToDbl(spdSumInfo.Sheets[0].Cells[i, (int)COL_SUM_LIST.REMAIN_QTY].Value) - scanQty));

                        // Pre-Scan Qty + Scan Qty
                        spdSumInfo.Sheets[0].Cells[i, (int)COL_SUM_LIST.SCAN_QTY].Value =
                            MPCF.MakeNumberFormat((MPCF.ToDbl(spdSumInfo.Sheets[0].Cells[i, (int)COL_SUM_LIST.SCAN_QTY].Value) + scanQty));

                        break;
                    }
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
        /// Delete Scan Qty From Summay Information
        /// </summary>
        /// <returns></returns>
        private bool DelScanQty(string invMatID, double scanQty)
        {
            try
            {
                // Find Cell
                for (int i = 0; i < spdSumInfo.Sheets[0].Rows.Count; i++)
                {
                    if (spdSumInfo.Sheets[0].Cells[i, (int)COL_SUM_LIST.INV_MAT_ID].Value.ToString() == invMatID)
                    {
                        // Remain Qty - Scan Qty
                        spdSumInfo.Sheets[0].Cells[i, (int)COL_SUM_LIST.REMAIN_QTY].Value =
                            MPCF.MakeNumberFormat((MPCF.ToDbl(spdSumInfo.Sheets[0].Cells[i, (int)COL_SUM_LIST.REMAIN_QTY].Value) + scanQty));

                        // Pre-Scan Qty + Scan Qty
                        spdSumInfo.Sheets[0].Cells[i, (int)COL_SUM_LIST.SCAN_QTY].Value =
                            MPCF.MakeNumberFormat((MPCF.ToDbl(spdSumInfo.Sheets[0].Cells[i, (int)COL_SUM_LIST.SCAN_QTY].Value) - scanQty));

                        break;
                    }
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
        /// Check Inv Mat ID in Summary Spread
        /// </summary>
        /// <param name="invMatID"></param>
        /// <returns></returns>
        private bool CheckInvMatIDInSumInfo(string invMatID)
        {
            if (spdSumInfo.Sheets[0].Rows.Count < 1)
            {
                return false;
            }

            for (int i = 0; i < spdSumInfo.Sheets[0].Rows.Count; i++)
            {
                if (spdSumInfo.Sheets[0].Cells[i, (int)COL_SUM_LIST.INV_MAT_ID].Value.ToString() == invMatID)
                {
                    return true;
                }
            }

            return false;
        }

        #endregion
    }

    public class ATPPurchaseInspectModel
    {
        private string deliveryNote;
        public string DeliveryNote
        {
            get { return deliveryNote; }
            set { deliveryNote = value; }
        }

        private string deliveryDate;
        public string DeliveryDate
        {
            get { return deliveryDate; }
            set { deliveryDate = value; }
        }

        private string vendor;
        public string Vendor
        {
            get { return vendor; }
            set { vendor = value; }
        }

        //private string customer;
        //public string Customer
        //{
        //    get { return customer; }
        //    set { customer = value; }
        //}

        private string deliveryStatus;
        public string DeliveryStatus
        {
            get { return deliveryStatus; }
            set { deliveryStatus = value; }
        }

        private string deliveryStatusDesc;
        public string DeliveryStatusDesc
        {
            get { return deliveryStatusDesc; }
            set { deliveryStatusDesc = value; }
        }

        //private string matCode;
        //public string MatCode
        //{
        //    get { return matCode; }
        //    set { matCode = value; }
        //}

        //private string matDesc;
        //public string MatDesc
        //{
        //    get { return matDesc; }
        //    set { matDesc = value; }
        //}

        private string reqQty;
        public string ReqQty
        {
            get { return reqQty; }
            set { reqQty = value; }
        }
    }
}
