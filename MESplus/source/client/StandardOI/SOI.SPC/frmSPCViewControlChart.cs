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

namespace SOI.SPC
{
    // (Required) Inherit Base Form
    // SOIBaseForm02 Common Role    
    // - Convert Theme 
    // - Register Favorite 
    // - Default Bottom Button : Process, Cancel 
    // - (option) Help Information Button
    // - (option for SE) Standard Operation Button
    public partial class frmSPCViewControlChart : SOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;

        public string _chartID = string.Empty;

        int giPrecision = 4;
        private const int MAT_ID_COL = 0;
        private const int MAT_VER_COL = 1;
        private const int FLOW_COL = 2;
        private const int OPER_COL = 3;
        private const int RES_COL = 4;
        private const int CHAR_COL = 5;
        private const int LOT_OR_RES_COL = 6;
        private const int USE_UNIT_COL = 7;
        private const int UNIT_COUNT_COL = 8;
        private const int SAMPLE_SIZE_COL = 9;
        private const int USL_COL = 10;
        private const int TARGET_COL = 11;
        private const int LSL_COL = 12;
        private const int UCL_COL = 13;
        private const int CL_COL = 14;
        private const int LCL_COL = 15;
        private const int UCL2_COL = 16;
        private const int CL2_COL = 17;
        private const int LCL2_COL = 18;

        private const int LOTID_COL = 5;
        private const int MATID_COL = 6;
        private const int MATDESC_COL = 7;
        private const int MATVER_COL = 8;
        private const int FLOW = 9;
        private const int OPER = 10;
        private const int PROCOPER_COL = 11;
        private const int RESID_COL = 12;
        private const int SUBRES_COL = 13;
        private const int PROCRES_COL = 14;
        private const int EVENT_COL = 15;

        private const int VALUE_START_COL = 19;
        private const int VALUE_END_COL = 1018;
        private const int WEIGHT_COL = 1019;
        private const int AVERAGE_COL = 1020;
        private const int SIGMA_COL = 1021;
        private const int RANGE_COL = 1022;
        private const int MAX_COL = 1023;
        private const int MIN_COL = 1024;
        private const int RAW_COL_UCL2 = 1031;
        private const int RAW_COL_OOC_TYPE_2 = 1035;
        public const double DOUBLE_NULL_DATA = 1.79769e+308;
        //public const double DOUBLE_NULL_DATA = 0.000;
        public const int INTEGER_NULL_DATA = 2147483647;
        //public const int INTEGER_NULL_DATA = 0;
        public const int VALUE_COUNT = 1000;

        #endregion

        #region Constructor

        public frmSPCViewControlChart()
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
            //MPGV.gIBaseFormEvent.Form_Load(this, e);
            
            //MPCF.FieldClear(this, cdvChartID);

            // DateTime 초기화
            dtpFrom.Value = DateTime.Now.AddMonths(-1);
            dtpTo.Value = DateTime.Now;
            
            //modSPCFunctions.SetGraphList(cboGraphType);
            InitChart();

            //pnlFillRight.Visible = chkViewChartOptions.Checked;
            //cdvChartID.Text = modSPCFunctions.GetFilterKey();

            //int i;
            //for (i = 0; i <= VALUE_COUNT - 1; i++)
            //{
            //    spdDataInfo.Sheets[0].ColumnHeader.Cells[1, VALUE_START_COL + i].Value = i + 1;
            //}

            //Chart.ContextMenu.MenuItems[1].Enabled = modSPCFunctions.CheckAvailableFunction("SPC5001");
            //Chart.ContextMenu.MenuItems[0].Enabled = modSPCFunctions.CheckAvailableFunction("SPC4003");

            chkViewAZone.Checked = chkViewBZone.Checked = chkViewCZone.Checked = true;
            chkViewLotID.Checked = chkViewSpecLimit.Checked = chkViewRChart.Checked = true;
            chkViewRuleCheck.Checked = chkViewDate.Checked = true;

            if (_chartID != "")
            {
                cdvChartID.Text = _chartID;
                btnProcess.PerformClick();
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
                if (MPCF.Trim(MPGV.gsChartID) != "")
                {
                    cdvChartID.Text = MPGV.gsChartID;
                    ChartInfo();
                }        

                // (Required) 
                bIsShown = true;
            }
        }

        /// <summary>
        /// Chart ID Code View
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cdvChartID_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                // In Node Setup
                TRSNode in_node = new TRSNode("VIEW_CHART_LIST_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';

                // Display and Header Text Setup
                string[] display = new string[] { "CHART_ID", "CHART_DESC" };
                string[] header = new string[] { "Chart ID", "Chart Desc" };

                // Show CodeView and Get Return
                cdvChartID.Text = cdvChartID.Show(cdvChartID, "SPC", "View Chart List", "SPC_View_Chart_List", in_node, "CHART_LIST", display, header, "Chart ID");
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Chart ID Code View KeyPress
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cdvChartID_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)13)
                {
                    if (cdvChartID.Text != "")
                    {
                        btnProcess.PerformClick();
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// View A Zone CheckBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkViewAZone_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Chart.IsViewAZone = chkViewAZone.Checked;
                Chart.Refresh();
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// View B Zone CheckBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkViewBZone_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Chart.IsViewBZone = chkViewBZone.Checked;
                Chart.Refresh();
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// View C Zone CheckBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkViewCZone_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Chart.IsViewCZone = chkViewCZone.Checked;
                Chart.Refresh();
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Redraw Button Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRedraw_Click(object sender, EventArgs e)
        {
            try
            {
                if (MPCF.CheckNumeric(this.txtMaxLotCount.Text) == false)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(78));
                    this.txtMaxLotCount.SelectAll();
                    this.txtMaxLotCount.Focus();
                    return;
                }
                else
                {
                    if (MPCF.ToInt(this.txtMaxLotCount.Text) <= 0)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(78));
                        this.txtMaxLotCount.SelectAll();
                        this.txtMaxLotCount.Focus();
                        return;
                    }
                }

                //this.btnReset.Enabled = false;
                Chart.MaxLotCount = MPCF.ToInt(this.txtMaxLotCount.Text);
                Chart.StartLotPos = 0;
                Chart.IsZoomChart = false;
                Chart.Refresh();
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// View X Axis Label CheckBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkViewLotID_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Chart.IsViewLotID = chkViewLotID.Checked;
                Chart.Refresh();
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// View Date CheckBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkViewDate_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Chart.IsViewDate = chkViewDate.Checked;
                Chart.Refresh();
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);                     
            }
        }

        /// <summary>
        /// View Spec Limit CheckBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkViewSpecLimit_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Chart.IsViewSpecLimit = chkViewSpecLimit.Checked;
                Chart.Refresh();
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// View Rule Check CheckBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkViewRuleCheck_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Chart.IsViewRunTestText = chkViewRuleCheck.Checked;
                Chart.Refresh();
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// View R Chart CheckBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkViewRChart_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Chart.IsViewRChart = chkViewRChart.Checked;
                Chart.Refresh();
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Auto Cal Control Limit CheckBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkAutoCalControlLimit_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Chart.IsUserInputCL = !(chkAutoCalControlLimit.Checked);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Chart Event - Mouse Button Down
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Chart_MouseButtonDown(object sender, SPCControlChart.MouseButtonDown_EventArgs e)
        {
            try
            {
                string sFromTime;
                string sToTime;
                char c_step;
                //sFromTime = ((DateTime)(dtpFrom.Value)).ToString("yyyyMMdd") + ((DateTime)(dtpFrom.Value)).ToString("HHmmss");
                //sToTime = ((DateTime)(dtpTo.Value)).ToString("yyyyMMdd") + ((DateTime)(dtpTo.Value)).ToString("HHmmss");
                sFromTime = ((DateTime)(dtpFrom.Value)).ToString("yyyyMMdd") + "000000";
                sToTime = ((DateTime)(dtpTo.Value)).ToString("yyyyMMdd") + "235959";

                if (e.UnitSeq == 0)
                {
                    c_step = '2';
                }
                else
                {
                    c_step = '3';
                }

                if (e.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    if (MPCF.ViewSPCEDCData(spdDataInfo, c_step, cdvChartID.Text, sFromTime, sToTime, giPrecision, AVERAGE_COL, MPCF.ToInt(this.spdChartInfo.Sheets[0].Cells[UNIT_COUNT_COL, 1].Text), MPCF.ToChar(this.spdChartInfo.Sheets[0].Cells[USE_UNIT_COL, 1].Text), "N", e.HistSeq, e.UnitSeq, false, ' ') == false)
                    {
                        return;
                    }
                }

                if (this.spdChartInfo.Sheets[0].Cells[LOT_OR_RES_COL, 1].Text == "L")
                {
                    spdDataInfo.Sheets[0].Columns[LOTID_COL].Visible = true;
                    spdDataInfo.Sheets[0].Columns[MATID_COL].Visible = true;
                    spdDataInfo.Sheets[0].Columns[MATDESC_COL].Visible = true;
                    spdDataInfo.Sheets[0].Columns[MATVER_COL].Visible = true;
                    spdDataInfo.Sheets[0].Columns[FLOW].Visible = true;
                    spdDataInfo.Sheets[0].Columns[OPER].Visible = true;
                    spdDataInfo.Sheets[0].Columns[PROCOPER_COL].Visible = true;
                    spdDataInfo.Sheets[0].Columns[PROCRES_COL].Visible = true;
                    spdDataInfo.Sheets[0].Columns[SUBRES_COL].Visible = false;
                    spdDataInfo.Sheets[0].Columns[EVENT_COL].Visible = false;
                }
                else if (this.spdChartInfo.Sheets[0].Cells[LOT_OR_RES_COL, 1].Text == "R")
                {
                    spdDataInfo.Sheets[0].Columns[LOTID_COL].Visible = false;
                    spdDataInfo.Sheets[0].Columns[MATID_COL].Visible = false;
                    spdDataInfo.Sheets[0].Columns[MATDESC_COL].Visible = false;
                    spdDataInfo.Sheets[0].Columns[MATVER_COL].Visible = false;
                    spdDataInfo.Sheets[0].Columns[FLOW].Visible = false;
                    spdDataInfo.Sheets[0].Columns[OPER].Visible = false;
                    spdDataInfo.Sheets[0].Columns[PROCOPER_COL].Visible = false;
                    spdDataInfo.Sheets[0].Columns[PROCRES_COL].Visible = false;
                    spdDataInfo.Sheets[0].Columns[SUBRES_COL].Visible = true;
                    spdDataInfo.Sheets[0].Columns[EVENT_COL].Visible = true;
                }

                if (Chart.ChartType == SPCControlChart.modEnums.GRAPH_TYPE.P 
                    || Chart.ChartType == SPCControlChart.modEnums.GRAPH_TYPE.PN 
                    || Chart.ChartType == SPCControlChart.modEnums.GRAPH_TYPE.C 
                    || Chart.ChartType == SPCControlChart.modEnums.GRAPH_TYPE.U)
                {
                    int i;
                    int iCol;
                    double dUCL;
                    double dCL;
                    double dLCL;
                    if (e.UnitSeq == 0)
                    {
                        for (i = 0; i <= spdDataInfo.Sheets[0].RowCount - 1; i++)
                        {
                            dUCL = e.UCL;
                            if (dUCL != DOUBLE_NULL_DATA)
                            {
                                iCol = MPCF.GetSpreadCol(spdDataInfo, "UCL", 0);
                                if (iCol != -1)
                                {
                                    spdDataInfo.Sheets[0].SetValue(i, MPCF.GetSpreadCol(spdDataInfo, "UCL", 0), MPCF.SetPrecision(dUCL.ToString(), giPrecision));
                                }
                            }
                            dCL = e.CL;
                            if (dCL != DOUBLE_NULL_DATA)
                            {
                                iCol = MPCF.GetSpreadCol(spdDataInfo, "CL", 0);
                                if (iCol != -1)
                                {
                                    spdDataInfo.Sheets[0].SetValue(i, MPCF.GetSpreadCol(spdDataInfo, "CL", 0), MPCF.SetPrecision(dCL.ToString(), giPrecision));
                                }
                            }
                            dLCL = e.LCL;
                            if (dLCL != DOUBLE_NULL_DATA)
                            {
                                iCol = MPCF.GetSpreadCol(spdDataInfo, "LCL", 0);
                                if (iCol != -1)
                                {
                                    spdDataInfo.Sheets[0].SetValue(i, MPCF.GetSpreadCol(spdDataInfo, "LCL", 0), MPCF.SetPrecision(dLCL.ToString(), giPrecision));
                                }
                            }
                        }
                    }
                    else
                    {
                        dUCL = e.UCL;
                        if (dUCL != DOUBLE_NULL_DATA)
                        {
                            iCol = MPCF.GetSpreadCol(spdDataInfo, "UCL", 0);
                            if (iCol != -1)
                            {
                                spdDataInfo.Sheets[0].SetValue(0, MPCF.GetSpreadCol(spdDataInfo, "UCL", 0), MPCF.SetPrecision(dUCL.ToString(), giPrecision));
                            }
                        }
                        dCL = e.CL;
                        if (dCL != DOUBLE_NULL_DATA)
                        {
                            iCol = MPCF.GetSpreadCol(spdDataInfo, "CL", 0);
                            if (iCol != -1)
                            {
                                spdDataInfo.Sheets[0].SetValue(0, MPCF.GetSpreadCol(spdDataInfo, "CL", 0), MPCF.SetPrecision(dCL.ToString(), giPrecision));
                            }
                        }
                        dLCL = e.LCL;
                        if (dLCL != DOUBLE_NULL_DATA)
                        {
                            iCol = MPCF.GetSpreadCol(spdDataInfo, "LCL", 0);
                            if (iCol != -1)
                            {
                                spdDataInfo.Sheets[0].SetValue(0, MPCF.GetSpreadCol(spdDataInfo, "LCL", 0), MPCF.SetPrecision(dLCL.ToString(), giPrecision));
                            }
                        }
                    }
                }

                MPCF.FitColumnHeader(spdDataInfo);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// View Button Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                if (ChartIDSelected() == false)
                {
                    return;
                }

                // Fit Column Header
                MPCF.FitColumnHeader(spdChartInfo);

                // Clear Data Info
                MPCF.ClearList(spdDataInfo, true);

                // View Control Chart
                if (View_ControlChart() == false)
                {
                    InitChart();
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
        /// Initialize Chart Options
        /// </summary>
        public void InitChart()
        {
            try
            {
                Chart.InitDataSet();

                Chart.IsViewRChart = this.chkViewRChart.Checked;
                Chart.IsViewLotID = this.chkViewLotID.Checked;
                Chart.IsViewDate = this.chkViewDate.Checked;
                Chart.IsViewSpecLimit = this.chkViewSpecLimit.Checked;
                Chart.IsViewXUCL = true;
                Chart.IsViewXCL = true;
                Chart.IsViewXLCL = true;
                Chart.IsViewRUCL = true;
                Chart.IsViewRCL = true;
                Chart.IsViewRLCL = true;
                Chart.IsViewRunTestText = this.chkViewRuleCheck.Checked;
                Chart.IsViewAZone = this.chkViewAZone.Checked;
                Chart.IsViewBZone = this.chkViewBZone.Checked;
                Chart.IsViewCZone = this.chkViewCZone.Checked;
                Chart.IsUserInputCL = !(this.chkAutoCalControlLimit.Checked);
                Chart.IsTimeBasedChart = this.chkBasedOnTime.Checked;

                if (MPCF.CheckNumeric(this.txtMaxLotCount.Text) == false)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(78));
                    this.txtMaxLotCount.SelectAll();
                    this.txtMaxLotCount.Focus();
                    return;
                }
                else
                {
                    if (MPCF.ToInt(this.txtMaxLotCount.Text) <= 0)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(78));
                        this.txtMaxLotCount.SelectAll();
                        this.txtMaxLotCount.Focus();
                        return;
                    }
                }

                Chart.Precision = giPrecision;
                Chart.MaxLotCount = MPCF.ToInt(this.txtMaxLotCount.Text);
                Chart.ChartType = SPCControlChart.modEnums.GRAPH_TYPE.NONE;
                Chart.Refresh();
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Information of Chart is reshown
        /// </summary>
        private void ChartInfo()
        {
            try
            {
                btnProcess.PerformClick();
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Action after Char ID Selected
        /// </summary>
        /// <returns></returns>
        public bool ChartIDSelected()
        {
            try
            {
                int iVer = 0;

                InitChart();

                ClearChartInfo();

                MPCF.ClearList(spdDataInfo, true);

                if (cdvChartID.Text == "")
                {
                    return false;
                }

                if (View_Chart() == false)
                {
                    return false;
                }

                if (SetChartOptions() == false)
                {
                    return false;
                }

                if (MPCF.Find_Spec_Version('1', cdvChartID.Text, ref iVer, true) == true)
                {
                    if (View_Spec(iVer) == false)
                    {
                        return false;
                    }
                }

                Set_Data();

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }
                
        /// <summary>
        /// View Chart 
        /// </summary>
        /// <returns></returns>
        private bool View_Chart()
        {
            try
            {
                TRSNode in_node = new TRSNode("View_Chart_In");
                TRSNode out_node = new TRSNode("View_Chart_Out");

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("CHART_ID", cdvChartID.Text);

                if (MPCF.CallService("SPC", "SPC_View_Chart", in_node, ref out_node) == false)
                {
                    return false;
                }

                if (MPCF.Trim(out_node.GetString("GRAPH_TYPE")) == "")
                {
                    cboGraphType.SelectedIndex = -1;
                }
                else
                {
                    cboGraphType.SelectedIndex = (int)Enum.Parse(typeof(eGraphType), MPCF.Trim(out_node.GetString("GRAPH_TYPE")));
                }

                spdChartInfo.Sheets[0].SetValue(MAT_ID_COL, 1, MPCF.Trim(out_node.GetString("MAT_ID")));
                spdChartInfo.Sheets[0].SetValue(MAT_VER_COL, 1, MPCF.Trim(out_node.GetInt("MAT_VER")));
                spdChartInfo.Sheets[0].SetValue(FLOW_COL, 1, MPCF.Trim(out_node.GetString("FLOW")));
                spdChartInfo.Sheets[0].SetValue(OPER_COL, 1, MPCF.Trim(out_node.GetString("OPER")));
                spdChartInfo.Sheets[0].SetValue(RES_COL, 1, MPCF.Trim(out_node.GetString("RES_ID")));
                spdChartInfo.Sheets[0].SetValue(CHAR_COL, 1, MPCF.Trim(out_node.GetString("CHAR_ID")));
                spdChartInfo.Sheets[0].SetValue(LOT_OR_RES_COL, 1, MPCF.Trim(out_node.GetChar("LOT_RES_FLAG")));
                spdChartInfo.Sheets[0].SetValue(USE_UNIT_COL, 1, MPCF.Trim(out_node.GetChar("UNIT_USE_FLAG")));
                spdChartInfo.Sheets[0].SetValue(UNIT_COUNT_COL, 1, MPCF.Trim(out_node.GetInt("UNIT_COUNT")));
                spdChartInfo.Sheets[0].SetValue(SAMPLE_SIZE_COL, 1, MPCF.Trim(out_node.GetInt("SAMPLE_SIZE")));

                giPrecision = out_node.GetInt("PRECISION_LIMIT");

                Chart.XRuleType = MPCF.Trim(out_node.GetString("X_RULE_CHECK_TBL"));
                Chart.RRuleType = MPCF.Trim(out_node.GetString("R_RULE_CHECK_TBL"));

                //cdvChartID.DescText = MPCF.Trim(out_node.GetString("CHART_DESC"));

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        /// <summary>
        /// View Spec
        /// </summary>
        /// <param name="iVer"></param>
        /// <returns></returns>
        private bool View_Spec(int iVer)
        {
            try
            {
                TRSNode in_node = new TRSNode("View_Spec_In");
                TRSNode out_node = new TRSNode("View_Spec_Out");

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("CHART_ID", cdvChartID.Text);
                in_node.AddInt("VERSION", iVer);

                if (MPCF.CallService("SPC", "SPC_View_Spec", in_node, ref out_node, true) == false)
                {
                    return false;
                }

                spdChartInfo.Sheets[0].SetValue(USL_COL, 1, MPCF.SetPrecision(MPCF.Trim(out_node.GetString("USL")), giPrecision));
                spdChartInfo.Sheets[0].SetValue(TARGET_COL, 1, MPCF.SetPrecision(MPCF.Trim(out_node.GetString("TARGET")), giPrecision));
                spdChartInfo.Sheets[0].SetValue(LSL_COL, 1, MPCF.SetPrecision(MPCF.Trim(out_node.GetString("LSL")), giPrecision));
                spdChartInfo.Sheets[0].SetValue(UCL_COL, 1, MPCF.SetPrecision(MPCF.Trim(out_node.GetString("UCL")), giPrecision));
                spdChartInfo.Sheets[0].SetValue(CL_COL, 1, MPCF.SetPrecision(MPCF.Trim(out_node.GetString("CL")), giPrecision));
                spdChartInfo.Sheets[0].SetValue(LCL_COL, 1, MPCF.SetPrecision(MPCF.Trim(out_node.GetString("LCL")), giPrecision));
                spdChartInfo.Sheets[0].SetValue(UCL2_COL, 1, MPCF.SetPrecision(MPCF.Trim(out_node.GetString("UCL2")), giPrecision));
                spdChartInfo.Sheets[0].SetValue(CL2_COL, 1, MPCF.SetPrecision(MPCF.Trim(out_node.GetString("CL2")), giPrecision));
                spdChartInfo.Sheets[0].SetValue(LCL2_COL, 1, MPCF.SetPrecision(MPCF.Trim(out_node.GetString("LCL2")), giPrecision));

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        /// <summary>
        /// Clear spdChartInfo
        /// </summary>
        public void ClearChartInfo()
        {
            try
            {
                for (int i = 0; i <= spdChartInfo.Sheets[0].RowCount - 1; i++)
                {
                    spdChartInfo.Sheets[0].SetValue(i, 1, "");
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Set Chart Options
        /// </summary>
        /// <returns></returns>
        public bool SetChartOptions()
        {
            try
            {
                switch (this.cboGraphType.SelectedIndex)
                {
                    case (int)SPCControlChart.modEnums.GRAPH_TYPE.XBARR:
                        this.chkViewRChart.Checked = true;
                        this.chkViewRChart.Visible = true;
                        this.chkViewSpecLimit.Enabled = true;
                        this.chkViewSpecLimit.Checked = true;
                        break;
                    case (int)SPCControlChart.modEnums.GRAPH_TYPE.XBARS:
                        this.chkViewRChart.Checked = true;
                        this.chkViewRChart.Visible = true;
                        this.chkViewSpecLimit.Enabled = true;
                        this.chkViewSpecLimit.Checked = true;
                        break;
                    case (int)SPCControlChart.modEnums.GRAPH_TYPE.XRS:
                        this.chkViewRChart.Checked = true;
                        this.chkViewRChart.Visible = true;
                        this.chkViewSpecLimit.Enabled = true;
                        this.chkViewSpecLimit.Checked = true;
                        break;
                    case (int)SPCControlChart.modEnums.GRAPH_TYPE.P:
                        this.chkViewRChart.Checked = false;
                        this.chkViewRChart.Visible = false;
                        this.chkViewSpecLimit.Enabled = true;
                        this.chkViewSpecLimit.Checked = true;
                        break;
                    case (int)SPCControlChart.modEnums.GRAPH_TYPE.PN:
                        this.chkViewRChart.Checked = false;
                        this.chkViewRChart.Visible = false;
                        this.chkViewSpecLimit.Enabled = true;
                        this.chkViewSpecLimit.Checked = true;
                        break;
                    case (int)SPCControlChart.modEnums.GRAPH_TYPE.C:
                        this.chkViewRChart.Checked = false;
                        this.chkViewRChart.Visible = false;
                        this.chkViewSpecLimit.Enabled = true;
                        this.chkViewSpecLimit.Checked = true;
                        break;
                    case (int)SPCControlChart.modEnums.GRAPH_TYPE.U:
                        this.chkViewRChart.Checked = false;
                        this.chkViewRChart.Visible = false;
                        this.chkViewSpecLimit.Enabled = true;
                        this.chkViewSpecLimit.Checked = true;
                        break;
                    case (int)SPCControlChart.modEnums.GRAPH_TYPE.ZBARS:
                        this.chkViewRChart.Checked = true;
                        this.chkViewRChart.Visible = true;
                        this.chkViewSpecLimit.Enabled = true;
                        this.chkViewSpecLimit.Checked = true;
                        break;
                    case (int)SPCControlChart.modEnums.GRAPH_TYPE.DELTAS:
                        this.chkViewRChart.Checked = true;
                        this.chkViewRChart.Visible = true;
                        this.chkViewSpecLimit.Enabled = false;
                        this.chkViewSpecLimit.Checked = false;
                        break;
                    default:
                        this.chkViewRChart.Checked = true;
                        this.chkViewRChart.Visible = true;
                        this.chkViewSpecLimit.Enabled = true;
                        this.chkViewSpecLimit.Checked = true;
                        break;
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
        /// Set Data by graph type
        /// </summary>
        private void Set_Data()
        {
            try
            {
                SetDatabyGraphType(spdDataInfo, (eGraphType)this.cboGraphType.SelectedIndex,
                                                   MPCF.ToInt(this.spdChartInfo.Sheets[0].Cells[SAMPLE_SIZE_COL, 1].Text),
                                                   VALUE_START_COL, AVERAGE_COL);

                SetValuePrompt(spdDataInfo, cdvChartID.Text, MPCF.ToInt(this.spdChartInfo.Sheets[0].Cells[SAMPLE_SIZE_COL, 1].Text), VALUE_START_COL);

                if (this.cboGraphType.SelectedIndex == MPCF.ToInt(eGraphType.XBARR) ||
                    this.cboGraphType.SelectedIndex == MPCF.ToInt(eGraphType.XBARS) ||
                    this.cboGraphType.SelectedIndex == MPCF.ToInt(eGraphType.XRS) ||
                    cboGraphType.SelectedIndex == MPCF.ToInt(eGraphType.ZBARS) ||
                    this.cboGraphType.SelectedIndex == MPCF.ToInt(eGraphType.DELTAS))
                {
                    spdDataInfo.Sheets[0].Columns[RAW_COL_UCL2].Visible = true;
                    spdDataInfo.Sheets[0].Columns[RAW_COL_UCL2 + 1].Visible = true;
                    spdDataInfo.Sheets[0].Columns[RAW_COL_UCL2 + 2].Visible = true;
                    spdDataInfo.Sheets[0].Columns[RAW_COL_OOC_TYPE_2].Visible = true;
                }
                else
                {
                    spdDataInfo.Sheets[0].Columns[RAW_COL_UCL2].Visible = false;
                    spdDataInfo.Sheets[0].Columns[RAW_COL_UCL2 + 1].Visible = false;
                    spdDataInfo.Sheets[0].Columns[RAW_COL_UCL2 + 2].Visible = false;
                    spdDataInfo.Sheets[0].Columns[RAW_COL_OOC_TYPE_2].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Set Data by graph type
        /// </summary>
        /// <param name="spddata"></param>
        /// <param name="eType"></param>
        /// <param name="iSampleSize"></param>
        /// <param name="iValueCol1"></param>
        /// <param name="iAverageCol"></param>
        public static void SetDatabyGraphType(FarPoint.Win.Spread.FpSpread spddata, eGraphType eType, int iSampleSize, int iValueCol1, int iAverageCol)
        {
            try
            {
                int i;
                switch (eType)
                {
                    case eGraphType.XBARR:

                        spddata.Sheets[0].Columns[iValueCol1].Width = 60;
                        spddata.Sheets[0].Columns[iValueCol1 + 1].Width = 60;

                        for (i = iValueCol1; i <= iValueCol1 + VALUE_COUNT - 1; i++)
                        {
                            spddata.Sheets[0].Columns[i].Visible = true;
                            MPCF.SetNumberCell(spddata.Sheets[0].Columns[i]);
                        }

                        for (i = iValueCol1 + iSampleSize; i <= iValueCol1 + VALUE_COUNT - 1; i++)
                        {
                            spddata.Sheets[0].Columns[i].Visible = false;
                        }

                        for (i = 0; i <= iSampleSize - 1; i++)
                        {
                            spddata.Sheets[0].ColumnHeader.Cells[1, iValueCol1 + i].Value = i + 1;
                        }

                        spddata.Sheets[0].Columns[iValueCol1 - 1].Visible = false;
                        spddata.Sheets[0].Columns[iValueCol1 - 2].Visible = false;
                        spddata.Sheets[0].ColumnHeader.Cells[0, iValueCol1].Value = MPCF.FindLanguage("Value");

                        /*
                        if (iSampleSize == 1)
                        {
                            spddata.Sheets[0].ColumnHeader.Cells[0, iValueCol1].Value = "       " + MPCF.FindLanguage("Value", 0);
                        }
                        else
                        {
                            spddata.Sheets[0].ColumnHeader.Cells[0, iValueCol1].Value = "       " + MPCF.FindLanguage("Value", 0) + "(1 ~ " + iSampleSize.ToString() + ")";
                        }
                         */

                        spddata.Sheets[0].Columns[iAverageCol - 1].Visible = false;
                        spddata.Sheets[0].ColumnHeader.Cells[0, iAverageCol].Value = MPCF.FindLanguage("Average");
                        spddata.Sheets[0].Columns[iAverageCol].Visible = true;
                        spddata.Sheets[0].Columns[iAverageCol + 1].Visible = true;
                        spddata.Sheets[0].Columns[iAverageCol + 2].Visible = true;
                        spddata.Sheets[0].Columns[iAverageCol + 3].Visible = true;
                        spddata.Sheets[0].Columns[iAverageCol + 4].Visible = true;
                        break;

                    case eGraphType.XBARS:

                        spddata.Sheets[0].Columns[iValueCol1].Width = 60;
                        spddata.Sheets[0].Columns[iValueCol1 + 1].Width = 60;

                        for (i = iValueCol1; i <= iValueCol1 + VALUE_COUNT - 1; i++)
                        {
                            spddata.Sheets[0].Columns[i].Visible = true;
                            MPCF.SetNumberCell(spddata.Sheets[0].Columns[i]);
                        }

                        for (i = iValueCol1 + iSampleSize; i <= iValueCol1 + VALUE_COUNT - 1; i++)
                        {
                            spddata.Sheets[0].Columns[i].Visible = false;
                        }

                        for (i = 0; i <= iSampleSize - 1; i++)
                        {
                            spddata.Sheets[0].ColumnHeader.Cells[1, iValueCol1 + i].Value = i + 1;
                        }

                        spddata.Sheets[0].Columns[iValueCol1 - 1].Visible = false;
                        spddata.Sheets[0].Columns[iValueCol1 - 2].Visible = false;
                        spddata.Sheets[0].ColumnHeader.Cells[0, iValueCol1].Value = MPCF.FindLanguage("Value");

                        /*
                        if (iSampleSize == 1)
                        {
                            spddata.Sheets[0].ColumnHeader.Cells[0, iValueCol1].Value = "       " + MPCF.FindLanguage("Value", 0);
                        }
                        else
                        {
                            spddata.Sheets[0].ColumnHeader.Cells[0, iValueCol1].Value = "       " + MPCF.FindLanguage("Value", 0) + "(1 ~ " + iSampleSize.ToString() + ")";
                        }
                         */

                        spddata.Sheets[0].Columns[iAverageCol - 1].Visible = false;
                        spddata.Sheets[0].ColumnHeader.Cells[0, iAverageCol].Value = MPCF.FindLanguage("Average");
                        spddata.Sheets[0].Columns[iAverageCol].Visible = true;
                        spddata.Sheets[0].Columns[iAverageCol + 1].Visible = true;
                        spddata.Sheets[0].Columns[iAverageCol + 2].Visible = true;
                        spddata.Sheets[0].Columns[iAverageCol + 3].Visible = true;
                        spddata.Sheets[0].Columns[iAverageCol + 4].Visible = true;
                        break;

                    case eGraphType.XRS:

                        spddata.Sheets[0].Columns[iValueCol1].Width = 60;
                        spddata.Sheets[0].Columns[iValueCol1 + 1].Width = 60;

                        for (i = iValueCol1; i <= iValueCol1 + VALUE_COUNT - 1; i++)
                        {
                            spddata.Sheets[0].Columns[i].Visible = true;
                            MPCF.SetNumberCell(spddata.Sheets[0].Columns[i]);
                        }

                        for (i = iValueCol1 + iSampleSize; i <= iValueCol1 + VALUE_COUNT - 1; i++)
                        {
                            spddata.Sheets[0].Columns[i].Visible = false;
                        }

                        for (i = 0; i <= iSampleSize - 1; i++)
                        {
                            spddata.Sheets[0].ColumnHeader.Cells[1, iValueCol1 + i].Value = i + 1;
                        }

                        spddata.Sheets[0].Columns[iValueCol1 - 1].Visible = false;
                        spddata.Sheets[0].Columns[iValueCol1 - 2].Visible = false;
                        spddata.Sheets[0].ColumnHeader.Cells[0, iValueCol1].Value = "   " + MPCF.FindLanguage("Value");
                        spddata.Sheets[0].Columns[iAverageCol - 1].Visible = false;
                        spddata.Sheets[0].ColumnHeader.Cells[0, iAverageCol].Value = MPCF.FindLanguage("Average");
                        spddata.Sheets[0].Columns[iAverageCol].Visible = true;
                        spddata.Sheets[0].Columns[iAverageCol + 1].Visible = false;
                        spddata.Sheets[0].Columns[iAverageCol + 2].Visible = true;
                        spddata.Sheets[0].Columns[iAverageCol + 3].Visible = false;
                        spddata.Sheets[0].Columns[iAverageCol + 4].Visible = false;
                        break;

                    case eGraphType.P:

                        spddata.Sheets[0].ColumnHeader.Cells[1, iValueCol1].Value = MPCF.FindLanguage("Sample Size") + " (n)";
                        spddata.Sheets[0].ColumnHeader.Cells[1, iValueCol1 + 1].Value = MPCF.FindLanguage("Defect Count") + " (Pn)";
                        spddata.Sheets[0].Columns[iValueCol1].Width = 100;
                        spddata.Sheets[0].Columns[iValueCol1 + 1].Width = 100;

                        for (i = iValueCol1; i <= iValueCol1 + VALUE_COUNT - 1; i++)
                        {
                            spddata.Sheets[0].Columns[i].Visible = true;
                            MPCF.SetNumberCell(spddata.Sheets[0].Columns[i]);
                        }

                        for (i = iValueCol1 + 2; i <= iValueCol1 + VALUE_COUNT - 1; i++)
                        {
                            spddata.Sheets[0].Columns[i].Visible = false;
                        }

                        spddata.Sheets[0].Columns[iValueCol1 - 1].Visible = false;
                        spddata.Sheets[0].Columns[iValueCol1 - 2].Visible = false;
                        spddata.Sheets[0].ColumnHeader.Cells[0, iValueCol1].Value = MPCF.FindLanguage("Value");
                        /*
                        spddata.Sheets[0].ColumnHeader.Cells[0, iValueCol1].Value = "       " + MPCF.FindLanguage("Value", 0);
                         */
                        spddata.Sheets[0].Columns[iAverageCol - 1].Visible = false;
                        spddata.Sheets[0].ColumnHeader.Cells[0, iAverageCol].Value = "P";
                        spddata.Sheets[0].Columns[iAverageCol].Visible = true;
                        spddata.Sheets[0].Columns[iAverageCol + 1].Visible = false;
                        spddata.Sheets[0].Columns[iAverageCol + 2].Visible = false;
                        spddata.Sheets[0].Columns[iAverageCol + 3].Visible = false;
                        spddata.Sheets[0].Columns[iAverageCol + 4].Visible = false;
                        break;

                    case eGraphType.PN:

                        spddata.Sheets[0].ColumnHeader.Cells[1, iValueCol1].Value = MPCF.FindLanguage("Defect Count") + " (Pn)";
                        spddata.Sheets[0].Columns[iValueCol1].Width = 100;

                        MPCF.SetNumberCell(spddata.Sheets[0].Columns[iValueCol1]);

                        for (i = iValueCol1 + 1; i <= iValueCol1 + VALUE_COUNT - 1; i++)
                        {
                            spddata.Sheets[0].Columns[i].Visible = false;
                        }

                        spddata.Sheets[0].Columns[iValueCol1 - 1].Visible = false;
                        spddata.Sheets[0].Columns[iValueCol1 - 2].Visible = false;
                        spddata.Sheets[0].ColumnHeader.Cells[0, iValueCol1].Value = MPCF.FindLanguage("Value");
                        /*
                        spddata.Sheets[0].ColumnHeader.Cells[0, iValueCol1].Value = "       " + MPCF.FindLanguage("Value", 0);
                         */
                        spddata.Sheets[0].Columns[iAverageCol - 1].Visible = false;
                        spddata.Sheets[0].ColumnHeader.Cells[0, iAverageCol].Value = "Pn";
                        spddata.Sheets[0].Columns[iAverageCol].Visible = true;
                        spddata.Sheets[0].Columns[iAverageCol + 1].Visible = false;
                        spddata.Sheets[0].Columns[iAverageCol + 2].Visible = false;
                        spddata.Sheets[0].Columns[iAverageCol + 3].Visible = false;
                        spddata.Sheets[0].Columns[iAverageCol + 4].Visible = false;
                        break;

                    case eGraphType.C:

                        spddata.Sheets[0].ColumnHeader.Cells[1, iValueCol1].Value = MPCF.FindLanguage("Defect Count") + " (C)";
                        spddata.Sheets[0].Columns[iValueCol1].Width = 100;

                        MPCF.SetNumberCell(spddata.Sheets[0].Columns[iValueCol1]);

                        for (i = iValueCol1 + 1; i <= iValueCol1 + VALUE_COUNT - 1; i++)
                        {
                            spddata.Sheets[0].Columns[i].Visible = false;
                        }

                        spddata.Sheets[0].Columns[iValueCol1 - 1].Visible = false;
                        spddata.Sheets[0].Columns[iValueCol1 - 2].Visible = false;
                        spddata.Sheets[0].ColumnHeader.Cells[0, iValueCol1].Value = MPCF.FindLanguage("Value");
                        /*
                        spddata.Sheets[0].ColumnHeader.Cells[0, iValueCol1].Value = "       " + MPCF.FindLanguage("Value", 0);
                         */
                        spddata.Sheets[0].Columns[iAverageCol - 1].Visible = false;
                        spddata.Sheets[0].ColumnHeader.Cells[0, iAverageCol].Value = "C";
                        spddata.Sheets[0].Columns[iAverageCol].Visible = true;
                        spddata.Sheets[0].Columns[iAverageCol + 1].Visible = false;
                        spddata.Sheets[0].Columns[iAverageCol + 2].Visible = false;
                        spddata.Sheets[0].Columns[iAverageCol + 3].Visible = false;
                        spddata.Sheets[0].Columns[iAverageCol + 4].Visible = false;
                        break;

                    case eGraphType.U:

                        spddata.Sheets[0].ColumnHeader.Cells[1, iValueCol1].Value = MPCF.FindLanguage("Sample Size") + " (n)";
                        spddata.Sheets[0].ColumnHeader.Cells[1, iValueCol1 + 1].Value = MPCF.FindLanguage("Defect Count") + " (C)";
                        spddata.Sheets[0].Columns[iValueCol1].Width = 100;
                        spddata.Sheets[0].Columns[iValueCol1 + 1].Width = 100;

                        MPCF.SetNumberCell(spddata.Sheets[0].Columns[iValueCol1]);
                        MPCF.SetNumberCell(spddata.Sheets[0].Columns[iValueCol1 + 1]);

                        for (i = iValueCol1; i <= iValueCol1 + VALUE_COUNT - 1; i++)
                        {
                            spddata.Sheets[0].Columns[i].Visible = true;
                        }

                        for (i = iValueCol1 + 2; i <= iValueCol1 + VALUE_COUNT - 1; i++)
                        {
                            spddata.Sheets[0].Columns[i].Visible = false;
                        }

                        spddata.Sheets[0].Columns[iValueCol1 - 1].Visible = false;
                        spddata.Sheets[0].Columns[iValueCol1 - 2].Visible = false;
                        spddata.Sheets[0].ColumnHeader.Cells[0, iValueCol1].Value = MPCF.FindLanguage("Value");
                        /*
                        spddata.Sheets[0].ColumnHeader.Cells[0, iValueCol1].Value = "       " + MPCF.FindLanguage("Value", 0);
                         */
                        spddata.Sheets[0].Columns[iAverageCol - 1].Visible = false;
                        spddata.Sheets[0].ColumnHeader.Cells[0, iAverageCol].Value = "U";
                        spddata.Sheets[0].Columns[iAverageCol].Visible = true;
                        spddata.Sheets[0].Columns[iAverageCol + 1].Visible = false;
                        spddata.Sheets[0].Columns[iAverageCol + 2].Visible = false;
                        spddata.Sheets[0].Columns[iAverageCol + 3].Visible = false;
                        spddata.Sheets[0].Columns[iAverageCol + 4].Visible = false;
                        break;

                    case eGraphType.ZBARS:

                        spddata.Sheets[0].Columns[iValueCol1].Width = 60;
                        spddata.Sheets[0].Columns[iValueCol1 + 1].Width = 60;

                        for (i = iValueCol1; i <= iValueCol1 + VALUE_COUNT - 1; i++)
                        {
                            spddata.Sheets[0].Columns[i].Visible = true;
                            MPCF.SetNumberCell(spddata.Sheets[0].Columns[i]);
                        }

                        for (i = iValueCol1 + iSampleSize; i <= iValueCol1 + VALUE_COUNT - 1; i++)
                        {
                            spddata.Sheets[0].Columns[i].Visible = false;
                        }

                        for (i = 0; i <= iSampleSize - 1; i++)
                        {
                            spddata.Sheets[0].ColumnHeader.Cells[1, iValueCol1 + i].Value = i + 1;
                        }

                        spddata.Sheets[0].Columns[iValueCol1 - 1].Visible = true;
                        spddata.Sheets[0].Columns[iValueCol1 - 2].Visible = true;
                        MPCF.SetNumberCell(spddata.Sheets[0].Columns[iValueCol1 - 1]);
                        MPCF.SetNumberCell(spddata.Sheets[0].Columns[iValueCol1 - 2]);
                        spddata.Sheets[0].ColumnHeader.Cells[0, iValueCol1].Value = MPCF.FindLanguage("Value");
                        /*
                        if (iSampleSize == 1)
                        {
                            spddata.Sheets[0].ColumnHeader.Cells[0, iValueCol1].Value = "       " + MPCF.FindLanguage("Value", 0);
                        }
                        else
                        {
                            spddata.Sheets[0].ColumnHeader.Cells[0, iValueCol1].Value = "       " + MPCF.FindLanguage("Value", 0) + "(1 ~ " + iSampleSize.ToString() + ")";
                        }
                         */
                        spddata.Sheets[0].Columns[iAverageCol - 1].Visible = true;
                        spddata.Sheets[0].ColumnHeader.Cells[0, iAverageCol].Value = MPCF.FindLanguage("Average");
                        spddata.Sheets[0].ColumnHeader.Cells[0, iAverageCol - 1].Value = MPCF.FindLanguage("Zbar");
                        spddata.Sheets[0].Columns[iAverageCol].Visible = true;
                        spddata.Sheets[0].Columns[iAverageCol + 1].Visible = true;
                        spddata.Sheets[0].Columns[iAverageCol + 2].Visible = true;
                        spddata.Sheets[0].Columns[iAverageCol + 3].Visible = true;
                        spddata.Sheets[0].Columns[iAverageCol + 4].Visible = true;
                        break;

                    case eGraphType.DELTAS:

                        spddata.Sheets[0].Columns[iValueCol1].Width = 60;
                        spddata.Sheets[0].Columns[iValueCol1 + 1].Width = 60;

                        for (i = iValueCol1; i <= iValueCol1 + VALUE_COUNT - 1; i++)
                        {
                            spddata.Sheets[0].Columns[i].Visible = true;
                            MPCF.SetNumberCell(spddata.Sheets[0].Columns[i]);
                        }

                        for (i = iValueCol1 + iSampleSize; i <= iValueCol1 + VALUE_COUNT - 1; i++)
                        {
                            spddata.Sheets[0].Columns[i].Visible = false;
                        }

                        for (i = 0; i <= iSampleSize - 1; i++)
                        {
                            spddata.Sheets[0].ColumnHeader.Cells[1, iValueCol1 + i].Value = i + 1;
                        }

                        spddata.Sheets[0].Columns[iValueCol1 - 1].Visible = false;
                        spddata.Sheets[0].Columns[iValueCol1 - 2].Visible = true;
                        MPCF.SetNumberCell(spddata.Sheets[0].Columns[iValueCol1 - 2]);
                        spddata.Sheets[0].ColumnHeader.Cells[0, iValueCol1].Value = MPCF.FindLanguage("Value");
                        /*
                        if (iSampleSize == 1)
                        {
                            spddata.Sheets[0].ColumnHeader.Cells[0, iValueCol1].Value = "       " + MPCF.FindLanguage("Value", 0);
                        }
                        else
                        {
                            spddata.Sheets[0].ColumnHeader.Cells[0, iValueCol1].Value = "       " + MPCF.FindLanguage("Value", 0) + "(1 ~ " + iSampleSize.ToString() + ")";
                        }
                         */
                        spddata.Sheets[0].Columns[iAverageCol - 1].Visible = true;
                        spddata.Sheets[0].ColumnHeader.Cells[0, iAverageCol].Value = MPCF.FindLanguage("Average");
                        spddata.Sheets[0].ColumnHeader.Cells[0, iAverageCol - 1].Value = MPCF.FindLanguage("Delta");
                        spddata.Sheets[0].Columns[iAverageCol].Visible = true;
                        spddata.Sheets[0].Columns[iAverageCol + 1].Visible = true;
                        spddata.Sheets[0].Columns[iAverageCol + 2].Visible = true;
                        spddata.Sheets[0].Columns[iAverageCol + 3].Visible = true;
                        spddata.Sheets[0].Columns[iAverageCol + 4].Visible = true;
                        break;

                    case eGraphType.NULL:

                        spddata.Sheets[0].Columns[iValueCol1].Width = 60;
                        spddata.Sheets[0].Columns[iValueCol1 + 1].Width = 60;

                        for (i = iValueCol1; i <= iValueCol1 + VALUE_COUNT - 1; i++)
                        {
                            spddata.Sheets[0].Columns[i].Visible = true;
                            MPCF.SetAsciiCell(spddata.Sheets[0].Columns[i]);
                        }

                        for (i = iValueCol1 + iSampleSize; i <= iValueCol1 + VALUE_COUNT - 1; i++)
                        {
                            spddata.Sheets[0].Columns[i].Visible = false;
                        }

                        for (i = 0; i <= iSampleSize - 1; i++)
                        {
                            spddata.Sheets[0].ColumnHeader.Cells[1, iValueCol1 + i].Value = i + 1;
                        }

                        spddata.Sheets[0].Columns[iValueCol1 - 1].Visible = false;
                        spddata.Sheets[0].Columns[iValueCol1 - 2].Visible = false;
                        spddata.Sheets[0].ColumnHeader.Cells[0, iValueCol1].Value = MPCF.FindLanguage("Value");
                        /*
                        if (iSampleSize == 1)
                        {
                            spddata.Sheets[0].ColumnHeader.Cells[0, iValueCol1].Value = "       " + MPCF.FindLanguage("Value", 0);
                        }
                        else
                        {
                            spddata.Sheets[0].ColumnHeader.Cells[0, iValueCol1].Value = "       " + MPCF.FindLanguage("Value", 0) + "(1 ~ " + iSampleSize.ToString() + ")";
                        }
                         */
                        spddata.Sheets[0].Columns[iAverageCol - 1].Visible = false;
                        spddata.Sheets[0].ColumnHeader.Cells[0, iAverageCol].Value = MPCF.FindLanguage("Average");
                        spddata.Sheets[0].Columns[iAverageCol].Visible = false;
                        spddata.Sheets[0].Columns[iAverageCol + 1].Visible = false;
                        spddata.Sheets[0].Columns[iAverageCol + 2].Visible = false;
                        spddata.Sheets[0].Columns[iAverageCol + 3].Visible = false;
                        spddata.Sheets[0].Columns[iAverageCol + 4].Visible = false;
                        break;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Set the prompt of value
        /// </summary>
        /// <param name="spddata"></param>
        /// <param name="sChartID"></param>
        /// <param name="iSampleSize"></param>
        /// <param name="iValueCol1"></param>
        public static void SetValuePrompt(FarPoint.Win.Spread.FpSpread spddata, string sChartID, int iSampleSize, int iValueCol1)
        {
            try
            {
                TRSNode in_node = new TRSNode("View_Prompt_In");
                TRSNode out_node = new TRSNode("View_Prompt_Out");

                int i = 0;

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("CHART_ID", MPCF.Trim(sChartID));

                if (MPCF.CallService("SPC", "SPC_View_Prompt", in_node, ref out_node, true) == false)
                {
                    return;
                }

                if (out_node.GetList("PRT_LIST").Count > 0)
                {
                    for (i = 0; i <= iSampleSize - 1; i++)
                    {
                        spddata.Sheets[0].ColumnHeader.Cells[1, iValueCol1 + i].Value = out_node.GetList("PRT_LIST")[i].GetString("PROMPT");
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Set Chart Title
        /// </summary>
        /// <returns></returns>
        public bool SetChartTitle()
        {
            try
            {
                switch (Chart.ChartType)
                {
                    case SPCControlChart.modEnums.GRAPH_TYPE.XBARR:

                        Chart.MainTitle = this.cdvChartID.Text + " : ";
                        Chart.SubTitle = "XBAR-CHART";
                        Chart.BottomTitle = "R-CHART";
                        Chart.UnitTitle = "";
                        break;

                    case SPCControlChart.modEnums.GRAPH_TYPE.XBARS:

                        Chart.MainTitle = this.cdvChartID.Text + " : ";
                        Chart.SubTitle = "XBAR-CHART";
                        Chart.BottomTitle = "S-CHART";
                        Chart.UnitTitle = "";
                        break;

                    case SPCControlChart.modEnums.GRAPH_TYPE.XRS:

                        Chart.MainTitle = this.cdvChartID.Text + " : ";
                        Chart.SubTitle = "X-CHART";
                        Chart.BottomTitle = "R-CHART";
                        Chart.UnitTitle = "";
                        break;

                    case SPCControlChart.modEnums.GRAPH_TYPE.P:

                        Chart.MainTitle = this.cdvChartID.Text + " : ";
                        Chart.SubTitle = "P-CHART";
                        Chart.BottomTitle = "";
                        Chart.UnitTitle = "";
                        break;

                    case SPCControlChart.modEnums.GRAPH_TYPE.PN:

                        Chart.MainTitle = this.cdvChartID.Text + " : ";
                        Chart.SubTitle = "PN-CHART";
                        Chart.BottomTitle = "";
                        Chart.UnitTitle = "";
                        break;

                    case SPCControlChart.modEnums.GRAPH_TYPE.C:

                        Chart.MainTitle = this.cdvChartID.Text + " : ";
                        Chart.SubTitle = "C-CHART";
                        Chart.BottomTitle = "";
                        Chart.UnitTitle = "";
                        break;

                    case SPCControlChart.modEnums.GRAPH_TYPE.U:

                        Chart.MainTitle = this.cdvChartID.Text + " : ";
                        Chart.SubTitle = "U-CHART";
                        Chart.BottomTitle = "";
                        Chart.UnitTitle = "";
                        break;

                    case SPCControlChart.modEnums.GRAPH_TYPE.ZBARS:

                        Chart.MainTitle = this.cdvChartID.Text + " : ";
                        Chart.SubTitle = "ZBAR-CHART";
                        Chart.BottomTitle = "S-CHART";
                        Chart.UnitTitle = "";
                        break;

                    case SPCControlChart.modEnums.GRAPH_TYPE.DELTAS:

                        Chart.MainTitle = this.cdvChartID.Text + " : ";
                        Chart.SubTitle = "DELTA-CHART";
                        Chart.BottomTitle = "S-CHART";
                        Chart.UnitTitle = "";
                        break;

                    default:

                        Chart.MainTitle = "";
                        Chart.SubTitle = "";
                        Chart.BottomTitle = "";
                        Chart.UnitTitle = "";
                        break;
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
        /// Set Chart Title
        /// </summary>
        /// <returns></returns>
        public bool View_ControlChart()
        {
            try
            {
                TRSNode in_node = new TRSNode("View_ControlChart_In");
                TRSNode out_node;
                int i;
                int j;
                int iGroupIndex;
                int iLotIndex;
                string sGroupIndex = string.Empty;
                string sLotIndex;
                double dUSL;
                double dLSL;
                double dUCL;
                double dCL;
                double dLCL;
                double dUCL2;
                double dCL2;
                double dLCL2;
                double dPrevUSL;
                double dPrevLSL;
                double dPrevUCL;
                double dPrevCL;
                double dPrevLCL;
                double dPrevUCL2;
                double dPrevCL2;
                double dPrevLCL2;
                double dValue;
                double dXData;
                double dRdata;
                double dTarget;
                string sTranTime;
                string sXAxis;
                ArrayList a_list = new ArrayList();

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("CHART_ID", cdvChartID.Text);
                in_node.AddString("FROM_TIME", ((DateTime)(dtpFrom.Value)).ToString("yyyyMMdd") + "000000");
                in_node.AddString("TO_TIME", ((DateTime)(dtpTo.Value)).ToString("yyyyMMdd") + "235959");
                in_node.AddInt("NEXT_HIST_SEQ", 0);
                in_node.AddInt("NEXT_UNIT_SEQ", 0);

                InitChart();

                Chart.ChartType = (SPCControlChart.modEnums.GRAPH_TYPE)this.cboGraphType.SelectedIndex;
                Chart.SampleSize = MPCF.ToInt(this.spdChartInfo.Sheets[0].Cells[SAMPLE_SIZE_COL, 1].Text);

                if (SetChartTitle() == false)
                {
                    return false;
                }

                iGroupIndex = -1;
                iLotIndex = 0;

                dPrevUSL = DOUBLE_NULL_DATA;
                dPrevLSL = DOUBLE_NULL_DATA;
                dPrevUCL = DOUBLE_NULL_DATA;
                dPrevCL = DOUBLE_NULL_DATA;
                dPrevLCL = DOUBLE_NULL_DATA;
                dPrevUCL2 = DOUBLE_NULL_DATA;
                dPrevCL2 = DOUBLE_NULL_DATA;
                dPrevLCL2 = DOUBLE_NULL_DATA;

                dUSL = DOUBLE_NULL_DATA;
                dLSL = DOUBLE_NULL_DATA;
                dUCL = DOUBLE_NULL_DATA;
                dCL = DOUBLE_NULL_DATA;
                dLCL = DOUBLE_NULL_DATA;
                dUCL2 = DOUBLE_NULL_DATA;
                dCL2 = DOUBLE_NULL_DATA;
                dLCL2 = DOUBLE_NULL_DATA;
                dTarget = DOUBLE_NULL_DATA;

                if (this.chkAutoCalControlLimit.Checked == true)
                {
                    if (MPCF.Trim(this.spdChartInfo.Sheets[0].Cells[USL_COL, 1].Text) == "")
                    {
                        dUSL = DOUBLE_NULL_DATA;
                    }
                    else
                    {
                        dUSL = MPCF.ToDbl(this.spdChartInfo.Sheets[0].Cells[USL_COL, 1].Text);
                    }
                    if (MPCF.Trim(this.spdChartInfo.Sheets[0].Cells[LSL_COL, 1].Text) == "")
                    {
                        dLSL = DOUBLE_NULL_DATA;
                    }
                    else
                    {
                        dLSL = MPCF.ToDbl(this.spdChartInfo.Sheets[0].Cells[LSL_COL, 1].Text);
                    }
                }

                do
                {
                    out_node = new TRSNode("SPC_View_ControlChart_Out");
                    if (MPCF.CallService("SPC", "SPC_View_ControlChart", in_node, ref out_node) == false)
                    {
                        return false;
                    }
                    a_list.Add(out_node);
                    in_node.SetInt("NEXT_HIST_SEQ", out_node.GetInt("NEXT_HIST_SEQ"));
                    in_node.SetInt("NEXT_UNIT_SEQ", out_node.GetInt("NEXT_UNIT_SEQ"));

                } while (in_node.GetInt("NEXT_HIST_SEQ") > 0 || in_node.GetInt("NEXT_UNIT_SEQ") > 0);
                //If View_ControlChart_Out.count = 0 Then
                //    ShowMsgBox(GetMessage(244))
                //    Return True
                //End If
                foreach (object obj in a_list)
                {
                    out_node = null;
                    out_node = (TRSNode)obj;
                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {

                        if (Chart.IsUserInputCL == true)
                        {
                            if (MPCF.Trim(out_node.GetList(0)[i].GetString("USL")) == "")
                            {
                                dUSL = DOUBLE_NULL_DATA;
                            }
                            else
                            {
                                dUSL = MPCF.ToDbl(out_node.GetList(0)[i].GetString("USL"));
                            }
                            if (MPCF.Trim(out_node.GetList(0)[i].GetString("LSL")) == "")
                            {
                                dLSL = DOUBLE_NULL_DATA;
                            }
                            else
                            {
                                dLSL = MPCF.ToDbl(out_node.GetList(0)[i].GetString("LSL"));
                            }

                            if (MPCF.Trim(out_node.GetList(0)[i].GetString("UCL")) == "")
                            {
                                dUCL = DOUBLE_NULL_DATA;
                            }
                            else
                            {
                                dUCL = MPCF.ToDbl(out_node.GetList(0)[i].GetString("UCL"));
                            }
                            if (MPCF.Trim(out_node.GetList(0)[i].GetString("CL")) == "")
                            {
                                dCL = DOUBLE_NULL_DATA;
                            }
                            else
                            {
                                dCL = MPCF.ToDbl(out_node.GetList(0)[i].GetString("CL"));
                            }
                            if (MPCF.Trim(out_node.GetList(0)[i].GetString("LCL")) == "")
                            {
                                dLCL = DOUBLE_NULL_DATA;
                            }
                            else
                            {
                                dLCL = MPCF.ToDbl(out_node.GetList(0)[i].GetString("LCL"));
                            }
                            if (MPCF.Trim(out_node.GetList(0)[i].GetString("UCL2")) == "")
                            {
                                dUCL2 = DOUBLE_NULL_DATA;
                            }
                            else
                            {
                                dUCL2 = MPCF.ToDbl(out_node.GetList(0)[i].GetString("UCL2"));
                            }
                            if (MPCF.Trim(out_node.GetList(0)[i].GetString("CL2")) == "")
                            {
                                dCL2 = DOUBLE_NULL_DATA;
                            }
                            else
                            {
                                dCL2 = MPCF.ToDbl(out_node.GetList(0)[i].GetString("CL2"));
                            }
                            if (MPCF.Trim(out_node.GetList(0)[i].GetString("UCL2")) == "")
                            {
                                dLCL2 = DOUBLE_NULL_DATA;
                            }
                            else
                            {
                                dLCL2 = MPCF.ToDbl(out_node.GetList(0)[i].GetString("LCL2"));
                            }
                        }

                        if (Chart.IsUserInputCL == false && (Chart.ChartType != SPCControlChart.modEnums.GRAPH_TYPE.P && Chart.ChartType != SPCControlChart.modEnums.GRAPH_TYPE.U))
                        {
                            if (iGroupIndex == -1 || dUSL != dPrevUSL || dLSL != dPrevLSL || dUCL != dPrevUCL || dCL != dPrevCL || dLCL != dPrevLCL || dUCL2 != dPrevUCL2 || dCL2 != dPrevCL2 || dLCL2 != dPrevLCL2)
                            {
                                iGroupIndex++;
                            }
                        }
                        else
                        {
                            iGroupIndex++;
                        }

                        sGroupIndex = "Group" + iGroupIndex.ToString("0000");
                        if (Chart.ChartType != SPCControlChart.modEnums.GRAPH_TYPE.DELTAS)
                        {
                            if (Chart.SetSpecLimit(sGroupIndex, dUSL, dLSL, dTarget) == false)
                            {
                                return false;
                            }
                        }

                        if (Chart.SetXControlLimit(sGroupIndex, dUCL, dCL, dLCL) == false)
                        {
                            return false;
                        }
                        if (Chart.SetRControlLimit(sGroupIndex, dUCL2, dCL2, dLCL2) == false)
                        {
                            return false;
                        }

                        sLotIndex = "Lot" + iLotIndex.ToString("0000");
                        sTranTime = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_TIME"));


                        if (MPCF.Trim(Chart.ResvField1) == "L")
                        {
                            sXAxis = MPCF.Trim(out_node.GetList(0)[i].GetString("LOT_ID"));
                        }
                        else
                        {
                            sXAxis = MPCF.Trim(out_node.GetList(0)[i].GetString("RES_ID"));
                        }

                        switch (Chart.ChartType)
                        {
                            case SPCControlChart.modEnums.GRAPH_TYPE.XBARR:
                                if ((MPCF.CheckNumeric(MPCF.Trim(out_node.GetList(0)[i].GetString("AVERAGE"))) == true ? MPCF.Trim(out_node.GetList(0)[i].GetString("AVERAGE")) : "") == "")
                                {
                                    dXData = DOUBLE_NULL_DATA;
                                }
                                else
                                {
                                    dXData = MPCF.ToDbl(out_node.GetList(0)[i].GetString("AVERAGE"));
                                }

                                if ((MPCF.CheckNumeric(MPCF.Trim(out_node.GetList(0)[i].GetString("RANGE"))) == true ? MPCF.Trim(out_node.GetList(0)[i].GetString("RANGE")) : "") == "")
                                {
                                    dRdata = DOUBLE_NULL_DATA;
                                }
                                else
                                {
                                    dRdata = MPCF.ToDbl(out_node.GetList(0)[i].GetString("RANGE"));
                                }
                                break;
                            case SPCControlChart.modEnums.GRAPH_TYPE.XBARS:

                                if ((MPCF.CheckNumeric(MPCF.Trim(out_node.GetList(0)[i].GetString("AVERAGE"))) == true ? MPCF.Trim(out_node.GetList(0)[i].GetString("AVERAGE")) : "") == "")
                                {
                                    dXData = DOUBLE_NULL_DATA;
                                }
                                else
                                {
                                    dXData = MPCF.ToDbl(out_node.GetList(0)[i].GetString("AVERAGE"));
                                }

                                if ((MPCF.CheckNumeric(MPCF.Trim(out_node.GetList(0)[i].GetString("STDDEV"))) == true ? MPCF.Trim(out_node.GetList(0)[i].GetString("STDDEV")) : "") == "")
                                {
                                    dRdata = DOUBLE_NULL_DATA;
                                }
                                else
                                {
                                    dRdata = MPCF.ToDbl(out_node.GetList(0)[i].GetString("STDDEV"));
                                }
                                break;
                            case SPCControlChart.modEnums.GRAPH_TYPE.XRS:
                                if ((MPCF.CheckNumeric(MPCF.Trim(out_node.GetList(0)[i].GetString("AVERAGE"))) == true ? MPCF.Trim(out_node.GetList(0)[i].GetString("AVERAGE")) : "") == "")
                                {
                                    dXData = DOUBLE_NULL_DATA;
                                }
                                else
                                {
                                    dXData = MPCF.ToDbl(out_node.GetList(0)[i].GetString("AVERAGE"));
                                }

                                if ((MPCF.CheckNumeric(MPCF.Trim(out_node.GetList(0)[i].GetString("RANGE"))) == true ? MPCF.Trim(out_node.GetList(0)[i].GetString("RANGE")) : "") == "")
                                {
                                    dRdata = DOUBLE_NULL_DATA;
                                }
                                else
                                {
                                    dRdata = MPCF.ToDbl(out_node.GetList(0)[i].GetString("RANGE"));
                                }
                                break;
                            case SPCControlChart.modEnums.GRAPH_TYPE.P:

                                if ((MPCF.CheckNumeric(MPCF.Trim(out_node.GetList(0)[i].GetString("AVERAGE"))) == true ? MPCF.Trim(out_node.GetList(0)[i].GetString("AVERAGE")) : "") == "")
                                {
                                    dXData = DOUBLE_NULL_DATA;
                                }
                                else
                                {
                                    dXData = MPCF.ToDbl(out_node.GetList(0)[i].GetString("AVERAGE"));
                                }
                                dRdata = DOUBLE_NULL_DATA;
                                break;
                            case SPCControlChart.modEnums.GRAPH_TYPE.PN:


                                if ((MPCF.CheckNumeric(MPCF.Trim(out_node.GetList(0)[i].GetString("AVERAGE"))) == true ? MPCF.Trim(out_node.GetList(0)[i].GetString("AVERAGE")) : "") == "")
                                {
                                    dXData = DOUBLE_NULL_DATA;
                                }
                                else
                                {
                                    dXData = MPCF.ToDbl(out_node.GetList(0)[i].GetString("AVERAGE"));
                                }
                                dRdata = DOUBLE_NULL_DATA;
                                break;
                            case SPCControlChart.modEnums.GRAPH_TYPE.C:

                                if ((MPCF.CheckNumeric(MPCF.Trim(out_node.GetList(0)[i].GetString("AVERAGE"))) == true ? MPCF.Trim(out_node.GetList(0)[i].GetString("AVERAGE")) : "") == "")
                                {
                                    dXData = DOUBLE_NULL_DATA;
                                }
                                else
                                {
                                    dXData = MPCF.ToDbl(out_node.GetList(0)[i].GetString("AVERAGE"));
                                }
                                dRdata = DOUBLE_NULL_DATA;
                                break;
                            case SPCControlChart.modEnums.GRAPH_TYPE.U:

                                if ((MPCF.CheckNumeric(MPCF.Trim(out_node.GetList(0)[i].GetString("AVERAGE"))) == true ? MPCF.Trim(out_node.GetList(0)[i].GetString("AVERAGE")) : "") == "")
                                {
                                    dXData = DOUBLE_NULL_DATA;
                                }
                                else
                                {
                                    dXData = MPCF.ToDbl(out_node.GetList(0)[i].GetString("AVERAGE"));
                                }
                                dRdata = DOUBLE_NULL_DATA;
                                break;
                            case SPCControlChart.modEnums.GRAPH_TYPE.ZBARS:

                                if ((MPCF.CheckNumeric(MPCF.Trim(out_node.GetList(0)[i].GetString("WEIGHT_VALUE"))) == true ? MPCF.Trim(out_node.GetList(0)[i].GetString("WEIGHT_VALUE")) : "") == "")
                                {
                                    dXData = DOUBLE_NULL_DATA;
                                }
                                else
                                {
                                    dXData = MPCF.ToDbl(out_node.GetList(0)[i].GetString("WEIGHT_VALUE"));
                                }

                                if ((MPCF.CheckNumeric(MPCF.Trim(out_node.GetList(0)[i].GetString("STDDEV"))) == true ? MPCF.Trim(out_node.GetList(0)[i].GetString("STDDEV")) : "") == "")
                                {
                                    dRdata = DOUBLE_NULL_DATA;
                                }
                                else
                                {
                                    dRdata = MPCF.ToDbl(out_node.GetList(0)[i].GetString("STDDEV"));
                                }
                                break;
                            case SPCControlChart.modEnums.GRAPH_TYPE.DELTAS:

                                if ((MPCF.CheckNumeric(MPCF.Trim(out_node.GetList(0)[i].GetString("WEIGHT_VALUE"))) == true ? MPCF.Trim(out_node.GetList(0)[i].GetString("WEIGHT_VALUE")) : "") == "")
                                {
                                    dXData = DOUBLE_NULL_DATA;
                                }
                                else
                                {
                                    dXData = MPCF.ToDbl(out_node.GetList(0)[i].GetString("WEIGHT_VALUE"));
                                }

                                if ((MPCF.CheckNumeric(MPCF.Trim(out_node.GetList(0)[i].GetString("STDDEV"))) == true ? MPCF.Trim(out_node.GetList(0)[i].GetString("STDDEV")) : "") == "")
                                {
                                    dRdata = DOUBLE_NULL_DATA;
                                }
                                else
                                {
                                    dRdata = MPCF.ToDbl(out_node.GetList(0)[i].GetString("STDDEV"));
                                }
                                break;
                            default:

                                dXData = DOUBLE_NULL_DATA;
                                dRdata = DOUBLE_NULL_DATA;
                                break;
                        }

                        if (Chart.AddChartData(sGroupIndex, sLotIndex, MPCF.Trim(out_node.GetList(0)[i].GetString("LOT_ID")), dXData, dRdata) == false)
                        {
                            return false;
                        }

                        if (sTranTime != "")
                        {
                            if (Chart.AddDate(sGroupIndex, sLotIndex, MPCF.ToInt(sTranTime.Substring(0, 4)), MPCF.ToInt(sTranTime.Substring(4, 2)), MPCF.ToInt(sTranTime.Substring(6, 2)), MPCF.ToInt(sTranTime.Substring(8, 2)), MPCF.ToInt(sTranTime.Substring(10, 2)), MPCF.ToInt(sTranTime.Substring(12, 2))) == false)
                            {
                                return false;
                            }
                        }

                        if (Chart.SetSequence(sGroupIndex, sLotIndex, out_node.GetList(0)[i].GetInt("HIST_SEQ"), out_node.GetList(0)[i].GetInt("UNIT_SEQ"), out_node.GetList(0)[i].GetInt("EDC_COL_SEQ")) == false)
                        {
                            return false;
                        }

                        if (MPCF.Trim(out_node.GetList(0)[i].GetChar("OOC_TYPE")) != "" || MPCF.Trim(out_node.GetList(0)[i].GetChar("OOC_TYPE2")) != "")
                        {
                            if (Chart.SetRunTestFlag(sLotIndex, MPCF.Trim(out_node.GetList(0)[i].GetChar("OOC_TYPE")), MPCF.Trim(out_node.GetList(0)[i].GetChar("OOC_TYPE2"))) == false)
                            {
                                return false;
                            }
                        }
                        for (j = 0; j <= out_node.GetList(0)[i].GetList(0).Count - 1; j++)
                        {
                            if ((MPCF.CheckNumeric(MPCF.Trim(out_node.GetList(0)[i].GetList(0)[j].GetString("VALUE"))) == true ? MPCF.Trim(out_node.GetList(0)[i].GetList(0)[j].GetString("VALUE")) : "") == "")
                            {
                                dValue = DOUBLE_NULL_DATA;
                            }
                            else
                            {
                                dValue = MPCF.ToDbl(out_node.GetList(0)[i].GetList(0)[j].GetString("VALUE"));
                            }
                            if (Chart.AddChartRawData(sGroupIndex, sLotIndex, sXAxis, dValue) == false)
                            {
                                return false;
                            }
                        }

                        dPrevUSL = dUSL;
                        dPrevLSL = dLSL;
                        dPrevUCL = dUCL;
                        dPrevCL = dCL;
                        dPrevLCL = dLCL;
                        dPrevUCL2 = dUCL2;
                        dPrevCL2 = dCL2;
                        dPrevLCL2 = dLCL2;

                        iLotIndex++;

                    }
                }

                if (Chart.RefreshChartData() == false)
                {
                    return false;
                }

                Chart.Refresh();

                //this.btnReset.Enabled = false;

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
