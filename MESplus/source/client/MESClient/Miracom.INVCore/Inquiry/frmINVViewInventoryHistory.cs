
using System.Diagnostics;
using System;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;

using Miracom.MsgHandler;
using System.Data;
using Miracom.MESCore;
using Miracom.CliFrx;
using Miracom.UI.Controls;

//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmINVViewInventoryHistory.vb
//   Description : MES Cient Form View Inventory History Class
//
//   MES Version : 4.1.0.0
//
//   Function List
//       - ClearData() : Clear Form Control Data
//       - CheckCondition() : Check the conditions before transaction
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2004-08-12 : Created by WKIM
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------
//#If _INV = True Then

namespace Miracom.INVCore
{
    public class frmINVViewInventoryHistory : Miracom.MESCore.ViewForm01
    {
        
        #region " Windows Form auto generated code "
        
        public frmINVViewInventoryHistory()
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
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvInvOper;
        protected System.Windows.Forms.Label lblInvOper;
        private System.Windows.Forms.CheckBox chkIncludeDelHistory;
        private FarPoint.Win.Spread.FpSpread spdHistory;
        private Miracom.MESCore.Controls.udcMaterial cdvMatID;
        private FarPoint.Win.Spread.SheetView spdHistory_Sheet1;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.TipAppearance tipAppearance1 = new FarPoint.Win.Spread.TipAppearance();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.BevelBorder bevelBorder1 = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Raised);
            this.pnlPeriod = new System.Windows.Forms.Panel();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.lblPeriod = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.cdvInvOper = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblInvOper = new System.Windows.Forms.Label();
            this.chkIncludeDelHistory = new System.Windows.Forms.CheckBox();
            this.spdHistory = new FarPoint.Win.Spread.FpSpread();
            this.spdHistory_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.cdvMatID = new Miracom.MESCore.Controls.udcMaterial();
            this.pnlViewTop.SuspendLayout();
            this.grpOption.SuspendLayout();
            this.pnlViewMid.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlPeriod.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvInvOper)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdHistory_Sheet1)).BeginInit();
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
            this.pnlViewTop.TabIndex = 0;
            // 
            // grpOption
            // 
            this.grpOption.Controls.Add(this.cdvMatID);
            this.grpOption.Controls.Add(this.chkIncludeDelHistory);
            this.grpOption.Controls.Add(this.pnlPeriod);
            this.grpOption.Controls.Add(this.cdvInvOper);
            this.grpOption.Controls.Add(this.lblInvOper);
            // 
            // pnlViewMid
            // 
            this.pnlViewMid.Controls.Add(this.spdHistory);
            this.pnlViewMid.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.pnlViewMid.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.TabIndex = 1;
            // 
            // pnlBottom
            // 
            this.pnlBottom.TabIndex = 0;
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "View Inventory History";
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
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(149, 6);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(14, 13);
            this.lblTo.TabIndex = 2;
            this.lblTo.Text = "~";
            // 
            // cdvInvOper
            // 
            this.cdvInvOper.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvInvOper.BorderHotColor = System.Drawing.Color.Black;
            this.cdvInvOper.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvInvOper.BtnToolTipText = "";
            this.cdvInvOper.ButtonWidth = 20;
            this.cdvInvOper.DescText = "";
            this.cdvInvOper.DisplaySubItemIndex = -1;
            this.cdvInvOper.DisplayText = "";
            this.cdvInvOper.Focusing = null;
            this.cdvInvOper.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvInvOper.Index = 0;
            this.cdvInvOper.IsViewBtnImage = false;
            this.cdvInvOper.Location = new System.Drawing.Point(120, 40);
            this.cdvInvOper.MaxLength = 10;
            this.cdvInvOper.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvInvOper.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvInvOper.MultiSelect = false;
            this.cdvInvOper.Name = "cdvInvOper";
            this.cdvInvOper.ReadOnly = false;
            this.cdvInvOper.SameWidthHeightOfButton = false;
            this.cdvInvOper.SearchSubItemIndex = 0;
            this.cdvInvOper.SelectedDescIndex = -1;
            this.cdvInvOper.SelectedDescToQueryText = "";
            this.cdvInvOper.SelectedSubItemIndex = -1;
            this.cdvInvOper.SelectedValueToQueryText = "";
            this.cdvInvOper.SelectionStart = 0;
            this.cdvInvOper.Size = new System.Drawing.Size(200, 20);
            this.cdvInvOper.SmallImageList = null;
            this.cdvInvOper.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvInvOper.TabIndex = 2;
            this.cdvInvOper.TextBoxToolTipText = "";
            this.cdvInvOper.TextBoxWidth = 200;
            this.cdvInvOper.VisibleButton = true;
            this.cdvInvOper.VisibleColumnHeader = false;
            this.cdvInvOper.VisibleDescription = false;
            this.cdvInvOper.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvInvOper_SelectedItemChanged);
            this.cdvInvOper.ButtonPress += new System.EventHandler(this.cdvInvOper_ButtonPress);
            // 
            // lblInvOper
            // 
            this.lblInvOper.AutoSize = true;
            this.lblInvOper.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblInvOper.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInvOper.Location = new System.Drawing.Point(12, 43);
            this.lblInvOper.Name = "lblInvOper";
            this.lblInvOper.Size = new System.Drawing.Size(91, 13);
            this.lblInvOper.TabIndex = 1;
            this.lblInvOper.Text = "Inventory Oper";
            this.lblInvOper.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkIncludeDelHistory
            // 
            this.chkIncludeDelHistory.AutoSize = true;
            this.chkIncludeDelHistory.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkIncludeDelHistory.Location = new System.Drawing.Point(470, 43);
            this.chkIncludeDelHistory.Name = "chkIncludeDelHistory";
            this.chkIncludeDelHistory.Size = new System.Drawing.Size(136, 18);
            this.chkIncludeDelHistory.TabIndex = 4;
            this.chkIncludeDelHistory.Text = "Include Delete History";
            // 
            // spdHistory
            // 
            this.spdHistory.AccessibleDescription = "spdHistory, Sheet1";
            this.spdHistory.BackColor = System.Drawing.SystemColors.Control;
            this.spdHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdHistory.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdHistory.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdHistory.HorizontalScrollBar.Name = "";
            this.spdHistory.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdHistory.HorizontalScrollBar.TabIndex = 2;
            this.spdHistory.Location = new System.Drawing.Point(0, 3);
            this.spdHistory.Name = "spdHistory";
            this.spdHistory.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdHistory.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdHistory.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdHistory_Sheet1});
            this.spdHistory.Size = new System.Drawing.Size(742, 439);
            this.spdHistory.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdHistory.TabIndex = 0;
            this.spdHistory.TabStop = false;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.spdHistory.TextTipAppearance = tipAppearance1;
            this.spdHistory.TextTipDelay = 200;
            this.spdHistory.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdHistory.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdHistory.VerticalScrollBar.Name = "";
            this.spdHistory.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdHistory.VerticalScrollBar.TabIndex = 3;
            this.spdHistory.SetViewportLeftColumn(0, 0, 3);
            this.spdHistory.SetActiveViewport(0, -1, -1);
            // 
            // spdHistory_Sheet1
            // 
            this.spdHistory_Sheet1.Reset();
            spdHistory_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdHistory_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdHistory_Sheet1.ColumnCount = 32;
            spdHistory_Sheet1.RowCount = 0;
            this.spdHistory_Sheet1.ActiveColumnIndex = -1;
            this.spdHistory_Sheet1.ActiveRowIndex = -1;
            this.spdHistory_Sheet1.AlternatingRows.Get(1).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdHistory_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdHistory_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdHistory_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdHistory_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Seq";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Tran Code";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Tran Time";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Qty";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Chg Qty";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "From To Flag";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "From To Mat ID";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "From To Mat Ver";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "From To Oper";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "From To Qty";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "From To Hist Seq";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "From To Lot ID";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 12).Value = "Scrap Code";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 13).Value = "Old Qty";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 14).Value = "Trans Cmf 1";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 15).Value = "Trans Cmf 2";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 16).Value = "Trans Cmf 3";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 17).Value = "Trans Cmf 4";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 18).Value = "Trans Cmf 5";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 19).Value = "Trans Cmf 6";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 20).Value = "Trans Cmf 7";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 21).Value = "Trans Cmf 8";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 22).Value = "Trans Cmf 9";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 23).Value = "Trans Cmf 10";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 24).Value = "Tran User ID";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 25).Value = "Tran Comment";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 26).Value = "Relate Tran Code";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 27).Value = "Relate Hist Seq";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 28).Value = "Hist Delete Flag";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 29).Value = "Hist Delete Time";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 30).Value = "Hist Delete User ID";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 31).Value = "Hist Delete Comment";
            this.spdHistory_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdHistory_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdHistory_Sheet1.ColumnHeader.Rows.Get(0).Height = 18F;
            this.spdHistory_Sheet1.Columns.Get(0).BackColor = System.Drawing.SystemColors.Control;
            this.spdHistory_Sheet1.Columns.Get(0).Border = bevelBorder1;
            this.spdHistory_Sheet1.Columns.Get(0).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdHistory_Sheet1.Columns.Get(0).ForeColor = System.Drawing.Color.Black;
            this.spdHistory_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(0).Label = "Seq";
            this.spdHistory_Sheet1.Columns.Get(0).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(0).Width = 44F;
            this.spdHistory_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(1).Label = "Tran Code";
            this.spdHistory_Sheet1.Columns.Get(1).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(1).Width = 90F;
            this.spdHistory_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(2).Label = "Tran Time";
            this.spdHistory_Sheet1.Columns.Get(2).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(2).Width = 120F;
            this.spdHistory_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdHistory_Sheet1.Columns.Get(3).Label = "Qty";
            this.spdHistory_Sheet1.Columns.Get(3).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdHistory_Sheet1.Columns.Get(4).Label = "Chg Qty";
            this.spdHistory_Sheet1.Columns.Get(4).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(5).Label = "From To Flag";
            this.spdHistory_Sheet1.Columns.Get(5).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(5).Width = 79F;
            this.spdHistory_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(6).Label = "From To Mat ID";
            this.spdHistory_Sheet1.Columns.Get(6).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(6).Width = 120F;
            this.spdHistory_Sheet1.Columns.Get(7).Label = "From To Mat Ver";
            this.spdHistory_Sheet1.Columns.Get(7).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(7).Width = 110F;
            this.spdHistory_Sheet1.Columns.Get(8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(8).Label = "From To Oper";
            this.spdHistory_Sheet1.Columns.Get(8).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(8).Width = 77F;
            this.spdHistory_Sheet1.Columns.Get(9).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdHistory_Sheet1.Columns.Get(9).Label = "From To Qty";
            this.spdHistory_Sheet1.Columns.Get(9).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(9).Width = 80F;
            this.spdHistory_Sheet1.Columns.Get(10).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(10).Label = "From To Hist Seq";
            this.spdHistory_Sheet1.Columns.Get(10).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(10).Width = 97F;
            this.spdHistory_Sheet1.Columns.Get(11).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(11).Label = "From To Lot ID";
            this.spdHistory_Sheet1.Columns.Get(11).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(11).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(11).Width = 120F;
            this.spdHistory_Sheet1.Columns.Get(12).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(12).Label = "Scrap Code";
            this.spdHistory_Sheet1.Columns.Get(12).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(12).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(12).Width = 69F;
            this.spdHistory_Sheet1.Columns.Get(13).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdHistory_Sheet1.Columns.Get(13).Label = "Old Qty";
            this.spdHistory_Sheet1.Columns.Get(13).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(13).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(14).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(14).Label = "Trans Cmf 1";
            this.spdHistory_Sheet1.Columns.Get(14).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(14).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(14).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(15).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(15).Label = "Trans Cmf 2";
            this.spdHistory_Sheet1.Columns.Get(15).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(15).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(15).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(16).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(16).Label = "Trans Cmf 3";
            this.spdHistory_Sheet1.Columns.Get(16).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(16).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(16).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(17).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(17).Label = "Trans Cmf 4";
            this.spdHistory_Sheet1.Columns.Get(17).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(17).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(17).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(18).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(18).Label = "Trans Cmf 5";
            this.spdHistory_Sheet1.Columns.Get(18).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(18).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(18).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(19).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(19).Label = "Trans Cmf 6";
            this.spdHistory_Sheet1.Columns.Get(19).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(19).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(19).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(20).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(20).Label = "Trans Cmf 7";
            this.spdHistory_Sheet1.Columns.Get(20).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(20).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(20).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(21).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(21).Label = "Trans Cmf 8";
            this.spdHistory_Sheet1.Columns.Get(21).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(21).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(21).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(22).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(22).Label = "Trans Cmf 9";
            this.spdHistory_Sheet1.Columns.Get(22).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(22).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(22).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(23).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(23).Label = "Trans Cmf 10";
            this.spdHistory_Sheet1.Columns.Get(23).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(23).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(23).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(24).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(24).Label = "Tran User ID";
            this.spdHistory_Sheet1.Columns.Get(24).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(24).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(24).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(25).Label = "Tran Comment";
            this.spdHistory_Sheet1.Columns.Get(25).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(25).Width = 300F;
            this.spdHistory_Sheet1.Columns.Get(26).Label = "Relate Tran Code";
            this.spdHistory_Sheet1.Columns.Get(26).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(26).Width = 102F;
            this.spdHistory_Sheet1.Columns.Get(27).Label = "Relate Hist Seq";
            this.spdHistory_Sheet1.Columns.Get(27).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(27).Width = 87F;
            this.spdHistory_Sheet1.Columns.Get(28).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(28).Label = "Hist Delete Flag";
            this.spdHistory_Sheet1.Columns.Get(28).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(28).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(28).Width = 98F;
            this.spdHistory_Sheet1.Columns.Get(29).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(29).Label = "Hist Delete Time";
            this.spdHistory_Sheet1.Columns.Get(29).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(29).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(29).Width = 120F;
            this.spdHistory_Sheet1.Columns.Get(30).Label = "Hist Delete User ID";
            this.spdHistory_Sheet1.Columns.Get(30).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(30).Width = 111F;
            this.spdHistory_Sheet1.Columns.Get(31).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(31).Label = "Hist Delete Comment";
            this.spdHistory_Sheet1.Columns.Get(31).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(31).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(31).Width = 300F;
            this.spdHistory_Sheet1.FrozenColumnCount = 3;
            this.spdHistory_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdHistory_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
            this.spdHistory_Sheet1.RowHeader.AutoText = FarPoint.Win.Spread.HeaderAutoText.Blank;
            this.spdHistory_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdHistory_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdHistory_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdHistory_Sheet1.RowHeader.Visible = false;
            this.spdHistory_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.spdHistory_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.spdHistory_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdHistory_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdHistory_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // cdvMatID
            // 
            this.cdvMatID.AddEmptyRowToLast = false;
            this.cdvMatID.AddEmptyRowToTop = false;
            this.cdvMatID.CodeViewBackColor = System.Drawing.SystemColors.Window;
            this.cdvMatID.DisplaySubItemIndex = 0;
            this.cdvMatID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvMatID.LabelBackColor = System.Drawing.SystemColors.Control;
            this.cdvMatID.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvMatID.LabelText = "Material";
            this.cdvMatID.ListCond_ExtFactory = "";
            this.cdvMatID.ListCond_StepMaterial = '1';
            this.cdvMatID.ListCond_StepVersion = '1';
            this.cdvMatID.Location = new System.Drawing.Point(12, 16);
            this.cdvMatID.MaterialEnabled = true;
            this.cdvMatID.MaterialReadOnly = false;
            this.cdvMatID.Name = "cdvMatID";
            this.cdvMatID.SearchSubItemIndex = 0;
            this.cdvMatID.SelectedDescIndex = -1;
            this.cdvMatID.SelectedSubItemIndex = 0;
            this.cdvMatID.Size = new System.Drawing.Size(308, 20);
            this.cdvMatID.TabIndex = 0;
            this.cdvMatID.VersionEnabled = true;
            this.cdvMatID.VersionReadOnly = false;
            this.cdvMatID.VisibleColumnHeader = false;
            this.cdvMatID.VisibleDescription = false;
            this.cdvMatID.VisibleMaterialButton = true;
            this.cdvMatID.VisibleVersionButton = true;
            this.cdvMatID.WidthButton = 20;
            this.cdvMatID.WidthLabel = 108;
            this.cdvMatID.WidthMaterialAndVersion = 200;
            this.cdvMatID.WidthVersion = 50;
            this.cdvMatID.MaterialSelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvMatID_SelectedItemChanged);
            this.cdvMatID.VersionSelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvMatID_SelectedItemChanged);
            // 
            // frmINVViewInventoryHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Name = "frmINVViewInventoryHistory";
            this.Text = "View Inventory History";
            this.Activated += new System.EventHandler(this.frmINVViewInventoryHistory_Activated);
            this.Load += new System.EventHandler(this.frmINVViewInventoryHistory_Load);
            this.pnlViewTop.ResumeLayout(false);
            this.grpOption.ResumeLayout(false);
            this.grpOption.PerformLayout();
            this.pnlViewMid.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlPeriod.ResumeLayout(false);
            this.pnlPeriod.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvInvOper)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdHistory_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Constant Definition "
        
        #endregion
        
        #region " Variable Definition "
        
        private bool b_load_flag;
        
        #endregion
        
        #region " Function Definition "
        //
        // CheckCondition()
        //       - Check the conditions before transaction
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal FuncName As String : Function Name
        //       - Optional ByVal ProcStep As String : Process Step
        
        private bool CheckCondition(string FuncName)
        {
            
            try
            {
                switch (FuncName)
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
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
            
            return true;
            
        }
        
        public virtual Control GetFisrtFocusItem()
        {
            
            try
            {
                return this.cdvMatID;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }
            
        }
        
        #endregion
        
        private void frmINVViewInventoryHistory_Load(object sender, System.EventArgs e)
        {
            
        }
        
        private void frmINVViewInventoryHistory_Activated(object sender, System.EventArgs e)
        {
            
            if (b_load_flag == false)
            {
                MPCF.FieldClear(this);
                MPCF.ClearList(spdHistory, true);
                MPCF.FitColumnHeader(spdHistory);
                
                dtpFrom.Value = DateTime.Today.AddMonths(- 1);
                dtpTo.Value = DateTime.Today;
                cdvMatID.Focus();
                b_load_flag = true;
            }
            
        }
        
        private void btnView_Click(System.Object sender, System.EventArgs e)
        {
            string sFromTime;
            string sToTime;
            char sIncludeDelHist;
            
            if (cdvMatID.Text != "" && cdvInvOper.Text != "")
            {
                if (CheckCondition("VIEW") == false)
                {
                    return;
                }
                sFromTime = MPCF.FromDate(dtpFrom);
                sToTime = MPCF.ToDate(dtpTo);
                sIncludeDelHist = chkIncludeDelHistory.Checked == true ? 'Y' : ' ';

                if (INVLIST.ViewInventoryHistory(spdHistory, '1', cdvMatID.Text, cdvMatID.Version, cdvInvOper.Text, sFromTime, sToTime, sIncludeDelHist, null, false, "") == false)
                {
                    return;
                }
                
                MPCF.FitColumnHeader(spdHistory);

                this.Text = MPCF.FindLanguage("View Inventory History", 0) + " (" + cdvMatID.Text + "," + cdvInvOper.Text + ")";
                this.lblFormTitle.Text = this.Text;
                
            }
            
        }
        
        private void btnExcel_Click(System.Object sender, System.EventArgs e)
        {
            string sCond;

            sCond = "Date : " + MPCF.MakeDateFormat(MPCF.FromDate(dtpFrom)) + " ~ " + MPCF.MakeDateFormat(MPCF.ToDate(dtpTo));
            
            if (MPCF.ExportToExcel(spdHistory, this.Text, sCond, true, true, true, -1, -1) == false)
            {
                return;
            }
            
        }
        
        private void cdvInvOper_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            
            btnView.PerformClick();
            
        }

        private void cdvMatID_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            
            cdvInvOper.Text = "";
            
        }
        
        //private void cdvMatID_MaterialButtonPress(object sender, System.EventArgs e)
        //{
        //    cdvMatID.Init();
        //    MPCF.InitListView(cdvMatID.MaterialGetListView);
        //    cdvMatID.MaterialColumns.Add("Material", 100, HorizontalAlignment.Left);
        //    cdvMatID.MaterialColumns.Add("Desc", 100, HorizontalAlignment.Left);
        //    cdvMatID.SelectedSubItemIndex = 0;

        //    WIPLIST.ViewMaterialList(cdvMatID.MaterialGetListView, '1');
        //}
        
        private void cdvInvOper_ButtonPress(object sender, System.EventArgs e)
        {
            cdvInvOper.Init();
            MPCF.InitListView(cdvInvOper.GetListView);
            cdvInvOper.Columns.Add("Oper", 100, HorizontalAlignment.Left);
            cdvInvOper.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvInvOper.SelectedSubItemIndex = 0;
            
            WIPLIST.ViewOperationList(cdvInvOper.GetListView, '6', "", 0,"", "", null, "");
        }
    }
    //#End If
}
