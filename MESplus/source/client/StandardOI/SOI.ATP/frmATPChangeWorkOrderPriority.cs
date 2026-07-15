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
    public partial class frmATPChangeWorkOrderPriority : SOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;
        
        public ChangeWorkOrderPriorityModel model = new ChangeWorkOrderPriorityModel();

        private enum COLS_WORK_ORDER_LIST
        {
            MAT_ID = 0,
            MAT_DESC,
            WORK_ORDER_ID,
            ORDER_QTY,
            ORDER_PRIORITY
        }

        #endregion

        #region Constructor

        public frmATPChangeWorkOrderPriority()
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
            // TEST Data
            dtWorkDate.SetValueAsString(model.WorkDate);
            cdvWorkCenter.Text = model.WorkCenter;
            cdvShop.Text = model.Shop;
            cdvLine.Text = model.LineId;

            // View Work Order Information
            ViewWorkOrderInformation();

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
        /// Plan Start Date Value Changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtPlanStartDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                // View
                if (ViewWorkOrderInformation() == false)
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

                //// Close
                //if (cdvWorkCenter.drResult == System.Windows.Forms.DialogResult.Cancel)
                //{
                //    return;
                //}

                // View
                if (ViewWorkOrderInformation() == false)
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
        /// Shop CodeView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cdvShop_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                // Pre-Search 
                TRSNode in_node = new TRSNode("VIEW_SHOP_IN");
                TRSNode out_node = new TRSNode("VIEW_SHOP_OUT");

                // In Node Setup                
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                //in_node.AddString("TABLE_NAME", "ATP_WORK_CENTER");

                // CodeView Column Header Setup
                string[] header = new string[] { "Shop Code", "Shop Description" };

                // CodeView Display Column Setup
                string[] display = new string[] { "SHOP_CODE", "SHOP_DESC" };

                // Show
                cdvShop.Text = cdvShop.Show(cdvShop, "Shop", "WIP", "WIP_View_Shop_List", in_node, "LIST", display, header, "SHOP_CODE");

                // View
                if (ViewWorkOrderInformation() == false)
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
        /// Line CodeView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cdvLine_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                // In Node Setup
                TRSNode in_node = new TRSNode("VIEW_LINE_LIST");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';

                // CodeView Column Header Setup
                string[] header = new string[] { "Line ID", "Line Description" };

                // CodeView Display Column Setup
                string[] display = new string[] { "LINE_CODE", "LINE_DESC" };

                // Show
                cdvLine.Text = cdvLine.Show(cdvLine, "Line", "WIP", "WIP_View_Line_List", in_node, "List", display, header, "LINE_CODE");

                // View
                if (ViewWorkOrderInformation() == false)
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
        /// Refresh Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                // View
                if (ViewWorkOrderInformation() == false)
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
        /// Up Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUp_Click(object sender, EventArgs e)
        {
            try
            {
                // 데이터가 존재하는 경우
                if (spdWorkOrder.Sheets[0].Rows.Count > 0)
                {
                    // Over 0 Row
                    if (spdWorkOrder.ActiveSheet.ActiveRowIndex > 0)
                    {
                        int iCurrRow = spdWorkOrder.ActiveSheet.ActiveRowIndex;
                        spdWorkOrder.Sheets[0].Rows.Add(iCurrRow, 1);
                        spdWorkOrder.Sheets[0].CopyRange(iCurrRow + 1, 0 , iCurrRow, 0, 1, spdWorkOrder.Sheets[0].Columns.Count, false);
                        spdWorkOrder.Sheets[0].CopyRange(iCurrRow - 1, 0, iCurrRow + 1, 0, 1, spdWorkOrder.Sheets[0].Columns.Count, false);
                        spdWorkOrder.Sheets[0].Rows[iCurrRow-1].Remove();

                        spdWorkOrder.ActiveSheet.ActiveRowIndex = iCurrRow - 1;
                    }
                    else
                    {
                        // Nothing
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Down Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDown_Click(object sender, EventArgs e)
        {
            try
            {
                // 데이터가 존재하는 경우
                if (spdWorkOrder.Sheets[0].Rows.Count > 0)
                {
                    // Over 0 Row
                    if (spdWorkOrder.ActiveSheet.ActiveRowIndex < spdWorkOrder.Sheets[0].RowCount - 1)
                    {
                        int iCurrRow = spdWorkOrder.ActiveSheet.ActiveRowIndex;
                        spdWorkOrder.Sheets[0].Rows.Add(iCurrRow + 1, 1);
                        spdWorkOrder.Sheets[0].CopyRange(iCurrRow, 0, iCurrRow + 1, 0, 1, spdWorkOrder.Sheets[0].Columns.Count, false);
                        spdWorkOrder.Sheets[0].CopyRange(iCurrRow + 2, 0, iCurrRow, 0, 1, spdWorkOrder.Sheets[0].Columns.Count, false);
                        spdWorkOrder.Sheets[0].Rows[iCurrRow + 2].Remove();

                        spdWorkOrder.ActiveSheet.ActiveRowIndex = iCurrRow + 1;
                    }
                    else
                    {
                        // Nothing
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Process Change Work Order Priority
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                // Validation
                if (spdWorkOrder.Sheets[0].Rows.Count < 1)
                {
                    return;
                }

                // Process
                if (ChangeWorkOrderPriority() == false)
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
        /// Work Order Information을 조회
        /// </summary>
        /// <returns></returns>
        private bool ViewWorkOrderInformation()
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_WORK_ORDER_INFO_IN");
                TRSNode out_node = new TRSNode("VIEW_WORK_ORDER_INFO_OUT");

                // Call Service
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("FROM_DATE", dtWorkDate.GetValueAsString(8));
                in_node.AddString("TO_DATE", dtWorkDate.GetValueAsString(8));
                in_node.AddString("WORK_CENTER", cdvWorkCenter.Text);
                in_node.AddString("SHOP_CODE", cdvShop.Text);
                in_node.AddString("LINE_CODE", cdvLine.Text);

                if (MPCF.CallService("ATP", "ATP_VIEW_WORKORDER_LIST", in_node, ref out_node) == false)
                {
                    return false;
                }

                // Spread Clear
                spdWorkOrder.Sheets[0].Rows.Clear();

                // Bind
                if (out_node.GetList(0) != null)
                {
                    int iRow = 0;

                    for (int i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        iRow = spdWorkOrder.Sheets[0].Rows.Count;
                        spdWorkOrder.Sheets[0].RowCount++;

                        spdWorkOrder.Sheets[0].Cells[iRow, (int)COLS_WORK_ORDER_LIST.MAT_ID].Value = out_node.GetList(0)[i].GetString("MAT_ID");
                        spdWorkOrder.Sheets[0].Cells[iRow, (int)COLS_WORK_ORDER_LIST.MAT_DESC].Value = out_node.GetList(0)[i].GetString("MAT_DESC");
                        spdWorkOrder.Sheets[0].Cells[iRow, (int)COLS_WORK_ORDER_LIST.WORK_ORDER_ID].Value = out_node.GetList(0)[i].GetString("ORDER_ID");
                        spdWorkOrder.Sheets[0].Cells[iRow, (int)COLS_WORK_ORDER_LIST.ORDER_QTY].Value = MPCF.MakeNumberFormat(out_node.GetList(0)[i].GetDouble("ORD_QTY"));
                        spdWorkOrder.Sheets[0].Cells[iRow, (int)COLS_WORK_ORDER_LIST.ORDER_PRIORITY].Value = out_node.GetList(0)[i].GetInt("PRIORITY");
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
        /// Change Work Order Priority
        /// </summary>
        /// <returns></returns>
        private bool ChangeWorkOrderPriority()
        {
            try
            {
                TRSNode in_node = new TRSNode("CHANGE_PRIORITY_IN");
                TRSNode out_node = new TRSNode("CHANGE_PRIORITY_OUT");
                TRSNode workOrderList;

                // Call Service
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';

                for (int i = 0; i < spdWorkOrder.Sheets[0].Rows.Count; i++)
                {
                    workOrderList = in_node.AddNode("ORDER_LIST");

                    workOrderList.AddString("ORDER_ID", spdWorkOrder.Sheets[0].Cells[i, (int)COLS_WORK_ORDER_LIST.WORK_ORDER_ID].Value.ToString());
                }

                if (MPCF.CallService("ATP", "ATP_Change_Workorder_Priority", in_node, ref out_node) == false)
                {
                    return false;
                }

                // Show Success Message
                MPCF.ShowSuccessMessage(out_node, false);

                if (ViewWorkOrderInformation() == false)
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

    public class ChangeWorkOrderPriorityModel
    {
        private string workDate;
        public string WorkDate
        {
            get { return workDate; }
            set { workDate = value; }
        }

        private string workCenter;
        public string WorkCenter
        {
            get { return workCenter; }
            set { workCenter = value; }
        }

        private string shop;
        public string Shop
        {
            get { return shop; }
            set { shop = value; }
        }

        private string lineId;
        public string LineId
        {
            get { return lineId; }
            set { lineId = value; }
        }
    }
}
