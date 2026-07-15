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
    public partial class frmATPPurchaseInspectManagement : SOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;
        private string sPurchaseType;

        private enum COL_PURCHASE_LIST
        {
            STATUS = 0,
            STATUS_DESC,
            PURCHASE_TYPE,
            PURCHASE_TYPE_DESC,
            WORK_CENTER,
            VENDOR,
            DELIVERY_DATE,
            ERP_DELIVERY_NOTE,
            MATERIAL_COUNT,
            DELIVERY_QTY,
            IQC_PASS_QTY,
            RECEIPT_QTY,
            REJECT_QTY,
            REMARKS,
            DELIVERY_NOTE,
            RECEIPT_STORE
            //PURCHASE_ORDER_ID
        }

        #endregion

        #region Constructor

        public frmATPPurchaseInspectManagement()
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
            DateTime dt = DateTime.Now;
            dtToDeliveryDate.SetValueAsDateTime(dt);
            dt = dt.AddDays(-(dt.Day - 1));
            dtFromDeliveryDate.SetValueAsDateTime(dt);

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
        /// Work Center CodeView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cdvWorkCenter_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                // Pre-Search 
                TRSNode in_node = new TRSNode("VIEW_WORK_CENTER_IN");
                TRSNode out_node = new TRSNode("VIEW_WORK_CENTER_OUT");

                // In Node Setup                
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", "ATP_WORK_CENTER");

                // CodeView Column Header Setup
                string[] header = new string[] { "Work Center", "Work Center Description" };

                // CodeView Display Column Setup
                string[] display = new string[] { "KEY_1", "DATA_1" };

                // Show
                cdvWorkCenter.Text = cdvWorkCenter.Show(cdvWorkCenter, "Work Center", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "KEY_1");
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Purchase Type CodeView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cdvPurchaseType_CodeViewButtonClick(object sender, EventArgs e)
        {
             try
            {
                // Pre-Search 
                TRSNode in_node = new TRSNode("VIEW_PUR_TYPE_IN");
                TRSNode out_node = new TRSNode("VIEW_PUR_TYPE_OUT");

                // In Node Setup                
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", "ATP_PUR_TYPE");

                // CodeView Column Header Setup
                string[] header = new string[] { "Purchase Type", "Purchase Type Description" };

                // CodeView Display Column Setup
                string[] display = new string[] { "KEY_1", "DATA_1" };

                // Show
                cdvPurchaseType.Text = cdvPurchaseType.Show(cdvPurchaseType, "Purchase Type", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "DATA_1");
                if (cdvPurchaseType.returnDatas == null || cdvPurchaseType.returnDatas.Count < 1)
                {
                    return;
                }

                sPurchaseType = cdvPurchaseType.returnDatas[0];

                //if (ViewPurchaseInspect() == false)
                //{
                //    return;
                //}                
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Customer CodeView
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

                // Blank Data
                if (string.IsNullOrEmpty(cdvCustomer.Text) == true)
                {
                    txtCustomerDesc.Text = string.Empty;
                }

                // Customer Description
                if (cdvCustomer.returnDatas == null || cdvCustomer.returnDatas.Count < 1)
                {
                    return;
                }
                txtCustomerDesc.Text = cdvCustomer.returnDatas[1];
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Open Inspect Form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInspect_Click(object sender, EventArgs e)
        {
            try
            {
                // Validation
                if (spdPurchase.ActiveSheet.ActiveRowIndex < 0)
                {
                    return;
                }

                frmATPPurchaseInspect frm = new frmATPPurchaseInspect();
                frm.model.DeliveryNote = Convert.ToString(spdPurchase.Sheets[0].Cells[spdPurchase.ActiveSheet.ActiveRowIndex, (int)COL_PURCHASE_LIST.DELIVERY_NOTE].Value);
                frm.model.DeliveryDate = Convert.ToString(spdPurchase.Sheets[0].Cells[spdPurchase.ActiveSheet.ActiveRowIndex, (int)COL_PURCHASE_LIST.DELIVERY_DATE].Value);
                frm.model.Vendor = Convert.ToString(spdPurchase.Sheets[0].Cells[spdPurchase.ActiveSheet.ActiveRowIndex, (int)COL_PURCHASE_LIST.VENDOR].Value);
                frm.model.DeliveryStatus = Convert.ToString(spdPurchase.Sheets[0].Cells[spdPurchase.ActiveSheet.ActiveRowIndex, (int)COL_PURCHASE_LIST.STATUS].Value);
                frm.model.DeliveryStatusDesc = Convert.ToString(spdPurchase.Sheets[0].Cells[spdPurchase.ActiveSheet.ActiveRowIndex, (int)COL_PURCHASE_LIST.STATUS_DESC].Value);
                frm.model.ReqQty = Convert.ToString(spdPurchase.Sheets[0].Cells[spdPurchase.ActiveSheet.ActiveRowIndex, (int)COL_PURCHASE_LIST.DELIVERY_QTY].Value);

                MenuInfoTag menuInfo = new MenuInfoTag();
                menuInfo.c_func_type = 'F';
                menuInfo.s_assembly_file = "SOI.ATP.dll";
                menuInfo.s_assembly_name = "SOI.ATP.frmATPPurchaseInspect";
                menuInfo.s_func_desc = "Purchase Inspect";
                menuInfo.s_func_name = "";
                MPGV.gIMdiForm.OpenMenu(menuInfo, frm);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Process Batch Inspect
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBatchInspect_Click(object sender, EventArgs e)
        {
            try
            {
                // Validation
                if (spdPurchase.ActiveSheet.ActiveRowIndex < 0)
                {
                    return;
                }

                // Message
                if (MPCF.ShowMsgBox(MPCF.GetMessage(76), MessageBoxButtons.YesNo, MSG_LEVEL.NONE) == System.Windows.Forms.DialogResult.No)
                {
                    return;
                }

                // Get Delivery Note
                string sDeliveryNote = string.Empty;
                string sStoreID = string.Empty;
                if (spdPurchase.Sheets[0].Cells[spdPurchase.ActiveSheet.ActiveRowIndex, (int)COL_PURCHASE_LIST.DELIVERY_NOTE].Value != null)
                {
                    sDeliveryNote = spdPurchase.Sheets[0].Cells[spdPurchase.ActiveSheet.ActiveRowIndex, (int)COL_PURCHASE_LIST.DELIVERY_NOTE].Value.ToString();
                }
                if (spdPurchase.Sheets[0].Cells[spdPurchase.ActiveSheet.ActiveRowIndex, (int)COL_PURCHASE_LIST.RECEIPT_STORE].Value != null)
                {
                    sStoreID = spdPurchase.Sheets[0].Cells[spdPurchase.ActiveSheet.ActiveRowIndex, (int)COL_PURCHASE_LIST.RECEIPT_STORE].Value.ToString();
                }

                // Batch Inspect
                if (BatchInspect(sDeliveryNote, sStoreID) == false)
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
        /// Open Reprint Form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReprint_Click(object sender, EventArgs e)
        {
            try
            {
                // Validation
                if (spdPurchase.ActiveSheet.ActiveRowIndex < 0)
                {
                    return;
                }

                frmATPReprintInventoryLotLabel frm = new frmATPReprintInventoryLotLabel();
                frm.model.DeliveryNote = Convert.ToString(spdPurchase.Sheets[0].Cells[spdPurchase.ActiveSheet.ActiveRowIndex, (int)COL_PURCHASE_LIST.DELIVERY_NOTE].Value);
                frm.model.DeliveryDate = Convert.ToString(spdPurchase.Sheets[0].Cells[spdPurchase.ActiveSheet.ActiveRowIndex, (int)COL_PURCHASE_LIST.DELIVERY_DATE].Value);
                frm.model.Vendor = Convert.ToString(spdPurchase.Sheets[0].Cells[spdPurchase.ActiveSheet.ActiveRowIndex, (int)COL_PURCHASE_LIST.VENDOR].Value);
                frm.model.DeliveryStatus = Convert.ToString(spdPurchase.Sheets[0].Cells[spdPurchase.ActiveSheet.ActiveRowIndex, (int)COL_PURCHASE_LIST.STATUS].Value);
                frm.model.DeliveryStatusDesc = Convert.ToString(spdPurchase.Sheets[0].Cells[spdPurchase.ActiveSheet.ActiveRowIndex, (int)COL_PURCHASE_LIST.STATUS_DESC].Value);
                frm.model.ReqQty = Convert.ToString(spdPurchase.Sheets[0].Cells[spdPurchase.ActiveSheet.ActiveRowIndex, (int)COL_PURCHASE_LIST.DELIVERY_QTY].Value);

                MenuInfoTag menuInfo = new MenuInfoTag();
                menuInfo.c_func_type = 'F';
                menuInfo.s_assembly_file = "SOI.ATP.dll";
                menuInfo.s_assembly_name = "SOI.ATP.frmATPReprintInventoryLotLabel";
                menuInfo.s_func_desc = "Reprint Inventory Lot Label";
                menuInfo.s_func_name = "";
                MPGV.gIMdiForm.OpenMenu(menuInfo, frm);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Open Receipt Information Form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReceiptInfo_Click(object sender, EventArgs e)
        {
            try
            {
                // Validation
                if (spdPurchase.ActiveSheet.ActiveRowIndex < 0)
                {
                    return;
                }

                frmATPReceiptInformation frm = new frmATPReceiptInformation();
                frm.model.DeliveryNote = Convert.ToString(spdPurchase.Sheets[0].Cells[spdPurchase.ActiveSheet.ActiveRowIndex, (int)COL_PURCHASE_LIST.DELIVERY_NOTE].Value);
                frm.model.DeliveryDate = Convert.ToString(spdPurchase.Sheets[0].Cells[spdPurchase.ActiveSheet.ActiveRowIndex, (int)COL_PURCHASE_LIST.DELIVERY_DATE].Value);
                frm.model.Vendor = Convert.ToString(spdPurchase.Sheets[0].Cells[spdPurchase.ActiveSheet.ActiveRowIndex, (int)COL_PURCHASE_LIST.VENDOR].Value);
                frm.model.DeliveryStatus = Convert.ToString(spdPurchase.Sheets[0].Cells[spdPurchase.ActiveSheet.ActiveRowIndex, (int)COL_PURCHASE_LIST.STATUS].Value);
                frm.model.DeliveryStatusDesc = Convert.ToString(spdPurchase.Sheets[0].Cells[spdPurchase.ActiveSheet.ActiveRowIndex, (int)COL_PURCHASE_LIST.STATUS_DESC].Value);
                frm.model.ReqQty = Convert.ToString(spdPurchase.Sheets[0].Cells[spdPurchase.ActiveSheet.ActiveRowIndex, (int)COL_PURCHASE_LIST.DELIVERY_QTY].Value);

                MenuInfoTag menuInfo = new MenuInfoTag();
                menuInfo.c_func_type = 'F';
                menuInfo.s_assembly_file = "SOI.ATP.dll";
                menuInfo.s_assembly_name = "SOI.ATP.frmATPReceiptInformation";
                menuInfo.s_func_desc = "Receipt Information";
                menuInfo.s_func_name = "";
                MPGV.gIMdiForm.OpenMenu(menuInfo, frm);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Open Reject Form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReject_Click(object sender, EventArgs e)
        {
            try
            {
                // Validation
                if (spdPurchase.ActiveSheet.ActiveRowIndex < 0)
                {
                    return;
                }

                frmATPRejectReceipt frm = new frmATPRejectReceipt();
                frm.model.DeliveryNote = Convert.ToString(spdPurchase.Sheets[0].Cells[spdPurchase.ActiveSheet.ActiveRowIndex, (int)COL_PURCHASE_LIST.DELIVERY_NOTE].Value);
                frm.model.DeliveryDate = Convert.ToString(spdPurchase.Sheets[0].Cells[spdPurchase.ActiveSheet.ActiveRowIndex, (int)COL_PURCHASE_LIST.DELIVERY_DATE].Value);
                frm.model.Vendor = Convert.ToString(spdPurchase.Sheets[0].Cells[spdPurchase.ActiveSheet.ActiveRowIndex, (int)COL_PURCHASE_LIST.VENDOR].Value);
                frm.model.DeliveryStatus = Convert.ToString(spdPurchase.Sheets[0].Cells[spdPurchase.ActiveSheet.ActiveRowIndex, (int)COL_PURCHASE_LIST.STATUS].Value);
                frm.model.DeliveryStatusDesc = Convert.ToString(spdPurchase.Sheets[0].Cells[spdPurchase.ActiveSheet.ActiveRowIndex, (int)COL_PURCHASE_LIST.STATUS_DESC].Value);
                frm.model.ReqQty = Convert.ToString(spdPurchase.Sheets[0].Cells[spdPurchase.ActiveSheet.ActiveRowIndex, (int)COL_PURCHASE_LIST.DELIVERY_QTY].Value);

                MenuInfoTag menuInfo = new MenuInfoTag();
                menuInfo.c_func_type = 'F';
                menuInfo.s_assembly_file = "SOI.ATP.dll";
                menuInfo.s_assembly_name = "SOI.ATP.frmATPRejectReceipt";
                menuInfo.s_func_desc = "Reject Receipt";
                menuInfo.s_func_name = "";
                MPGV.gIMdiForm.OpenMenu(menuInfo, frm);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Process Batch Reject
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBatchReject_Click(object sender, EventArgs e)
        {
            try
            {
                // Validation
                if (spdPurchase.ActiveSheet.ActiveRowIndex < 0)
                {
                    return;
                }

                // Message
                if (MPCF.ShowMsgBox(MPCF.GetMessage(77), MessageBoxButtons.YesNo, MSG_LEVEL.NONE) == System.Windows.Forms.DialogResult.No)
                {
                    return;
                }

                // Get Delivery Note
                string sDeliveryNote = string.Empty;
                if (spdPurchase.Sheets[0].Cells[spdPurchase.ActiveSheet.ActiveRowIndex, (int)COL_PURCHASE_LIST.DELIVERY_NOTE].Value != null)
                {
                    sDeliveryNote = spdPurchase.Sheets[0].Cells[spdPurchase.ActiveSheet.ActiveRowIndex, (int)COL_PURCHASE_LIST.DELIVERY_NOTE].Value.ToString();
                }

                // Batch Inspect
                if (BatchReject(sDeliveryNote) == false)
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
        /// View Purchase Inspect Information
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                // 필요없어 보임
                //// Validation
                //if (chkArrival.Checked == false
                //    && chkReceipt.Checked == false)
                //{
                //    MPCF.SetFocus(chkArrival);
                //    return;
                //}
                
                // View
                if (ViewPurchaseInspect() == false)
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
        /// View Purchase Inspect
        /// </summary>
        /// <returns></returns>
        private bool ViewPurchaseInspect()
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_PURCHASE_IN");
                TRSNode out_node = new TRSNode("VIEW_PURCHASE_OUT");

                // Call Service
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("FROM_DATE", dtFromDeliveryDate.GetValueAsString(8));
                in_node.AddString("TO_DATE", dtToDeliveryDate.GetValueAsString(8));
                in_node.AddString("PLANT_ID", MPCF.Trim(cdvWorkCenter.Text));
                in_node.AddChar("PO_TYPE", MPCF.ToChar(sPurchaseType));
                in_node.AddString("DLV_NO", MPCF.Trim(txtDelivertyNote.Text));
                in_node.AddString("VENDOR_ID", MPCF.Trim(cdvCustomer.Text));
                in_node.AddChar("ARRIVAL_FLAG", chkArrival.Checked == true ? 'Y' : 'N');
                in_node.AddChar("RECEIPT_FLAG", chkReceipt.Checked == true ? 'Y' : 'N');

                if (MPCF.CallService("ATP", "ATP_VIEW_DELIVERY_MST_LIST", in_node, ref out_node) == false)
                {
                    return false;
                }

                // Spread Clear
                spdPurchase.Sheets[0].Rows.Clear();

                // Bind
                if(out_node.GetList(0) != null)
                {
                    List<TRSNode> outList = out_node.GetList(0);

                    int iRow = 0;

                    for(int i = 0 ; i< outList.Count; i++)
                    {
                        iRow = spdPurchase.Sheets[0].Rows.Count;
                        spdPurchase.Sheets[0].RowCount++;

                        spdPurchase.Sheets[0].Cells[iRow, (int)COL_PURCHASE_LIST.STATUS].Value = outList[i].GetString("DLV_STATUS");
                        spdPurchase.Sheets[0].Cells[iRow, (int)COL_PURCHASE_LIST.STATUS_DESC].Value = outList[i].GetString("DLV_STATUS_DESC");
                        spdPurchase.Sheets[0].Cells[iRow, (int)COL_PURCHASE_LIST.PURCHASE_TYPE].Value = outList[i].GetString("PO_TYPE");
                        spdPurchase.Sheets[0].Cells[iRow, (int)COL_PURCHASE_LIST.PURCHASE_TYPE_DESC].Value = outList[i].GetString("PO_TYPE_DESC");
                        spdPurchase.Sheets[0].Cells[iRow, (int)COL_PURCHASE_LIST.WORK_CENTER].Value = outList[i].GetString("PLANT_ID");
                        spdPurchase.Sheets[0].Cells[iRow, (int)COL_PURCHASE_LIST.VENDOR].Value = outList[i].GetString("VENDOR_ID");
                        spdPurchase.Sheets[0].Cells[iRow, (int)COL_PURCHASE_LIST.DELIVERY_DATE].Value = MPCF.MakeDateFormat(outList[i].GetString("DLV_DATE"), DATE_TIME_FORMAT.DATE);
                        spdPurchase.Sheets[0].Cells[iRow, (int)COL_PURCHASE_LIST.ERP_DELIVERY_NOTE].Value = outList[i].GetString("ERP_DLV_NO");
                        spdPurchase.Sheets[0].Cells[iRow, (int)COL_PURCHASE_LIST.MATERIAL_COUNT].Value = MPCF.MakeNumberFormat(outList[i].GetInt("MAT_COUNT"));
                        spdPurchase.Sheets[0].Cells[iRow, (int)COL_PURCHASE_LIST.DELIVERY_QTY].Value = MPCF.MakeNumberFormat(outList[i].GetDouble("DLV_QTY"));
                        spdPurchase.Sheets[0].Cells[iRow, (int)COL_PURCHASE_LIST.IQC_PASS_QTY].Value = MPCF.MakeNumberFormat(outList[i].GetDouble("IQC_PASS_QTY"));
                        spdPurchase.Sheets[0].Cells[iRow, (int)COL_PURCHASE_LIST.RECEIPT_QTY].Value = MPCF.MakeNumberFormat(outList[i].GetDouble("IN_QTY"));
                        spdPurchase.Sheets[0].Cells[iRow, (int)COL_PURCHASE_LIST.REJECT_QTY].Value = MPCF.MakeNumberFormat(outList[i].GetDouble("RTN_QTY"));
                        spdPurchase.Sheets[0].Cells[iRow, (int)COL_PURCHASE_LIST.REMARKS].Value = outList[i].GetString("DLV_COMMENT");
                        spdPurchase.Sheets[0].Cells[iRow, (int)COL_PURCHASE_LIST.DELIVERY_NOTE].Value = outList[i].GetString("DLV_NO");
                        spdPurchase.Sheets[0].Cells[iRow, (int)COL_PURCHASE_LIST.RECEIPT_STORE].Value = outList[i].GetString("DLV_OPER");
                        //spdPurchase.Sheets[0].Cells[iRow, (int)COL_PURCHASE_LIST.PURCHASE_ORDER_ID].Value = outList[i].GetString("");
                    }
                }

                // Success Message
                MPCF.ShowSuccessMessage(out_node, false);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        /// <summary>
        /// Batch Inspect
        /// </summary>
        /// <returns></returns>
        private bool BatchInspect(string dlvNo, string storeID)
        {
            try
            {
                TRSNode in_node = new TRSNode("BATCH_INSPECT_IN");
                TRSNode out_node = new TRSNode("BATCH_INSPECT_OUT");

                // Call Service
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';                
                in_node.AddChar("ALL_FLAG", 'Y');
                in_node.AddString("DLV_NO", dlvNo);
                in_node.AddString("STORE_ID", storeID);

                if (MPCF.CallService("ATP", "ATP_INSPECT_DELIVERY_LABEL", in_node, ref out_node) == false)
                {
                    return false;
                }

                // Show Success Message
                MPCF.ShowSuccessMessage(out_node, false);

                if (ViewPurchaseInspect() == false)
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
        /// Batch Reject
        /// </summary>
        /// <returns></returns>
        private bool BatchReject(string dlvNo)
        {
            try
            {
                TRSNode in_node = new TRSNode("BATCH_REJECT_IN");
                TRSNode out_node = new TRSNode("BATCH_REJECT_OUT");

                // Call Service
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddChar("ALL_FLAG", 'Y');
                in_node.AddString("DLV_NO", dlvNo);

                if (MPCF.CallService("ATP", "ATP_RETURN_DELIVERY_LABEL", in_node, ref out_node) == false)
                {
                    return false;
                }

                // Show Success Message
                MPCF.ShowSuccessMessage(out_node, false);

                if (ViewPurchaseInspect() == false)
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
