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
    public partial class frmINVViewInventoryLotListByStore : SOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;

        #endregion

        #region Constructor

        public frmINVViewInventoryLotListByStore()
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
        /// Store CodeView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cdvInvStore_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                // In Node Setup
                TRSNode in_node = new TRSNode("VIEW_DATA_LIST_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';

                // Display and Header Text Setup
                string[] display = new string[] { "STORE_ID", "STORE_DESC" };
                string[] header = new string[] { "Store ID", "Store Desc" };

                // Show CodeView and Get Return
                cdvInvStore.Text = cdvInvStore.Show(cdvInvStore, "View Store List", "INV", "INV_View_Store_List", in_node, "STORE_LIST", display, header, "Store ID");

                // Field Clear
                MPCF.FieldClear(this, cdvInvStore);

                // Validation
                if (string.IsNullOrEmpty(cdvInvStore.Text) == true)
                {
                    return;
                }

                // View Inv Lot List By Stroe
                if (ViewInvLotListByStore() == false)
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
        /// Inv Mat ID CodeView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cdvInvMatID_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                // Validation
                if (MPCF.CheckValue(cdvInvStore, false) == false)
                {
                    return;
                }

                // In Node Setup
                TRSNode in_node = new TRSNode("VIEW_DATA_LIST_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("MAT_TYPE", "RM");

                // Display and Header Text Setup
                string[] display = new string[] { "INV_MAT_ID", "INV_MAT_DESC" };
                string[] header = new string[] { "Inv Mat ID", "Inv Mat Desc" };

                // Show CodeView and Get Return
                cdvInvMatID.Text = cdvInvMatID.Show(cdvInvMatID, "View Inventory Material List", "INV", "INV_View_INV_Material_List", in_node, "INV_MATERIAL_LIST", display, header, "Inv Mat ID");

                // Field Clear
                MPCF.FieldClear(this, cdvInvStore, cdvInvMatID);

                // View Inv Lot List By Stroe
                if (ViewInvLotListByStore() == false)
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
        /// Lot Del Flag Checked Changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkInvLotDelFlag_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                // Validation
                if (string.IsNullOrEmpty(cdvInvStore.Text) == true)
                {
                    return;
                }

                // View
                if (ViewInvLotListByStore() == false)
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
        /// Excel Button Click Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnToExcel_Click(object sender, EventArgs e)
        {
            try
            {
                // Validation
                if (spdLotList.ActiveSheet.RowCount < 1)
                {
                    return;
                }
                
                // Export
                if (MPCF.ExportToExcel(spdLotList, this.Text, "", true, true, true, -1, -1) == false)
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
        /// View
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                // Validation
                if (MPCF.CheckValue(cdvInvStore, false) == false)
                {
                    return;
                }
                
                // View Inv Lot List By Stroe
                if (ViewInvLotListByStore() == false)
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
        /// View Inv Lot List by store
        /// </summary>
        /// <returns></returns>
        private bool ViewInvLotListByStore()
        {
            TRSNode in_node = new TRSNode("VIEW_DATA_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_DATA_LIST_OUT");
            ArrayList lisList = new ArrayList();

            try
            {
                // Call Service
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("STORE_ID", cdvInvStore.Text);
                in_node.AddString("INV_MAT_ID", cdvInvMatID.Text);

                if (MPCF.CallService("INV", "INV_View_Inv_Lot_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                // Field Clear
                MPCF.FieldClear(spdLotList);

                // Bind
                if (out_node.GetList(0) != null)
                {
                    int iRow = 0;

                    for (int i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        iRow = spdLotList.Sheets[0].Rows.Count;
                        spdLotList.Sheets[0].RowCount++;

                        spdLotList.ActiveSheet.Cells[iRow, 0].Value = out_node.GetList(0)[iRow].GetString("INV_LOT_ID");
                        spdLotList.ActiveSheet.Cells[iRow, 1].Value = out_node.GetList(0)[iRow].GetString("INV_MAT_ID");
                        spdLotList.ActiveSheet.Cells[iRow, 2].Value = out_node.GetList(0)[iRow].GetString("INV_MAT_DESC");
                        spdLotList.ActiveSheet.Cells[iRow, 3].Value = MPCF.MakeNumberFormat(out_node.GetList(0)[iRow].GetDouble("QTY_1"));
                        spdLotList.ActiveSheet.Cells[iRow, 4].Value = out_node.GetList(0)[iRow].GetChar("INV_LOT_TYPE");
                        spdLotList.ActiveSheet.Cells[iRow, 5].Value = out_node.GetList(0)[iRow].GetString("INV_LOT_STATUS");
                        spdLotList.ActiveSheet.Cells[iRow, 6].Value = out_node.GetList(0)[iRow].GetString("VENDOR_ID");
                        spdLotList.ActiveSheet.Cells[iRow, 7].Value = out_node.GetList(0)[iRow].GetChar("INV_LOT_DEL_FLAG");
                    }
                }

                if (chkInvLotDelFlag.Checked == true)
                {
                    // Call Service
                    in_node.Init();
                    out_node.Init();
                    MPCF.SetInMsg(in_node);
                    in_node.ProcStep = '1';
                    in_node.AddString("STORE_ID", cdvInvStore.Text);
                    in_node.AddString("INV_MAT_ID", cdvInvMatID.Text);
                    in_node.AddChar("INV_LOT_DEL_FLAG", "Y");

                    if (MPCF.CallService("INV", "INV_View_Inv_Lot_List", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    // Bind
                    if (out_node.GetList(0) != null)
                    {
                        int iRow = 0;

                        for (int i = 0; i < out_node.GetList(0).Count; i++)
                        {
                            iRow = spdLotList.Sheets[0].Rows.Count;
                            spdLotList.Sheets[0].RowCount++;

                            spdLotList.ActiveSheet.Cells[iRow, 0].Value = out_node.GetList(0)[i].GetString("INV_LOT_ID");
                            spdLotList.ActiveSheet.Cells[iRow, 1].Value = out_node.GetList(0)[i].GetString("INV_MAT_ID");
                            spdLotList.ActiveSheet.Cells[iRow, 2].Value = out_node.GetList(0)[i].GetString("INV_MAT_DESC");
                            spdLotList.ActiveSheet.Cells[iRow, 3].Value = MPCF.MakeNumberFormat(out_node.GetList(0)[i].GetDouble("QTY_1"));
                            spdLotList.ActiveSheet.Cells[iRow, 4].Value = out_node.GetList(0)[i].GetChar("INV_LOT_TYPE");
                            spdLotList.ActiveSheet.Cells[iRow, 5].Value = out_node.GetList(0)[i].GetString("INV_LOT_STATUS");
                            spdLotList.ActiveSheet.Cells[iRow, 6].Value = out_node.GetList(0)[i].GetString("VENDOR_ID");
                            spdLotList.ActiveSheet.Cells[iRow, 7].Value = out_node.GetList(0)[i].GetChar("INV_LOT_DEL_FLAG");
                        }
                    }
                }

                // Fit Column Header
                MPCF.FitColumnHeader(spdLotList);

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
