
//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmWIPViewLotTrace.vb
//   Description : MES Cient Form View Lot Trace Class
//
//   MES Version : 4.1.0.0
//
//   Function List
//       - View_Lot_Trace() : View Lot Trace History
//       - SetData() : Set Trace Data into spdLotHistory
//       - FindLot() : Find Lot Id Node
//       - AddLot() : Add New Lot id into spdLotList
//       - FindNodeCount() : Count only Child Node of Parent Node
//       - FindNodeCount() : Count All Child Node of Parent Node
//       - GetNextDepthChar() : Get Level Character
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2004-07-02 : Created by CM Koo
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

using Miracom.MsgHandler;
using System.Data;
using Miracom.MESCore;
using Miracom.CliFrx;
using Miracom.TRSCore;



namespace Miracom.WIPCore
{
    public class frmWIPViewLotTrace : Miracom.MESCore.ViewForm01
    {
        
        #region " Windows Form auto generated code "
        
        public frmWIPViewLotTrace()
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

        
        



        private System.Windows.Forms.TextBox txtLotID;
        private System.Windows.Forms.Label lblLotID;
        private System.Windows.Forms.RadioButton rbnPtoC;
        private System.Windows.Forms.RadioButton rbnCtoP;
        private System.Windows.Forms.Panel pnlInfoLeft;
        private System.Windows.Forms.Panel pnlInfoMid;
        private System.Windows.Forms.Splitter sptInfo;
        private FarPoint.Win.Spread.FpSpread spdLotList;
        private FarPoint.Win.Spread.SheetView spdLotList_Sheet1;
        private System.Windows.Forms.ImageList imlSPIcons;
        private FarPoint.Win.Spread.FpSpread spdOperLotList;
        private FarPoint.Win.Spread.SheetView spdOperLotList_Sheet1;
        private System.Windows.Forms.ContextMenu ctxLotTrace;
        private System.Windows.Forms.MenuItem mnuPtoC;
        private System.Windows.Forms.MenuItem mnuCtoP;
        private System.Windows.Forms.MenuItem mnuLotStatus;
        private System.Windows.Forms.MenuItem mnuLotHistory;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer3 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer4 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.BevelBorder bevelBorder1 = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Raised);
            FarPoint.Win.BevelBorder bevelBorder2 = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Raised);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWIPViewLotTrace));
            this.txtLotID = new System.Windows.Forms.TextBox();
            this.lblLotID = new System.Windows.Forms.Label();
            this.rbnPtoC = new System.Windows.Forms.RadioButton();
            this.rbnCtoP = new System.Windows.Forms.RadioButton();
            this.pnlInfoLeft = new System.Windows.Forms.Panel();
            this.spdOperLotList = new FarPoint.Win.Spread.FpSpread();
            this.spdOperLotList_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.pnlInfoMid = new System.Windows.Forms.Panel();
            this.spdLotList = new FarPoint.Win.Spread.FpSpread();
            this.spdLotList_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.sptInfo = new System.Windows.Forms.Splitter();
            this.imlSPIcons = new System.Windows.Forms.ImageList(this.components);
            this.ctxLotTrace = new System.Windows.Forms.ContextMenu();
            this.mnuPtoC = new System.Windows.Forms.MenuItem();
            this.mnuCtoP = new System.Windows.Forms.MenuItem();
            this.mnuLotStatus = new System.Windows.Forms.MenuItem();
            this.mnuLotHistory = new System.Windows.Forms.MenuItem();
            this.pnlViewTop.SuspendLayout();
            this.grpOption.SuspendLayout();
            this.pnlViewMid.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlInfoLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdOperLotList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdOperLotList_Sheet1)).BeginInit();
            this.pnlInfoMid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdLotList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdLotList_Sheet1)).BeginInit();
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
            this.pnlViewTop.Location = new System.Drawing.Point(2, 0);
            this.pnlViewTop.Size = new System.Drawing.Size(738, 47);
            // 
            // grpOption
            // 
            this.grpOption.Controls.Add(this.rbnCtoP);
            this.grpOption.Controls.Add(this.rbnPtoC);
            this.grpOption.Controls.Add(this.txtLotID);
            this.grpOption.Controls.Add(this.lblLotID);
            this.grpOption.Size = new System.Drawing.Size(738, 47);
            // 
            // pnlViewMid
            // 
            this.pnlViewMid.Controls.Add(this.sptInfo);
            this.pnlViewMid.Controls.Add(this.pnlInfoMid);
            this.pnlViewMid.Controls.Add(this.pnlInfoLeft);
            this.pnlViewMid.Location = new System.Drawing.Point(2, 47);
            this.pnlViewMid.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.pnlViewMid.Size = new System.Drawing.Size(738, 459);
            this.pnlViewMid.TabIndex = 2;
            // 
            // btnClose
            // 
            this.btnClose.TabIndex = 1;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Location = new System.Drawing.Point(0, 506);
            // 
            // pnlCenter
            // 
            this.pnlCenter.Padding = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.pnlCenter.Size = new System.Drawing.Size(742, 506);
            // 
            // pnlTop
            // 
            this.pnlTop.Padding = new System.Windows.Forms.Padding(1);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Location = new System.Drawing.Point(1, 1);
            this.lblFormTitle.Size = new System.Drawing.Size(740, 0);
            this.lblFormTitle.Text = "View Lot Trace";
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
            // rbnPtoC
            // 
            this.rbnPtoC.AutoSize = true;
            this.rbnPtoC.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbnPtoC.Location = new System.Drawing.Point(396, 18);
            this.rbnPtoC.Name = "rbnPtoC";
            this.rbnPtoC.Size = new System.Drawing.Size(100, 18);
            this.rbnPtoC.TabIndex = 2;
            this.rbnPtoC.TabStop = true;
            this.rbnPtoC.Text = "Parent -> Child";
            // 
            // rbnCtoP
            // 
            this.rbnCtoP.AutoSize = true;
            this.rbnCtoP.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbnCtoP.Location = new System.Drawing.Point(550, 18);
            this.rbnCtoP.Name = "rbnCtoP";
            this.rbnCtoP.Size = new System.Drawing.Size(100, 18);
            this.rbnCtoP.TabIndex = 3;
            this.rbnCtoP.TabStop = true;
            this.rbnCtoP.Text = "Child -> Parent";
            // 
            // pnlInfoLeft
            // 
            this.pnlInfoLeft.Controls.Add(this.spdOperLotList);
            this.pnlInfoLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlInfoLeft.Location = new System.Drawing.Point(0, 2);
            this.pnlInfoLeft.Name = "pnlInfoLeft";
            this.pnlInfoLeft.Size = new System.Drawing.Size(210, 457);
            this.pnlInfoLeft.TabIndex = 0;
            // 
            // spdOperLotList
            // 
            this.spdOperLotList.AccessibleDescription = "";
            this.spdOperLotList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdOperLotList.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdOperLotList.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdOperLotList.HorizontalScrollBar.Name = "";
            this.spdOperLotList.HorizontalScrollBar.Renderer = defaultScrollBarRenderer3;
            this.spdOperLotList.HorizontalScrollBar.TabIndex = 2;
            this.spdOperLotList.Location = new System.Drawing.Point(0, 0);
            this.spdOperLotList.Name = "spdOperLotList";
            this.spdOperLotList.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdOperLotList.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdOperLotList.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdOperLotList_Sheet1});
            this.spdOperLotList.Size = new System.Drawing.Size(210, 457);
            this.spdOperLotList.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdOperLotList.TabIndex = 0;
            this.spdOperLotList.TabStop = false;
            this.spdOperLotList.TextTipDelay = 200;
            this.spdOperLotList.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdOperLotList.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdOperLotList.VerticalScrollBar.Name = "";
            this.spdOperLotList.VerticalScrollBar.Renderer = defaultScrollBarRenderer4;
            this.spdOperLotList.VerticalScrollBar.TabIndex = 3;
            this.spdOperLotList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.spdOperLotList_MouseDown);
            this.spdOperLotList.SetActiveViewport(0, -1, -1);
            // 
            // spdOperLotList_Sheet1
            // 
            this.spdOperLotList_Sheet1.Reset();
            spdOperLotList_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdOperLotList_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdOperLotList_Sheet1.ColumnCount = 2;
            spdOperLotList_Sheet1.RowCount = 0;
            this.spdOperLotList_Sheet1.ActiveColumnIndex = -1;
            this.spdOperLotList_Sheet1.ActiveRowIndex = -1;
            this.spdOperLotList_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdOperLotList_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdOperLotList_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdOperLotList_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdOperLotList_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Oper";
            this.spdOperLotList_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Lot ID";
            this.spdOperLotList_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdOperLotList_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdOperLotList_Sheet1.ColumnHeader.Rows.Get(0).Height = 18F;
            this.spdOperLotList_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdOperLotList_Sheet1.Columns.Get(0).Label = "Oper";
            this.spdOperLotList_Sheet1.Columns.Get(0).Locked = true;
            this.spdOperLotList_Sheet1.Columns.Get(0).MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Restricted;
            this.spdOperLotList_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOperLotList_Sheet1.Columns.Get(0).Width = 63F;
            this.spdOperLotList_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdOperLotList_Sheet1.Columns.Get(1).Label = "Lot ID";
            this.spdOperLotList_Sheet1.Columns.Get(1).Locked = true;
            this.spdOperLotList_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOperLotList_Sheet1.Columns.Get(1).Width = 102F;
            this.spdOperLotList_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdOperLotList_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
            this.spdOperLotList_Sheet1.RowHeader.Columns.Default.Resizable = true;
            this.spdOperLotList_Sheet1.RowHeader.Columns.Get(0).Width = 23F;
            this.spdOperLotList_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdOperLotList_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdOperLotList_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.spdOperLotList_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.spdOperLotList_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdOperLotList_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdOperLotList_Sheet1.VisualStyles = FarPoint.Win.VisualStyles.Auto;
            this.spdOperLotList_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // pnlInfoMid
            // 
            this.pnlInfoMid.Controls.Add(this.spdLotList);
            this.pnlInfoMid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlInfoMid.Location = new System.Drawing.Point(210, 2);
            this.pnlInfoMid.Name = "pnlInfoMid";
            this.pnlInfoMid.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.pnlInfoMid.Size = new System.Drawing.Size(528, 457);
            this.pnlInfoMid.TabIndex = 1;
            // 
            // spdLotList
            // 
            this.spdLotList.AccessibleDescription = "spdLotList, Sheet1";
            this.spdLotList.BackColor = System.Drawing.SystemColors.Control;
            this.spdLotList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdLotList.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdLotList.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdLotList.HorizontalScrollBar.Name = "";
            this.spdLotList.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdLotList.HorizontalScrollBar.TabIndex = 2;
            this.spdLotList.Location = new System.Drawing.Point(2, 0);
            this.spdLotList.Name = "spdLotList";
            this.spdLotList.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdLotList.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdLotList.SelectionBlockOptions = ((FarPoint.Win.Spread.SelectionBlockOptions)(((FarPoint.Win.Spread.SelectionBlockOptions.Cells | FarPoint.Win.Spread.SelectionBlockOptions.Rows)
                        | FarPoint.Win.Spread.SelectionBlockOptions.Columns)));
            this.spdLotList.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdLotList_Sheet1});
            this.spdLotList.Size = new System.Drawing.Size(526, 457);
            this.spdLotList.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdLotList.TabIndex = 0;
            this.spdLotList.TabStop = false;
            this.spdLotList.TextTipDelay = 200;
            this.spdLotList.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdLotList.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdLotList.VerticalScrollBar.Name = "";
            this.spdLotList.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdLotList.VerticalScrollBar.TabIndex = 3;
            this.spdLotList.CellClick += new FarPoint.Win.Spread.CellClickEventHandler(this.spdLotList_CellClick);
            this.spdLotList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.spdLotList_MouseDown);
            this.spdLotList.SetViewportLeftColumn(0, 0, 3);
            this.spdLotList.SetActiveViewport(0, -1, -1);
            // 
            // spdLotList_Sheet1
            // 
            this.spdLotList_Sheet1.Reset();
            spdLotList_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdLotList_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdLotList_Sheet1.ColumnCount = 30;
            spdLotList_Sheet1.ColumnHeader.RowCount = 2;
            spdLotList_Sheet1.RowCount = 0;
            this.spdLotList_Sheet1.ActiveColumnIndex = -1;
            this.spdLotList_Sheet1.ActiveRowIndex = -1;
            this.spdLotList_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdLotList_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdLotList_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdLotList_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdLotList_Sheet1.ColumnHeader.Cells.Get(0, 0).ColumnSpan = 2;
            this.spdLotList_Sheet1.ColumnHeader.Cells.Get(0, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdLotList_Sheet1.ColumnHeader.Cells.Get(0, 0).RowSpan = 2;
            this.spdLotList_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Level";
            this.spdLotList_Sheet1.ColumnHeader.Cells.Get(0, 0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLotList_Sheet1.ColumnHeader.Cells.Get(0, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdLotList_Sheet1.ColumnHeader.Cells.Get(0, 1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLotList_Sheet1.ColumnHeader.Cells.Get(0, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdLotList_Sheet1.ColumnHeader.Cells.Get(0, 2).RowSpan = 2;
            this.spdLotList_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Lot ID";
            this.spdLotList_Sheet1.ColumnHeader.Cells.Get(0, 2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLotList_Sheet1.ColumnHeader.Cells.Get(0, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdLotList_Sheet1.ColumnHeader.Cells.Get(0, 3).RowSpan = 2;
            this.spdLotList_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Tran Code";
            this.spdLotList_Sheet1.ColumnHeader.Cells.Get(0, 3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLotList_Sheet1.ColumnHeader.Cells.Get(0, 4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdLotList_Sheet1.ColumnHeader.Cells.Get(0, 4).RowSpan = 2;
            this.spdLotList_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Tran Time";
            this.spdLotList_Sheet1.ColumnHeader.Cells.Get(0, 4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLotList_Sheet1.ColumnHeader.Cells.Get(0, 5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdLotList_Sheet1.ColumnHeader.Cells.Get(0, 5).RowSpan = 2;
            this.spdLotList_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Material";
            this.spdLotList_Sheet1.ColumnHeader.Cells.Get(0, 5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLotList_Sheet1.ColumnHeader.Cells.Get(0, 6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdLotList_Sheet1.ColumnHeader.Cells.Get(0, 6).RowSpan = 2;
            this.spdLotList_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Mat Ver";
            this.spdLotList_Sheet1.ColumnHeader.Cells.Get(0, 6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLotList_Sheet1.ColumnHeader.Cells.Get(0, 7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdLotList_Sheet1.ColumnHeader.Cells.Get(0, 7).RowSpan = 2;
            this.spdLotList_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "Flow";
            this.spdLotList_Sheet1.ColumnHeader.Cells.Get(0, 7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLotList_Sheet1.ColumnHeader.Cells.Get(0, 8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdLotList_Sheet1.ColumnHeader.Cells.Get(0, 8).RowSpan = 2;
            this.spdLotList_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "Flow Seq";
            this.spdLotList_Sheet1.ColumnHeader.Cells.Get(0, 8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLotList_Sheet1.ColumnHeader.Cells.Get(0, 9).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdLotList_Sheet1.ColumnHeader.Cells.Get(0, 9).RowSpan = 2;
            this.spdLotList_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "Oper";
            this.spdLotList_Sheet1.ColumnHeader.Cells.Get(0, 9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLotList_Sheet1.ColumnHeader.Cells.Get(0, 10).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdLotList_Sheet1.ColumnHeader.Cells.Get(0, 10).RowSpan = 2;
            this.spdLotList_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "C_Material";
            this.spdLotList_Sheet1.ColumnHeader.Cells.Get(0, 10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLotList_Sheet1.ColumnHeader.Cells.Get(0, 11).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdLotList_Sheet1.ColumnHeader.Cells.Get(0, 11).RowSpan = 2;
            this.spdLotList_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "C_Mat Ver";
            this.spdLotList_Sheet1.ColumnHeader.Cells.Get(0, 11).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLotList_Sheet1.ColumnHeader.Cells.Get(0, 12).ColumnSpan = 6;
            this.spdLotList_Sheet1.ColumnHeader.Cells.Get(0, 12).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdLotList_Sheet1.ColumnHeader.Cells.Get(0, 12).Value = "QTY 1";
            this.spdLotList_Sheet1.ColumnHeader.Cells.Get(0, 12).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLotList_Sheet1.ColumnHeader.Cells.Get(0, 18).ColumnSpan = 6;
            this.spdLotList_Sheet1.ColumnHeader.Cells.Get(0, 18).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdLotList_Sheet1.ColumnHeader.Cells.Get(0, 18).Value = "QTY 2";
            this.spdLotList_Sheet1.ColumnHeader.Cells.Get(0, 18).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLotList_Sheet1.ColumnHeader.Cells.Get(0, 24).ColumnSpan = 6;
            this.spdLotList_Sheet1.ColumnHeader.Cells.Get(0, 24).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdLotList_Sheet1.ColumnHeader.Cells.Get(0, 24).Value = "QTY 3";
            this.spdLotList_Sheet1.ColumnHeader.Cells.Get(0, 24).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLotList_Sheet1.ColumnHeader.Cells.Get(1, 11).Value = "Mat Ver";
            this.spdLotList_Sheet1.ColumnHeader.Cells.Get(1, 12).Value = "P Move";
            this.spdLotList_Sheet1.ColumnHeader.Cells.Get(1, 13).Value = "P Old";
            this.spdLotList_Sheet1.ColumnHeader.Cells.Get(1, 14).Value = "P New";
            this.spdLotList_Sheet1.ColumnHeader.Cells.Get(1, 15).Value = "C Move";
            this.spdLotList_Sheet1.ColumnHeader.Cells.Get(1, 16).Value = "C Old";
            this.spdLotList_Sheet1.ColumnHeader.Cells.Get(1, 17).Value = "C New";
            this.spdLotList_Sheet1.ColumnHeader.Cells.Get(1, 18).Value = "P Move";
            this.spdLotList_Sheet1.ColumnHeader.Cells.Get(1, 19).Value = "P Old";
            this.spdLotList_Sheet1.ColumnHeader.Cells.Get(1, 20).Value = "P New";
            this.spdLotList_Sheet1.ColumnHeader.Cells.Get(1, 21).Value = "C Move";
            this.spdLotList_Sheet1.ColumnHeader.Cells.Get(1, 22).Value = "C Old";
            this.spdLotList_Sheet1.ColumnHeader.Cells.Get(1, 23).Value = "C New";
            this.spdLotList_Sheet1.ColumnHeader.Cells.Get(1, 24).Value = "P Move";
            this.spdLotList_Sheet1.ColumnHeader.Cells.Get(1, 25).Value = "P Old";
            this.spdLotList_Sheet1.ColumnHeader.Cells.Get(1, 26).Value = "P New";
            this.spdLotList_Sheet1.ColumnHeader.Cells.Get(1, 27).Value = "C Move";
            this.spdLotList_Sheet1.ColumnHeader.Cells.Get(1, 28).Value = "C Old";
            this.spdLotList_Sheet1.ColumnHeader.Cells.Get(1, 29).Value = "C New";
            this.spdLotList_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdLotList_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdLotList_Sheet1.ColumnHeader.Rows.Get(0).Height = 17F;
            this.spdLotList_Sheet1.ColumnHeader.Rows.Get(1).Height = 17F;
            this.spdLotList_Sheet1.Columns.Get(0).BackColor = System.Drawing.Color.LightGray;
            this.spdLotList_Sheet1.Columns.Get(0).Border = bevelBorder1;
            this.spdLotList_Sheet1.Columns.Get(0).Locked = true;
            this.spdLotList_Sheet1.Columns.Get(0).Width = 22F;
            this.spdLotList_Sheet1.Columns.Get(1).BackColor = System.Drawing.Color.LightGray;
            this.spdLotList_Sheet1.Columns.Get(1).Border = bevelBorder2;
            this.spdLotList_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotList_Sheet1.Columns.Get(1).Locked = true;
            this.spdLotList_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLotList_Sheet1.Columns.Get(1).Width = 57F;
            this.spdLotList_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotList_Sheet1.Columns.Get(2).Locked = true;
            this.spdLotList_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLotList_Sheet1.Columns.Get(2).Width = 130F;
            this.spdLotList_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotList_Sheet1.Columns.Get(3).Locked = true;
            this.spdLotList_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLotList_Sheet1.Columns.Get(3).Width = 82F;
            this.spdLotList_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotList_Sheet1.Columns.Get(4).Locked = true;
            this.spdLotList_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLotList_Sheet1.Columns.Get(4).Width = 120F;
            this.spdLotList_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotList_Sheet1.Columns.Get(5).Locked = true;
            this.spdLotList_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLotList_Sheet1.Columns.Get(5).Width = 120F;
            this.spdLotList_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdLotList_Sheet1.Columns.Get(6).Locked = true;
            this.spdLotList_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLotList_Sheet1.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotList_Sheet1.Columns.Get(7).Locked = true;
            this.spdLotList_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLotList_Sheet1.Columns.Get(7).Width = 100F;
            this.spdLotList_Sheet1.Columns.Get(8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdLotList_Sheet1.Columns.Get(8).Locked = true;
            this.spdLotList_Sheet1.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLotList_Sheet1.Columns.Get(9).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotList_Sheet1.Columns.Get(9).Locked = true;
            this.spdLotList_Sheet1.Columns.Get(9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLotList_Sheet1.Columns.Get(9).Width = 82F;
            this.spdLotList_Sheet1.Columns.Get(10).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotList_Sheet1.Columns.Get(10).Locked = true;
            this.spdLotList_Sheet1.Columns.Get(10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLotList_Sheet1.Columns.Get(10).Width = 120F;
            this.spdLotList_Sheet1.Columns.Get(11).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdLotList_Sheet1.Columns.Get(11).Label = "Mat Ver";
            this.spdLotList_Sheet1.Columns.Get(11).Locked = true;
            this.spdLotList_Sheet1.Columns.Get(11).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLotList_Sheet1.Columns.Get(12).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdLotList_Sheet1.Columns.Get(12).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdLotList_Sheet1.Columns.Get(12).Label = "P Move";
            this.spdLotList_Sheet1.Columns.Get(12).Locked = true;
            this.spdLotList_Sheet1.Columns.Get(12).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLotList_Sheet1.Columns.Get(13).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdLotList_Sheet1.Columns.Get(13).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdLotList_Sheet1.Columns.Get(13).Label = "P Old";
            this.spdLotList_Sheet1.Columns.Get(13).Locked = true;
            this.spdLotList_Sheet1.Columns.Get(13).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLotList_Sheet1.Columns.Get(14).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdLotList_Sheet1.Columns.Get(14).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdLotList_Sheet1.Columns.Get(14).Label = "P New";
            this.spdLotList_Sheet1.Columns.Get(14).Locked = true;
            this.spdLotList_Sheet1.Columns.Get(14).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLotList_Sheet1.Columns.Get(15).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdLotList_Sheet1.Columns.Get(15).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdLotList_Sheet1.Columns.Get(15).Label = "C Move";
            this.spdLotList_Sheet1.Columns.Get(15).Locked = true;
            this.spdLotList_Sheet1.Columns.Get(15).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLotList_Sheet1.Columns.Get(16).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdLotList_Sheet1.Columns.Get(16).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdLotList_Sheet1.Columns.Get(16).Label = "C Old";
            this.spdLotList_Sheet1.Columns.Get(16).Locked = true;
            this.spdLotList_Sheet1.Columns.Get(16).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLotList_Sheet1.Columns.Get(17).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdLotList_Sheet1.Columns.Get(17).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdLotList_Sheet1.Columns.Get(17).Label = "C New";
            this.spdLotList_Sheet1.Columns.Get(17).Locked = true;
            this.spdLotList_Sheet1.Columns.Get(17).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLotList_Sheet1.Columns.Get(18).BackColor = System.Drawing.Color.LightYellow;
            this.spdLotList_Sheet1.Columns.Get(18).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdLotList_Sheet1.Columns.Get(18).Label = "P Move";
            this.spdLotList_Sheet1.Columns.Get(18).Locked = true;
            this.spdLotList_Sheet1.Columns.Get(18).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLotList_Sheet1.Columns.Get(19).BackColor = System.Drawing.Color.LightYellow;
            this.spdLotList_Sheet1.Columns.Get(19).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdLotList_Sheet1.Columns.Get(19).Label = "P Old";
            this.spdLotList_Sheet1.Columns.Get(19).Locked = true;
            this.spdLotList_Sheet1.Columns.Get(19).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLotList_Sheet1.Columns.Get(20).BackColor = System.Drawing.Color.LightYellow;
            this.spdLotList_Sheet1.Columns.Get(20).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdLotList_Sheet1.Columns.Get(20).Label = "P New";
            this.spdLotList_Sheet1.Columns.Get(20).Locked = true;
            this.spdLotList_Sheet1.Columns.Get(20).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLotList_Sheet1.Columns.Get(21).BackColor = System.Drawing.Color.LightYellow;
            this.spdLotList_Sheet1.Columns.Get(21).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdLotList_Sheet1.Columns.Get(21).Label = "C Move";
            this.spdLotList_Sheet1.Columns.Get(21).Locked = true;
            this.spdLotList_Sheet1.Columns.Get(21).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLotList_Sheet1.Columns.Get(22).BackColor = System.Drawing.Color.LightYellow;
            this.spdLotList_Sheet1.Columns.Get(22).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdLotList_Sheet1.Columns.Get(22).Label = "C Old";
            this.spdLotList_Sheet1.Columns.Get(22).Locked = true;
            this.spdLotList_Sheet1.Columns.Get(22).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLotList_Sheet1.Columns.Get(23).BackColor = System.Drawing.Color.LightYellow;
            this.spdLotList_Sheet1.Columns.Get(23).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdLotList_Sheet1.Columns.Get(23).Label = "C New";
            this.spdLotList_Sheet1.Columns.Get(23).Locked = true;
            this.spdLotList_Sheet1.Columns.Get(23).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLotList_Sheet1.Columns.Get(24).BackColor = System.Drawing.Color.Honeydew;
            this.spdLotList_Sheet1.Columns.Get(24).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdLotList_Sheet1.Columns.Get(24).Label = "P Move";
            this.spdLotList_Sheet1.Columns.Get(24).Locked = true;
            this.spdLotList_Sheet1.Columns.Get(24).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLotList_Sheet1.Columns.Get(25).BackColor = System.Drawing.Color.Honeydew;
            this.spdLotList_Sheet1.Columns.Get(25).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdLotList_Sheet1.Columns.Get(25).Label = "P Old";
            this.spdLotList_Sheet1.Columns.Get(25).Locked = true;
            this.spdLotList_Sheet1.Columns.Get(25).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLotList_Sheet1.Columns.Get(26).BackColor = System.Drawing.Color.Honeydew;
            this.spdLotList_Sheet1.Columns.Get(26).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdLotList_Sheet1.Columns.Get(26).Label = "P New";
            this.spdLotList_Sheet1.Columns.Get(26).Locked = true;
            this.spdLotList_Sheet1.Columns.Get(26).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLotList_Sheet1.Columns.Get(27).BackColor = System.Drawing.Color.Honeydew;
            this.spdLotList_Sheet1.Columns.Get(27).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdLotList_Sheet1.Columns.Get(27).Label = "C Move";
            this.spdLotList_Sheet1.Columns.Get(27).Locked = true;
            this.spdLotList_Sheet1.Columns.Get(27).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLotList_Sheet1.Columns.Get(28).BackColor = System.Drawing.Color.Honeydew;
            this.spdLotList_Sheet1.Columns.Get(28).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdLotList_Sheet1.Columns.Get(28).Label = "C Old";
            this.spdLotList_Sheet1.Columns.Get(28).Locked = true;
            this.spdLotList_Sheet1.Columns.Get(28).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLotList_Sheet1.Columns.Get(29).BackColor = System.Drawing.Color.Honeydew;
            this.spdLotList_Sheet1.Columns.Get(29).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdLotList_Sheet1.Columns.Get(29).Label = "C New";
            this.spdLotList_Sheet1.Columns.Get(29).Locked = true;
            this.spdLotList_Sheet1.Columns.Get(29).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLotList_Sheet1.FrozenColumnCount = 3;
            this.spdLotList_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdLotList_Sheet1.RowHeader.Columns.Default.Resizable = true;
            this.spdLotList_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdLotList_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdLotList_Sheet1.RowHeader.Visible = false;
            this.spdLotList_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdLotList_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdLotList_Sheet1.VisualStyles = FarPoint.Win.VisualStyles.Auto;
            this.spdLotList_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // sptInfo
            // 
            this.sptInfo.Location = new System.Drawing.Point(210, 2);
            this.sptInfo.Name = "sptInfo";
            this.sptInfo.Size = new System.Drawing.Size(4, 457);
            this.sptInfo.TabIndex = 1;
            this.sptInfo.TabStop = false;
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
            // ctxLotTrace
            // 
            this.ctxLotTrace.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuPtoC,
            this.mnuCtoP,
            this.mnuLotStatus,
            this.mnuLotHistory});
            // 
            // mnuPtoC
            // 
            this.mnuPtoC.Index = 0;
            this.mnuPtoC.Text = "Parent -> Child";
            this.mnuPtoC.Click += new System.EventHandler(this.mnuPtoC_Click);
            // 
            // mnuCtoP
            // 
            this.mnuCtoP.Index = 1;
            this.mnuCtoP.Text = "Child -> Parent";
            this.mnuCtoP.Click += new System.EventHandler(this.mnuCtoP_Click);
            // 
            // mnuLotStatus
            // 
            this.mnuLotStatus.Index = 2;
            this.mnuLotStatus.Tag = "WIP3001";
            this.mnuLotStatus.Text = "View Lot Status";
            this.mnuLotStatus.Click += new System.EventHandler(this.mnuSubMenu_Click);
            // 
            // mnuLotHistory
            // 
            this.mnuLotHistory.Index = 3;
            this.mnuLotHistory.Tag = "WIP3002";
            this.mnuLotHistory.Text = "View Lot History";
            this.mnuLotHistory.Click += new System.EventHandler(this.mnuSubMenu_Click);
            // 
            // frmWIPViewLotTrace
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Name = "frmWIPViewLotTrace";
            this.Text = "View Lot Trace";
            this.Activated += new System.EventHandler(this.frmWIPViewLotTrace_Activated);
            this.Load += new System.EventHandler(this.frmWIPViewLotTrace_Load);
            this.pnlViewTop.ResumeLayout(false);
            this.grpOption.ResumeLayout(false);
            this.grpOption.PerformLayout();
            this.pnlViewMid.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlInfoLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdOperLotList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdOperLotList_Sheet1)).EndInit();
            this.pnlInfoMid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdLotList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdLotList_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Constant Definition "
        
        private const int COL_ICON = 0;
        private const int COL_LEVEL = 1;
        private const int COL_LOT_ID = 2;
        private const int COL_TRAN_CODE = 3;
        private const int COL_TRAN_TIME = 4;
        private const int COL_MAT_ID = 5;
        private const int COL_MAT_VER = 6;
        private const int COL_FLOW = 7;
        private const int COL_FLOW_SEQ = 8;
        private const int COL_OPER = 9;
        private const int COL_C_MAT_ID = 10;
        private const int COL_C_MAT_VER = 11;
        private const int COL_M_M_QTY_1 = 12;
        private const int COL_M_O_QTY_1 = 13;
        private const int COL_M_N_QTY_1 = 14;
        private const int COL_C_M_QTY_1 = 15;
        private const int COL_C_O_QTY_1 = 16;
        private const int COL_C_N_QTY_1 = 17;
        private const int COL_M_M_QTY_2 = 18;
        private const int COL_M_O_QTY_2 = 19;
        private const int COL_M_N_QTY_2 = 20;
        private const int COL_C_M_QTY_2 = 21;
        private const int COL_C_O_QTY_2 = 22;
        private const int COL_C_N_QTY_2 = 23;
        private const int COL_M_M_QTY_3 = 24;
        private const int COL_M_O_QTY_3 = 25;
        private const int COL_M_N_QTY_3 = 26;
        private const int COL_C_M_QTY_3 = 27;
        private const int COL_C_O_QTY_3 = 28;
        private const int COL_C_N_QTY_3 = 29;
        
        private const string ROOT_SYMBOL = "*";
        
        #endregion
        
        #region " Variable Definition "
        
        private bool b_load_flag;
        
        private FarPoint.Win.Spread.CellType.GeneralCellType plusCellType = new FarPoint.Win.Spread.CellType.GeneralCellType();
        private FarPoint.Win.Spread.CellType.GeneralCellType minusCellType = new FarPoint.Win.Spread.CellType.GeneralCellType();
        private FarPoint.Win.Spread.CellType.GeneralCellType emptyCellType = new FarPoint.Win.Spread.CellType.GeneralCellType();
        private FarPoint.Win.Spread.CellType.GeneralCellType checkCellType = new FarPoint.Win.Spread.CellType.GeneralCellType();
        
        private enum CELL_STATUS
        {
            PLUS = 1,
            MINUS = 2,
            EMPTY = 3,
            CHECK = 4
        }
        
        private enum OWNER_RBUTTON
        {
            TRACE_SPD = 1,
            OPER_SPD = 2
        }
        
        private OWNER_RBUTTON iOwnerRightButton;
        
        #endregion
        
        #region " Function Definition "
        
        // View_Lot_Trace()
        //       - View Lot Trace History
        // Return Value
        //       - Boolean : True / False
        // Arguments
        //        - ByVal sLotID As String : Trace Lot id
        //       - ByVal sFromToFlag As String : From To Flag of Lot Id
        //       - ByVal sParent As String : Parent Node of Lot Id
        //
        private bool View_Lot_Trace(string sLotID, char sFromToFlag, string sParent)
        {
            TRSNode in_node = new TRSNode("VIEW_LOT_TRACE_IN");
            TRSNode out_node = new TRSNode("VIEW_LOT_TRACE_OUT");
            int i;
            int iFind;

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("LOT_ID", MPCF.Trim(sLotID));
            in_node.AddChar("FROM_TO_FLAG", sFromToFlag);
            in_node.AddInt("NEXT_HIST_SEQ", int.MaxValue);

            do
            {
                if (MPCR.CallService("WIP", "WIP_View_Lot_Trace", in_node, ref out_node) == false)
                {
                    return false;
                }
                
                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    iFind = FindLot(sLotID);
                    if (iFind >= 0)
                    {
                        spdLotList.Sheets[0].Cells[iFind, COL_ICON].CellType = minusCellType;
                        spdLotList.Sheets[0].Cells[iFind, COL_ICON].Tag = CELL_STATUS.MINUS;

                        iFind = FindLot(out_node.GetList(0)[i].GetString("CHILD_LOT_ID"));
                        if (iFind >= 0)
                        {
                            spdLotList.Sheets[0].Cells[iFind, COL_LOT_ID].Font = new Font(spdLotList.Font.Name, spdLotList.Font.Size, FontStyle.Bold);
                            SetData(out_node.GetList(0)[i], true);
                        }
                        else
                        {
                            SetData(out_node.GetList(0)[i], false);

                            if (View_Lot_Trace(out_node.GetList(0)[i].GetString("CHILD_LOT_ID"), sFromToFlag, out_node.GetList(0)[i].GetString("LOT_ID")) == false)
                            {
                                return false;
                            }
                        }
                        
                    }
                    else
                    {
                        AddLot(sLotID, "");
                        SetData(out_node.GetList(0)[i], false);

                        if (View_Lot_Trace(out_node.GetList(0)[i].GetString("CHILD_LOT_ID"), sFromToFlag, out_node.GetList(0)[i].GetString("LOT_ID")) == false)
                        {
                            return false;
                        }
                        sParent = sLotID;
                    }
                    
                }

                in_node.SetInt("NEXT_HIST_SEQ", out_node.GetInt("NEXT_HIST_SEQ"));
            } while (in_node.GetInt("NEXT_HIST_SEQ") > 0);

            //Add by J.S. 2011.10.12 for good view
            MPCF.FitColumnHeader(spdOperLotList);
            MPCF.FitColumnHeader(spdLotList);

            return true;
            
        }
        
        // SetData()
        //       - Set Trace Data into spdLotHistory
        // Return Value
        //       -
        // Arguments
        //        - ByVal lot_list As MPMAS_WIP_View_Lot_Trace_out_tag_list : Trace Lot information
        //       - Optional ByVal bDup As Boolean = False : When Duplicate Lot Id, Lot Id is under line
        //
        private void SetData(TRSNode lot_out, bool bDup)
        {
            int iAddIdx;
            iAddIdx = AddLot(lot_out.GetString("CHILD_LOT_ID"), lot_out.GetString("LOT_ID"));

            spdLotList.Sheets[0].Cells[iAddIdx, COL_TRAN_TIME].Value = MPCF.MakeDateFormat(lot_out.GetString("TRAN_TIME"));
            spdLotList.Sheets[0].Cells[iAddIdx, COL_TRAN_CODE].Value = lot_out.GetString("TRAN_CODE");


            if (lot_out.GetChar("FROM_TO_FLAG") == 'F')
            {
                spdLotList.Sheets[0].Cells[iAddIdx, COL_MAT_ID].Value = lot_out.GetString("MAT_ID");
                spdLotList.Sheets[0].Cells[iAddIdx, COL_MAT_VER].Value = lot_out.GetInt("MAT_VER");
                spdLotList.Sheets[0].Cells[iAddIdx, COL_FLOW].Value = lot_out.GetString("FLOW");
                spdLotList.Sheets[0].Cells[iAddIdx, COL_FLOW_SEQ].Value = lot_out.GetInt("FLOW_SEQ_NUM");
                spdLotList.Sheets[0].Cells[iAddIdx, COL_OPER].Value = lot_out.GetString("OPER");
                spdLotList.Sheets[0].Cells[iAddIdx, COL_C_MAT_ID].Value = lot_out.GetString("CHILD_MAT_ID");
                spdLotList.Sheets[0].Cells[iAddIdx, COL_C_MAT_VER].Value = lot_out.GetInt("CHILD_MAT_VER");
                spdLotList.Sheets[0].Cells[iAddIdx, COL_M_M_QTY_1].Value = lot_out.GetDouble("MOVE_QTY_1");
                spdLotList.Sheets[0].Cells[iAddIdx, COL_M_O_QTY_1].Value = lot_out.GetDouble("OLD_QTY_1");
                spdLotList.Sheets[0].Cells[iAddIdx, COL_M_N_QTY_1].Value = lot_out.GetDouble("QTY_1");
                spdLotList.Sheets[0].Cells[iAddIdx, COL_C_M_QTY_1].Value = lot_out.GetDouble("CHILD_MOVE_QTY_1");
                spdLotList.Sheets[0].Cells[iAddIdx, COL_C_O_QTY_1].Value = lot_out.GetDouble("CHILD_OLD_QTY_1");
                spdLotList.Sheets[0].Cells[iAddIdx, COL_C_N_QTY_1].Value = lot_out.GetDouble("CHILD_QTY_1");
                spdLotList.Sheets[0].Cells[iAddIdx, COL_M_M_QTY_2].Value = lot_out.GetDouble("MOVE_QTY_2");
                spdLotList.Sheets[0].Cells[iAddIdx, COL_M_O_QTY_2].Value = lot_out.GetDouble("OLD_QTY_2");
                spdLotList.Sheets[0].Cells[iAddIdx, COL_M_N_QTY_2].Value = lot_out.GetDouble("QTY_2");
                spdLotList.Sheets[0].Cells[iAddIdx, COL_C_M_QTY_2].Value = lot_out.GetDouble("CHILD_MOVE_QTY_2");
                spdLotList.Sheets[0].Cells[iAddIdx, COL_C_O_QTY_2].Value = lot_out.GetDouble("CHILD_OLD_QTY_2");
                spdLotList.Sheets[0].Cells[iAddIdx, COL_C_N_QTY_2].Value = lot_out.GetDouble("CHILD_QTY_2");
                spdLotList.Sheets[0].Cells[iAddIdx, COL_M_M_QTY_3].Value = lot_out.GetDouble("MOVE_QTY_3");
                spdLotList.Sheets[0].Cells[iAddIdx, COL_M_O_QTY_3].Value = lot_out.GetDouble("OLD_QTY_3");
                spdLotList.Sheets[0].Cells[iAddIdx, COL_M_N_QTY_3].Value = lot_out.GetDouble("QTY_3");
                spdLotList.Sheets[0].Cells[iAddIdx, COL_C_M_QTY_3].Value = lot_out.GetDouble("CHILD_MOVE_QTY_3");
                spdLotList.Sheets[0].Cells[iAddIdx, COL_C_O_QTY_3].Value = lot_out.GetDouble("CHILD_OLD_QTY_3");
                spdLotList.Sheets[0].Cells[iAddIdx, COL_C_N_QTY_3].Value = lot_out.GetDouble("CHILD_QTY_3");
            }
            else
            {
                spdLotList.Sheets[0].Cells[iAddIdx, COL_MAT_ID].Value = lot_out.GetString("CHILD_MAT_ID");
                spdLotList.Sheets[0].Cells[iAddIdx, COL_MAT_VER].Value = lot_out.GetInt("CHILD_MAT_VER");
                spdLotList.Sheets[0].Cells[iAddIdx, COL_FLOW].Value = lot_out.GetString("CHILD_FLOW");
                spdLotList.Sheets[0].Cells[iAddIdx, COL_FLOW_SEQ].Value = lot_out.GetInt("CHILD_FLOW_SEQ_NUM");
                spdLotList.Sheets[0].Cells[iAddIdx, COL_OPER].Value = lot_out.GetString("CHILD_OPER");
                spdLotList.Sheets[0].Cells[iAddIdx, COL_C_MAT_ID].Value = lot_out.GetString("MAT_ID");
                spdLotList.Sheets[0].Cells[iAddIdx, COL_C_MAT_VER].Value = lot_out.GetInt("MAT_VER");
                spdLotList.Sheets[0].Cells[iAddIdx, COL_M_M_QTY_1].Value = lot_out.GetDouble("CHILD_MOVE_QTY_1");
                spdLotList.Sheets[0].Cells[iAddIdx, COL_M_O_QTY_1].Value = lot_out.GetDouble("CHILD_OLD_QTY_1");
                spdLotList.Sheets[0].Cells[iAddIdx, COL_M_N_QTY_1].Value = lot_out.GetDouble("CHILD_QTY_1");
                spdLotList.Sheets[0].Cells[iAddIdx, COL_C_M_QTY_1].Value = lot_out.GetDouble("MOVE_QTY_1");
                spdLotList.Sheets[0].Cells[iAddIdx, COL_C_O_QTY_1].Value = lot_out.GetDouble("OLD_QTY_1");
                spdLotList.Sheets[0].Cells[iAddIdx, COL_C_N_QTY_1].Value = lot_out.GetDouble("QTY_1");
                spdLotList.Sheets[0].Cells[iAddIdx, COL_M_M_QTY_2].Value = lot_out.GetDouble("CHILD_MOVE_QTY_2");
                spdLotList.Sheets[0].Cells[iAddIdx, COL_M_O_QTY_2].Value = lot_out.GetDouble("CHILD_OLD_QTY_2");
                spdLotList.Sheets[0].Cells[iAddIdx, COL_M_N_QTY_2].Value = lot_out.GetDouble("CHILD_QTY_2");
                spdLotList.Sheets[0].Cells[iAddIdx, COL_C_M_QTY_2].Value = lot_out.GetDouble("MOVE_QTY_2");
                spdLotList.Sheets[0].Cells[iAddIdx, COL_C_O_QTY_2].Value = lot_out.GetDouble("OLD_QTY_2");
                spdLotList.Sheets[0].Cells[iAddIdx, COL_C_N_QTY_2].Value = lot_out.GetDouble("QTY_2");
                spdLotList.Sheets[0].Cells[iAddIdx, COL_M_M_QTY_3].Value = lot_out.GetDouble("CHILD_MOVE_QTY_3");
                spdLotList.Sheets[0].Cells[iAddIdx, COL_M_O_QTY_3].Value = lot_out.GetDouble("CHILD_OLD_QTY_3");
                spdLotList.Sheets[0].Cells[iAddIdx, COL_M_N_QTY_3].Value = lot_out.GetDouble("CHILD_QTY_3");
                spdLotList.Sheets[0].Cells[iAddIdx, COL_C_M_QTY_3].Value = lot_out.GetDouble("MOVE_QTY_3");
                spdLotList.Sheets[0].Cells[iAddIdx, COL_C_O_QTY_3].Value = lot_out.GetDouble("OLD_QTY_3");
                spdLotList.Sheets[0].Cells[iAddIdx, COL_C_N_QTY_3].Value = lot_out.GetDouble("QTY_3");
            }

            if (bDup == true)
            {
                spdLotList.Sheets[0].Cells[iAddIdx, COL_LOT_ID].Font = new Font(spdLotList.Font.Name, spdLotList.Font.Size, FontStyle.Underline);
            }
            else
            {
                spdOperLotList.Sheets[0].RowCount++;
                spdOperLotList.Sheets[0].Cells[spdOperLotList.Sheets[0].RowCount - 1, 0].Value = lot_out.GetString("CHILD_OPER");
                spdOperLotList.Sheets[0].Cells[spdOperLotList.Sheets[0].RowCount - 1, 1].Value = lot_out.GetString("CHILD_LOT_ID");
            }


            Color colorTransCode = new Color();
            switch (lot_out.GetString("TRAN_CODE").ToUpper())
            {
                case MPGC.MP_TRAN_CODE_SPLIT:

                    colorTransCode = Color.Red;
                    break;
                case MPGC.MP_TRAN_CODE_MERGE:

                    colorTransCode = Color.Blue;
                    break;
                case MPGC.MP_TRAN_CODE_COMBINE:

                    colorTransCode = Color.Black;
                    break;
            }
            spdLotList.Sheets[0].Cells[iAddIdx, COL_LOT_ID, iAddIdx, spdLotList.Sheets[0].ColumnCount - 1].ForeColor = colorTransCode;
        }


        // FindLot()
        //       - Find Lot Id Node
        // Return Value
        //       - integer : found Lot Id Node Index
        // Arguments
        //        - ByVal sLotId As String : finding Lot id
        //
        private int FindLot(string sLotId)
        {
            int i;
            
            FarPoint.Win.Spread.SheetView with_1 = spdLotList.Sheets[0];
            for (i = 0; i <= with_1.RowCount - 1; i++)
            {
                if (MPCF.Trim(with_1.Cells[i, COL_LOT_ID].Value).ToUpper() == MPCF.ToUpper( MPCF.Trim(sLotId)))
                {
                    return i;
                }
            }
            
            return - 1;
        }
        
        // FindNodeCount()
        //       - Count only Child Node of Parent Node
        // Return Value
        //       - integer : Node Count
        // Arguments
        //        - ByVal sParent As String : parent lot_id
        //
        private int FindNodeCount(string sParent)
        {
            int i;
            int iCnt;
            
            iCnt = 0;
            
            for (i = 0; i <= spdLotList.Sheets[0].RowCount - 1; i++)
            {
                if (MPCF.ToUpper(spdLotList.Sheets[0].Cells[i, COL_LOT_ID].Tag) == MPCF.ToUpper(sParent))
                {
                    iCnt++;
                }
            }
            
            return iCnt;
        }
        
        // AddLot()
        //       - Add New Lot id into spdLotList
        // Return Value
        //       - integer : Added Node index
        // Arguments
        //        - ByVal sLotId As String : Adding Lot id
        //       - ByVal sParent As String : parent Node
        //
        private int AddLot(string sLotId, string sParent)
        {
            int iNodeCnt;
            int iAddIdx;
            int iParentIdx;
            
            FarPoint.Win.Spread.SheetView with_1 = spdLotList.Sheets[0];
            if (sParent == "")
            {
                with_1.RowCount = 1;
                
                with_1.Cells[0, COL_ICON].CellType = minusCellType;
                with_1.Cells[0, COL_ICON].Tag = CELL_STATUS.MINUS;
                with_1.Cells[0, COL_LEVEL].Value = ROOT_SYMBOL;
                with_1.Cells[0, COL_LOT_ID].Value = sLotId;
                with_1.Cells[0, COL_LOT_ID].Tag = "";
                
                return 0;
            }
            
            iParentIdx = FindLot(sParent);
            iNodeCnt = FindNodeCount(sParent);
            iAddIdx = iParentIdx + iNodeCnt + 1;
            
            with_1.AddRows(iAddIdx, 1);
            with_1.Cells[iAddIdx, COL_LEVEL].Value = GetNextDepthChar(iParentIdx, iNodeCnt);
            with_1.Cells[iAddIdx, COL_LOT_ID].Value = sLotId;
            with_1.Cells[iAddIdx, COL_LOT_ID].Tag = sParent;
            
            return iAddIdx;
            
        }
        
        // FindNodeCount()
        //       - Count All Child Node of Parent Node
        // Return Value
        //       - integer : Node Count
        // Arguments
        //        - ByVal sParent As String : parent Lot id
        //       - ByVal iStart As Integer : start node index
        //       - ByVal sLevel As String : parent node Level character
        //
        private int FindNodeCount(string sParent, int iStart, string sLevel)
        {
            int i;
            int iCnt;
            
            iCnt = 0;
            
            FarPoint.Win.Spread.SheetView with_1 = spdLotList.Sheets[0];
            
            for (i = iStart; i <= with_1.RowCount - 1; i++)
            {
                if (MPCF.Trim(with_1.Cells[i, COL_LEVEL].Value).Length > sLevel.Length)
                {
                    if (MPCF.Trim(with_1.Cells[i, COL_LEVEL].Value).Substring(0, sLevel.Length) == sLevel)
                    {
                        if (MPCF.ToUpper(with_1.Cells[i, COL_LOT_ID].Tag)== MPCF.ToUpper(sParent))
                        {
                            iCnt++;
                            iCnt += FindNodeCount(MPCF.Trim(with_1.Cells[i, COL_LOT_ID].Value), i + 1, MPCF.Trim(with_1.Cells[i, COL_LEVEL].Value));
                        }
                    }
                }
            }
            
            
            return iCnt;
        }
        
        // GetNextDepthChar()
        //       - Get Level Character
        // Return Value
        //       - String : Level Char
        // Arguments
        //        - ByVal iParentIdx As Integer : parent node index
        //       - ByVal iNodeCnt As Integer : only child Node count of parent Node
        //
        private string GetNextDepthChar(int iParentIdx, int iNodeCnt)
        {
            string sNewLevel = "";
            
            if (MPCF.Trim(spdLotList.Sheets[0].Cells[iParentIdx, COL_LEVEL].Value) == ROOT_SYMBOL)
            {
                sNewLevel = MPCF.Trim(iNodeCnt + 1);
            }
            else
            {
                sNewLevel = MPCF.Trim(spdLotList.Sheets[0].Cells[iParentIdx, COL_LEVEL].Value) + "." + MPCF.Trim(iNodeCnt + 1);
            }
            
            return sNewLevel;
        }
        
        public void ActiveFormNow()
        {
            if (MPCF.Trim(MPGV.gsCurrentLot_ID) != "")
            {
                txtLotID.Text = MPGV.gsCurrentLot_ID;
                btnView_Click(btnView, null);
            }
        }
        
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
        
        private void frmWIPViewLotTrace_Load(object sender, System.EventArgs e)
        {
            
            plusCellType.BackgroundImage = new FarPoint.Win.Picture(imlSPIcons.Images[MPCF.ToInt(CELL_STATUS.PLUS) - 1], FarPoint.Win.RenderStyle.Normal, Color.White, FarPoint.Win.HorizontalAlignment.Center, FarPoint.Win.VerticalAlignment.Center);
            minusCellType.BackgroundImage = new FarPoint.Win.Picture(imlSPIcons.Images[MPCF.ToInt(CELL_STATUS.MINUS) - 1], FarPoint.Win.RenderStyle.Normal, Color.White, FarPoint.Win.HorizontalAlignment.Center, FarPoint.Win.VerticalAlignment.Center);
            emptyCellType.BackgroundImage = new FarPoint.Win.Picture(imlSPIcons.Images[MPCF.ToInt(CELL_STATUS.EMPTY) - 1], FarPoint.Win.RenderStyle.Normal, Color.White, FarPoint.Win.HorizontalAlignment.Center, FarPoint.Win.VerticalAlignment.Center);
            checkCellType.BackgroundImage = new FarPoint.Win.Picture(imlSPIcons.Images[MPCF.ToInt(CELL_STATUS.CHECK) - 1], FarPoint.Win.RenderStyle.Normal, Color.White, FarPoint.Win.HorizontalAlignment.Right, FarPoint.Win.VerticalAlignment.Center);
            
        }
        
        private void frmWIPViewLotTrace_Activated(object sender, System.EventArgs e)
        {
            
            if (b_load_flag == false)
            {
                MPCF.FieldClear(this);
                MPCF.ClearList(spdOperLotList, true);
                MPCF.ClearList(spdLotList, true);
                rbnPtoC.Checked = false;
                rbnCtoP.Checked = true;

                ActiveFormNow();
                
                b_load_flag = true;
            }
        }
        
        private void btnView_Click(System.Object sender, System.EventArgs e)
        {
            
            if (txtLotID.Text != "")
            {
                MPCF.ClearList(spdLotList, true);
                MPCF.ClearList(spdOperLotList, true);
                if (View_Lot_Trace(txtLotID.Text, (rbnCtoP.Checked == true ? 'T' : 'F'), "") == false)
                {
                    return;
                }
                if (spdLotList.Sheets[0].RowCount > 0)
                {
                    spdLotList.Sheets[0].SortRows(COL_LEVEL, true, false);
                    spdOperLotList.Sheets[0].SortRows(0, true, false);
                }
            }
            
        }
        
        private void spdLotList_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            int i;
            string sClickLevel;
            
            if (e.ColumnHeader == true)
            {
                return;
            }
            if (e.RowHeader == true)
            {
                return;
            }
            
            if (e.Column != COL_ICON)
            {
                return;
            }
            
            FarPoint.Win.Spread.SheetView with_1 = spdLotList.Sheets[0];
            sClickLevel = MPCF.Trim(with_1.Cells[e.Row, COL_LEVEL].Value);
            
            if (MPCF.Trim(with_1.Cells[e.Row, COL_ICON].Tag) == "")
            {
                return;
            }
            
            if (sClickLevel == ROOT_SYMBOL)
            {
                sClickLevel = "";
            }
            
            for (i = e.Row + 1; i <= with_1.RowCount - 1; i++)
            {
                if (with_1.Cells[i, COL_LEVEL].Value.ToString().Length > sClickLevel.Length)
                {
                    if (MPCF.Trim(with_1.Cells[i, COL_LEVEL].Value).Substring(0, sClickLevel.Length) == sClickLevel)
                    {
                        
                        if (MPCF.ToInt(with_1.Cells[e.Row, COL_ICON].Tag) == (int)CELL_STATUS.MINUS)
                        {
                            with_1.Rows[i].Visible = false;
                        }
                        else
                        {
                            with_1.Rows[i].Visible = true;
                        }
                        
                        if (MPCF.ToInt(with_1.Cells[i, COL_ICON].Tag) == (int)CELL_STATUS.PLUS)
                        {
                            i += FindNodeCount(MPCF.Trim(with_1.Cells[i, COL_LOT_ID].Value), i + 1, MPCF.Trim(with_1.Cells[i, COL_LEVEL].Value));
                        }
                        
                    }
                }
            }
            
            if (MPCF.ToInt(with_1.Cells[e.Row, COL_ICON].Tag) == (int)CELL_STATUS.MINUS)
            {
                with_1.Cells[e.Row, COL_ICON].CellType = plusCellType;
                with_1.Cells[e.Row, COL_ICON].Tag = CELL_STATUS.PLUS;
            }
            else if (MPCF.ToInt(with_1.Cells[e.Row, COL_ICON].Tag) == (int)CELL_STATUS.PLUS)
            {
                with_1.Cells[e.Row, COL_ICON].CellType = minusCellType;
                with_1.Cells[e.Row, COL_ICON].Tag = CELL_STATUS.MINUS;
            }
            
        }
        
        private void spdLotList_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                iOwnerRightButton = OWNER_RBUTTON.TRACE_SPD;
                ctxLotTrace.Show(spdLotList, new Point(e.X, e.Y));
            }
            else if (e.Button == System.Windows.Forms.MouseButtons.Left && e.Clicks >= 2)
            {
                if (spdLotList.Sheets[0].ActiveRowIndex < 1)
                {
                    return;
                }
                if (spdLotList.Sheets[0].ActiveColumnIndex != COL_LOT_ID)
                {
                    return;
                }
                txtLotID.Text = MPCF.Trim(spdLotList.Sheets[0].Cells[spdLotList.Sheets[0].ActiveRowIndex, COL_LOT_ID].Value);
                btnView_Click(btnView, e);
            }
            
        }
        
        private void spdOperLotList_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                iOwnerRightButton = OWNER_RBUTTON.OPER_SPD;
                ctxLotTrace.Show(spdOperLotList, new Point(e.X, e.Y));
            }
            else if (e.Button == System.Windows.Forms.MouseButtons.Left && e.Clicks >= 2)
            {
                if (spdOperLotList.Sheets[0].ActiveRowIndex < 0)
                {
                    return;
                }
                if (spdOperLotList.Sheets[0].RowCount <= 0)
                {
                    return;
                }

                txtLotID.Text = MPCF.Trim(spdOperLotList.Sheets[0].Cells[spdOperLotList.Sheets[0].ActiveRowIndex, 1].Value);
                btnView_Click(btnView, e);
            }
            
        }
        
        private void mnuCtoP_Click(object sender, System.EventArgs e)
        {
            FarPoint.Win.Spread.SheetView spd = null;
            int iCol = 0;
            try
            {
                
                rbnCtoP.Checked = true;
                if (iOwnerRightButton == OWNER_RBUTTON.TRACE_SPD)
                {
                    iCol = COL_LOT_ID;
                    spd = spdLotList.Sheets[0];
                }
                else if (iOwnerRightButton == OWNER_RBUTTON.OPER_SPD)
                {
                    iCol = 1;
                    spd = spdOperLotList.Sheets[0];
                }

                if (spd.RowCount < 1) return;

                txtLotID.Text = MPCF.Trim(spd.Cells[spd.ActiveRowIndex, iCol].Value);
                btnView_Click(btnView, e);
                
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void mnuPtoC_Click(object sender, System.EventArgs e)
        {
            FarPoint.Win.Spread.SheetView spd = null;
            int iCol = 0;

            try
            {
                rbnPtoC.Checked = true;
                if (iOwnerRightButton == OWNER_RBUTTON.TRACE_SPD)
                {
                    iCol = COL_LOT_ID;
                    spd = spdLotList.Sheets[0];
                }
                else if (iOwnerRightButton == OWNER_RBUTTON.OPER_SPD)
                {
                    iCol = 1;
                    spd = spdOperLotList.Sheets[0];
                }
                
                if (spd.RowCount < 1) return;

                txtLotID.Text = MPCF.Trim(spd.Cells[spd.ActiveRowIndex, iCol].Value);
                btnView_Click(btnView, e);
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        
        private void mnuSubMenu_Click(System.Object sender, System.EventArgs e)
        {
            FarPoint.Win.Spread.SheetView spd = null;
            int iCol = 0;
            string s_func_name;
            
            try
            {
                if (((MenuItem)sender).Tag == null) return;
                if (MPCF.Trim(((MenuItem)sender).Tag) == "") return;
                
                if (iOwnerRightButton == OWNER_RBUTTON.TRACE_SPD)
                {
                    iCol = COL_LOT_ID;
                    spd = spdLotList.Sheets[0];
                }
                else if (iOwnerRightButton == OWNER_RBUTTON.OPER_SPD)
                {
                    iCol = 1;
                    spd = spdOperLotList.Sheets[0];
                }
                
                if (spd.RowCount < 1) return;

                MPGV.gsCurrentLot_ID = MPCF.Trim(spd.Cells[spd.ActiveRowIndex, iCol].Value);

                s_func_name = MPCF.Trim(((MenuItem)sender).Tag);
                MPGV.gIMdiForm.ActiveMenu(s_func_name);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        
        private void btnExcel_Click(System.Object sender, System.EventArgs e)
        {
            string sCond;
            
            sCond = "Lot ID : " + txtLotID.Text + "\r";
            sCond = sCond + "Direction : ";
            if (rbnCtoP.Checked == true)
            {
                sCond = sCond + "Child -> Parent";
            }
            else
            {
                sCond = sCond + "Parent -> Child";
            }

            if (MPCF.ExportToExcel(spdLotList, this.Text, sCond, true, true, true, -1, -1) == false)
            {
                return;
            }
            
            
        }
        
    }
}
