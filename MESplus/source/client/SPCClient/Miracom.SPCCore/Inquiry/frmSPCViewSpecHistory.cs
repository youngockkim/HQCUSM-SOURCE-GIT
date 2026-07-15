
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
using Miracom.TRSCore;
//#If _SPC = True Then

//-----------------------------------------------------------------------------
//
//   System      : SPCClient
//   File Name   : frmSPCViewSpecHistory.vb
//   Description : View Spec History
//
//   MES Version : 1.0.0
//
//   Function List
//       - CheckCondition() : Check the Conditions before Transaction
//       - View_Spec_History() : View Spec History
//
//
//   Detail Description
//       -
//       -
//
//   History
//       - 2005-05-30 : Created by H.K.Kim
//
//
//   Copyright(C) 1998-2004 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------
namespace Miracom.SPCCore
{
    public class frmSPCViewSpecHistory : System.Windows.Forms.Form
    {
        
        #region " Windows Form auto generated code "
        
        public frmSPCViewSpecHistory()
        {
            
            
            InitializeComponent();
            
            
            
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
        



        internal System.Windows.Forms.Panel pnlBottom;
        internal System.Windows.Forms.Button btnView;
        internal System.Windows.Forms.Button btnClose;
        internal System.Windows.Forms.Panel pnlTop;
        internal System.Windows.Forms.GroupBox grpTop;
        internal System.Windows.Forms.Label lblGraphType;
        internal Infragistics.Win.UltraWinEditors.UltraComboEditor cboGraphType;
        internal System.Windows.Forms.Label lblPeriod;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvChartID;
        internal System.Windows.Forms.Label lblChartID;
        internal System.Windows.Forms.Panel pnlMidTop;
        internal System.Windows.Forms.Panel pnlData;
        private FarPoint.Win.Spread.FpSpread spdData;
        internal FarPoint.Win.Spread.SheetView spdData_Sheet1;
        internal Infragistics.Win.UltraWinEditors.UltraCheckEditor chkPeriod;
        internal Infragistics.Win.UltraWinEditors.UltraComboEditor cboMonth;
        internal Infragistics.Win.UltraWinEditors.UltraNumericEditor uneYear;
        internal Infragistics.Win.UltraWinEditors.UltraTextEditor txtPeriod;
        internal Infragistics.Win.UltraWinEditors.UltraCheckEditor chkIncludeRelease;
        internal System.Windows.Forms.GroupBox grpChartInfo;
        internal System.Windows.Forms.Button btnRefresh;
        public System.Windows.Forms.Button btnExcel;
        internal Miracom.SPCCore.udcChart ctrlChartData;
        internal System.Windows.Forms.Button btnFiltering;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvChartSetID;
        internal System.Windows.Forms.Label lblChartSet;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSPCViewSpecHistory));
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem3 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem4 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem5 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem6 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem7 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem8 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem9 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem10 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem11 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem12 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer2 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer3 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer4 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnExcel = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnView = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.grpTop = new System.Windows.Forms.GroupBox();
            this.cdvChartSetID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblChartSet = new System.Windows.Forms.Label();
            this.btnFiltering = new System.Windows.Forms.Button();
            this.chkIncludeRelease = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.txtPeriod = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.uneYear = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.cboMonth = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.chkPeriod = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.lblGraphType = new System.Windows.Forms.Label();
            this.cboGraphType = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.lblPeriod = new System.Windows.Forms.Label();
            this.cdvChartID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblChartID = new System.Windows.Forms.Label();
            this.pnlMidTop = new System.Windows.Forms.Panel();
            this.grpChartInfo = new System.Windows.Forms.GroupBox();
            this.ctrlChartData = new Miracom.SPCCore.udcChart();
            this.pnlData = new System.Windows.Forms.Panel();
            this.spdData = new FarPoint.Win.Spread.FpSpread();
            this.spdData_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.pnlBottom.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.grpTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChartSetID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIncludeRelease)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPeriod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uneYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMonth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkPeriod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboGraphType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChartID)).BeginInit();
            this.pnlMidTop.SuspendLayout();
            this.grpChartInfo.SuspendLayout();
            this.pnlData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdData_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnExcel);
            this.pnlBottom.Controls.Add(this.btnRefresh);
            this.pnlBottom.Controls.Add(this.btnView);
            this.pnlBottom.Controls.Add(this.btnClose);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 506);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(742, 40);
            this.pnlBottom.TabIndex = 3;
            // 
            // btnExcel
            // 
            this.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExcel.Image")));
            this.btnExcel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnExcel.Location = new System.Drawing.Point(36, 8);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(24, 24);
            this.btnExcel.TabIndex = 3;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
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
            // btnView
            // 
            this.btnView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnView.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnView.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnView.Location = new System.Drawing.Point(558, 7);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(88, 26);
            this.btnView.TabIndex = 0;
            this.btnView.Text = "View";
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnClose.Location = new System.Drawing.Point(650, 7);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(88, 26);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.grpTop);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.pnlTop.Size = new System.Drawing.Size(742, 96);
            this.pnlTop.TabIndex = 0;
            // 
            // grpTop
            // 
            this.grpTop.Controls.Add(this.cdvChartSetID);
            this.grpTop.Controls.Add(this.lblChartSet);
            this.grpTop.Controls.Add(this.btnFiltering);
            this.grpTop.Controls.Add(this.chkIncludeRelease);
            this.grpTop.Controls.Add(this.txtPeriod);
            this.grpTop.Controls.Add(this.uneYear);
            this.grpTop.Controls.Add(this.cboMonth);
            this.grpTop.Controls.Add(this.chkPeriod);
            this.grpTop.Controls.Add(this.lblGraphType);
            this.grpTop.Controls.Add(this.cboGraphType);
            this.grpTop.Controls.Add(this.lblPeriod);
            this.grpTop.Controls.Add(this.cdvChartID);
            this.grpTop.Controls.Add(this.lblChartID);
            this.grpTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpTop.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpTop.Location = new System.Drawing.Point(3, 0);
            this.grpTop.Name = "grpTop";
            this.grpTop.Size = new System.Drawing.Size(736, 96);
            this.grpTop.TabIndex = 0;
            this.grpTop.TabStop = false;
            // 
            // cdvChartSetID
            // 
            this.cdvChartSetID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvChartSetID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvChartSetID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvChartSetID.BtnToolTipText = "";
            this.cdvChartSetID.DescText = "";
            this.cdvChartSetID.DisplaySubItemIndex = -1;
            this.cdvChartSetID.DisplayText = "";
            this.cdvChartSetID.Focusing = null;
            this.cdvChartSetID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvChartSetID.Index = 0;
            this.cdvChartSetID.IsViewBtnImage = false;
            this.cdvChartSetID.Location = new System.Drawing.Point(120, 17);
            this.cdvChartSetID.MaxLength = 30;
            this.cdvChartSetID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvChartSetID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvChartSetID.Name = "cdvChartSetID";
            this.cdvChartSetID.ReadOnly = false;
            this.cdvChartSetID.SearchSubItemIndex = 0;
            this.cdvChartSetID.SelectedDescIndex = -1;
            this.cdvChartSetID.SelectedSubItemIndex = -1;
            this.cdvChartSetID.SelectionStart = 0;
            this.cdvChartSetID.Size = new System.Drawing.Size(200, 20);
            this.cdvChartSetID.SmallImageList = null;
            this.cdvChartSetID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvChartSetID.TabIndex = 1;
            this.cdvChartSetID.TextBoxToolTipText = "";
            this.cdvChartSetID.TextBoxWidth = 200;
            this.cdvChartSetID.VisibleButton = true;
            this.cdvChartSetID.VisibleColumnHeader = false;
            this.cdvChartSetID.VisibleDescription = false;
            this.cdvChartSetID.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvChartSetID_SelectedItemChanged);
            this.cdvChartSetID.ButtonPress += new System.EventHandler(this.cdvChartSetID_ButtonPress);
            this.cdvChartSetID.TextBoxTextChanged += new System.EventHandler(this.cdvChartSetID_TextBoxTextChanged);
            // 
            // lblChartSet
            // 
            this.lblChartSet.AutoSize = true;
            this.lblChartSet.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblChartSet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChartSet.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblChartSet.Location = new System.Drawing.Point(15, 20);
            this.lblChartSet.Name = "lblChartSet";
            this.lblChartSet.Size = new System.Drawing.Size(65, 13);
            this.lblChartSet.TabIndex = 0;
            this.lblChartSet.Text = "Chart Set ID";
            // 
            // btnFiltering
            // 
            this.btnFiltering.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFiltering.Image = ((System.Drawing.Image)(resources.GetObject("btnFiltering.Image")));
            this.btnFiltering.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnFiltering.Location = new System.Drawing.Point(324, 39);
            this.btnFiltering.Name = "btnFiltering";
            this.btnFiltering.Size = new System.Drawing.Size(24, 24);
            this.btnFiltering.TabIndex = 4;
            this.btnFiltering.Click += new System.EventHandler(this.btnFiltering_Click);
            // 
            // chkIncludeRelease
            // 
            this.chkIncludeRelease.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkIncludeRelease.AutoSize = true;
            this.chkIncludeRelease.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkIncludeRelease.Location = new System.Drawing.Point(554, 42);
            this.chkIncludeRelease.Name = "chkIncludeRelease";
            this.chkIncludeRelease.Size = new System.Drawing.Size(176, 17);
            this.chkIncludeRelease.TabIndex = 11;
            this.chkIncludeRelease.Text = "Include unreleased version";
            this.chkIncludeRelease.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            // 
            // txtPeriod
            // 
            this.txtPeriod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPeriod.Location = new System.Drawing.Point(628, 17);
            this.txtPeriod.MaxLength = 20;
            this.txtPeriod.Name = "txtPeriod";
            this.txtPeriod.ReadOnly = true;
            this.txtPeriod.Size = new System.Drawing.Size(100, 20);
            this.txtPeriod.TabIndex = 9;
            // 
            // uneYear
            // 
            this.uneYear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.uneYear.Location = new System.Drawing.Point(629, 17);
            this.uneYear.MaskInput = "nnnn";
            this.uneYear.MaxValue = 9998;
            this.uneYear.MinValue = 1;
            this.uneYear.Name = "uneYear";
            this.uneYear.Size = new System.Drawing.Size(52, 21);
            this.uneYear.SpinButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.Always;
            this.uneYear.SpinWrap = true;
            this.uneYear.TabIndex = 5;
            this.uneYear.Value = 2005;
            // 
            // cboMonth
            // 
            this.cboMonth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cboMonth.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            appearance1.TextHAlignAsString = "Right";
            valueListItem1.Appearance = appearance1;
            valueListItem1.DataValue = "ValueListItem0";
            valueListItem1.DisplayText = "1";
            appearance2.TextHAlignAsString = "Right";
            valueListItem2.Appearance = appearance2;
            valueListItem2.DataValue = "ValueListItem1";
            valueListItem2.DisplayText = "2";
            appearance3.TextHAlignAsString = "Right";
            valueListItem3.Appearance = appearance3;
            valueListItem3.DataValue = "ValueListItem2";
            valueListItem3.DisplayText = "3";
            appearance4.TextHAlignAsString = "Right";
            valueListItem4.Appearance = appearance4;
            valueListItem4.DataValue = "ValueListItem3";
            valueListItem4.DisplayText = "4";
            appearance5.TextHAlignAsString = "Right";
            valueListItem5.Appearance = appearance5;
            valueListItem5.DataValue = "ValueListItem4";
            valueListItem5.DisplayText = "5";
            appearance6.TextHAlignAsString = "Right";
            valueListItem6.Appearance = appearance6;
            valueListItem6.DataValue = "ValueListItem5";
            valueListItem6.DisplayText = "6";
            appearance7.TextHAlignAsString = "Right";
            valueListItem7.Appearance = appearance7;
            valueListItem7.DataValue = "ValueListItem6";
            valueListItem7.DisplayText = "7";
            appearance8.TextHAlignAsString = "Right";
            valueListItem8.Appearance = appearance8;
            valueListItem8.DataValue = "ValueListItem7";
            valueListItem8.DisplayText = "8";
            appearance9.TextHAlignAsString = "Right";
            valueListItem9.Appearance = appearance9;
            valueListItem9.DataValue = "ValueListItem8";
            valueListItem9.DisplayText = "9";
            appearance10.TextHAlignAsString = "Right";
            valueListItem10.Appearance = appearance10;
            valueListItem10.DataValue = "ValueListItem9";
            valueListItem10.DisplayText = "10";
            appearance11.TextHAlignAsString = "Right";
            valueListItem11.Appearance = appearance11;
            valueListItem11.DataValue = "ValueListItem10";
            valueListItem11.DisplayText = "11";
            appearance12.TextHAlignAsString = "Right";
            valueListItem12.Appearance = appearance12;
            valueListItem12.DataValue = "ValueListItem11";
            valueListItem12.DisplayText = "12";
            this.cboMonth.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem1,
            valueListItem2,
            valueListItem3,
            valueListItem4,
            valueListItem5,
            valueListItem6,
            valueListItem7,
            valueListItem8,
            valueListItem9,
            valueListItem10,
            valueListItem11,
            valueListItem12});
            this.cboMonth.Location = new System.Drawing.Point(681, 17);
            this.cboMonth.Name = "cboMonth";
            this.cboMonth.Size = new System.Drawing.Size(42, 21);
            this.cboMonth.TabIndex = 10;
            // 
            // chkPeriod
            // 
            this.chkPeriod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkPeriod.AutoSize = true;
            this.chkPeriod.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkPeriod.Location = new System.Drawing.Point(554, 20);
            this.chkPeriod.Name = "chkPeriod";
            this.chkPeriod.Size = new System.Drawing.Size(14, 13);
            this.chkPeriod.TabIndex = 7;
            this.chkPeriod.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.chkPeriod.CheckedChanged += new System.EventHandler(this.chkPeriod_CheckedChanged);
            // 
            // lblGraphType
            // 
            this.lblGraphType.AutoSize = true;
            this.lblGraphType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblGraphType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGraphType.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblGraphType.Location = new System.Drawing.Point(15, 67);
            this.lblGraphType.Name = "lblGraphType";
            this.lblGraphType.Size = new System.Drawing.Size(63, 13);
            this.lblGraphType.TabIndex = 5;
            this.lblGraphType.Text = "Graph Type";
            // 
            // cboGraphType
            // 
            this.cboGraphType.DropDownButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.Never;
            this.cboGraphType.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cboGraphType.Location = new System.Drawing.Point(120, 65);
            this.cboGraphType.Name = "cboGraphType";
            this.cboGraphType.ReadOnly = true;
            this.cboGraphType.Size = new System.Drawing.Size(200, 19);
            this.cboGraphType.TabIndex = 6;
            this.cboGraphType.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            // 
            // lblPeriod
            // 
            this.lblPeriod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPeriod.AutoSize = true;
            this.lblPeriod.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblPeriod.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPeriod.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblPeriod.Location = new System.Drawing.Point(570, 20);
            this.lblPeriod.Name = "lblPeriod";
            this.lblPeriod.Size = new System.Drawing.Size(37, 13);
            this.lblPeriod.TabIndex = 8;
            this.lblPeriod.Text = "Period";
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
            this.cdvChartID.Location = new System.Drawing.Point(120, 41);
            this.cdvChartID.MaxLength = 30;
            this.cdvChartID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvChartID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvChartID.Name = "cdvChartID";
            this.cdvChartID.ReadOnly = false;
            this.cdvChartID.SearchSubItemIndex = 0;
            this.cdvChartID.SelectedDescIndex = -1;
            this.cdvChartID.SelectedSubItemIndex = -1;
            this.cdvChartID.SelectionStart = 0;
            this.cdvChartID.Size = new System.Drawing.Size(200, 20);
            this.cdvChartID.SmallImageList = null;
            this.cdvChartID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvChartID.TabIndex = 3;
            this.cdvChartID.TextBoxToolTipText = "";
            this.cdvChartID.TextBoxWidth = 200;
            this.cdvChartID.VisibleButton = true;
            this.cdvChartID.VisibleColumnHeader = false;
            this.cdvChartID.VisibleDescription = false;
            this.cdvChartID.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvChartID_SelectedItemChanged);
            this.cdvChartID.ButtonPress += new System.EventHandler(this.cdvChartID_ButtonPress);
            this.cdvChartID.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvChartID_TextBoxKeyPress);
            this.cdvChartID.TextBoxTextChanged += new System.EventHandler(this.cdvChartID_TextBoxTextChanged);
            // 
            // lblChartID
            // 
            this.lblChartID.AutoSize = true;
            this.lblChartID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblChartID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChartID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblChartID.Location = new System.Drawing.Point(15, 44);
            this.lblChartID.Name = "lblChartID";
            this.lblChartID.Size = new System.Drawing.Size(46, 13);
            this.lblChartID.TabIndex = 2;
            this.lblChartID.Text = "Chart ID";
            // 
            // pnlMidTop
            // 
            this.pnlMidTop.Controls.Add(this.grpChartInfo);
            this.pnlMidTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMidTop.Location = new System.Drawing.Point(0, 96);
            this.pnlMidTop.Name = "pnlMidTop";
            this.pnlMidTop.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.pnlMidTop.Size = new System.Drawing.Size(742, 102);
            this.pnlMidTop.TabIndex = 1;
            // 
            // grpChartInfo
            // 
            this.grpChartInfo.Controls.Add(this.ctrlChartData);
            this.grpChartInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpChartInfo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpChartInfo.Location = new System.Drawing.Point(3, 0);
            this.grpChartInfo.Name = "grpChartInfo";
            this.grpChartInfo.Size = new System.Drawing.Size(736, 98);
            this.grpChartInfo.TabIndex = 0;
            this.grpChartInfo.TabStop = false;
            // 
            // ctrlChartData
            // 
            this.ctrlChartData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlChartData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlChartData.Location = new System.Drawing.Point(3, 16);
            this.ctrlChartData.Name = "ctrlChartData";
            this.ctrlChartData.Size = new System.Drawing.Size(730, 79);
            this.ctrlChartData.SyncEDCFlag = ' ';
            this.ctrlChartData.TabIndex = 0;
            // 
            // pnlData
            // 
            this.pnlData.Controls.Add(this.spdData);
            this.pnlData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlData.Location = new System.Drawing.Point(0, 198);
            this.pnlData.Name = "pnlData";
            this.pnlData.Padding = new System.Windows.Forms.Padding(3);
            this.pnlData.Size = new System.Drawing.Size(742, 308);
            this.pnlData.TabIndex = 2;
            // 
            // spdData
            // 
            this.spdData.AccessibleDescription = "spdData, Sheet1, Row 0, Column 0, ";
            this.spdData.BackColor = System.Drawing.SystemColors.Control;
            this.spdData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdData.FocusRenderer = defaultFocusIndicatorRenderer2;
            this.spdData.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdData.HorizontalScrollBar.Name = "";
            this.spdData.HorizontalScrollBar.Renderer = defaultScrollBarRenderer3;
            this.spdData.HorizontalScrollBar.TabIndex = 2;
            this.spdData.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdData.Location = new System.Drawing.Point(3, 3);
            this.spdData.Name = "spdData";
            this.spdData.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdData.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdData.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdData_Sheet1});
            this.spdData.Size = new System.Drawing.Size(736, 302);
            this.spdData.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdData.TabIndex = 0;
            this.spdData.TabStop = false;
            this.spdData.TextTipDelay = 200;
            this.spdData.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdData.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdData.VerticalScrollBar.Name = "";
            this.spdData.VerticalScrollBar.Renderer = defaultScrollBarRenderer4;
            this.spdData.VerticalScrollBar.TabIndex = 3;
            this.spdData.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdData.SetActiveViewport(0, -1, -1);
            // 
            // spdData_Sheet1
            // 
            this.spdData_Sheet1.Reset();
            spdData_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdData_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdData_Sheet1.ColumnCount = 18;
            spdData_Sheet1.RowCount = 0;
            this.spdData_Sheet1.ActiveColumnIndex = -1;
            this.spdData_Sheet1.ActiveRowIndex = -1;
            this.spdData_Sheet1.AlternatingRows.Get(1).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdData_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdData_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Chart ID";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Version";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Released";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Apply Start Time";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Apply End Time";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "A/M";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "USL";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "Target";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "LSL";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 9).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "UCL";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 10).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "CL";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 11).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "LCL";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 11).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 12).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 12).Value = "UCL2";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 12).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 13).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 13).Value = "CL2";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 13).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 14).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 14).Value = "LCL2";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 14).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 15).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 15).Value = "Comment";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 15).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 16).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 16).Value = "Release User";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 16).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 17).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 17).Value = "Release Time";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 17).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdData_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdData_Sheet1.Columns.Get(0).Label = "Chart ID";
            this.spdData_Sheet1.Columns.Get(0).Locked = true;
            this.spdData_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(0).Width = 100F;
            this.spdData_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(1).Label = "Version";
            this.spdData_Sheet1.Columns.Get(1).Locked = true;
            this.spdData_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(1).Width = 45F;
            this.spdData_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(2).Label = "Released";
            this.spdData_Sheet1.Columns.Get(2).Locked = true;
            this.spdData_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(2).Width = 55F;
            this.spdData_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdData_Sheet1.Columns.Get(3).Label = "Apply Start Time";
            this.spdData_Sheet1.Columns.Get(3).Locked = true;
            this.spdData_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(3).Width = 140F;
            this.spdData_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdData_Sheet1.Columns.Get(4).Label = "Apply End Time";
            this.spdData_Sheet1.Columns.Get(4).Locked = true;
            this.spdData_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(4).Width = 140F;
            this.spdData_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(5).Label = "A/M";
            this.spdData_Sheet1.Columns.Get(5).Locked = true;
            this.spdData_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(5).Width = 30F;
            this.spdData_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(6).Label = "USL";
            this.spdData_Sheet1.Columns.Get(6).Locked = true;
            this.spdData_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(6).Width = 80F;
            this.spdData_Sheet1.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(7).Label = "Target";
            this.spdData_Sheet1.Columns.Get(7).Locked = true;
            this.spdData_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(7).Width = 80F;
            this.spdData_Sheet1.Columns.Get(8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(8).Label = "LSL";
            this.spdData_Sheet1.Columns.Get(8).Locked = true;
            this.spdData_Sheet1.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(8).Width = 80F;
            this.spdData_Sheet1.Columns.Get(9).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(9).Label = "UCL";
            this.spdData_Sheet1.Columns.Get(9).Locked = true;
            this.spdData_Sheet1.Columns.Get(9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(9).Width = 80F;
            this.spdData_Sheet1.Columns.Get(10).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(10).Label = "CL";
            this.spdData_Sheet1.Columns.Get(10).Locked = true;
            this.spdData_Sheet1.Columns.Get(10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(10).Width = 80F;
            this.spdData_Sheet1.Columns.Get(11).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(11).Label = "LCL";
            this.spdData_Sheet1.Columns.Get(11).Locked = true;
            this.spdData_Sheet1.Columns.Get(11).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(11).Width = 80F;
            this.spdData_Sheet1.Columns.Get(12).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(12).Label = "UCL2";
            this.spdData_Sheet1.Columns.Get(12).Locked = true;
            this.spdData_Sheet1.Columns.Get(12).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(12).Width = 80F;
            this.spdData_Sheet1.Columns.Get(13).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(13).Label = "CL2";
            this.spdData_Sheet1.Columns.Get(13).Locked = true;
            this.spdData_Sheet1.Columns.Get(13).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(13).Width = 80F;
            this.spdData_Sheet1.Columns.Get(14).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(14).Label = "LCL2";
            this.spdData_Sheet1.Columns.Get(14).Locked = true;
            this.spdData_Sheet1.Columns.Get(14).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(14).Width = 80F;
            this.spdData_Sheet1.Columns.Get(15).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdData_Sheet1.Columns.Get(15).Label = "Comment";
            this.spdData_Sheet1.Columns.Get(15).Locked = true;
            this.spdData_Sheet1.Columns.Get(15).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(15).Width = 266F;
            this.spdData_Sheet1.Columns.Get(16).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdData_Sheet1.Columns.Get(16).Label = "Release User";
            this.spdData_Sheet1.Columns.Get(16).Locked = true;
            this.spdData_Sheet1.Columns.Get(16).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(16).Width = 85F;
            this.spdData_Sheet1.Columns.Get(17).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdData_Sheet1.Columns.Get(17).Label = "Release Time";
            this.spdData_Sheet1.Columns.Get(17).Locked = true;
            this.spdData_Sheet1.Columns.Get(17).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(17).Width = 140F;
            this.spdData_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdData_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdData_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdData_Sheet1.Rows.Default.Height = 18F;
            this.spdData_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.spdData_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.spdData_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdData_Sheet1.VisualStyles = FarPoint.Win.VisualStyles.Auto;
            this.spdData_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // frmSPCViewSpecHistory
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Controls.Add(this.pnlData);
            this.Controls.Add(this.pnlMidTop);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.pnlBottom);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.MinimumSize = new System.Drawing.Size(750, 580);
            this.Name = "frmSPCViewSpecHistory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "View Spec History";
            this.Load += new System.EventHandler(this.frmSPCViewSpecHistory_Load);
            this.pnlBottom.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.grpTop.ResumeLayout(false);
            this.grpTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChartSetID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIncludeRelease)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPeriod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uneYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMonth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkPeriod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboGraphType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChartID)).EndInit();
            this.pnlMidTop.ResumeLayout(false);
            this.grpChartInfo.ResumeLayout(false);
            this.pnlData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdData_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Function Implementations"
        
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
                if (cdvChartID.Text == "" && cdvChartSetID.Text == "")
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(108) + "\r\n" + "[CHART_ID or CHART_SET_ID]");
                    cdvChartID.Focus();
                    return false;
                }
                
                if (chkPeriod.Checked == true)
                {
                    if (cboMonth.Text == "")
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(108));
                        cboMonth.Focus();
                        return false;
                    }
                }
                
                return true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCViewSpecHistory.CheckCondition()\n" + ex.Message);
                return false;
            }
            
        }
        
        // View_Spec_History()
        //       - View Spec History
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool View_Spec_History(char c_step)
        {
            
            try
            {
                TRSNode in_node = new TRSNode("View_Process_Capability_In");
                TRSNode out_node;
                ArrayList a_list = new ArrayList();

                int i;
                int iRow;
                int iCol;

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = c_step;
                in_node.AddString("CHART_ID", MPCF.Trim(cdvChartID.Text));
                in_node.AddString("CHART_SET_ID", MPCF.Trim(cdvChartSetID.Text));
                in_node.AddInt("NEXT_VERSION", int.MaxValue);

                if (chkPeriod.Checked == true)
                {
                    in_node.AddString("YEAR_MONTH", uneYear.Value + MPCF.ToInt(cboMonth.Text).ToString("00") + "00000000");

                }
                if (chkIncludeRelease.Checked == true)
                {
                    in_node.AddChar("INCLUDE_RELEASE", 'Y');
                }

                MPCF.ClearList(spdData, true);
                
                do
                {
                    out_node = new TRSNode("View_Spec_History_Out");
                    if (MPCR.CallService("SPC", "SPC_View_Spec_History", in_node, ref out_node) == false)
                    {
                        return false;
                    }
                    a_list.Add(out_node);

                    in_node.SetString("NEXT_CHART_ID", out_node.GetString("NEXT_CHART_ID"));
                    in_node.SetInt("NEXT_VERSION", out_node.GetInt("NEXT_VERSION"));

                } while (in_node.GetString("NEXT_CHART_ID") != "" || in_node.GetInt("NEXT_VERSION") > 0 );
                 foreach (object obj in a_list)
                {
                    out_node = null;
                    out_node = (TRSNode)obj;

                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        iRow = spdData.Sheets[0].RowCount;
                        spdData.Sheets[0].RowCount++;
                        iCol = 0;

                        spdData.Sheets[0].Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("CHART_ID");

                        iCol++;
                        spdData.Sheets[0].Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetInt("VERSION");

                        iCol++;
                        spdData.Sheets[0].Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetChar("RELEASE_FLAG");

                        iCol++;
                        spdData.Sheets[0].Cells[iRow, iCol].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("APPLY_START_TIME"));

                        iCol++;
                        spdData.Sheets[0].Cells[iRow, iCol].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("APPLY_END_TIME"));

                        iCol++;
                        spdData.Sheets[0].Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetChar("AUTO_MANUAL_FLAG");

                        iCol++;
                        spdData.Sheets[0].Cells[iRow, iCol].Value = MPCF.SetPrecision(MPCF.Trim(out_node.GetList(0)[i].GetString("USL")), ctrlChartData.Precision);

                        iCol++;
                        spdData.Sheets[0].Cells[iRow, iCol].Value = MPCF.SetPrecision(MPCF.Trim(out_node.GetList(0)[i].GetString("TARGET")), ctrlChartData.Precision);

                        iCol++;
                        spdData.Sheets[0].Cells[iRow, iCol].Value = MPCF.SetPrecision(MPCF.Trim(out_node.GetList(0)[i].GetString("LSL")), ctrlChartData.Precision);

                        iCol++;
                        spdData.Sheets[0].Cells[iRow, iCol].Value = MPCF.SetPrecision(MPCF.Trim(out_node.GetList(0)[i].GetString("UCL")), ctrlChartData.Precision);

                        iCol++;
                        spdData.Sheets[0].Cells[iRow, iCol].Value = MPCF.SetPrecision(MPCF.Trim(out_node.GetList(0)[i].GetString("CL")), ctrlChartData.Precision);

                        iCol++;
                        spdData.Sheets[0].Cells[iRow, iCol].Value = MPCF.SetPrecision(MPCF.Trim(out_node.GetList(0)[i].GetString("LCL")), ctrlChartData.Precision);

                        iCol++;
                        spdData.Sheets[0].Cells[iRow, iCol].Value = MPCF.SetPrecision(MPCF.Trim(out_node.GetList(0)[i].GetString("UCL2")), ctrlChartData.Precision);

                        iCol++;
                        spdData.Sheets[0].Cells[iRow, iCol].Value = MPCF.SetPrecision(MPCF.Trim(out_node.GetList(0)[i].GetString("CL2")), ctrlChartData.Precision);

                        iCol++;
                        spdData.Sheets[0].Cells[iRow, iCol].Value = MPCF.SetPrecision(MPCF.Trim(out_node.GetList(0)[i].GetString("LCL2")), ctrlChartData.Precision);

                        iCol++;
                        spdData.Sheets[0].Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("SPEC_COMMENT"));

                        iCol++;
                        spdData.Sheets[0].Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("RELEASE_USER_ID"));

                        iCol++;
                        spdData.Sheets[0].Cells[iRow, iCol].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("RELEASE_TIME"));

                        iCol++;
                    }
                }
                    
                
                return true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCViewEDCData.View_Spec_History()\n" + ex.Message);
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
                btnView.PerformClick();
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCViewProcessCapability.ChartInfo()\n" + ex.Message);
            }
            
        }
        
        #endregion
        
        #region " Event Implementations"
        
        private void frmSPCViewSpecHistory_Load(object sender, System.EventArgs e)
        {
            
            try
            {
                MPGV.gIBaseFormEvent.Form_Load(this, e);
                MPCF.SetTextboxStyle(this.Controls);
                
                uneYear.Value = DateTime.Now.Year;
                cboMonth.Text = DateTime.Now.Month.ToString();
                modSPCFunctions.SetGraphList(cboGraphType);
                
                cdvChartID.Text = modSPCFunctions.GetFilterKey();
                
                this.pnlMidTop.Visible = false;
                
                if (MPCF.Trim(MPGV.gsChartID) != "")
                {
                    cdvChartID.Text = MPGV.gsChartID;
                    ChartInfo();
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCViewSpecHistory.frmSPCViewSpecHistory_Load()\n" + ex.Message);
            }
            
        }
        
        private void cdvChartID_ButtonPress(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                cdvChartID.Init();
                MPCF.InitListView(cdvChartID.GetListView);
                cdvChartID.Columns.Add("Chart", 50, HorizontalAlignment.Left);
                if (cdvChartSetID.Text == "")
                {
                    cdvChartID.Columns.Add("GraphType", 50, HorizontalAlignment.Left);
                }
                cdvChartID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvChartID.SelectedSubItemIndex = 0;
                if (cdvChartSetID.Text != "")
                {
                    SPCLIST.ViewSPCAttachChartList(cdvChartID.GetListView, '1', cdvChartSetID.Text, "");
                }
                else
                {
                    SPCLIST.ViewChartList(cdvChartID.GetListView, '2', "", 0, "", "", "", ' ', ' ', MPCF.Trim(cdvChartID.Text), "", -1, -1, null, "");
                }
                cdvChartID.AddEmptyRow(1);
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCViewSpecHistory.cdvChartID_ButtonPress()\n" + ex.Message);
            }
            
        }
        
        private void cdvChartID_SelectedItemChanged(System.Object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            
            try
            {
                MPCF.ClearList(spdData, true);
                MPCF.FieldClear(this.grpTop, cdvChartID, uneYear, cdvChartSetID, null, null, false);
                ctrlChartData.ClearChartInfo();
                
                if (cdvChartID.Text == "")
                {
                    this.pnlMidTop.Visible = false;
                }
                else
                {
                    this.pnlMidTop.Visible = true;
                    if (ctrlChartData.ViewChartInformation(cdvChartID.Text, true) == false)
                    {
                        return;
                    }
                    cboGraphType.SelectedIndex = (int)Enum.Parse(typeof(eGraphType), ctrlChartData.ChartGraphType);
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCViewSpecHistory.cdvChartID_SelectedItemChanged()\n" + ex.Message);
            }
            
        }

        private void cdvChartID_TextBoxKeyPress(object sender, KeyPressEventArgs e)
        {
            if (MPCF.Trim(cdvChartID.Text) != "" && e.KeyChar == (char)13)
            {
                cdvChartID_SelectedItemChanged(null, null);
                btnView.PerformClick();
            }
        }

        private void btnView_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                if (CheckCondition() == false)
                {
                    return;
                }
                if (cdvChartID.Text != "")
                {
                    spdData.Sheets[0].Columns[0].Visible = false;
                    this.pnlMidTop.Visible = true;
                    View_Spec_History('1');
                }
                else if (cdvChartID.Text == "" && cdvChartSetID.Text != "")
                {
                    spdData.Sheets[0].Columns[0].Visible = true;
                    this.pnlMidTop.Visible = false;
                    View_Spec_History('2');
                }
                
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCViewSpecHistory.btnView_Click()\n" + ex.Message);
            }
            
        }
        
        private void chkPeriod_CheckedChanged(object sender, System.EventArgs e)
        {
            
            try
            {
                txtPeriod.Visible = ! chkPeriod.Checked;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCViewSpecHistory.chkPeriod_CheckedChanged()\n" + ex.Message);
            }
            
        }
        
        private void btnClose_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                this.Dispose();
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCViewSpecHistory.btnClose_Click()\n" + ex.Message);
            }
            
        }
        
        private void cdvChartID_TextBoxTextChanged(object sender, System.EventArgs e)
        {
            
            try
            {
                MPCF.ClearList(spdData, true);
                cboGraphType.SelectedIndex = -1;
                ctrlChartData.ClearChartInfo();
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCViewSpecHistory.cdvChartID_TextBoxTextChanged()\n" + ex.Message);
            }
            
        }
        
        private void btnRefresh_Click(object sender, System.EventArgs e)
        {
            
            try
            {
                MPCF.ClearList(spdData, true);
                cboGraphType.SelectedIndex = - 1;
                ctrlChartData.ClearChartInfo();
                
                if (cdvChartID.Text == "")
                {
                    return;
                }
                if (ctrlChartData.ViewChartInformation(cdvChartID.Text, true) == false)
                {
                    return;
                }
                cboGraphType.SelectedIndex = (int)Enum.Parse(typeof(eGraphType), ctrlChartData.ChartGraphType);
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCViewSpecHistory.btnRefresh_Click()\n" + ex.Message);
            }
            
        }
        
        private void btnExcel_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                string sCond;
                
                sCond = "Chart ID : " + MPCF.Trim(cdvChartID.Text) + "\r";
                sCond = sCond + "Graph Type : " + MPCF.Trim(cboGraphType.Text) + "\r";
                MPCF.ExportToExcel(spdData, this.Text, sCond);
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCViewSpecHistory.btnExcel_Click()\n" + ex.Message);
            }
            
        }
        
        private void btnFiltering_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                frmSPCViewChartList form = new frmSPCViewChartList();
                form.StartPosition = FormStartPosition.CenterParent;
                if (cdvChartSetID.Text != "")
                {
                    form.cdvChartSetID.Text = cdvChartSetID.Text;
                    form.cdvChartSetID.Enabled = false;
                }
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
                MPCF.ShowMsgBox("frmSPCViewSpecHistory.btnFiltering_Click()\n" + ex.Message);
            }
            
        }
        
        private void cdvChartSetID_ButtonPress(object sender, System.EventArgs e)
        {
            
            try
            {
                cdvChartSetID.Init();
                MPCF.InitListView(cdvChartSetID.GetListView);
                cdvChartSetID.Columns.Add("Chart", 50, HorizontalAlignment.Left);
                cdvChartSetID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvChartSetID.SelectedSubItemIndex = 0;
                SPCLIST.ViewChartSetList(cdvChartSetID.GetListView, '1', "", 0,"", "", ' ', "", -1, -1, "");
                cdvChartSetID.AddEmptyRow(1);
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCViewSpecHistory.cdvChartSetID_ButtonPress()\n" + ex.Message);
            }
            
        }
        
        private void cdvChartSetID_SelectedItemChanged(object sender, UI.MCCodeViewSelChanged_EventArgs e)
        {
            
            try
            {
                MPCF.ClearList(spdData, true);
                cdvChartID.Text = "";
                this.cboGraphType.SelectedIndex = - 1;
                ctrlChartData.ClearChartInfo();
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCViewSpecHistory.cdvChartSetID_SelectedItemChanged()\n" + ex.Message);
            }
            
        }
        
        private void cdvChartSetID_TextBoxTextChanged(object sender, System.EventArgs e)
        {
            
            try
            {
                MPCF.ClearList(spdData, true);
                cdvChartID.Text = "";
                this.cboGraphType.SelectedIndex = - 1;
                ctrlChartData.ClearChartInfo();
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCViewSpecHistory.cdvChartSetID_TextBoxTextChanged()\n" + ex.Message);
            }
            
        }
        
        #endregion


    }
    
    
    //#End If
    
}
