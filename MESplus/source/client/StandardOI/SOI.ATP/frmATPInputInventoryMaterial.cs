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
    public partial class frmATPInputInventoryMaterial : SOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;

        public ATPInputInventoryMaterialModel model = new ATPInputInventoryMaterialModel();

        private enum COL_SCAN_LIST
        {
            TRANSACTION_TIME = 0,
            INV_LOT_ID,
            QTY,
            INV_MAT_ID,
            INV_MAT_DESC
        }

        private enum COL_INV_MAT_LIST
        {
            INV_MAT_ID = 0,
            INV_MAT_DESC,
            QTY
        }

        #endregion

        #region Constructor

        public frmATPInputInventoryMaterial()
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
            // Init Data
            txtWorkOrderID.Text = model.WorkOrderID;
            txtPackQty.Text = model.PackQty;
            txtShop.Text = model.Shop;
            txtLineCode.Text = model.LineID;
            txtLineDesc.Text = model.LineDesc;
            txtMatCode.Text = model.MatID;
            txtMatDesc.Text = model.MatDesc;
            lblOrderQty.Text = model.OrderQty;
            lblPlanRemainQty.Text = model.RemainQty;
            lblOutQty.Text = model.OutQty;
            lblLossQty.Text = model.LossQty;

            // View Inputted List
            if (string.IsNullOrEmpty(txtWorkOrderID.Text) == false)
            {
                ViewInvLotList();
            }
           
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
        /// Inventory Lot ID TextBox Enter Key
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

                    // Input or Cancel Input
                    if (InputInvLot() == false)
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
        /// Refresh
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                // Field Clear
                MPCF.FieldClear(txtInvLotID);
                spdInputMatList.Sheets[0].Rows.Clear();
                spdScanList.Sheets[0].Rows.Clear();
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// View Data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                // Check Value
                if (MPCF.CheckValue(txtInvLotID, false) == false)
                {
                    return;
                }

                // Input or Cancel Input
                if (InputInvLot() == false)
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
        /// View Inputted List
        /// </summary>
        /// <returns></returns>
        private bool ViewInvLotList()
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_INPUTTED_LIST_IN");
                TRSNode out_node = new TRSNode("VIEW_INPUTTED_LIST_OUT");

                // Call Service
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("ORDER_ID", txtWorkOrderID.Text);
                in_node.AddString("SHOP_CODE", txtShop.Text);
                in_node.AddString("LINE_CODE", txtLineCode.Text);

                if (MPCF.CallService("ATP", "ATP_VIEW_WORKORDER_INPUT_INVENTORY_MATERIAL", in_node, ref out_node) == false)
                {
                    return false;
                }

                // Clear
                spdInputMatList.Sheets[0].Rows.Clear();
                spdScanList.Sheets[0].Rows.Clear();

                // No Data Found
                if (out_node.GetList(0) == null
                    || out_node.GetList(0).Count < 1)
                {
                    return true;
                }
                else
                {
                    int iRow = 0;
                    for (int i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        // Add To Inventory Lot List                
                        iRow = spdScanList.Sheets[0].Rows.Count;
                        spdScanList.Sheets[0].RowCount++;
                        spdScanList.Sheets[0].Cells[iRow, (int)COL_SCAN_LIST.TRANSACTION_TIME].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("TRAN_TIME"), DATE_TIME_FORMAT.DATETIME);
                        spdScanList.Sheets[0].Cells[iRow, (int)COL_SCAN_LIST.INV_LOT_ID].Value = out_node.GetList(0)[i].GetString("INV_LOT_ID");
                        spdScanList.Sheets[0].Cells[iRow, (int)COL_SCAN_LIST.QTY].Value = MPCF.MakeNumberFormat(out_node.GetList(0)[i].GetDouble("IN_QTY_1"));
                        spdScanList.Sheets[0].Cells[iRow, (int)COL_SCAN_LIST.INV_MAT_ID].Value = out_node.GetList(0)[i].GetString("INV_MAT_ID");
                        spdScanList.Sheets[0].Cells[iRow, (int)COL_SCAN_LIST.INV_MAT_DESC].Value = out_node.GetList(0)[i].GetString("INV_MAT_DESC");

                        // Add To Inputted Material List
                        if (ChangeSummaryInfo(out_node.GetList(0)[i].GetString("INV_MAT_ID"), out_node.GetList(0)[i].GetString("INV_MAT_DESC"), out_node.GetList(0)[i].GetDouble("IN_QTY_1")) == false)
                        {
                            return false;
                        }
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
        /// View Summary Information
        /// </summary>
        /// <returns></returns>
        private bool ChangeSummaryInfo(string invMatID, string invMatDesc, double qty)
        {
            try
            {
                int iFoundIndex = -1;
                
                // Check Exist Data
                for (int i = 0; i < spdInputMatList.Sheets[0].Rows.Count; i++)
                {
                    if (spdInputMatList.Sheets[0].Cells[i, (int)COL_INV_MAT_LIST.INV_MAT_ID].Value.ToString() == invMatID)
                    {
                        iFoundIndex = i;
                        break;
                    }
                }

                // Add to Exist Data
                if (iFoundIndex >= 0)
                {
                    // Pre-Scan Qty + Scan Qty
                    spdInputMatList.Sheets[0].Cells[iFoundIndex, (int)COL_INV_MAT_LIST.QTY].Value =
                        MPCF.MakeNumberFormat((MPCF.ToDbl(spdInputMatList.Sheets[0].Cells[iFoundIndex, (int)COL_INV_MAT_LIST.QTY].Value) + qty).ToString());
                }
                // Not Found Data
                else
                {
                    int iRow = spdInputMatList.Sheets[0].Rows.Count;
                    spdInputMatList.Sheets[0].RowCount++;
                    spdInputMatList.Sheets[0].Cells[iRow, (int)COL_INV_MAT_LIST.INV_MAT_ID].Value = invMatID;
                    spdInputMatList.Sheets[0].Cells[iRow, (int)COL_INV_MAT_LIST.INV_MAT_DESC].Value = invMatDesc;
                    spdInputMatList.Sheets[0].Cells[iRow, (int)COL_INV_MAT_LIST.QTY].Value = MPCF.MakeNumberFormat(qty);                    
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
        /// Process Input
        /// </summary>
        /// <returns></returns>
        private bool InputInvLot()
        {
            try
            {
                TRSNode in_node = new TRSNode("INPUT_INV_LOT_IN");
                TRSNode out_node = new TRSNode("INPUT_INV_LOT_OUT");                

                // Call Service
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("ORDER_ID", model.WorkOrderID);
                in_node.AddString("LINE_CODE", model.LineID);
                in_node.AddString("LABEL_ID", txtInvLotID.Text);

                // Input
                if (chkOutSelection.OnOffState == SOICheckBoxOnOffState.OnState)
                {
                    if (MPCF.CallService("ATP", "ATP_Input_Workorder_Inventory_Material", in_node, ref out_node) == false)
                    {
                        return false;
                    }
                }
                // Cancel Input
                else
                {
                    if (MPCF.CallService("ATP", "ATP_Cancelinput_Workorder_Inventory_Material", in_node, ref out_node) == false)
                    {
                        return false;
                    }
                }                

                // View Inv Lot List
                if (ViewInvLotList() == false)
                {
                    return false;
                }

                // Show Success Message
                MPCF.ShowSuccessMessage(out_node, false);

                //// Active Row Change
                //if (string.IsNullOrEmpty(out_node.GetString("INV_LOT_ID")) == false)
                //{
                //    for (int i = 0; i < spdScanList.Sheets[0].Rows.Count; i++)
                //    {
                //        if (spdScanList.Sheets[0].Cells[i, (int)COL_SCAN_LIST.INV_LOT_ID].Value != null
                //            && spdScanList.Sheets[0].Cells[i, (int)COL_SCAN_LIST.INV_LOT_ID].Value.ToString() == out_node.GetString("INV_LOT_ID"))
                //        {
                //            spdScanList.Sheets[0].ActiveRowIndex = i;
                //        }
                //    }
                //}  

                // Focus
                MPCF.FieldClear(txtInvLotID);
                MPCF.SetFocus(txtInvLotID);                

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

    public class ATPInputInventoryMaterialModel
    {
        private string workOrderID;
        public string WorkOrderID
        {
            get { return workOrderID; }
            set { workOrderID = value; }
        }

        private string packQty;
        public string PackQty
        {
            get { return packQty; }
            set { packQty = value; }
        }

        private string shop;
        public string Shop
        {
            get { return shop; }
            set { shop = value; }
        }

        private string lineID;
        public string LineID
        {
            get { return lineID; }
            set { lineID = value; }
        }

        private string lineDesc;
        public string LineDesc
        {
            get { return lineDesc; }
            set { lineDesc = value; }
        }

        private string matID;
        public string MatID
        {
            get { return matID; }
            set { matID = value; }
        }

        private string matDesc;
        public string MatDesc
        {
            get { return matDesc; }
            set { matDesc = value; }
        }

        private string orderQty;
        public string OrderQty
        {
            get { return orderQty; }
            set { orderQty = value; }
        }

        private string remainQty;
        public string RemainQty
        {
            get { return remainQty; }
            set { remainQty = value; }
        }

        private string outQty;
        public string OutQty
        {
            get { return outQty; }
            set { outQty = value; }
        }

        private string lossQty;
        public string LossQty
        {
            get { return lossQty; }
            set { lossQty = value; }
        }
    }
}
