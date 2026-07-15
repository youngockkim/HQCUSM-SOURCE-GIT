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
    public partial class frmATPInventoryReturn : SOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;

        private enum COL_SCAN_LIST
        {
            INV_LOT_ID = 1,
            INV_MAT_ID,
            QTY
        }

        private enum COL_SUM_LIST
        {
            INV_MAT_ID = 0,
            INV_MAT_DESC,
            QTY
        }

        #endregion

        #region Constructor

        public frmATPInventoryReturn()
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
                // MPCF.SetFocus(control);                

                // (Required) 
                bIsShown = true;
            }
        }

        /// <summary>
        /// Out Store CodeView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cdvOutStore_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                // Pre-Search 
                TRSNode in_node = new TRSNode("VIEW_OUT_STORE_IN");
                TRSNode out_node = new TRSNode("VIEW_OUT_STORE_OUT");

                // In Node Setup                
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddChar("OPER_STORE_FLAG", 'Y');

                // CodeView Column Header Setup
                string[] header = new string[] { "Store ID", "Store Description" };

                // CodeView Display Column Setup
                string[] display = new string[] { "STORE_ID", "STORE_DESC" };

                // Show
                cdvOutStore.Text = cdvOutStore.Show(cdvOutStore, "Out Store", "INV", "INV_View_Store_List", in_node, "STORE_LIST", display, header, "STORE_ID");
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// In Store CodeView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cdvInStore_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                // Pre-Search 
                TRSNode in_node = new TRSNode("VIEW_IN_STORE_IN");
                TRSNode out_node = new TRSNode("VIEW_IN_STORE_OUT");

                // In Node Setup                
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddChar("OPER_STORE_FLAG", 'N');
                in_node.AddChar("NG_STORE_FLAG", 'N');
                in_node.AddChar("IQC_STORE_FLAG", 'N');

                // CodeView Column Header Setup
                string[] header = new string[] { "Store ID", "Store Description" };

                // CodeView Display Column Setup
                string[] display = new string[] { "STORE_ID", "STORE_DESC" };

                // Show
                cdvInStore.Text = cdvInStore.Show(cdvInStore, "In Store", "INV", "INV_View_Store_List", in_node, "STORE_LIST", display, header, "STORE_ID");
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
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

                    if (AddToScanList(txtInvLotID.Text) == false)
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
        /// CheckBox Select All / Release All
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
        /// Delete Scan
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteScan_Click(object sender, EventArgs e)
        {
            try
            {
                // CheckBox Check -> Delete from Summary -> Delete from scanList
                for (int i = spdScanList.Sheets[0].Rows.Count - 1; i >= 0; i--)
                {
                    if ((bool)spdScanList.Sheets[0].Cells[i, 0].Value == true)
                    {
                        if (DelScanQty(MPCF.Trim(spdScanList.Sheets[0].Cells[i, (int)COL_SCAN_LIST.INV_MAT_ID].Value),
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
        /// Refrech 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                // Field Clear
                MPCF.FieldClear(this);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Process
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
                if (InventoryReturn() == false)
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
                for (int i = 0; i < spdScanList.Sheets[0].Rows.Count; i++)
                {
                    if (spdScanList.Sheets[0].Cells[i, (int)COL_SCAN_LIST.INV_LOT_ID].Value != null
                        && spdScanList.Sheets[0].Cells[i, (int)COL_SCAN_LIST.INV_LOT_ID].Value.ToString() == invLotID)
                    {
                        return true;
                    }
                }

                TRSNode in_node = new TRSNode("VIEW_INV_LOT_IN");
                TRSNode out_node = new TRSNode("VIEW_INV_LOT_OUT");

                // Call Service
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LABEL_ID", MPCF.Trim(invLotID));

                if (MPCF.CallService("ATP", "ATP_VIEW_LABEL", in_node, ref out_node) == false)
                {
                    return false;
                }

                // Bind
                int iRow = spdScanList.Sheets[0].Rows.Count;
                spdScanList.Sheets[0].RowCount++;
                spdScanList.Sheets[0].Cells[iRow, 0].Value = true;
                spdScanList.Sheets[0].Cells[iRow, (int)COL_SCAN_LIST.INV_LOT_ID].Value = out_node.GetString("LABEL_ID");
                spdScanList.Sheets[0].Cells[iRow, (int)COL_SCAN_LIST.INV_MAT_ID].Value = out_node.GetString("MAT_ID");
                spdScanList.Sheets[0].Cells[iRow, (int)COL_SCAN_LIST.QTY].Value = MPCF.MakeNumberFormat(out_node.GetDouble("QTY_1"));

                if (ChangeSummaryInfo(out_node.GetString("MAT_ID"), out_node.GetString("MAT_DESC"), out_node.GetDouble("QTY_1")) == false)
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
        private bool ChangeSummaryInfo(string invMatID, string invMatDesc, double scanQty)
        {
            try
            {
                // Validation
                if (CheckInvMatIDInSumInfo(invMatID) == false)
                {
                    // Bind                    
                    int iRow = spdSumInfo.Sheets[0].Rows.Count;
                    spdSumInfo.Sheets[0].RowCount++;

                    spdSumInfo.Sheets[0].Cells[iRow, (int)COL_SUM_LIST.INV_MAT_ID].Value = invMatID;
                    spdSumInfo.Sheets[0].Cells[iRow, (int)COL_SUM_LIST.INV_MAT_DESC].Value = invMatDesc;
                    spdSumInfo.Sheets[0].Cells[iRow, (int)COL_SUM_LIST.QTY].Value = MPCF.MakeNumberFormat(scanQty);
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
                        // Pre-Scan Qty + Scan Qty
                        spdSumInfo.Sheets[0].Cells[i, (int)COL_SUM_LIST.QTY].Value =
                            MPCF.MakeNumberFormat((MPCF.ToDbl(spdSumInfo.Sheets[0].Cells[i, (int)COL_SUM_LIST.QTY].Value) + scanQty));

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
                        // Pre-Scan Qty + Scan Qty
                        spdSumInfo.Sheets[0].Cells[i, (int)COL_SUM_LIST.QTY].Value =
                            MPCF.MakeNumberFormat((MPCF.ToDbl(spdSumInfo.Sheets[0].Cells[i, (int)COL_SUM_LIST.QTY].Value) - scanQty));

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

        /// <summary>
        /// Process Inventory Return
        /// </summary>
        /// <returns></returns>
        private bool InventoryReturn()
        {
            try
            {
                TRSNode in_node = new TRSNode("INV_RETURN_IN");
                TRSNode out_node = new TRSNode("INV_RETURN_OUT");
                TRSNode scanList;

                // Call Service
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("STORE_ID", cdvOutStore.Text);
                in_node.AddString("TO_STORE_ID", cdvInStore.Text);
                in_node.AddString("ACCT_TYPE", "MOVE");
                in_node.AddString("ACCT_GRP", "MG1");
                in_node.AddString("ACCT_CODE", "M02");

                for (int i = 0; i < spdScanList.Sheets[0].Rows.Count; i++)
                {
                    scanList = in_node.AddNode("LABEL_LIST");

                    scanList.AddString("LABEL_ID", spdScanList.Sheets[0].Cells[i, (int)COL_SCAN_LIST.INV_LOT_ID].Value.ToString());
                    //scanList.AddString("INV_MAT_ID", spdScanList.Sheets[0].Cells[i, (int)COL_SCAN_LIST.INV_MAT_ID].Value.ToString());
                    //scanList.AddString("QTY", spdScanList.Sheets[0].Cells[i, (int)COL_SCAN_LIST.QTY].Value);
                }

                if (MPCF.CallService("ATP", "ATP_Transfer_Inv_Lot", in_node, ref out_node) == false)
                {
                    return false;
                }

                // Show Success Message
                MPCF.ShowSuccessMessage(out_node, false);

                // Field Clear
                MPCF.FieldClear(txtInvLotID);
                spdSumInfo.Sheets[0].Rows.Clear();
                spdScanList.Sheets[0].Rows.Clear();

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
}
