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
using System.Collections;

namespace SOI.INV
{
    // (Required) Inherit Base Form
    // SOIBaseForm02 Common Role    
    // - Convert Theme 
    // - Register Favorite 
    // - Default Bottom Button : Process, Cancel 
    // - (option) Help Information Button
    // - (option for SE) Standard Operation Button
    public partial class frmINVViewInventoryLotHistory : SOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;

        #endregion

        #region Constructor

        public frmINVViewInventoryLotHistory()
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
        private void frmINVViewInventoryLotHistory_Load(object sender, EventArgs e)
        {
            // Init
            dtpFromTime.Value = DateTime.Now.AddMonths(-1);

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
        private void frmINVViewInventoryLotHistory_Shown(object sender, EventArgs e)
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
        /// Lot ID에서 엔터키 입력 시 조회합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtInvLotID_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter && MPCF.Trim(txtInvLotID.Text) != "")
                {
                    if (ViewLotHistory(txtInvLotID.Text) == false)
                    {
                        MPCF.SetFocus(txtInvLotID);
                        txtInvLotID.SelectAll();
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
        /// Excel Button Click Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnToExcel_Click(object sender, EventArgs e)
        {
            try
            {
                // Export
                if (MPCF.ExportToExcel(spdHistory, this.Text, "", true, true, true, -1, -1) == false)
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
        /// View Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                // Validation
                if (MPCF.CheckValue(txtInvLotID, false) == false)
                {
                    return;
                }

                // View Lot History
                if (ViewLotHistory(txtInvLotID.Text) == false)
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

        #region Functions

        /// <summary>
        /// Lot History 조회
        /// </summary>
        /// <param name="sLotID"></param>
        /// <returns></returns>
        private bool ViewLotHistory(string sLotID)
        {
            TRSNode in_node = new TRSNode("VIEW_LOT_HISTORY_IN");
            TRSNode out_node = new TRSNode("VIEW_LOT_HISTORY_OUT");
            ArrayList lisHist = new ArrayList();

            try
            {
                // Call Service
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("INV_LOT_ID", MPCF.Trim(sLotID));
                in_node.AddString("FROM_TRAN_TIME", "20000101");
                in_node.AddString("TO_TRAN_TIME", "29991231");
                if (MPCF.CallService("WIP", "INV_View_Inv_Lot_History", in_node, ref out_node) == false)
                {
                    return false;
                }

                // Clear
                MPCF.ClearList(this.spdHistory);

                // Bind
                if (out_node.GetList(0) != null)
                {
                    int iRow = 0;

                    for (int i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        iRow = spdHistory.Sheets[0].Rows.Count;
                        spdHistory.Sheets[0].RowCount++;

                        spdHistory.ActiveSheet.Cells[iRow, 0].Value = out_node.GetList(0)[iRow].GetInt("HIST_SEQ");
                        spdHistory.ActiveSheet.Cells[iRow, 1].Value = MPCF.MakeDateFormat(out_node.GetList(0)[iRow].GetString("TRAN_TIME"));
                        spdHistory.ActiveSheet.Cells[iRow, 2].Value = out_node.GetList(0)[iRow].GetString("TRAN_CODE");
                        spdHistory.ActiveSheet.Cells[iRow, 3].Value = out_node.GetList(0)[iRow].GetString("INV_MAT_ID");
                        spdHistory.ActiveSheet.Cells[iRow, 4].Value = out_node.GetList(0)[iRow].GetString("INV_MAT_DESC");
                        spdHistory.ActiveSheet.Cells[iRow, 5].Value = out_node.GetList(0)[iRow].GetString("STORE_ID");
                        spdHistory.ActiveSheet.Cells[iRow, 6].Value = out_node.GetList(0)[iRow].GetString("STORE_DESC");
                        spdHistory.ActiveSheet.Cells[iRow, 7].Value = MPCF.MakeNumberFormat(out_node.GetList(0)[iRow].GetDouble("QTY_1"));
                        spdHistory.ActiveSheet.Cells[iRow, 8].Value = out_node.GetList(0)[iRow].GetChar("INV_LOT_TYPE");
                        spdHistory.ActiveSheet.Cells[iRow, 9].Value = out_node.GetList(0)[iRow].GetString("INV_LOT_STATUS");
                        spdHistory.ActiveSheet.Cells[iRow, 10].Value = out_node.GetList(0)[iRow].GetString("VENDOR_ID");
                        spdHistory.ActiveSheet.Cells[iRow, 11].Value = out_node.GetList(0)[iRow].GetString("TRAN_USER_ID");
                    }
                }

                // Fit Header
                MPCF.FitColumnHeader(spdHistory);

                // Success
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
}
