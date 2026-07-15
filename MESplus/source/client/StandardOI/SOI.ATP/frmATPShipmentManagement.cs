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
    public partial class frmATPShipmentManagement : SOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;

        private enum COL_SHIPMENT_LIST
        {
            SHIPMENT_TYPE = 0,
            SHIPMENT_TYPE_DESC,
            CUSTOMER_ID,
            CUSTOMER_DESC,
            SHIPMENT_DATE,
            SHIPMENT_ORD_ID,
            REMARK,
            STATUS,
            STATUS_DESC,
            ERP_SHIPMENT_ORD_ID,
            INVOICE_NO,
            CAR_NO
        }

        #endregion

        #region Constructor

        public frmATPShipmentManagement()
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
            DateTime dtNow = DateTime.Now;
            dtFromDate.SetValueAsDateTime(dtNow);
            //dtNow = dtNow.AddDays(7);
            dtToDate.SetValueAsDateTime(dtNow);

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

        ///// <summary>
        ///// Work Center CodeView
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void cdvWorkCenter_CodeViewButtonClick(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        // Pre-Search 
        //        TRSNode in_node = new TRSNode("VIEW_WORK_CENTER_IN");
        //        TRSNode out_node = new TRSNode("VIEW_WORK_CENTER_OUT");

        //        // In Node Setup                
        //        MPCF.SetInMsg(in_node);
        //        in_node.ProcStep = '1';
        //        in_node.AddString("TABLE_NAME", "ATP_WORK_CENTER");

        //        // CodeView Column Header Setup
        //        string[] header = new string[] { "Work Center", "Work Center Description" };

        //        // CodeView Display Column Setup
        //        string[] display = new string[] { "KEY_1", "DATA_1" };

        //        // Show
        //        cdvWorkCenter.Text = cdvWorkCenter.Show(cdvWorkCenter, "Work Center", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "KEY_1");
        //    }
        //    catch (Exception ex)
        //    {
        //        MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
        //    }
        //}

        /// <summary>
        /// Shipment Type CodeView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cdvShipmentType_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                // Pre-Search 
                TRSNode in_node = new TRSNode("VIEW_SHIP_TYPE_IN");
                TRSNode out_node = new TRSNode("VIEW_SHIP_TYPE_OUT");

                // In Node Setup                
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", "ATP_SHIP_TYPE");

                // CodeView Column Header Setup
                string[] header = new string[] { "Shipment Type", "Shipment Type Description" };

                // CodeView Display Column Setup
                string[] display = new string[] { "KEY_1", "DATA_1" };

                // Show
                cdvShipmentType.Text = cdvShipmentType.Show(cdvShipmentType, "Shipment Type", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "KEY_1");
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
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Shipment Order ID Enter Key
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtShipmentOrderID_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    // Validation
                    if (MPCF.CheckValue(txtShipmentOrderID, false) == false)
                    {
                        return;
                    }

                    // View
                    if (ViewShipment() == false)
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
        /// View Shipment 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                // View
                if (ViewShipment() == false)
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
        /// Open Shipment 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnShipment_Click(object sender, EventArgs e)
        {
            try
            {
                // Validation
                if (spdShipment.Sheets[0].Rows.Count < 1)
                {
                    return;
                }
                if (spdShipment.ActiveSheet.ActiveRowIndex < 0)
                {
                    spdShipment.ActiveSheet.ActiveRowIndex = 0;
                }

                if (Convert.ToString(spdShipment.Sheets[0].Cells[spdShipment.ActiveSheet.ActiveRowIndex, (int)COL_SHIPMENT_LIST.STATUS].Value) != "A")
                {
                    return;
                }

                frmATPShipment frm = new frmATPShipment();
                frm.model.ShipmentOrderID = Convert.ToString(spdShipment.Sheets[0].Cells[spdShipment.ActiveSheet.ActiveRowIndex, (int)COL_SHIPMENT_LIST.SHIPMENT_ORD_ID].Value);
                frm.model.ShipmentDate = MPCF.DestroyDateFormat(Convert.ToString(spdShipment.Sheets[0].Cells[spdShipment.ActiveSheet.ActiveRowIndex, (int)COL_SHIPMENT_LIST.SHIPMENT_DATE].Value));
                frm.model.CustomerID = Convert.ToString(spdShipment.Sheets[0].Cells[spdShipment.ActiveSheet.ActiveRowIndex, (int)COL_SHIPMENT_LIST.CUSTOMER_ID].Value);
                frm.model.CustomerDesc = Convert.ToString(spdShipment.Sheets[0].Cells[spdShipment.ActiveSheet.ActiveRowIndex, (int)COL_SHIPMENT_LIST.CUSTOMER_DESC].Value);
                frm.model.CarNumber = Convert.ToString(spdShipment.Sheets[0].Cells[spdShipment.ActiveSheet.ActiveRowIndex, (int)COL_SHIPMENT_LIST.CAR_NO].Value);
                frm.model.InvoiceNumber = Convert.ToString(spdShipment.Sheets[0].Cells[spdShipment.ActiveSheet.ActiveRowIndex, (int)COL_SHIPMENT_LIST.INVOICE_NO].Value);

                MenuInfoTag menuInfo = new MenuInfoTag();
                menuInfo.c_func_type = 'F';
                menuInfo.s_assembly_file = "SOI.ATP.dll";
                menuInfo.s_assembly_name = "SOI.ATP.frmATPShipment";
                menuInfo.s_func_desc = "Shipment";
                menuInfo.s_func_name = "";
                MPGV.gIMdiForm.OpenMenu(menuInfo, frm);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        #endregion

        #region Function

        /// <summary>
        /// View Shipment
        /// </summary>
        /// <returns></returns>
        private bool ViewShipment()
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_PURCHASE_IN");
                TRSNode out_node = new TRSNode("VIEW_PURCHASE_OUT");

                // Call Service
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';                
                in_node.AddString("REQ_FROM_DATE", dtFromDate.GetValueAsString(8));
                in_node.AddString("REQ_TO_DATE", dtToDate.GetValueAsString(8));
                in_node.AddString("REQ_TYPE", cdvShipmentType.Text);
                in_node.AddString("CUST_ID", cdvCustomer.Text);
                in_node.AddString("INV_REQ_NO", txtShipmentOrderID.Text);
                in_node.AddChar("CONFIRM_FLAG", chkConfirm.Checked == true ? 'Y' : 'N');
                in_node.AddChar("PROCESS_FLAG", chkProcess.Checked == true ? 'Y' : 'N');
                in_node.AddChar("END_FLAG", chkEnd.Checked == true ? 'Y' : 'N');
                in_node.AddChar("CLOSE_FLAG", chkFinish.Checked == true ? 'Y' : 'N');

                if (MPCF.CallService("ATP", "ATP_VIEW_REQUESTORDER_LIST", in_node, ref out_node) == false)
                {
                    return false;
                }

                // Spread Clear
                spdShipment.Sheets[0].Rows.Clear();

                // Bind
                if (out_node.GetList(0) != null)
                {
                    List<TRSNode> outList = out_node.GetList(0);

                    int iRow = 0;

                    for (int i = 0; i < outList.Count; i++)
                    {
                        iRow = spdShipment.Sheets[0].Rows.Count;
                        spdShipment.Sheets[0].RowCount++;

                        spdShipment.Sheets[0].Cells[iRow, (int)COL_SHIPMENT_LIST.SHIPMENT_TYPE].Value = outList[i].GetString("REQ_TYPE");
                        spdShipment.Sheets[0].Cells[iRow, (int)COL_SHIPMENT_LIST.SHIPMENT_TYPE_DESC].Value = outList[i].GetString("REQ_TYPE_DESC");
                        spdShipment.Sheets[0].Cells[iRow, (int)COL_SHIPMENT_LIST.CUSTOMER_ID].Value = outList[i].GetString("CUST_ID");
                        spdShipment.Sheets[0].Cells[iRow, (int)COL_SHIPMENT_LIST.CUSTOMER_DESC].Value = outList[i].GetString("CUST_DESC");
                        spdShipment.Sheets[0].Cells[iRow, (int)COL_SHIPMENT_LIST.SHIPMENT_DATE].Value = MPCF.MakeDateFormat(outList[i].GetString("REQ_DATE"), DATE_TIME_FORMAT.DATE);
                        spdShipment.Sheets[0].Cells[iRow, (int)COL_SHIPMENT_LIST.SHIPMENT_ORD_ID].Value = outList[i].GetString("INV_REQ_NO");
                        spdShipment.Sheets[0].Cells[iRow, (int)COL_SHIPMENT_LIST.REMARK].Value = outList[i].GetString("REQ_COMMENT");
                        spdShipment.Sheets[0].Cells[iRow, (int)COL_SHIPMENT_LIST.STATUS].Value = outList[i].GetChar("REQ_STATUS");
                        spdShipment.Sheets[0].Cells[iRow, (int)COL_SHIPMENT_LIST.STATUS_DESC].Value = outList[i].GetString("REQ_STATUS_DESC");
                        spdShipment.Sheets[0].Cells[iRow, (int)COL_SHIPMENT_LIST.ERP_SHIPMENT_ORD_ID].Value = outList[i].GetString("ERP_REQ_NO");
                        spdShipment.Sheets[0].Cells[iRow, (int)COL_SHIPMENT_LIST.INVOICE_NO].Value = outList[i].GetString("REQ_CMF_2");
                        spdShipment.Sheets[0].Cells[iRow, (int)COL_SHIPMENT_LIST.CAR_NO].Value = outList[i].GetString("ISS_CAR_NO");
                    }

                    MPCF.FitColumnHeader(spdShipment);
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

        #endregion
    }
}
