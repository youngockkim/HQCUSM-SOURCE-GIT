
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
//   File Name   : frmSPCSetupPrompt.vb
//   Description :
//
//   MES Version : 1.0.0
//
//   Function List
//       - CheckCondition() : Check the Conditions before Transaction
//       - View_Prompt() : View Prompt Information
//       - Update_Prompt() : Create/Update/Delete Prompt
//       - View_Chart() : View Chart Information
//
//
//
//   Detail Description
//       -
//       -
//
//   History
//       - 2006-02-23 : Created by H.K.Kim
//
//
//   Copyright(C) 1998-2004 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------
namespace Miracom.SPCCore
{
    public class frmSPCSetupPrompt : System.Windows.Forms.Form
    {
        
        #region " Windows Form auto generated code "
        
        public frmSPCSetupPrompt()
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
        



        public System.Windows.Forms.Panel pnlBottom;
        public System.Windows.Forms.Button btnDelete;
        public System.Windows.Forms.Panel pnlFind;
        public System.Windows.Forms.Label lblDataCount;
        public System.Windows.Forms.Label lblDataCountBack;
        public System.Windows.Forms.Button btnExcel;
        public System.Windows.Forms.Button btnRefresh;
        public System.Windows.Forms.Button btnNext;
        public Infragistics.Win.UltraWinEditors.UltraTextEditor txtFind;
        public System.Windows.Forms.Button btnUpdate;
        public System.Windows.Forms.Button btnClose;
        public System.Windows.Forms.Panel pnlLeft;
        internal Miracom.UI.Controls.MCListView.MCListView lisChart;
        internal System.Windows.Forms.Panel pnlFilter;
        internal System.Windows.Forms.GroupBox grpFilter;
        public System.Windows.Forms.Button btnView;
        internal Infragistics.Win.UltraWinEditors.UltraTextEditor txtFilter;
        internal System.Windows.Forms.RadioButton rbnAll;
        internal System.Windows.Forms.RadioButton rbnFilter;
        internal System.Windows.Forms.ColumnHeader ColumnHeader1;
        internal System.Windows.Forms.ColumnHeader ColumnHeader2;
        public System.Windows.Forms.Panel pnlRight;
        internal System.Windows.Forms.Panel pnlPrompt;
        internal System.Windows.Forms.GroupBox grpChart;
        internal Infragistics.Win.UltraWinEditors.UltraComboEditor cboGraphType;
        internal System.Windows.Forms.Label lblDesc;
        internal System.Windows.Forms.Label lblChart;
        internal Infragistics.Win.UltraWinEditors.UltraTextEditor txtDesc;
        internal Infragistics.Win.UltraWinEditors.UltraTextEditor txtChart;
        internal FarPoint.Win.Spread.FpSpread spdPrompt;
        internal FarPoint.Win.Spread.SheetView spdPrompt_Sheet1;
        internal System.Windows.Forms.GroupBox grpChartInfo;
        internal Infragistics.Win.UltraWinEditors.UltraTextEditor txtUnitCount;
        internal Infragistics.Win.UltraWinEditors.UltraTextEditor txtSampleSize;
        internal System.Windows.Forms.Label lblSampleSize;
        internal System.Windows.Forms.Label lblUnitCount;
        internal Infragistics.Win.UltraWinEditors.UltraCheckEditor chkAscii;
        internal System.Windows.Forms.Label lblLotorRes;
        internal Infragistics.Win.UltraWinEditors.UltraTextEditor txtLotorRes;
        internal System.Windows.Forms.GroupBox grpCopy;
        internal System.Windows.Forms.Label lblFromChartID;
        public System.Windows.Forms.Button btnCopy;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvFromChartID;
        internal System.Windows.Forms.Button btnFiltering;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSPCSetupPrompt));
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer2 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer3 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer4 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.pnlFind = new System.Windows.Forms.Panel();
            this.lblDataCount = new System.Windows.Forms.Label();
            this.lblDataCountBack = new System.Windows.Forms.Label();
            this.btnExcel = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.txtFind = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.lisChart = new Miracom.UI.Controls.MCListView.MCListView();
            this.ColumnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.grpFilter = new System.Windows.Forms.GroupBox();
            this.btnView = new System.Windows.Forms.Button();
            this.txtFilter = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.rbnAll = new System.Windows.Forms.RadioButton();
            this.rbnFilter = new System.Windows.Forms.RadioButton();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.pnlPrompt = new System.Windows.Forms.Panel();
            this.spdPrompt = new FarPoint.Win.Spread.FpSpread();
            this.spdPrompt_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.grpCopy = new System.Windows.Forms.GroupBox();
            this.btnCopy = new System.Windows.Forms.Button();
            this.cdvFromChartID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblFromChartID = new System.Windows.Forms.Label();
            this.grpChartInfo = new System.Windows.Forms.GroupBox();
            this.txtUnitCount = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.txtSampleSize = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lblSampleSize = new System.Windows.Forms.Label();
            this.lblUnitCount = new System.Windows.Forms.Label();
            this.chkAscii = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.lblLotorRes = new System.Windows.Forms.Label();
            this.txtLotorRes = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.grpChart = new System.Windows.Forms.GroupBox();
            this.btnFiltering = new System.Windows.Forms.Button();
            this.cboGraphType = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.lblDesc = new System.Windows.Forms.Label();
            this.lblChart = new System.Windows.Forms.Label();
            this.txtDesc = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.txtChart = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.pnlBottom.SuspendLayout();
            this.pnlFind.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFind)).BeginInit();
            this.pnlLeft.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.grpFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFilter)).BeginInit();
            this.pnlRight.SuspendLayout();
            this.pnlPrompt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdPrompt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdPrompt_Sheet1)).BeginInit();
            this.grpCopy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvFromChartID)).BeginInit();
            this.grpChartInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnitCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSampleSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAscii)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLotorRes)).BeginInit();
            this.grpChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboGraphType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDesc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtChart)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnDelete);
            this.pnlBottom.Controls.Add(this.pnlFind);
            this.pnlBottom.Controls.Add(this.btnUpdate);
            this.pnlBottom.Controls.Add(this.btnClose);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 506);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(742, 40);
            this.pnlBottom.TabIndex = 2;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnDelete.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnDelete.Location = new System.Drawing.Point(557, 7);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(88, 26);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // pnlFind
            // 
            this.pnlFind.Controls.Add(this.lblDataCount);
            this.pnlFind.Controls.Add(this.lblDataCountBack);
            this.pnlFind.Controls.Add(this.btnExcel);
            this.pnlFind.Controls.Add(this.btnRefresh);
            this.pnlFind.Controls.Add(this.btnNext);
            this.pnlFind.Controls.Add(this.txtFind);
            this.pnlFind.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlFind.Location = new System.Drawing.Point(0, 0);
            this.pnlFind.Name = "pnlFind";
            this.pnlFind.Size = new System.Drawing.Size(232, 40);
            this.pnlFind.TabIndex = 3;
            // 
            // lblDataCount
            // 
            this.lblDataCount.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblDataCount.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblDataCount.Location = new System.Drawing.Point(7, 13);
            this.lblDataCount.Name = "lblDataCount";
            this.lblDataCount.Size = new System.Drawing.Size(36, 16);
            this.lblDataCount.TabIndex = 0;
            this.lblDataCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDataCountBack
            // 
            this.lblDataCountBack.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDataCountBack.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblDataCountBack.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblDataCountBack.Location = new System.Drawing.Point(4, 8);
            this.lblDataCountBack.Name = "lblDataCountBack";
            this.lblDataCountBack.Size = new System.Drawing.Size(42, 24);
            this.lblDataCountBack.TabIndex = 6;
            this.lblDataCountBack.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnExcel
            // 
            this.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExcel.Image")));
            this.btnExcel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnExcel.Location = new System.Drawing.Point(200, 8);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(24, 24);
            this.btnExcel.TabIndex = 4;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnRefresh.Location = new System.Drawing.Point(174, 8);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(24, 24);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnNext
            // 
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNext.Image = ((System.Drawing.Image)(resources.GetObject("btnNext.Image")));
            this.btnNext.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnNext.Location = new System.Drawing.Point(148, 8);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(24, 24);
            this.btnNext.TabIndex = 2;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // txtFind
            // 
            this.txtFind.AutoSize = false;
            this.txtFind.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFind.Location = new System.Drawing.Point(48, 8);
            this.txtFind.Name = "txtFind";
            this.txtFind.Size = new System.Drawing.Size(96, 24);
            this.txtFind.TabIndex = 1;
            this.txtFind.TextChanged += new System.EventHandler(this.txtFind_TextChanged);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnUpdate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnUpdate.Location = new System.Drawing.Point(465, 7);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(88, 26);
            this.btnUpdate.TabIndex = 0;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
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
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.lisChart);
            this.pnlLeft.Controls.Add(this.pnlFilter);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Padding = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.pnlLeft.Size = new System.Drawing.Size(232, 506);
            this.pnlLeft.TabIndex = 0;
            // 
            // lisChart
            // 
            this.lisChart.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader1,
            this.ColumnHeader2});
            this.lisChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisChart.EnableSort = true;
            this.lisChart.EnableSortIcon = true;
            this.lisChart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisChart.FullRowSelect = true;
            this.lisChart.Location = new System.Drawing.Point(3, 43);
            this.lisChart.MultiSelect = false;
            this.lisChart.Name = "lisChart";
            this.lisChart.Size = new System.Drawing.Size(229, 460);
            this.lisChart.TabIndex = 0;
            this.lisChart.UseCompatibleStateImageBehavior = false;
            this.lisChart.View = System.Windows.Forms.View.Details;
            this.lisChart.SelectedIndexChanged += new System.EventHandler(this.lisChart_SelectedIndexChanged);
            // 
            // ColumnHeader1
            // 
            this.ColumnHeader1.Text = "Chart";
            this.ColumnHeader1.Width = 100;
            // 
            // ColumnHeader2
            // 
            this.ColumnHeader2.Text = "Description";
            this.ColumnHeader2.Width = 300;
            // 
            // pnlFilter
            // 
            this.pnlFilter.Controls.Add(this.grpFilter);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(3, 3);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Padding = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.pnlFilter.Size = new System.Drawing.Size(229, 40);
            this.pnlFilter.TabIndex = 3;
            // 
            // grpFilter
            // 
            this.grpFilter.Controls.Add(this.btnView);
            this.grpFilter.Controls.Add(this.txtFilter);
            this.grpFilter.Controls.Add(this.rbnAll);
            this.grpFilter.Controls.Add(this.rbnFilter);
            this.grpFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpFilter.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpFilter.Location = new System.Drawing.Point(0, 0);
            this.grpFilter.Name = "grpFilter";
            this.grpFilter.Size = new System.Drawing.Size(229, 38);
            this.grpFilter.TabIndex = 0;
            this.grpFilter.TabStop = false;
            // 
            // btnView
            // 
            this.btnView.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnView.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnView.Location = new System.Drawing.Point(184, 13);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(36, 20);
            this.btnView.TabIndex = 3;
            this.btnView.Text = "View";
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // txtFilter
            // 
            this.txtFilter.Location = new System.Drawing.Point(26, 13);
            this.txtFilter.MaxLength = 30;
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(98, 20);
            this.txtFilter.TabIndex = 1;
            this.txtFilter.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            // 
            // rbnAll
            // 
            this.rbnAll.AutoSize = true;
            this.rbnAll.Location = new System.Drawing.Point(131, 16);
            this.rbnAll.Name = "rbnAll";
            this.rbnAll.Size = new System.Drawing.Size(36, 17);
            this.rbnAll.TabIndex = 2;
            this.rbnAll.Text = "All";
            // 
            // rbnFilter
            // 
            this.rbnFilter.AutoSize = true;
            this.rbnFilter.Location = new System.Drawing.Point(8, 16);
            this.rbnFilter.Name = "rbnFilter";
            this.rbnFilter.Size = new System.Drawing.Size(14, 13);
            this.rbnFilter.TabIndex = 0;
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.pnlPrompt);
            this.pnlRight.Controls.Add(this.grpChartInfo);
            this.pnlRight.Controls.Add(this.grpChart);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.Location = new System.Drawing.Point(232, 0);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Padding = new System.Windows.Forms.Padding(3);
            this.pnlRight.Size = new System.Drawing.Size(510, 506);
            this.pnlRight.TabIndex = 4;
            // 
            // pnlPrompt
            // 
            this.pnlPrompt.Controls.Add(this.spdPrompt);
            this.pnlPrompt.Controls.Add(this.grpCopy);
            this.pnlPrompt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPrompt.Location = new System.Drawing.Point(3, 144);
            this.pnlPrompt.Name = "pnlPrompt";
            this.pnlPrompt.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.pnlPrompt.Size = new System.Drawing.Size(504, 359);
            this.pnlPrompt.TabIndex = 3;
            // 
            // spdPrompt
            // 
            this.spdPrompt.AccessibleDescription = "spdPrompt, Sheet1, Row 0, Column 0, ";
            this.spdPrompt.BackColor = System.Drawing.SystemColors.Control;
            this.spdPrompt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdPrompt.FocusRenderer = defaultFocusIndicatorRenderer2;
            this.spdPrompt.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdPrompt.HorizontalScrollBar.Name = "";
            this.spdPrompt.HorizontalScrollBar.Renderer = defaultScrollBarRenderer3;
            this.spdPrompt.HorizontalScrollBar.TabIndex = 2;
            this.spdPrompt.Location = new System.Drawing.Point(0, 5);
            this.spdPrompt.Name = "spdPrompt";
            this.spdPrompt.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdPrompt.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdPrompt.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdPrompt_Sheet1});
            this.spdPrompt.Size = new System.Drawing.Size(504, 310);
            this.spdPrompt.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdPrompt.TabIndex = 6;
            this.spdPrompt.TextTipDelay = 200;
            this.spdPrompt.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdPrompt.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdPrompt.VerticalScrollBar.Name = "";
            this.spdPrompt.VerticalScrollBar.Renderer = defaultScrollBarRenderer4;
            this.spdPrompt.VerticalScrollBar.TabIndex = 3;
            // 
            // spdPrompt_Sheet1
            // 
            this.spdPrompt_Sheet1.Reset();
            spdPrompt_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdPrompt_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdPrompt_Sheet1.ColumnCount = 1;
            spdPrompt_Sheet1.RowCount = 100;
            this.spdPrompt_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdPrompt_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdPrompt_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdPrompt_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdPrompt_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Prompt";
            this.spdPrompt_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdPrompt_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            textCellType2.MaxLength = 20;
            this.spdPrompt_Sheet1.Columns.Get(0).CellType = textCellType2;
            this.spdPrompt_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdPrompt_Sheet1.Columns.Get(0).Label = "Prompt";
            this.spdPrompt_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdPrompt_Sheet1.Columns.Get(0).Width = 300F;
            this.spdPrompt_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdPrompt_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdPrompt_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdPrompt_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdPrompt_Sheet1.Rows.Default.Height = 18F;
            this.spdPrompt_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdPrompt_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdPrompt_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // grpCopy
            // 
            this.grpCopy.Controls.Add(this.btnCopy);
            this.grpCopy.Controls.Add(this.cdvFromChartID);
            this.grpCopy.Controls.Add(this.lblFromChartID);
            this.grpCopy.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpCopy.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpCopy.Location = new System.Drawing.Point(0, 315);
            this.grpCopy.Name = "grpCopy";
            this.grpCopy.Size = new System.Drawing.Size(504, 44);
            this.grpCopy.TabIndex = 7;
            this.grpCopy.TabStop = false;
            this.grpCopy.Text = "Copy";
            // 
            // btnCopy
            // 
            this.btnCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCopy.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCopy.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCopy.Location = new System.Drawing.Point(408, 8);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(88, 26);
            this.btnCopy.TabIndex = 2;
            this.btnCopy.Text = "Copy";
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // cdvFromChartID
            // 
            this.cdvFromChartID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvFromChartID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvFromChartID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvFromChartID.BtnToolTipText = "";
            this.cdvFromChartID.DescText = "";
            this.cdvFromChartID.DisplaySubItemIndex = -1;
            this.cdvFromChartID.DisplayText = "";
            this.cdvFromChartID.Focusing = null;
            this.cdvFromChartID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvFromChartID.Index = 0;
            this.cdvFromChartID.IsViewBtnImage = false;
            this.cdvFromChartID.Location = new System.Drawing.Point(120, 16);
            this.cdvFromChartID.MaxLength = 30;
            this.cdvFromChartID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvFromChartID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvFromChartID.Name = "cdvFromChartID";
            this.cdvFromChartID.ReadOnly = false;
            this.cdvFromChartID.SearchSubItemIndex = 0;
            this.cdvFromChartID.SelectedDescIndex = -1;
            this.cdvFromChartID.SelectedSubItemIndex = -1;
            this.cdvFromChartID.SelectionStart = 0;
            this.cdvFromChartID.Size = new System.Drawing.Size(200, 20);
            this.cdvFromChartID.SmallImageList = null;
            this.cdvFromChartID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvFromChartID.TabIndex = 1;
            this.cdvFromChartID.TextBoxToolTipText = "";
            this.cdvFromChartID.TextBoxWidth = 200;
            this.cdvFromChartID.VisibleButton = true;
            this.cdvFromChartID.VisibleColumnHeader = false;
            this.cdvFromChartID.VisibleDescription = false;
            this.cdvFromChartID.ButtonPress += new System.EventHandler(this.cdvFromChartID_ButtonPress);
            // 
            // lblFromChartID
            // 
            this.lblFromChartID.AutoSize = true;
            this.lblFromChartID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblFromChartID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFromChartID.Location = new System.Drawing.Point(15, 19);
            this.lblFromChartID.Name = "lblFromChartID";
            this.lblFromChartID.Size = new System.Drawing.Size(72, 13);
            this.lblFromChartID.TabIndex = 0;
            this.lblFromChartID.Text = "From Chart ID";
            // 
            // grpChartInfo
            // 
            this.grpChartInfo.Controls.Add(this.txtUnitCount);
            this.grpChartInfo.Controls.Add(this.txtSampleSize);
            this.grpChartInfo.Controls.Add(this.lblSampleSize);
            this.grpChartInfo.Controls.Add(this.lblUnitCount);
            this.grpChartInfo.Controls.Add(this.chkAscii);
            this.grpChartInfo.Controls.Add(this.lblLotorRes);
            this.grpChartInfo.Controls.Add(this.txtLotorRes);
            this.grpChartInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpChartInfo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpChartInfo.Location = new System.Drawing.Point(3, 72);
            this.grpChartInfo.Name = "grpChartInfo";
            this.grpChartInfo.Size = new System.Drawing.Size(504, 72);
            this.grpChartInfo.TabIndex = 1;
            this.grpChartInfo.TabStop = false;
            // 
            // txtUnitCount
            // 
            this.txtUnitCount.Location = new System.Drawing.Point(352, 41);
            this.txtUnitCount.MaxLength = 30;
            this.txtUnitCount.Name = "txtUnitCount";
            this.txtUnitCount.ReadOnly = true;
            this.txtUnitCount.Size = new System.Drawing.Size(110, 20);
            this.txtUnitCount.TabIndex = 7;
            // 
            // txtSampleSize
            // 
            this.txtSampleSize.Location = new System.Drawing.Point(120, 41);
            this.txtSampleSize.MaxLength = 30;
            this.txtSampleSize.Name = "txtSampleSize";
            this.txtSampleSize.ReadOnly = true;
            this.txtSampleSize.Size = new System.Drawing.Size(110, 20);
            this.txtSampleSize.TabIndex = 5;
            // 
            // lblSampleSize
            // 
            this.lblSampleSize.AutoSize = true;
            this.lblSampleSize.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblSampleSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSampleSize.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblSampleSize.Location = new System.Drawing.Point(15, 44);
            this.lblSampleSize.Name = "lblSampleSize";
            this.lblSampleSize.Size = new System.Drawing.Size(65, 13);
            this.lblSampleSize.TabIndex = 4;
            this.lblSampleSize.Text = "Sample Size";
            // 
            // lblUnitCount
            // 
            this.lblUnitCount.AutoSize = true;
            this.lblUnitCount.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUnitCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUnitCount.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblUnitCount.Location = new System.Drawing.Point(244, 44);
            this.lblUnitCount.Name = "lblUnitCount";
            this.lblUnitCount.Size = new System.Drawing.Size(57, 13);
            this.lblUnitCount.TabIndex = 6;
            this.lblUnitCount.Text = "Unit Count";
            // 
            // chkAscii
            // 
            this.chkAscii.AutoSize = true;
            this.chkAscii.Enabled = false;
            this.chkAscii.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkAscii.Location = new System.Drawing.Point(244, 19);
            this.chkAscii.Name = "chkAscii";
            this.chkAscii.Size = new System.Drawing.Size(80, 17);
            this.chkAscii.TabIndex = 2;
            this.chkAscii.Text = "Ascii Data";
            this.chkAscii.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            // 
            // lblLotorRes
            // 
            this.lblLotorRes.AutoSize = true;
            this.lblLotorRes.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLotorRes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLotorRes.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblLotorRes.Location = new System.Drawing.Point(15, 19);
            this.lblLotorRes.Name = "lblLotorRes";
            this.lblLotorRes.Size = new System.Drawing.Size(79, 13);
            this.lblLotorRes.TabIndex = 0;
            this.lblLotorRes.Text = "Lot / Resource";
            // 
            // txtLotorRes
            // 
            this.txtLotorRes.Location = new System.Drawing.Point(120, 16);
            this.txtLotorRes.MaxLength = 10;
            this.txtLotorRes.Name = "txtLotorRes";
            this.txtLotorRes.ReadOnly = true;
            this.txtLotorRes.Size = new System.Drawing.Size(110, 20);
            this.txtLotorRes.TabIndex = 1;
            // 
            // grpChart
            // 
            this.grpChart.Controls.Add(this.btnFiltering);
            this.grpChart.Controls.Add(this.cboGraphType);
            this.grpChart.Controls.Add(this.lblDesc);
            this.grpChart.Controls.Add(this.lblChart);
            this.grpChart.Controls.Add(this.txtDesc);
            this.grpChart.Controls.Add(this.txtChart);
            this.grpChart.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpChart.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpChart.Location = new System.Drawing.Point(3, 3);
            this.grpChart.Name = "grpChart";
            this.grpChart.Size = new System.Drawing.Size(504, 69);
            this.grpChart.TabIndex = 0;
            this.grpChart.TabStop = false;
            // 
            // btnFiltering
            // 
            this.btnFiltering.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFiltering.Image = ((System.Drawing.Image)(resources.GetObject("btnFiltering.Image")));
            this.btnFiltering.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnFiltering.Location = new System.Drawing.Point(324, 14);
            this.btnFiltering.Name = "btnFiltering";
            this.btnFiltering.Size = new System.Drawing.Size(24, 24);
            this.btnFiltering.TabIndex = 2;
            this.btnFiltering.Click += new System.EventHandler(this.btnFiltering_Click);
            // 
            // cboGraphType
            // 
            this.cboGraphType.DropDownButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.Never;
            this.cboGraphType.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cboGraphType.Location = new System.Drawing.Point(352, 17);
            this.cboGraphType.Name = "cboGraphType";
            this.cboGraphType.ReadOnly = true;
            this.cboGraphType.Size = new System.Drawing.Size(128, 19);
            this.cboGraphType.TabIndex = 3;
            this.cboGraphType.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblDesc.Location = new System.Drawing.Point(15, 43);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(60, 13);
            this.lblDesc.TabIndex = 4;
            this.lblDesc.Text = "Description";
            // 
            // lblChart
            // 
            this.lblChart.AutoSize = true;
            this.lblChart.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblChart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChart.Location = new System.Drawing.Point(15, 19);
            this.lblChart.Name = "lblChart";
            this.lblChart.Size = new System.Drawing.Size(54, 13);
            this.lblChart.TabIndex = 0;
            this.lblChart.Text = "Chart ID";
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(120, 40);
            this.txtDesc.MaxLength = 50;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.ReadOnly = true;
            this.txtDesc.Size = new System.Drawing.Size(360, 20);
            this.txtDesc.TabIndex = 5;
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
            // frmSPCSetupPrompt
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.pnlBottom);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(750, 580);
            this.Name = "frmSPCSetupPrompt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "EDC Data Prompt Setup";
            this.Load += new System.EventHandler(this.frmSPCSetupPrompt_Load);
            this.pnlBottom.ResumeLayout(false);
            this.pnlFind.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtFind)).EndInit();
            this.pnlLeft.ResumeLayout(false);
            this.pnlFilter.ResumeLayout(false);
            this.grpFilter.ResumeLayout(false);
            this.grpFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFilter)).EndInit();
            this.pnlRight.ResumeLayout(false);
            this.pnlPrompt.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdPrompt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdPrompt_Sheet1)).EndInit();
            this.grpCopy.ResumeLayout(false);
            this.grpCopy.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvFromChartID)).EndInit();
            this.grpChartInfo.ResumeLayout(false);
            this.grpChartInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnitCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSampleSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAscii)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLotorRes)).EndInit();
            this.grpChart.ResumeLayout(false);
            this.grpChart.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboGraphType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDesc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtChart)).EndInit();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Function Implementations"
        
        // CheckCondition()
        //       - Check the conditions before transaction
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal FuncName As String : Function Name
        //
        private bool CheckCondition(char FuncName)
        {
            
            try
            {
                int i;
                if (txtChart.Text == "")
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                    txtChart.Focus();
                    return false;
                }

                switch (FuncName)
                {
                    case MPGC.MP_STEP_UPDATE:
                        
                        for (i = 0; i <= spdPrompt.Sheets[0].RowCount - 1; i++)
                        {
                            if (MPCF.Trim(spdPrompt.Sheets[0].Cells[i, 0].Value) == "")
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                                spdPrompt.Sheets[0].SetActiveCell(i, 0);
                                return false;
                            }
                        }
                        break;
                }
                
                return true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCSetupPrompt.CheckCondition()\n" + ex.Message);
                return false;
            }
            
        }
        
        // View_Chart()
        //       - View Chart
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool View_Chart(string sChartID)
        {
            
            try
            {
                TRSNode in_node = new TRSNode("View_Chart_In");
                TRSNode out_node = new TRSNode("View_Chart_Out");
                int iGraphType = 0;

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("CHART_ID", MPCF.Trim(sChartID));

                if (MPCR.CallService("SPC", "SPC_View_Chart", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCF.FieldClear(this.grpChartInfo);

                txtDesc.Text = out_node.GetString("CHART_DESC");

                if (MPCF.Trim(out_node.GetString("GRAPH_TYPE")) == "")
                {
                    cboGraphType.SelectedIndex = - 1;
                }
                else
                {
                    cboGraphType.SelectedIndex = (int)Enum.Parse(typeof(eGraphType), MPCF.Trim(out_node.GetString("GRAPH_TYPE")));
                }
                iGraphType = cboGraphType.SelectedIndex;

                if (MPCF.Trim(out_node.GetChar("LOT_RES_FLAG")) == "L")
                {
                    txtLotorRes.Text = "Lot";
                }
                else if (MPCF.Trim(out_node.GetChar("LOT_RES_FLAG")) == "R")
                {
                    txtLotorRes.Text = "Resource";
                }

                txtSampleSize.Text = out_node.GetInt("SAMPLE_SIZE").ToString();
                txtUnitCount.Text = out_node.GetInt("UNIT_COUNT").ToString();


                MPCF.ClearList(spdPrompt, true);
                
                if (iGraphType == MPCF.ToInt(eGraphType.P) || iGraphType == MPCF.ToInt(eGraphType.U))
                {
                    spdPrompt.Sheets[0].RowCount = 2;
                }
                else if (iGraphType == MPCF.ToInt(eGraphType.PN) || iGraphType == MPCF.ToInt(eGraphType.C))
                {
                    spdPrompt.Sheets[0].RowCount = 1;
                }
                else
                {
                    spdPrompt.Sheets[0].RowCount = out_node.GetInt("SAMPLE_SIZE");
                }
                
                return true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCSetupPrompt.View_Chart()\n" + ex.Message);
                return false;
            }
            
        }
        
        // View_Prompt()
        //       - View Prompt
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool View_Prompt(string sChartID)
        {
            
            try
            {
                TRSNode in_node = new TRSNode("View_Prompt_In");
                TRSNode out_node = new TRSNode("View_Prompt_Out");
                int i = 0;

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("CHART_ID", MPCF.Trim(sChartID));

                if (MPCR.CallService("SPC", "SPC_View_Prompt", in_node, ref out_node) == false)
                {
                    return false;
                }
                                
                for (i = 0; i <= spdPrompt.Sheets[0].RowCount - 1; i++)
                {
                    spdPrompt.Sheets[0].Cells[i, 0].Value = out_node.GetList(0)[i].GetString("PROMPT");
                }
                
                return true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCSetupPrompt.View_Prompt()\n" + ex.Message);
                return false;
            }
            
        }
        
        // Update_Prompt()
        //       - Update Prompt
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool Update_Prompt(char c_step)
        {
            
            try
            {
                TRSNode in_node = new TRSNode("Update_Prompt_In");
                TRSNode out_node = new TRSNode("Cmn_Out");
                int i = 0;

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = c_step;
                in_node.AddString("CHART_ID", lisChart.SelectedItems[0].Text);

                for (i = 0; i < 100; i++ )
                {
                    in_node.AddNode("PRT_LIST");
                }

                for (i = 0; i <= spdPrompt.Sheets[0].RowCount - 1; i++)
                {
                    in_node.GetList(0)[i].AddString("PROMPT", MPCF.Trim(spdPrompt.Sheets[0].Cells[i, 0].Value));
                }
                if (MPCR.CallService("SPC", "SPC_Update_Prompt", in_node, ref out_node) == false)
                {
                    return false;
                }
                MPCR.ShowSuccessMsg(out_node);
                                
                return true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCSetupPrompt.Update_Prompt()\n" + ex.Message);
                return false;
            }
            
        }
        
        public virtual Control GetFisrtFocusItem()
        {
            
            try
            {
                return this.lisChart;
                
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
                if (lisChart.Items.Count > 0)
                {
                    if (MPCF.FindListItem(lisChart, txtChart.Text, false) == false)
                    {
                        View_Chart(txtChart.Text);
                        if (View_Prompt(txtChart.Text) == false)
                        {
                            return;
                        }
                    }
                }
                else
                {
                    View_Chart(txtChart.Text);
                    if (View_Prompt(txtChart.Text) == false)
                    {
                        return;
                    }
                }
                
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCSetupPrompt.ChartInfo()\n" + ex.Message);
            }
            
        }
        
        #endregion
        
        #region " Event Implematations"
        
        private void btnClose_Click(object sender, System.EventArgs e)
        {
            
            try
            {
                this.Dispose();
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCSetupPrompt.btnClose_Click()\n" + ex.Message);
            }
            
        }
        
        private void lisChart_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            
            try
            {
                MPCF.FieldClear(this.pnlRight);
                
                if (lisChart.SelectedItems.Count > 0)
                {
                    txtChart.Text = lisChart.SelectedItems[0].Text;
                    View_Chart(lisChart.SelectedItems[0].Text);
                    if (View_Prompt(lisChart.SelectedItems[0].Text) == false)
                    {
                        return;
                    }
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCSetupPrompt.lisChart_SelectedIndexChanged()\n" + ex.Message);
            }
            
        }
        
        private void btnRefresh_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                lblDataCount.Text = "";
                if (rbnAll.Checked == false && rbnFilter.Checked == false)
                {
                    rbnAll.Checked = true;
                }
                if (rbnFilter.Checked == true && MPCF.Trim(txtFilter.Text) == "")
                {
                    lisChart.Items.Clear();
                    lblDataCount.Text = lisChart.Items.Count.ToString();
                    return;
                }
                if (SPCLIST.ViewChartList(lisChart, '1', "", 0, "", "", "", ' ', ' ', (rbnAll.Checked == true ? "" : (MPCF.Trim(txtFilter.Text))), "", -1, -1, null, "") == true)
                {
                    lblDataCount.Text = lisChart.Items.Count.ToString();
                    if (lisChart.Items.Count > 0)
                    {
                        lisChart.Items[0].Selected = true;
                    }
                }
                
                if (lisChart.Items.Count > 0)
                {
                    MPCF.FindListItem(lisChart, txtChart.Text, false);
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCSetupPrompt.btnRefresh_Click()\n" + ex.Message);
            }
            
        }
        
        private void btnExcel_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                MPCF.ExportToExcel(lisChart, this.Text, "");
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCSetupPrompt.btnExcel_Click()\n" + ex.Message);
            }
            
        }
        
        private void btnNext_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                MPCF.FindListItemNextPartial(lisChart, txtFind.Text, true, false);
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCSetupPrompt.btnNext_Click()\n" + ex.Message);
            }
            
        }
        
        private void txtFind_TextChanged(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                MPCF.FindListItemPartial(lisChart, txtFind.Text, 0, true, false);
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCSetupPrompt.txtFind_TextChanged()\n" + ex.Message);
            }
            
        }
        
        private void frmSPCSetupPrompt_Load(object sender, System.EventArgs e)
        {
            
            try
            {
                MPGV.gIBaseFormEvent.Form_Load(this, e);
                MPCF.SetTextboxStyle(this.Controls);
                
                MPCF.InitListView(lisChart);
                modSPCFunctions.SetGraphList(cboGraphType);
                
                rbnFilter.Checked = true;
                txtFilter.Text = modSPCFunctions.GetFilterKey();
                
                if (MPCF.Trim(MPGV.gsChartID) != "")
                {
                    this.txtChart.Text = MPGV.gsChartID;
                    ChartInfo();
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCSetupPrompt.frmSPCSetupPrompt_Load()\n" + ex.Message);
            }
            
        }
        
        
        private void btnView_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                lblDataCount.Text = "";
                
                modSPCFunctions.SaveFilterKey(MPCF.Trim(txtFilter.Text));
                
                if (rbnFilter.Checked == true && MPCF.Trim(txtFilter.Text) == "")
                {
                    lisChart.Items.Clear();
                    lblDataCount.Text = lisChart.Items.Count.ToString();
                    return;
                }
                if (SPCLIST.ViewChartList(lisChart, '1', "", 0, "", "", "", ' ', ' ', (rbnAll.Checked == true ? "" : (MPCF.Trim(txtFilter.Text))), "", -1, -1, null, "") == true)
                {
                    lblDataCount.Text = lisChart.Items.Count.ToString();
                    if (lisChart.Items.Count > 0)
                    {
                        lisChart.Items[0].Selected = true;
                    }
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCSetupPrompt.btnView_Click()\n" + ex.Message);
            }
            
        }
        
        private void txtFilter_TextChanged(object sender, System.EventArgs e)
        {
            
            try
            {
                rbnFilter.Checked = true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCSetupPrompt.txtFilter_TextChanged()\n" + ex.Message);
            }
            
        }
        
        private void btnDelete_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                if (CheckCondition(MPGC.MP_STEP_DELETE) == false)
                {
                    return;
                }
                if (MPCF.ShowMsgBox(MPCF.GetMessage(54), MessageBoxButtons.YesNo, 1) != System.Windows.Forms.DialogResult.Yes)
                {
                    return;
                }
                if (Update_Prompt(MPGC.MP_STEP_DELETE) == false)
                {
                    return;
                }
                spdPrompt.Sheets[0].ClearRange(0, 0, spdPrompt.Sheets[0].RowCount, 1, true);
                
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCSetupPrompt.btnDelete_Click()\n" + ex.Message);
            }
            
        }
        
        private void btnUpdate_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                if (CheckCondition(MPGC.MP_STEP_UPDATE) == false)
                {
                    return;
                }
                if (Update_Prompt(MPGC.MP_STEP_UPDATE) == false)
                {
                    return;
                }
                
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCSetupPrompt.btnDelete_Click()\n" + ex.Message);
            }
            
        }
        
        private void btnCopy_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                if (MPCF.Trim(txtChart.Text) == "")
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                    txtChart.Focus();
                    return;
                }
                if (MPCF.CheckValue(cdvFromChartID, 1) == false)
                {
                    return;
                }
                View_Prompt(cdvFromChartID.Text);
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCSetupPrompt.btnCopy_Click()\n" + ex.Message);
            }
            
        }
        
        private void cdvFromChartID_ButtonPress(object sender, System.EventArgs e)
        {
            
            try
            {
                cdvFromChartID.Init();
                MPCF.InitListView(cdvFromChartID.GetListView);
                cdvFromChartID.Columns.Add("Chart", 50, HorizontalAlignment.Left);
                cdvFromChartID.Columns.Add("GraphType", 50, HorizontalAlignment.Left);
                cdvFromChartID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvFromChartID.SelectedSubItemIndex = 0;
                SPCLIST.ViewChartList(cdvFromChartID.GetListView, '2', "", 0,"", "", "", ' ', ' ', "", "", -1, -1, null, "");
                cdvFromChartID.AddEmptyRow(1);
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranControlChart.cdvFromChartID_ButtonPress()\n" + ex.Message);
            }
            
        }
        
        private void btnFiltering_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                frmSPCViewChartList form = new frmSPCViewChartList();
                form.StartPosition = FormStartPosition.CenterParent;
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    if (form.lisChart.SelectedItems.Count > 0)
                    {
                        txtChart.Text = form.lisChart.SelectedItems[0].SubItems[1].Text;
                        ChartInfo();
                    }
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCSetupPrompt.btnFiltering_Click()\n" + ex.Message);
            }
            
        }
        
        #endregion
        
    }
    
    
    //#End If
    
}
