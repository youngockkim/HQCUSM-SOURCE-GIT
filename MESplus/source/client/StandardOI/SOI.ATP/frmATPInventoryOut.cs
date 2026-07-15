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
    public partial class frmATPInventoryOut : SOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;

        private enum COL_INV_MAT_LIST
        {
            INV_MAT_ID = 0,
            INV_MAT_DESC,
            PROD_REQ_QTY,
            SAFETY_QTY,
            INV_OUT_QTY,
            REQ_QTY,
            INV_QTY
        }

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
            REQ_QTY,
            REMAIN_QTY,
            QTY
        }

        #endregion

        #region Constructor

        public frmATPInventoryOut()
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
            //// View Request Inventory Material List 
            //ViewInvMatList();

#if DEBUG
            tlpTestDate.Visible = true;
            dtTestDate.SetValueAsDateTime(DateTime.Now);
#endif

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
                in_node.AddChar("IN_OUT_STORE_FLAG", 'O');
                in_node.AddChar("OPER_STORE_FLAG", 'N');

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
                in_node.AddChar("OPER_STORE_FLAG", 'Y');

                // CodeView Column Header Setup
                string[] header = new string[] { "Store ID", "Store Description" };

                // CodeView Display Column Setup
                string[] display = new string[] { "STORE_ID", "STORE_DESC" };

                // Show
                cdvTransitStore.Text = cdvTransitStore.Show(cdvTransitStore, "In Store", "INV", "INV_View_Store_List", in_node, "STORE_LIST", display, header, "STORE_ID");
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Material CodeView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cdvMatCode_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                // Pre-Search 
                TRSNode in_node = new TRSNode("VIEW_INV_MAT_IN");
                TRSNode out_node = new TRSNode("VIEW_INV_MAT_OUT");

                // In Node Setup                
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '2';
                //in_node.AddString("TABLE_NAME", MPCF.Trim(""));

                // CodeView Column Header Setup
                string[] header = new string[] { "Inventory Material ID", "Inventory Material Description" };

                // CodeView Display Column Setup
                string[] display = new string[] { "INV_MAT_ID", "INV_MAT_DESC" };

                // Show
                cdvInvMatID.Text = cdvInvMatID.Show(cdvInvMatID, "Inventory Material", "INV", "INV_View_Inv_Material_List", in_node, "INV_MATERIAL_LIST", display, header, "INV_MAT_ID");

                // Description
                if (cdvInvMatID.returnDatas != null
                    && cdvInvMatID.returnDatas.Count > 0)
                {
                    
                    txtInvMatDesc.Text = cdvInvMatID.returnDatas[1];
                }
                else
                {
                    txtInvMatDesc.Text = string.Empty;
                }

                // Init
                MPCF.FieldClear(txtInvLotID);
                spdScanList.Sheets[0].Rows.Clear();
                spdSumInfo.Sheets[0].Rows.Clear();
                MPCF.ShowMessageClear();

                if (MPCF.CheckValue(cdvTransitStore, false) == false)
                {
                    return;
                }

                // View
                if (ViewInvMatList() == false)
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
        /// Inventory Lot ID Enter
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
                    if (spdInvMatList.Sheets[0].Rows.Count < 1)
                    {
                        return;
                    }

                    if (AddToScanList(txtInvLotID.Text) == false)
                    {
                        return;
                    }

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
        /// View List
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                // Check Value
                //if (MPCF.CheckValue(cdvOutStore, false) == false)
                //{
                //    return;
                //}
                if (MPCF.CheckValue(cdvTransitStore, false) == false)
                {
                    return;
                }
                //if (MPCF.CheckValue(cdvInvMatID, false) == false)
                //{
                //    return;
                //}

                // View
                if (ViewInvMatList() == false)
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
                if (InventoryOut() == false)
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
        /// View Inventory Material List
        /// </summary>
        /// <returns></returns>
        private bool ViewInvMatList()
        {
            try
            {
                // Clear
                MPCF.FieldClear(txtInvLotID);
                spdScanList.Sheets[0].Rows.Clear();
                spdSumInfo.Sheets[0].Rows.Clear();
                MPCF.ShowMessageClear();

                TRSNode in_node = new TRSNode("VIEW_REQ_INV_OUT_IN");
                TRSNode out_node = new TRSNode("VIEW_REQ_INV_OUT_OUT");

                DateTime dtNow = DateTime.Now;

#if DEBUG
                dtNow = dtTestDate.GetValueAsDateTime();
#endif
                // Call Service
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("WORK_DATE", MPCF.DestroyDateFormat(dtNow.ToString(), DATE_TIME_FORMAT.DATE));
                in_node.AddString("TO_STORE_ID", cdvTransitStore.Text);
                in_node.AddString("MAT_ID", cdvInvMatID.Text);

                if (MPCF.CallService("ATP", "ATP_View_Out_Request", in_node, ref out_node) == false)
                {
                    return false;
                }

                // Spread Clear
                spdInvMatList.Sheets[0].Rows.Clear();

                // Bind
                if (out_node.GetList(0) != null)
                {
                    int iRow = 0;

                    for (int i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        iRow = spdInvMatList.Sheets[0].Rows.Count;
                        spdInvMatList.Sheets[0].RowCount++;

                        spdInvMatList.Sheets[0].Cells[iRow, (int)COL_INV_MAT_LIST.INV_MAT_ID].Value = out_node.GetList(0)[i].GetString("MAT_ID");
                        spdInvMatList.Sheets[0].Cells[iRow, (int)COL_INV_MAT_LIST.INV_MAT_DESC].Value = out_node.GetList(0)[i].GetString("MAT_DESC");
                        spdInvMatList.Sheets[0].Cells[iRow, (int)COL_INV_MAT_LIST.PROD_REQ_QTY].Value = MPCF.MakeNumberFormat(out_node.GetList(0)[i].GetDouble("REQUIRE_QTY"));
                        spdInvMatList.Sheets[0].Cells[iRow, (int)COL_INV_MAT_LIST.SAFETY_QTY].Value = MPCF.MakeNumberFormat(out_node.GetList(0)[i].GetDouble("SAFETY_QTY"));
                        spdInvMatList.Sheets[0].Cells[iRow, (int)COL_INV_MAT_LIST.INV_OUT_QTY].Value = MPCF.MakeNumberFormat(out_node.GetList(0)[i].GetDouble("OUT_QTY"));
                        spdInvMatList.Sheets[0].Cells[iRow, (int)COL_INV_MAT_LIST.REQ_QTY].Value = MPCF.MakeNumberFormat(out_node.GetList(0)[i].GetDouble("REQUEST_QTY"));
                        spdInvMatList.Sheets[0].Cells[iRow, (int)COL_INV_MAT_LIST.INV_QTY].Value = MPCF.MakeNumberFormat(out_node.GetList(0)[i].GetDouble("INV_QTY"));
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
        /// Add To Scan List
        /// </summary>
        /// <param name="invLotID"></param>
        /// <returns></returns>
        private bool AddToScanList(string invLotID)
        {
            try
            {
                MPCF.ShowMessageClear();

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

                // Validation
                int iFoundRow = -1;
                for (int i = 0; i < spdInvMatList.Sheets[0].Rows.Count; i++)
                {
                    if (spdInvMatList.Sheets[0].Cells[i, (int)COL_INV_MAT_LIST.INV_MAT_ID].Value != null
                        && spdInvMatList.Sheets[0].Cells[i, (int)COL_INV_MAT_LIST.INV_MAT_ID].Value.ToString() == out_node.GetString("MAT_ID"))
                    {
                        iFoundRow = i;
                        break;
                    }
                }
                if (iFoundRow < 0)
                {
                    // Can not find inventory out material.
                    MPCF.ShowMessage(MPCF.GetMessage(78), MSG_LEVEL.ERROR, false);
                    return false;
                }              

                // Bind
                int iRow = spdScanList.Sheets[0].Rows.Count;
                spdScanList.Sheets[0].RowCount++;
                spdScanList.Sheets[0].Cells[iRow, 0].Value = true;
                spdScanList.Sheets[0].Cells[iRow, (int)COL_SCAN_LIST.INV_LOT_ID].Value = out_node.GetString("LABEL_ID");
                spdScanList.Sheets[0].Cells[iRow, (int)COL_SCAN_LIST.INV_MAT_ID].Value = out_node.GetString("MAT_ID");
                spdScanList.Sheets[0].Cells[iRow, (int)COL_SCAN_LIST.QTY].Value = MPCF.MakeNumberFormat(out_node.GetDouble("QTY_1"));

                if (ChangeSummaryInfo(iFoundRow, out_node.GetString("MAT_ID"), out_node.GetString("MAT_DESC"), out_node.GetDouble("QTY_1")) == false)
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
        private bool ChangeSummaryInfo(int iFoundRow, string invMatID, string invMatDesc, double scanQty)
        {
            try
            {
                // Validation
                if (CheckInvMatIDInSumInfo(invMatID) == false)
                {
                    int iRow = 0;
                    iRow = spdSumInfo.Sheets[0].Rows.Count;
                    spdSumInfo.Sheets[0].RowCount++;
                    spdSumInfo.Sheets[0].Cells[iRow, (int)COL_SUM_LIST.INV_MAT_ID].Value = invMatID;
                    spdSumInfo.Sheets[0].Cells[iRow, (int)COL_SUM_LIST.INV_MAT_DESC].Value = invMatDesc;
                    spdSumInfo.Sheets[0].Cells[iRow, (int)COL_SUM_LIST.REQ_QTY].Value = Convert.ToString(spdInvMatList.Sheets[0].Cells[iFoundRow, (int)COL_INV_MAT_LIST.REQ_QTY].Value);
                    spdSumInfo.Sheets[0].Cells[iRow, (int)COL_SUM_LIST.REMAIN_QTY].Value = MPCF.MakeNumberFormat(MPCF.ToDbl(MPCF.DestroyNumberFormat(Convert.ToString(spdInvMatList.Sheets[0].Cells[iFoundRow, (int)COL_INV_MAT_LIST.REQ_QTY].Value))) - scanQty);
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
                        // Remain Qty - Scan Qty
                        spdSumInfo.Sheets[0].Cells[i, (int)COL_SUM_LIST.REMAIN_QTY].Value =
                            MPCF.MakeNumberFormat((MPCF.ToDbl(spdSumInfo.Sheets[0].Cells[i, (int)COL_SUM_LIST.REMAIN_QTY].Value) - scanQty));

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
                        // Remain Qty - Scan Qty
                        spdSumInfo.Sheets[0].Cells[i, (int)COL_SUM_LIST.REMAIN_QTY].Value =
                            MPCF.MakeNumberFormat((MPCF.ToDbl(spdSumInfo.Sheets[0].Cells[i, (int)COL_SUM_LIST.REMAIN_QTY].Value) + scanQty));

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
        /// View Summary Information
        /// </summary>
        /// <returns></returns>
        private bool ViewSummaryInfo()
        {
            try
            {
                int iRow;

                for (int i = 0; i < 1; i++)
                {
                    iRow = spdSumInfo.Sheets[0].Rows.Count;
                    spdSumInfo.Sheets[0].RowCount++;

                    spdSumInfo.Sheets[0].Cells[iRow, (int)COL_SUM_LIST.INV_MAT_ID].Value = "18110-RM4A0";
                    spdSumInfo.Sheets[0].Cells[iRow, (int)COL_SUM_LIST.INV_MAT_DESC].Value = "18110-RM4A0";
                    spdSumInfo.Sheets[0].Cells[iRow, (int)COL_SUM_LIST.QTY].Value = "300";
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
        /// Inventory Out
        /// </summary>
        /// <returns></returns>
        private bool InventoryOut()
        {
            try
            {
                TRSNode in_node = new TRSNode("INV_OUT_IN");
                TRSNode out_node = new TRSNode("INV_OUT_OUT");
                TRSNode scanList;

                // Call Service
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("STORE_ID", cdvOutStore.Text);
                in_node.AddString("TO_STORE_ID", cdvTransitStore.Text);
                in_node.AddString("ACCT_TYPE", "MOVE");
                in_node.AddString("ACCT_GRP", "MG1");
                in_node.AddString("ACCT_CODE", "M01");

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

                if (MPCF.CheckValue(cdvTransitStore, false) == false)
                {
                    return false;
                }

                if (ViewInvMatList() == false)
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

        #endregion
    }
}
