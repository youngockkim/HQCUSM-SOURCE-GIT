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

namespace SOI.WIP
{
    // (Required) Inherit Base Form
    // SOIBaseForm02 Common Role    
    // - Convert Theme 
    // - Register Favorite 
    // - Default Bottom Button : Process, Cancel 
    // - (option) Help Information Button
    // - (option for SE) Standard Operation Button
    public partial class frmWIPViewProductivityByPeriod : SOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;

        #endregion

        #region Constructor

        public frmWIPViewProductivityByPeriod()
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
        /// Oper CodeView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cdvOperation_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                // In Node Setup
                TRSNode in_node = new TRSNode("VIEW_OPERATION_LIST_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';

                // Display and Header Text Setup
                string[] display = new string[] { "OPER", "OPER_DESC" };
                string[] header = new string[] { "Oper", "Oper Desc" };

                // Show CodeView and Get Return
                cdvOperation.Text = cdvOperation.Show(cdvOperation, "View Operation List", "WIP", "WIP_View_Operation_List", in_node, "LIST", display, header, "Oper");
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

        /// <summary>
        /// Include Res Id CheckBox 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkIncludeResource_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkIncludeResource.Checked == true)
                {
                    spdData.ActiveSheet.Columns[8].Visible = true;
                }
                else
                {
                    spdData.ActiveSheet.Columns[8].Visible = false;
                }

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
                TRSNode in_node = new TRSNode("VIEW_PRODUCTIVITY_BY_PERIOD_IN");
                TRSNode out_node = new TRSNode("VIEW_PRODUCTIVITY_BY_PERIOD_OUT");

                //  Call Service
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
                    in_node.AddString("LINE_ID", cdvWorkLine.Text);
                }
                if (cdvOperation != null && cdvOperation.Text != "")
                {
                    in_node.AddString("OPER", cdvOperation.Text);
                }
                if (cdvMaterial != null && cdvMaterial.Text != "")
                {
                    in_node.AddString("MAT_ID", cdvMaterial.Text);
                }
                if (chkIncludeResource.Checked == true)
                {
                    in_node.AddChar("RES_FLAG", 'Y');
                }

                if (MPCF.CallService("CRPT", "CRPT_View_Productivity_By_Period", in_node, ref out_node) == false)
                {
                    return false;
                }

                // Clear
                MPCF.ClearList(this.spdData);
                
                // Bind
                spdData.ActiveSheet.RowCount = out_node.GetList(0).Count;
                for (int i = 0; i < out_node.GetList(0).Count; i++)
                {
                    spdData.ActiveSheet.Cells[i, 0].Value = out_node.GetList(0)[i].GetString("WORK_DATE");
                    spdData.ActiveSheet.Cells[i, 1].Value = out_node.GetList(0)[i].GetString("LINE_ID");
                    spdData.ActiveSheet.Cells[i, 2].Value = out_node.GetList(0)[i].GetString("ORDER_ID");
                    spdData.ActiveSheet.Cells[i, 3].Value = out_node.GetList(0)[i].GetString("BOM_KEY");
                    spdData.ActiveSheet.Cells[i, 4].Value = out_node.GetList(0)[i].GetString("OPER");
                    spdData.ActiveSheet.Cells[i, 5].Value = out_node.GetList(0)[i].GetString("OPER_DESC");
                    spdData.ActiveSheet.Cells[i, 6].Value = out_node.GetList(0)[i].GetString("MAT_ID");
                    spdData.ActiveSheet.Cells[i, 7].Value = out_node.GetList(0)[i].GetString("MAT_DESC");
                    spdData.ActiveSheet.Cells[i, 8].Value = MPCF.MakeNumberFormat(out_node.GetList(0)[i].GetInt("PASS_QTY"));
                    spdData.ActiveSheet.Cells[i, 9].Value = MPCF.MakeNumberFormat(out_node.GetList(0)[i].GetInt("LOSS_QTY"));
                    spdData.ActiveSheet.Cells[i, 10].Value = MPCF.MakeNumberFormat(out_node.GetList(0)[i].GetDouble("YIELD"), 2);
                }

                // Fit Column Hedaer
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
