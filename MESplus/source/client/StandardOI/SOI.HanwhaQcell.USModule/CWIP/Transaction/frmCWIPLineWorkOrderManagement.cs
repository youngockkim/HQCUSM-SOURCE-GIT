using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows.Forms;

using Miracom.TRSCore;
using SOI.OIFrx;
using SOI.OIFrx.SOIBaseForm;
using SOI.OIFrx.SOIControls;
using SOI.OIFrx.SOIPopup;
using SOI.OIFrx.SOIModel;
using SOI.CliFrx;
using SOI.WIP;
using Infragistics.Win.UltraWinGrid;

using System.Globalization;

namespace SOI.HanwhaQcell.USModule
{
    // (Required) Inherit Base Form
    // SOIBaseForm02 Common Role    
    // - Convert Theme 
    // - Register Favorite 
    // - Default Bottom Button : Process, Cancel 
    // - (option) Help Information Button
    // - (option for SE) Standard Operation Button
    public partial class frmCWIPLineWorkOrderManagement : SOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;

        #endregion

        #region Constructor

        public frmCWIPLineWorkOrderManagement()
        {
            InitializeComponent();
        }

        #endregion

        #region [Constant Definition]

        public enum ORDER_LIST
        {
            WORK_DATE = 0,
            ORDER_ID,
            ORDER_DESC,
            MAT_ID,
            MAT_DESC,
            BOM_ID,
            ORD_QTY,
            ORD_IN_QTY,
            ORD_OUT_QTY,
            ORD_LOSS_QTY,
            ORD_REWORK_QTY,
            ORDER_STATUS
        }

        public enum BOM_LIST
        {
            SEQ = 0,
            MAT_ID,
            MAT_DESC,
            QTY
        }

        #endregion

        #region [Variable Definition]

        private string gCurrentOrderID = string.Empty;
        private string gSelectedOrderID = string.Empty;

        #endregion

        #region Event Handler

        /// <summary>
        /// (Required) Form Load
        /// - Convert Caption
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmCWIPLineWorkOrderManagement_Load(object sender, EventArgs e)
        {
            // Init
            dtpTo.Value = DateTime.Today;
            dtpFrom.Value = DateTime.Today.AddDays(-7);

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
        /// 

        private void frmCWIPLineWorkOrderManagement_Shown(object sender, EventArgs e)
        {
            if (bIsShown == false)
            {
                MPCF.SetFocus(dtpFrom);

                bIsShown = true;
            }
        }

        private void cdvLineID_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                // Validation
                if (MPCF.CheckValue(cdvArea, false) == false)
                {
                    return;
                }

                TRSNode in_node = new TRSNode("VIEW_GCM_DATA_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_LINE_CODE));
                in_node.AddString("LINE_GROUP", MPCF.Trim(cdvArea.Text));

                string[] header = new string[] { "Line Code", "Description" };
                string[] display = new string[] { "KEY_1", "DATA_1" };

                //cdvLineID.Text = cdvLineID.Show(cdvLineID, "Code List", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "KEY_1");
                cdvLineID.Text = cdvLineID.Show(cdvLineID, "Code List", "CWIP", "CWIP_View_Line_List", in_node, "DATA_LIST", display, header, "KEY_1");

                // Validation
                if (string.IsNullOrEmpty(cdvLineID.Text) == true)
                {
                    return;
                }

                // Display Current Order
                cdvOrderLineID.Text = cdvLineID.Text;
                cdvOrderLineID.Description = cdvLineID.Description;
                ViewCurrentOrder();

                return;

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

        private void cdvArea_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_GCM_DATA_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_AREA));

                string[] header = new string[] { "Line Group", "Description" };
                string[] display = new string[] { "KEY_1", "DATA_1" };

                cdvArea.Text = cdvArea.Show(cdvArea, "Code List", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "KEY_1");

                // Clear Line ID
                MPCF.FieldClear(cdvLineID);

                // Validation
                if (string.IsNullOrEmpty(cdvArea.Text) == true)
                {
                    return;
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void cdvMaterial_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_MATERIAL_LIST_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("MAT_TYPE", MPCF.Trim(HQGC.MATERIAL_TYPE_P)); // Production

                string[] header = new string[] { "Product", "Description" };
                string[] display = new string[] { "MAT_ID", "MAT_DESC" };

                cdvMaterial.Text = cdvMaterial.Show(cdvMaterial, "View Material List", "WIP", "WIP_View_Material_List", in_node, "LIST", display, header, "MAT_ID");

                // Validation
                if (string.IsNullOrEmpty(cdvMaterial.Text) == true)
                {
                    return;
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void cdvOrderLineID_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                // Validation
                if (MPCF.CheckValue(cdvArea, false) == false)
                {
                    return;
                }

                TRSNode in_node = new TRSNode("VIEW_GCM_DATA_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_LINE_CODE));
                in_node.AddString("LINE_GROUP", MPCF.Trim(cdvArea.Text));

                string[] header = new string[] { "Line", "Line Desc", "Current Order" };
                string[] display = new string[] { "KEY_1", "DATA_1", "DATA_3" };

                cdvOrderLineID.Text = cdvOrderLineID.Show(cdvOrderLineID, "Code List", "CWIP", "CWIP_View_Line_List", in_node, "DATA_LIST", display, header, "KEY_1");

                // Validation
                if (string.IsNullOrEmpty(cdvOrderLineID.Text) == true)
                {
                    return;
                }

                // Clear
                MPCF.FieldClear(cdvWorkOrder);
                
                // Set Current Order
                txtCurrentOrder.Text = cdvOrderLineID.returnDatas[2];


            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void cdvWorkOrder_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                // Validation
                if (MPCF.CheckValue(cdvOrderLineID, false) == false)
                {
                    return;
                }

                // CodeView Service
                TRSNode in_node = new TRSNode("View_Order_List_Detail_In");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LINE_ID", cdvOrderLineID.Text);
                //in_node.AddChar("ORD_STATUS_FLAG", 'Y');
                in_node.AddString("MAT_ID", "");

                string[] header = new string[] { "Order ID", "Order Desc" };
                string[] display = new string[] { "ORDER_ID", "ORDER_DESC" };

                cdvWorkOrder.Code = cdvWorkOrder.Show(cdvWorkOrder, "View Production Order List By Line", "CORD", "CORD_View_Order_List_By_Line", in_node, "LIST", display, header, "ORDER_ID");

                // Close
                //if (cdvWorkOrder.drResult == System.Windows.Forms.DialogResult.Cancel)
                //{
                //    return;
                //}


            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnViewWorkOrder_Click(object sender, EventArgs e)
        {
            try
            {
                // Check Value
                gSelectedOrderID = spdOrder.Sheets[0].Cells[spdOrder.Sheets[0].ActiveRowIndex, (int)ORDER_LIST.ORDER_ID].Text;

                if (string.IsNullOrEmpty(gSelectedOrderID))
                {
                    MPCF.ShowMessage(MPCF.GetMessage(504), MSG_LEVEL.ERROR, false);
                    return;
                }

                frmWIPViewWorkOrderPopup f = new frmWIPViewWorkOrderPopup(gSelectedOrderID);
                f.Owner = MPGV.gfrmMDI;
                f.ShowDialog();
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                // Validation
                if (MPCF.CheckValue(cdvArea, false) == false)
                {
                    return;
                }

                if (MPCF.CheckValue(cdvLineID, false) == false)
                {
                    return;
                }

                // Initialize Spread
                MPCF.ClearList(spdOrder);
                MPCF.ClearList(spdBOM);

                // View Order List
                if (ViewWorkOrderList() == false)
                {
                    cdvLineID.Select();
                    MPCF.SetFocus(cdvLineID);
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }

        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                // Change Current Order
                if (ChangeCurrentOrder() == false)
                {
                    return;
                }

                txtCurrentOrder.Text = gCurrentOrderID;

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void spdOrder_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (spdOrder.ActiveSheet.RowCount <= 0 || e.ColumnHeader == true)
                return;

            // View Order BOM List by Order ID
            ViewOrderBOMList(spdOrder.Sheets[0].Cells[e.Row, (int)ORDER_LIST.ORDER_ID].Text);

            // Set Work Order 
            cdvWorkOrder.Text = spdOrder.Sheets[0].Cells[e.Row, (int)ORDER_LIST.ORDER_ID].Text;
            cdvWorkOrder.Description = spdOrder.Sheets[0].Cells[e.Row, (int)ORDER_LIST.ORDER_DESC].Text;
        }

        #endregion


        #region Function
  
        private bool ViewWorkOrderList()
        {
            try
            {
                int i;
                DateTime dtpFromDateTimeOut = new DateTime();
                DateTime dtpToDateTimeOut = new DateTime();

                MPCF.ClearList(spdOrder);

                TRSNode in_node = new TRSNode("VIEW_WORK_ORDER_LIST_IN");
                TRSNode out_node = new TRSNode("VIEW_WORK_ORDER_LIST_OUT");
                TRSNode order_list;

                MPCF.SetInMsg(in_node);

                if (string.IsNullOrEmpty(MPCF.Trim(cdvMaterial.Text)))
                {
                    in_node.ProcStep = '2';
                }
                else
                {
                    in_node.ProcStep = '3';
                }

                in_node.AddString("LINE_ID", MPCF.Trim(cdvLineID.Text));
                in_node.AddString("MAT_ID", MPCF.Trim(cdvMaterial.Text));

                if (dtpFrom.Value != null)
                {
                    bool bTrySuccess = DateTime.TryParse(dtpFrom.Value.ToString(), out dtpFromDateTimeOut);
                    if (bTrySuccess == true)
                    {
                        in_node.AddString("FROM_DATE", dtpFromDateTimeOut.ToString("yyyyMMdd"));
                    }
                }

                if (dtpTo.Value != null)
                {
                    bool bTrySuccess = DateTime.TryParse(dtpTo.Value.ToString(), out dtpToDateTimeOut);
                    if (bTrySuccess == true)
                    {
                        in_node.AddString("TO_DATE", dtpToDateTimeOut.ToString("yyyyMMdd"));
                    }
                }

                if (MPCF.CallService("CORD", "CORD_View_Order_List_By_Line", in_node, ref out_node) == false)
                {
                    return false;
                }

                spdOrder.ActiveSheet.RowCount = 0;

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    order_list = out_node.GetList(0)[i];

                    spdOrder.ActiveSheet.RowCount++;

                    spdOrder.ActiveSheet.Cells[i, (int)ORDER_LIST.WORK_DATE].Value = MPCF.MakeDateFormat(order_list.GetString("WORK_DATE"), DATE_TIME_FORMAT.DATE);
                    spdOrder.ActiveSheet.Cells[i, (int)ORDER_LIST.ORDER_ID].Value = order_list.GetString("ORDER_ID");
                    spdOrder.ActiveSheet.Cells[i, (int)ORDER_LIST.ORDER_DESC].Value = order_list.GetString("ORDER_DESC");
                    spdOrder.ActiveSheet.Cells[i, (int)ORDER_LIST.MAT_ID].Value = order_list.GetString("MAT_ID");
                    spdOrder.ActiveSheet.Cells[i, (int)ORDER_LIST.MAT_DESC].Value = order_list.GetString("MAT_DESC");
                    spdOrder.ActiveSheet.Cells[i, (int)ORDER_LIST.BOM_ID].Value = order_list.GetString("ORD_CMF_7");
                    spdOrder.ActiveSheet.Cells[i, (int)ORDER_LIST.ORD_QTY].Value = order_list.GetDouble("ORD_QTY");
                    spdOrder.ActiveSheet.Cells[i, (int)ORDER_LIST.ORD_IN_QTY].Value = order_list.GetDouble("ORD_IN_QTY");
                    spdOrder.ActiveSheet.Cells[i, (int)ORDER_LIST.ORD_OUT_QTY].Value = order_list.GetDouble("ORD_OUT_QTY");
                    spdOrder.ActiveSheet.Cells[i, (int)ORDER_LIST.ORD_LOSS_QTY].Value = order_list.GetDouble("ORD_LOSS_QTY");
                    spdOrder.ActiveSheet.Cells[i, (int)ORDER_LIST.ORD_REWORK_QTY].Value = order_list.GetDouble("ORD_REWORK_QTY");

                    // Order Status
                    if (order_list.GetChar("ORDER_STATUS_FLAG") == HQGC.WORK_ORDER_STATUS_C)
                    {
                        spdOrder.ActiveSheet.Cells[i, (int)ORDER_LIST.ORDER_STATUS].Value = HQGC.WORK_ORDER_STATUS_DESC_C;
                    }
                    else if (order_list.GetChar("ORDER_STATUS_FLAG") == HQGC.WORK_ORDER_STATUS_D)
                    {
                        spdOrder.ActiveSheet.Cells[i, (int)ORDER_LIST.ORDER_STATUS].Value = HQGC.WORK_ORDER_STATUS_DESC_D;
                    }
                    else if (order_list.GetChar("ORDER_STATUS_FLAG") == HQGC.WORK_ORDER_STATUS_F)
                    {
                        spdOrder.ActiveSheet.Cells[i, (int)ORDER_LIST.ORDER_STATUS].Value = HQGC.WORK_ORDER_STATUS_DESC_F;
                    }
                    else if (order_list.GetChar("ORDER_STATUS_FLAG") == HQGC.WORK_ORDER_STATUS_O)
                    {
                        spdOrder.ActiveSheet.Cells[i, (int)ORDER_LIST.ORDER_STATUS].Value = HQGC.WORK_ORDER_STATUS_DESC_O;
                    }
                    else if (order_list.GetChar("ORDER_STATUS_FLAG") == HQGC.WORK_ORDER_STATUS_S)
                    {
                        spdOrder.ActiveSheet.Cells[i, (int)ORDER_LIST.ORDER_STATUS].Value = HQGC.WORK_ORDER_STATUS_DESC_S;
                    }

                }

                MPCF.FitColumnHeader(spdOrder);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        private bool ViewOrderBOMList(string inOrderID)
        {
            try
            {
                int i;
                MPCF.ClearList(spdBOM);

                TRSNode in_node = new TRSNode("VIEW_ORDER_BOM_LIST_IN");
                TRSNode out_node = new TRSNode("VIEW_ORDER_BOM_LIST_OUT");
                TRSNode bom_list;

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("ORDER_ID", MPCF.Trim(inOrderID));

                if (MPCF.CallService("CWIP", "CWIP_View_Order_BOM_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                spdBOM.ActiveSheet.RowCount = 0;

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    bom_list = out_node.GetList(0)[i];

                    spdBOM.ActiveSheet.RowCount++;

                    spdBOM.ActiveSheet.Cells[i, (int)BOM_LIST.SEQ].Value = bom_list.GetInt("SEQ");
                    spdBOM.ActiveSheet.Cells[i, (int)BOM_LIST.MAT_ID].Value = bom_list.GetString("MAT_ID");
                    spdBOM.ActiveSheet.Cells[i, (int)BOM_LIST.MAT_DESC].Value = bom_list.GetString("MAT_DESC");
                    spdBOM.ActiveSheet.Cells[i, (int)BOM_LIST.QTY].Value = bom_list.GetDouble("QTY");

                }

                MPCF.FitColumnHeader(spdBOM);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        private bool ChangeCurrentOrder()
        {
            TRSNode in_node = new TRSNode("CHANGE_CURRENT_ORDER_IN");
            TRSNode out_node = new TRSNode("CHANGE_CURRENT_ORDER_OUT");

            try
            {
                // Call Service
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LINE_ID", MPCF.Trim(cdvOrderLineID.Text));
                in_node.AddString("ORDER_ID", MPCF.Trim(cdvWorkOrder.Text));

                if (MPCF.CallService("CORD", "CORD_Change_Current_Order", in_node, ref out_node) == false)
                {
                    return false;
                }

                gCurrentOrderID = out_node.GetString("ORDER_ID");

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

        private bool ViewCurrentOrder()
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_GCM_DATA_IN");
                TRSNode out_node = new TRSNode("VIEW_GCM_DATA_OUT");
                TRSNode order_list;

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_LINE_CODE));
                in_node.AddString("KEY_1", MPCF.Trim(cdvLineID.Text));

                if (MPCF.CallService("BAS", "BAS_View_Data_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                order_list = out_node.GetList(0)[0];
                txtCurrentOrder.Text = order_list.GetString("DATA_3");

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
