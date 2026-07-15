
//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmWIPViewReturnLotList.vb
//   Description : View Return Lot List
//
//   MES Version : 4.1.0.0
//
//   Function List
//
//   Detail Description
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2004-08-13 : Created by H.K.KIM
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
using Miracom.UI;
using Miracom.TRSCore;



namespace Miracom.WIPCore
{
    public class frmWIPViewReturnLotList : Miracom.MESCore.ViewForm01
    {
        
        #region " Windows Form auto generated code "
        
        public frmWIPViewReturnLotList()
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
        



        private System.Windows.Forms.Panel pnlPeriod;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label lblPeriod;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Label lblRMAStatus;
        private System.Windows.Forms.ComboBox cboRMAStatus;
        private System.Windows.Forms.Button btnOpen;
        private FarPoint.Win.Spread.FpSpread spdRMA;
        private FarPoint.Win.Spread.SheetView spdRMA_Sheet1;
        private Miracom.MESCore.Controls.udcMaterial cdvMaterial;
        private System.Windows.Forms.Button btnCloseLot;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            this.pnlPeriod = new System.Windows.Forms.Panel();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.lblPeriod = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.lblRMAStatus = new System.Windows.Forms.Label();
            this.cboRMAStatus = new System.Windows.Forms.ComboBox();
            this.btnCloseLot = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.spdRMA = new FarPoint.Win.Spread.FpSpread();
            this.spdRMA_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.cdvMaterial = new Miracom.MESCore.Controls.udcMaterial();
            this.pnlViewTop.SuspendLayout();
            this.grpOption.SuspendLayout();
            this.pnlViewMid.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlPeriod.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdRMA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdRMA_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(374, 8);
            this.btnView.TabIndex = 0;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.TabIndex = 4;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // pnlViewTop
            // 
            this.pnlViewTop.Size = new System.Drawing.Size(742, 73);
            // 
            // grpOption
            // 
            this.grpOption.Controls.Add(this.cdvMaterial);
            this.grpOption.Controls.Add(this.cboRMAStatus);
            this.grpOption.Controls.Add(this.lblRMAStatus);
            this.grpOption.Controls.Add(this.pnlPeriod);
            this.grpOption.Size = new System.Drawing.Size(742, 73);
            // 
            // pnlViewMid
            // 
            this.pnlViewMid.Controls.Add(this.spdRMA);
            this.pnlViewMid.Location = new System.Drawing.Point(0, 73);
            this.pnlViewMid.Padding = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.pnlViewMid.Size = new System.Drawing.Size(742, 440);
            this.pnlViewMid.TabIndex = 2;
            // 
            // btnClose
            // 
            this.btnClose.TabIndex = 3;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnOpen);
            this.pnlBottom.Controls.Add(this.btnCloseLot);
            this.pnlBottom.Controls.SetChildIndex(this.btnView, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnCloseLot, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnClose, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnExcel, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnOpen, 0);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "View Return Lot List";
            // 
            // pnlPeriod
            // 
            this.pnlPeriod.Controls.Add(this.dtpFrom);
            this.pnlPeriod.Controls.Add(this.lblPeriod);
            this.pnlPeriod.Controls.Add(this.dtpTo);
            this.pnlPeriod.Controls.Add(this.lblTo);
            this.pnlPeriod.Location = new System.Drawing.Point(470, 16);
            this.pnlPeriod.Name = "pnlPeriod";
            this.pnlPeriod.Size = new System.Drawing.Size(257, 20);
            this.pnlPeriod.TabIndex = 4;
            // 
            // dtpFrom
            // 
            this.dtpFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(56, 0);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(90, 20);
            this.dtpFrom.TabIndex = 2;
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
            // lblRMAStatus
            // 
            this.lblRMAStatus.AutoSize = true;
            this.lblRMAStatus.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblRMAStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRMAStatus.Location = new System.Drawing.Point(12, 43);
            this.lblRMAStatus.Name = "lblRMAStatus";
            this.lblRMAStatus.Size = new System.Drawing.Size(37, 13);
            this.lblRMAStatus.TabIndex = 2;
            this.lblRMAStatus.Text = "Status";
            this.lblRMAStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboRMAStatus
            // 
            this.cboRMAStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRMAStatus.Items.AddRange(new object[] {
            "",
            "Open",
            "Close"});
            this.cboRMAStatus.Location = new System.Drawing.Point(120, 40);
            this.cboRMAStatus.Name = "cboRMAStatus";
            this.cboRMAStatus.Size = new System.Drawing.Size(200, 21);
            this.cboRMAStatus.TabIndex = 3;
            // 
            // btnCloseLot
            // 
            this.btnCloseLot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCloseLot.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCloseLot.Location = new System.Drawing.Point(558, 8);
            this.btnCloseLot.Name = "btnCloseLot";
            this.btnCloseLot.Size = new System.Drawing.Size(88, 26);
            this.btnCloseLot.TabIndex = 2;
            this.btnCloseLot.Text = "Close Lot";
            this.btnCloseLot.Click += new System.EventHandler(this.btnCloseLot_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpen.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnOpen.Location = new System.Drawing.Point(466, 8);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(88, 26);
            this.btnOpen.TabIndex = 1;
            this.btnOpen.Text = "Open Lot";
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // spdRMA
            // 
            this.spdRMA.AccessibleDescription = "spdRMA, Sheet1, Row 0, Column 0, ";
            this.spdRMA.BackColor = System.Drawing.SystemColors.Control;
            this.spdRMA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdRMA.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdRMA.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdRMA.HorizontalScrollBar.Name = "";
            this.spdRMA.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdRMA.HorizontalScrollBar.TabIndex = 2;
            this.spdRMA.Location = new System.Drawing.Point(3, 3);
            this.spdRMA.Name = "spdRMA";
            this.spdRMA.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdRMA.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdRMA.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdRMA_Sheet1});
            this.spdRMA.Size = new System.Drawing.Size(736, 437);
            this.spdRMA.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdRMA.TabIndex = 0;
            this.spdRMA.TabStop = false;
            this.spdRMA.TextTipDelay = 200;
            this.spdRMA.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdRMA.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdRMA.VerticalScrollBar.Name = "";
            this.spdRMA.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdRMA.VerticalScrollBar.TabIndex = 3;
            this.spdRMA.SelectionChanged += new FarPoint.Win.Spread.SelectionChangedEventHandler(this.spdRMA_SelectionChanged);
            this.spdRMA.SetViewportLeftColumn(0, 0, 2);
            this.spdRMA.SetActiveViewport(0, 0, -1);
            // 
            // spdRMA_Sheet1
            // 
            this.spdRMA_Sheet1.Reset();
            spdRMA_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdRMA_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdRMA_Sheet1.ColumnCount = 15;
            spdRMA_Sheet1.RowCount = 5;
            this.spdRMA_Sheet1.AlternatingRows.Get(1).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdRMA_Sheet1.Cells.Get(0, 0).Locked = false;
            this.spdRMA_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdRMA_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdRMA_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdRMA_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdRMA_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Work Date";
            this.spdRMA_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Lot ID";
            this.spdRMA_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Status";
            this.spdRMA_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Mat ID";
            this.spdRMA_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Mat Ver";
            this.spdRMA_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Qty";
            this.spdRMA_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Hist Exist Flag";
            this.spdRMA_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "Create Code";
            this.spdRMA_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "Create Comment";
            this.spdRMA_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "Result Code";
            this.spdRMA_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "Result Comment";
            this.spdRMA_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "Create Time";
            this.spdRMA_Sheet1.ColumnHeader.Cells.Get(0, 12).Value = "Create User ID";
            this.spdRMA_Sheet1.ColumnHeader.Cells.Get(0, 13).Value = "Result Time";
            this.spdRMA_Sheet1.ColumnHeader.Cells.Get(0, 14).Value = "Result User ID";
            this.spdRMA_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdRMA_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdRMA_Sheet1.ColumnHeader.Rows.Get(0).Height = 18F;
            this.spdRMA_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdRMA_Sheet1.Columns.Get(0).Label = "Work Date";
            this.spdRMA_Sheet1.Columns.Get(0).Locked = true;
            this.spdRMA_Sheet1.Columns.Get(0).MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Restricted;
            this.spdRMA_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdRMA_Sheet1.Columns.Get(0).Width = 75F;
            this.spdRMA_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdRMA_Sheet1.Columns.Get(1).Label = "Lot ID";
            this.spdRMA_Sheet1.Columns.Get(1).Locked = true;
            this.spdRMA_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdRMA_Sheet1.Columns.Get(1).Width = 100F;
            this.spdRMA_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdRMA_Sheet1.Columns.Get(2).Label = "Status";
            this.spdRMA_Sheet1.Columns.Get(2).Locked = true;
            this.spdRMA_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdRMA_Sheet1.Columns.Get(2).Width = 62F;
            this.spdRMA_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdRMA_Sheet1.Columns.Get(3).Label = "Mat ID";
            this.spdRMA_Sheet1.Columns.Get(3).Locked = true;
            this.spdRMA_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdRMA_Sheet1.Columns.Get(3).Width = 123F;
            this.spdRMA_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdRMA_Sheet1.Columns.Get(4).Label = "Mat Ver";
            this.spdRMA_Sheet1.Columns.Get(4).Locked = true;
            this.spdRMA_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdRMA_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdRMA_Sheet1.Columns.Get(5).Label = "Qty";
            this.spdRMA_Sheet1.Columns.Get(5).Locked = true;
            this.spdRMA_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdRMA_Sheet1.Columns.Get(5).Width = 85F;
            this.spdRMA_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdRMA_Sheet1.Columns.Get(6).Label = "Hist Exist Flag";
            this.spdRMA_Sheet1.Columns.Get(6).Locked = true;
            this.spdRMA_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdRMA_Sheet1.Columns.Get(6).Width = 82F;
            this.spdRMA_Sheet1.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdRMA_Sheet1.Columns.Get(7).Label = "Create Code";
            this.spdRMA_Sheet1.Columns.Get(7).Locked = true;
            this.spdRMA_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdRMA_Sheet1.Columns.Get(7).Width = 86F;
            this.spdRMA_Sheet1.Columns.Get(8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdRMA_Sheet1.Columns.Get(8).Label = "Create Comment";
            this.spdRMA_Sheet1.Columns.Get(8).Locked = true;
            this.spdRMA_Sheet1.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdRMA_Sheet1.Columns.Get(8).Width = 300F;
            this.spdRMA_Sheet1.Columns.Get(9).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdRMA_Sheet1.Columns.Get(9).Label = "Result Code";
            this.spdRMA_Sheet1.Columns.Get(9).Locked = true;
            this.spdRMA_Sheet1.Columns.Get(9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdRMA_Sheet1.Columns.Get(9).Width = 94F;
            this.spdRMA_Sheet1.Columns.Get(10).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdRMA_Sheet1.Columns.Get(10).Label = "Result Comment";
            this.spdRMA_Sheet1.Columns.Get(10).Locked = true;
            this.spdRMA_Sheet1.Columns.Get(10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdRMA_Sheet1.Columns.Get(10).Width = 300F;
            this.spdRMA_Sheet1.Columns.Get(11).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdRMA_Sheet1.Columns.Get(11).Label = "Create Time";
            this.spdRMA_Sheet1.Columns.Get(11).Locked = true;
            this.spdRMA_Sheet1.Columns.Get(11).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdRMA_Sheet1.Columns.Get(11).Width = 120F;
            this.spdRMA_Sheet1.Columns.Get(12).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdRMA_Sheet1.Columns.Get(12).Label = "Create User ID";
            this.spdRMA_Sheet1.Columns.Get(12).Locked = true;
            this.spdRMA_Sheet1.Columns.Get(12).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdRMA_Sheet1.Columns.Get(12).Width = 100F;
            this.spdRMA_Sheet1.Columns.Get(13).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdRMA_Sheet1.Columns.Get(13).Label = "Result Time";
            this.spdRMA_Sheet1.Columns.Get(13).Locked = true;
            this.spdRMA_Sheet1.Columns.Get(13).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdRMA_Sheet1.Columns.Get(13).Width = 120F;
            this.spdRMA_Sheet1.Columns.Get(14).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdRMA_Sheet1.Columns.Get(14).Label = "Result User ID";
            this.spdRMA_Sheet1.Columns.Get(14).Locked = true;
            this.spdRMA_Sheet1.Columns.Get(14).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdRMA_Sheet1.Columns.Get(14).Width = 100F;
            this.spdRMA_Sheet1.FrozenColumnCount = 2;
            this.spdRMA_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdRMA_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdRMA_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdRMA_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdRMA_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.spdRMA_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdRMA_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdRMA_Sheet1.VisualStyles = FarPoint.Win.VisualStyles.Auto;
            this.spdRMA_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // cdvMaterial
            // 
            this.cdvMaterial.AddEmptyRowToLast = false;
            this.cdvMaterial.AddEmptyRowToTop = false;
            this.cdvMaterial.CodeViewBackColor = System.Drawing.SystemColors.Window;
            this.cdvMaterial.DisplaySubItemIndex = 0;
            this.cdvMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvMaterial.LabelBackColor = System.Drawing.SystemColors.Control;
            this.cdvMaterial.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvMaterial.LabelText = "Material";
            this.cdvMaterial.ListCond_ExtFactory = "";
            this.cdvMaterial.ListCond_StepMaterial = '1';
            this.cdvMaterial.ListCond_StepVersion = '1';
            this.cdvMaterial.Location = new System.Drawing.Point(12, 15);
            this.cdvMaterial.MaterialEnabled = true;
            this.cdvMaterial.MaterialReadOnly = false;
            this.cdvMaterial.Name = "cdvMaterial";
            this.cdvMaterial.SearchSubItemIndex = 0;
            this.cdvMaterial.SelectedDescIndex = -1;
            this.cdvMaterial.SelectedSubItemIndex = 0;
            this.cdvMaterial.Size = new System.Drawing.Size(308, 20);
            this.cdvMaterial.TabIndex = 1;
            this.cdvMaterial.VersionEnabled = true;
            this.cdvMaterial.VersionReadOnly = false;
            this.cdvMaterial.VisibleColumnHeader = false;
            this.cdvMaterial.VisibleDescription = false;
            this.cdvMaterial.VisibleMaterialButton = true;
            this.cdvMaterial.VisibleVersionButton = true;
            this.cdvMaterial.WidthButton = 20;
            this.cdvMaterial.WidthLabel = 108;
            this.cdvMaterial.WidthMaterialAndVersion = 200;
            this.cdvMaterial.WidthVersion = 50;
            // 
            // frmWIPViewReturnLotList
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Name = "frmWIPViewReturnLotList";
            this.Text = "View Return Lot List";
            this.Activated += new System.EventHandler(this.frmWIPViewReturnLotList_Activated);
            this.Closed += new System.EventHandler(this.frmWIPViewReturnLotList_Closed);
            this.pnlViewTop.ResumeLayout(false);
            this.grpOption.ResumeLayout(false);
            this.grpOption.PerformLayout();
            this.pnlViewMid.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlPeriod.ResumeLayout(false);
            this.pnlPeriod.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdRMA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdRMA_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Constant Definition "
        
        #endregion
        
        #region " Variable Definition "
        private bool b_load_flag = false;
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
        
        private string MakeDate(string sWorkDate)
        {
            return sWorkDate.Substring(0, 4) + "/" + sWorkDate.Substring(4, 2) + "/" + sWorkDate.Substring(6, 2);
        }
        private bool ViewReturnLotList()
        {
            int i;
            int iCol = 0;
            int iRow = 0;
            
            string sFromDate;
            string sToDate;

            sFromDate = MPCF.FromDate(dtpFrom);
            sFromDate = sFromDate.Substring(0, 8);

            sToDate = MPCF.ToDate(dtpTo);
            sToDate = sToDate.Substring(0, 8);

            TRSNode in_node = new TRSNode("VIEW_RETURNLOT_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_RETURNLOT_LIST_OUT");

            MPCF.ClearList(spdRMA, true);
            MPCR.SetInMsg(in_node);

            in_node.ProcStep = '1';
            in_node.AddString("FROM_DATE", sFromDate);
            in_node.AddString("TO_DATE", sToDate);

            if (cboRMAStatus.SelectedIndex == 0)
            {
                in_node.AddString("RMA_STATUS", "");
            }
            else if (cboRMAStatus.SelectedIndex == 1)
            {
                in_node.AddString("RMA_STATUS", "O");
            }
            else if (cboRMAStatus.SelectedIndex == 2)
            {
                in_node.AddString("RMA_STATUS", "C");
            }
            in_node.AddString("MAT_ID", cdvMaterial.Text);
            in_node.AddInt("MAT_VER", cdvMaterial.Version);
            do
            {
                if (MPCR.CallService("WIP", "WIP_View_ReturnLot_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    iRow = spdRMA.Sheets[0].RowCount;
                    spdRMA.Sheets[0].RowCount = spdRMA.Sheets[0].RowCount + 1;

                    iCol = 0;
                    spdRMA.Sheets[0].Cells[iRow, iCol].Value = MakeDate(out_node.GetList(0)[i].GetString("WORK_DATE"));

                    iCol++;
                    spdRMA.Sheets[0].Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("LOT_ID");

                    iCol++;
                    switch (out_node.GetList(0)[i].GetString("RMA_STATUS"))
                    {
                        case "C":

                            spdRMA.Sheets[0].Cells[iRow, iCol].Value = "Close";

                            iCol++;
                            break;
                        case "O":

                            spdRMA.Sheets[0].Cells[iRow, iCol].Value = "Open";

                            iCol++;
                            break;
                    }
                    spdRMA.Sheets[0].Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("MAT_ID");

                    iCol++;
                    spdRMA.Sheets[0].Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetInt("MAT_VER");

                    iCol++;
                    spdRMA.Sheets[0].Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetDouble("QTY");

                    iCol++;
                    spdRMA.Sheets[0].Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetChar("HIST_EXIST_FLAG");

                    iCol++;
                    spdRMA.Sheets[0].Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("CREATE_CODE");

                    iCol++;
                    spdRMA.Sheets[0].Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("CREATE_COMMENT");

                    iCol++;
                    spdRMA.Sheets[0].Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("RESULT_CODE");

                    iCol++;
                    spdRMA.Sheets[0].Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("RESULT_COMMENT");

                    iCol++;
                    spdRMA.Sheets[0].Cells[iRow, iCol].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("CREATE_TIME"));

                    iCol++;
                    spdRMA.Sheets[0].Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("CREATE_USER_ID");

                    iCol++;
                    spdRMA.Sheets[0].Cells[iRow, iCol].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("RESULT_TIME"));

                    iCol++;
                    spdRMA.Sheets[0].Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("RESULT_USER_ID");

                    iCol++;
                }

                in_node.SetString("FROM_DATE", out_node.GetString("NEXT_FROM_DATE"));
                in_node.SetString("NEXT_LOT_ID", out_node.GetString("NEXT_LOT_ID"));
            } while (in_node.GetString("NEXT_FROM_DATE") != "" || in_node.GetString("NEXT_LOT_ID") != "");


            MPCF.FitColumnHeader(spdRMA);

            return true;

        }

        
        public virtual Control GetFisrtFocusItem()
        {
            
            try
            {
                return this.cdvMaterial;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }
            
        }
        
        #endregion
        
        private void frmWIPViewReturnLotList_Activated(object sender, System.EventArgs e)
        {
            if (b_load_flag == false)
            {
                MPCF.ClearList(spdRMA, true);
                MPCF.FitColumnHeader(spdRMA);
                
                dtpFrom.Value = DateTime.Now;
                dtpTo.Value = DateTime.Now;
                b_load_flag = true;
            }
        }
        private void frmWIPViewReturnLotList_Closed(object sender, System.EventArgs e)
        {
            MPGV.gsReturnLotID = "";
            MPGV.gsWorkDate = "";
        }
        
        private void spdRMA_SelectionChanged(object sender, FarPoint.Win.Spread.SelectionChangedEventArgs e)
        {
            if (spdRMA.Sheets[0].RowCount == 0)
            {
                return;
            }
            MPGV.gsReturnLotID = MPCF.Trim(spdRMA.Sheets[0].GetValue(spdRMA.Sheets[0].ActiveRowIndex, 1));
            MPGV.gsWorkDate = MPCF.DestroyDateFormat(spdRMA.Sheets[0].Cells[spdRMA.Sheets[0].ActiveRowIndex, 0].Text, DATE_TIME_FORMAT.DATE);
        }
        
        private void btnOpen_Click(System.Object sender, System.EventArgs e)
        {
            Form f;

            try
            {
                f = MPCF.GetChildForm(MPGV.gfrmMDI, "frmWIPTranOpenReturnLot");
                if (f == null)
                {
                    f = new frmWIPTranOpenReturnLot();
                    f.MdiParent = MPGV.gfrmMDI;
                    f.Show();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }
        private void btnCloseLot_Click(System.Object sender, System.EventArgs e)
        {
            Form f;

            try
            {
                f = MPCF.GetChildForm(MPGV.gfrmMDI, "frmWIPTranCloseReturnLot");
                if (f == null)
                {
                    f = new frmWIPTranCloseReturnLot();
                    f.MdiParent = MPGV.gfrmMDI;
                    f.Show();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        
        private void btnView_Click(System.Object sender, System.EventArgs e)
        {
            if (CheckCondition("VIEW") == false)
            {
                return;
            }
            ViewReturnLotList();
        }
        
        private void btnExcel_Click(System.Object sender, System.EventArgs e)
        {
            string sCond;

            sCond = "Date : " + dtpFrom.Value.ToString("yyyy/MM/dd") + " ~ " + dtpTo.Value.ToString("yyyy/MM/dd");
            if (MPCF.Trim(cdvMaterial.Text) != "")
            {
                sCond = sCond + "\r" + "Material : " + MPCF.Trim(cdvMaterial.Text);
                sCond = sCond + "\r" + "Version : " + MPCF.Trim(cdvMaterial.Version);
            }
            if (MPCF.Trim(cboRMAStatus.Text) != "")
            {
                sCond = sCond + "\r" + "Status : " + MPCF.Trim(cboRMAStatus.Text);
            }

            MPCF.ExportToExcel(spdRMA, this.Text, sCond);
            
        }

    }
    
}
