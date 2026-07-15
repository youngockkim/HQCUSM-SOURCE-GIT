
using Miracom.CliFrx;
using System.Data;
using System;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;

using System.Diagnostics;
using Miracom.MsgHandler;
using Miracom.Stat;
using Miracom.MESCore;
using Infragistics.Win.UltraWinEditors;
using Miracom.TRSCore;
//#If _SPC = True Then
//-----------------------------------------------------------------------------
//
//   System      : SPCClient
//   File Name   : frmSPCTranOnLineChart.vb
//   Description : Realtime Monitoring Chart
//
//   SPC Version : 1.0.0
//
//   Function List
//       - ViewControlChartEvent : View Control Chart Mashaling
//       - CheckCondition : Check the conditions before transaction
//       - InitChart : Initialize Chart Options
//       - SetChartOptions : Set Chart Options
//       - SetChartTitle : Set Chart Titles
//       - ResetChart : Reset Chart
//       - View_ControlChart : View Control Chart
//
//   Detail Description
//       -
//
//   History
//       - 2005-05-09 : Created by LaverWon
//
//   Copyright(C) 1998-2004 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------

namespace Miracom.SPCCore
{
    public class frmSPCTranOnLineChart : System.Windows.Forms.Form
    {

        #region " Windows Form auto generated code "

        delegate bool ViewControlChartDelegate();
        delegate void ChartRefreshDelegate();

        private ViewControlChartDelegate _ViewControlChartDelegate;
        private ChartRefreshDelegate _ChartRefreshDelegate;

        public frmSPCTranOnLineChart()
        {

            
            InitializeComponent();

            
            _ViewControlChartDelegate = new ViewControlChartDelegate(ViewControlChart);
            _ChartRefreshDelegate = new ChartRefreshDelegate(ChartRefresh);

        }

        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (!(components == null))
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        
        private System.ComponentModel.Container components = null;

        //Ï∞∏Í≥†: ?§Ïùå ?ÑÎ°ú?úÏ???Windows Form ?îÏûê?¥ÎÑà???ÑÏöî?©Îãà??
        //Windows Form ?îÏûê?¥ÎÑàÎ•??¨Ïö©?òÏó¨ ?òÏ†ï?????àÏäµ?àÎã§.
        //ÏΩîÎìú ?∏ÏßëÍ∏∞Î? ?¨Ïö©?òÏó¨ ?òÏ†ï?òÏ? ÎßàÏã≠?úÏò§.
        internal System.Windows.Forms.Panel pnlFill;
        internal System.Windows.Forms.Panel pnlFillFill;
        internal System.Windows.Forms.Panel pnlFillTop;
        internal System.Windows.Forms.Panel pnlBottom;
        internal System.Windows.Forms.Button btnClose;
        internal System.Windows.Forms.Panel pnlChart;
        internal SPCControlChart.SPCControlChart Chart;
        internal System.Windows.Forms.GroupBox grpTop;
        internal System.Windows.Forms.GroupBox grpChartOptions;
        internal Infragistics.Win.UltraWinEditors.UltraCheckEditor chkViewCZone;
        internal Infragistics.Win.UltraWinEditors.UltraCheckEditor chkViewBZone;
        internal Infragistics.Win.UltraWinEditors.UltraCheckEditor chkViewAZone;
        internal Infragistics.Win.UltraWinEditors.UltraTextEditor txtMaxLotCount;
        internal System.Windows.Forms.Label lblMaxLotCount;
        internal Infragistics.Win.UltraWinEditors.UltraCheckEditor chkViewSpecLimit;
        internal Infragistics.Win.UltraWinEditors.UltraCheckEditor chkViewDate;
        internal Infragistics.Win.UltraWinEditors.UltraCheckEditor chkViewLotID;
        internal Infragistics.Win.UltraWinEditors.UltraCheckEditor chkViewRuleCheck;
        internal Infragistics.Win.UltraWinEditors.UltraCheckEditor chkViewRChart;
        internal System.Windows.Forms.Label lblGraphType;
        internal Infragistics.Win.UltraWinEditors.UltraComboEditor cboGraphType;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvChartID;
        internal System.Windows.Forms.Label lblChartID;
        internal System.Windows.Forms.GroupBox grpChartInfo;
        internal System.Windows.Forms.Button btnRefresh;
        internal System.Windows.Forms.Button btnMonitoring;
        internal Miracom.SPCCore.udcChart ctrlChartData;
        internal Infragistics.Win.UltraWinEditors.UltraCheckEditor chkAutoCalControlLimit;
        internal System.Windows.Forms.Label lblAutoControlLimit;
        internal System.Windows.Forms.Button btnPrint;
        internal System.Windows.Forms.Button btnSaveImage;
        internal System.Windows.Forms.Button btnCopyImage;
        internal System.Windows.Forms.Button btnFiltering;
        [System.Diagnostics.DebuggerStepThrough()]
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSPCTranOnLineChart));
            this.pnlFill = new System.Windows.Forms.Panel();
            this.pnlFillFill = new System.Windows.Forms.Panel();
            this.pnlChart = new System.Windows.Forms.Panel();
            this.Chart = new SPCControlChart.SPCControlChart();
            this.pnlFillTop = new System.Windows.Forms.Panel();
            this.grpChartOptions = new System.Windows.Forms.GroupBox();
            this.lblAutoControlLimit = new System.Windows.Forms.Label();
            this.chkAutoCalControlLimit = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.chkViewRuleCheck = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.chkViewRChart = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.chkViewSpecLimit = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.chkViewDate = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.chkViewLotID = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.txtMaxLotCount = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lblMaxLotCount = new System.Windows.Forms.Label();
            this.chkViewCZone = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.chkViewBZone = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.chkViewAZone = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.grpTop = new System.Windows.Forms.GroupBox();
            this.btnFiltering = new System.Windows.Forms.Button();
            this.lblGraphType = new System.Windows.Forms.Label();
            this.cboGraphType = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.cdvChartID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblChartID = new System.Windows.Forms.Label();
            this.grpChartInfo = new System.Windows.Forms.GroupBox();
            this.ctrlChartData = new Miracom.SPCCore.udcChart();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnSaveImage = new System.Windows.Forms.Button();
            this.btnCopyImage = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnMonitoring = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.pnlFill.SuspendLayout();
            this.pnlFillFill.SuspendLayout();
            this.pnlChart.SuspendLayout();
            this.pnlFillTop.SuspendLayout();
            this.grpChartOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkAutoCalControlLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkViewRuleCheck)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkViewRChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkViewSpecLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkViewDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkViewLotID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaxLotCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkViewCZone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkViewBZone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkViewAZone)).BeginInit();
            this.grpTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboGraphType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChartID)).BeginInit();
            this.grpChartInfo.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlFill
            // 
            this.pnlFill.Controls.Add(this.pnlFillFill);
            this.pnlFill.Controls.Add(this.pnlFillTop);
            this.pnlFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFill.Location = new System.Drawing.Point(0, 0);
            this.pnlFill.Name = "pnlFill";
            this.pnlFill.Size = new System.Drawing.Size(792, 596);
            this.pnlFill.TabIndex = 0;
            // 
            // pnlFillFill
            // 
            this.pnlFillFill.Controls.Add(this.pnlChart);
            this.pnlFillFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFillFill.Location = new System.Drawing.Point(0, 179);
            this.pnlFillFill.Name = "pnlFillFill";
            this.pnlFillFill.Padding = new System.Windows.Forms.Padding(3);
            this.pnlFillFill.Size = new System.Drawing.Size(792, 417);
            this.pnlFillFill.TabIndex = 1;
            // 
            // pnlChart
            // 
            this.pnlChart.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlChart.Controls.Add(this.Chart);
            this.pnlChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlChart.Location = new System.Drawing.Point(3, 3);
            this.pnlChart.Name = "pnlChart";
            this.pnlChart.Size = new System.Drawing.Size(786, 411);
            this.pnlChart.TabIndex = 0;
            // 
            // Chart
            // 
            this.Chart.AZoneColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(115)))), ((int)(((byte)(0)))));
            this.Chart.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Chart.BGColor = System.Drawing.Color.WhiteSmoke;
            this.Chart.BottomTitle = "";
            this.Chart.BottomTitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(39)))), ((int)(((byte)(116)))));
            this.Chart.BZoneColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
            this.Chart.ChartType = SPCControlChart.modEnums.GRAPH_TYPE.NONE;
            this.Chart.CLLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(15)))));
            this.Chart.ControlLimitColor = System.Drawing.Color.Black;
            this.Chart.CZoneColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(255)))), ((int)(((byte)(33)))));
            this.Chart.DateColor = System.Drawing.Color.Black;
            this.Chart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Chart.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Chart.IsAutoRuleCheck = false;
            this.Chart.IsDrawGroupLine = false;
            this.Chart.IsOnLineChart = false;
            this.Chart.IsOnLineStop = false;
            this.Chart.IsPoint3D = true;
            this.Chart.IsSimpleChart = false;
            this.Chart.IsTimeBasedChart = false;
            this.Chart.IsUserInputCL = false;
            this.Chart.IsViewAZone = true;
            this.Chart.IsViewBZone = true;
            this.Chart.IsViewContextMenu = true;
            this.Chart.IsViewCZone = true;
            this.Chart.IsViewDate = true;
            this.Chart.IsViewDisable = false;
            this.Chart.IsViewLotID = false;
            this.Chart.IsViewLSL = false;
            this.Chart.IsViewPoint = true;
            this.Chart.IsViewRChart = true;
            this.Chart.IsViewRCL = true;
            this.Chart.IsViewRLCL = true;
            this.Chart.IsViewRUCL = true;
            this.Chart.IsViewRunTestText = false;
            this.Chart.IsViewSpecLimit = false;
            this.Chart.IsViewTarget = false;
            this.Chart.IsViewUSL = false;
            this.Chart.IsViewXCL = true;
            this.Chart.IsViewXLCL = true;
            this.Chart.IsViewXUCL = true;
            this.Chart.LCLLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(15)))));
            this.Chart.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(100)))));
            this.Chart.Location = new System.Drawing.Point(0, 0);
            this.Chart.LotIDColor = System.Drawing.Color.Black;
            this.Chart.LSLLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.Chart.MainTitle = "";
            this.Chart.MainTitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.Chart.MaxLotCount = 100;
            this.Chart.Name = "Chart";
            this.Chart.NormalPointColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Chart.OOCPointColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
            this.Chart.OOSPointColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Chart.PointSize = 3;
            this.Chart.Precision = 4;
            this.Chart.RRegionColor = System.Drawing.Color.White;
            this.Chart.RRuleType = "";
            this.Chart.RunTestColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.Chart.SampleSize = 0;
            this.Chart.Size = new System.Drawing.Size(782, 407);
            this.Chart.SpecLimitColor = System.Drawing.Color.Black;
            this.Chart.SubTitle = "";
            this.Chart.SubTitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(39)))), ((int)(((byte)(116)))));
            this.Chart.TabIndex = 0;
            this.Chart.UCLLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(15)))));
            this.Chart.UnitTitle = "";
            this.Chart.UnitTitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(39)))), ((int)(((byte)(116)))));
            this.Chart.USLLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.Chart.XRegionColor = System.Drawing.Color.White;
            this.Chart.XRuleType = "";
            this.Chart.YAxisColor = System.Drawing.Color.Black;
            this.Chart.MouseButtonDown += new SPCControlChart.MouseButtonDownEventHandler(this.Chart_MouseButtonDown);
            this.Chart.ViewOOCInfo += new SPCControlChart.ViewOOCInfoEventHandler(this.Chart_ViewOOCInfo);
            this.Chart.ChangeEDCData += new SPCControlChart.ChangeEDCDataEventHandler(this.Chart_ChangeEDCData);
            // 
            // pnlFillTop
            // 
            this.pnlFillTop.Controls.Add(this.grpChartOptions);
            this.pnlFillTop.Controls.Add(this.grpTop);
            this.pnlFillTop.Controls.Add(this.grpChartInfo);
            this.pnlFillTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFillTop.Location = new System.Drawing.Point(0, 0);
            this.pnlFillTop.Name = "pnlFillTop";
            this.pnlFillTop.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.pnlFillTop.Size = new System.Drawing.Size(792, 179);
            this.pnlFillTop.TabIndex = 0;
            // 
            // grpChartOptions
            // 
            this.grpChartOptions.Controls.Add(this.lblAutoControlLimit);
            this.grpChartOptions.Controls.Add(this.chkAutoCalControlLimit);
            this.grpChartOptions.Controls.Add(this.chkViewRuleCheck);
            this.grpChartOptions.Controls.Add(this.chkViewRChart);
            this.grpChartOptions.Controls.Add(this.chkViewSpecLimit);
            this.grpChartOptions.Controls.Add(this.chkViewDate);
            this.grpChartOptions.Controls.Add(this.chkViewLotID);
            this.grpChartOptions.Controls.Add(this.txtMaxLotCount);
            this.grpChartOptions.Controls.Add(this.lblMaxLotCount);
            this.grpChartOptions.Controls.Add(this.chkViewCZone);
            this.grpChartOptions.Controls.Add(this.chkViewBZone);
            this.grpChartOptions.Controls.Add(this.chkViewAZone);
            this.grpChartOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpChartOptions.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpChartOptions.Location = new System.Drawing.Point(332, 0);
            this.grpChartOptions.Name = "grpChartOptions";
            this.grpChartOptions.Size = new System.Drawing.Size(457, 78);
            this.grpChartOptions.TabIndex = 1;
            this.grpChartOptions.TabStop = false;
            this.grpChartOptions.Text = "Chart Options";
            // 
            // lblAutoControlLimit
            // 
            this.lblAutoControlLimit.AutoSize = true;
            this.lblAutoControlLimit.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAutoControlLimit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAutoControlLimit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblAutoControlLimit.Location = new System.Drawing.Point(359, 17);
            this.lblAutoControlLimit.Name = "lblAutoControlLimit";
            this.lblAutoControlLimit.Size = new System.Drawing.Size(89, 13);
            this.lblAutoControlLimit.TabIndex = 10;
            this.lblAutoControlLimit.Text = "Auto Control Limit";
            // 
            // chkAutoCalControlLimit
            // 
            this.chkAutoCalControlLimit.AutoSize = true;
            this.chkAutoCalControlLimit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkAutoCalControlLimit.Location = new System.Drawing.Point(342, 17);
            this.chkAutoCalControlLimit.Name = "chkAutoCalControlLimit";
            this.chkAutoCalControlLimit.Size = new System.Drawing.Size(125, 17);
            this.chkAutoCalControlLimit.TabIndex = 9;
            this.chkAutoCalControlLimit.Text = "Auto Control Limit";
            this.chkAutoCalControlLimit.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            // 
            // chkViewRuleCheck
            // 
            this.chkViewRuleCheck.AutoSize = true;
            this.chkViewRuleCheck.Checked = true;
            this.chkViewRuleCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkViewRuleCheck.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkViewRuleCheck.Location = new System.Drawing.Point(218, 17);
            this.chkViewRuleCheck.Name = "chkViewRuleCheck";
            this.chkViewRuleCheck.Size = new System.Drawing.Size(118, 17);
            this.chkViewRuleCheck.TabIndex = 6;
            this.chkViewRuleCheck.Text = "View Rule Check";
            this.chkViewRuleCheck.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.chkViewRuleCheck.CheckedChanged += new System.EventHandler(this.chkViewRuleCheck_CheckedChanged);
            // 
            // chkViewRChart
            // 
            this.chkViewRChart.AutoSize = true;
            this.chkViewRChart.Checked = true;
            this.chkViewRChart.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkViewRChart.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkViewRChart.Location = new System.Drawing.Point(218, 37);
            this.chkViewRChart.Name = "chkViewRChart";
            this.chkViewRChart.Size = new System.Drawing.Size(99, 17);
            this.chkViewRChart.TabIndex = 7;
            this.chkViewRChart.Text = "View R-Chart";
            this.chkViewRChart.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.chkViewRChart.CheckedChanged += new System.EventHandler(this.chkViewRChart_CheckedChanged);
            // 
            // chkViewSpecLimit
            // 
            this.chkViewSpecLimit.AutoSize = true;
            this.chkViewSpecLimit.Checked = true;
            this.chkViewSpecLimit.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkViewSpecLimit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkViewSpecLimit.Location = new System.Drawing.Point(94, 57);
            this.chkViewSpecLimit.Name = "chkViewSpecLimit";
            this.chkViewSpecLimit.Size = new System.Drawing.Size(113, 17);
            this.chkViewSpecLimit.TabIndex = 5;
            this.chkViewSpecLimit.Text = "View Spec Limit";
            this.chkViewSpecLimit.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.chkViewSpecLimit.CheckedChanged += new System.EventHandler(this.chkViewSpecLimit_CheckedChanged);
            // 
            // chkViewDate
            // 
            this.chkViewDate.AutoSize = true;
            this.chkViewDate.Checked = true;
            this.chkViewDate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkViewDate.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkViewDate.Location = new System.Drawing.Point(94, 37);
            this.chkViewDate.Name = "chkViewDate";
            this.chkViewDate.Size = new System.Drawing.Size(79, 17);
            this.chkViewDate.TabIndex = 4;
            this.chkViewDate.Text = "View Date";
            this.chkViewDate.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.chkViewDate.CheckedChanged += new System.EventHandler(this.chkViewDate_CheckedChanged);
            // 
            // chkViewLotID
            // 
            this.chkViewLotID.AutoSize = true;
            this.chkViewLotID.Checked = true;
            this.chkViewLotID.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkViewLotID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkViewLotID.Location = new System.Drawing.Point(94, 17);
            this.chkViewLotID.Name = "chkViewLotID";
            this.chkViewLotID.Size = new System.Drawing.Size(119, 17);
            this.chkViewLotID.TabIndex = 3;
            this.chkViewLotID.Text = "View XAxis Label";
            this.chkViewLotID.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.chkViewLotID.CheckedChanged += new System.EventHandler(this.chkViewLotID_CheckedChanged);
            // 
            // txtMaxLotCount
            // 
            this.txtMaxLotCount.Location = new System.Drawing.Point(306, 55);
            this.txtMaxLotCount.MaxLength = 20;
            this.txtMaxLotCount.Name = "txtMaxLotCount";
            this.txtMaxLotCount.Size = new System.Drawing.Size(54, 20);
            this.txtMaxLotCount.TabIndex = 11;
            this.txtMaxLotCount.Text = "30";
            this.txtMaxLotCount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMaxLotCount_KeyPress);
            // 
            // lblMaxLotCount
            // 
            this.lblMaxLotCount.AutoSize = true;
            this.lblMaxLotCount.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblMaxLotCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaxLotCount.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblMaxLotCount.Location = new System.Drawing.Point(218, 59);
            this.lblMaxLotCount.Name = "lblMaxLotCount";
            this.lblMaxLotCount.Size = new System.Drawing.Size(91, 13);
            this.lblMaxLotCount.TabIndex = 8;
            this.lblMaxLotCount.Text = "Max Point Count :";
            // 
            // chkViewCZone
            // 
            this.chkViewCZone.AutoSize = true;
            this.chkViewCZone.Checked = true;
            this.chkViewCZone.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkViewCZone.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkViewCZone.Location = new System.Drawing.Point(16, 57);
            this.chkViewCZone.Name = "chkViewCZone";
            this.chkViewCZone.Size = new System.Drawing.Size(64, 17);
            this.chkViewCZone.TabIndex = 2;
            this.chkViewCZone.Text = "C Zone";
            this.chkViewCZone.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.chkViewCZone.CheckedChanged += new System.EventHandler(this.chkViewCZone_CheckedChanged);
            // 
            // chkViewBZone
            // 
            this.chkViewBZone.AutoSize = true;
            this.chkViewBZone.Checked = true;
            this.chkViewBZone.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkViewBZone.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkViewBZone.Location = new System.Drawing.Point(16, 37);
            this.chkViewBZone.Name = "chkViewBZone";
            this.chkViewBZone.Size = new System.Drawing.Size(63, 17);
            this.chkViewBZone.TabIndex = 1;
            this.chkViewBZone.Text = "B Zone";
            this.chkViewBZone.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.chkViewBZone.CheckedChanged += new System.EventHandler(this.chkViewBZone_CheckedChanged);
            // 
            // chkViewAZone
            // 
            this.chkViewAZone.AutoSize = true;
            this.chkViewAZone.Checked = true;
            this.chkViewAZone.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkViewAZone.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkViewAZone.Location = new System.Drawing.Point(16, 17);
            this.chkViewAZone.Name = "chkViewAZone";
            this.chkViewAZone.Size = new System.Drawing.Size(63, 17);
            this.chkViewAZone.TabIndex = 0;
            this.chkViewAZone.Text = "A Zone";
            this.chkViewAZone.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.chkViewAZone.CheckedChanged += new System.EventHandler(this.chkViewAZone_CheckedChanged);
            // 
            // grpTop
            // 
            this.grpTop.Controls.Add(this.btnFiltering);
            this.grpTop.Controls.Add(this.lblGraphType);
            this.grpTop.Controls.Add(this.cboGraphType);
            this.grpTop.Controls.Add(this.cdvChartID);
            this.grpTop.Controls.Add(this.lblChartID);
            this.grpTop.Dock = System.Windows.Forms.DockStyle.Left;
            this.grpTop.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpTop.Location = new System.Drawing.Point(3, 0);
            this.grpTop.Name = "grpTop";
            this.grpTop.Size = new System.Drawing.Size(329, 78);
            this.grpTop.TabIndex = 0;
            this.grpTop.TabStop = false;
            // 
            // btnFiltering
            // 
            this.btnFiltering.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFiltering.Image = ((System.Drawing.Image)(resources.GetObject("btnFiltering.Image")));
            this.btnFiltering.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnFiltering.Location = new System.Drawing.Point(298, 19);
            this.btnFiltering.Name = "btnFiltering";
            this.btnFiltering.Size = new System.Drawing.Size(24, 24);
            this.btnFiltering.TabIndex = 2;
            this.btnFiltering.Click += new System.EventHandler(this.btnFiltering_Click);
            // 
            // lblGraphType
            // 
            this.lblGraphType.AutoSize = true;
            this.lblGraphType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblGraphType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGraphType.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblGraphType.Location = new System.Drawing.Point(13, 48);
            this.lblGraphType.Name = "lblGraphType";
            this.lblGraphType.Size = new System.Drawing.Size(63, 13);
            this.lblGraphType.TabIndex = 3;
            this.lblGraphType.Text = "Graph Type";
            // 
            // cboGraphType
            // 
            this.cboGraphType.DropDownButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.Never;
            this.cboGraphType.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cboGraphType.Location = new System.Drawing.Point(115, 46);
            this.cboGraphType.Name = "cboGraphType";
            this.cboGraphType.ReadOnly = true;
            this.cboGraphType.Size = new System.Drawing.Size(179, 19);
            this.cboGraphType.TabIndex = 4;
            this.cboGraphType.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            // 
            // cdvChartID
            // 
            this.cdvChartID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvChartID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvChartID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvChartID.BtnToolTipText = "";
            this.cdvChartID.DescText = "";
            this.cdvChartID.DisplaySubItemIndex = -1;
            this.cdvChartID.DisplayText = "";
            this.cdvChartID.Focusing = null;
            this.cdvChartID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvChartID.Index = 0;
            this.cdvChartID.IsViewBtnImage = false;
            this.cdvChartID.Location = new System.Drawing.Point(115, 21);
            this.cdvChartID.MaxLength = 30;
            this.cdvChartID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvChartID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvChartID.Name = "cdvChartID";
            this.cdvChartID.ReadOnly = false;
            this.cdvChartID.SearchSubItemIndex = 0;
            this.cdvChartID.SelectedDescIndex = -1;
            this.cdvChartID.SelectedSubItemIndex = -1;
            this.cdvChartID.SelectionStart = 0;
            this.cdvChartID.Size = new System.Drawing.Size(179, 20);
            this.cdvChartID.SmallImageList = null;
            this.cdvChartID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvChartID.TabIndex = 1;
            this.cdvChartID.TextBoxToolTipText = "";
            this.cdvChartID.TextBoxWidth = 179;
            this.cdvChartID.VisibleButton = true;
            this.cdvChartID.VisibleColumnHeader = false;
            this.cdvChartID.VisibleDescription = false;
            this.cdvChartID.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvChartID_SelectedItemChanged);
            this.cdvChartID.ButtonPress += new System.EventHandler(this.cdvChartID_ButtonPress);
            this.cdvChartID.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvChartID_TextBoxKeyPress);
            // 
            // lblChartID
            // 
            this.lblChartID.AutoSize = true;
            this.lblChartID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblChartID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChartID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblChartID.Location = new System.Drawing.Point(13, 24);
            this.lblChartID.Name = "lblChartID";
            this.lblChartID.Size = new System.Drawing.Size(54, 13);
            this.lblChartID.TabIndex = 0;
            this.lblChartID.Text = "Chart ID";
            // 
            // grpChartInfo
            // 
            this.grpChartInfo.Controls.Add(this.ctrlChartData);
            this.grpChartInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpChartInfo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpChartInfo.Location = new System.Drawing.Point(3, 78);
            this.grpChartInfo.Name = "grpChartInfo";
            this.grpChartInfo.Size = new System.Drawing.Size(786, 98);
            this.grpChartInfo.TabIndex = 2;
            this.grpChartInfo.TabStop = false;
            // 
            // ctrlChartData
            // 
            this.ctrlChartData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlChartData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlChartData.Location = new System.Drawing.Point(3, 16);
            this.ctrlChartData.Name = "ctrlChartData";
            this.ctrlChartData.Size = new System.Drawing.Size(780, 79);
            this.ctrlChartData.SyncEDCFlag = ' ';
            this.ctrlChartData.TabIndex = 0;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnPrint);
            this.pnlBottom.Controls.Add(this.btnSaveImage);
            this.pnlBottom.Controls.Add(this.btnCopyImage);
            this.pnlBottom.Controls.Add(this.btnRefresh);
            this.pnlBottom.Controls.Add(this.btnMonitoring);
            this.pnlBottom.Controls.Add(this.btnClose);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 596);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(792, 40);
            this.pnlBottom.TabIndex = 0;
            // 
            // btnPrint
            // 
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnPrint.Location = new System.Drawing.Point(92, 8);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(24, 24);
            this.btnPrint.TabIndex = 5;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnSaveImage
            // 
            this.btnSaveImage.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSaveImage.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveImage.Image")));
            this.btnSaveImage.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSaveImage.Location = new System.Drawing.Point(64, 8);
            this.btnSaveImage.Name = "btnSaveImage";
            this.btnSaveImage.Size = new System.Drawing.Size(24, 24);
            this.btnSaveImage.TabIndex = 4;
            this.btnSaveImage.Click += new System.EventHandler(this.btnSaveImage_Click);
            // 
            // btnCopyImage
            // 
            this.btnCopyImage.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCopyImage.Image = ((System.Drawing.Image)(resources.GetObject("btnCopyImage.Image")));
            this.btnCopyImage.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCopyImage.Location = new System.Drawing.Point(36, 8);
            this.btnCopyImage.Name = "btnCopyImage";
            this.btnCopyImage.Size = new System.Drawing.Size(24, 24);
            this.btnCopyImage.TabIndex = 3;
            this.btnCopyImage.Click += new System.EventHandler(this.btnCopyImage_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnRefresh.Location = new System.Drawing.Point(8, 8);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(24, 24);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnMonitoring
            // 
            this.btnMonitoring.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMonitoring.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnMonitoring.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnMonitoring.Location = new System.Drawing.Point(608, 7);
            this.btnMonitoring.Name = "btnMonitoring";
            this.btnMonitoring.Size = new System.Drawing.Size(88, 26);
            this.btnMonitoring.TabIndex = 0;
            this.btnMonitoring.Tag = "M";
            this.btnMonitoring.Text = "Monitoring";
            this.btnMonitoring.Click += new System.EventHandler(this.btnMonitoring_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnClose.Location = new System.Drawing.Point(700, 7);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(88, 26);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmSPCTranOnLineChart
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(792, 636);
            this.Controls.Add(this.pnlFill);
            this.Controls.Add(this.pnlBottom);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(800, 670);
            this.Name = "frmSPCTranOnLineChart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Realtime Monitoring Control Chart";
            this.Activated += new System.EventHandler(this.frmSPCTranOnLineChart_Activated);
            this.Closed += new System.EventHandler(this.frmSPCTranOnLineChart_Closed);
            this.Load += new System.EventHandler(this.frmSPCTranOnLineChart_Load);
            this.pnlFill.ResumeLayout(false);
            this.pnlFillFill.ResumeLayout(false);
            this.pnlChart.ResumeLayout(false);
            this.pnlFillTop.ResumeLayout(false);
            this.grpChartOptions.ResumeLayout(false);
            this.grpChartOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkAutoCalControlLimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkViewRuleCheck)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkViewRChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkViewSpecLimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkViewDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkViewLotID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaxLotCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkViewCZone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkViewBZone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkViewAZone)).EndInit();
            this.grpTop.ResumeLayout(false);
            this.grpTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboGraphType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChartID)).EndInit();
            this.grpChartInfo.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        #region " Variable Definition"

        bool b_load_flag;
        public string gsReceiveCode = "";

        #endregion

        #region " Functions Implementation"

        // ViewControlChartEvent()
        //       - View Control Chart Mashaling
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        public bool ViewControlChartEvent()
        {

            try
            {
                IAsyncResult r = BeginInvoke(_ViewControlChartDelegate, null);
                bool bReturn = (bool)EndInvoke(r);

                return bReturn;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranOnLineChart.ViewControlChartEvent()\n" + ex.Message);
                return false;
            }

        }
        private void ChartRefresh()
        {
            try
            {
                Chart.Refresh();
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranOnLineChart.SetChartOption()\n" + ex.Message);
                
            }
        }
        public void ChartRefreshEvent()
        {

            try
            {
                IAsyncResult r = BeginInvoke(_ChartRefreshDelegate, null);
                EndInvoke(r);

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranOnLineChart.ChartRefreshEvent()\n" + ex.Message);
            }

        }
        // CheckCondition()
        //       - Check the conditions before transaction
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool CheckCondition()
        {

            try
            {
                if (cdvChartID.Text == "")
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                    cdvChartID.Focus();
                    return false;
                }
                if (cboGraphType.Text == "")
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                    cboGraphType.Focus();
                    return false;
                }
                if (MPCF.CheckNumeric(this.txtMaxLotCount.Text) == false)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(116));
                    this.txtMaxLotCount.SelectAll();
                    this.txtMaxLotCount.Focus();
                    return false;
                }
                else
                {
                    if (MPCF.ToInt(this.txtMaxLotCount.Text) <= 0)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(116));
                        this.txtMaxLotCount.SelectAll();
                        this.txtMaxLotCount.Focus();
                        return false;
                    }
                    if (MPCF.ToInt(this.txtMaxLotCount.Text) > 100)
                    {
                        if (MPGV.gcLanguage == '2')
                        {
                            MPCF.ShowMsgBox(MPCF.GetErrorMsgParse(236, "\'100\' ") + MPCF.GetMessage(236));
                        }
                        else
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(236) + " \'100\'");
                        }
                        this.txtMaxLotCount.SelectAll();
                        this.txtMaxLotCount.Focus();
                        return false;
                    }
                }

                return true;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranOnLineChart.CheckCondition()\n" + ex.Message);
                return false;
            }

        }

        // InitChart()
        //       - Initialize Chart Options
        // Return Value
        //       -
        // Arguments
        //       -
        //
        public void InitChart()
        {

            try
            {
                Chart.InitDataSet();
                Chart.IsOnLineChart = true;
                Chart.IsOnLineStop = false;
                Chart.IsViewRChart = this.chkViewRChart.Checked;
                Chart.IsViewLotID = this.chkViewLotID.Checked;
                Chart.IsViewDate = this.chkViewDate.Checked;
                Chart.IsUserInputCL = true;
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
                Chart.IsUserInputCL = !this.chkAutoCalControlLimit.Checked;

                if (MPCF.CheckNumeric(this.txtMaxLotCount.Text) == false)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(116));
                    this.txtMaxLotCount.SelectAll();
                    this.txtMaxLotCount.Focus();
                    return;
                }
                else
                {
                    if (MPCF.ToInt(this.txtMaxLotCount.Text) <= 0)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(116));
                        this.txtMaxLotCount.SelectAll();
                        this.txtMaxLotCount.Focus();
                        return;
                    }
                }

                Chart.MaxLotCount = MPCF.ToInt(this.txtMaxLotCount.Text);
                Chart.ChartType = SPCControlChart.modEnums.GRAPH_TYPE.NONE;
                Chart.SampleSize = 0;

                Chart.Refresh();

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranOnLineChart.InitChart()\n" + ex.Message);
            }

        }

        // SetChartOptions()
        //       - Set Chart Options
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
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
                MPCF.ShowMsgBox("frmSPCTranOnLineChart.SetChartOptions()\n" + ex.Message);
                return false;
            }

        }

        // SetChartTitle()
        //       - Set Chart Title
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        public bool SetChartTitle()
        {

            try
            {
                switch (Chart.ChartType)
                {
                    case SPCControlChart.modEnums.GRAPH_TYPE.XBARR:

                        Chart.MainTitle = this.cdvChartID.Text + " : " + this.cdvChartID.DescText;
                        Chart.SubTitle = "XBAR-CHART";
                        Chart.BottomTitle = "R-CHART";
                        Chart.UnitTitle = "";
                        break;
                    case SPCControlChart.modEnums.GRAPH_TYPE.XBARS:

                        Chart.MainTitle = this.cdvChartID.Text + " : " + this.cdvChartID.DescText;
                        Chart.SubTitle = "XBAR-CHART";
                        Chart.BottomTitle = "S-CHART";
                        Chart.UnitTitle = "";
                        break;
                    case SPCControlChart.modEnums.GRAPH_TYPE.XRS:

                        Chart.MainTitle = this.cdvChartID.Text + " : " + this.cdvChartID.DescText;
                        Chart.SubTitle = "X-CHART";
                        Chart.BottomTitle = "R-CHART";
                        Chart.UnitTitle = "";
                        break;
                    case SPCControlChart.modEnums.GRAPH_TYPE.P:

                        Chart.MainTitle = this.cdvChartID.Text + " : " + this.cdvChartID.DescText;
                        Chart.SubTitle = "P-CHART";
                        Chart.BottomTitle = "";
                        Chart.UnitTitle = "";
                        break;
                    case SPCControlChart.modEnums.GRAPH_TYPE.PN:

                        Chart.MainTitle = this.cdvChartID.Text + " : " + this.cdvChartID.DescText;
                        Chart.SubTitle = "PN-CHART";
                        Chart.BottomTitle = "";
                        Chart.UnitTitle = "";
                        break;
                    case SPCControlChart.modEnums.GRAPH_TYPE.C:

                        Chart.MainTitle = this.cdvChartID.Text + " : " + this.cdvChartID.DescText;
                        Chart.SubTitle = "C-CHART";
                        Chart.BottomTitle = "";
                        Chart.UnitTitle = "";
                        break;
                    case SPCControlChart.modEnums.GRAPH_TYPE.U:

                        Chart.MainTitle = this.cdvChartID.Text + " : " + this.cdvChartID.DescText;
                        Chart.SubTitle = "U-CHART";
                        Chart.BottomTitle = "";
                        Chart.UnitTitle = "";
                        break;
                    case SPCControlChart.modEnums.GRAPH_TYPE.ZBARS:

                        Chart.MainTitle = this.cdvChartID.Text + " : " + this.cdvChartID.DescText;
                        Chart.SubTitle = "ZBAR-CHART";
                        Chart.BottomTitle = "S-CHART";
                        Chart.UnitTitle = "";
                        break;
                    case SPCControlChart.modEnums.GRAPH_TYPE.DELTAS:

                        Chart.MainTitle = this.cdvChartID.Text + " : " + this.cdvChartID.DescText;
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
                MPCF.ShowMsgBox("frmSPCTranOnLineChart.SetChartTitle()\n" + ex.Message);
                return false;
            }

        }

        // ResetChart()
        //       - Reset Chart
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        public bool ResetChart()
        {

            try
            {
                Chart.SampleSize = ctrlChartData.SampleSize;
                Chart.ChartType = (SPCControlChart.modEnums.GRAPH_TYPE)this.cboGraphType.SelectedIndex;
                Chart.Precision = ctrlChartData.Precision;

                if (SetChartTitle() == false)
                {
                    return false;
                }

                Chart.ResvField2 = "-1";
                Chart.ResvField3 = "-1";

                Chart.Refresh();

                return true;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranOnLineChart.ResetChart()\n" + ex.Message);
                return false;
            }

        }

        // ViewControlChart()
        //       - View Control Chart
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        public bool ViewControlChart()
        {

            try
            {
                TRSNode in_node = new TRSNode("View_ControlChart_In");
                TRSNode out_node;
                ArrayList a_list = new ArrayList();
               
                int i;
                int j;
                string sGroupIndex;
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

                InitChart();
                if (ResetChart() == false)
                {
                    return false;
                }

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '2';
                in_node.AddString("CHART_ID", cdvChartID.Text);
                in_node.AddInt("MAX_LOT_COUNT", MPCF.ToInt(txtMaxLotCount.Text));
                in_node.AddInt("NEXT_HIST_SEQ", 0);
                in_node.AddInt("NEXT_UNIT_SEQ", 0);

                dPrevUSL = StatGlobalVariable.DOUBLE_NULL_DATA;
                dPrevLSL = StatGlobalVariable.DOUBLE_NULL_DATA;
                dPrevUCL = StatGlobalVariable.DOUBLE_NULL_DATA;
                dPrevCL = StatGlobalVariable.DOUBLE_NULL_DATA;
                dPrevLCL = StatGlobalVariable.DOUBLE_NULL_DATA;
                dPrevUCL2 = StatGlobalVariable.DOUBLE_NULL_DATA;
                dPrevCL2 = StatGlobalVariable.DOUBLE_NULL_DATA;
                dPrevLCL2 = StatGlobalVariable.DOUBLE_NULL_DATA;

                dUSL = StatGlobalVariable.DOUBLE_NULL_DATA;
                dLSL = StatGlobalVariable.DOUBLE_NULL_DATA;
                dUCL = StatGlobalVariable.DOUBLE_NULL_DATA;
                dCL = StatGlobalVariable.DOUBLE_NULL_DATA;
                dLCL = StatGlobalVariable.DOUBLE_NULL_DATA;
                dUCL2 = StatGlobalVariable.DOUBLE_NULL_DATA;
                dCL2 = StatGlobalVariable.DOUBLE_NULL_DATA;
                dLCL2 = StatGlobalVariable.DOUBLE_NULL_DATA;
                dTarget = StatGlobalVariable.DOUBLE_NULL_DATA;

                if (this.chkAutoCalControlLimit.Checked == true)
                {
                    if (MPCF.Trim(ctrlChartData.USL) == "")
                    {
                        dUSL = StatGlobalVariable.DOUBLE_NULL_DATA;
                    }
                    else
                    {
                        dUSL = MPCF.ToDbl(ctrlChartData.USL);
                    }
                    if (MPCF.Trim(ctrlChartData.LSL) == "")
                    {
                        dLSL = StatGlobalVariable.DOUBLE_NULL_DATA;
                    }
                    else
                    {
                        dLSL = MPCF.ToDbl(ctrlChartData.LSL);
                    }
                }
                out_node = new TRSNode("View_ControlChart_Out");
                if (MPCR.CallService("SPC", "SPC_View_ControlChart", in_node, ref out_node) == false)
                {
                    return false;
                }
               
                for (i = out_node.GetList(0).Count - 1; i >= 0; i--)
                {
                    if (this.chkAutoCalControlLimit.Checked == false)
                    {
                        if (MPCF.Trim(out_node.GetList(0)[i].GetString("USL")) == "")
                        {
                            dUSL = StatGlobalVariable.DOUBLE_NULL_DATA;
                        }
                        else
                        {
                            dUSL = MPCF.ToDbl(out_node.GetList(0)[i].GetString("USL"));
                        }
                        if (MPCF.Trim(out_node.GetList(0)[i].GetString("LSL")) == "")
                        {
                            dLSL = StatGlobalVariable.DOUBLE_NULL_DATA;
                        }
                        else
                        {
                            dLSL = MPCF.ToDbl(out_node.GetList(0)[i].GetString("LSL"));
                        }

                        if (MPCF.Trim(out_node.GetList(0)[i].GetString("UCL")) == "")
                        {
                            dUCL = StatGlobalVariable.DOUBLE_NULL_DATA;
                        }
                        else
                        {
                            dUCL = MPCF.ToDbl(out_node.GetList(0)[i].GetString("UCL"));
                        }
                        if (MPCF.Trim(out_node.GetList(0)[i].GetString("CL")) == "")
                        {
                            dCL = StatGlobalVariable.DOUBLE_NULL_DATA;
                        }
                        else
                        {
                            dCL = MPCF.ToDbl(out_node.GetList(0)[i].GetString("CL"));
                        }
                        if (MPCF.Trim(out_node.GetList(0)[i].GetString("LCL")) == "")
                        {
                            dLCL = StatGlobalVariable.DOUBLE_NULL_DATA;
                        }
                        else
                        {
                            dLCL = MPCF.ToDbl(out_node.GetList(0)[i].GetString("LCL"));
                        }
                        if (MPCF.Trim(out_node.GetList(0)[i].GetString("UCL2")) == "")
                        {
                            dUCL2 = StatGlobalVariable.DOUBLE_NULL_DATA;
                        }
                        else
                        {
                            dUCL2 = MPCF.ToDbl(out_node.GetList(0)[i].GetString("UCL2"));
                        }
                        if (MPCF.Trim(out_node.GetList(0)[i].GetString("CL2")) == "")
                        {
                            dCL2 = StatGlobalVariable.DOUBLE_NULL_DATA;
                        }
                        else
                        {
                            dCL2 = MPCF.ToDbl(out_node.GetList(0)[i].GetString("CL2"));
                        }
                        if (MPCF.Trim(out_node.GetList(0)[i].GetString("UCL2")) == "")
                        {
                            dLCL2 = StatGlobalVariable.DOUBLE_NULL_DATA;
                        }
                        else
                        {
                            dLCL2 = MPCF.ToDbl(out_node.GetList(0)[i].GetString("LCL2"));
                        }
                    }
                    if (this.chkAutoCalControlLimit.Checked == true && (Chart.ChartType != SPCControlChart.modEnums.GRAPH_TYPE.P && Chart.ChartType != SPCControlChart.modEnums.GRAPH_TYPE.U))
                    {
                        if (Chart.ResvField2 == "-1" || dUSL != dPrevUSL || dLSL != dPrevLSL || dUCL != dPrevUCL || dCL != dPrevCL || dLCL != dPrevLCL || dUCL2 != dPrevUCL2 || dCL2 != dPrevCL2 || dLCL2 != dPrevLCL2)
                        {
                            Chart.ResvField2 = Convert.ToString(MPCF.ToInt(Chart.ResvField2) + 1);
                        }
                    }
                    else
                    {
                        Chart.ResvField2 = Convert.ToString(MPCF.ToInt(Chart.ResvField2) + 1);
                    }
                    sGroupIndex = "Group" + MPCF.ToInt(Chart.ResvField2).ToString("0000");
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

                    sLotIndex = "Lot" + MPCF.ToInt(Chart.ResvField3).ToString("0000");
                    sTranTime = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_TIME"));
                    if (ctrlChartData.LotorRes == "L")
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
                                dXData = StatGlobalVariable.DOUBLE_NULL_DATA;
                            }
                            else
                            {
                                dXData = MPCF.ToDbl(out_node.GetList(0)[i].GetString("AVERAGE"));
                            }

                            if ((MPCF.CheckNumeric(MPCF.Trim(out_node.GetList(0)[i].GetString("RANGE"))) == true ? MPCF.Trim(out_node.GetList(0)[i].GetString("RANGE")) : "") == "")
                            {
                                dRdata = StatGlobalVariable.DOUBLE_NULL_DATA;
                            }
                            else
                            {
                                dRdata = MPCF.ToDbl(out_node.GetList(0)[i].GetString("RANGE"));
                            }
                            break;
                        case SPCControlChart.modEnums.GRAPH_TYPE.XBARS:

                            if ((MPCF.CheckNumeric(MPCF.Trim(out_node.GetList(0)[i].GetString("AVERAGE"))) == true ? MPCF.Trim(out_node.GetList(0)[i].GetString("AVERAGE")) : "") == "")
                            {
                                dXData = StatGlobalVariable.DOUBLE_NULL_DATA;
                            }
                            else
                            {
                                dXData = MPCF.ToDbl(out_node.GetList(0)[i].GetString("AVERAGE"));
                            }

                            if ((MPCF.CheckNumeric(MPCF.Trim(out_node.GetList(0)[i].GetString("STDDEV"))) == true ? MPCF.Trim(out_node.GetList(0)[i].GetString("STDDEV")) : "") == "")
                            {
                                dRdata = StatGlobalVariable.DOUBLE_NULL_DATA;
                            }
                            else
                            {
                                dRdata = MPCF.ToDbl(out_node.GetList(0)[i].GetString("STDDEV"));
                            }
                            break;
                        case SPCControlChart.modEnums.GRAPH_TYPE.XRS:

                            if ((MPCF.CheckNumeric(MPCF.Trim(out_node.GetList(0)[i].GetString("AVERAGE"))) == true ? MPCF.Trim(out_node.GetList(0)[i].GetString("AVERAGE")) : "") == "")
                            {
                                dXData = StatGlobalVariable.DOUBLE_NULL_DATA;
                            }
                            else
                            {
                                dXData = MPCF.ToDbl(out_node.GetList(0)[i].GetString("AVERAGE"));
                            }

                            if ((MPCF.CheckNumeric(MPCF.Trim(out_node.GetList(0)[i].GetString("RANGE"))) == true ? MPCF.Trim(out_node.GetList(0)[i].GetString("RANGE")) : "") == "")
                            {
                                dRdata = StatGlobalVariable.DOUBLE_NULL_DATA;
                            }
                            else
                            {
                                dRdata = MPCF.ToDbl(out_node.GetList(0)[i].GetString("RANGE"));
                            }
                            break;
                        case SPCControlChart.modEnums.GRAPH_TYPE.P:

                            if ((MPCF.CheckNumeric(MPCF.Trim(out_node.GetList(0)[i].GetString("AVERAGE"))) == true ? MPCF.Trim(out_node.GetList(0)[i].GetString("AVERAGE")) : "") == "")
                            {
                                dXData = StatGlobalVariable.DOUBLE_NULL_DATA;
                            }
                            else
                            {
                                dXData = MPCF.ToDbl(out_node.GetList(0)[i].GetString("AVERAGE"));
                            }
                            dRdata = StatGlobalVariable.DOUBLE_NULL_DATA;
                            break;
                        case SPCControlChart.modEnums.GRAPH_TYPE.PN:

                            if ((MPCF.CheckNumeric(MPCF.Trim(out_node.GetList(0)[i].GetString("AVERAGE"))) == true ? MPCF.Trim(out_node.GetList(0)[i].GetString("AVERAGE")) : "") == "")
                            {
                                dXData = StatGlobalVariable.DOUBLE_NULL_DATA;
                            }
                            else
                            {
                                dXData = MPCF.ToDbl(out_node.GetList(0)[i].GetString("AVERAGE"));
                            }
                            dRdata = StatGlobalVariable.DOUBLE_NULL_DATA;
                            break;
                        case SPCControlChart.modEnums.GRAPH_TYPE.C:

                            if ((MPCF.CheckNumeric(MPCF.Trim(out_node.GetList(0)[i].GetString("AVERAGE"))) == true ? MPCF.Trim(out_node.GetList(0)[i].GetString("AVERAGE")) : "") == "")
                            {
                                dXData = StatGlobalVariable.DOUBLE_NULL_DATA;
                            }
                            else
                            {
                                dXData = MPCF.ToDbl(out_node.GetList(0)[i].GetString("AVERAGE"));
                            }
                            dRdata = StatGlobalVariable.DOUBLE_NULL_DATA;
                            break;
                        case SPCControlChart.modEnums.GRAPH_TYPE.U:

                            if ((MPCF.CheckNumeric(MPCF.Trim(out_node.GetList(0)[i].GetString("AVERAGE"))) == true ? MPCF.Trim(out_node.GetList(0)[i].GetString("AVERAGE")) : "") == "")
                            {
                                dXData = StatGlobalVariable.DOUBLE_NULL_DATA;
                            }
                            else
                            {
                                dXData = MPCF.ToDbl(out_node.GetList(0)[i].GetString("AVERAGE"));
                            }
                            dRdata = StatGlobalVariable.DOUBLE_NULL_DATA;
                            break;
                        case SPCControlChart.modEnums.GRAPH_TYPE.ZBARS:

                            if ((MPCF.CheckNumeric(MPCF.Trim(out_node.GetList(0)[i].GetString("WEIGHT_VALUE"))) == true ? MPCF.Trim(out_node.GetList(0)[i].GetString("WEIGHT_VALUE")) : "") == "")
                            {
                                dXData = StatGlobalVariable.DOUBLE_NULL_DATA;
                            }
                            else
                            {
                                dXData = MPCF.ToDbl(out_node.GetList(0)[i].GetString("WEIGHT_VALUE"));
                            }

                            if ((MPCF.CheckNumeric(MPCF.Trim(out_node.GetList(0)[i].GetString("STDDEV"))) == true ? MPCF.Trim(out_node.GetList(0)[i].GetString("STDDEV")) : "") == "")
                            {
                                dRdata = StatGlobalVariable.DOUBLE_NULL_DATA;
                            }
                            else
                            {
                                dRdata = MPCF.ToDbl(out_node.GetList(0)[i].GetString("STDDEV"));
                            }
                            break;
                        case SPCControlChart.modEnums.GRAPH_TYPE.DELTAS:

                            if ((MPCF.CheckNumeric(MPCF.Trim(out_node.GetList(0)[i].GetString("WEIGHT_VALUE"))) == true ? MPCF.Trim(out_node.GetList(0)[i].GetString("WEIGHT_VALUE")) : "") == "")
                            {
                                dXData = StatGlobalVariable.DOUBLE_NULL_DATA;
                            }
                            else
                            {
                                dXData = MPCF.ToDbl(out_node.GetList(0)[i].GetString("WEIGHT_VALUE"));
                            }

                            if ((MPCF.CheckNumeric(MPCF.Trim(out_node.GetList(0)[i].GetString("STDDEV"))) == true ? MPCF.Trim(out_node.GetList(0)[i].GetString("STDDEV")) : "") == "")
                            {
                                dRdata = StatGlobalVariable.DOUBLE_NULL_DATA;
                            }
                            else
                            {
                                dRdata = MPCF.ToDbl(out_node.GetList(0)[i].GetString("STDDEV"));
                            }
                            break;
                        default:

                            dXData = StatGlobalVariable.DOUBLE_NULL_DATA;
                            dRdata = StatGlobalVariable.DOUBLE_NULL_DATA;
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
                            dValue = StatGlobalVariable.DOUBLE_NULL_DATA;
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

                    Chart.ResvField3 = Convert.ToString(MPCF.ToInt(Chart.ResvField3) + 1);
                    //Chart.ResvField3++;

                }
                in_node.SetInt("NEXT_HIST_SEQ", out_node.GetInt("NEXT_HIST_SEQ"));
                in_node.SetInt("NEXT_UNIT_SEQ", out_node.GetInt("NEXT_UNIT_SEQ"));
               
                if (Chart.ChartType == SPCControlChart.modEnums.GRAPH_TYPE.DELTAS)
                {
                    Chart.IsViewSpecLimit = false;
                }

                if (Chart.RefreshChartData() == false)
                {
                    return false;
                }

                Chart.Refresh();

                return true;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranOnLineChart.ViewControlChart()\n" + ex.Message);
                return false;
            }

        }

        // ViewControlChart()
        //       - View Control Chart
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal bMonitering As Boolean : Monitoring Flag
        //
        public bool ViewControlChart(bool bMonitering)
        {

            try
            {
                string sPublishChannel = "";

                if (bMonitering == true)
                {
                    modSPCVariables.giTune++;
                    sPublishChannel = "/" + MPGV.gsSiteID;
                    sPublishChannel += "/SPC";
                    sPublishChannel += "/" + MPGV.gsFactory;
                    sPublishChannel += "/" + modSPCFunctions.ConvertAscii(MPCF.Trim(cdvChartID.Text));
                    sPublishChannel += "/" + modSPCVariables.giTune.ToString();
                    Chart.PublishChannel = sPublishChannel;

                    if (false == MPMH.tune(Chart.PublishChannel, true, false))
                    {
                        Chart.PublishChannel = "";
                        MPCF.ShowMsgBox("Message Tuning " + MPMH.StatusMessage);
                        return false;
                    }

                    if (ViewControlChart() == false)
                    {
                        ViewControlChart(false);
                        return false;
                    }
                }
                else
                {
                    if (Chart.PublishChannel != null && Chart.PublishChannel != "")
                    {
                        if (false == MPMH.untune(Chart.PublishChannel, true, false))
                        {
                            return false;
                        }
                    }
                }

                return true;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranOnLineChart.ViewControlChart()\n" + ex.Message);
                return false;
            }

        }

        public virtual Control GetFisrtFocusItem()
        {

            try
            {
                return this.cdvChartID;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }

        }

        private void ChartInfo()
        {

            try
            {
                cdvChartID_SelectedItemChanged(null, null);

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranOnLineChart.ChartInfo()\n" + ex.Message);
            }

        }

        #endregion

        #region " Event Implematations"

        private void frmSPCTranOnLineChart_Load(object sender, System.EventArgs e)
        {

            try
            {
                MPGV.gIBaseFormEvent.Form_Load(this, e);
                MPCF.SetTextboxStyle(this.Controls);

                MPCF.FieldClear(this.grpTop);
                modSPCFunctions.SetGraphList(cboGraphType);
                InitChart();
                cdvChartID.Text = modSPCFunctions.GetFilterKey();

                Chart.ContextMenu.MenuItems[1].Enabled = modSPCFunctions.CheckAvailableFunction("SPC5001");
                Chart.ContextMenu.MenuItems[0].Enabled = modSPCFunctions.CheckAvailableFunction("SPC4003");


            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranOnLineChart.frmSPCTranOnLineChart_Load()\n" + ex.Message);
            }

        }

        private void frmSPCTranOnLineChart_Activated(object sender, System.EventArgs e)
        {

            try
            {
                if (b_load_flag == false)
                {
                    if (MPCF.Trim(MPGV.gsChartID) != "")
                    {
                        cdvChartID.Text = MPGV.gsChartID;
                        ChartInfo();
                    }
                    b_load_flag = true;
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranOnLineChart.frmSPCTranOnLineChart_Activated()\n" + ex.Message);
            }

        }

        private void cdvChartID_ButtonPress(System.Object sender, System.EventArgs e)
        {

            try
            {
                cdvChartID.Init();
                MPCF.InitListView(cdvChartID.GetListView);
                cdvChartID.Columns.Add("Chart", 50, HorizontalAlignment.Left);
                cdvChartID.Columns.Add("GraphType", 50, HorizontalAlignment.Left);
                cdvChartID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvChartID.SelectedSubItemIndex = 0;
                cdvChartID.SelectedDescIndex = 2;
                SPCLIST.ViewChartList(cdvChartID.GetListView, '2', "", 0, "", "", "", ' ', ' ', MPCF.Trim(cdvChartID.Text), "", -1, -1, null, "");
                cdvChartID.AddEmptyRow(1);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranOnLineChart.cdvChartID_ButtonPress()\n" + ex.Message);
            }

        }

        private void cdvChartID_SelectedItemChanged(object sender, UI.MCCodeViewSelChanged_EventArgs e)
        {

            try
            {
                bool bRet = false;

                if (cdvChartID.Text == "")
                {
                    return;
                }
                bRet = ctrlChartData.ViewChartInformation(cdvChartID.Text, true);
                if (bRet == false)
                {
                    return;
                }

                cboGraphType.SelectedIndex = (int)Enum.Parse(typeof(eGraphType), ctrlChartData.ChartGraphType);                
                if (SetChartOptions() == false)
                {
                    return;
                }
                InitChart();

                Chart.ResvField1 = ctrlChartData.LotorRes;

                string sRuleType = MPCF.Trim(ctrlChartData.spdChartInfo.Sheets[0].Cells[4, 5].Value);
                if (sRuleType != "")
                {
                    string[] arrRuleType = sRuleType.Split('/');
                    string sXRuleType;
                    string sRRuleType;
                    int i;
                    sXRuleType = "";
                    sRRuleType = "";
                    for (i = 0; i <= arrRuleType[0].ToString().Length - 1; i++)
                    {
                        string sRule = arrRuleType[0].Substring(i, 1);
                        if (sRule != "_" && sRule != " ")
                        {
                            sXRuleType += "Y";
                        }
                        else                        {
                            sXRuleType += " ";
                        }
                    }
                    if (arrRuleType.Length > 1)
                    {
                        for (i = 0; i <= arrRuleType[1].Length - 1; i++)
                        {
                            string sRule = arrRuleType[1].Substring(i, 1);
                            if (sRule != "_" && sRule != " ")
                            {
                                sRRuleType += "Y";
                            }
                            else
                            {
                                sXRuleType += " ";
                            }
                        }
                    }
                    Chart.XRuleType = sXRuleType;
                    Chart.RRuleType = sRRuleType;
                }

                if (ResetChart() == false)
                {
                    return;
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranOnLineChart.cdvChartID_SelectedItemChanged()\n" + ex.Message);
            }

        }

        private void btnMonitoring_Click(System.Object sender, System.EventArgs e)
        {

            try
            {
                if (MPCF.Trim(btnMonitoring.Tag) == "M")
                {
                    if (CheckCondition() == false)
                    {
                        return;
                    }
                    if (ViewControlChart(true) == false)
                    {
                        return;
                    }
                    cdvChartID.Enabled = false;
                    btnMonitoring.Text = MPCF.FindLanguage("Stop", 1);
                    btnMonitoring.Tag = "S";
                    txtMaxLotCount.Enabled = false;
                    chkAutoCalControlLimit.Enabled = false;
                }
                else if (MPCF.Trim(btnMonitoring.Tag) == "S")
                {
                    Chart.IsOnLineStop = true;
                    btnMonitoring.Text = MPCF.FindLanguage("Monitoring", 1);
                    btnMonitoring.Tag = "M";
                    cdvChartID.Enabled = true;
                    txtMaxLotCount.Enabled = true;
                    chkAutoCalControlLimit.Enabled = true;
                    if (ViewControlChart(false) == false)
                    {
                        return;
                    }
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranOnLineChart.btnMonitoring_Click()\n" + ex.Message);
            }

        }

        private void chkViewLotID_CheckedChanged(System.Object sender, System.EventArgs e)
        {

            try
            {
                Chart.IsViewLotID = chkViewLotID.Checked;
                Chart.Refresh();

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranOnLineChart.chkViewLotID_CheckedChanged()\n" + ex.Message);
            }

        }

        private void chkViewDate_CheckedChanged(System.Object sender, System.EventArgs e)
        {

            try
            {
                Chart.IsViewDate = chkViewDate.Checked;
                Chart.Refresh();

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranOnLineChart.chkViewDate_CheckedChanged()\n" + ex.Message);
            }

        }

        private void chkViewSpecLimit_CheckedChanged(System.Object sender, System.EventArgs e)
        {

            try
            {
                Chart.IsViewSpecLimit = chkViewSpecLimit.Checked;
                Chart.Refresh();

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranOnLineChart.chkViewSpecLimit_CheckedChanged()\n" + ex.Message);
            }

        }

        private void chkViewRChart_CheckedChanged(System.Object sender, System.EventArgs e)
        {

            try
            {
                Chart.IsViewRChart = chkViewRChart.Checked;
                Chart.Refresh();

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranOnLineChart.chkViewRChart_CheckedChanged()\n" + ex.Message);
            }

        }

        private void chkViewAZone_CheckedChanged(System.Object sender, System.EventArgs e)
        {

            try
            {
                Chart.IsViewAZone = chkViewAZone.Checked;
                Chart.Refresh();

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranOnLineChart.chkViewAZone_CheckedChanged()\n" + ex.Message);
            }

        }

        private void chkViewBZone_CheckedChanged(System.Object sender, System.EventArgs e)
        {

            try
            {
                Chart.IsViewBZone = chkViewBZone.Checked;
                Chart.Refresh();

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranOnLineChart.chkViewBZone_CheckedChanged()\n" + ex.Message);
            }

        }

        private void chkViewCZone_CheckedChanged(System.Object sender, System.EventArgs e)
        {

            try
            {
                Chart.IsViewCZone = chkViewCZone.Checked;
                Chart.Refresh();

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranOnLineChart.chkViewCZone_CheckedChanged()\n" + ex.Message);
            }

        }

        private void chkViewRuleCheck_CheckedChanged(System.Object sender, System.EventArgs e)
        {

            try
            {
                Chart.IsViewRunTestText = chkViewRuleCheck.Checked;
                Chart.Refresh();

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranOnLineChart.chkViewRuleCheck_CheckedChanged()\n" + ex.Message);
            }

        }

        private void btnClose_Click(object sender, System.EventArgs e)
        {

            try
            {
                ViewControlChart(false);
                this.Dispose();

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranOnLineChart.btnClose_Click()\n" + ex.Message);
            }

        }

        private void Chart_MouseButtonDown(object sender, SPCControlChart.MouseButtonDown_EventArgs e)
        {

            try
            {
                //ShowMsgBox(e.SelRegion & " " & e.LotID & " " & e.TransTime & " " & e.HistSeq & " " & e.UnitSeq)

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranOnLineChart.Chart_MouseButtonDown()\n" + ex.Message);
            }

        }

        private void frmSPCTranOnLineChart_Closed(object sender, System.EventArgs e)
        {

            try
            {

                if (ViewControlChart(false) == false)
                {
                    return;
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranOnLineChart.frmSPCTranOnLineChart_Closed()\n" + ex.Message);
            }

        }

        private void btnRedraw_Click(System.Object sender, System.EventArgs e)
        {

            try
            {
                if (MPCF.CheckNumeric(this.txtMaxLotCount.Text) == false)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(116));
                    this.txtMaxLotCount.SelectAll();
                    this.txtMaxLotCount.Focus();
                    return;
                }
                else
                {
                    if (MPCF.ToInt(this.txtMaxLotCount.Text) <= 0)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(116));
                        this.txtMaxLotCount.SelectAll();
                        this.txtMaxLotCount.Focus();
                        return;
                    }
                    if (MPCF.ToInt(this.txtMaxLotCount.Text) > 100)
                    {
                        if (MPGV.gcLanguage == '2')
                        {
                            MPCF.ShowMsgBox(MPCF.GetErrorMsgParse(236, "\'100\' ") + MPCF.GetMessage(236));
                        }
                        else
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(236) + " \'100\'");
                        }
                        this.txtMaxLotCount.SelectAll();
                        this.txtMaxLotCount.Focus();
                        return;
                    }
                }

                Chart.MaxLotCount = MPCF.ToInt(this.txtMaxLotCount.Text);
                Chart.StartLotPos = 0;
                Chart.IsZoomChart = false;
                Chart.Refresh();

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranOnLineChart.btnRedraw_Click()\n" + ex.Message);
            }

        }

        private void btnRefresh_Click(object sender, System.EventArgs e)
        {

            try
            {
                InitChart();
                if (cdvChartID.Text == "")
                {
                    return;
                }
                if (ctrlChartData.ViewChartInformation(cdvChartID.Text, true) == false)
                {
                    return;
                }
                cboGraphType.SelectedIndex = (int)Enum.Parse(typeof(eGraphType), ctrlChartData.ChartGraphType);
                Chart.ResvField1 = ctrlChartData.LotorRes;

                Chart.IsOnLineStop = true;
                btnMonitoring.Text = "Monitoring";
                btnMonitoring.Tag = "M";
                cdvChartID.Enabled = true;
                if (ViewControlChart(false) == false)
                {
                    return;
                }

                if (SetChartOptions() == false)
                {
                    return;
                }
                if (ResetChart() == false)
                {
                    return;
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranOnLineChart.btnRefresh_Click()\n" + ex.Message);
            }

        }

        private void txtMaxLotCount_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {

            try
            {
                if (e.KeyChar != (char)13 && e.KeyChar != (char)8)
                {
                    if (e.KeyChar < (char)48 || e.KeyChar > (char)57)
                    {
                        if (e.KeyChar == (char)46)
                        {
                            if (((UltraTextEditor)sender).Text == "" || ((UltraTextEditor)sender).Text.Contains(".") == true)
                            {
                                e.Handled = true;
                            }
                        }
                        else
                        {
                            e.Handled = true;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranOnLineChart.txtMaxLotCount_KeyPress()\n" + ex.Message);
            }

        }

        private void Chart_ViewOOCInfo(object sender, SPCControlChart.MouseButtonDown_EventArgs e)
        {

            try
            {
                frmSPCTranUpdateOOCHistory form = new frmSPCTranUpdateOOCHistory();
                form.gcStep = '2';
                form.txtChart.Text = cdvChartID.Text;
                form.giEDCHistSeq = e.HistSeq;
                form.giUnitSeq = e.UnitSeq;
                if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    // Nothing
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranOnLineChart.Chart_ViewOOCInfo()\n" + ex.Message);
            }

        }

        private void Chart_ChangeEDCData(object sender, SPCControlChart.MouseButtonDown_EventArgs e)
        {

            try
            {
                int i;
                System.Windows.Forms.Form form;

                try
                {
                    form = MPCF.GetChildForm(MPGV.gfrmMDI, "frmSPCTranChangeEDCData");
                    if (form == null)
                    {
                        form = new frmSPCTranChangeEDCData();
                        form.MdiParent = MPGV.gfrmMDI;
                        form.Show();
                    }
                    else
                    {
                        form.Activate();
                    }
                }
                catch (Exception ex)
                {
                    MPCF.ShowMsgBox(ex.Message);
                    return;
                }

                DateTime dtTranTime = new DateTime(MPCF.ToInt(MPCF.Mid(e.TransTime, 0, 4)), MPCF.ToInt(MPCF.Mid(e.TransTime, 4, 2)), MPCF.ToInt(MPCF.Mid(e.TransTime, 6, 2))
                    , MPCF.ToInt(MPCF.Mid(e.TransTime, 8, 2)), MPCF.ToInt(MPCF.Mid(e.TransTime, 10, 2)), MPCF.ToInt(MPCF.Mid(e.TransTime, 12, 2)));


                ((frmSPCTranChangeEDCData)form).uccStart.Value = dtTranTime;
                ((frmSPCTranChangeEDCData)form).udtStart.Value = "000000";
                ((frmSPCTranChangeEDCData)form).uccEnd.Value = dtTranTime;
                ((frmSPCTranChangeEDCData)form).udtEnd.Value = "235959";
                ((frmSPCTranChangeEDCData)form).cdvChartID.Text = this.cdvChartID.Text;
                if (((frmSPCTranChangeEDCData)form).cdvChartID.Text != "")
                {
                    ((frmSPCTranChangeEDCData)form).cdvChartID.Text = cdvChartID.Text;
                    ((frmSPCTranChangeEDCData)form).ChartSelected();
                    ((frmSPCTranChangeEDCData)form).btnView.PerformClick();

                    for (i = 0; i <= ((frmSPCTranChangeEDCData)form).spdData.Sheets[0].RowCount - 1; i++)
                    {
                        if ((int)((frmSPCTranChangeEDCData)form).spdData.Sheets[0].Cells[i, 1].Value == e.HistSeq
                            && (int)((frmSPCTranChangeEDCData)form).spdData.Sheets[0].Cells[i, 2].Value == e.UnitSeq)
                        {
                            ((frmSPCTranChangeEDCData)form).spdData.Sheets[0].ActiveRowIndex = i;
                            ((frmSPCTranChangeEDCData)form).spdData.Sheets[0].AddSelection(i, 0, 1, ((frmSPCTranChangeEDCData)form).spdData.Sheets[0].ColumnCount);
                            ((frmSPCTranChangeEDCData)form).spdData.ShowActiveCell(FarPoint.Win.Spread.VerticalPosition.Top, FarPoint.Win.Spread.HorizontalPosition.Left);
                            ((frmSPCTranChangeEDCData)form).ViewSelectData(i);
                            return;
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranOnLineChart.Chart_ChangeEDCData()\n" + ex.Message);
            }

        }

        private void btnCopyImage_Click(System.Object sender, System.EventArgs e)
        {

            try
            {
                if (Chart.CopyImage() == true)
                {
                    //Do Nothing
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranOnLineChart.btnCopyImage_Click()\n" + ex.Message);
            }

        }

        private void btnSaveImage_Click(System.Object sender, System.EventArgs e)
        {

            try
            {
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.Filter = "Png Image|*.png";
                dlg.Title = "Save an Image File";
                if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    Chart.SaveImage(dlg.FileName);
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranOnLineChart.btnSaveImage_Click()\n" + ex.Message);
            }

        }

        private void btnPrint_Click(System.Object sender, System.EventArgs e)
        {

            try
            {
                if (Chart.Print() == true)
                {
                    //Do Nothing
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranOnLineChart.btnPrint_Click()\n" + ex.Message);
            }

        }

        private void btnFiltering_Click(System.Object sender, System.EventArgs e)
        {

            try
            {
                if (cdvChartID.Enabled == false)
                {
                    return;
                }
                frmSPCViewChartList form = new frmSPCViewChartList();
                form.StartPosition = FormStartPosition.CenterParent;
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    if (form.lisChart.SelectedItems.Count > 0)
                    {
                        cdvChartID.Text = form.lisChart.SelectedItems[0].SubItems[1].Text;
                        ChartInfo();
                    }
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranOnLineChart.btnFiltering_Click()\n" + ex.Message);
            }

        }

        private void cdvChartID_TextBoxKeyPress(object sender, KeyPressEventArgs e)
        {

            try
            {
                if (e.KeyChar == (char)13)
                {
                    if (cdvChartID.Text != "")
                    {
                        ChartInfo();                        
                    }
                }


            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranOnLineChart.cdvChartID_TextBoxKeyPress()\n" + ex.Message);
            }

        }

        #endregion

    }


    //#End If

}
