
//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmWipViewLotHistory.vb
//   Description : MES Cient Form View Lot History Class
//
//   MES Version : 4.1.0.0
//
//   Function List
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2004-06-16 : Created by CM Koo
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------

using System.Diagnostics;
using System;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;
using System.Text;

using Miracom.MsgHandler;
using System.Data;
using Miracom.MESCore;
using Miracom.CliFrx;
using Miracom.TRSCore;

namespace Miracom.WIPCore
{
    public class frmWIPViewLotHistory : Miracom.MESCore.ViewForm01
    {
        
        #region " Windows Form auto generated code "
        
        public frmWIPViewLotHistory()
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

        private System.ComponentModel.IContainer components;

        
        



        private System.Windows.Forms.CheckBox chkIncludeDelHistory;
        private System.Windows.Forms.TextBox txtLotID;
        private System.Windows.Forms.Label lblLotID;
        private System.Windows.Forms.Panel pnlPeriod;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label lblPeriod;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.TabControl tabHistory;
        private System.Windows.Forms.TabPage tbpView2;
        private System.Windows.Forms.TabPage tbpView1;
        private System.Windows.Forms.Button btnExpand;
        private System.Windows.Forms.Button btnCollapse;
        private System.Windows.Forms.ImageList imlFromToIcon;
        private System.Windows.Forms.ImageList imlSPIcons;
        private FarPoint.Win.Spread.FpSpread spdHistoryBrief;
        private FarPoint.Win.Spread.SheetView spdHistoryBrief_Sheet1;
        private FarPoint.Win.Spread.FpSpread spdHistory;
        private FarPoint.Win.Spread.SheetView spdHistory_Sheet1;
        private TabPage tbpExtension;
        private FarPoint.Win.Spread.FpSpread spdExtension;
        private FarPoint.Win.Spread.SheetView spdExtension_Sheet1;
        private CheckBox chkExtension;
        private Splitter splitter1;
        private Panel pnlViewRight;
        private UI.Controls.MCListView.MCListView lisInquiryHistory;
        private ColumnHeader colPrevLotID;
        private Panel pnlTempLabel;
        private Label lblTemp;
        private System.Windows.Forms.ContextMenu ctxMenu;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            FarPoint.Win.Spread.CellType.ColumnHeaderRenderer columnHeaderRenderer1 = new FarPoint.Win.Spread.CellType.ColumnHeaderRenderer();
            FarPoint.Win.Spread.CellType.RowHeaderRenderer rowHeaderRenderer1 = new FarPoint.Win.Spread.CellType.RowHeaderRenderer();
            FarPoint.Win.Spread.CellType.ColumnHeaderRenderer columnHeaderRenderer2 = new FarPoint.Win.Spread.CellType.ColumnHeaderRenderer();
            FarPoint.Win.Spread.CellType.RowHeaderRenderer rowHeaderRenderer2 = new FarPoint.Win.Spread.CellType.RowHeaderRenderer();
            FarPoint.Win.Spread.CellType.ColumnHeaderRenderer columnHeaderRenderer3 = new FarPoint.Win.Spread.CellType.ColumnHeaderRenderer();
            FarPoint.Win.Spread.CellType.RowHeaderRenderer rowHeaderRenderer3 = new FarPoint.Win.Spread.CellType.RowHeaderRenderer();
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.ComplexBorder complexBorder1 = new FarPoint.Win.ComplexBorder(new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.None, System.Drawing.Color.Silver), new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.None, System.Drawing.Color.Silver), new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.None), new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.None, System.Drawing.Color.Silver));
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer3 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle1 = new FarPoint.Win.Spread.NamedStyle("HeaderDefault");
            FarPoint.Win.Spread.NamedStyle namedStyle2 = new FarPoint.Win.Spread.NamedStyle("RowHeaderDefault");
            FarPoint.Win.Spread.NamedStyle namedStyle3 = new FarPoint.Win.Spread.NamedStyle("CornerDefault");
            FarPoint.Win.Spread.CellType.CornerRenderer cornerRenderer1 = new FarPoint.Win.Spread.CellType.CornerRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle4 = new FarPoint.Win.Spread.NamedStyle("DataAreaDefault");
            FarPoint.Win.Spread.CellType.GeneralCellType generalCellType1 = new FarPoint.Win.Spread.CellType.GeneralCellType();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer4 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.BevelBorder bevelBorder1 = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Raised);
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer5 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer6 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWIPViewLotHistory));
            this.chkIncludeDelHistory = new System.Windows.Forms.CheckBox();
            this.txtLotID = new System.Windows.Forms.TextBox();
            this.lblLotID = new System.Windows.Forms.Label();
            this.pnlPeriod = new System.Windows.Forms.Panel();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.lblPeriod = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.tabHistory = new System.Windows.Forms.TabControl();
            this.tbpView1 = new System.Windows.Forms.TabPage();
            this.spdHistoryBrief = new FarPoint.Win.Spread.FpSpread();
            this.spdHistoryBrief_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.tbpView2 = new System.Windows.Forms.TabPage();
            this.spdHistory = new FarPoint.Win.Spread.FpSpread();
            this.spdHistory_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.tbpExtension = new System.Windows.Forms.TabPage();
            this.spdExtension = new FarPoint.Win.Spread.FpSpread();
            this.spdExtension_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.btnExpand = new System.Windows.Forms.Button();
            this.btnCollapse = new System.Windows.Forms.Button();
            this.imlFromToIcon = new System.Windows.Forms.ImageList(this.components);
            this.imlSPIcons = new System.Windows.Forms.ImageList(this.components);
            this.ctxMenu = new System.Windows.Forms.ContextMenu();
            this.chkExtension = new System.Windows.Forms.CheckBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.pnlViewRight = new System.Windows.Forms.Panel();
            this.lisInquiryHistory = new Miracom.UI.Controls.MCListView.MCListView();
            this.colPrevLotID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlTempLabel = new System.Windows.Forms.Panel();
            this.lblTemp = new System.Windows.Forms.Label();
            this.pnlViewTop.SuspendLayout();
            this.grpOption.SuspendLayout();
            this.pnlViewMid.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlPeriod.SuspendLayout();
            this.tabHistory.SuspendLayout();
            this.tbpView1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdHistoryBrief)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdHistoryBrief_Sheet1)).BeginInit();
            this.tbpView2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdHistory_Sheet1)).BeginInit();
            this.tbpExtension.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdExtension)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdExtension_Sheet1)).BeginInit();
            this.pnlViewRight.SuspendLayout();
            this.pnlTempLabel.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnView
            // 
            this.btnView.TabIndex = 0;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.TabIndex = 2;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // pnlViewTop
            // 
            this.pnlViewTop.Size = new System.Drawing.Size(742, 68);
            // 
            // grpOption
            // 
            this.grpOption.Controls.Add(this.chkExtension);
            this.grpOption.Controls.Add(this.pnlPeriod);
            this.grpOption.Controls.Add(this.txtLotID);
            this.grpOption.Controls.Add(this.lblLotID);
            this.grpOption.Controls.Add(this.chkIncludeDelHistory);
            this.grpOption.Size = new System.Drawing.Size(742, 68);
            // 
            // pnlViewMid
            // 
            this.pnlViewMid.Controls.Add(this.tabHistory);
            this.pnlViewMid.Controls.Add(this.splitter1);
            this.pnlViewMid.Controls.Add(this.pnlViewRight);
            this.pnlViewMid.Location = new System.Drawing.Point(0, 68);
            this.pnlViewMid.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.pnlViewMid.Size = new System.Drawing.Size(742, 445);
            this.pnlViewMid.TabIndex = 2;
            // 
            // btnClose
            // 
            this.btnClose.TabIndex = 1;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnExpand);
            this.pnlBottom.Controls.Add(this.btnCollapse);
            this.pnlBottom.Controls.SetChildIndex(this.btnClose, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnView, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnExcel, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnCollapse, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnExpand, 0);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "View Lot History";
            columnHeaderRenderer1.BackColor = System.Drawing.SystemColors.Control;
            columnHeaderRenderer1.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            columnHeaderRenderer1.ForeColor = System.Drawing.SystemColors.ControlText;
            columnHeaderRenderer1.Name = "columnHeaderRenderer1";
            columnHeaderRenderer1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            columnHeaderRenderer1.TextRotationAngle = 0D;
            rowHeaderRenderer1.BackColor = System.Drawing.SystemColors.Control;
            rowHeaderRenderer1.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            rowHeaderRenderer1.ForeColor = System.Drawing.SystemColors.ControlText;
            rowHeaderRenderer1.Name = "rowHeaderRenderer1";
            rowHeaderRenderer1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            rowHeaderRenderer1.TextRotationAngle = 0D;
            columnHeaderRenderer2.BackColor = System.Drawing.SystemColors.Control;
            columnHeaderRenderer2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            columnHeaderRenderer2.ForeColor = System.Drawing.SystemColors.ControlText;
            columnHeaderRenderer2.Name = "columnHeaderRenderer2";
            columnHeaderRenderer2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            columnHeaderRenderer2.TextRotationAngle = 0D;
            rowHeaderRenderer2.BackColor = System.Drawing.SystemColors.Control;
            rowHeaderRenderer2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            rowHeaderRenderer2.ForeColor = System.Drawing.SystemColors.ControlText;
            rowHeaderRenderer2.Name = "rowHeaderRenderer2";
            rowHeaderRenderer2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            rowHeaderRenderer2.TextRotationAngle = 0D;
            columnHeaderRenderer3.BackColor = System.Drawing.SystemColors.Control;
            columnHeaderRenderer3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            columnHeaderRenderer3.ForeColor = System.Drawing.SystemColors.ControlText;
            columnHeaderRenderer3.Name = "columnHeaderRenderer3";
            columnHeaderRenderer3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            columnHeaderRenderer3.TextRotationAngle = 0D;
            rowHeaderRenderer3.BackColor = System.Drawing.SystemColors.Control;
            rowHeaderRenderer3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            rowHeaderRenderer3.ForeColor = System.Drawing.SystemColors.ControlText;
            rowHeaderRenderer3.Name = "rowHeaderRenderer3";
            rowHeaderRenderer3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            rowHeaderRenderer3.TextRotationAngle = 0D;
            // 
            // chkIncludeDelHistory
            // 
            this.chkIncludeDelHistory.AutoSize = true;
            this.chkIncludeDelHistory.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkIncludeDelHistory.Location = new System.Drawing.Point(121, 43);
            this.chkIncludeDelHistory.Name = "chkIncludeDelHistory";
            this.chkIncludeDelHistory.Size = new System.Drawing.Size(136, 18);
            this.chkIncludeDelHistory.TabIndex = 2;
            this.chkIncludeDelHistory.Text = "Include Delete History";
            // 
            // txtLotID
            // 
            this.txtLotID.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtLotID.Location = new System.Drawing.Point(120, 16);
            this.txtLotID.MaxLength = 25;
            this.txtLotID.Name = "txtLotID";
            this.txtLotID.Size = new System.Drawing.Size(200, 20);
            this.txtLotID.TabIndex = 1;
            // 
            // lblLotID
            // 
            this.lblLotID.AutoSize = true;
            this.lblLotID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLotID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLotID.Location = new System.Drawing.Point(15, 19);
            this.lblLotID.Name = "lblLotID";
            this.lblLotID.Size = new System.Drawing.Size(42, 13);
            this.lblLotID.TabIndex = 0;
            this.lblLotID.Text = "Lot ID";
            // 
            // pnlPeriod
            // 
            this.pnlPeriod.Controls.Add(this.dtpFrom);
            this.pnlPeriod.Controls.Add(this.lblPeriod);
            this.pnlPeriod.Controls.Add(this.dtpTo);
            this.pnlPeriod.Controls.Add(this.lblTo);
            this.pnlPeriod.Location = new System.Drawing.Point(475, 16);
            this.pnlPeriod.Name = "pnlPeriod";
            this.pnlPeriod.Size = new System.Drawing.Size(257, 20);
            this.pnlPeriod.TabIndex = 3;
            // 
            // dtpFrom
            // 
            this.dtpFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(56, 0);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(90, 20);
            this.dtpFrom.TabIndex = 1;
            // 
            // lblPeriod
            // 
            this.lblPeriod.AutoSize = true;
            this.lblPeriod.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblPeriod.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPeriod.Location = new System.Drawing.Point(0, 3);
            this.lblPeriod.Name = "lblPeriod";
            this.lblPeriod.Size = new System.Drawing.Size(43, 13);
            this.lblPeriod.TabIndex = 0;
            this.lblPeriod.Text = "Period";
            this.lblPeriod.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpTo
            // 
            this.dtpTo.Dock = System.Windows.Forms.DockStyle.Right;
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(167, 0);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(90, 20);
            this.dtpTo.TabIndex = 3;
            // 
            // lblTo
            // 
            this.lblTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTo.Location = new System.Drawing.Point(149, 6);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(12, 9);
            this.lblTo.TabIndex = 2;
            this.lblTo.Text = "~";
            // 
            // tabHistory
            // 
            this.tabHistory.Controls.Add(this.tbpView1);
            this.tabHistory.Controls.Add(this.tbpView2);
            this.tabHistory.Controls.Add(this.tbpExtension);
            this.tabHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabHistory.Location = new System.Drawing.Point(0, 3);
            this.tabHistory.Name = "tabHistory";
            this.tabHistory.SelectedIndex = 0;
            this.tabHistory.Size = new System.Drawing.Size(601, 442);
            this.tabHistory.TabIndex = 0;
            // 
            // tbpView1
            // 
            this.tbpView1.Controls.Add(this.spdHistoryBrief);
            this.tbpView1.Location = new System.Drawing.Point(4, 22);
            this.tbpView1.Name = "tbpView1";
            this.tbpView1.Size = new System.Drawing.Size(593, 416);
            this.tbpView1.TabIndex = 1;
            this.tbpView1.Text = "View 1";
            // 
            // spdHistoryBrief
            // 
            this.spdHistoryBrief.AccessibleDescription = "spdHistoryBrief, Sheet1, Row 0, Column 0, ";
            this.spdHistoryBrief.BackColor = System.Drawing.SystemColors.Control;
            this.spdHistoryBrief.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdHistoryBrief.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdHistoryBrief.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdHistoryBrief.HorizontalScrollBar.Name = "";
            this.spdHistoryBrief.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdHistoryBrief.HorizontalScrollBar.TabIndex = 0;
            this.spdHistoryBrief.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdHistoryBrief.Location = new System.Drawing.Point(0, 0);
            this.spdHistoryBrief.Name = "spdHistoryBrief";
            this.spdHistoryBrief.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdHistoryBrief.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdHistoryBrief.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdHistoryBrief_Sheet1});
            this.spdHistoryBrief.Size = new System.Drawing.Size(593, 416);
            this.spdHistoryBrief.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdHistoryBrief.TabIndex = 0;
            this.spdHistoryBrief.TabStop = false;
            this.spdHistoryBrief.TextTipDelay = 200;
            this.spdHistoryBrief.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdHistoryBrief.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdHistoryBrief.VerticalScrollBar.Name = "";
            this.spdHistoryBrief.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdHistoryBrief.VerticalScrollBar.TabIndex = 3;
            this.spdHistoryBrief.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdHistoryBrief.CellClick += new FarPoint.Win.Spread.CellClickEventHandler(this.spdHistoryBrief_CellClick);
            this.spdHistoryBrief.MouseDown += new System.Windows.Forms.MouseEventHandler(this.spdHistoryBrief_MouseDown);
            this.spdHistoryBrief.MouseUp += new System.Windows.Forms.MouseEventHandler(this.spdHistoryBrief_MouseUp);
            this.spdHistoryBrief.SetViewportLeftColumn(0, 0, 3);
            this.spdHistoryBrief.SetActiveViewport(0, 0, -1);
            // 
            // spdHistoryBrief_Sheet1
            // 
            this.spdHistoryBrief_Sheet1.Reset();
            spdHistoryBrief_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdHistoryBrief_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdHistoryBrief_Sheet1.ColumnCount = 12;
            spdHistoryBrief_Sheet1.RowCount = 5;
            spdHistoryBrief_Sheet1.RowHeader.ColumnCount = 0;
            this.spdHistoryBrief_Sheet1.AlternatingRows.Get(1).BackColor = System.Drawing.Color.White;
            this.spdHistoryBrief_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdHistoryBrief_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdHistoryBrief_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdHistoryBrief_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdHistoryBrief_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "_";
            this.spdHistoryBrief_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Seq";
            this.spdHistoryBrief_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Tran Time";
            this.spdHistoryBrief_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Code";
            this.spdHistoryBrief_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Mat ID";
            this.spdHistoryBrief_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Mat Ver";
            this.spdHistoryBrief_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Flow";
            this.spdHistoryBrief_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "Flow Seq";
            this.spdHistoryBrief_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "Oper";
            this.spdHistoryBrief_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "Qty 1";
            this.spdHistoryBrief_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "Qty 2";
            this.spdHistoryBrief_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "Qty 3";
            this.spdHistoryBrief_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdHistoryBrief_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdHistoryBrief_Sheet1.ColumnHeader.Rows.Get(0).Height = 18F;
            this.spdHistoryBrief_Sheet1.Columns.Get(0).BackColor = System.Drawing.Color.Gainsboro;
            this.spdHistoryBrief_Sheet1.Columns.Get(0).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdHistoryBrief_Sheet1.Columns.Get(0).ForeColor = System.Drawing.Color.Black;
            this.spdHistoryBrief_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistoryBrief_Sheet1.Columns.Get(0).Label = "_";
            this.spdHistoryBrief_Sheet1.Columns.Get(0).Locked = true;
            this.spdHistoryBrief_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistoryBrief_Sheet1.Columns.Get(0).Width = 23F;
            this.spdHistoryBrief_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistoryBrief_Sheet1.Columns.Get(1).Label = "Seq";
            this.spdHistoryBrief_Sheet1.Columns.Get(1).Locked = true;
            this.spdHistoryBrief_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistoryBrief_Sheet1.Columns.Get(1).Width = 42F;
            this.spdHistoryBrief_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistoryBrief_Sheet1.Columns.Get(2).Label = "Tran Time";
            this.spdHistoryBrief_Sheet1.Columns.Get(2).Locked = true;
            this.spdHistoryBrief_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistoryBrief_Sheet1.Columns.Get(2).Width = 135F;
            this.spdHistoryBrief_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistoryBrief_Sheet1.Columns.Get(3).Label = "Code";
            this.spdHistoryBrief_Sheet1.Columns.Get(3).Locked = true;
            this.spdHistoryBrief_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistoryBrief_Sheet1.Columns.Get(3).Width = 90F;
            this.spdHistoryBrief_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistoryBrief_Sheet1.Columns.Get(4).Label = "Mat ID";
            this.spdHistoryBrief_Sheet1.Columns.Get(4).Locked = true;
            this.spdHistoryBrief_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistoryBrief_Sheet1.Columns.Get(4).Width = 110F;
            this.spdHistoryBrief_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistoryBrief_Sheet1.Columns.Get(5).Label = "Mat Ver";
            this.spdHistoryBrief_Sheet1.Columns.Get(5).Locked = true;
            this.spdHistoryBrief_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistoryBrief_Sheet1.Columns.Get(6).Label = "Flow";
            this.spdHistoryBrief_Sheet1.Columns.Get(6).Locked = true;
            this.spdHistoryBrief_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistoryBrief_Sheet1.Columns.Get(6).Width = 82F;
            this.spdHistoryBrief_Sheet1.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistoryBrief_Sheet1.Columns.Get(7).Label = "Flow Seq";
            this.spdHistoryBrief_Sheet1.Columns.Get(7).Locked = true;
            this.spdHistoryBrief_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistoryBrief_Sheet1.Columns.Get(8).Label = "Oper";
            this.spdHistoryBrief_Sheet1.Columns.Get(8).Locked = true;
            this.spdHistoryBrief_Sheet1.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistoryBrief_Sheet1.Columns.Get(9).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdHistoryBrief_Sheet1.Columns.Get(9).Label = "Qty 1";
            this.spdHistoryBrief_Sheet1.Columns.Get(9).Locked = true;
            this.spdHistoryBrief_Sheet1.Columns.Get(9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistoryBrief_Sheet1.Columns.Get(9).Width = 62F;
            this.spdHistoryBrief_Sheet1.Columns.Get(10).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdHistoryBrief_Sheet1.Columns.Get(10).Label = "Qty 2";
            this.spdHistoryBrief_Sheet1.Columns.Get(10).Locked = true;
            this.spdHistoryBrief_Sheet1.Columns.Get(10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistoryBrief_Sheet1.Columns.Get(10).Width = 62F;
            this.spdHistoryBrief_Sheet1.Columns.Get(11).Border = complexBorder1;
            this.spdHistoryBrief_Sheet1.Columns.Get(11).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdHistoryBrief_Sheet1.Columns.Get(11).Label = "Qty 3";
            this.spdHistoryBrief_Sheet1.Columns.Get(11).Locked = true;
            this.spdHistoryBrief_Sheet1.Columns.Get(11).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistoryBrief_Sheet1.Columns.Get(11).Width = 62F;
            this.spdHistoryBrief_Sheet1.FrozenColumnCount = 3;
            this.spdHistoryBrief_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdHistoryBrief_Sheet1.HorizontalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.None);
            this.spdHistoryBrief_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdHistoryBrief_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdHistoryBrief_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdHistoryBrief_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdHistoryBrief_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdHistoryBrief_Sheet1.VerticalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.None);
            this.spdHistoryBrief_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // tbpView2
            // 
            this.tbpView2.Controls.Add(this.spdHistory);
            this.tbpView2.Location = new System.Drawing.Point(4, 22);
            this.tbpView2.Name = "tbpView2";
            this.tbpView2.Size = new System.Drawing.Size(593, 416);
            this.tbpView2.TabIndex = 0;
            this.tbpView2.Text = "View 2";
            // 
            // spdHistory
            // 
            this.spdHistory.AccessibleDescription = "spdHistory, Sheet1, Row 0, Column 0, ";
            this.spdHistory.BackColor = System.Drawing.SystemColors.Control;
            this.spdHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdHistory.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdHistory.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdHistory.HorizontalScrollBar.Name = "";
            this.spdHistory.HorizontalScrollBar.Renderer = defaultScrollBarRenderer3;
            this.spdHistory.HorizontalScrollBar.TabIndex = 8;
            this.spdHistory.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdHistory.Location = new System.Drawing.Point(0, 0);
            this.spdHistory.Name = "spdHistory";
            namedStyle1.BackColor = System.Drawing.SystemColors.Control;
            namedStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            namedStyle1.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            namedStyle1.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle1.Renderer = columnHeaderRenderer3;
            namedStyle1.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            namedStyle2.BackColor = System.Drawing.SystemColors.Control;
            namedStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            namedStyle2.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            namedStyle2.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle2.Renderer = rowHeaderRenderer3;
            namedStyle2.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            namedStyle3.BackColor = System.Drawing.SystemColors.Control;
            namedStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            namedStyle3.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            namedStyle3.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle3.Renderer = cornerRenderer1;
            namedStyle3.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            namedStyle4.BackColor = System.Drawing.SystemColors.Window;
            namedStyle4.CellType = generalCellType1;
            namedStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            namedStyle4.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle4.Renderer = generalCellType1;
            this.spdHistory.NamedStyles.AddRange(new FarPoint.Win.Spread.NamedStyle[] {
            namedStyle1,
            namedStyle2,
            namedStyle3,
            namedStyle4});
            this.spdHistory.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.spdHistory.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdHistory.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdHistory.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdHistory_Sheet1});
            this.spdHistory.Size = new System.Drawing.Size(593, 416);
            this.spdHistory.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdHistory.TabIndex = 3;
            this.spdHistory.TabStop = false;
            this.spdHistory.TextTipDelay = 200;
            this.spdHistory.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdHistory.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdHistory.VerticalScrollBar.Name = "";
            this.spdHistory.VerticalScrollBar.Renderer = defaultScrollBarRenderer4;
            this.spdHistory.VerticalScrollBar.TabIndex = 9;
            this.spdHistory.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdHistory.MouseDown += new System.Windows.Forms.MouseEventHandler(this.spdHistory_MouseDown);
            this.spdHistory.MouseUp += new System.Windows.Forms.MouseEventHandler(this.spdHistory_MouseUp);
            this.spdHistory.SetViewportLeftColumn(0, 0, 3);
            this.spdHistory.SetActiveViewport(0, 0, -1);
            // 
            // spdHistory_Sheet1
            // 
            this.spdHistory_Sheet1.Reset();
            spdHistory_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdHistory_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdHistory_Sheet1.ColumnCount = 189;
            spdHistory_Sheet1.RowCount = 5;
            spdHistory_Sheet1.RowHeader.ColumnCount = 0;
            this.spdHistory_Sheet1.AlternatingRows.Get(1).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdHistory_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdHistory_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdHistory_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdHistory_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Seq";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Tran Code";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Tran Time";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Factory";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Mat ID";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Mat Ver";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Flow";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "Flow Seq";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "Oper";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "Qty 1";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "Qty 2";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "Qty 3";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 12).Value = "Carrier";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 13).Value = "Lot Type";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 14).Value = "Owner Code";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 15).Value = "Create Code";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 16).Value = "Create Time";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 17).Value = "Lot Priority";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 18).Value = "Lot Status";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 19).Value = "Lot Delete Time";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 20).Value = "Hold Flag";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 21).Value = "Hold Code";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 22).Value = "Hold Prv Group";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 23).Value = "Oper In Qty 1";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 24).Value = "Oper In Qty 2";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 25).Value = "Oper In Qty 3";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 26).Value = "Create Qty 1";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 27).Value = "Create Qty 2";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 28).Value = "Create Qty 3";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 29).Value = "Start Qty 1";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 30).Value = "Start Qty 2";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 31).Value = "Start Qty 3";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 32).Value = "Inventory Flag";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 33).Value = "Transit Flag";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 34).Value = "Unit Exist Flag";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 35).Value = "Inventory Unit";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 36).Value = "Rework Flag";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 37).Value = "Rework Code";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 38).Value = "Rework Count";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 39).Value = "Rework Return Flow";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 40).Value = "Rework Return Flow Seq";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 41).Value = "Rework Return Oper";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 42).Value = "Rework End Flow";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 43).Value = "Rework End Flow Seq";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 44).Value = "Rework End Oper";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 45).Value = "Rework Return Clear Flag";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 46).Value = "Rework Time";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 47).Value = "NSTD Flag";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 48).Value = "NSTD Return Flow";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 49).Value = "NSTD Return Flow Seq";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 50).Value = "NSTD Return Oper";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 51).Value = "NSTD Time";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 52).Value = "Repair Flag";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 53).Value = "Repair Return Oper";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 54).Value = "Store Return Flow";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 55).Value = "Store Return Flow Seq";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 56).Value = "Store Return Oper";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 57).Value = "Start Flag";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 58).Value = "Start Time";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 59).Value = "Start Resource";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 60).Value = "End Flag";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 61).Value = "End Time";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 62).Value = "End Resource";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 63).Value = "Sample Flag";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 64).Value = "Sample Wait Flag";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 65).Value = "Sample Result";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 66).Value = "From To Flag";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 67).Value = "From To Lot ID";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 68).Value = "From To Mat ID";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 69).Value = "From To Mat Version";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 70).Value = "From To Flow";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 71).Value = "From To Flow Seq";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 72).Value = "From To Oper";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 73).Value = "From To Qty 1";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 74).Value = "From To Qty 2";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 75).Value = "From To Qty 3";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 76).Value = "From To Hist Seq";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 77).Value = "Ship Code";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 78).Value = "Ship Time";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 79).Value = "Original Due Time";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 80).Value = "Scheduled Due Time";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 81).Value = "Factory In Time";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 82).Value = "Flow In Time";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 83).Value = "Oper In Time";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 84).Value = "Reserve Resource";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 85).Value = "Port ID";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 86).Value = "Batch ID";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 87).Value = "Batch Seq";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 88).Value = "Order ID";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 89).Value = "Add Order ID 1";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 90).Value = "Add Order ID 2";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 91).Value = "Add Order ID 3";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 92).Value = "Lot Location 1";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 93).Value = "Lot Location 2";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 94).Value = "Lot Location 3";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 95).Value = "Lot Cmf 1";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 96).Value = "Lot Cmf 2";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 97).Value = "Lot Cmf 3";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 98).Value = "Lot Cmf 4";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 99).Value = "Lot Cmf 5";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 100).Value = "Lot Cmf 6";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 101).Value = "Lot Cmf 7";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 102).Value = "Lot Cmf 8";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 103).Value = "Lot Cmf 9";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 104).Value = "Lot Cmf 10";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 105).Value = "Lot Cmf 11";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 106).Value = "Lot Cmf 12";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 107).Value = "Lot Cmf 13";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 108).Value = "Lot Cmf 14";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 109).Value = "Lot Cmf 15";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 110).Value = "Lot Cmf 16";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 111).Value = "Lot Cmf 17";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 112).Value = "Lot Cmf 18";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 113).Value = "Lot Cmf 19";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 114).Value = "Lot Cmf 20";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 115).Value = "Lot Delete Flag";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 116).Value = "Lot Delete Code";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 117).Value = "Bom Set ID";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 118).Value = "Bom Set Version";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 119).Value = "Bom Active Hist Seq";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 120).Value = "Bom Hist Seq";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 121).Value = "Critical Resource";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 122).Value = "Critical Resource Group";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 123).Value = "Save Resource 1";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 124).Value = "Save Resource 2";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 125).Value = "Sub Resource";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 126).Value = "Lot Group ID 1";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 127).Value = "Lot Group ID 2";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 128).Value = "Lot Group ID 3";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 129).Value = "Yield 1";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 130).Value = "Yield 2";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 131).Value = "Yield 3";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 132).Value = "Good Qty";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 133).Value = "Resv Field 1";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 134).Value = "Resv Field 2";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 135).Value = "Resv Field 3";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 136).Value = "Resv Field 4";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 137).Value = "Resv Field 5";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 138).Value = "Resv Flag 1";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 139).Value = "Resv Flag 2";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 140).Value = "Resv Flag 3";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 141).Value = "Resv Flag 4";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 142).Value = "Resv Flag 5";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 143).Value = "Old Factory";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 144).Value = "Old Mat ID";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 145).Value = "Old Mat Version";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 146).Value = "Old Flow";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 147).Value = "Old Flow Seq";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 148).Value = "Old Oper";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 149).Value = "Old Qty 1";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 150).Value = "Old Qty 2";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 151).Value = "Old Qty 3";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 152).Value = "Old Hist Seq";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 153).Value = "Old Lot Type";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 154).Value = "Old Owner Code";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 155).Value = "Old Create Code";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 156).Value = "Old Factory In Time";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 157).Value = "Old Flow In Time";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 158).Value = "Old Oper In Time";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 159).Value = "Trans Cmf 1";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 160).Value = "Trans Cmf 2";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 161).Value = "Trans Cmf 3";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 162).Value = "Trans Cmf 4";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 163).Value = "Trans Cmf 5";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 164).Value = "Trans Cmf 6";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 165).Value = "Trans Cmf 7";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 166).Value = "Trans Cmf 8";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 167).Value = "Trans Cmf 9";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 168).Value = "Trans Cmf 10";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 169).Value = "Tran Cmf 11";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 170).Value = "Tran Cmf 12";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 171).Value = "Tran Cmf 13";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 172).Value = "Tran Cmf 14";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 173).Value = "Tran Cmf 15";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 174).Value = "Tran Cmf 16";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 175).Value = "Tran Cmf 17";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 176).Value = "Tran Cmf 18";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 177).Value = "Tran Cmf 19";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 178).Value = "Tran Cmf 20";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 179).Value = "Tran User ID";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 180).Value = "Tran Comment";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 181).Value = "Prev Active Hist Seq";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 182).Value = "Multi Tr Key";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 183).Value = "Multi Tr Seq";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 184).Value = "Hist Delete Flag";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 185).Value = "Hist Delete Time";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 186).Value = "Hist Delete User ID";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 187).Value = "Hist Delete Comment";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 188).Value = "Sys Tran Time";
            this.spdHistory_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdHistory_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdHistory_Sheet1.Columns.Get(0).BackColor = System.Drawing.SystemColors.Control;
            this.spdHistory_Sheet1.Columns.Get(0).Border = bevelBorder1;
            this.spdHistory_Sheet1.Columns.Get(0).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdHistory_Sheet1.Columns.Get(0).ForeColor = System.Drawing.Color.Black;
            this.spdHistory_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(0).Label = "Seq";
            this.spdHistory_Sheet1.Columns.Get(0).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(0).Width = 44F;
            this.spdHistory_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(1).Label = "Tran Code";
            this.spdHistory_Sheet1.Columns.Get(1).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(1).Width = 81F;
            this.spdHistory_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(2).Label = "Tran Time";
            this.spdHistory_Sheet1.Columns.Get(2).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(2).Width = 125F;
            this.spdHistory_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(3).Label = "Factory";
            this.spdHistory_Sheet1.Columns.Get(3).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(4).Label = "Mat ID";
            this.spdHistory_Sheet1.Columns.Get(4).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(4).Width = 122F;
            this.spdHistory_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(5).Label = "Mat Ver";
            this.spdHistory_Sheet1.Columns.Get(5).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(6).Label = "Flow";
            this.spdHistory_Sheet1.Columns.Get(6).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(6).Width = 92F;
            this.spdHistory_Sheet1.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(7).Label = "Flow Seq";
            this.spdHistory_Sheet1.Columns.Get(7).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(8).Label = "Oper";
            this.spdHistory_Sheet1.Columns.Get(8).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(9).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdHistory_Sheet1.Columns.Get(9).Label = "Qty 1";
            this.spdHistory_Sheet1.Columns.Get(9).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(10).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdHistory_Sheet1.Columns.Get(10).Label = "Qty 2";
            this.spdHistory_Sheet1.Columns.Get(10).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(11).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdHistory_Sheet1.Columns.Get(11).Label = "Qty 3";
            this.spdHistory_Sheet1.Columns.Get(11).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(11).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(12).Label = "Carrier";
            this.spdHistory_Sheet1.Columns.Get(12).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(12).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(13).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(13).Label = "Lot Type";
            this.spdHistory_Sheet1.Columns.Get(13).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(13).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(14).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(14).Label = "Owner Code";
            this.spdHistory_Sheet1.Columns.Get(14).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(14).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(14).Width = 82F;
            this.spdHistory_Sheet1.Columns.Get(15).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(15).Label = "Create Code";
            this.spdHistory_Sheet1.Columns.Get(15).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(15).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(15).Width = 86F;
            this.spdHistory_Sheet1.Columns.Get(16).Label = "Create Time";
            this.spdHistory_Sheet1.Columns.Get(16).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(16).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(16).Width = 125F;
            this.spdHistory_Sheet1.Columns.Get(17).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(17).Label = "Lot Priority";
            this.spdHistory_Sheet1.Columns.Get(17).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(17).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(17).Width = 79F;
            this.spdHistory_Sheet1.Columns.Get(18).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(18).Label = "Lot Status";
            this.spdHistory_Sheet1.Columns.Get(18).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(18).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(18).Width = 67F;
            this.spdHistory_Sheet1.Columns.Get(19).Label = "Lot Delete Time";
            this.spdHistory_Sheet1.Columns.Get(19).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(19).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(19).Width = 116F;
            this.spdHistory_Sheet1.Columns.Get(20).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(20).Label = "Hold Flag";
            this.spdHistory_Sheet1.Columns.Get(20).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(20).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(20).Width = 62F;
            this.spdHistory_Sheet1.Columns.Get(21).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(21).Label = "Hold Code";
            this.spdHistory_Sheet1.Columns.Get(21).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(21).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(21).Width = 69F;
            this.spdHistory_Sheet1.Columns.Get(22).Label = "Hold Prv Group";
            this.spdHistory_Sheet1.Columns.Get(22).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(22).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(22).Width = 83F;
            this.spdHistory_Sheet1.Columns.Get(23).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdHistory_Sheet1.Columns.Get(23).Label = "Oper In Qty 1";
            this.spdHistory_Sheet1.Columns.Get(23).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(23).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(23).Width = 85F;
            this.spdHistory_Sheet1.Columns.Get(24).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdHistory_Sheet1.Columns.Get(24).Label = "Oper In Qty 2";
            this.spdHistory_Sheet1.Columns.Get(24).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(24).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(24).Width = 86F;
            this.spdHistory_Sheet1.Columns.Get(25).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdHistory_Sheet1.Columns.Get(25).Label = "Oper In Qty 3";
            this.spdHistory_Sheet1.Columns.Get(25).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(25).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(25).Width = 84F;
            this.spdHistory_Sheet1.Columns.Get(26).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdHistory_Sheet1.Columns.Get(26).Label = "Create Qty 1";
            this.spdHistory_Sheet1.Columns.Get(26).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(26).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(26).Width = 80F;
            this.spdHistory_Sheet1.Columns.Get(27).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdHistory_Sheet1.Columns.Get(27).Label = "Create Qty 2";
            this.spdHistory_Sheet1.Columns.Get(27).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(27).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(27).Width = 80F;
            this.spdHistory_Sheet1.Columns.Get(28).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdHistory_Sheet1.Columns.Get(28).Label = "Create Qty 3";
            this.spdHistory_Sheet1.Columns.Get(28).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(28).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(28).Width = 80F;
            this.spdHistory_Sheet1.Columns.Get(29).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdHistory_Sheet1.Columns.Get(29).Label = "Start Qty 1";
            this.spdHistory_Sheet1.Columns.Get(29).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(29).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(29).Width = 80F;
            this.spdHistory_Sheet1.Columns.Get(30).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdHistory_Sheet1.Columns.Get(30).Label = "Start Qty 2";
            this.spdHistory_Sheet1.Columns.Get(30).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(30).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(30).Width = 80F;
            this.spdHistory_Sheet1.Columns.Get(31).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdHistory_Sheet1.Columns.Get(31).Label = "Start Qty 3";
            this.spdHistory_Sheet1.Columns.Get(31).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(31).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(31).Width = 80F;
            this.spdHistory_Sheet1.Columns.Get(32).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(32).Label = "Inventory Flag";
            this.spdHistory_Sheet1.Columns.Get(32).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(32).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(32).Width = 69F;
            this.spdHistory_Sheet1.Columns.Get(33).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(33).Label = "Transit Flag";
            this.spdHistory_Sheet1.Columns.Get(33).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(33).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(33).Width = 84F;
            this.spdHistory_Sheet1.Columns.Get(34).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(34).Label = "Unit Exist Flag";
            this.spdHistory_Sheet1.Columns.Get(34).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(34).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(34).Width = 97F;
            this.spdHistory_Sheet1.Columns.Get(35).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(35).Label = "Inventory Unit";
            this.spdHistory_Sheet1.Columns.Get(35).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(35).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(35).Width = 90F;
            this.spdHistory_Sheet1.Columns.Get(36).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(36).Label = "Rework Flag";
            this.spdHistory_Sheet1.Columns.Get(36).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(36).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(36).Width = 85F;
            this.spdHistory_Sheet1.Columns.Get(37).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(37).Label = "Rework Code";
            this.spdHistory_Sheet1.Columns.Get(37).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(37).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(37).Width = 92F;
            this.spdHistory_Sheet1.Columns.Get(38).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(38).Label = "Rework Count";
            this.spdHistory_Sheet1.Columns.Get(38).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(38).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(38).Width = 93F;
            this.spdHistory_Sheet1.Columns.Get(39).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(39).Label = "Rework Return Flow";
            this.spdHistory_Sheet1.Columns.Get(39).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(39).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(39).Width = 125F;
            this.spdHistory_Sheet1.Columns.Get(40).Label = "Rework Return Flow Seq";
            this.spdHistory_Sheet1.Columns.Get(40).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(40).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(40).Width = 135F;
            this.spdHistory_Sheet1.Columns.Get(41).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(41).Label = "Rework Return Oper";
            this.spdHistory_Sheet1.Columns.Get(41).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(41).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(41).Width = 134F;
            this.spdHistory_Sheet1.Columns.Get(42).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(42).Label = "Rework End Flow";
            this.spdHistory_Sheet1.Columns.Get(42).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(42).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(42).Width = 123F;
            this.spdHistory_Sheet1.Columns.Get(43).Label = "Rework End Flow Seq";
            this.spdHistory_Sheet1.Columns.Get(43).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(43).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(43).Width = 124F;
            this.spdHistory_Sheet1.Columns.Get(44).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(44).Label = "Rework End Oper";
            this.spdHistory_Sheet1.Columns.Get(44).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(44).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(44).Width = 108F;
            this.spdHistory_Sheet1.Columns.Get(45).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(45).Label = "Rework Return Clear Flag";
            this.spdHistory_Sheet1.Columns.Get(45).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(45).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(45).Width = 160F;
            this.spdHistory_Sheet1.Columns.Get(46).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(46).Label = "Rework Time";
            this.spdHistory_Sheet1.Columns.Get(46).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(46).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(46).Width = 120F;
            this.spdHistory_Sheet1.Columns.Get(47).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(47).Label = "NSTD Flag";
            this.spdHistory_Sheet1.Columns.Get(47).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(47).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(47).Width = 68F;
            this.spdHistory_Sheet1.Columns.Get(48).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(48).Label = "NSTD Return Flow";
            this.spdHistory_Sheet1.Columns.Get(48).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(48).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(48).Width = 110F;
            this.spdHistory_Sheet1.Columns.Get(49).Label = "NSTD Return Flow Seq";
            this.spdHistory_Sheet1.Columns.Get(49).Width = 124F;
            this.spdHistory_Sheet1.Columns.Get(50).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(50).Label = "NSTD Return Oper";
            this.spdHistory_Sheet1.Columns.Get(50).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(50).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(50).Width = 111F;
            this.spdHistory_Sheet1.Columns.Get(51).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(51).Label = "NSTD Time";
            this.spdHistory_Sheet1.Columns.Get(51).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(51).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(51).Width = 120F;
            this.spdHistory_Sheet1.Columns.Get(52).Label = "Repair Flag";
            this.spdHistory_Sheet1.Columns.Get(52).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(52).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(52).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(53).Label = "Repair Return Oper";
            this.spdHistory_Sheet1.Columns.Get(53).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(53).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(53).Width = 113F;
            this.spdHistory_Sheet1.Columns.Get(54).Label = "Store Return Flow";
            this.spdHistory_Sheet1.Columns.Get(54).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(54).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(54).Width = 119F;
            this.spdHistory_Sheet1.Columns.Get(55).Label = "Store Return Flow Seq";
            this.spdHistory_Sheet1.Columns.Get(55).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(55).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(55).Width = 119F;
            this.spdHistory_Sheet1.Columns.Get(56).Label = "Store Return Oper";
            this.spdHistory_Sheet1.Columns.Get(56).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(56).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(56).Width = 119F;
            this.spdHistory_Sheet1.Columns.Get(57).Label = "Start Flag";
            this.spdHistory_Sheet1.Columns.Get(57).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(57).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(57).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(58).Label = "Start Time";
            this.spdHistory_Sheet1.Columns.Get(58).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(58).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(58).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(59).Label = "Start Resource";
            this.spdHistory_Sheet1.Columns.Get(59).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(59).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(59).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(60).Label = "End Flag";
            this.spdHistory_Sheet1.Columns.Get(60).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(60).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(60).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(61).Label = "End Time";
            this.spdHistory_Sheet1.Columns.Get(61).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(61).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(61).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(62).Label = "End Resource";
            this.spdHistory_Sheet1.Columns.Get(62).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(62).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(62).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(63).Label = "Sample Flag";
            this.spdHistory_Sheet1.Columns.Get(63).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(63).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(63).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(64).Label = "Sample Wait Flag";
            this.spdHistory_Sheet1.Columns.Get(64).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(64).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(64).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(65).Label = "Sample Result";
            this.spdHistory_Sheet1.Columns.Get(65).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(65).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(65).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(66).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(66).Label = "From To Flag";
            this.spdHistory_Sheet1.Columns.Get(66).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(66).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(66).Width = 88F;
            this.spdHistory_Sheet1.Columns.Get(67).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(67).Label = "From To Lot ID";
            this.spdHistory_Sheet1.Columns.Get(67).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(67).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(67).Width = 102F;
            this.spdHistory_Sheet1.Columns.Get(68).Label = "From To Mat ID";
            this.spdHistory_Sheet1.Columns.Get(68).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(68).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(68).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(69).Label = "From To Mat Version";
            this.spdHistory_Sheet1.Columns.Get(69).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(69).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(69).Width = 107F;
            this.spdHistory_Sheet1.Columns.Get(70).Label = "From To Flow";
            this.spdHistory_Sheet1.Columns.Get(70).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(70).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(70).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(71).Label = "From To Flow Seq";
            this.spdHistory_Sheet1.Columns.Get(71).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(71).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(71).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(72).Label = "From To Oper";
            this.spdHistory_Sheet1.Columns.Get(72).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(72).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(72).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(73).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdHistory_Sheet1.Columns.Get(73).Label = "From To Qty 1";
            this.spdHistory_Sheet1.Columns.Get(73).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(73).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(73).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(74).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdHistory_Sheet1.Columns.Get(74).Label = "From To Qty 2";
            this.spdHistory_Sheet1.Columns.Get(74).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(74).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(74).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(75).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdHistory_Sheet1.Columns.Get(75).Label = "From To Qty 3";
            this.spdHistory_Sheet1.Columns.Get(75).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(75).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(75).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(76).Label = "From To Hist Seq";
            this.spdHistory_Sheet1.Columns.Get(76).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(76).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(76).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(77).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(77).Label = "Ship Code";
            this.spdHistory_Sheet1.Columns.Get(77).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(77).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(77).Width = 107F;
            this.spdHistory_Sheet1.Columns.Get(78).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(78).Label = "Ship Time";
            this.spdHistory_Sheet1.Columns.Get(78).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(78).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(78).Width = 125F;
            this.spdHistory_Sheet1.Columns.Get(79).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(79).Label = "Original Due Time";
            this.spdHistory_Sheet1.Columns.Get(79).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(79).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(79).Width = 125F;
            this.spdHistory_Sheet1.Columns.Get(80).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(80).Label = "Scheduled Due Time";
            this.spdHistory_Sheet1.Columns.Get(80).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(80).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(80).Width = 133F;
            this.spdHistory_Sheet1.Columns.Get(81).Label = "Factory In Time";
            this.spdHistory_Sheet1.Columns.Get(81).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(81).Width = 125F;
            this.spdHistory_Sheet1.Columns.Get(82).Label = "Flow In Time";
            this.spdHistory_Sheet1.Columns.Get(82).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(82).Width = 125F;
            this.spdHistory_Sheet1.Columns.Get(83).Label = "Oper In Time";
            this.spdHistory_Sheet1.Columns.Get(83).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(83).Width = 125F;
            this.spdHistory_Sheet1.Columns.Get(84).Label = "Reserve Resource";
            this.spdHistory_Sheet1.Columns.Get(84).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(84).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(84).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(85).Label = "Port ID";
            this.spdHistory_Sheet1.Columns.Get(85).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(85).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(85).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(86).Label = "Batch ID";
            this.spdHistory_Sheet1.Columns.Get(86).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(86).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(86).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(87).Label = "Batch Seq";
            this.spdHistory_Sheet1.Columns.Get(87).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(87).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(87).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(88).Label = "Order ID";
            this.spdHistory_Sheet1.Columns.Get(88).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(88).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(88).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(89).Label = "Add Order ID 1";
            this.spdHistory_Sheet1.Columns.Get(89).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(89).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(89).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(90).Label = "Add Order ID 2";
            this.spdHistory_Sheet1.Columns.Get(90).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(90).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(90).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(91).Label = "Add Order ID 3";
            this.spdHistory_Sheet1.Columns.Get(91).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(91).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(91).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(92).Label = "Lot Location 1";
            this.spdHistory_Sheet1.Columns.Get(92).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(92).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(92).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(93).Label = "Lot Location 2";
            this.spdHistory_Sheet1.Columns.Get(93).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(93).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(93).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(94).Label = "Lot Location 3";
            this.spdHistory_Sheet1.Columns.Get(94).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(94).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(94).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(95).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(95).Label = "Lot Cmf 1";
            this.spdHistory_Sheet1.Columns.Get(95).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(95).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(95).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(96).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(96).Label = "Lot Cmf 2";
            this.spdHistory_Sheet1.Columns.Get(96).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(96).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(96).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(97).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(97).Label = "Lot Cmf 3";
            this.spdHistory_Sheet1.Columns.Get(97).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(97).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(97).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(98).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(98).Label = "Lot Cmf 4";
            this.spdHistory_Sheet1.Columns.Get(98).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(98).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(98).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(99).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(99).Label = "Lot Cmf 5";
            this.spdHistory_Sheet1.Columns.Get(99).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(99).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(99).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(100).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(100).Label = "Lot Cmf 6";
            this.spdHistory_Sheet1.Columns.Get(100).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(100).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(100).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(101).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(101).Label = "Lot Cmf 7";
            this.spdHistory_Sheet1.Columns.Get(101).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(101).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(101).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(102).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(102).Label = "Lot Cmf 8";
            this.spdHistory_Sheet1.Columns.Get(102).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(102).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(102).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(103).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(103).Label = "Lot Cmf 9";
            this.spdHistory_Sheet1.Columns.Get(103).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(103).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(103).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(104).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(104).Label = "Lot Cmf 10";
            this.spdHistory_Sheet1.Columns.Get(104).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(104).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(104).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(105).Label = "Lot Cmf 11";
            this.spdHistory_Sheet1.Columns.Get(105).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(105).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(105).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(106).Label = "Lot Cmf 12";
            this.spdHistory_Sheet1.Columns.Get(106).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(106).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(106).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(107).Label = "Lot Cmf 13";
            this.spdHistory_Sheet1.Columns.Get(107).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(107).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(107).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(108).Label = "Lot Cmf 14";
            this.spdHistory_Sheet1.Columns.Get(108).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(108).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(108).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(109).Label = "Lot Cmf 15";
            this.spdHistory_Sheet1.Columns.Get(109).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(109).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(109).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(110).Label = "Lot Cmf 16";
            this.spdHistory_Sheet1.Columns.Get(110).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(110).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(110).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(111).Label = "Lot Cmf 17";
            this.spdHistory_Sheet1.Columns.Get(111).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(111).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(111).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(112).Label = "Lot Cmf 18";
            this.spdHistory_Sheet1.Columns.Get(112).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(112).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(112).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(113).Label = "Lot Cmf 19";
            this.spdHistory_Sheet1.Columns.Get(113).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(113).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(113).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(114).Label = "Lot Cmf 20";
            this.spdHistory_Sheet1.Columns.Get(114).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(114).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(114).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(115).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(115).Label = "Lot Delete Flag";
            this.spdHistory_Sheet1.Columns.Get(115).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(115).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(115).Width = 108F;
            this.spdHistory_Sheet1.Columns.Get(116).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(116).Label = "Lot Delete Code";
            this.spdHistory_Sheet1.Columns.Get(116).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(116).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(116).Width = 128F;
            this.spdHistory_Sheet1.Columns.Get(117).Label = "Bom Set ID";
            this.spdHistory_Sheet1.Columns.Get(117).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(117).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(117).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(118).Label = "Bom Set Version";
            this.spdHistory_Sheet1.Columns.Get(118).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(118).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(118).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(119).Label = "Bom Active Hist Seq";
            this.spdHistory_Sheet1.Columns.Get(119).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(119).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(119).Width = 116F;
            this.spdHistory_Sheet1.Columns.Get(120).Label = "Bom Hist Seq";
            this.spdHistory_Sheet1.Columns.Get(120).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(120).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(120).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(121).Label = "Critical Resource";
            this.spdHistory_Sheet1.Columns.Get(121).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(121).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(121).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(122).Label = "Critical Resource Group";
            this.spdHistory_Sheet1.Columns.Get(122).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(122).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(122).Width = 123F;
            this.spdHistory_Sheet1.Columns.Get(123).Label = "Save Resource 1";
            this.spdHistory_Sheet1.Columns.Get(123).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(123).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(123).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(124).Label = "Save Resource 2";
            this.spdHistory_Sheet1.Columns.Get(124).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(124).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(124).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(125).Label = "Sub Resource";
            this.spdHistory_Sheet1.Columns.Get(125).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(125).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(125).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(126).Label = "Lot Group ID 1";
            this.spdHistory_Sheet1.Columns.Get(126).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(126).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(126).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(127).Label = "Lot Group ID 2";
            this.spdHistory_Sheet1.Columns.Get(127).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(127).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(127).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(128).Label = "Lot Group ID 3";
            this.spdHistory_Sheet1.Columns.Get(128).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(128).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(128).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(129).Label = "Yield 1";
            this.spdHistory_Sheet1.Columns.Get(129).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(129).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(129).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(130).Label = "Yield 2";
            this.spdHistory_Sheet1.Columns.Get(130).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(130).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(130).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(131).Label = "Yield 3";
            this.spdHistory_Sheet1.Columns.Get(131).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(131).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(131).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(132).Label = "Good Qty";
            this.spdHistory_Sheet1.Columns.Get(132).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(132).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(132).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(133).Label = "Resv Field 1";
            this.spdHistory_Sheet1.Columns.Get(133).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(133).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(133).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(134).Label = "Resv Field 2";
            this.spdHistory_Sheet1.Columns.Get(134).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(134).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(134).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(135).Label = "Resv Field 3";
            this.spdHistory_Sheet1.Columns.Get(135).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(135).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(135).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(136).Label = "Resv Field 4";
            this.spdHistory_Sheet1.Columns.Get(136).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(136).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(136).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(137).Label = "Resv Field 5";
            this.spdHistory_Sheet1.Columns.Get(137).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(137).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(137).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(138).Label = "Resv Flag 1";
            this.spdHistory_Sheet1.Columns.Get(138).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(138).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(138).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(139).Label = "Resv Flag 2";
            this.spdHistory_Sheet1.Columns.Get(139).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(139).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(139).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(140).Label = "Resv Flag 3";
            this.spdHistory_Sheet1.Columns.Get(140).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(140).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(140).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(141).Label = "Resv Flag 4";
            this.spdHistory_Sheet1.Columns.Get(141).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(141).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(141).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(142).Label = "Resv Flag 5";
            this.spdHistory_Sheet1.Columns.Get(142).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(142).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(142).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(143).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(143).Label = "Old Factory";
            this.spdHistory_Sheet1.Columns.Get(143).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(143).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(143).Width = 95F;
            this.spdHistory_Sheet1.Columns.Get(144).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(144).Label = "Old Mat ID";
            this.spdHistory_Sheet1.Columns.Get(144).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(144).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(144).Width = 88F;
            this.spdHistory_Sheet1.Columns.Get(145).Label = "Old Mat Version";
            this.spdHistory_Sheet1.Columns.Get(145).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(145).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(145).Width = 92F;
            this.spdHistory_Sheet1.Columns.Get(146).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(146).Label = "Old Flow";
            this.spdHistory_Sheet1.Columns.Get(146).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(146).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(146).Width = 99F;
            this.spdHistory_Sheet1.Columns.Get(147).Label = "Old Flow Seq";
            this.spdHistory_Sheet1.Columns.Get(147).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(147).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(147).Width = 80F;
            this.spdHistory_Sheet1.Columns.Get(148).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(148).Label = "Old Oper";
            this.spdHistory_Sheet1.Columns.Get(148).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(148).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(149).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdHistory_Sheet1.Columns.Get(149).Label = "Old Qty 1";
            this.spdHistory_Sheet1.Columns.Get(149).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(149).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(149).Width = 80F;
            this.spdHistory_Sheet1.Columns.Get(150).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdHistory_Sheet1.Columns.Get(150).Label = "Old Qty 2";
            this.spdHistory_Sheet1.Columns.Get(150).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(150).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(150).Width = 80F;
            this.spdHistory_Sheet1.Columns.Get(151).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdHistory_Sheet1.Columns.Get(151).Label = "Old Qty 3";
            this.spdHistory_Sheet1.Columns.Get(151).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(151).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(151).Width = 80F;
            this.spdHistory_Sheet1.Columns.Get(152).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdHistory_Sheet1.Columns.Get(152).Label = "Old Hist Seq";
            this.spdHistory_Sheet1.Columns.Get(152).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(152).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(152).Width = 98F;
            this.spdHistory_Sheet1.Columns.Get(153).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(153).Label = "Old Lot Type";
            this.spdHistory_Sheet1.Columns.Get(153).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(153).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(153).Width = 101F;
            this.spdHistory_Sheet1.Columns.Get(154).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(154).Label = "Old Owner Code";
            this.spdHistory_Sheet1.Columns.Get(154).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(154).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(154).Width = 123F;
            this.spdHistory_Sheet1.Columns.Get(155).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(155).Label = "Old Create Code";
            this.spdHistory_Sheet1.Columns.Get(155).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(155).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(155).Width = 114F;
            this.spdHistory_Sheet1.Columns.Get(156).Label = "Old Factory In Time";
            this.spdHistory_Sheet1.Columns.Get(156).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(156).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(156).Width = 120F;
            this.spdHistory_Sheet1.Columns.Get(157).Label = "Old Flow In Time";
            this.spdHistory_Sheet1.Columns.Get(157).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(157).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(157).Width = 120F;
            this.spdHistory_Sheet1.Columns.Get(158).Label = "Old Oper In Time";
            this.spdHistory_Sheet1.Columns.Get(158).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(158).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(158).Width = 120F;
            this.spdHistory_Sheet1.Columns.Get(159).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(159).Label = "Trans Cmf 1";
            this.spdHistory_Sheet1.Columns.Get(159).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(159).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(159).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(160).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(160).Label = "Trans Cmf 2";
            this.spdHistory_Sheet1.Columns.Get(160).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(160).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(160).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(161).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(161).Label = "Trans Cmf 3";
            this.spdHistory_Sheet1.Columns.Get(161).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(161).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(161).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(162).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(162).Label = "Trans Cmf 4";
            this.spdHistory_Sheet1.Columns.Get(162).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(162).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(162).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(163).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(163).Label = "Trans Cmf 5";
            this.spdHistory_Sheet1.Columns.Get(163).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(163).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(163).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(164).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(164).Label = "Trans Cmf 6";
            this.spdHistory_Sheet1.Columns.Get(164).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(164).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(164).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(165).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(165).Label = "Trans Cmf 7";
            this.spdHistory_Sheet1.Columns.Get(165).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(165).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(165).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(166).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(166).Label = "Trans Cmf 8";
            this.spdHistory_Sheet1.Columns.Get(166).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(166).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(166).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(167).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(167).Label = "Trans Cmf 9";
            this.spdHistory_Sheet1.Columns.Get(167).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(167).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(167).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(168).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(168).Label = "Trans Cmf 10";
            this.spdHistory_Sheet1.Columns.Get(168).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(168).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(168).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(169).Label = "Tran Cmf 11";
            this.spdHistory_Sheet1.Columns.Get(169).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(169).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(169).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(170).Label = "Tran Cmf 12";
            this.spdHistory_Sheet1.Columns.Get(170).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(170).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(170).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(171).Label = "Tran Cmf 13";
            this.spdHistory_Sheet1.Columns.Get(171).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(171).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(171).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(172).Label = "Tran Cmf 14";
            this.spdHistory_Sheet1.Columns.Get(172).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(172).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(172).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(173).Label = "Tran Cmf 15";
            this.spdHistory_Sheet1.Columns.Get(173).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(173).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(173).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(174).Label = "Tran Cmf 16";
            this.spdHistory_Sheet1.Columns.Get(174).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(174).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(174).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(175).Label = "Tran Cmf 17";
            this.spdHistory_Sheet1.Columns.Get(175).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(175).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(175).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(176).Label = "Tran Cmf 18";
            this.spdHistory_Sheet1.Columns.Get(176).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(176).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(176).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(177).Label = "Tran Cmf 19";
            this.spdHistory_Sheet1.Columns.Get(177).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(177).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(177).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(178).Label = "Tran Cmf 20";
            this.spdHistory_Sheet1.Columns.Get(178).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(178).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(178).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(179).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(179).Label = "Tran User ID";
            this.spdHistory_Sheet1.Columns.Get(179).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(179).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(179).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(180).Label = "Tran Comment";
            this.spdHistory_Sheet1.Columns.Get(180).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(180).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(180).Width = 86F;
            this.spdHistory_Sheet1.Columns.Get(181).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdHistory_Sheet1.Columns.Get(181).Label = "Prev Active Hist Seq";
            this.spdHistory_Sheet1.Columns.Get(181).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(181).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(181).Width = 131F;
            this.spdHistory_Sheet1.Columns.Get(182).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(182).Label = "Multi Tr Key";
            this.spdHistory_Sheet1.Columns.Get(182).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(182).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(182).Width = 92F;
            this.spdHistory_Sheet1.Columns.Get(183).Label = "Multi Tr Seq";
            this.spdHistory_Sheet1.Columns.Get(183).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(183).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Top;
            this.spdHistory_Sheet1.Columns.Get(183).Width = 74F;
            this.spdHistory_Sheet1.Columns.Get(184).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(184).Label = "Hist Delete Flag";
            this.spdHistory_Sheet1.Columns.Get(184).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(184).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(184).Width = 98F;
            this.spdHistory_Sheet1.Columns.Get(185).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(185).Label = "Hist Delete Time";
            this.spdHistory_Sheet1.Columns.Get(185).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(185).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(185).Width = 125F;
            this.spdHistory_Sheet1.Columns.Get(186).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(186).Label = "Hist Delete User ID";
            this.spdHistory_Sheet1.Columns.Get(186).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(186).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(186).Width = 127F;
            this.spdHistory_Sheet1.Columns.Get(187).Label = "Hist Delete Comment";
            this.spdHistory_Sheet1.Columns.Get(187).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(187).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(187).Width = 116F;
            this.spdHistory_Sheet1.Columns.Get(188).Label = "Sys Tran Time";
            this.spdHistory_Sheet1.Columns.Get(188).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(188).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(188).Width = 125F;
            this.spdHistory_Sheet1.FrozenColumnCount = 3;
            this.spdHistory_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdHistory_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
            this.spdHistory_Sheet1.RowHeader.AutoText = FarPoint.Win.Spread.HeaderAutoText.Blank;
            this.spdHistory_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdHistory_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdHistory_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdHistory_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.spdHistory_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.spdHistory_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdHistory_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdHistory_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // tbpExtension
            // 
            this.tbpExtension.Controls.Add(this.spdExtension);
            this.tbpExtension.Location = new System.Drawing.Point(4, 22);
            this.tbpExtension.Name = "tbpExtension";
            this.tbpExtension.Size = new System.Drawing.Size(593, 416);
            this.tbpExtension.TabIndex = 2;
            this.tbpExtension.Text = "Extension";
            this.tbpExtension.UseVisualStyleBackColor = true;
            // 
            // spdExtension
            // 
            this.spdExtension.AccessibleDescription = "";
            this.spdExtension.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdExtension.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdExtension.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdExtension.HorizontalScrollBar.Name = "";
            this.spdExtension.HorizontalScrollBar.Renderer = defaultScrollBarRenderer5;
            this.spdExtension.HorizontalScrollBar.TabIndex = 6;
            this.spdExtension.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdExtension.Location = new System.Drawing.Point(0, 0);
            this.spdExtension.Name = "spdExtension";
            this.spdExtension.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdExtension.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdExtension.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdExtension_Sheet1});
            this.spdExtension.Size = new System.Drawing.Size(593, 416);
            this.spdExtension.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdExtension.TabIndex = 0;
            this.spdExtension.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdExtension.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdExtension.VerticalScrollBar.Name = "";
            this.spdExtension.VerticalScrollBar.Renderer = defaultScrollBarRenderer6;
            this.spdExtension.VerticalScrollBar.TabIndex = 7;
            this.spdExtension.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdExtension.SetActiveViewport(0, -1, -1);
            // 
            // spdExtension_Sheet1
            // 
            this.spdExtension_Sheet1.Reset();
            spdExtension_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdExtension_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdExtension_Sheet1.ColumnCount = 1;
            spdExtension_Sheet1.RowCount = 0;
            spdExtension_Sheet1.RowHeader.ColumnCount = 0;
            this.spdExtension_Sheet1.ActiveColumnIndex = -1;
            this.spdExtension_Sheet1.ActiveRowIndex = -1;
            this.spdExtension_Sheet1.AlternatingRows.Get(1).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdExtension_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdExtension_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdExtension_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdExtension_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdExtension_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdExtension_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdExtension_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdExtension_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdExtension_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdExtension_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdExtension_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdExtension_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdExtension_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // btnExpand
            // 
            this.btnExpand.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExpand.Image = ((System.Drawing.Image)(resources.GetObject("btnExpand.Image")));
            this.btnExpand.Location = new System.Drawing.Point(74, 6);
            this.btnExpand.Name = "btnExpand";
            this.btnExpand.Size = new System.Drawing.Size(24, 24);
            this.btnExpand.TabIndex = 4;
            this.btnExpand.Click += new System.EventHandler(this.btnExpand_Click);
            // 
            // btnCollapse
            // 
            this.btnCollapse.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCollapse.Image = ((System.Drawing.Image)(resources.GetObject("btnCollapse.Image")));
            this.btnCollapse.Location = new System.Drawing.Point(42, 6);
            this.btnCollapse.Name = "btnCollapse";
            this.btnCollapse.Size = new System.Drawing.Size(24, 24);
            this.btnCollapse.TabIndex = 3;
            this.btnCollapse.Click += new System.EventHandler(this.btnCollapse_Click);
            // 
            // imlFromToIcon
            // 
            this.imlFromToIcon.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlFromToIcon.ImageStream")));
            this.imlFromToIcon.TransparentColor = System.Drawing.Color.Transparent;
            this.imlFromToIcon.Images.SetKeyName(0, "");
            this.imlFromToIcon.Images.SetKeyName(1, "");
            // 
            // imlSPIcons
            // 
            this.imlSPIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlSPIcons.ImageStream")));
            this.imlSPIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.imlSPIcons.Images.SetKeyName(0, "");
            this.imlSPIcons.Images.SetKeyName(1, "");
            this.imlSPIcons.Images.SetKeyName(2, "");
            this.imlSPIcons.Images.SetKeyName(3, "");
            // 
            // chkExtension
            // 
            this.chkExtension.AutoSize = true;
            this.chkExtension.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkExtension.Location = new System.Drawing.Point(475, 43);
            this.chkExtension.Name = "chkExtension";
            this.chkExtension.Size = new System.Drawing.Size(151, 18);
            this.chkExtension.TabIndex = 4;
            this.chkExtension.Text = "Include Extension History";
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter1.Location = new System.Drawing.Point(601, 3);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 442);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // pnlViewRight
            // 
            this.pnlViewRight.Controls.Add(this.lisInquiryHistory);
            this.pnlViewRight.Controls.Add(this.pnlTempLabel);
            this.pnlViewRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlViewRight.Location = new System.Drawing.Point(604, 3);
            this.pnlViewRight.Name = "pnlViewRight";
            this.pnlViewRight.Size = new System.Drawing.Size(138, 442);
            this.pnlViewRight.TabIndex = 2;
            // 
            // lisInquiryHistory
            // 
            this.lisInquiryHistory.AutoArrange = false;
            this.lisInquiryHistory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colPrevLotID});
            this.lisInquiryHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisInquiryHistory.EnableSort = true;
            this.lisInquiryHistory.EnableSortIcon = true;
            this.lisInquiryHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisInquiryHistory.FullRowSelect = true;
            this.lisInquiryHistory.HideSelection = false;
            this.lisInquiryHistory.Location = new System.Drawing.Point(0, 21);
            this.lisInquiryHistory.MultiSelect = false;
            this.lisInquiryHistory.Name = "lisInquiryHistory";
            this.lisInquiryHistory.Size = new System.Drawing.Size(138, 421);
            this.lisInquiryHistory.TabIndex = 1;
            this.lisInquiryHistory.UseCompatibleStateImageBehavior = false;
            this.lisInquiryHistory.View = System.Windows.Forms.View.Details;
            this.lisInquiryHistory.Click += new System.EventHandler(this.lisInquiryHistory_Click);
            // 
            // colPrevLotID
            // 
            this.colPrevLotID.Text = "Lot ID";
            this.colPrevLotID.Width = 120;
            // 
            // pnlTempLabel
            // 
            this.pnlTempLabel.Controls.Add(this.lblTemp);
            this.pnlTempLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTempLabel.Location = new System.Drawing.Point(0, 0);
            this.pnlTempLabel.Name = "pnlTempLabel";
            this.pnlTempLabel.Size = new System.Drawing.Size(138, 21);
            this.pnlTempLabel.TabIndex = 2;
            // 
            // lblTemp
            // 
            this.lblTemp.AutoSize = true;
            this.lblTemp.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblTemp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTemp.Location = new System.Drawing.Point(6, 5);
            this.lblTemp.Name = "lblTemp";
            this.lblTemp.Size = new System.Drawing.Size(73, 13);
            this.lblTemp.TabIndex = 1;
            this.lblTemp.Text = "Inquiry History";
            // 
            // frmWIPViewLotHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Name = "frmWIPViewLotHistory";
            this.Text = "View Lot History";
            this.Activated += new System.EventHandler(this.frmWIPViewLotHistory_Activated);
            this.Load += new System.EventHandler(this.frmWIPViewLotHistory_Load);
            this.pnlViewTop.ResumeLayout(false);
            this.grpOption.ResumeLayout(false);
            this.grpOption.PerformLayout();
            this.pnlViewMid.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlPeriod.ResumeLayout(false);
            this.pnlPeriod.PerformLayout();
            this.tabHistory.ResumeLayout(false);
            this.tbpView1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdHistoryBrief)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdHistoryBrief_Sheet1)).EndInit();
            this.tbpView2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdHistory_Sheet1)).EndInit();
            this.tbpExtension.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdExtension)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdExtension_Sheet1)).EndInit();
            this.pnlViewRight.ResumeLayout(false);
            this.pnlTempLabel.ResumeLayout(false);
            this.pnlTempLabel.PerformLayout();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Constant Definition "
        
        private const int COL1_ICON = 0;
        private const int COL1_HIST_SEQ = 1;
        private const int COL1_TRAN_TIME = 2;
        private const int COL1_TRAN_CODE = 3;
        private const int COL1_MAT_ID = 4;
        private const int COL1_MAT_VER = 5;
        private const int COL1_FLOW = 6;
        private const int COL1_FLOW_SEQ = 7;
        private const int COL1_OPER = 8;
        private const int COL1_QTY_1 = 9;
        private const int COL1_QTY_2 = 10;
        private const int COL1_QTY_3 = 11;
        
        private const int COL2_HIST_SEQ = 0;
        
        #endregion
        
        #region " Variable Definition "
        
        private bool b_load_flag;
        
        private FarPoint.Win.Spread.CellType.GeneralCellType plusCellType = new FarPoint.Win.Spread.CellType.GeneralCellType();
        private FarPoint.Win.Spread.CellType.GeneralCellType minusCellType = new FarPoint.Win.Spread.CellType.GeneralCellType();
        private FarPoint.Win.Spread.CellType.GeneralCellType emptyCellType = new FarPoint.Win.Spread.CellType.GeneralCellType();
        private FarPoint.Win.Spread.CellType.GeneralCellType checkCellType = new FarPoint.Win.Spread.CellType.GeneralCellType();
        
        private FarPoint.Win.Spread.CellType.GeneralCellType increaseCellType = new FarPoint.Win.Spread.CellType.GeneralCellType();
        private FarPoint.Win.Spread.CellType.GeneralCellType decreaseCellType = new FarPoint.Win.Spread.CellType.GeneralCellType();
        
        private enum CELL_STATUS
        {
            PLUS = 1,
            MINUS = 2,
            EMPTY = 3,
            CHECK = 4
        }

        private ArrayList gaTranCmfPrompts;
        private ArrayList gaNotExistCmfs;

        private struct CMF_Info
        {
            public string Item_Name;
            public ArrayList Prompt;
        };
        
        CMF_Info[] CMFPromptList;
        #endregion
        
        #region " Function Definition "
        //
        // CheckCondition()
        //       - Check the conditions before transaction
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal FuncName As String : Function Name
        //
        private bool CheckCondition(string FuncName)
        {

            switch (MPCF.Trim(FuncName))
            {
                case "VIEW":
                    
                    if (dtpFrom.Value > dtpTo.Value)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(120));
                        dtpFrom.Value = DateTime.Today.AddMonths(- 1);
                        return false;
                    }
                    break;
                    
            }
            
            return true;
            
        }
        
        public void ActiveFormNow()
        {
            if (MPCF.Trim(MPGV.gsCurrentLot_ID) != "")
            {
                txtLotID.Text = MPGV.gsCurrentLot_ID;
                btnView_Click(btnView, null);
            }
        }
        
        // ViewLotHistory()
        //       - View Lot History Detail
        // Return Value
        //       - boolean : True / False
        // Arguments
        //        - ByVal c_step As String                        : ?ïÏû• Process Step
        //        - ByVal sLotID As String                    : Lot id
        //        - Optional ByVal sFromTime As String = ""   : ?úÏûë ?úÍ∞Ñ
        //        - Optional ByVal sToTime As String = ""     : ÎßàÏ?Îß??úÍ∞Ñ
        //        - Optional ByVal sIncludeDelHistory As String = ""  : Delete HistoryÍπåÏ? ?¨Ìï®??Í≤ÉÏù∏ÏßÄ?
        //
        private bool ViewLotHistory(char c_step, string sLotID, string sFromTime, string sToTime, char sIncludeDelHistory)
        {
            
            int i;
            int iRow;
            string sDetail;
            string sFromTo;

            TRSNode in_node = new TRSNode("VIEW_LOT_HISTORY_IN");
            TRSNode out_node = new TRSNode("VIEW_LOT_HISTORY_OUT");
            FarPoint.Win.Spread.SheetView briefHist;

            try
            {
                MPCF.ClearList(spdHistoryBrief, true);
                MPCF.ClearList(spdExtension, true);

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = c_step;
                in_node.AddString("LOT_ID", MPCF.Trim(sLotID));
                in_node.AddString("FROM_TRAN_TIME", MPCF.Trim(sFromTime));
                in_node.AddString("TO_TRAN_TIME", MPCF.Trim(sToTime));
                in_node.AddChar("INCLUDE_DEL_HIST", sIncludeDelHistory);
                in_node.AddInt("HIST_SEQ", int.MaxValue);

                if (chkExtension.Checked == true)
                    in_node.AddChar("EXT_FLAG", 'Y');

                do
                {
                    if (MPCR.CallService("WIP", "WIP_View_Lot_History", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        WIPLIST.PrintLotHistoryToSpread(spdHistory, out_node.GetList(0)[i]);

                        if(chkExtension.Checked==true)
                            WIPLIST.PrintLotExtHistoryToSpread(spdExtension, out_node.GetList(0)[i]);

                        briefHist = spdHistoryBrief.Sheets[0];
                        iRow = briefHist.RowCount;
                        briefHist.RowCount++;

                        if (out_node.GetList(0)[i].GetChar("HIST_DEL_FLAG") == 'Y')
                        {
                            briefHist.Cells[iRow, COL1_TRAN_TIME, iRow, briefHist.ColumnCount - 1].ForeColor = Color.Magenta;
                        }
                        else
                        {
                            briefHist.Cells[iRow, COL1_TRAN_TIME, iRow, briefHist.ColumnCount - 1].ForeColor = Color.Black;
                        }

                        briefHist.Cells[iRow, COL1_HIST_SEQ, iRow, briefHist.ColumnCount - 1].Font = 
                            new Font(spdHistoryBrief.Font.Name, spdHistoryBrief.Font.Size, FontStyle.Bold);

                        briefHist.Cells[iRow, COL1_ICON].CellType = minusCellType;
                        briefHist.Cells[iRow, COL1_ICON].Tag = CELL_STATUS.MINUS;

                        briefHist.Cells[iRow, COL1_HIST_SEQ].Value = out_node.GetList(0)[i].GetInt("HIST_SEQ").ToString();
                        briefHist.Cells[iRow, COL1_TRAN_TIME].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("TRAN_TIME"));
                        briefHist.Cells[iRow, COL1_TRAN_CODE].Value = out_node.GetList(0)[i].GetString("TRAN_CODE");
                        briefHist.Cells[iRow, COL1_MAT_ID].Value = out_node.GetList(0)[i].GetString("MAT_ID");
                        briefHist.Cells[iRow, COL1_MAT_VER].Value = out_node.GetList(0)[i].GetInt("MAT_VER");
                        briefHist.Cells[iRow, COL1_FLOW].Value = out_node.GetList(0)[i].GetString("FLOW");
                        briefHist.Cells[iRow, COL1_FLOW_SEQ].Value = out_node.GetList(0)[i].GetInt("FLOW_SEQ_NUM");
                        briefHist.Cells[iRow, COL1_OPER].Value = out_node.GetList(0)[i].GetString("OPER");
                        briefHist.Cells[iRow, COL1_QTY_1].Value = MPCF.Format("#######,##0.###", out_node.GetList(0)[i].GetDouble("QTY_1"));
                        briefHist.Cells[iRow, COL1_QTY_2].Value = MPCF.Format("#######,##0.###", out_node.GetList(0)[i].GetDouble("QTY_2"));
                        briefHist.Cells[iRow, COL1_QTY_3].Value = MPCF.Format("#######,##0.###", out_node.GetList(0)[i].GetDouble("QTY_3"));

                        switch (out_node.GetList(0)[i].GetString("TRAN_CODE").ToUpper())
                        {
                            case MPGC.MP_TRAN_CODE_CREATE:

                                sDetail = "Lot Type : " + out_node.GetList(0)[i].GetChar("LOT_TYPE") + "     Priority : " + out_node.GetList(0)[i].GetChar("LOT_PRIORITY");
                                AddRow(sDetail);
                                sDetail = "Create Code : " + out_node.GetList(0)[i].GetString("CREATE_CODE") + "     Owner Code : " + out_node.GetList(0)[i].GetString("OWNER_CODE") + 
                                    "     Due Date : " + MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("SCH_DUE_TIME"), DATE_TIME_FORMAT.DATE);
                                AddRow(sDetail);
                                break;

                            case MPGC.MP_TRAN_CODE_START:
                                /*** #987 Multi Resource (2012.04.09 by JYPARK) ***/
                                //sDetail = "Start Resource ID : " + out_node.GetList(0)[i].GetString("START_RES_ID"); //+"     Event ID : " + out_node.GetList(0)[i].GetString("OPER").event_id);
                                sDetail = "Start Resource ID : " + MPCR.ParseResourceID('1', "START", out_node.GetList(0)[i]);
                                /*** End of Modification (2012.04.09) ***/
                                AddRow(sDetail);
                                break;

                            case MPGC.MP_TRAN_CODE_END:

                                sDetail = "Old Oper : " + out_node.GetList(0)[i].GetString("OLD_OPER") + "     Old Flow : " + out_node.GetList(0)[i].GetString("OLD_FLOW");
                                AddRow(sDetail);
                                sDetail = "Ret Oper : " + out_node.GetList(0)[i].GetString("NSTD_RET_OPER") + "     Ret Flow : " + out_node.GetList(0)[i].GetString("NSTD_RET_FLOW");
                                AddRow(sDetail);
                                /*** #987 Multi Resource (2012.04.09 by JYPARK) ***/
                                //sDetail = "End Resource ID : " + out_node.GetList(0)[i].GetString("START_RES_ID"); //+"     Event ID : " + out_node.GetList(0)[i].GetString("OPER").event_id);
                                sDetail = "End Resource ID : " + MPCR.ParseResourceID('1', "END", out_node.GetList(0)[i]);
                                /*** End of Modification (2012.04.09) ***/
                                AddRow(sDetail);
                                break;

                            case MPGC.MP_TRAN_CODE_MOVE:

                                sDetail = "Old Oper : " + out_node.GetList(0)[i].GetString("OLD_OPER") + "     Old Flow : " + out_node.GetList(0)[i].GetString("OLD_FLOW");
                                AddRow(sDetail);
                                break;

                            case MPGC.MP_TRAN_CODE_REWORK:

                                sDetail = "Rework Code : " + out_node.GetList(0)[i].GetString("RWK_CODE") + "     Rework Count : " + out_node.GetList(0)[i].GetInt("RWK_COUNT").ToString() + 
                                    "     Rework Return Clear Flag : " + out_node.GetList(0)[i].GetChar("RWK_RET_CLEAR_FLAG");
                                AddRow(sDetail);
                                sDetail = "Old Flow : " + out_node.GetList(0)[i].GetString("OLD_FLOW") + "     Old Oper : " + out_node.GetList(0)[i].GetString("OLD_OPER");
                                AddRow(sDetail);
                                sDetail = "Ret Flow : " + out_node.GetList(0)[i].GetString("RWK_RET_FLOW") + "     Ret Oper : " + out_node.GetList(0)[i].GetString("RWK_RET_OPER");
                                AddRow(sDetail);
                                sDetail = "End Flow : " + out_node.GetList(0)[i].GetString("RWK_END_FLOW") + "     End Oper : " + out_node.GetList(0)[i].GetString("RWK_END_OPER");
                                AddRow(sDetail);
                                /*** #987 Multi Resource (2012.04.09 by JYPARK) ***/
                                //sDetail = "Resource ID : " + out_node.GetList(0)[i].GetString("START_RES_ID"); //+"     Event ID : " + out_node.GetList(0)[i].GetString("OPER").event_id);
                                sDetail = "Resource ID : " + MPCR.ParseResourceID('1', "END", out_node.GetList(0)[i]);
                                /*** End of Modification (2012.04.09) ***/
                                AddRow(sDetail);
                                break;

                            case MPGC.MP_TRAN_CODE_LOSS:
                                sDetail = "Old Qty 1 : " + MPCF.Format("#######,##0.###", out_node.GetList(0)[i].GetDouble("OLD_QTY_1")) + 
                                    " (" + MPCF.Format("#######,##0.###", out_node.GetList(0)[i].GetDouble("QTY_1") - out_node.GetList(0)[i].GetDouble("OLD_QTY_1")) + ")" + 
                                    "     Old Qty 2 : " + MPCF.Format("#######,##0.###", out_node.GetList(0)[i].GetDouble("OLD_QTY_2")) + 
                                    " (" + MPCF.Format("#######,##0.###", out_node.GetList(0)[i].GetDouble("QTY_2") - out_node.GetList(0)[i].GetDouble("OLD_QTY_2")) + ")" + 
                                    "     Old Qty 3 : " + MPCF.Format("#######,##0.###", out_node.GetList(0)[i].GetDouble("OLD_QTY_3")) + 
                                    " (" + MPCF.Format("#######,##0.###", out_node.GetList(0)[i].GetDouble("QTY_3") - out_node.GetList(0)[i].GetDouble("OLD_QTY_3")) + ")";
                                AddRow(sDetail);
                                /*** #987 Multi Resource (2012.04.09 by JYPARK) ***/
                                //sDetail = "Resource ID : " + out_node.GetList(0)[i].GetString("START_RES_ID"); //+"     Event ID : " + out_node.GetList(0)[i].GetString("OPER").event_id);
                                sDetail = "Resource ID : " + MPCR.ParseResourceID('1', "START", out_node.GetList(0)[i]);
                                /*** End of Modification (2012.04.09) ***/
                                AddRow(sDetail);
                                if (out_node.GetList(0)[i].GetChar("LOT_DEL_FLAG") == 'Y')
                                {
                                    sDetail = "Lot Delete Reason : " + out_node.GetList(0)[i].GetString("LOT_DEL_CODE");
                                    AddRow(sDetail);
                                }
                                break;


                            case MPGC.MP_TRAN_CODE_BONUS:

                                sDetail = "Old Qty 1 : " + MPCF.Format("#######,##0.###", out_node.GetList(0)[i].GetDouble("OLD_QTY_1")) + 
                                    " (" + MPCF.Format("#######,##0.###", out_node.GetList(0)[i].GetDouble("QTY_1") - out_node.GetList(0)[i].GetDouble("OLD_QTY_1")) + ")" + 
                                    "     Old Qty 2 : " + MPCF.Format("#######,##0.###", out_node.GetList(0)[i].GetDouble("OLD_QTY_2")) + 
                                    " (" + MPCF.Format("#######,##0.###", out_node.GetList(0)[i].GetDouble("QTY_2") - out_node.GetList(0)[i].GetDouble("OLD_QTY_2")) + ")" + 
                                    "     Old Qty 3 : " + MPCF.Format("#######,##0.###", out_node.GetList(0)[i].GetDouble("OLD_QTY_3")) + 
                                    " (" + MPCF.Format("#######,##0.###", out_node.GetList(0)[i].GetDouble("QTY_3") - out_node.GetList(0)[i].GetDouble("OLD_QTY_3")) + ")";
                                AddRow(sDetail);
                                /*** #987 Multi Resource (2012.04.09 by JYPARK) ***/
                                //sDetail = "Resource ID : " + out_node.GetList(0)[i].GetString("START_RES_ID"); //+"     Event ID : " + out_node.GetList(0)[i].GetString("OPER").event_id);
                                sDetail = "Resource ID : " + MPCR.ParseResourceID('1', "START", out_node.GetList(0)[i]);
                                /*** End of Modification (2012.04.09) ***/
                                AddRow(sDetail);
                                if (out_node.GetList(0)[i].GetChar("LOT_DEL_FLAG") == 'Y')
                                {
                                    sDetail = "Lot Delete Reason : " + out_node.GetList(0)[i].GetString("LOT_DEL_CODE");
                                    AddRow(sDetail);
                                }
                                break;

                            case MPGC.MP_TRAN_CODE_SPLIT:
                            case MPGC.MP_TRAN_CODE_MERGE:
                            case MPGC.MP_TRAN_CODE_COMBINE:

                                if (out_node.GetList(0)[i].GetString("TRAN_CODE").ToUpper() == MPGC.MP_TRAN_CODE_SPLIT && 
                                    out_node.GetList(0)[i].GetChar("FROM_TO_FLAG") == 'T' && 
                                    out_node.GetList(0)[i].GetInt("HIST_SEQ") == 1)
                                {
                                    sDetail = "Lot Type : " + out_node.GetList(0)[i].GetChar("LOT_TYPE") + "     Priority : " + out_node.GetList(0)[i].GetChar("LOT_PRIORITY");
                                    AddRow(sDetail);
                                    sDetail = "Create Code : " + out_node.GetList(0)[i].GetString("CREATE_CODE") + "     Owner Code : " + out_node.GetList(0)[i].GetString("OWNER_CODE") + 
                                        "     Due Date : " + MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("SCH_DUE_TIME"), DATE_TIME_FORMAT.DATE);
                                    AddRow(sDetail);
                                }
                                else
                                {
                                    sDetail = "Old Qty 1 : " + MPCF.Format("#######,##0.###", out_node.GetList(0)[i].GetDouble("OLD_QTY_1")) +
                                        " (" + MPCF.Format("#######,##0.###", out_node.GetList(0)[i].GetDouble("QTY_1") - out_node.GetList(0)[i].GetDouble("OLD_QTY_1")) + ")" +
                                        "     Old Qty 2 : " + MPCF.Format("#######,##0.###", out_node.GetList(0)[i].GetDouble("OLD_QTY_2")) +
                                        " (" + MPCF.Format("#######,##0.###", out_node.GetList(0)[i].GetDouble("QTY_2") - out_node.GetList(0)[i].GetDouble("OLD_QTY_2")) + ")" +
                                        "     Old Qty 3 : " + MPCF.Format("#######,##0.###", out_node.GetList(0)[i].GetDouble("OLD_QTY_3")) +
                                        " (" + MPCF.Format("#######,##0.###", out_node.GetList(0)[i].GetDouble("QTY_3") - out_node.GetList(0)[i].GetDouble("OLD_QTY_3")) + ")";
                                    AddRow(sDetail);
                                }

                                if (out_node.GetList(0)[i].GetChar("FROM_TO_FLAG") == 'T')
                                {
                                    sFromTo = "From ";
                                }
                                else
                                {
                                    sFromTo = "To ";
                                }

                                sDetail = sFromTo + "Lot ID : " + out_node.GetList(0)[i].GetString("FROM_TO_LOT_ID");
                                AddRow(sDetail, spdHistoryBrief.Sheets[0].RowCount, COL1_TRAN_TIME, 8, FontStyle.Bold);

                                spdHistoryBrief.Sheets[0].Cells[spdHistoryBrief.Sheets[0].RowCount - 1, COL1_TRAN_TIME].Tag = out_node.GetList(0)[i].GetString("FROM_TO_LOT_ID");

                                sDetail = sFromTo + "From To Flag : " + out_node.GetList(0)[i].GetChar("FROM_TO_FLAG");
                                AddRow(sDetail, spdHistoryBrief.Sheets[0].RowCount, COL1_TRAN_TIME, 8, FontStyle.Regular);

                                sDetail = sFromTo + "Material : " + out_node.GetList(0)[i].GetString("FROM_TO_MAT_ID") + "     " + sFromTo + 
                                    "Flow : " + out_node.GetList(0)[i].GetString("FROM_TO_FLOW") + "     " + sFromTo + 
                                    "Oper : " + out_node.GetList(0)[i].GetString("FROM_TO_OPER");
                                AddRow(sDetail);

                                if (out_node.GetList(0)[i].GetString("TRAN_CODE").ToUpper() == MPGC.MP_TRAN_CODE_COMBINE)
                                {
                                    sDetail = sFromTo + "Qty 1 : \'" + MPCF.Format("#######,##0.###", out_node.GetList(0)[i].GetDouble("FROM_TO_QTY_1")) + "\'" + "     " + sFromTo +
                                        "Qty 2 : \'" + MPCF.Format("#######,##0.###", out_node.GetList(0)[i].GetDouble("FROM_TO_QTY_2")) + "\'" + "     " + sFromTo +
                                        "Qty 3 : \'" + MPCF.Format("#######,##0.###", out_node.GetList(0)[i].GetDouble("FROM_TO_QTY_3")) + "\'";
                                }
                                else
                                {
                                    sDetail = sFromTo + "Qty 1 : \'" + MPCF.Format("#######,##0.###", out_node.GetList(0)[i].GetDouble("FROM_TO_QTY_1") - 
                                        (out_node.GetList(0)[i].GetDouble("OLD_QTY_1") - out_node.GetList(0)[i].GetDouble("QTY_1"))) + "\' -> \'" + 
                                        MPCF.Format("#######,##0.###", out_node.GetList(0)[i].GetDouble("FROM_TO_QTY_1")) + "\'" + "     " + sFromTo + 
                                        "Qty 2 : \'" + MPCF.Format("#######,##0.###", out_node.GetList(0)[i].GetDouble("FROM_TO_QTY_2") - 
                                        (out_node.GetList(0)[i].GetDouble("OLD_QTY_2") - out_node.GetList(0)[i].GetDouble("QTY_2"))) + "\' -> \'" + 
                                        MPCF.Format("#######,##0.###", out_node.GetList(0)[i].GetDouble("FROM_TO_QTY_2")) + "\'" + "     " + sFromTo + 
                                        "Qty 3 : \'" + MPCF.Format("#######,##0.###", out_node.GetList(0)[i].GetDouble("FROM_TO_QTY_3") - 
                                        (out_node.GetList(0)[i].GetDouble("OLD_QTY_3") - out_node.GetList(0)[i].GetDouble("QTY_3"))) + "\' -> \'" + 
                                        MPCF.Format("#######,##0.###", out_node.GetList(0)[i].GetDouble("FROM_TO_QTY_3")) + "\'";
                                }
                                AddRow(sDetail);

                                if (out_node.GetList(0)[i].GetChar("LOT_DEL_FLAG") == 'Y')
                                {
                                    sDetail = "Lot Delete Reason : " + out_node.GetList(0)[i].GetString("LOT_DEL_CODE");
                                    AddRow(sDetail);
                                }
                                break;

                            case MPGC.MP_TRAN_CODE_HOLD:

                                sDetail = "Hold Code : " + out_node.GetList(0)[i].GetString("HOLD_CODE");
                                AddRow(sDetail);
                                break;

                            case MPGC.MP_TRAN_CODE_RELEASE:

                                //sDetail = "Release Code : " + out_node.GetList(0)[i].GetString("RELEASE_CODE"));
                                //AddRow(sDetail);
                                break;

                            case MPGC.MP_TRAN_CODE_SHIP:

                                sDetail = "Ship Code : " + out_node.GetList(0)[i].GetString("SHIP_CODE") + 
                                    "     Ship Time : " + MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("SHIP_TIME")) + 
                                    "     Factory : \'" + out_node.GetList(0)[i].GetString("OLD_FACTORY") + "\' -> \'" + out_node.GetList(0)[i].GetString("FACTORY") + "\'";
                                AddRow(sDetail);
                                break;

                            case MPGC.MP_TRAN_CODE_RECEIVE:

                                sDetail = "Lot Type : " + out_node.GetList(0)[i].GetChar("LOT_TYPE") + "     Priority : " + out_node.GetList(0)[i].GetChar("LOT_PRIORITY");
                                AddRow(sDetail);
                                sDetail = "Create Code : " + out_node.GetList(0)[i].GetString("CREATE_CODE") + "     Owner Code : " + out_node.GetList(0)[i].GetString("OWNER_CODE") + 
                                    "     Due Date : " + MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("SCH_DUE_TIME"), DATE_TIME_FORMAT.DATE);
                                AddRow(sDetail);
                                sDetail = "Old Material : " + out_node.GetList(0)[i].GetString("OLD_MAT_ID") + "     Old Oper : " + out_node.GetList(0)[i].GetString("OLD_OPER");
                                AddRow(sDetail);
                                sDetail = "Old Create Code : " + out_node.GetList(0)[i].GetString("OLD_CREATE_CODE") + 
                                    "     Old Owner Code : " + out_node.GetList(0)[i].GetString("OLD_OWNER_CODE");
                                AddRow(sDetail);
                                sDetail = "Old Qty 1 : " + MPCF.Format("#######,##0.###", out_node.GetList(0)[i].GetDouble("OLD_QTY_1")) + 
                                    " (" + MPCF.Format("#######,##0.###", out_node.GetList(0)[i].GetDouble("QTY_1") - out_node.GetList(0)[i].GetDouble("OLD_QTY_1")) + ")" + 
                                    "     Old Qty 2 : " + MPCF.Format("#######,##0.###", out_node.GetList(0)[i].GetDouble("OLD_QTY_2")) + 
                                    " (" + MPCF.Format("#######,##0.###", out_node.GetList(0)[i].GetDouble("QTY_2") - out_node.GetList(0)[i].GetDouble("OLD_QTY_2")) + ")" + 
                                    "     Old Qty 3 : " + MPCF.Format("#######,##0.###", out_node.GetList(0)[i].GetDouble("OLD_QTY_3")) + 
                                    " (" + MPCF.Format("#######,##0.###", out_node.GetList(0)[i].GetDouble("QTY_3") - out_node.GetList(0)[i].GetDouble("OLD_QTY_3")) + ")";
                                AddRow(sDetail);
                                break;

                            case MPGC.MP_TRAN_CODE_ADAPT:

                                sDetail = "Lot Type : " + out_node.GetList(0)[i].GetChar("LOT_TYPE") + "     Priority : " + out_node.GetList(0)[i].GetChar("LOT_PRIORITY");
                                AddRow(sDetail);
                                sDetail = "Create Code : " + out_node.GetList(0)[i].GetString("CREATE_CODE") + "     Owner Code : " + out_node.GetList(0)[i].GetString("OWNER_CODE") + 
                                    "     Due Date : " + MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("SCH_DUE_TIME"), DATE_TIME_FORMAT.DATE);
                                AddRow(sDetail);
                                sDetail = "Old Material : " + out_node.GetList(0)[i].GetString("OLD_MAT_ID") + "     Old Oper : " + out_node.GetList(0)[i].GetString("OLD_OPER");
                                AddRow(sDetail);
                                sDetail = "Old Create Code : " + out_node.GetList(0)[i].GetString("OLD_CREATE_CODE") + 
                                    "     Old Owner Code : " + out_node.GetList(0)[i].GetString("OLD_OWNER_CODE");
                                AddRow(sDetail);
                                sDetail = "Old Qty 1 : " + MPCF.Format("#######,##0.###", out_node.GetList(0)[i].GetDouble("OLD_QTY_1")) + 
                                    " (" + MPCF.Format("#######,##0.###", out_node.GetList(0)[i].GetDouble("QTY_1") - out_node.GetList(0)[i].GetDouble("OLD_QTY_1")) + ")" + 
                                    "     Old Qty 2 : " + MPCF.Format("#######,##0.###", out_node.GetList(0)[i].GetDouble("OLD_QTY_2")) + 
                                    " (" + MPCF.Format("#######,##0.###", out_node.GetList(0)[i].GetDouble("QTY_2") - out_node.GetList(0)[i].GetDouble("OLD_QTY_2")) + ")" + 
                                    "     Old Qty 3 : " + MPCF.Format("#######,##0.###", out_node.GetList(0)[i].GetDouble("OLD_QTY_3")) + 
                                    " (" + MPCF.Format("#######,##0.###", out_node.GetList(0)[i].GetDouble("QTY_3") - out_node.GetList(0)[i].GetDouble("OLD_QTY_3")) + ")";
                                AddRow(sDetail);

                                try
                                {
                                    if (out_node.GetList(0)[i + 1].GetString("SHIP_CODE") != out_node.GetList(0)[i].GetString("SHIP_CODE"))
                                    {
                                        sDetail = "Ship Code : \'" + out_node.GetList(0)[i + 1].GetString("SHIP_CODE") + "\' -> \'" + out_node.GetList(0)[i].GetString("SHIP_CODE") + "\'";
                                        AddRow(sDetail);
                                    }
                                    if (out_node.GetList(0)[i + 1].GetChar("RWK_FLAG") != out_node.GetList(0)[i].GetChar("RWK_FLAG"))
                                    {
                                        sDetail = "Rework Code : \'" + out_node.GetList(0)[i + 1].GetString("RWK_CODE") + "\' -> \'" + out_node.GetList(0)[i].GetString("RWK_CODE") + "\'" + 
                                            "     Rework Count : \'" + out_node.GetList(0)[i + 1].GetInt("RWK_COUNT") + "\' -> \'" + out_node.GetList(0)[i].GetInt("RWK_COUNT") + "\'" + 
                                            "     Rework Return Clear Flag : \'" + out_node.GetList(0)[i + 1].GetChar("RWK_RET_CLEAR_FLAG") + "\' -> \'" + out_node.GetList(0)[i].GetString("RWK_RET_CLEAR_FLAG") + "\'";
                                        AddRow(sDetail);
                                        sDetail = "Rwk Ret Flow : \'" + out_node.GetList(0)[i + 1].GetString("RWK_RET_FLOW") + "\' -> \'" + out_node.GetList(0)[i].GetString("RWK_RET_FLOW") + "\'" + 
                                            "     Rwk Ret Oper : \'" + out_node.GetList(0)[i + 1].GetString("RWK_RET_OPER") + "\' -> \'" + out_node.GetList(0)[i].GetString("RWK_RET_OPER") + "\'";
                                        AddRow(sDetail);
                                        sDetail = "Rwk End Flow : \'" + out_node.GetList(0)[i + 1].GetString("RWK_END_FLOW") + "\' -> \'" + out_node.GetList(0)[i].GetString("RWK_END_FLOW") + "\'" + 
                                            "     Rwk End Oper : \'" + out_node.GetList(0)[i + 1].GetString("RWK_END_OPER") + "\' -> \'" + out_node.GetList(0)[i].GetString("RWK_END_OPER") + "\'";
                                        AddRow(sDetail);
                                    }
                                    if (out_node.GetList(0)[i + 1].GetChar("NSTD_FLAG") != out_node.GetList(0)[i].GetChar("NSTD_FLAG"))
                                    {
                                        sDetail = "Nstd Ret Flow : \'" + out_node.GetList(0)[i + 1].GetString("NSTD_RET_FLOW") + "\' -> \'" + out_node.GetList(0)[i].GetString("NSTD_RET_FLOW") + "\'" + 
                                            "     Nstd Ret Oper : \'" + out_node.GetList(0)[i + 1].GetString("NSTD_RET_OPER") + "\' -> \'" + out_node.GetList(0)[i].GetString("NSTD_RET_OPER") + "\'";
                                        AddRow(sDetail);
                                    }
                                }
                                catch (Exception)
                                {

                                }

                                if (out_node.GetList(0)[i].GetChar("LOT_DEL_FLAG") == 'Y')
                                {
                                    sDetail = "Lot Delete Reason : " + out_node.GetList(0)[i].GetString("LOT_DEL_CODE");
                                    AddRow(sDetail);
                                }
                                break;

                            case MPGC.MP_TRAN_CODE_LOTEDC:

                                //sDetail = "Col Set ID : " + out_node.GetList(0)[i].GetString("COL_SET_ID")) + "     Col Set Version : " + out_node.GetList(0)[i].GetString("OPER").col_set_version);
                                //AddRow(sDetail);
                                break;

                            case MPGC.MP_TRAN_CODE_TERMINATE:

                                sDetail = "Delete Code : " + out_node.GetList(0)[i].GetString("LOT_DEL_CODE");
                                AddRow(sDetail);
                                break;
                        }

                        PrintCmf(out_node.GetList(0)[i]);
                        sDetail = "User ID : " + out_node.GetList(0)[i].GetString("TRAN_USER_ID");

                        AddRow(sDetail);
                        if (out_node.GetList(0)[i].GetString("TRAN_COMMENT") != "")
                        {
                            AddRow(out_node.GetList(0)[i].GetString("TRAN_COMMENT"));
                        }

                        UnderLine();

                    }

                    in_node.SetInt("HIST_SEQ", out_node.GetInt("NEXT_HIST_SEQ"));

                } while (in_node.GetInt("HIST_SEQ") > 0);

                AddInquiryHistory(sLotID);

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            
            return true;
        }
        
        // SetExtHeader()
        //       - Set Lot Extension History Header
        // Return Value
        //       - boolean : True / False
        // Arguments
        //        - ByVal c_step As String
        //
        private bool SetExtHeader()
        {
            
            int i=0;

            TRSNode in_node = new TRSNode("VIEW_GCM_DATA_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_GCM_DATA_LIST_OUT");

            try
            {
                MPCF.ClearList(spdHistoryBrief, true);

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPGC.MP_GCM_LOT_EXTENSION);

                if (MPCR.CallService("BAS", "BAS_View_Data_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                spdExtension.ActiveSheet.ColumnHeader.Cells[0, i].Text = "Seq";
                spdExtension.ActiveSheet.ColumnHeader.Columns.Count++;
                i++;
                spdExtension.ActiveSheet.ColumnHeader.Cells[0, i].Text = "Tran Code";
                spdExtension.ActiveSheet.ColumnHeader.Columns.Count++;
                i++;
                spdExtension.ActiveSheet.ColumnHeader.Cells[0, i].Text = "Tran Time";
                spdExtension.ActiveSheet.ColumnHeader.Columns.Count++;
                i++;
                spdExtension.ActiveSheet.ColumnHeader.Cells[0, i].Text = "Material";
                spdExtension.ActiveSheet.ColumnHeader.Columns.Count++;
                i++;
                spdExtension.ActiveSheet.ColumnHeader.Cells[0, i].Text = "Ver";
                spdExtension.ActiveSheet.ColumnHeader.Columns.Count++;
                i++;
                spdExtension.ActiveSheet.ColumnHeader.Cells[0, i].Text = "Flow";
                spdExtension.ActiveSheet.ColumnHeader.Columns.Count++;
                i++;
                spdExtension.ActiveSheet.ColumnHeader.Cells[0, i].Text = "Flow Seq";
                spdExtension.ActiveSheet.ColumnHeader.Columns.Count++;
                i++;
                spdExtension.ActiveSheet.ColumnHeader.Cells[0, i].Text = "Operation";
                spdExtension.ActiveSheet.ColumnHeader.Columns.Count++;
                i++;
                spdExtension.ActiveSheet.ColumnHeader.Cells[0, i].Text = "Qty 1";
                spdExtension.ActiveSheet.ColumnHeader.Columns.Count++;
                i++;
                spdExtension.ActiveSheet.ColumnHeader.Cells[0, i].Text = "Qty 2";
                spdExtension.ActiveSheet.ColumnHeader.Columns.Count++;
                i++;
                spdExtension.ActiveSheet.ColumnHeader.Cells[0, i].Text = "Qty 3";
                for (i = 2; i < out_node.GetList("DATA_LIST").Count; i++)
                {
                    spdExtension.ActiveSheet.ColumnHeader.Columns.Count++;
                    spdExtension.ActiveSheet.ColumnHeader.Cells[0, i+9].Tag = out_node.GetList("DATA_LIST")[i].GetString("KEY_2");
                    spdExtension.ActiveSheet.ColumnHeader.Cells[0, i+9].Text = out_node.GetList("DATA_LIST")[i].GetString("DATA_1");
                }

                spdExtension.ActiveSheet.Columns[0, spdExtension.ActiveSheet.ColumnCount - 1].Locked = true;
                spdExtension.ActiveSheet.Columns[0, spdExtension.ActiveSheet.ColumnCount - 1].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
                spdExtension.ActiveSheet.Columns[0].Font = new Font(spdExtension.Font, FontStyle.Bold);
                spdExtension.ActiveSheet.Columns[0].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

            return true;

        }
        
        // AddRow()
        //       - Add one Row in spdHistoryBrief
        // Return Value
        //       -
        // Arguments
        //        -
        //
        private void AddRow(string sDetail)
        {
            int iRow;
            
            FarPoint.Win.Spread.SheetView with_1 = spdHistoryBrief.Sheets[0];
            iRow = with_1.RowCount;
            
            with_1.RowCount++;
            with_1.AddSpanCell(iRow, COL1_TRAN_TIME, 1, 8);
            with_1.Cells[iRow, COL1_TRAN_TIME].Value = sDetail;
            with_1.Cells[iRow, COL1_TRAN_TIME].Font = new Font(spdHistoryBrief.Font.Name, 8);
            with_1.Cells[iRow, COL1_TRAN_TIME].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            with_1.Cells[iRow, COL1_TRAN_TIME].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            
            with_1.Rows[iRow].Height = 13;
            
        }

        // AddRow()
        //       - Add one Row in spdHistoryBrief
        // Return Value
        //       -
        // Arguments
        //        -
        //
        private void AddRow(string sDetail, int iRow, int iCol, int iColSpan, FontStyle font_style)
        {
            FarPoint.Win.Spread.SheetView with_1 = spdHistoryBrief.Sheets[0];
            if (iRow >= with_1.RowCount)
            {
                with_1.RowCount = iRow + 1;
            }

            with_1.AddSpanCell(iRow, iCol, 1, iColSpan);
            with_1.Cells[iRow, iCol].Value = sDetail;
            with_1.Cells[iRow, iCol].Font = new Font(spdHistoryBrief.Font.Name, 8, font_style);
            with_1.Cells[iRow, iCol].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            with_1.Cells[iRow, iCol].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;

            with_1.Rows[iRow].Height = 13;

        }
        
        // UnderLine()
        //       - Add Under Line Border in spdHistoryBrief
        // Return Value
        //       -
        // Arguments
        //        -
        //
        private void UnderLine()
        {
            
            spdHistoryBrief.Sheets[0].Rows[spdHistoryBrief.Sheets[0].RowCount - 1].Height = 16;
            
            spdHistoryBrief.Sheets[0].Cells[spdHistoryBrief.Sheets[0].RowCount - 1, COL1_ICON, spdHistoryBrief.Sheets[0].RowCount - 1, spdHistoryBrief.Sheets[0].ColumnCount - 1].Border = new FarPoint.Win.ComplexBorder(new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.None), new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.None), new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.None), new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.ThinLine));
        }

        //Modify by J.S. 2011.09.30 replace service ( BAS_SQL_Query -> WIP_View_Factory_Cmf_List_Detail)
        private bool ViewCMFList()
        {
            TRSNode in_node = new TRSNode("WIP_View_Factory_Cmf_List_Detail_in");
            TRSNode out_node = new TRSNode("WIP_View_Factory_Cmf_List_Detail_out");
            TRSNode item_info;
            int c, r;

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';

                if (MPCR.CallService("WIP", "WIP_View_Factory_Cmf_List_Detail", in_node, ref out_node) == false)
                {
                    CMFPromptList = new CMF_Info[1];
                    CMFPromptList[0].Prompt = new ArrayList();
                    return false;
                }

                CMFPromptList = new CMF_Info[out_node.GetList("ITEM_LIST").Count];

                for (r = 0; r < out_node.GetList("ITEM_LIST").Count; r++)
                {
                    item_info = out_node.GetList("ITEM_LIST")[r];

                    CMFPromptList[r].Prompt = new ArrayList();
                    CMFPromptList[r].Item_Name = item_info.GetString("ITEM_NAME");

                    for (c = 0; c < item_info.GetList("DATA_LIST").Count; c++)
                    {
                        CMFPromptList[r].Prompt.Add(item_info.GetList("DATA_LIST")[c].GetString("PROMPT"));
                    }
                }

                //for (r = 0; r < out_node.GetList("ROWS").Count; r++)
                //{
                //    CMFPromptList[r].Prompt = new ArrayList();
                //    for (c = 0; c < out_node.GetList("COLUMNS").Count; c++)
                //    {                            
                //        if (out_node.GetList("COLUMNS")[c].GetString("NAME") == "ITEM_NAME")
                //        {
                //            CMFPromptList[r].Item_Name = out_node.GetList("ROWS")[r].GetList("COLS")[c].GetString("DATA");
                //        }
                //        else if (MPCF.Trim(out_node.GetList("COLUMNS")[c].GetString("NAME")).Substring(0, 3) == "PRT")
                //        {
                //            if (MPCF.ToInt(out_node.GetList("ROWS")[r].GetList("COLS")[0].GetString("DATA")) > CMFPromptList[r].Prompt.Count)
                //            {
                //                CMFPromptList[r].Prompt.Add(out_node.GetList("ROWS")[r].GetList("COLS")[c].GetString("DATA"));
                //            }
                //        }
                //    }
                //}

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

            return true;

        }
        // PrintCmf()
        //       - Print Cmf
        // Return Value
        //       -
        // Arguments
        //        -
        //
        private void PrintCmf(TRSNode his)
        {
            string sDetail;
            int i, i_item_index;

            try
            {
                i_item_index = -1;

                for (i = 0; i < CMFPromptList.Length; i++)
                {
                    if ("CMF_TRN_" + his.GetString("TRAN_CODE").ToUpper() == CMFPromptList[i].Item_Name)
                    {
                        i_item_index = i;
                        break;
                    }
                }
                if (i_item_index != -1)
                {
                    for (i = 1; i <= CMFPromptList[i_item_index].Prompt.Count; i++)
                    {
                        if (his.GetString("TRAN_CMF_" + i.ToString()) != "")
                        {
                            if (MPCF.Trim(CMFPromptList[i_item_index].Prompt[i - 1]) == "")
                            {
                                sDetail = "Cmf " + i.ToString() + " : " + his.GetString("TRAN_CMF_" + i.ToString());
                            }
                            else
                            {
                                sDetail = CMFPromptList[i_item_index].Prompt[i - 1] + " : " + his.GetString("TRAN_CMF_" + i.ToString());
                            }
                            AddRow(sDetail);
                        }
                    }
                }
                else
                {
                    //Add by J.S 2011.09.30 for exception
                    for (i = 1; i <= 20; i++)
                    {
                        if (his.GetString("TRAN_CMF_" + i.ToString()) != "")
                        {
                            sDetail = "Cmf " + i.ToString() + " : " + his.GetString("TRAN_CMF_" + i.ToString());
                            AddRow(sDetail);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        
        // GetSubMenu()
        //       - initial CodeView Control
        // Return Value
        //       -
        // Arguments
        //        -
        private bool GetSubMenu()
        {
            MenuItem mnuTmp = new MenuItem("View Lot Recipe History", new EventHandler(subMenu_Click));
            mnuTmp.Tag = "RCP3001"; 
            ctxMenu.MenuItems.Add(mnuTmp);
            return true;
        }
        
        #if _CRR
        
        // ViewCarrierListByLotHistory()
        //       - View Carrier List By Lot History
        // Return Value
        //       - boolean : True / False
        // Arguments
        //        - ByVal sLotID As String                    : Lot id
        //        - ByVal iHistSeq As Integer                    : History Sequence
        //        - ByRef sToolTip As String                    : Tool Tip Text
        //
        public bool ViewCarrierListByLotHistory(string sLotID, int iHistSeq, ref string sToolTip)
        {

            int i;
            TRSNode in_node = new TRSNode("VIEW_CARRIER_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_CARRIER_LIST_OUT");

            try
            {

                sToolTip = "";

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LOT_ID", MPCF.Trim(sLotID));
                in_node.AddInt("HIST_SEQ", iHistSeq);

                do
                {
                    if (MPCR.CallService("RAS", "RAS_View_Carrier_List_By_Lot_History", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        sToolTip = sToolTip + out_node.GetList(0)[i].GetString("CRR_ID") + " : " + out_node.GetList(0)[i].GetString("CRR_DESC") + "\r\n";
                    }

                    in_node.SetString("NEXT_CRR_ID", out_node.GetString("NEXT_CRR_ID"));

                } while (in_node.GetString("NEXT_CRR_ID") != "");

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;
        }

        #endif

        public virtual Control GetFisrtFocusItem()
        {
            
            try
            {
                return this.txtLotID;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }
            
        }
        
        #endregion

        private void AddInquiryHistory(string sLotID)
        {
            try
            {
                if (MPCF.FindListItemIndex(lisInquiryHistory, sLotID, false) < 0)
                {
                    ListViewItem itemX = new ListViewItem(sLotID, (int)SMALLICON_INDEX.IDX_LOT);
                    lisInquiryHistory.Items.Insert(0, itemX);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        
        private void frmWIPViewLotHistory_Load(object sender, System.EventArgs e)
        {
            
            plusCellType.BackgroundImage = new FarPoint.Win.Picture(imlSPIcons.Images[(int)CELL_STATUS.PLUS - 1], FarPoint.Win.RenderStyle.Normal, Color.White, FarPoint.Win.HorizontalAlignment.Center, FarPoint.Win.VerticalAlignment.Center);
            minusCellType.BackgroundImage = new FarPoint.Win.Picture(imlSPIcons.Images[(int)CELL_STATUS.MINUS - 1], FarPoint.Win.RenderStyle.Normal, Color.White, FarPoint.Win.HorizontalAlignment.Center, FarPoint.Win.VerticalAlignment.Center);
            emptyCellType.BackgroundImage = new FarPoint.Win.Picture(imlSPIcons.Images[(int)CELL_STATUS.EMPTY - 1], FarPoint.Win.RenderStyle.Normal, Color.White, FarPoint.Win.HorizontalAlignment.Center, FarPoint.Win.VerticalAlignment.Center);
            checkCellType.BackgroundImage = new FarPoint.Win.Picture(imlSPIcons.Images[(int)CELL_STATUS.CHECK - 1], FarPoint.Win.RenderStyle.Normal, Color.White, FarPoint.Win.HorizontalAlignment.Right, FarPoint.Win.VerticalAlignment.Center);
            increaseCellType.BackgroundImage = new FarPoint.Win.Picture(imlFromToIcon.Images[0], FarPoint.Win.RenderStyle.Normal, Color.White, FarPoint.Win.HorizontalAlignment.Center, FarPoint.Win.VerticalAlignment.Center);
            decreaseCellType.BackgroundImage = new FarPoint.Win.Picture(imlFromToIcon.Images[1], FarPoint.Win.RenderStyle.Normal, Color.White, FarPoint.Win.HorizontalAlignment.Center, FarPoint.Win.VerticalAlignment.Center);

            gaTranCmfPrompts = new ArrayList();
            gaNotExistCmfs = new ArrayList();
        }
        
        private void frmWIPViewLotHistory_Activated(object sender, System.EventArgs e)
        {
            
            if (b_load_flag == false)
            {
                MPCF.FieldClear(this);
                MPCF.ClearList(spdHistoryBrief, true);
                MPCF.ClearList(spdHistory, true);
                MPCR.SetLotCmfPrompt(spdHistory, 95);
                MPCF.FitColumnHeader(spdHistory);
                dtpFrom.Value = DateTime.Today.AddMonths(- 1);
                dtpTo.Value = DateTime.Today;
                GetSubMenu();
                txtLotID.Focus();

                ViewCMFList();
                SetExtHeader();
                
                ActiveFormNow();
                
                b_load_flag = true;
            }
        }
        
        private void btnView_Click(System.Object sender, System.EventArgs e)
        {
            string sFromTime;
            string sToTime;
            char sIncludeDelHist;

            MPCF.ClearList(spdHistory, true);
            MPCF.ClearList(spdHistoryBrief, true);
            
            if (txtLotID.Text != "")
            {
                if (CheckCondition("VIEW") == false)
                {
                    return;
                }
                sFromTime = MPCF.FromDate(dtpFrom);
                sToTime = MPCF.ToDate(dtpTo);
                sIncludeDelHist = chkIncludeDelHistory.Checked == true ? 'Y' : ' ';
                
                if (ViewLotHistory('1', txtLotID.Text, sFromTime, sToTime, sIncludeDelHist) == false)
                {
                    return;
                }
                
                MPCF.FitColumnHeader(spdHistory);
                MPCF.FitColumnHeader(spdExtension);
                
                this.Text = MPCF.FindLanguage("Lot History", 0) + " (" + txtLotID.Text + ")";
                this.lblFormTitle.Text = this.Text;
                
            }
        }
        
        private void btnExcel_Click(System.Object sender, System.EventArgs e)
        {
            string sCond;

            sCond = "Date : " + MPCF.MakeDateFormat(MPCF.FromDate(dtpFrom)) + " ~ " + MPCF.MakeDateFormat(MPCF.ToDate(dtpTo));
            
            if (tabHistory.SelectedTab == tbpView1)
            {
                if (MPCF.ExportToExcel(spdHistoryBrief, this.Text, sCond, true, true, true, -1, -1) == false)
                {
                    return;
                }
            }
            else
            {
                if (MPCF.ExportToExcel(spdHistory, this.Text, sCond, true, true, true, -1, -1) == false)
                {
                    return;
                }
            }
            
            
        }
        
        private void spdHistoryBrief_CellClick(System.Object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            int i;
            
            if (spdHistoryBrief.Sheets[0].RowCount < 1)
            {
                return;
            }
            if (e.Column != COL1_ICON)
            {
                return;
            }
            if (e.Row < 0)
            {
                return;
            }
            if (e.ColumnHeader == true)
            {
                return;
            }
            if (e.RowHeader == true)
            {
                return;
            }
            
            FarPoint.Win.Spread.SheetView with_1 = spdHistoryBrief.Sheets[0];
            if (MPCF.Trim(with_1.Cells[e.Row, COL1_ICON].Tag) == "")
            {
                return;
            }
            
            for (i = e.Row + 1; i <= with_1.RowCount - 1; i++)
            {
                if (MPCF.Trim(with_1.Cells[i, COL1_ICON].Tag) != "")
                {
                    break;
                }
                
                if (MPCF.ToInt(with_1.Cells[e.Row, COL1_ICON].Tag) == (int)CELL_STATUS.MINUS)
                {
                    with_1.Rows[i].Visible = false;
                }
                else
                {
                    with_1.Rows[i].Visible = true;
                }
            }

            if (MPCF.ToInt(with_1.Cells[e.Row, COL1_ICON].Tag) == (int)CELL_STATUS.MINUS)
            {
                with_1.Cells[e.Row, COL1_ICON].CellType = plusCellType;
                with_1.Cells[e.Row, COL1_ICON].Tag = CELL_STATUS.PLUS;
            }
            else if (MPCF.ToInt(with_1.Cells[e.Row, COL1_ICON].Tag) == (int)CELL_STATUS.PLUS)
            {
                with_1.Cells[e.Row, COL1_ICON].CellType = minusCellType;
                with_1.Cells[e.Row, COL1_ICON].Tag = CELL_STATUS.MINUS;
            }
            
        }
        
        private void spdHistoryBrief_MouseDown(System.Object sender, System.Windows.Forms.MouseEventArgs e)
        {
            
            int i = 0;
            
            try
            {
                if (spdHistoryBrief.Sheets[0].RowCount < 1)
                {
                    return;
                }
                
                MPGV.gsCurrentLot_ID = "";
                MPGV.giCurrentHistSeq = 0;
                
                if (e.Y <= spdHistoryBrief.Sheets[0].ColumnHeader.Rows[0].Height)
                {
                    return;
                }
                
                if (e.Button == System.Windows.Forms.MouseButtons.Left && e.Clicks >= 2)
                {
                    FarPoint.Win.Spread.SheetView with_1 = spdHistoryBrief.Sheets[0];
                    if (with_1.ActiveColumnIndex != COL1_TRAN_TIME)
                    {
                        return;
                    }
                    
                    if (MPCF.Trim(with_1.Cells[with_1.ActiveRowIndex, COL1_TRAN_TIME].Tag) == "")
                    {
                        return;
                    }
                    
                    txtLotID.Text = MPCF.Trim(with_1.Cells[with_1.ActiveRowIndex, COL1_TRAN_TIME].Tag);
                    btnView_Click(sender, e);
                    
                }

                MPGV.gsCurrentLot_ID = MPCF.Trim(txtLotID.Text);
                FarPoint.Win.Spread.SheetView with_2 = spdHistoryBrief.Sheets[0];
                for (i = 0; i <= 10; i++)
                {
                    if (with_2.ActiveRowIndex - i < 0)
                    {
                        return;
                    }
                    if (MPCF.Trim(with_2.Cells[with_2.ActiveRowIndex - i, COL1_HIST_SEQ].Value) != "")
                    {
                        MPGV.giCurrentHistSeq = MPCF.ToInt(with_2.GetValue(with_2.ActiveRowIndex - i, COL1_HIST_SEQ));
                        break;
                    }
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void spdHistoryBrief_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                ctxMenu.Show(spdHistoryBrief, new Point(e.X, e.Y));
            }
        }
        
        private void spdHistory_MouseDown(System.Object sender, System.Windows.Forms.MouseEventArgs e)
        {
            
            int i = 0;
            
            try
            {
                if (spdHistory.Sheets[0].RowCount < 1)
                {
                    return;
                }
                
                MPGV.gsCurrentLot_ID = "";
                MPGV.giCurrentHistSeq = 0;
                
                if (e.Y <= spdHistory.Sheets[0].ColumnHeader.Rows[0].Height)
                {
                    return;
                }

                MPGV.gsCurrentLot_ID = MPCF.Trim(txtLotID.Text);
                FarPoint.Win.Spread.SheetView with_1 = spdHistory.Sheets[0];
                for (i = 0; i <= 10; i++)
                {
                    if (with_1.ActiveRowIndex - i < 0)
                    {
                        return;
                    }
                    if (MPCF.Trim(with_1.Cells[with_1.ActiveRowIndex - i, 0].Value) != "")
                    {
                        MPGV.giCurrentHistSeq = MPCF.ToInt(with_1.GetValue(with_1.ActiveRowIndex - i, 0));
                        break;
                    }
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void spdHistory_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                ctxMenu.Show(spdHistory, new Point(e.X, e.Y));
            }
        }
        
        private void btnCollapse_Click(System.Object sender, System.EventArgs e)
        {
            int i;
            
            FarPoint.Win.Spread.SheetView with_1 = spdHistoryBrief.Sheets[0];
            for (i = 0; i <= with_1.RowCount - 1; i++)
            {
                if (MPCF.Trim(with_1.Cells[i, COL1_ICON].Tag) == "")
                {
                    with_1.Rows[i].Visible = false;
                }
                else
                {
                    if (MPCF.ToInt(with_1.Cells[i, COL1_ICON].Tag) == (int)CELL_STATUS.MINUS)
                    {
                        with_1.Cells[i, COL1_ICON].CellType = plusCellType;
                        with_1.Cells[i, COL1_ICON].Tag = CELL_STATUS.PLUS;
                    }
                }
            }
            
        }
        
        private void btnExpand_Click(System.Object sender, System.EventArgs e)
        {
            int i;
            
            FarPoint.Win.Spread.SheetView with_1 = spdHistoryBrief.Sheets[0];
            for (i = 0; i <= with_1.RowCount - 1; i++)
            {
                if (MPCF.Trim(with_1.Cells[i, COL1_ICON].Tag) == "")
                {
                    with_1.Rows[i].Visible = true;
                }
                else
                {
                    if (MPCF.ToInt(with_1.Cells[i, COL1_ICON].Tag) == (int)CELL_STATUS.PLUS)
                    {
                        with_1.Cells[i, COL1_ICON].CellType = minusCellType;
                        with_1.Cells[i, COL1_ICON].Tag = CELL_STATUS.MINUS;
                    }
                }
            }
            
        }
        
        private void subMenu_Click(System.Object sender, System.EventArgs e)
        {
            string s_func_name;

            if (((MenuItem)sender).Tag == null) return;
            if (MPCF.Trim(((MenuItem)sender).Tag) == "") return;

            s_func_name = MPCF.Trim(((MenuItem)sender).Tag);
            MPGV.gIMdiForm.ActiveMenu(s_func_name);
        }

        private void lisInquiryHistory_Click(object sender, EventArgs e)
        {
            if (lisInquiryHistory.SelectedIndices.Count > 0)
            {
                txtLotID.Text = lisInquiryHistory.SelectedItems[0].Text;
                btnView.PerformClick();
            }
        }
    }
    
}
