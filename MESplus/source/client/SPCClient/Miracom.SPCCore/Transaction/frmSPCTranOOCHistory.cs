
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
//   File Name   : frmSPCTranOOCHistory.vb
//   Description : Update OOC History
//
//   SPC Version : 1.0.0
//
//   Function List
//       - Update_OOC_History : Update OOC History
//       - View_OOC_History : View OOC History
//
//   Detail Description
//       -
//
//   History
//       - 2005-05-09 : Created by H.K.Kim
//
//   Copyright(C) 1998-2004 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------
namespace Miracom.SPCCore
{
    public class frmSPCTranOOCHistory : System.Windows.Forms.Form
    {
        
        #region " Windows Form auto generated code "
        
        public frmSPCTranOOCHistory()
        {
            
            
            InitializeComponent();
            
            
            
        }
        
        public frmSPCTranOOCHistory(int iEdcHistSeq, string sTranTime, int iEdcUnitSeq)
        {
            
            
            InitializeComponent();
            
            
            giEdcHistSeq = iEdcHistSeq;
            gsTranTime = sTranTime;
            giEdcUnitSeq = iEdcUnitSeq;
            
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
        internal System.Windows.Forms.Button btnOK;
        internal System.Windows.Forms.Button btnClose;
        internal System.Windows.Forms.Panel pnlTop;
        internal Infragistics.Win.UltraWinEditors.UltraTextEditor txtChart;
        internal System.Windows.Forms.GroupBox grpChart;
        internal System.Windows.Forms.Label lblGraphType;
        internal System.Windows.Forms.Label lblChartID;
        internal System.Windows.Forms.Panel pnlResult;
        internal FarPoint.Win.Spread.FpSpread spdResult;
        internal FarPoint.Win.Spread.SheetView spdResult_Sheet1;
        internal System.Windows.Forms.Panel pnlOOC;
        internal System.Windows.Forms.GroupBox grpTrouble;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvTrbCode;
        internal System.Windows.Forms.Label lblTroubleCode;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvTrbUser;
        internal System.Windows.Forms.Label lblTroubleUser;
        internal System.Windows.Forms.Label lblTrbComment;
        internal Infragistics.Win.UltraWinEditors.UltraTextEditor txtTrbComment;
        internal Infragistics.Win.UltraWinEditors.UltraDateTimeEditor udtTrbTime;
        internal Infragistics.Win.UltraWinSchedule.UltraCalendarCombo uccTrbDate;
        internal System.Windows.Forms.Label lblTrbTime;
        internal System.Windows.Forms.GroupBox grpAction;
        internal System.Windows.Forms.Label lblActTime;
        internal Infragistics.Win.UltraWinEditors.UltraTextEditor txtActComment;
        internal System.Windows.Forms.Label lblActComment;
        internal System.Windows.Forms.Label lblActUser;
        internal System.Windows.Forms.Label lblActCode;
        internal Infragistics.Win.UltraWinEditors.UltraDateTimeEditor udtActTime;
        internal Infragistics.Win.UltraWinSchedule.UltraCalendarCombo uccActDate;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvInspector;
        internal System.Windows.Forms.Label lblInspector;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvActUser;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvActCode;
        internal Infragistics.Win.UltraWinEditors.UltraTextEditor txtGraphType;
        internal System.Windows.Forms.GroupBox grpChartInfo;
        internal System.Windows.Forms.Button btnRefresh;
        internal Miracom.SPCCore.udcChart ctrlChartData;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSPCTranOOCHistory));
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.BevelBorder bevelBorder1 = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Raised);
            Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton dateButton1 = new Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton();
            Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton dateButton2 = new Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.grpChartInfo = new System.Windows.Forms.GroupBox();
            this.ctrlChartData = new Miracom.SPCCore.udcChart();
            this.grpChart = new System.Windows.Forms.GroupBox();
            this.txtGraphType = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lblGraphType = new System.Windows.Forms.Label();
            this.lblChartID = new System.Windows.Forms.Label();
            this.txtChart = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.pnlResult = new System.Windows.Forms.Panel();
            this.spdResult = new FarPoint.Win.Spread.FpSpread();
            this.spdResult_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.pnlOOC = new System.Windows.Forms.Panel();
            this.grpAction = new System.Windows.Forms.GroupBox();
            this.lblActTime = new System.Windows.Forms.Label();
            this.txtActComment = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lblActComment = new System.Windows.Forms.Label();
            this.cdvActUser = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblActUser = new System.Windows.Forms.Label();
            this.cdvActCode = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblActCode = new System.Windows.Forms.Label();
            this.udtActTime = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.uccActDate = new Infragistics.Win.UltraWinSchedule.UltraCalendarCombo();
            this.grpTrouble = new System.Windows.Forms.GroupBox();
            this.cdvInspector = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblInspector = new System.Windows.Forms.Label();
            this.lblTrbTime = new System.Windows.Forms.Label();
            this.txtTrbComment = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lblTrbComment = new System.Windows.Forms.Label();
            this.cdvTrbUser = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblTroubleUser = new System.Windows.Forms.Label();
            this.cdvTrbCode = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblTroubleCode = new System.Windows.Forms.Label();
            this.udtTrbTime = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.uccTrbDate = new Infragistics.Win.UltraWinSchedule.UltraCalendarCombo();
            this.pnlBottom.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.grpChartInfo.SuspendLayout();
            this.grpChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtGraphType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtChart)).BeginInit();
            this.pnlResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdResult_Sheet1)).BeginInit();
            this.pnlOOC.SuspendLayout();
            this.grpAction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtActComment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvActUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvActCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udtActTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uccActDate)).BeginInit();
            this.grpTrouble.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvInspector)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTrbComment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvTrbUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvTrbCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udtTrbTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uccTrbDate)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnRefresh);
            this.pnlBottom.Controls.Add(this.btnOK);
            this.pnlBottom.Controls.Add(this.btnClose);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 506);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(742, 40);
            this.pnlBottom.TabIndex = 3;
            // 
            // btnRefresh
            // 
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnRefresh.Location = new System.Drawing.Point(8, 8);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(24, 24);
            this.btnRefresh.TabIndex = 0;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnOK.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnOK.Location = new System.Drawing.Point(558, 8);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(88, 26);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
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
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.grpChartInfo);
            this.pnlTop.Controls.Add(this.grpChart);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.pnlTop.Size = new System.Drawing.Size(742, 132);
            this.pnlTop.TabIndex = 0;
            // 
            // grpChartInfo
            // 
            this.grpChartInfo.Controls.Add(this.ctrlChartData);
            this.grpChartInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpChartInfo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpChartInfo.Location = new System.Drawing.Point(3, 48);
            this.grpChartInfo.Name = "grpChartInfo";
            this.grpChartInfo.Size = new System.Drawing.Size(736, 83);
            this.grpChartInfo.TabIndex = 1;
            this.grpChartInfo.TabStop = false;
            // 
            // ctrlChartData
            // 
            this.ctrlChartData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlChartData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlChartData.Location = new System.Drawing.Point(3, 16);
            this.ctrlChartData.Name = "ctrlChartData";
            this.ctrlChartData.Size = new System.Drawing.Size(730, 64);
            this.ctrlChartData.TabIndex = 0;
            // 
            // grpChart
            // 
            this.grpChart.Controls.Add(this.txtGraphType);
            this.grpChart.Controls.Add(this.lblGraphType);
            this.grpChart.Controls.Add(this.lblChartID);
            this.grpChart.Controls.Add(this.txtChart);
            this.grpChart.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpChart.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpChart.Location = new System.Drawing.Point(3, 0);
            this.grpChart.Name = "grpChart";
            this.grpChart.Size = new System.Drawing.Size(736, 48);
            this.grpChart.TabIndex = 0;
            this.grpChart.TabStop = false;
            // 
            // txtGraphType
            // 
            this.txtGraphType.Location = new System.Drawing.Point(524, 16);
            this.txtGraphType.MaxLength = 30;
            this.txtGraphType.Name = "txtGraphType";
            this.txtGraphType.ReadOnly = true;
            this.txtGraphType.Size = new System.Drawing.Size(200, 20);
            this.txtGraphType.TabIndex = 3;
            // 
            // lblGraphType
            // 
            this.lblGraphType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblGraphType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGraphType.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblGraphType.Location = new System.Drawing.Point(411, 19);
            this.lblGraphType.Name = "lblGraphType";
            this.lblGraphType.Size = new System.Drawing.Size(104, 14);
            this.lblGraphType.TabIndex = 2;
            this.lblGraphType.Text = "Graph Type";
            // 
            // lblChartID
            // 
            this.lblChartID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblChartID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChartID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblChartID.Location = new System.Drawing.Point(15, 19);
            this.lblChartID.Name = "lblChartID";
            this.lblChartID.Size = new System.Drawing.Size(97, 14);
            this.lblChartID.TabIndex = 0;
            this.lblChartID.Text = "Chart ID";
            // 
            // txtChart
            // 
            this.txtChart.Location = new System.Drawing.Point(120, 16);
            this.txtChart.MaxLength = 30;
            this.txtChart.Name = "txtChart";
            this.txtChart.ReadOnly = true;
            this.txtChart.Size = new System.Drawing.Size(200, 20);
            this.txtChart.TabIndex = 1;
            // 
            // pnlResult
            // 
            this.pnlResult.Controls.Add(this.spdResult);
            this.pnlResult.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlResult.Location = new System.Drawing.Point(0, 132);
            this.pnlResult.Name = "pnlResult";
            this.pnlResult.Padding = new System.Windows.Forms.Padding(3);
            this.pnlResult.Size = new System.Drawing.Size(742, 124);
            this.pnlResult.TabIndex = 1;
            // 
            // spdResult
            // 
            this.spdResult.AccessibleDescription = "spdResult, Sheet1, Row 0, Column 0, ";
            this.spdResult.BackColor = System.Drawing.SystemColors.Control;
            this.spdResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdResult.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdResult.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdResult.HorizontalScrollBar.Name = "";
            this.spdResult.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdResult.HorizontalScrollBar.TabIndex = 2;
            this.spdResult.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdResult.Location = new System.Drawing.Point(3, 3);
            this.spdResult.Name = "spdResult";
            this.spdResult.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdResult.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdResult.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdResult_Sheet1});
            this.spdResult.Size = new System.Drawing.Size(736, 118);
            this.spdResult.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdResult.TabIndex = 0;
            this.spdResult.TabStop = false;
            this.spdResult.TextTipDelay = 200;
            this.spdResult.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdResult.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdResult.VerticalScrollBar.Name = "";
            this.spdResult.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdResult.VerticalScrollBar.TabIndex = 3;
            this.spdResult.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdResult.CellClick += new FarPoint.Win.Spread.CellClickEventHandler(this.spdResult_CellClick);
            this.spdResult.SelectionChanged += new FarPoint.Win.Spread.SelectionChangedEventHandler(this.spdResult_SelectionChanged);
            // 
            // spdResult_Sheet1
            // 
            this.spdResult_Sheet1.Reset();
            this.spdResult_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdResult_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.spdResult_Sheet1.ColumnCount = 9;
            this.spdResult_Sheet1.RowCount = 5;
            this.spdResult_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Seq";
            this.spdResult_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Chart ID";
            this.spdResult_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Unit ID";
            this.spdResult_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Chart";
            this.spdResult_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Rule Type";
            this.spdResult_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Rule Description";
            this.spdResult_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Comment";
            this.spdResult_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdResult_Sheet1.Columns.Get(0).BackColor = System.Drawing.SystemColors.Control;
            this.spdResult_Sheet1.Columns.Get(0).Border = bevelBorder1;
            this.spdResult_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdResult_Sheet1.Columns.Get(0).Label = "Seq";
            this.spdResult_Sheet1.Columns.Get(0).Locked = true;
            this.spdResult_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdResult_Sheet1.Columns.Get(0).Width = 43F;
            this.spdResult_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdResult_Sheet1.Columns.Get(1).Label = "Chart ID";
            this.spdResult_Sheet1.Columns.Get(1).Locked = true;
            this.spdResult_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdResult_Sheet1.Columns.Get(1).Width = 100F;
            this.spdResult_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdResult_Sheet1.Columns.Get(2).Label = "Unit ID";
            this.spdResult_Sheet1.Columns.Get(2).Locked = true;
            this.spdResult_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdResult_Sheet1.Columns.Get(2).Width = 100F;
            this.spdResult_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdResult_Sheet1.Columns.Get(3).Label = "Chart";
            this.spdResult_Sheet1.Columns.Get(3).Locked = true;
            this.spdResult_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdResult_Sheet1.Columns.Get(3).Width = 40F;
            this.spdResult_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdResult_Sheet1.Columns.Get(4).Label = "Rule Type";
            this.spdResult_Sheet1.Columns.Get(4).Locked = true;
            this.spdResult_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdResult_Sheet1.Columns.Get(5).Label = "Rule Description";
            this.spdResult_Sheet1.Columns.Get(5).Locked = true;
            this.spdResult_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdResult_Sheet1.Columns.Get(5).Width = 312F;
            this.spdResult_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdResult_Sheet1.Columns.Get(6).Label = "Comment";
            this.spdResult_Sheet1.Columns.Get(6).Locked = true;
            this.spdResult_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdResult_Sheet1.Columns.Get(7).Visible = false;
            this.spdResult_Sheet1.Columns.Get(8).Visible = false;
            this.spdResult_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdResult_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdResult_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdResult_Sheet1.RowHeader.Visible = false;
            this.spdResult_Sheet1.Rows.Default.Height = 18F;
            this.spdResult_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.spdResult_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.spdResult_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdResult_Sheet1.VisualStyles = FarPoint.Win.VisualStyles.Auto;
            this.spdResult_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // pnlOOC
            // 
            this.pnlOOC.Controls.Add(this.grpAction);
            this.pnlOOC.Controls.Add(this.grpTrouble);
            this.pnlOOC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlOOC.Location = new System.Drawing.Point(0, 256);
            this.pnlOOC.Name = "pnlOOC";
            this.pnlOOC.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.pnlOOC.Size = new System.Drawing.Size(742, 250);
            this.pnlOOC.TabIndex = 2;
            // 
            // grpAction
            // 
            this.grpAction.Controls.Add(this.lblActTime);
            this.grpAction.Controls.Add(this.txtActComment);
            this.grpAction.Controls.Add(this.lblActComment);
            this.grpAction.Controls.Add(this.cdvActUser);
            this.grpAction.Controls.Add(this.lblActUser);
            this.grpAction.Controls.Add(this.cdvActCode);
            this.grpAction.Controls.Add(this.lblActCode);
            this.grpAction.Controls.Add(this.udtActTime);
            this.grpAction.Controls.Add(this.uccActDate);
            this.grpAction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpAction.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpAction.Location = new System.Drawing.Point(3, 120);
            this.grpAction.Name = "grpAction";
            this.grpAction.Size = new System.Drawing.Size(736, 130);
            this.grpAction.TabIndex = 1;
            this.grpAction.TabStop = false;
            // 
            // lblActTime
            // 
            this.lblActTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblActTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActTime.Location = new System.Drawing.Point(15, 43);
            this.lblActTime.Name = "lblActTime";
            this.lblActTime.Size = new System.Drawing.Size(97, 14);
            this.lblActTime.TabIndex = 4;
            this.lblActTime.Text = "Action Time";
            this.lblActTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtActComment
            // 
            this.txtActComment.Location = new System.Drawing.Point(120, 64);
            this.txtActComment.MaxLength = 200;
            this.txtActComment.Multiline = true;
            this.txtActComment.Name = "txtActComment";
            this.txtActComment.Size = new System.Drawing.Size(604, 43);
            this.txtActComment.TabIndex = 4;
            // 
            // lblActComment
            // 
            this.lblActComment.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblActComment.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActComment.Location = new System.Drawing.Point(15, 64);
            this.lblActComment.Name = "lblActComment";
            this.lblActComment.Size = new System.Drawing.Size(97, 14);
            this.lblActComment.TabIndex = 7;
            this.lblActComment.Text = "Action Comment";
            this.lblActComment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cdvActUser
            // 
            this.cdvActUser.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvActUser.BorderHotColor = System.Drawing.Color.Black;
            this.cdvActUser.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvActUser.BtnToolTipText = "";
            this.cdvActUser.DescText = "";
            this.cdvActUser.DisplaySubItemIndex = -1;
            this.cdvActUser.DisplayText = "";
            this.cdvActUser.Focusing = null;
            this.cdvActUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvActUser.Index = 0;
            this.cdvActUser.IsViewBtnImage = false;
            this.cdvActUser.Location = new System.Drawing.Point(524, 16);
            this.cdvActUser.MaxLength = 20;
            this.cdvActUser.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvActUser.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvActUser.Name = "cdvActUser";
            this.cdvActUser.ReadOnly = false;
            this.cdvActUser.SearchSubItemIndex = 0;
            this.cdvActUser.SelectedDescIndex = -1;
            this.cdvActUser.SelectedSubItemIndex = -1;
            this.cdvActUser.SelectionStart = 0;
            this.cdvActUser.Size = new System.Drawing.Size(200, 20);
            this.cdvActUser.SmallImageList = null;
            this.cdvActUser.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvActUser.TabIndex = 1;
            this.cdvActUser.TextBoxToolTipText = "";
            this.cdvActUser.TextBoxWidth = 200;
            this.cdvActUser.VisibleButton = true;
            this.cdvActUser.VisibleColumnHeader = false;
            this.cdvActUser.VisibleDescription = false;
            this.cdvActUser.ButtonPress += new System.EventHandler(this.cdvActUser_ButtonPress);
            // 
            // lblActUser
            // 
            this.lblActUser.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblActUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActUser.Location = new System.Drawing.Point(411, 19);
            this.lblActUser.Name = "lblActUser";
            this.lblActUser.Size = new System.Drawing.Size(97, 14);
            this.lblActUser.TabIndex = 2;
            this.lblActUser.Text = "Action User";
            this.lblActUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cdvActCode
            // 
            this.cdvActCode.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvActCode.BorderHotColor = System.Drawing.Color.Black;
            this.cdvActCode.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvActCode.BtnToolTipText = "";
            this.cdvActCode.DescText = "";
            this.cdvActCode.DisplaySubItemIndex = -1;
            this.cdvActCode.DisplayText = "";
            this.cdvActCode.Focusing = null;
            this.cdvActCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvActCode.Index = 0;
            this.cdvActCode.IsViewBtnImage = false;
            this.cdvActCode.Location = new System.Drawing.Point(120, 16);
            this.cdvActCode.MaxLength = 30;
            this.cdvActCode.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvActCode.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvActCode.Name = "cdvActCode";
            this.cdvActCode.ReadOnly = false;
            this.cdvActCode.SearchSubItemIndex = 0;
            this.cdvActCode.SelectedDescIndex = -1;
            this.cdvActCode.SelectedSubItemIndex = -1;
            this.cdvActCode.SelectionStart = 0;
            this.cdvActCode.Size = new System.Drawing.Size(200, 20);
            this.cdvActCode.SmallImageList = null;
            this.cdvActCode.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvActCode.TabIndex = 0;
            this.cdvActCode.TextBoxToolTipText = "";
            this.cdvActCode.TextBoxWidth = 200;
            this.cdvActCode.VisibleButton = true;
            this.cdvActCode.VisibleColumnHeader = false;
            this.cdvActCode.VisibleDescription = false;
            this.cdvActCode.ButtonPress += new System.EventHandler(this.cdvActCode_ButtonPress);
            // 
            // lblActCode
            // 
            this.lblActCode.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblActCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActCode.Location = new System.Drawing.Point(15, 19);
            this.lblActCode.Name = "lblActCode";
            this.lblActCode.Size = new System.Drawing.Size(97, 14);
            this.lblActCode.TabIndex = 0;
            this.lblActCode.Text = "Action Code";
            this.lblActCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // udtActTime
            // 
            this.udtActTime.DateTime = new System.DateTime(2005, 5, 11, 0, 0, 0, 0);
            this.udtActTime.DropDownButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.Never;
            this.udtActTime.FormatString = "";
            this.udtActTime.Location = new System.Drawing.Point(211, 40);
            this.udtActTime.MaskInput = "hh:mm:ss";
            this.udtActTime.Name = "udtActTime";
            this.udtActTime.Size = new System.Drawing.Size(72, 21);
            this.udtActTime.SpinButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.Always;
            this.udtActTime.SpinWrap = true;
            this.udtActTime.TabIndex = 3;
            this.udtActTime.Value = new System.DateTime(2005, 5, 11, 0, 0, 0, 0);
            // 
            // uccActDate
            // 
            this.uccActDate.BackColor = System.Drawing.SystemColors.Window;
            this.uccActDate.DateButtons.Add(dateButton1);
            this.uccActDate.Location = new System.Drawing.Point(120, 40);
            this.uccActDate.Name = "uccActDate";
            this.uccActDate.NonAutoSizeHeight = 21;
            this.uccActDate.Size = new System.Drawing.Size(88, 21);
            this.uccActDate.TabIndex = 2;
            this.uccActDate.Value = new System.DateTime(2005, 5, 9, 0, 0, 0, 0);
            // 
            // grpTrouble
            // 
            this.grpTrouble.Controls.Add(this.cdvInspector);
            this.grpTrouble.Controls.Add(this.lblInspector);
            this.grpTrouble.Controls.Add(this.lblTrbTime);
            this.grpTrouble.Controls.Add(this.txtTrbComment);
            this.grpTrouble.Controls.Add(this.lblTrbComment);
            this.grpTrouble.Controls.Add(this.cdvTrbUser);
            this.grpTrouble.Controls.Add(this.lblTroubleUser);
            this.grpTrouble.Controls.Add(this.cdvTrbCode);
            this.grpTrouble.Controls.Add(this.lblTroubleCode);
            this.grpTrouble.Controls.Add(this.udtTrbTime);
            this.grpTrouble.Controls.Add(this.uccTrbDate);
            this.grpTrouble.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpTrouble.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpTrouble.Location = new System.Drawing.Point(3, 0);
            this.grpTrouble.Name = "grpTrouble";
            this.grpTrouble.Size = new System.Drawing.Size(736, 120);
            this.grpTrouble.TabIndex = 0;
            this.grpTrouble.TabStop = false;
            // 
            // cdvInspector
            // 
            this.cdvInspector.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvInspector.BorderHotColor = System.Drawing.Color.Black;
            this.cdvInspector.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvInspector.BtnToolTipText = "";
            this.cdvInspector.DescText = "";
            this.cdvInspector.DisplaySubItemIndex = -1;
            this.cdvInspector.DisplayText = "";
            this.cdvInspector.Focusing = null;
            this.cdvInspector.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvInspector.Index = 0;
            this.cdvInspector.IsViewBtnImage = false;
            this.cdvInspector.Location = new System.Drawing.Point(524, 16);
            this.cdvInspector.MaxLength = 20;
            this.cdvInspector.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvInspector.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvInspector.Name = "cdvInspector";
            this.cdvInspector.ReadOnly = false;
            this.cdvInspector.SearchSubItemIndex = 0;
            this.cdvInspector.SelectedDescIndex = -1;
            this.cdvInspector.SelectedSubItemIndex = -1;
            this.cdvInspector.SelectionStart = 0;
            this.cdvInspector.Size = new System.Drawing.Size(200, 20);
            this.cdvInspector.SmallImageList = null;
            this.cdvInspector.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvInspector.TabIndex = 1;
            this.cdvInspector.TextBoxToolTipText = "";
            this.cdvInspector.TextBoxWidth = 200;
            this.cdvInspector.VisibleButton = true;
            this.cdvInspector.VisibleColumnHeader = false;
            this.cdvInspector.VisibleDescription = false;
            this.cdvInspector.ButtonPress += new System.EventHandler(this.cdvInspector_ButtonPress);
            // 
            // lblInspector
            // 
            this.lblInspector.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblInspector.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInspector.Location = new System.Drawing.Point(411, 19);
            this.lblInspector.Name = "lblInspector";
            this.lblInspector.Size = new System.Drawing.Size(97, 14);
            this.lblInspector.TabIndex = 2;
            this.lblInspector.Text = "Inspector";
            this.lblInspector.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTrbTime
            // 
            this.lblTrbTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblTrbTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrbTime.Location = new System.Drawing.Point(15, 43);
            this.lblTrbTime.Name = "lblTrbTime";
            this.lblTrbTime.Size = new System.Drawing.Size(97, 14);
            this.lblTrbTime.TabIndex = 4;
            this.lblTrbTime.Text = "Trouble Time";
            this.lblTrbTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTrbComment
            // 
            this.txtTrbComment.Location = new System.Drawing.Point(120, 64);
            this.txtTrbComment.MaxLength = 200;
            this.txtTrbComment.Multiline = true;
            this.txtTrbComment.Name = "txtTrbComment";
            this.txtTrbComment.Size = new System.Drawing.Size(604, 43);
            this.txtTrbComment.TabIndex = 5;
            // 
            // lblTrbComment
            // 
            this.lblTrbComment.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblTrbComment.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrbComment.Location = new System.Drawing.Point(15, 64);
            this.lblTrbComment.Name = "lblTrbComment";
            this.lblTrbComment.Size = new System.Drawing.Size(101, 14);
            this.lblTrbComment.TabIndex = 9;
            this.lblTrbComment.Text = "Trouble Comment";
            this.lblTrbComment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cdvTrbUser
            // 
            this.cdvTrbUser.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvTrbUser.BorderHotColor = System.Drawing.Color.Black;
            this.cdvTrbUser.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvTrbUser.BtnToolTipText = "";
            this.cdvTrbUser.DescText = "";
            this.cdvTrbUser.DisplaySubItemIndex = -1;
            this.cdvTrbUser.DisplayText = "";
            this.cdvTrbUser.Focusing = null;
            this.cdvTrbUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvTrbUser.Index = 0;
            this.cdvTrbUser.IsViewBtnImage = false;
            this.cdvTrbUser.Location = new System.Drawing.Point(524, 40);
            this.cdvTrbUser.MaxLength = 20;
            this.cdvTrbUser.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvTrbUser.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvTrbUser.Name = "cdvTrbUser";
            this.cdvTrbUser.ReadOnly = false;
            this.cdvTrbUser.SearchSubItemIndex = 0;
            this.cdvTrbUser.SelectedDescIndex = -1;
            this.cdvTrbUser.SelectedSubItemIndex = -1;
            this.cdvTrbUser.SelectionStart = 0;
            this.cdvTrbUser.Size = new System.Drawing.Size(200, 20);
            this.cdvTrbUser.SmallImageList = null;
            this.cdvTrbUser.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvTrbUser.TabIndex = 4;
            this.cdvTrbUser.TextBoxToolTipText = "";
            this.cdvTrbUser.TextBoxWidth = 200;
            this.cdvTrbUser.VisibleButton = true;
            this.cdvTrbUser.VisibleColumnHeader = false;
            this.cdvTrbUser.VisibleDescription = false;
            this.cdvTrbUser.ButtonPress += new System.EventHandler(this.cdvTrbUser_ButtonPress);
            // 
            // lblTroubleUser
            // 
            this.lblTroubleUser.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblTroubleUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTroubleUser.Location = new System.Drawing.Point(411, 43);
            this.lblTroubleUser.Name = "lblTroubleUser";
            this.lblTroubleUser.Size = new System.Drawing.Size(97, 14);
            this.lblTroubleUser.TabIndex = 7;
            this.lblTroubleUser.Text = "Trouble User";
            this.lblTroubleUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cdvTrbCode
            // 
            this.cdvTrbCode.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvTrbCode.BorderHotColor = System.Drawing.Color.Black;
            this.cdvTrbCode.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvTrbCode.BtnToolTipText = "";
            this.cdvTrbCode.DescText = "";
            this.cdvTrbCode.DisplaySubItemIndex = -1;
            this.cdvTrbCode.DisplayText = "";
            this.cdvTrbCode.Focusing = null;
            this.cdvTrbCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvTrbCode.Index = 0;
            this.cdvTrbCode.IsViewBtnImage = false;
            this.cdvTrbCode.Location = new System.Drawing.Point(120, 16);
            this.cdvTrbCode.MaxLength = 30;
            this.cdvTrbCode.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvTrbCode.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvTrbCode.Name = "cdvTrbCode";
            this.cdvTrbCode.ReadOnly = false;
            this.cdvTrbCode.SearchSubItemIndex = 0;
            this.cdvTrbCode.SelectedDescIndex = -1;
            this.cdvTrbCode.SelectedSubItemIndex = -1;
            this.cdvTrbCode.SelectionStart = 0;
            this.cdvTrbCode.Size = new System.Drawing.Size(200, 20);
            this.cdvTrbCode.SmallImageList = null;
            this.cdvTrbCode.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvTrbCode.TabIndex = 0;
            this.cdvTrbCode.TextBoxToolTipText = "";
            this.cdvTrbCode.TextBoxWidth = 200;
            this.cdvTrbCode.VisibleButton = true;
            this.cdvTrbCode.VisibleColumnHeader = false;
            this.cdvTrbCode.VisibleDescription = false;
            this.cdvTrbCode.ButtonPress += new System.EventHandler(this.cdvTrbCode_ButtonPress);
            // 
            // lblTroubleCode
            // 
            this.lblTroubleCode.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblTroubleCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTroubleCode.Location = new System.Drawing.Point(15, 19);
            this.lblTroubleCode.Name = "lblTroubleCode";
            this.lblTroubleCode.Size = new System.Drawing.Size(97, 14);
            this.lblTroubleCode.TabIndex = 0;
            this.lblTroubleCode.Text = "Trouble Code";
            this.lblTroubleCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // udtTrbTime
            // 
            this.udtTrbTime.DateTime = new System.DateTime(2005, 5, 11, 0, 0, 0, 0);
            this.udtTrbTime.DropDownButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.Never;
            this.udtTrbTime.FormatString = "";
            this.udtTrbTime.Location = new System.Drawing.Point(211, 40);
            this.udtTrbTime.MaskInput = "hh:mm:ss";
            this.udtTrbTime.Name = "udtTrbTime";
            this.udtTrbTime.Size = new System.Drawing.Size(72, 21);
            this.udtTrbTime.SpinButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.Always;
            this.udtTrbTime.SpinWrap = true;
            this.udtTrbTime.TabIndex = 3;
            this.udtTrbTime.Value = new System.DateTime(2005, 5, 11, 0, 0, 0, 0);
            // 
            // uccTrbDate
            // 
            this.uccTrbDate.BackColor = System.Drawing.SystemColors.Window;
            this.uccTrbDate.DateButtons.Add(dateButton2);
            this.uccTrbDate.Location = new System.Drawing.Point(120, 40);
            this.uccTrbDate.Name = "uccTrbDate";
            this.uccTrbDate.NonAutoSizeHeight = 21;
            this.uccTrbDate.Size = new System.Drawing.Size(88, 21);
            this.uccTrbDate.TabIndex = 2;
            this.uccTrbDate.Value = new System.DateTime(2005, 5, 9, 0, 0, 0, 0);
            // 
            // frmSPCTranOOCHistory
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Controls.Add(this.pnlOOC);
            this.Controls.Add(this.pnlResult);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.pnlBottom);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(750, 580);
            this.Name = "frmSPCTranOOCHistory";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "OOC History";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmSPCTranOOCHistory_Closing);
            this.Load += new System.EventHandler(this.frmSPCTranOOCHistory_Load);
            this.pnlBottom.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.grpChartInfo.ResumeLayout(false);
            this.grpChart.ResumeLayout(false);
            this.grpChart.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtGraphType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtChart)).EndInit();
            this.pnlResult.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdResult_Sheet1)).EndInit();
            this.pnlOOC.ResumeLayout(false);
            this.grpAction.ResumeLayout(false);
            this.grpAction.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtActComment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvActUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvActCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udtActTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uccActDate)).EndInit();
            this.grpTrouble.ResumeLayout(false);
            this.grpTrouble.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvInspector)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTrbComment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvTrbUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvTrbCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udtTrbTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uccTrbDate)).EndInit();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Variable Definition"
        private int giEdcHistSeq = - 1;
        private int giEdcUnitSeq = - 1;
        private string gsTranTime = "";
        #endregion
        
        #region " Funcion Definition"
        
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
                if (this.uccTrbDate.Value == System.DBNull.Value)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                    uccTrbDate.Focus();
                    return false;
                }
                
                if (this.udtTrbTime.Value == System.DBNull.Value)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                    udtTrbTime.Focus();
                    return false;
                }
                
                if (this.uccActDate.Value == System.DBNull.Value)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                    uccActDate.Focus();
                    return false;
                }
                
                if (this.udtActTime.Value == System.DBNull.Value)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                    udtActTime.Focus();
                    return false;
                }
                
                return true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranOOCHistory.CheckCondition()\n" + ex.Message);
                return false;
            }
            
        }
        
        // Update_OOC_History()
        //       - Update OOC History
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        
        private bool Update_OOC_History()
        {
            int i;
            int i_active_seq;
            
            try
            {
                TRSNode in_node = new TRSNode("OOC_History_In");
                TRSNode out_node = new TRSNode("Cmn_Out");

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = MPGC.MP_STEP_UPDATE;
                
                if (spdResult.Sheets[0].Columns[1].Visible == false)
                {
                    in_node.AddString("CHART_ID", MPCF.Trim(txtChart.Text));

                    if (giEdcHistSeq > - 1)
                    {
                        in_node.AddInt("EDC_HIST_SEQ", giEdcHistSeq);
                    }
                    else
                    {
                        return false;
                    }
                    if (giEdcUnitSeq > - 1)
                    {
                        in_node.AddInt("EDC_UNIT_SEQ", giEdcUnitSeq);
                    }
                    else
                    {
                        in_node.AddInt("EDC_UNIT_SEQ", MPCF.ToInt(spdResult.Sheets[0].Cells[spdResult.Sheets[0].ActiveRowIndex, 0].Text));
                    }
                    in_node.AddString("TRAN_TIME", MPCF.Trim(gsTranTime));
                }
                else
                {
                    in_node.AddInt("EDC_UNIT_SEQ", MPCF.ToInt(spdResult.Sheets[0].Cells[spdResult.Sheets[0].ActiveRowIndex, 0].Text));
                    in_node.AddString("CHART_ID", spdResult.Sheets[0].Cells[spdResult.Sheets[0].ActiveRowIndex, 1].Text);
                    in_node.AddInt("EDC_HIST_SEQ", MPCF.ToInt(spdResult.Sheets[0].Cells[spdResult.Sheets[0].ActiveRowIndex, 7].Text));
                    in_node.AddString("TRAN_TIME", spdResult.Sheets[0].Cells[spdResult.Sheets[0].ActiveRowIndex, 8].Text);

                }
                in_node.AddString("TRB_CODE", MPCF.Trim(cdvTrbCode.Text));
                in_node.AddString("TRB_USER", MPCF.Trim(cdvTrbUser.Text), true);
                in_node.AddString("TRB_COMMENT", MPCF.Trim(txtTrbComment.Text));
                in_node.AddString("TRB_TIME", ((DateTime)uccTrbDate.Value).ToString("yyyyMMdd") + ((DateTime)udtTrbTime.Value).ToString("HHmmss"));
                in_node.AddString("ACT_CODE", MPCF.Trim(cdvActCode.Text));
                in_node.AddString("ACT_USER", MPCF.Trim(cdvActUser.Text), true);
                in_node.AddString("ACT_COMMENT", MPCF.Trim(txtActComment.Text));
                in_node.AddString("ACT_TIME", ((DateTime)uccActDate.Value).ToString("yyyyMMdd") + ((DateTime)udtActTime.Value).ToString("HHmmss"));
                in_node.AddString("INSPECTOR", MPCF.Trim(cdvInspector.Text));

                if (MPCR.CallService("SPC", "SPC_OOC_History", in_node, ref out_node) == false)
                {
                    return false;
                }
                MPCR.ShowSuccessMsg(out_node);                                
                
                i_active_seq = (int)(spdResult.Sheets[0].Cells[spdResult.Sheets[0].ActiveRow.Index, 0].Value);

                for (i = 0; i < spdResult.Sheets[0].RowCount; i++)
                {
                    if (i_active_seq == (int)(spdResult.Sheets[0].Cells[i, 0].Value))
                    {
                        spdResult.Sheets[0].Cells[i, 6].Text = "Y";
                    }
                }

                // ¾Æ·¡ Logic ÀÌ»óÇÔ - 2010/12/09
                //spdResult.Sheets[0].Cells[spdResult.Sheets[0].ActiveRow.Index, 6].Text = "Y";
                //if (spdResult.Sheets[0].ActiveRow.Index != 0 && MPCF.Trim(spdResult.Sheets[0].Cells[spdResult.Sheets[0].ActiveRow.Index, 3].Value) == "R")
                //{
                //    if (spdResult.Sheets[0].Cells[spdResult.Sheets[0].ActiveRow.Index - 1, 6].RowSpan > 1)
                //    {
                //        spdResult.Sheets[0].Cells[spdResult.Sheets[0].ActiveRow.Index - 1, 6].Value = "Y";
                //    }
                //}
                
                return true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranOOCHistory.Update_OOC_History()\n" + ex.Message);
                return false;
            }
            
        }
        
        // View_OOC_History()
        //       - View OOC History
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal iRowIndex As Integer : row index
        //
        private bool View_OOC_History(int iRowIndex)
        {
            
            try
            {
                TRSNode in_node = new TRSNode("View_OOC_History_In");
                TRSNode out_node = new TRSNode("View_OOC_History_Out");
                string sUnitUseFlag = "";

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '2';

                if (spdResult.Sheets[0].Columns[1].Visible == false)
                {
                    in_node.AddString("CHART_ID", txtChart.Text);
                    in_node.AddInt("EDC_HIST_SEQ", giEdcHistSeq);
                    sUnitUseFlag = this.ctrlChartData.UseUnit.ToString();
                }
                else
                {
                    in_node.AddString("CHART_ID", MPCF.Trim(spdResult.Sheets[0].Cells[iRowIndex, 1].Value));
                    in_node.AddInt("EDC_HIST_SEQ", (int)spdResult.Sheets[0].Cells[iRowIndex, 7].Value);
                    sUnitUseFlag = View_Chart(MPCF.Trim(spdResult.Sheets[0].Cells[iRowIndex, 1].Value));
                }
                if (sUnitUseFlag == "Y")
                {
                    in_node.AddInt("EDC_UNIT_SEQ", MPCF.ToInt(spdResult.Sheets[0].Cells[iRowIndex, 0].Text));

                }
                else
                {
                    in_node.AddInt("EDC_UNIT_SEQ", 0);
                }

                if (MPCR.CallService("SPC", "SPC_View_OOC_History", in_node, ref out_node) == false)
                {
                    return false;
                }

                cdvTrbCode.Text = out_node.GetString("TRB_CODE");
                cdvTrbUser.Text = out_node.GetString("TRB_USER");

                if (MPCF.Trim(out_node.GetString("TRB_TIME")) == "")
                {
                    uccTrbDate.Value = DateTime.Now;
                    udtTrbTime.Value = DateTime.Now;
                }
                else
                {

                    uccTrbDate.Value = MPCF.ToDate(out_node.GetString("TRB_TIME"));
                    udtTrbTime.Value = MPCF.ToDate(out_node.GetString("TRB_TIME"));
                }

                txtTrbComment.Text = out_node.GetString("TRB_COMMENT");
                cdvActCode.Text = out_node.GetString("ACT_CODE");
                cdvActUser.Text = out_node.GetString("ACT_USER");
                if (MPCF.Trim(out_node.GetString("ACT_TIME")) == "")
                {
                    uccActDate.Value = DateTime.Now;
                    udtActTime.Value = DateTime.Now;
                }
                else
                {
                    uccActDate.Value = MPCF.ToDate(out_node.GetString("ACT_TIME"));
                    udtActTime.Value = MPCF.ToDate(out_node.GetString("ACT_TIME"));
                }
                txtActComment.Text = out_node.GetString("ACT_COMMENT");
                cdvInspector.Text = out_node.GetString("INSPECTOR");
                
                return true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranOOCHistory.View_OOC_History()\n" + ex.Message);
                return false;
            }
            
        }
        
        // View_Chart()
        //       - View Chart
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal sChartID As String : ì°¨íŠ¸ ëª?
        //
        private string View_Chart(string sChartID)
        {
            
            try
            {
                TRSNode in_node = new TRSNode("View_Chart_In");
                TRSNode out_node = new TRSNode("View_Chart_Out");

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("CHART_ID", MPCF.Trim(sChartID));

                if (MPCR.CallService("SPC", "SPC_View_Chart", in_node, ref out_node) == false)
                {
                    return "";
                }
                
                return out_node.GetChar("UNIT_USE_FLAG").ToString();
                
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranOOCHistory.View_OOC_History()\n" + ex.Message);
                return null;
            }
            
        }
        
        #endregion
        
        #region " Event Implematations"
        
        private void frmSPCTranOOCHistory_Load(object sender, System.EventArgs e)
        {
            
            try
            {
                MPGV.gIBaseFormEvent.Form_Load(this, e);
                MPCF.SetTextboxStyle(this.Controls);
                
                uccTrbDate.Value = DateTime.Now;
                udtTrbTime.Value = DateTime.Now;
                uccActDate.Value = DateTime.Now;
                udtActTime.Value = DateTime.Now;
                
                cdvTrbUser.Text = MPGV.gsUserID;
                cdvActUser.Text = MPGV.gsUserID;
                if (txtChart.Text == "")
                {
                    return;
                }
                if (ctrlChartData.ViewChartInformation(txtChart.Text, false) == false)
                {
                    return;
                }
                txtGraphType.Text = ctrlChartData.ChartGraphType;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranOOCHistory.frmSPCTranOOCHistory_Load()\n" + ex.Message);
            }
            
        }
        
        private void btnOK_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                if (CheckCondition() == false)
                {
                    return;
                }
                if (Update_OOC_History() == false)
                {
                    return;
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranOOCHistory.btnOK_Click()\n" + ex.Message);
            }
            
        }
        
        private void spdResult_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            try
            {
                //View_OOC_History(e.Row)
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranOOCHistory.spdResult_CellClick()\n" + ex.Message);
            }
        }
        
        private void spdResult_SelectionChanged(object sender, FarPoint.Win.Spread.SelectionChangedEventArgs e)
        {
            
            try
            {
                if (e.Range.Row < 0)
                {
                    return;
                }
                
                if (spdResult.Sheets[0].Cells[e.Range.Row, 0].Text == "")
                {
                    View_OOC_History(e.Range.Row - 1);
                }
                else
                {
                    View_OOC_History(e.Range.Row);
                }
                
                if (spdResult.Sheets[0].Cells[e.Range.Row, 0].RowSpan == 2)
                {
                    
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranOOCHistory.spdResult_SelectionChanged()\n" + ex.Message);
            }
            
        }
        
        private void cdvActCode_ButtonPress(object sender, System.EventArgs e)
        {
            
            try
            {
                cdvActCode.Init();
                MPCF.InitListView(cdvActCode.GetListView);
                cdvActCode.Columns.Add("Action Code", 50, HorizontalAlignment.Left);
                cdvActCode.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvActCode.SelectedSubItemIndex = 0;
                BASLIST.ViewGCMDataList(cdvActCode.GetListView, '1', modSPCConstants.MP_SPC_ACTION_CODE);
                if (cdvActCode.AddEmptyRow(1) == false)
                {
                    return;
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranOOCHistory.cdvActCode_ButtonPress()\n" + ex.Message);
            }
            
        }
        
        private void cdvActUser_ButtonPress(object sender, System.EventArgs e)
        {
            
            try
            {
                cdvActUser.Init();
                MPCF.InitListView(cdvActUser.GetListView);
                cdvActUser.Columns.Add("UserID", 100, HorizontalAlignment.Left);
                cdvActUser.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvActUser.SelectedSubItemIndex = 0;
                SECLIST.ViewSECUserList(cdvActUser.GetListView, '1', -1, null, "", "");
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranOOCHistory.cdvActUser_ButtonPress()\n" + ex.Message);
            }
            
        }
        
        private void cdvInspector_ButtonPress(object sender, System.EventArgs e)
        {
            
            try
            {
                cdvInspector.Init();
                MPCF.InitListView(cdvInspector.GetListView);
                cdvInspector.Columns.Add("UserID", 100, HorizontalAlignment.Left);
                cdvInspector.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvInspector.SelectedSubItemIndex = 0;
                SECLIST.ViewSECUserList(cdvInspector.GetListView, '1', -1, null, "", "");
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranOOCHistory.cdvInspector_ButtonPress()\n" + ex.Message);
            }
            
        }
        
        private void cdvTrbCode_ButtonPress(object sender, System.EventArgs e)
        {
            
            try
            {
                cdvTrbCode.Init();
                MPCF.InitListView(cdvTrbCode.GetListView);
                cdvTrbCode.Columns.Add("Trouble Code", 50, HorizontalAlignment.Left);
                cdvTrbCode.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvTrbCode.SelectedSubItemIndex = 0;
                BASLIST.ViewGCMDataList(cdvTrbCode.GetListView, '1', modSPCConstants.MP_SPC_TROUBLE_CODE);
                if (cdvTrbCode.AddEmptyRow(1) == false)
                {
                    return;
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranOOCHistory.cdvTrbCode_ButtonPress()\n" + ex.Message);
            }
            
        }
        
        private void cdvTrbUser_ButtonPress(object sender, System.EventArgs e)
        {
            
            try
            {
                cdvTrbUser.Init();
                MPCF.InitListView(cdvTrbUser.GetListView);
                cdvTrbUser.Columns.Add("UserID", 100, HorizontalAlignment.Left);
                cdvTrbUser.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvTrbUser.SelectedSubItemIndex = 0;
                SECLIST.ViewSECUserList(cdvTrbUser.GetListView, '1', -1, null, "", "");
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranOOCHistory.cdvTrbUser_ButtonPress()\n" + ex.Message);
            }
            
        }
        
        private void frmSPCTranOOCHistory_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            
            try
            {
                int i;
                for (i = 0; i <= spdResult.Sheets[0].RowCount - 1; i++)
                {
                    if (spdResult.Sheets[0].Cells[i, 6].Text == "" && spdResult.Sheets[0].Cells[i, 0].Text != "")
                    {
                        if (MPCF.ShowMsgBox(MPCF.GetMessage(211), MessageBoxButtons.YesNo, 1) == System.Windows.Forms.DialogResult.No)
                        {
                            e.Cancel = true;
                            return;
                        }
                        else
                        {
                            return;
                        }
                    }
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranOOCHistory.frmSPCTranOOCHistory_Closing()\n" + ex.Message);
            }
            
        }
        
        private void btnRefresh_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                if (txtChart.Text == "")
                {
                    return;
                }
                if (ctrlChartData.ViewChartInformation(txtChart.Text, false) == false)
                {
                    return;
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranOOCHistory.btnRefresh_Click()\n" + ex.Message);
            }
            
        }
        
        #endregion
        
    }
    
    
    //#End If
    
}
