
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
//   File Name   : frmSPCViewOOCHistory.vb
//   Description : View OOC History
//
//   MES Version : 1.0.0
//
//   Function List
//       - CheckCondition() : Check the conditions before transaction
//       - View_OOC_History_List() : View OOC History
//
//
//   Detail Description
//       -
//       -
//
//   History
//       - 2005-05-25 : Created by H.K.Kim
//
//
//   Copyright(C) 1998-2004 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------
namespace Miracom.SPCCore
{
    public class frmSPCViewOOCHistory : System.Windows.Forms.Form
    {
        
        #region " Windows Form auto generated code "
        
        public frmSPCViewOOCHistory()
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
        



        internal System.Windows.Forms.Panel pnlTop;
        internal System.Windows.Forms.GroupBox grpTop;
        internal System.Windows.Forms.Panel pnlBottom;
        internal System.Windows.Forms.Button btnView;
        internal System.Windows.Forms.Button btnClose;
        internal System.Windows.Forms.Panel pnlData;
        private FarPoint.Win.Spread.FpSpread spdData;
        internal FarPoint.Win.Spread.SheetView spdData_Sheet1;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvChartID;
        internal System.Windows.Forms.Label lblChartID;
        internal System.Windows.Forms.Label lblPeriod;
        internal Infragistics.Win.UltraWinSchedule.UltraCalendarCombo uccFromDate;
        internal System.Windows.Forms.Label lblA;
        internal Infragistics.Win.UltraWinSchedule.UltraCalendarCombo uccToDate;
        internal System.Windows.Forms.Button btnTrouble;
        internal System.Windows.Forms.RadioButton rbnInclude;
        internal System.Windows.Forms.RadioButton rbnOnlyDelete;
        internal System.Windows.Forms.RadioButton rbnHistory;
        internal Infragistics.Win.UltraWinEditors.UltraCheckEditor chkIncludeDeleteChart;
        public System.Windows.Forms.Button btnExcel;
        internal System.Windows.Forms.Button btnFiltering;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvChartSetID;
        internal System.Windows.Forms.Label lblChartSet;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSPCViewOOCHistory));
            Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton dateButton1 = new Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton();
            Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton dateButton2 = new Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton();
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.grpTop = new System.Windows.Forms.GroupBox();
            this.cdvChartSetID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblChartSet = new System.Windows.Forms.Label();
            this.btnFiltering = new System.Windows.Forms.Button();
            this.rbnOnlyDelete = new System.Windows.Forms.RadioButton();
            this.rbnInclude = new System.Windows.Forms.RadioButton();
            this.rbnHistory = new System.Windows.Forms.RadioButton();
            this.uccToDate = new Infragistics.Win.UltraWinSchedule.UltraCalendarCombo();
            this.lblA = new System.Windows.Forms.Label();
            this.uccFromDate = new Infragistics.Win.UltraWinSchedule.UltraCalendarCombo();
            this.lblPeriod = new System.Windows.Forms.Label();
            this.cdvChartID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblChartID = new System.Windows.Forms.Label();
            this.chkIncludeDeleteChart = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnExcel = new System.Windows.Forms.Button();
            this.btnTrouble = new System.Windows.Forms.Button();
            this.btnView = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.pnlData = new System.Windows.Forms.Panel();
            this.spdData = new FarPoint.Win.Spread.FpSpread();
            this.spdData_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.pnlTop.SuspendLayout();
            this.grpTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChartSetID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uccToDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uccFromDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChartID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIncludeDeleteChart)).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.pnlData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdData_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.grpTop);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.pnlTop.Size = new System.Drawing.Size(742, 88);
            this.pnlTop.TabIndex = 0;
            // 
            // grpTop
            // 
            this.grpTop.Controls.Add(this.cdvChartSetID);
            this.grpTop.Controls.Add(this.lblChartSet);
            this.grpTop.Controls.Add(this.btnFiltering);
            this.grpTop.Controls.Add(this.rbnOnlyDelete);
            this.grpTop.Controls.Add(this.rbnInclude);
            this.grpTop.Controls.Add(this.rbnHistory);
            this.grpTop.Controls.Add(this.uccToDate);
            this.grpTop.Controls.Add(this.lblA);
            this.grpTop.Controls.Add(this.uccFromDate);
            this.grpTop.Controls.Add(this.lblPeriod);
            this.grpTop.Controls.Add(this.cdvChartID);
            this.grpTop.Controls.Add(this.lblChartID);
            this.grpTop.Controls.Add(this.chkIncludeDeleteChart);
            this.grpTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpTop.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpTop.Location = new System.Drawing.Point(3, 0);
            this.grpTop.Name = "grpTop";
            this.grpTop.Size = new System.Drawing.Size(736, 88);
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
            this.cdvChartSetID.Location = new System.Drawing.Point(120, 18);
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
            this.lblChartSet.Location = new System.Drawing.Point(15, 21);
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
            this.btnFiltering.Location = new System.Drawing.Point(324, 40);
            this.btnFiltering.Name = "btnFiltering";
            this.btnFiltering.Size = new System.Drawing.Size(24, 24);
            this.btnFiltering.TabIndex = 4;
            this.btnFiltering.Click += new System.EventHandler(this.btnFiltering_Click);
            // 
            // rbnOnlyDelete
            // 
            this.rbnOnlyDelete.AutoSize = true;
            this.rbnOnlyDelete.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbnOnlyDelete.Location = new System.Drawing.Point(300, 68);
            this.rbnOnlyDelete.Name = "rbnOnlyDelete";
            this.rbnOnlyDelete.Size = new System.Drawing.Size(127, 18);
            this.rbnOnlyDelete.TabIndex = 11;
            this.rbnOnlyDelete.Text = "Only Deleted History";
            // 
            // rbnInclude
            // 
            this.rbnInclude.AutoSize = true;
            this.rbnInclude.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbnInclude.Location = new System.Drawing.Point(156, 68);
            this.rbnInclude.Name = "rbnInclude";
            this.rbnInclude.Size = new System.Drawing.Size(141, 18);
            this.rbnInclude.TabIndex = 10;
            this.rbnInclude.Text = "Include Deleted History";
            // 
            // rbnHistory
            // 
            this.rbnHistory.AutoSize = true;
            this.rbnHistory.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbnHistory.Location = new System.Drawing.Point(16, 68);
            this.rbnHistory.Name = "rbnHistory";
            this.rbnHistory.Size = new System.Drawing.Size(115, 18);
            this.rbnHistory.TabIndex = 9;
            this.rbnHistory.Text = "Undeleted History";
            // 
            // uccToDate
            // 
            this.uccToDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.uccToDate.DateButtons.Add(dateButton1);
            this.uccToDate.Location = new System.Drawing.Point(629, 18);
            this.uccToDate.Name = "uccToDate";
            this.uccToDate.NonAutoSizeHeight = 21;
            this.uccToDate.Size = new System.Drawing.Size(88, 21);
            this.uccToDate.TabIndex = 8;
            this.uccToDate.Value = new System.DateTime(2005, 5, 9, 0, 0, 0, 0);
            // 
            // lblA
            // 
            this.lblA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblA.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblA.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblA.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblA.Location = new System.Drawing.Point(613, 20);
            this.lblA.Name = "lblA";
            this.lblA.Size = new System.Drawing.Size(12, 14);
            this.lblA.TabIndex = 7;
            this.lblA.Text = "~";
            // 
            // uccFromDate
            // 
            this.uccFromDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.uccFromDate.DateButtons.Add(dateButton2);
            this.uccFromDate.Location = new System.Drawing.Point(521, 18);
            this.uccFromDate.Name = "uccFromDate";
            this.uccFromDate.NonAutoSizeHeight = 21;
            this.uccFromDate.Size = new System.Drawing.Size(88, 21);
            this.uccFromDate.TabIndex = 6;
            this.uccFromDate.Value = new System.DateTime(2005, 5, 9, 0, 0, 0, 0);
            // 
            // lblPeriod
            // 
            this.lblPeriod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPeriod.AutoSize = true;
            this.lblPeriod.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblPeriod.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPeriod.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblPeriod.Location = new System.Drawing.Point(453, 21);
            this.lblPeriod.Name = "lblPeriod";
            this.lblPeriod.Size = new System.Drawing.Size(43, 13);
            this.lblPeriod.TabIndex = 5;
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
            this.cdvChartID.Location = new System.Drawing.Point(120, 42);
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
            this.cdvChartID.TextBoxTextChanged += new System.EventHandler(this.cdvChartID_TextBoxTextChanged);
            // 
            // lblChartID
            // 
            this.lblChartID.AutoSize = true;
            this.lblChartID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblChartID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChartID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblChartID.Location = new System.Drawing.Point(15, 45);
            this.lblChartID.Name = "lblChartID";
            this.lblChartID.Size = new System.Drawing.Size(46, 13);
            this.lblChartID.TabIndex = 2;
            this.lblChartID.Text = "Chart ID";
            // 
            // chkIncludeDeleteChart
            // 
            this.chkIncludeDeleteChart.AutoSize = true;
            this.chkIncludeDeleteChart.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkIncludeDeleteChart.Location = new System.Drawing.Point(453, 68);
            this.chkIncludeDeleteChart.Name = "chkIncludeDeleteChart";
            this.chkIncludeDeleteChart.Size = new System.Drawing.Size(147, 17);
            this.chkIncludeDeleteChart.TabIndex = 12;
            this.chkIncludeDeleteChart.Text = "Include Deleted Chart";
            this.chkIncludeDeleteChart.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnExcel);
            this.pnlBottom.Controls.Add(this.btnTrouble);
            this.pnlBottom.Controls.Add(this.btnView);
            this.pnlBottom.Controls.Add(this.btnClose);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 506);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(742, 40);
            this.pnlBottom.TabIndex = 2;
            // 
            // btnExcel
            // 
            this.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExcel.Image")));
            this.btnExcel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnExcel.Location = new System.Drawing.Point(8, 8);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(24, 24);
            this.btnExcel.TabIndex = 3;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnTrouble
            // 
            this.btnTrouble.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTrouble.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnTrouble.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnTrouble.Location = new System.Drawing.Point(558, 8);
            this.btnTrouble.Name = "btnTrouble";
            this.btnTrouble.Size = new System.Drawing.Size(88, 26);
            this.btnTrouble.TabIndex = 1;
            this.btnTrouble.Text = "Trouble ";
            this.btnTrouble.Click += new System.EventHandler(this.btnTrouble_Click);
            // 
            // btnView
            // 
            this.btnView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnView.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnView.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnView.Location = new System.Drawing.Point(466, 8);
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
            this.btnClose.Location = new System.Drawing.Point(650, 8);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(88, 26);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pnlData
            // 
            this.pnlData.Controls.Add(this.spdData);
            this.pnlData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlData.Location = new System.Drawing.Point(0, 88);
            this.pnlData.Name = "pnlData";
            this.pnlData.Padding = new System.Windows.Forms.Padding(3);
            this.pnlData.Size = new System.Drawing.Size(742, 418);
            this.pnlData.TabIndex = 1;
            // 
            // spdData
            // 
            this.spdData.AccessibleDescription = "spdData, Sheet1, Row 0, Column 0, ";
            this.spdData.BackColor = System.Drawing.SystemColors.Control;
            this.spdData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdData.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdData.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdData.HorizontalScrollBar.Name = "";
            this.spdData.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdData.HorizontalScrollBar.TabIndex = 2;
            this.spdData.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdData.Location = new System.Drawing.Point(3, 3);
            this.spdData.Name = "spdData";
            this.spdData.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdData.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdData.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdData_Sheet1});
            this.spdData.Size = new System.Drawing.Size(736, 412);
            this.spdData.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdData.TabIndex = 0;
            this.spdData.TabStop = false;
            this.spdData.TextTipDelay = 200;
            this.spdData.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdData.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdData.VerticalScrollBar.Name = "";
            this.spdData.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
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
            spdData_Sheet1.ColumnCount = 21;
            spdData_Sheet1.RowCount = 0;
            spdData_Sheet1.RowHeader.ColumnCount = 0;
            this.spdData_Sheet1.ActiveColumnIndex = -1;
            this.spdData_Sheet1.ActiveRowIndex = -1;
            this.spdData_Sheet1.AlternatingRows.Get(1).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdData_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdData_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Chart ID";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Seq";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Tran Time";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "L/R";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "OOC Type";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Rule Description";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "OOC Type2";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "Rule Description";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "Inspector";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "Trouble Code";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "Trouble User";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "Trouble Time";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 12).Value = "Trouble Comment";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 13).Value = "Action Code";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 14).Value = "Action User";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 15).Value = "Action Time";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 16).Value = "Action Comment";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 17).Value = "Delete Flag";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 18).Value = "Delete Comment";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 19).Value = "EDC Hist Seq";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 20).Value = "EDC Unit Seq";
            this.spdData_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdData_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdData_Sheet1.Columns.Get(0).Label = "Chart ID";
            this.spdData_Sheet1.Columns.Get(0).Locked = true;
            this.spdData_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(0).Width = 100F;
            this.spdData_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(1).Label = "Seq";
            this.spdData_Sheet1.Columns.Get(1).Locked = true;
            this.spdData_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(1).Width = 30F;
            this.spdData_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdData_Sheet1.Columns.Get(2).Label = "Tran Time";
            this.spdData_Sheet1.Columns.Get(2).Locked = true;
            this.spdData_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(2).Width = 140F;
            this.spdData_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(3).Label = "L/R";
            this.spdData_Sheet1.Columns.Get(3).Locked = true;
            this.spdData_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(3).Width = 30F;
            this.spdData_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(4).Label = "OOC Type";
            this.spdData_Sheet1.Columns.Get(4).Locked = true;
            this.spdData_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(4).Width = 65F;
            this.spdData_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdData_Sheet1.Columns.Get(5).Label = "Rule Description";
            this.spdData_Sheet1.Columns.Get(5).Locked = true;
            this.spdData_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(5).Width = 315F;
            this.spdData_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(6).Label = "OOC Type2";
            this.spdData_Sheet1.Columns.Get(6).Locked = true;
            this.spdData_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(6).Width = 70F;
            this.spdData_Sheet1.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdData_Sheet1.Columns.Get(7).Label = "Rule Description";
            this.spdData_Sheet1.Columns.Get(7).Locked = true;
            this.spdData_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(7).Width = 315F;
            this.spdData_Sheet1.Columns.Get(8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdData_Sheet1.Columns.Get(8).Label = "Inspector";
            this.spdData_Sheet1.Columns.Get(8).Locked = true;
            this.spdData_Sheet1.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(8).Width = 80F;
            this.spdData_Sheet1.Columns.Get(9).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdData_Sheet1.Columns.Get(9).Label = "Trouble Code";
            this.spdData_Sheet1.Columns.Get(9).Locked = true;
            this.spdData_Sheet1.Columns.Get(9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(9).Width = 100F;
            this.spdData_Sheet1.Columns.Get(10).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdData_Sheet1.Columns.Get(10).Label = "Trouble User";
            this.spdData_Sheet1.Columns.Get(10).Locked = true;
            this.spdData_Sheet1.Columns.Get(10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(10).Width = 85F;
            this.spdData_Sheet1.Columns.Get(11).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdData_Sheet1.Columns.Get(11).Label = "Trouble Time";
            this.spdData_Sheet1.Columns.Get(11).Locked = true;
            this.spdData_Sheet1.Columns.Get(11).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(11).Width = 108F;
            this.spdData_Sheet1.Columns.Get(12).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdData_Sheet1.Columns.Get(12).Label = "Trouble Comment";
            this.spdData_Sheet1.Columns.Get(12).Locked = true;
            this.spdData_Sheet1.Columns.Get(12).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(12).Width = 200F;
            this.spdData_Sheet1.Columns.Get(13).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdData_Sheet1.Columns.Get(13).Label = "Action Code";
            this.spdData_Sheet1.Columns.Get(13).Locked = true;
            this.spdData_Sheet1.Columns.Get(13).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(13).Width = 80F;
            this.spdData_Sheet1.Columns.Get(14).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdData_Sheet1.Columns.Get(14).Label = "Action User";
            this.spdData_Sheet1.Columns.Get(14).Locked = true;
            this.spdData_Sheet1.Columns.Get(14).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(14).Width = 85F;
            this.spdData_Sheet1.Columns.Get(15).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdData_Sheet1.Columns.Get(15).Label = "Action Time";
            this.spdData_Sheet1.Columns.Get(15).Locked = true;
            this.spdData_Sheet1.Columns.Get(15).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(15).Width = 108F;
            this.spdData_Sheet1.Columns.Get(16).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdData_Sheet1.Columns.Get(16).Label = "Action Comment";
            this.spdData_Sheet1.Columns.Get(16).Locked = true;
            this.spdData_Sheet1.Columns.Get(16).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(16).Width = 200F;
            this.spdData_Sheet1.Columns.Get(17).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdData_Sheet1.Columns.Get(17).Label = "Delete Flag";
            this.spdData_Sheet1.Columns.Get(17).Locked = true;
            this.spdData_Sheet1.Columns.Get(17).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(17).Width = 70F;
            this.spdData_Sheet1.Columns.Get(18).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdData_Sheet1.Columns.Get(18).Label = "Delete Comment";
            this.spdData_Sheet1.Columns.Get(18).Locked = true;
            this.spdData_Sheet1.Columns.Get(18).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(18).Width = 200F;
            this.spdData_Sheet1.Columns.Get(19).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(19).Label = "EDC Hist Seq";
            this.spdData_Sheet1.Columns.Get(19).Locked = true;
            this.spdData_Sheet1.Columns.Get(19).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(19).Width = 80F;
            this.spdData_Sheet1.Columns.Get(20).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(20).Label = "EDC Unit Seq";
            this.spdData_Sheet1.Columns.Get(20).Locked = true;
            this.spdData_Sheet1.Columns.Get(20).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(20).Width = 80F;
            this.spdData_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdData_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdData_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdData_Sheet1.RowHeader.Visible = false;
            this.spdData_Sheet1.Rows.Default.Height = 18F;
            this.spdData_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.spdData_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.spdData_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdData_Sheet1.VisualStyles = FarPoint.Win.VisualStyles.Auto;
            this.spdData_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // frmSPCViewOOCHistory
            // 
            this.AcceptButton = this.btnView;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Controls.Add(this.pnlData);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(750, 580);
            this.Name = "frmSPCViewOOCHistory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "View OOC History";
            this.Load += new System.EventHandler(this.frmSPCViewOOCHistory_Load);
            this.pnlTop.ResumeLayout(false);
            this.grpTop.ResumeLayout(false);
            this.grpTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChartSetID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uccToDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uccFromDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChartID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIncludeDeleteChart)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.pnlData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdData_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Function Definition "
        
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
                if (this.uccFromDate.Value == System.DBNull.Value)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                    uccFromDate.Focus();
                    return false;
                }
                if (this.uccToDate.Value == System.DBNull.Value)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                    uccToDate.Focus();
                    return false;
                }
                
                if (((DateTime)uccFromDate.Value) >= ((DateTime)uccToDate.Value))
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(214));
                    return false;
                }
                
                return true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCViewOOCHistory.CheckCondition()\n" + ex.Message);
                return false;
            }
            
        }
        
        // View_OOC_History_List()
        //       - View OOC History
        // Return Value
        //       -
        // Arguments
        //        -
        //
        private bool View_OOC_History_List()
        {
            TRSNode in_node = new TRSNode("View_OOC_History_Detail_In");
            TRSNode out_node;
            ArrayList a_list = new ArrayList();
            int i;
            int iRow;
            
            try
            {
                MPCF.ClearList(spdData, true);

                MPCR.SetInMsg(in_node);
                in_node.AddString("FROM_TIME", MPCF.DateFromString(uccFromDate));
                in_node.AddString("TO_TIME", MPCF.DateToString(uccToDate));

                if (rbnInclude.Checked == true)
                {
                    in_node.AddChar("INCLUDE_DELETE", '1');
                }
                else if (rbnOnlyDelete.Checked == true)
                {
                    in_node.AddChar("INCLUDE_DELETE", '2');
                }
                else
                {
                    in_node.AddChar("INCLUDE_DELETE", '3');
                }
                
                if (chkIncludeDeleteChart.Checked == true)
                {
                    in_node.AddChar("INC_DEL_CHART", 'N');                
                }
                else
                {
                    in_node.AddChar("INC_DEL_CHART", 'Y');
                }
                in_node.AddString("CHART_SET_ID", MPCF.Trim(cdvChartSetID.Text));
                in_node.AddString("NEXT_CHART_ID", MPCF.Trim(cdvChartID.Text));
                in_node.AddInt("NEXT_HIST_SEQ", int.MaxValue);
                
                if (cdvChartID.Text != "")
                {
                    in_node.ProcStep = '2';
                }
                else if (cdvChartID.Text == "" && cdvChartSetID.Text != "")
                {
                    in_node.ProcStep = '3';
                }
                else
                {
                    in_node.ProcStep = '1';
                }
                
                do
                {
                    out_node = new TRSNode("View_OOC_History_Detail_Out");
                    if (MPCR.CallService("SPC", "SPC_View_OOC_History_Detail", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    a_list.Add(out_node);
                    
                    in_node.SetString("NEXT_CHART_ID", out_node.GetString("NEXT_CHART_ID"));
                    in_node.SetInt("NEXT_HIST_SEQ", out_node.GetInt("NEXT_HIST_SEQ"));

                } while (in_node.GetString("NEXT_CHART_ID") != "" || in_node.GetInt("NEXT_HIST_SEQ") > 0 );

                foreach (object obj in a_list)
                {
                    out_node = null;
                    out_node = (TRSNode)obj;

                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        iRow = spdData.Sheets[0].RowCount;
                        spdData.Sheets[0].RowCount++;
                     
                        spdData.Sheets[0].Cells[iRow, 0].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("CHART_ID"));
                        spdData.Sheets[0].Cells[iRow, 1].Value = out_node.GetList(0)[i].GetInt("HIST_SEQ").ToString();
                        spdData.Sheets[0].Cells[iRow, 2].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("TRAN_TIME"));
                        spdData.Sheets[0].Cells[iRow, 3].Value = MPCF.Trim(out_node.GetList(0)[i].GetChar("LOT_RES_FLAG"));
                        spdData.Sheets[0].Cells[iRow, 4].Value = MPCF.Trim(out_node.GetList(0)[i].GetChar("OOC_TYPE"));
                        spdData.Sheets[0].Cells[iRow, 6].Value = MPCF.Trim(out_node.GetList(0)[i].GetChar("OOC_TYPE2"));
                        /* Added By YJJung 160222 For the extended ooc history */
                        if (MPCF.Trim(out_node.GetList(0)[i].GetString("X_OOC_MSG_1")) != "" || MPCF.Trim(out_node.GetList(0)[i].GetString("R_OOC_MSG_1")) != "")
                        {
                            spdData.Sheets[0].Cells[iRow, 5].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("X_OOC_MSG_1"));
                            spdData.Sheets[0].Cells[iRow, 7].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("R_OOC_MSG_1"));
                        }
                        else
                        {
                            spdData.Sheets[0].Cells[iRow, 5].Value = MPCF.SetRuleDescription(out_node.GetList(0)[i].GetChar("OOC_TYPE"), out_node);
                            spdData.Sheets[0].Cells[iRow, 7].Value = MPCF.SetRuleDescription(out_node.GetList(0)[i].GetChar("OOC_TYPE2"), out_node);
                        }
                        
                        //else if (MPGV.gcLanguage == '2')
                        //{
                        //    if (MPCF.Trim(out_node.GetList(0)[i].GetString("X_OOC_MSG_2")) != "" || MPCF.Trim(out_node.GetList(0)[i].GetString("R_OOC_MSG_2")) != "")
                        //    {
                        //        spdData.Sheets[0].Cells[iRow, 5].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("X_OOC_MSG_2"));
                        //        spdData.Sheets[0].Cells[iRow, 7].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("R_OOC_MSG_2"));
                        //    }
                        //    else
                        //    {
                        //        spdData.Sheets[0].Cells[iRow, 5].Value = MPCF.SetRuleDescription(out_node.GetList(0)[i].GetChar("OOC_TYPE"), out_node);
                        //        spdData.Sheets[0].Cells[iRow, 7].Value = MPCF.SetRuleDescription(out_node.GetList(0)[i].GetChar("OOC_TYPE2"), out_node);
                        //    }
                        //}
                        //else if (MPGV.gcLanguage == '3')
                        //{
                        //    if (MPCF.Trim(out_node.GetList(0)[i].GetString("X_OOC_MSG_2")) != "" || MPCF.Trim(out_node.GetList(0)[i].GetString("R_OOC_MSG_2")) != "")
                        //    {
                        //        spdData.Sheets[0].Cells[iRow, 5].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("X_OOC_MSG_3"));
                        //        spdData.Sheets[0].Cells[iRow, 7].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("R_OOC_MSG_3"));
                        //    }
                        //    else
                        //    {
                        //        spdData.Sheets[0].Cells[iRow, 5].Value = MPCF.SetRuleDescription(out_node.GetList(0)[i].GetChar("OOC_TYPE"), out_node);
                        //        spdData.Sheets[0].Cells[iRow, 7].Value = MPCF.SetRuleDescription(out_node.GetList(0)[i].GetChar("OOC_TYPE2"), out_node);
                        //    }
                        //}
                        spdData.Sheets[0].Cells[iRow, 8].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("INSPECTOR"));
                        spdData.Sheets[0].Cells[iRow, 9].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRB_CODE"));
                        spdData.Sheets[0].Cells[iRow, 10].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRB_USER"));
                        spdData.Sheets[0].Cells[iRow, 11].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("TRB_TIME"));
                        spdData.Sheets[0].Cells[iRow, 12].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRB_COMMENT"));
                        spdData.Sheets[0].Cells[iRow, 13].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("ACT_CODE"));
                        spdData.Sheets[0].Cells[iRow, 14].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("ACT_USER"));
                        spdData.Sheets[0].Cells[iRow, 15].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("ACT_TIME"));
                        spdData.Sheets[0].Cells[iRow, 16].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("ACT_COMMENT"));
                        spdData.Sheets[0].Cells[iRow, 17].Value = MPCF.Trim(out_node.GetList(0)[i].GetChar("DELETE_FLAG"));
                        spdData.Sheets[0].Cells[iRow, 18].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("DELETE_COMMENT"));
                        spdData.Sheets[0].Cells[iRow, 19].Value = out_node.GetList(0)[i].GetInt("EDC_HIST_SEQ").ToString();
                        spdData.Sheets[0].Cells[iRow, 20].Value = out_node.GetList(0)[i].GetInt("EDC_UNIT_SEQ").ToString();
                        if (out_node.GetList(0)[i].GetChar("DELETE_FLAG") == 'Y')
                        {
                            spdData.Sheets[0].Rows[iRow].ForeColor = Color.Magenta;
                        }
                        
                    }
                }

                if (in_node.GetChar("PROCSTEP") == '2')
                {
                    spdData.Sheets[0].Columns[0].Visible = false;
                }
                else
                {
                    spdData.Sheets[0].Columns[0].Visible = true;
                }
                
                return true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCViewOOCHistory.View_OOC_History_List()\n" + ex.Message);
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
                btnView.PerformClick();
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCViewOOCHistory.ChartInfo()\n" + ex.Message);
            }
            
        }
        
        #endregion
        
        #region " Event Implematations"
        
        private void cdvChartID_ButtonPress(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                
                cdvChartID.Init();
                MPCF.InitListView(cdvChartID.GetListView);
                cdvChartID.Columns.Add("Chart", 50, HorizontalAlignment.Left);
                cdvChartID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvChartID.SelectedSubItemIndex = 0;
                if (cdvChartSetID.Text != "")
                {
                    SPCLIST.ViewSPCAttachChartList(cdvChartID.GetListView, '1', cdvChartSetID.Text, "");
                }
                else
                {
                    SPCLIST.ViewChartList(cdvChartID.GetListView, '2', "", 0, "", "", "", ' ', (chkIncludeDeleteChart.Checked ? 'Y' : ' '), MPCF.Trim(cdvChartID.Text), "", -1, -1, null, "");
                }
                cdvChartID.AddEmptyRow(1);
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCViewOOCHistory.cdvChartID_ButtonPress()\n" + ex.Message);
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
                View_OOC_History_List();
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCViewOOCHistory.btnView_Click()\n" + ex.Message);
            }
            
        }
        
        private void frmSPCViewOOCHistory_Load(object sender, System.EventArgs e)
        {
            
            try
            {
                MPGV.gIBaseFormEvent.Form_Load(this, e);
                MPCF.SetTextboxStyle(this.Controls);
                
                uccFromDate.Value = DateTime.Today.AddMonths(- 1);
                uccToDate.Value = DateTime.Today;
                rbnHistory.Checked = true;
                
                cdvChartID.Text = modSPCFunctions.GetFilterKey();
                
                if (MPCF.Trim(MPGV.gsChartID) != "")
                {
                    cdvChartID.Text = MPGV.gsChartID;
                    ChartInfo();
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCViewOOCHistory.frmSPCViewOOCHistory_Load()\n" + ex.Message);
            }
            
        }
        
        private void btnTrouble_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                frmSPCTranUpdateOOCHistory form = new frmSPCTranUpdateOOCHistory();
                int iRow;
                iRow = spdData.Sheets[0].ActiveRowIndex;
                if (spdData.Sheets[0].SelectionCount > 0)
                {
                    if (spdData.Sheets[0].Columns[0].Visible == true)
                    {
                        form.txtChart.Text = MPCF.Trim(spdData.Sheets[0].Cells[iRow, 0].Value);
                    }
                    else
                    {
                        form.txtChart.Text = cdvChartID.Text;
                    }
                    form.txtHistSeq.Text = MPCF.Trim(spdData.Sheets[0].Cells[iRow, 1].Value);
                    if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                    {
                        spdData.Sheets[0].Cells[iRow, 8].Value = form.cdvInspector.Text;
                        spdData.Sheets[0].Cells[iRow, 9].Value = form.cdvTrbCode.Text;
                        spdData.Sheets[0].Cells[iRow, 10].Value = form.cdvTrbUser.Text;
                        spdData.Sheets[0].Cells[iRow, 11].Value = MPCF.MakeDateFormat(((DateTime)(form.uccTrbDate.Value)).ToString("yyyyMMdd") + ((DateTime)(form.udtTrbTime.Value)).ToString("HHmmss"));
                        spdData.Sheets[0].Cells[iRow, 12].Value = form.txtTrbComment.Text;
                        spdData.Sheets[0].Cells[iRow, 13].Value = form.cdvActCode.Text;
                        spdData.Sheets[0].Cells[iRow, 14].Value = form.cdvActUser.Text;
                        spdData.Sheets[0].Cells[iRow, 15].Value = MPCF.MakeDateFormat(((DateTime)(form.uccActDate.Value)).ToString("yyyyMMdd") + ((DateTime)(form.udtActTime.Value)).ToString("HHmmss"));
                        spdData.Sheets[0].Cells[iRow, 16].Value = form.txtActComment.Text;
                    }
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCViewOOCHistory.btnTrouble_Click()\n" + ex.Message);
            }
            
        }
        
        private void btnClose_Click(object sender, System.EventArgs e)
        {
            
            try
            {
                this.Dispose();
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCViewOOCHistory.btnClose_Click()\n" + ex.Message);
            }
            
        }
        
        private void cdvChartID_SelectedItemChanged(object sender, UI.MCCodeViewSelChanged_EventArgs e)
        {
            
            try
            {
                MPCF.ClearList(spdData, true);
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCViewOOCHistory.cdvChartID_SelectedItemChanged()\n" + ex.Message);
            }
            
        }
        
        private void cdvChartID_TextBoxTextChanged(object sender, System.EventArgs e)
        {
            
            try
            {
                MPCF.ClearList(spdData, true);
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCViewOOCHistory.cdvChartID_TextBoxTextChanged()\n" + ex.Message);
            }
            
        }
        
        private void btnExcel_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                string sCond;

                sCond = "Chart ID : " + MPCF.Trim(cdvChartID.Text) + "\r";
                sCond = sCond + "Date : " + MPCF.MakeDateFormat(MPCF.DateFromString(uccFromDate)) + " ~ " + MPCF.MakeDateFormat(MPCF.DateToString(uccToDate));
                MPCF.ExportToExcel(spdData, this.Text, sCond);
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCViewOOCHistory.btnExcel_Click()\n" + ex.Message);
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
                MPCF.ShowMsgBox("frmSPCViewOOCHistory.btnFiltering_Click()\n" + ex.Message);
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
