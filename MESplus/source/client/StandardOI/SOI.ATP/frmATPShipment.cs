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
    public partial class frmATPShipment : SOIBaseForm03
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;

        public ATPShipmentModel model = new ATPShipmentModel();

        private enum COL_REQ_DETAIL_LIST
        {
            SEQ = 0,
            MAT_ID,
            MAT_DESC,
            REQ_QTY,
            OUT_QTY,
            SCAN_QTY,
            REMAIN_QTY
        }

        private enum COL_SCAN_LIST
        {
            LABEL_ID = 1,
            MAT_ID,
            QTY
        }

        #endregion

        #region Constructor

        public frmATPShipment()
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
            txtShipmentOrdID.Text = model.ShipmentOrderID;
            if (string.IsNullOrEmpty(model.ShipmentDate) == true)
            {
                DateTime dtNow = DateTime.Now;
                dtReqTime.SetValueAsDateTime(dtNow);
            }
            else
            {
                dtReqTime.SetValueAsString(model.ShipmentDate);
            }
            cdvCustomer.Text = model.CustomerID;
            txtCustomerDesc.Text = model.CustomerDesc;

            if (string.IsNullOrEmpty(txtShipmentOrdID.Text) == false)
            {
                ViewRequestDetails();
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
                // MPCF.SetFocus(control);                

                // (Required) 
                bIsShown = true;
            }
        }

        /// <summary>
        /// Label ID Enter Key
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtLabelID_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    // Check Value
                    if (MPCF.CheckValue(txtLabelID, false) == false)
                    {
                        return;
                    }

                    // Add to List
                    if (AddToScanList(txtLabelID.Text) == false)
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
        /// Customer Codeview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cdvCustomer_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                // Pre-Search 
                TRSNode in_node = new TRSNode("VIEW_CUSTOMER_IN");
                TRSNode out_node = new TRSNode("VIEW_CUSTOMER_OUT");

                // In Node Setup                
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", "ATP_VENDOR");
                in_node.AddString("DATA_2", "V");

                // CodeView Column Header Setup
                string[] header = new string[] { "Purchase Type", "Purchase Type Description" };

                // CodeView Display Column Setup
                string[] display = new string[] { "KEY_1", "DATA_1" };

                // Show
                cdvCustomer.Text = cdvCustomer.Show(cdvCustomer, "Purchase Type", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "KEY_1");

                // Description
                if (cdvCustomer.returnDatas != null && cdvCustomer.returnDatas.Count > 0)
                {
                    txtCustomerDesc.Text = cdvCustomer.returnDatas[1];
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Open Print Popup
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProcess_Click(object sender, EventArgs e)
        {
            frmATPShipmentPrintPopup frm = new frmATPShipmentPrintPopup();
            ATPShipmentPrintPopupModelList list;

            try
            {
                if (Ship() == false)
                {
                    return;
                }

                DateTime dt = DateTime.Now;

                // Validation
                if (spdReqDetail.Sheets[0].Rows.Count < 1)
                {
                    return;
                }
                if (spdScanList.Sheets[0].Rows.Count < 1)
                {
                    return;
                }

                frm.Owner = this;

                // Bind
                frm.model.Supplier = string.Empty;
                frm.model.CarNumber = model.CarNumber;
                frm.model.InvoiceNumber = model.InvoiceNumber;
                frm.model.Consumer = cdvCustomer.Text;
                frm.model.IssueDate = dt.ToString();

                for (int i = 0; i < spdReqDetail.Sheets[0].Rows.Count; i++)
                {
                    list = new ATPShipmentPrintPopupModelList();

                    list.Seq = Convert.ToString(spdReqDetail.Sheets[0].Cells[i, (int)COL_REQ_DETAIL_LIST.SEQ].Value);
                    list.MatID = Convert.ToString(spdReqDetail.Sheets[0].Cells[i, (int)COL_REQ_DETAIL_LIST.MAT_ID].Value);
                    list.MatDesc = Convert.ToString(spdReqDetail.Sheets[0].Cells[i, (int)COL_REQ_DETAIL_LIST.MAT_DESC].Value);
                    list.Qty = Convert.ToString(spdReqDetail.Sheets[0].Cells[i, (int)COL_REQ_DETAIL_LIST.SCAN_QTY].Value);
                    list.Ramark = string.Empty;

                    if (frm.model.List == null)
                    {
                        frm.model.List = new List<ATPShipmentPrintPopupModelList>();
                    }

                    frm.model.List.Add(list);
                }

                frm.ShowDialog();

                if (ViewRequestDetails() == false)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
            finally
            {
                if (frm != null)
                {
                    frm.Dispose();
                }
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
                        if (DelScanQty(MPCF.Trim(spdScanList.Sheets[0].Cells[i, (int)COL_SCAN_LIST.MAT_ID].Value),
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
                // List Clear
                MPCF.FieldClear(txtLabelID);
                spdScanList.Sheets[0].Rows.Clear();
                spdReqDetail.Sheets[0].Rows.Clear();

                // View Request Detail
                if (ViewRequestDetails() == false)
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
        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                // List Clear
                MPCF.FieldClear(txtLabelID);
                spdScanList.Sheets[0].Rows.Clear();
                spdReqDetail.Sheets[0].Rows.Clear();

                // View Request Detail
                if (ViewRequestDetails() == false)
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
        /// View Request Detail
        /// </summary>
        /// <returns></returns>
        private bool ViewRequestDetails()
        {
            try
            {
                // Field Clear
                MPCF.FieldClear(txtLabelID);
                spdReqDetail.Sheets[0].Rows.Clear();
                spdScanList.Sheets[0].Rows.Clear();

                TRSNode in_node = new TRSNode("VIEW_REQ_DETAIL_IN");
                TRSNode out_node = new TRSNode("VIEW_REQ_DETAIL_OUT");

                // Call Service
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("INV_REQ_NO", txtShipmentOrdID.Text);

                if (MPCF.CallService("ATP", "ATP_VIEW_REQUESTORDER_LIST_DETAIL", in_node, ref out_node) == false)
                {
                    return false;
                }

                // Bind
                if (out_node.GetList(0) != null)
                {
                    List<TRSNode> outList = out_node.GetList(0);

                    int iRow = 0;

                    for (int i = 0; i < outList.Count; i++)
                    {
                        iRow = spdReqDetail.Sheets[0].Rows.Count;
                        spdReqDetail.Sheets[0].RowCount++;

                        spdReqDetail.Sheets[0].Cells[iRow, (int)COL_REQ_DETAIL_LIST.SEQ].Value = (i + 1);
                        spdReqDetail.Sheets[0].Cells[iRow, (int)COL_REQ_DETAIL_LIST.MAT_ID].Value = outList[i].GetString("MAT_ID");
                        spdReqDetail.Sheets[0].Cells[iRow, (int)COL_REQ_DETAIL_LIST.MAT_DESC].Value = outList[i].GetString("MAT_DESC");
                        spdReqDetail.Sheets[0].Cells[iRow, (int)COL_REQ_DETAIL_LIST.REQ_QTY].Value = MPCF.MakeNumberFormat(outList[i].GetDouble("REQ_QTY"));
                        spdReqDetail.Sheets[0].Cells[iRow, (int)COL_REQ_DETAIL_LIST.OUT_QTY].Value = MPCF.MakeNumberFormat(outList[i].GetDouble("RESULT_QTY"));
                        spdReqDetail.Sheets[0].Cells[iRow, (int)COL_REQ_DETAIL_LIST.SCAN_QTY].Value = 0;
                        spdReqDetail.Sheets[0].Cells[iRow, (int)COL_REQ_DETAIL_LIST.REMAIN_QTY].Value = MPCF.MakeNumberFormat(outList[i].GetDouble("REQ_QTY") - outList[i].GetDouble("RESULT_QTY"));
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
        private bool AddToScanList(string labelID)
        {
            try
            {
                for (int i = 0; i < spdScanList.Sheets[0].Rows.Count; i++)
                {
                    if (spdScanList.Sheets[0].Cells[i, (int)COL_SCAN_LIST.LABEL_ID].Value != null
                        && spdScanList.Sheets[0].Cells[i, (int)COL_SCAN_LIST.LABEL_ID].Value.ToString() == labelID)
                    {
                        return true;
                    }
                }

                TRSNode in_node = new TRSNode("VIEW_INV_LOT_IN");
                TRSNode out_node = new TRSNode("VIEW_INV_LOT_OUT");

                // Call Service
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LABEL_ID", MPCF.Trim(labelID));

                if (MPCF.CallService("ATP", "ATP_VIEW_LABEL", in_node, ref out_node) == false)
                {
                    return false;
                }

                if (ChangeSummaryInfo(out_node.GetString("MAT_ID"), out_node.GetString("MAT_DESC"), out_node.GetDouble("QTY_1"),
                        out_node.GetDouble("OUT_QTY"), out_node.GetDouble("REQ_QTY")) == false)
                {
                    return false;
                }

                // Bind
                int iRow = spdScanList.Sheets[0].Rows.Count;
                spdScanList.Sheets[0].RowCount++;
                spdScanList.Sheets[0].Cells[iRow, 0].Value = true;
                spdScanList.Sheets[0].Cells[iRow, (int)COL_SCAN_LIST.LABEL_ID].Value = out_node.GetString("LABEL_ID");
                spdScanList.Sheets[0].Cells[iRow, (int)COL_SCAN_LIST.MAT_ID].Value = out_node.GetString("MAT_ID");
                spdScanList.Sheets[0].Cells[iRow, (int)COL_SCAN_LIST.QTY].Value = MPCF.MakeNumberFormat(out_node.GetDouble("QTY_1"));

                // Set Focus
                MPCF.SetFocusAndSelectAll(txtLabelID);

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
        private bool ChangeSummaryInfo(string invMatID, string invMatDesc, double scanQty, double outQty, double reqQty)
        {
            try
            {
                // Validation
                if (CheckInvMatIDInSumInfo(invMatID) == false)
                {
                    MPCF.ShowMessage(MPCF.GetMessage(80), MSG_LEVEL.ERROR, false);
                    return false;
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
                for (int i = 0; i < spdReqDetail.Sheets[0].Rows.Count; i++)
                {
                    if (spdReqDetail.Sheets[0].Cells[i, (int)COL_REQ_DETAIL_LIST.MAT_ID].Value.ToString() == invMatID)
                    {
                        // Remain Qty
                        spdReqDetail.Sheets[0].Cells[i, (int)COL_REQ_DETAIL_LIST.REMAIN_QTY].Value =
                            MPCF.MakeNumberFormat((MPCF.ToDbl(spdReqDetail.Sheets[0].Cells[i, (int)COL_REQ_DETAIL_LIST.REMAIN_QTY].Value) - scanQty));

                        // Scan Qty
                        spdReqDetail.Sheets[0].Cells[i, (int)COL_REQ_DETAIL_LIST.SCAN_QTY].Value =
                            MPCF.MakeNumberFormat((MPCF.ToDbl(spdReqDetail.Sheets[0].Cells[i, (int)COL_REQ_DETAIL_LIST.SCAN_QTY].Value) + scanQty));

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
                for (int i = 0; i < spdReqDetail.Sheets[0].Rows.Count; i++)
                {
                    if (spdReqDetail.Sheets[0].Cells[i, (int)COL_REQ_DETAIL_LIST.MAT_ID].Value.ToString() == invMatID)
                    {
                        // Remain Qty
                        spdReqDetail.Sheets[0].Cells[i, (int)COL_REQ_DETAIL_LIST.REMAIN_QTY].Value =
                            MPCF.MakeNumberFormat((MPCF.ToDbl(spdReqDetail.Sheets[0].Cells[i, (int)COL_REQ_DETAIL_LIST.REMAIN_QTY].Value) + scanQty));

                        // Scan Qty
                        spdReqDetail.Sheets[0].Cells[i, (int)COL_REQ_DETAIL_LIST.SCAN_QTY].Value =
                            MPCF.MakeNumberFormat((MPCF.ToDbl(spdReqDetail.Sheets[0].Cells[i, (int)COL_REQ_DETAIL_LIST.SCAN_QTY].Value) - scanQty));

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
            if (spdReqDetail.Sheets[0].Rows.Count < 1)
            {
                return false;
            }

            for (int i = 0; i < spdReqDetail.Sheets[0].Rows.Count; i++)
            {
                if (spdReqDetail.Sheets[0].Cells[i, (int)COL_REQ_DETAIL_LIST.MAT_ID].Value.ToString() == invMatID)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Shipment
        /// </summary>
        /// <returns></returns>
        private bool Ship()
        {
            try
            {
                TRSNode in_node = new TRSNode("SHIPMENT_IN");
                TRSNode out_node = new TRSNode("SHIPMENT_OUT");
                TRSNode scanList;

                // Call Service
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';                
                in_node.AddString("INV_REQ_NO", model.ShipmentOrderID);

                for (int i = 0; i < spdScanList.Sheets[0].Rows.Count; i++)
                {
                    scanList = in_node.AddNode("LABEL_LIST");

                    scanList.AddString("LABEL_ID", spdScanList.Sheets[0].Cells[i, (int)COL_SCAN_LIST.LABEL_ID].Value.ToString());
                }

                if (MPCF.CallService("ATP", "ATP_SHIP_INV_LOT", in_node, ref out_node) == false)
                {
                    return false;
                }

                // Show Success Message
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

    public class ATPShipmentModel
    {
        private string shipmentOrderID;
        public string ShipmentOrderID
        {
            get { return shipmentOrderID; }
            set { shipmentOrderID = value; }
        }

        private string shipmentDate;
        public string ShipmentDate
        {
            get { return shipmentDate; }
            set { shipmentDate = value; }
        }

        private string customerID;
        public string CustomerID
        {
            get { return customerID; }
            set { customerID = value; }
        }

        private string customerDesc;
        public string CustomerDesc
        {
            get { return customerDesc; }
            set { customerDesc = value; }
        }

        private string carNumber;
        public string CarNumber
        {
            get { return carNumber; }
            set { carNumber = value; }
        }

        private string invoiceNumber;
        public string InvoiceNumber
        {
            get { return invoiceNumber; }
            set { invoiceNumber = value; }
        }
    }
}
