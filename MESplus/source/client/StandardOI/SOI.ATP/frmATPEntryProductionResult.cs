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
    public partial class frmATPEntryProductionResult : SOIBaseForm03
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;

        public ATPEntryProductionResultModel model = new ATPEntryProductionResultModel();

        private enum COL_SCAN_LIST
        {
            TRANSACTION_TIME = 0,
            INV_LOT_ID,
            GOOD_QTY,
            BAD_QTY,
            INV_MAT_ID,
            INV_MAT_DESC
        }

        private enum COL_INV_MAT_LIST
        {
            INV_MAT_ID = 0,
            INV_MAT_DESC,
            INPUT_QTY,
            INPUT_COUNT
        }

        #endregion

        #region Constructor

        public frmATPEntryProductionResult()
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
            // TEST Load Data
            // 선발행: Scan Already Printed Label (P)
            // 후발행: Input Quantity (Q)
            // 투입품: Scan Inventory Lot ID (I)
            txtEntryType.Text = model.EntryType;
            txtWorkOrderID.Text = model.WorkOrderID;
            txtPackQty.Text = model.PackQty;
            txtShop.Text = model.Shop;
            txtLineCode.Text = model.LineID;
            txtLineDesc.Text = model.LineDesc;
            txtMatCode.Text = model.MatID;
            txtMatDesc.Text = model.MatDesc;
            lblOrderQty.Text = model.OrderQty;
            lblRemainQty.Text = model.RemainQty;
            lblOutQty.Text = model.OutQty;
            lblLossQty.Text = model.LossQty;

            SetInputResultType(model.EntryTypeFlag);

            ViewEntryResult();

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
        /// Qty Enter Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQtyEnter_Click(object sender, EventArgs e)
        {
            try
            {
                // Validation
                if (MPCF.CheckValue(txtQty, false) == false)
                {
                    return;
                }

                // Enter Result
                if (EnterResult() == false)
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
        /// ID Input Enter Key
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtIDInput_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    // Validation
                    if (MPCF.CheckValue(txtIDInput, false) == false)
                    {
                        return;
                    }

                    // Enter Result
                    if (EnterResult() == false)
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
        /// Refresh Button Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                // Clear
                MPCF.FieldClear(txtQty);
                MPCF.FieldClear(txtIDInput);
                spdInputMatList.Sheets[0].Rows.Clear();
                spdScanList.Sheets[0].Rows.Clear();

                //if (ViewEntryResult() == false)
                //{
                //    return;
                //}
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        #endregion

        #region Function

        /// <summary>
        /// Set Control
        /// </summary>
        /// <param name="flag"></param>
        private void SetInputResultType(char flag)
        {
            try
            {
                if (flag == 'P')
                {
                    tlpQty.Visible = false;
                    tlpTextBox.Visible = true;

                    lblIDLabel.Text = MPCF.FindLanguage("Lot ID");
                }
                // flag = Q
                else if (flag == 'Q')
                {
                    tlpTextBox.Visible = false;
                    tlpQty.Visible = true;
                }
                // flag = I
                else
                {
                    tlpQty.Visible = false;
                    tlpTextBox.Visible = true;

                    lblIDLabel.Text = MPCF.FindLanguage("Inventory Lot ID");
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// View Entry Result        
        /// </summary>
        /// <returns></returns>
        private bool ViewEntryResult()
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_ENTRY_RESULT_IN");
                TRSNode out_node = new TRSNode("VIEW_ENTRY_RESULT_OUT");

                // Call Service
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("ORDER_ID", txtWorkOrderID.Text);
                in_node.AddChar("OPERATION_TYPE", 'W');

                if (MPCF.CallService("ATP", "ATP_View_Wip_Lot_Entry_Result_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                if (out_node.GetList(0) == null
                    || out_node.GetList(0).Count < 1)
                {
                    return true;
                }
                else
                {
                    // Clear
                    spdInputMatList.Sheets[0].Rows.Clear();
                    spdScanList.Sheets[0].Rows.Clear();

                    for (int i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        // Add To Inventory Lot List                
                        int iRow = spdScanList.Sheets[0].Rows.Count;
                        spdScanList.Sheets[0].RowCount++;
                        spdScanList.Sheets[0].Cells[iRow, (int)COL_SCAN_LIST.TRANSACTION_TIME].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("TRAN_TIME"), DATE_TIME_FORMAT.DATETIME);
                        spdScanList.Sheets[0].Cells[iRow, (int)COL_SCAN_LIST.INV_LOT_ID].Value = out_node.GetList(0)[i].GetString("LOT_ID");
                        spdScanList.Sheets[0].Cells[iRow, (int)COL_SCAN_LIST.GOOD_QTY].Value = MPCF.MakeNumberFormat(out_node.GetList(0)[i].GetDouble("GOOD_QTY"));
                        spdScanList.Sheets[0].Cells[iRow, (int)COL_SCAN_LIST.BAD_QTY].Value = MPCF.MakeNumberFormat(out_node.GetList(0)[i].GetDouble("BAD_QTY"));
                        spdScanList.Sheets[0].Cells[iRow, (int)COL_SCAN_LIST.INV_MAT_ID].Value = out_node.GetList(0)[i].GetString("MAT_ID");
                        spdScanList.Sheets[0].Cells[iRow, (int)COL_SCAN_LIST.INV_MAT_DESC].Value = out_node.GetList(0)[i].GetString("MAT_DESC");
                        
                        // Add To Inputted List
                        int iFoundRowIndex = MPCF.GetSpreadRowIndex(spdInputMatList, (int)COL_INV_MAT_LIST.INV_MAT_ID, out_node.GetList(0)[i].GetString("MAT_ID"));
                        if (iFoundRowIndex < 0)
                        {
                            iRow = spdInputMatList.Sheets[0].Rows.Count;
                            spdInputMatList.Sheets[0].RowCount++;
                            spdInputMatList.Sheets[0].Cells[iRow, (int)COL_INV_MAT_LIST.INV_MAT_ID].Value = out_node.GetList(0)[i].GetString("MAT_ID");
                            spdInputMatList.Sheets[0].Cells[iRow, (int)COL_INV_MAT_LIST.INV_MAT_DESC].Value = out_node.GetList(0)[i].GetString("MAT_DESC");
                            spdInputMatList.Sheets[0].Cells[iRow, (int)COL_INV_MAT_LIST.INPUT_QTY].Value = MPCF.MakeNumberFormat(out_node.GetList(0)[i].GetDouble("GOOD_QTY"));
                            spdInputMatList.Sheets[0].Cells[iRow, (int)COL_INV_MAT_LIST.INPUT_COUNT].Value = 1;
                        }
                        else
                        {
                            spdInputMatList.Sheets[0].Cells[iFoundRowIndex, (int)COL_INV_MAT_LIST.INPUT_QTY].Value = 
                                MPCF.MakeNumberFormat((MPCF.ToDbl(spdInputMatList.Sheets[0].Cells[iFoundRowIndex, (int)COL_INV_MAT_LIST.INPUT_QTY].Value)
                                + MPCF.ToDbl(out_node.GetList(0)[i].GetDouble("GOOD_QTY"))).ToString());

                            spdInputMatList.Sheets[0].Cells[iFoundRowIndex, (int)COL_INV_MAT_LIST.INPUT_COUNT].Value = 
                                (MPCF.ToInt(spdInputMatList.Sheets[0].Cells[iFoundRowIndex, (int)COL_INV_MAT_LIST.INPUT_COUNT].Value) + 1).ToString();
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
        /// Process Enter Result
        /// </summary>
        /// <returns></returns>
        private bool EnterResult()
        {
            try
            {
                TRSNode in_node = new TRSNode("ENTER_RESULT_IN");
                TRSNode out_node = new TRSNode("ENTER_RESULT_OUT");

                // Call Service
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';

                // Scan Already Printed Label (P) : 선발행
                if (model.EntryTypeFlag == 'P')
                {
                    in_node.AddChar("ENTRY_TYPE", model.EntryTypeFlag);
                    in_node.AddString("ORDER_ID", model.WorkOrderID);
                    in_node.AddString("LOT_ID", txtIDInput.Text);                    
                }
                // Input Quantity (Q) : 후발행
                else if (model.EntryTypeFlag == 'Q')
                {
                    in_node.AddChar("ENTRY_TYPE", model.EntryTypeFlag);
                    in_node.AddString("ORDER_ID", model.WorkOrderID);
                    in_node.AddDouble("QTY", MPCF.ToDbl(txtQty.Value));
                }
                // Scan Inventory Lot ID (I) : 투입품
                else
                {
                    in_node.AddChar("ENTRY_TYPE", model.EntryTypeFlag);
                    in_node.AddString("ORDER_ID", model.WorkOrderID);
                    in_node.AddString("LOT_ID", txtIDInput.Text);
                }

                if (MPCF.CallService("ATP", "ATP_ENTRYRESULT_WIP_LOT", in_node, ref out_node) == false)
                {
                    return false;
                }

                // Show Success Message
                MPCF.ShowSuccessMessage(out_node, false);

                // Print Label
                if (chkPrintLabel.Checked == true)
                {
                    // 선발행 또는 후발행인 경우에만 발행
                    if (model.EntryTypeFlag == 'P' || model.EntryTypeFlag == 'Q')
                    {
                        // Mapping Data
                        TRSNode mappingNode = new TRSNode("MAPPING_NODE");
                        mappingNode.AddString("INV_LABEL_ID", out_node.GetString("INV_LOT_ID"));

                        // Print Label
                        MPCF.PrintLabelByLabelID(this, base.printOption, "ATP_MES_OPTIONS", "INV_PRINT_LABEL_ID", mappingNode);
                    }
                }

                if (ViewEntryResult() == false)
                {
                    return false;
                }

                //// Add To Inventory Lot List
                //int iRow = spdScanList.Sheets[0].Rows.Count;
                //spdScanList.Sheets[0].RowCount++;
                //spdScanList.Sheets[0].Cells[iRow, (int)COL_SCAN_LIST.TRANSACTION_TIME].Value = MPCF.MakeDateFormat(out_node.GetString("TRAN_TIME"), DATE_TIME_FORMAT.DATETIME);
                //spdScanList.Sheets[0].Cells[iRow, (int)COL_SCAN_LIST.INV_LOT_ID].Value = out_node.GetString("INV_LOT_ID");
                //spdScanList.Sheets[0].Cells[iRow, (int)COL_SCAN_LIST.QTY].Value = MPCF.MakeNumberFormat(out_node.GetDouble("QTY"));
                //spdScanList.Sheets[0].Cells[iRow, (int)COL_SCAN_LIST.INV_MAT_ID].Value = out_node.GetString("MAT_ID");
                //spdScanList.Sheets[0].Cells[iRow, (int)COL_SCAN_LIST.INV_MAT_DESC].Value = out_node.GetString("MAT_DESC");
                //spdScanList.Sheets[0].Cells[iRow, (int)COL_SCAN_LIST.LOSS_QTY].Value = MPCF.MakeNumberFormat(out_node.GetDouble("SCRAP_QTY"));

                //// Add To Inputted List
                //int iFoundRowIndex = MPCF.GetSpreadRowIndex(spdInputMatList, (int)COL_INV_MAT_LIST.INV_MAT_ID, out_node.GetString("INV_MAT_ID"));
                //if (iFoundRowIndex < 0)
                //{
                //    iRow = spdInputMatList.Sheets[0].Rows.Count;
                //    spdInputMatList.Sheets[0].RowCount++;
                //    spdInputMatList.Sheets[0].Cells[iRow, (int)COL_INV_MAT_LIST.INV_MAT_ID].Value = out_node.GetString("MAT_ID");
                //    spdInputMatList.Sheets[0].Cells[iRow, (int)COL_INV_MAT_LIST.INV_MAT_DESC].Value = out_node.GetString("MAT_DESC");
                //    spdInputMatList.Sheets[0].Cells[iRow, (int)COL_INV_MAT_LIST.INPUT_QTY].Value = MPCF.MakeNumberFormat(out_node.GetDouble("QTY"));
                //    spdInputMatList.Sheets[0].Cells[iRow, (int)COL_INV_MAT_LIST.INPUT_COUNT].Value = "1";
                //}
                //else
                //{
                //    spdInputMatList.Sheets[0].Cells[iFoundRowIndex, (int)COL_INV_MAT_LIST.INPUT_QTY].Value = (MPCF.ToDbl(spdInputMatList.Sheets[0].Cells[iFoundRowIndex, (int)COL_INV_MAT_LIST.INPUT_QTY].Value)
                //        + out_node.GetDouble("QTY")).ToString();

                //    spdInputMatList.Sheets[0].Cells[iFoundRowIndex, (int)COL_INV_MAT_LIST.INPUT_COUNT].Value = (MPCF.ToInt(spdInputMatList.Sheets[0].Cells[iFoundRowIndex, (int)COL_INV_MAT_LIST.INPUT_COUNT].Value)
                //        + 1).ToString();
                //}

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

    public class ATPEntryProductionResultModel
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

        private string entryType;
        public string EntryType
        {
            get { return entryType; }
            set { entryType = value; }
        }

        private char entryTypeFlag;
        public char EntryTypeFlag
        {
            get { return entryTypeFlag; }
            set { entryTypeFlag = value; }
        }
    }
}
