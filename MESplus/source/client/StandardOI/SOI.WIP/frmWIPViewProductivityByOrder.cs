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

namespace SOI.WIP
{
    // (Required) Inherit Base Form
    // SOIBaseForm02 Common Role    
    // - Convert Theme 
    // - Register Favorite 
    // - Default Bottom Button : Process, Cancel 
    // - (option) Help Information Button
    // - (option for SE) Standard Operation Button
    public partial class frmWIPViewProductivityByOrder : SOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;

        #endregion

        #region Constructor

        public frmWIPViewProductivityByOrder()
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
        private void frmTempSOIBaseForm02_Shown(object sender, EventArgs e)
        {
            // (Required) 
            if (bIsShown == false)
            {
                // (Required) 
                bIsShown = true;
            }
        }

        /// <summary>
        /// Work Line CodeView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cdvWorkLine_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                // In Node Setup
                TRSNode in_node = new TRSNode("VIEW_GCM_DATA_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim("@LINE_CODE"));

                string[] header = new string[] { "Line Code", "Description" };
                string[] display = new string[] { "KEY_1", "DATA_1" };

                cdvWorkLine.Text = cdvWorkLine.Show(cdvWorkLine, "Code List", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "KEY_1");

                // Clear
                MPCF.FieldClear(pnlMiddleMargin, cdvWorkLine);

                // Validation
                if (string.IsNullOrEmpty(cdvWorkLine.Text) == true)
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
        /// Mat ID CodeView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cdvMaterial_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                // In Node Setup
                TRSNode in_node = new TRSNode("VIEW_MATERIAL_LIST_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';

                // Display and Header Text Setup
                string[] display = new string[] { "MAT_ID", "MAT_DESC" };
                string[] header = new string[] { "Mat ID", "Mat Desc" };

                // Show CodeView and Get Return
                cdvMaterial.Text = cdvMaterial.Show(cdvMaterial, "View Material List", "WIP", "WIP_View_Material_List", in_node, "LIST", display, header, "Mat ID");
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Work Order CodeView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cdvWorkOrder_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                // Check Required Value
                if (MPCF.CheckValue(cdvWorkLine, false) == false)
                {
                    return;
                }

                // In Node Setup
                TRSNode in_node = new TRSNode("View_Order_List_Detail_In");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("FROM_DATE", "20010101010101");
                in_node.AddString("TO_DATE", "99910101010101");
                in_node.AddString("WORK_LINE", cdvWorkLine.Text);
                in_node.AddChar("ACTIVE_ORD_FLAG", 'Y');
                in_node.AddString("MAT_ID", "");
                in_node.AddInt("MAT_VER", "");
                in_node.AddString("MAT_TYPE", "");
                in_node.AddString("MAT_GRP", "");

                // Display and Header Text Setup
                string[] display = new string[] { "ORDER_ID", "ORDER_DESC" };
                string[] header = new string[] { "Order ID", "Order Desc" };

                // Show CodeView and Get Return
                cdvWorkOrder.Text = cdvWorkOrder.Show(cdvWorkOrder, "View Work Order", "ORD", "ORD_View_Order_List_Detail", in_node, "ORDER_LIST", display, header, "Order ID");
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Order Status CodeView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cdvOrderStatus_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                // In Node Setup
                TRSNode in_node = new TRSNode("VIEW_DATA_LIST_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim("ORDER_STATUS"));

                // Display and Header Text Setup
                string[] display = new string[] { "KEY_1", "DATA_1" };
                string[] header = new string[] { "Order Status", "Order Desc" };

                // Show CodeView and Get Return
                cdvOrderStatus.Text = cdvOrderStatus.Show(cdvOrderStatus, "View Order Status", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "Order Status");
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
                if (MPCF.ExportToExcel(spdData, this.Text, "", true, true, true, -1, -1) == false)
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
        /// View Button Click Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                if (ViewProductivity() == false)
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
        /// View Productivity
        /// </summary>
        /// <returns></returns>
        private bool ViewProductivity()
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_PRODUCTIVITY_BY_ORDER_IN");
                TRSNode out_node = new TRSNode("VIEW_PRODUCTIVITY_BY_ORDER_OUT");

                ArrayList lisHist = new ArrayList();

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                DateTime dtpDateTimeOut = new DateTime();
                if (dtpFrom.Value != null)
                {
                    bool bTrySuccess = DateTime.TryParse(dtpFrom.Value.ToString(), out dtpDateTimeOut);
                    if (bTrySuccess == true)
                    {
                        in_node.AddString("FROM_TIME", dtpDateTimeOut.ToString("yyyyMMdd"));
                    }
                }
                if (dtpTo.Value != null)
                {
                    bool bTrySuccess = DateTime.TryParse(dtpTo.Value.ToString(), out dtpDateTimeOut);
                    if (bTrySuccess == true)
                    {
                        in_node.AddString("TO_TIME", dtpDateTimeOut.ToString("yyyyMMdd"));
                    }
                }
                if (cdvWorkLine != null && cdvWorkLine.Text != "")
                {
                    in_node.AddString("WORK_LINE", cdvWorkLine.Text);
                }
                if (cdvWorkOrder != null && cdvWorkOrder.Text != "")
                {
                    in_node.AddString("ORDER_ID", cdvWorkOrder.Text);
                }
                if (cdvMaterial != null && cdvMaterial.Text != "")
                {
                    in_node.AddString("MAT_ID", cdvMaterial.Text);
                }
                if (cdvOrderStatus.Text != " ")
                {
                    in_node.AddChar("ORD_STATUS_FLAG", cdvOrderStatus.Text);
                }

                if (MPCF.CallService("CRPT", "CRPT_View_Productivity_By_Order", in_node, ref out_node) == false)
                {
                    return false;
                }

                // Field Clear
                MPCF.ClearList(this.spdData);

                // Data Bind
                spdData.ActiveSheet.RowCount = out_node.GetList(0).Count;

                for (int i = 0; i < out_node.GetList(0).Count; i++)
                {
                    spdData.ActiveSheet.Cells[i, 0].Value = out_node.GetList(0)[i].GetString("WORK_DATE");
                    spdData.ActiveSheet.Cells[i, 1].Value = out_node.GetList(0)[i].GetString("WORK_LINE");
                    spdData.ActiveSheet.Cells[i, 2].Value = out_node.GetList(0)[i].GetString("ORDER_ID");
                    spdData.ActiveSheet.Cells[i, 3].Value = out_node.GetList(0)[i].GetString("BOM_KEY");
                    spdData.ActiveSheet.Cells[i, 4].Value = out_node.GetList(0)[i].GetString("MAT_ID");
                    spdData.ActiveSheet.Cells[i, 5].Value = out_node.GetList(0)[i].GetString("MAT_DESC");
                    spdData.ActiveSheet.Cells[i, 6].Value = out_node.GetList(0)[i].GetString("PLAN_START_TIME");
                    spdData.ActiveSheet.Cells[i, 7].Value = out_node.GetList(0)[i].GetString("PLAN_END_TIME");
                    spdData.ActiveSheet.Cells[i, 8].Value = out_node.GetList(0)[i].GetChar("ORD_STATUS_FLAG");
                    spdData.ActiveSheet.Cells[i, 9].Value = MPCF.MakeNumberFormat(out_node.GetList(0)[i].GetDouble("ORD_QTY"));
                    spdData.ActiveSheet.Cells[i, 10].Value = MPCF.MakeNumberFormat(out_node.GetList(0)[i].GetInt("IN_QTY"));
                    spdData.ActiveSheet.Cells[i, 11].Value = MPCF.MakeNumberFormat(out_node.GetList(0)[i].GetInt("OUT_QTY"));
                    spdData.ActiveSheet.Cells[i, 12].Value = MPCF.MakeNumberFormat(out_node.GetList(0)[i].GetInt("LOSS_QTY"));
                    spdData.ActiveSheet.Cells[i, 13].Value = MPCF.MakeNumberFormat(out_node.GetList(0)[i].GetInt("REPAIR_QTY"));
                    spdData.ActiveSheet.Cells[i, 14].Value = MPCF.MakeNumberFormat(out_node.GetList(0)[i].GetInt("ACHIEVE"), 2);
                    spdData.ActiveSheet.Cells[i, 15].Value = MPCF.MakeNumberFormat(out_node.GetList(0)[i].GetInt("YIELD"), 2);
                    spdData.ActiveSheet.Cells[i, 16].Value = MPCF.MakeNumberFormat(out_node.GetList(0)[i].GetInt("LOSS_RATE"), 2);
                }

                // Fit Column Header
                MPCF.FitColumnHeader(spdData);

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
