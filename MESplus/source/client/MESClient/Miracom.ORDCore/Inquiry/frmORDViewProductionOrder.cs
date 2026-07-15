
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
//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmORDViewProductionOrder.vb
//   Description : MES Cient Form View Production Order
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
//       - 2004-07-14 : Created by CM Koo
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------
//#If _ORD = True Then

namespace Miracom.ORDCore
{
    public class frmORDViewProductionOrder : Miracom.MESCore.ViewForm01
    {
        
        #region " Windows Form auto generated code "
        
        public frmORDViewProductionOrder()
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
        



        private System.Windows.Forms.TabPage tbpOrder;
        private System.Windows.Forms.TabPage tbpMaterial;
        private System.Windows.Forms.TabControl tabOrder;
        private FarPoint.Win.Spread.FpSpread spdOrder;
        private FarPoint.Win.Spread.SheetView spdOrder_Sheet1;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvActiveStatus;
        private System.Windows.Forms.Label lblActiveStatus;
        private FarPoint.Win.Spread.FpSpread spdMatOrder;
        private FarPoint.Win.Spread.SheetView spdMatOrder_Sheet1;
        private System.Windows.Forms.Panel pnlPeriod;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label lblPeriod;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private Miracom.MESCore.Controls.udcMaterial cdvMaterial;
        private System.Windows.Forms.Label lblTo;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer2 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer3 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer4 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            this.tabOrder = new System.Windows.Forms.TabControl();
            this.tbpOrder = new System.Windows.Forms.TabPage();
            this.spdOrder = new FarPoint.Win.Spread.FpSpread();
            this.spdOrder_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.tbpMaterial = new System.Windows.Forms.TabPage();
            this.spdMatOrder = new FarPoint.Win.Spread.FpSpread();
            this.spdMatOrder_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.cdvActiveStatus = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblActiveStatus = new System.Windows.Forms.Label();
            this.pnlPeriod = new System.Windows.Forms.Panel();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.lblPeriod = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.cdvMaterial = new Miracom.MESCore.Controls.udcMaterial();
            this.pnlViewTop.SuspendLayout();
            this.grpOption.SuspendLayout();
            this.pnlViewMid.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.tabOrder.SuspendLayout();
            this.tbpOrder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdOrder_Sheet1)).BeginInit();
            this.tbpMaterial.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdMatOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdMatOrder_Sheet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvActiveStatus)).BeginInit();
            this.pnlPeriod.SuspendLayout();
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
            // grpOption
            // 
            this.grpOption.Controls.Add(this.cdvMaterial);
            this.grpOption.Controls.Add(this.pnlPeriod);
            this.grpOption.Controls.Add(this.cdvActiveStatus);
            this.grpOption.Controls.Add(this.lblActiveStatus);
            // 
            // pnlViewMid
            // 
            this.pnlViewMid.Controls.Add(this.tabOrder);
            this.pnlViewMid.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
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
            this.lblFormTitle.Text = "View Production Order";
            // 
            // tabOrder
            // 
            this.tabOrder.Controls.Add(this.tbpOrder);
            this.tabOrder.Controls.Add(this.tbpMaterial);
            this.tabOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabOrder.ItemSize = new System.Drawing.Size(60, 18);
            this.tabOrder.Location = new System.Drawing.Point(0, 5);
            this.tabOrder.Name = "tabOrder";
            this.tabOrder.SelectedIndex = 0;
            this.tabOrder.Size = new System.Drawing.Size(742, 437);
            this.tabOrder.TabIndex = 0;
            // 
            // tbpOrder
            // 
            this.tbpOrder.Controls.Add(this.spdOrder);
            this.tbpOrder.Location = new System.Drawing.Point(4, 22);
            this.tbpOrder.Name = "tbpOrder";
            this.tbpOrder.Size = new System.Drawing.Size(734, 411);
            this.tbpOrder.TabIndex = 0;
            this.tbpOrder.Text = "Order";
            // 
            // spdOrder
            // 
            this.spdOrder.AccessibleDescription = "spdOrder, Sheet1, Row 0, Column 0, ";
            this.spdOrder.BackColor = System.Drawing.SystemColors.Control;
            this.spdOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdOrder.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdOrder.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdOrder.HorizontalScrollBar.Name = "";
            this.spdOrder.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdOrder.HorizontalScrollBar.TabIndex = 4;
            this.spdOrder.Location = new System.Drawing.Point(0, 0);
            this.spdOrder.Name = "spdOrder";
            this.spdOrder.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdOrder.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdOrder.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdOrder_Sheet1});
            this.spdOrder.Size = new System.Drawing.Size(734, 411);
            this.spdOrder.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdOrder.TabIndex = 0;
            this.spdOrder.TabStop = false;
            this.spdOrder.TextTipDelay = 200;
            this.spdOrder.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdOrder.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdOrder.VerticalScrollBar.Name = "";
            this.spdOrder.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdOrder.VerticalScrollBar.TabIndex = 5;
            this.spdOrder.AutoSortedColumn += new FarPoint.Win.Spread.AutoSortedColumnEventHandler(this.spdOrder_AutoSortedColumn);
            this.spdOrder.SetViewportLeftColumn(0, 0, 2);
            this.spdOrder.SetActiveViewport(0, 0, -1);
            // 
            // spdOrder_Sheet1
            // 
            this.spdOrder_Sheet1.Reset();
            spdOrder_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdOrder_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdOrder_Sheet1.ColumnCount = 34;
            spdOrder_Sheet1.RowCount = 5;
            this.spdOrder_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdOrder_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdOrder_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdOrder_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdOrder_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Work Date";
            this.spdOrder_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Order ID";
            this.spdOrder_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Order Desc";
            this.spdOrder_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Mat ID";
            this.spdOrder_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Mat Ver";
            this.spdOrder_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Flow";
            this.spdOrder_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Flow Seq Num";
            this.spdOrder_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "Order Qty";
            this.spdOrder_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "Res ID";
            this.spdOrder_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "Bom Set ID";
            this.spdOrder_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "Bom Set Version";
            this.spdOrder_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "Customer ID";
            this.spdOrder_Sheet1.ColumnHeader.Cells.Get(0, 12).Value = "Customer Mat ID";
            this.spdOrder_Sheet1.ColumnHeader.Cells.Get(0, 13).Value = "Plan Due Time";
            this.spdOrder_Sheet1.ColumnHeader.Cells.Get(0, 14).Value = "Plan Start Time";
            this.spdOrder_Sheet1.ColumnHeader.Cells.Get(0, 15).Value = "Plan End Time";
            this.spdOrder_Sheet1.ColumnHeader.Cells.Get(0, 16).Value = "Qty";
            this.spdOrder_Sheet1.ColumnHeader.Cells.Get(0, 17).Value = "Lot Type";
            this.spdOrder_Sheet1.ColumnHeader.Cells.Get(0, 18).Value = "Owner Code";
            this.spdOrder_Sheet1.ColumnHeader.Cells.Get(0, 19).Value = "Create Code";
            this.spdOrder_Sheet1.ColumnHeader.Cells.Get(0, 20).Value = "Lot Priority";
            this.spdOrder_Sheet1.ColumnHeader.Cells.Get(0, 21).Value = "Org Due Time";
            this.spdOrder_Sheet1.ColumnHeader.Cells.Get(0, 22).Value = "Ord Status Flag";
            this.spdOrder_Sheet1.ColumnHeader.Cells.Get(0, 23).Value = "Ord Ship Flag";
            this.spdOrder_Sheet1.ColumnHeader.Cells.Get(0, 24).Value = "Ord Start Time";
            this.spdOrder_Sheet1.ColumnHeader.Cells.Get(0, 25).Value = "Ord End Time";
            this.spdOrder_Sheet1.ColumnHeader.Cells.Get(0, 26).Value = "Order In Qty";
            this.spdOrder_Sheet1.ColumnHeader.Cells.Get(0, 27).Value = "Order Out Qty";
            this.spdOrder_Sheet1.ColumnHeader.Cells.Get(0, 28).Value = "Order Loss Qty";
            this.spdOrder_Sheet1.ColumnHeader.Cells.Get(0, 29).Value = "Order Rwk Qty";
            this.spdOrder_Sheet1.ColumnHeader.Cells.Get(0, 30).Value = "Create User";
            this.spdOrder_Sheet1.ColumnHeader.Cells.Get(0, 31).Value = "Create Time";
            this.spdOrder_Sheet1.ColumnHeader.Cells.Get(0, 32).Value = "Update User";
            this.spdOrder_Sheet1.ColumnHeader.Cells.Get(0, 33).Value = "Update Time";
            this.spdOrder_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdOrder_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdOrder_Sheet1.Columns.Get(0).AllowAutoSort = true;
            this.spdOrder_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdOrder_Sheet1.Columns.Get(0).Label = "Work Date";
            this.spdOrder_Sheet1.Columns.Get(0).Locked = true;
            this.spdOrder_Sheet1.Columns.Get(0).MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Restricted;
            this.spdOrder_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOrder_Sheet1.Columns.Get(0).Width = 100F;
            this.spdOrder_Sheet1.Columns.Get(1).AllowAutoSort = true;
            this.spdOrder_Sheet1.Columns.Get(1).Label = "Order ID";
            this.spdOrder_Sheet1.Columns.Get(1).Locked = true;
            this.spdOrder_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOrder_Sheet1.Columns.Get(1).Width = 106F;
            this.spdOrder_Sheet1.Columns.Get(2).AllowAutoSort = true;
            this.spdOrder_Sheet1.Columns.Get(2).Label = "Order Desc";
            this.spdOrder_Sheet1.Columns.Get(2).Locked = true;
            this.spdOrder_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOrder_Sheet1.Columns.Get(2).Width = 110F;
            this.spdOrder_Sheet1.Columns.Get(3).AllowAutoSort = true;
            this.spdOrder_Sheet1.Columns.Get(3).Label = "Mat ID";
            this.spdOrder_Sheet1.Columns.Get(3).Locked = true;
            this.spdOrder_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOrder_Sheet1.Columns.Get(3).Width = 120F;
            this.spdOrder_Sheet1.Columns.Get(4).AllowAutoSort = true;
            this.spdOrder_Sheet1.Columns.Get(4).Label = "Mat Ver";
            this.spdOrder_Sheet1.Columns.Get(4).Locked = true;
            this.spdOrder_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOrder_Sheet1.Columns.Get(4).Width = 100F;
            this.spdOrder_Sheet1.Columns.Get(5).AllowAutoSort = true;
            this.spdOrder_Sheet1.Columns.Get(5).Label = "Flow";
            this.spdOrder_Sheet1.Columns.Get(5).Locked = true;
            this.spdOrder_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOrder_Sheet1.Columns.Get(5).Width = 101F;
            this.spdOrder_Sheet1.Columns.Get(6).AllowAutoSort = true;
            this.spdOrder_Sheet1.Columns.Get(6).Label = "Flow Seq Num";
            this.spdOrder_Sheet1.Columns.Get(6).Locked = true;
            this.spdOrder_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOrder_Sheet1.Columns.Get(6).Width = 100F;
            this.spdOrder_Sheet1.Columns.Get(7).AllowAutoSort = true;
            this.spdOrder_Sheet1.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdOrder_Sheet1.Columns.Get(7).Label = "Order Qty";
            this.spdOrder_Sheet1.Columns.Get(7).Locked = true;
            this.spdOrder_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOrder_Sheet1.Columns.Get(7).Width = 100F;
            this.spdOrder_Sheet1.Columns.Get(8).AllowAutoSort = true;
            this.spdOrder_Sheet1.Columns.Get(8).Label = "Res ID";
            this.spdOrder_Sheet1.Columns.Get(8).Locked = true;
            this.spdOrder_Sheet1.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOrder_Sheet1.Columns.Get(8).Width = 115F;
            this.spdOrder_Sheet1.Columns.Get(9).AllowAutoSort = true;
            this.spdOrder_Sheet1.Columns.Get(9).Label = "Bom Set ID";
            this.spdOrder_Sheet1.Columns.Get(9).Locked = true;
            this.spdOrder_Sheet1.Columns.Get(9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOrder_Sheet1.Columns.Get(9).Width = 121F;
            this.spdOrder_Sheet1.Columns.Get(10).AllowAutoSort = true;
            this.spdOrder_Sheet1.Columns.Get(10).Label = "Bom Set Version";
            this.spdOrder_Sheet1.Columns.Get(10).Locked = true;
            this.spdOrder_Sheet1.Columns.Get(10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOrder_Sheet1.Columns.Get(10).Width = 118F;
            this.spdOrder_Sheet1.Columns.Get(11).AllowAutoSort = true;
            this.spdOrder_Sheet1.Columns.Get(11).Label = "Customer ID";
            this.spdOrder_Sheet1.Columns.Get(11).Locked = true;
            this.spdOrder_Sheet1.Columns.Get(11).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOrder_Sheet1.Columns.Get(11).Width = 105F;
            this.spdOrder_Sheet1.Columns.Get(12).AllowAutoSort = true;
            this.spdOrder_Sheet1.Columns.Get(12).Label = "Customer Mat ID";
            this.spdOrder_Sheet1.Columns.Get(12).Locked = true;
            this.spdOrder_Sheet1.Columns.Get(12).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOrder_Sheet1.Columns.Get(12).Width = 127F;
            this.spdOrder_Sheet1.Columns.Get(13).AllowAutoSort = true;
            this.spdOrder_Sheet1.Columns.Get(13).Label = "Plan Due Time";
            this.spdOrder_Sheet1.Columns.Get(13).Locked = true;
            this.spdOrder_Sheet1.Columns.Get(13).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOrder_Sheet1.Columns.Get(13).Width = 125F;
            this.spdOrder_Sheet1.Columns.Get(14).AllowAutoSort = true;
            this.spdOrder_Sheet1.Columns.Get(14).Label = "Plan Start Time";
            this.spdOrder_Sheet1.Columns.Get(14).Locked = true;
            this.spdOrder_Sheet1.Columns.Get(14).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOrder_Sheet1.Columns.Get(14).Width = 125F;
            this.spdOrder_Sheet1.Columns.Get(15).AllowAutoSort = true;
            this.spdOrder_Sheet1.Columns.Get(15).Label = "Plan End Time";
            this.spdOrder_Sheet1.Columns.Get(15).Locked = true;
            this.spdOrder_Sheet1.Columns.Get(15).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOrder_Sheet1.Columns.Get(15).Width = 125F;
            this.spdOrder_Sheet1.Columns.Get(16).AllowAutoSort = true;
            this.spdOrder_Sheet1.Columns.Get(16).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdOrder_Sheet1.Columns.Get(16).Label = "Qty";
            this.spdOrder_Sheet1.Columns.Get(16).Locked = true;
            this.spdOrder_Sheet1.Columns.Get(16).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOrder_Sheet1.Columns.Get(16).Width = 100F;
            this.spdOrder_Sheet1.Columns.Get(17).AllowAutoSort = true;
            this.spdOrder_Sheet1.Columns.Get(17).Label = "Lot Type";
            this.spdOrder_Sheet1.Columns.Get(17).Locked = true;
            this.spdOrder_Sheet1.Columns.Get(17).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOrder_Sheet1.Columns.Get(17).Width = 70F;
            this.spdOrder_Sheet1.Columns.Get(18).AllowAutoSort = true;
            this.spdOrder_Sheet1.Columns.Get(18).Label = "Owner Code";
            this.spdOrder_Sheet1.Columns.Get(18).Locked = true;
            this.spdOrder_Sheet1.Columns.Get(18).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOrder_Sheet1.Columns.Get(18).Width = 92F;
            this.spdOrder_Sheet1.Columns.Get(19).AllowAutoSort = true;
            this.spdOrder_Sheet1.Columns.Get(19).Label = "Create Code";
            this.spdOrder_Sheet1.Columns.Get(19).Locked = true;
            this.spdOrder_Sheet1.Columns.Get(19).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOrder_Sheet1.Columns.Get(19).Width = 86F;
            this.spdOrder_Sheet1.Columns.Get(20).AllowAutoSort = true;
            this.spdOrder_Sheet1.Columns.Get(20).Label = "Lot Priority";
            this.spdOrder_Sheet1.Columns.Get(20).Locked = true;
            this.spdOrder_Sheet1.Columns.Get(20).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOrder_Sheet1.Columns.Get(20).Width = 82F;
            this.spdOrder_Sheet1.Columns.Get(21).AllowAutoSort = true;
            this.spdOrder_Sheet1.Columns.Get(21).Label = "Org Due Time";
            this.spdOrder_Sheet1.Columns.Get(21).Locked = true;
            this.spdOrder_Sheet1.Columns.Get(21).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOrder_Sheet1.Columns.Get(21).Width = 125F;
            this.spdOrder_Sheet1.Columns.Get(22).AllowAutoSort = true;
            this.spdOrder_Sheet1.Columns.Get(22).Label = "Ord Status Flag";
            this.spdOrder_Sheet1.Columns.Get(22).Locked = true;
            this.spdOrder_Sheet1.Columns.Get(22).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOrder_Sheet1.Columns.Get(22).Width = 97F;
            this.spdOrder_Sheet1.Columns.Get(23).AllowAutoSort = true;
            this.spdOrder_Sheet1.Columns.Get(23).Label = "Ord Ship Flag";
            this.spdOrder_Sheet1.Columns.Get(23).Locked = true;
            this.spdOrder_Sheet1.Columns.Get(23).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOrder_Sheet1.Columns.Get(23).Width = 98F;
            this.spdOrder_Sheet1.Columns.Get(24).AllowAutoSort = true;
            this.spdOrder_Sheet1.Columns.Get(24).Label = "Ord Start Time";
            this.spdOrder_Sheet1.Columns.Get(24).Locked = true;
            this.spdOrder_Sheet1.Columns.Get(24).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOrder_Sheet1.Columns.Get(24).Width = 125F;
            this.spdOrder_Sheet1.Columns.Get(25).AllowAutoSort = true;
            this.spdOrder_Sheet1.Columns.Get(25).Label = "Ord End Time";
            this.spdOrder_Sheet1.Columns.Get(25).Locked = true;
            this.spdOrder_Sheet1.Columns.Get(25).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOrder_Sheet1.Columns.Get(25).Width = 125F;
            this.spdOrder_Sheet1.Columns.Get(26).AllowAutoSort = true;
            this.spdOrder_Sheet1.Columns.Get(26).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdOrder_Sheet1.Columns.Get(26).Label = "Order In Qty";
            this.spdOrder_Sheet1.Columns.Get(26).Locked = true;
            this.spdOrder_Sheet1.Columns.Get(26).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOrder_Sheet1.Columns.Get(26).Width = 100F;
            this.spdOrder_Sheet1.Columns.Get(27).AllowAutoSort = true;
            this.spdOrder_Sheet1.Columns.Get(27).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdOrder_Sheet1.Columns.Get(27).Label = "Order Out Qty";
            this.spdOrder_Sheet1.Columns.Get(27).Locked = true;
            this.spdOrder_Sheet1.Columns.Get(27).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOrder_Sheet1.Columns.Get(27).Width = 100F;
            this.spdOrder_Sheet1.Columns.Get(28).AllowAutoSort = true;
            this.spdOrder_Sheet1.Columns.Get(28).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdOrder_Sheet1.Columns.Get(28).Label = "Order Loss Qty";
            this.spdOrder_Sheet1.Columns.Get(28).Locked = true;
            this.spdOrder_Sheet1.Columns.Get(28).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOrder_Sheet1.Columns.Get(28).Width = 100F;
            this.spdOrder_Sheet1.Columns.Get(29).AllowAutoSort = true;
            this.spdOrder_Sheet1.Columns.Get(29).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdOrder_Sheet1.Columns.Get(29).Label = "Order Rwk Qty";
            this.spdOrder_Sheet1.Columns.Get(29).Locked = true;
            this.spdOrder_Sheet1.Columns.Get(29).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOrder_Sheet1.Columns.Get(29).Width = 100F;
            this.spdOrder_Sheet1.Columns.Get(30).AllowAutoSort = true;
            this.spdOrder_Sheet1.Columns.Get(30).Label = "Create User";
            this.spdOrder_Sheet1.Columns.Get(30).Locked = true;
            this.spdOrder_Sheet1.Columns.Get(30).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOrder_Sheet1.Columns.Get(30).Width = 80F;
            this.spdOrder_Sheet1.Columns.Get(31).AllowAutoSort = true;
            this.spdOrder_Sheet1.Columns.Get(31).Label = "Create Time";
            this.spdOrder_Sheet1.Columns.Get(31).Locked = true;
            this.spdOrder_Sheet1.Columns.Get(31).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOrder_Sheet1.Columns.Get(31).Width = 125F;
            this.spdOrder_Sheet1.Columns.Get(32).AllowAutoSort = true;
            this.spdOrder_Sheet1.Columns.Get(32).Label = "Update User";
            this.spdOrder_Sheet1.Columns.Get(32).Locked = true;
            this.spdOrder_Sheet1.Columns.Get(32).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOrder_Sheet1.Columns.Get(32).Width = 80F;
            this.spdOrder_Sheet1.Columns.Get(33).AllowAutoSort = true;
            this.spdOrder_Sheet1.Columns.Get(33).Label = "Update Time";
            this.spdOrder_Sheet1.Columns.Get(33).Locked = true;
            this.spdOrder_Sheet1.Columns.Get(33).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOrder_Sheet1.Columns.Get(33).Width = 125F;
            this.spdOrder_Sheet1.FrozenColumnCount = 2;
            this.spdOrder_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdOrder_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdOrder_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdOrder_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdOrder_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdOrder_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdOrder_Sheet1.VisualStyles = FarPoint.Win.VisualStyles.Auto;
            this.spdOrder_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // tbpMaterial
            // 
            this.tbpMaterial.Controls.Add(this.spdMatOrder);
            this.tbpMaterial.Location = new System.Drawing.Point(4, 22);
            this.tbpMaterial.Name = "tbpMaterial";
            this.tbpMaterial.Size = new System.Drawing.Size(734, 411);
            this.tbpMaterial.TabIndex = 1;
            this.tbpMaterial.Text = "Material";
            // 
            // spdMatOrder
            // 
            this.spdMatOrder.AccessibleDescription = "spdMatOrder, Sheet1, Row 0, Column 0, ";
            this.spdMatOrder.BackColor = System.Drawing.SystemColors.Control;
            this.spdMatOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdMatOrder.FocusRenderer = defaultFocusIndicatorRenderer2;
            this.spdMatOrder.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdMatOrder.HorizontalScrollBar.Name = "";
            this.spdMatOrder.HorizontalScrollBar.Renderer = defaultScrollBarRenderer3;
            this.spdMatOrder.HorizontalScrollBar.TabIndex = 4;
            this.spdMatOrder.Location = new System.Drawing.Point(0, 0);
            this.spdMatOrder.Name = "spdMatOrder";
            this.spdMatOrder.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdMatOrder.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdMatOrder.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdMatOrder_Sheet1});
            this.spdMatOrder.Size = new System.Drawing.Size(734, 411);
            this.spdMatOrder.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdMatOrder.TabIndex = 1;
            this.spdMatOrder.TabStop = false;
            this.spdMatOrder.TextTipDelay = 200;
            this.spdMatOrder.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdMatOrder.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdMatOrder.VerticalScrollBar.Name = "";
            this.spdMatOrder.VerticalScrollBar.Renderer = defaultScrollBarRenderer4;
            this.spdMatOrder.VerticalScrollBar.TabIndex = 5;
            this.spdMatOrder.SetViewportLeftColumn(0, 0, 2);
            this.spdMatOrder.SetActiveViewport(0, 0, -1);
            // 
            // spdMatOrder_Sheet1
            // 
            this.spdMatOrder_Sheet1.Reset();
            spdMatOrder_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdMatOrder_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdMatOrder_Sheet1.ColumnCount = 34;
            spdMatOrder_Sheet1.RowCount = 5;
            this.spdMatOrder_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdMatOrder_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdMatOrder_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdMatOrder_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdMatOrder_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Mat ID";
            this.spdMatOrder_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Mat Ver";
            this.spdMatOrder_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Work Date";
            this.spdMatOrder_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Order ID";
            this.spdMatOrder_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Order Desc";
            this.spdMatOrder_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Flow";
            this.spdMatOrder_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Flow Seq Num";
            this.spdMatOrder_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "Order Qty";
            this.spdMatOrder_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "Res ID";
            this.spdMatOrder_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "Bom Set ID";
            this.spdMatOrder_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "Bom Set Version";
            this.spdMatOrder_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "Customer ID";
            this.spdMatOrder_Sheet1.ColumnHeader.Cells.Get(0, 12).Value = "Customer Mat ID";
            this.spdMatOrder_Sheet1.ColumnHeader.Cells.Get(0, 13).Value = "Plan Due Time";
            this.spdMatOrder_Sheet1.ColumnHeader.Cells.Get(0, 14).Value = "Plan Start Time";
            this.spdMatOrder_Sheet1.ColumnHeader.Cells.Get(0, 15).Value = "Plan End Time";
            this.spdMatOrder_Sheet1.ColumnHeader.Cells.Get(0, 16).Value = "Qty";
            this.spdMatOrder_Sheet1.ColumnHeader.Cells.Get(0, 17).Value = "Lot Type";
            this.spdMatOrder_Sheet1.ColumnHeader.Cells.Get(0, 18).Value = "Owner Code";
            this.spdMatOrder_Sheet1.ColumnHeader.Cells.Get(0, 19).Value = "Create Code";
            this.spdMatOrder_Sheet1.ColumnHeader.Cells.Get(0, 20).Value = "Lot Priority";
            this.spdMatOrder_Sheet1.ColumnHeader.Cells.Get(0, 21).Value = "Org Due Time";
            this.spdMatOrder_Sheet1.ColumnHeader.Cells.Get(0, 22).Value = "Ord Status Flag";
            this.spdMatOrder_Sheet1.ColumnHeader.Cells.Get(0, 23).Value = "Ord Ship Flag";
            this.spdMatOrder_Sheet1.ColumnHeader.Cells.Get(0, 24).Value = "Ord Start Time";
            this.spdMatOrder_Sheet1.ColumnHeader.Cells.Get(0, 25).Value = "Ord End Time";
            this.spdMatOrder_Sheet1.ColumnHeader.Cells.Get(0, 26).Value = "Order In Qty";
            this.spdMatOrder_Sheet1.ColumnHeader.Cells.Get(0, 27).Value = "Order Out Qty";
            this.spdMatOrder_Sheet1.ColumnHeader.Cells.Get(0, 28).Value = "Order Loss Qty";
            this.spdMatOrder_Sheet1.ColumnHeader.Cells.Get(0, 29).Value = "Order Rwk Qty";
            this.spdMatOrder_Sheet1.ColumnHeader.Cells.Get(0, 30).Value = "Create User";
            this.spdMatOrder_Sheet1.ColumnHeader.Cells.Get(0, 31).Value = "Create Time";
            this.spdMatOrder_Sheet1.ColumnHeader.Cells.Get(0, 32).Value = "Update User";
            this.spdMatOrder_Sheet1.ColumnHeader.Cells.Get(0, 33).Value = "Update Time";
            this.spdMatOrder_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdMatOrder_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdMatOrder_Sheet1.Columns.Get(0).Label = "Mat ID";
            this.spdMatOrder_Sheet1.Columns.Get(0).Locked = true;
            this.spdMatOrder_Sheet1.Columns.Get(0).MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Restricted;
            this.spdMatOrder_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMatOrder_Sheet1.Columns.Get(0).Width = 118F;
            this.spdMatOrder_Sheet1.Columns.Get(1).Label = "Mat Ver";
            this.spdMatOrder_Sheet1.Columns.Get(1).Locked = true;
            this.spdMatOrder_Sheet1.Columns.Get(1).MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Restricted;
            this.spdMatOrder_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMatOrder_Sheet1.Columns.Get(1).Width = 100F;
            this.spdMatOrder_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdMatOrder_Sheet1.Columns.Get(2).Label = "Work Date";
            this.spdMatOrder_Sheet1.Columns.Get(2).Locked = true;
            this.spdMatOrder_Sheet1.Columns.Get(2).MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Restricted;
            this.spdMatOrder_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMatOrder_Sheet1.Columns.Get(2).Width = 100F;
            this.spdMatOrder_Sheet1.Columns.Get(3).Label = "Order ID";
            this.spdMatOrder_Sheet1.Columns.Get(3).Locked = true;
            this.spdMatOrder_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMatOrder_Sheet1.Columns.Get(3).Width = 106F;
            this.spdMatOrder_Sheet1.Columns.Get(4).Label = "Order Desc";
            this.spdMatOrder_Sheet1.Columns.Get(4).Locked = true;
            this.spdMatOrder_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMatOrder_Sheet1.Columns.Get(4).Width = 110F;
            this.spdMatOrder_Sheet1.Columns.Get(5).Label = "Flow";
            this.spdMatOrder_Sheet1.Columns.Get(5).Locked = true;
            this.spdMatOrder_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMatOrder_Sheet1.Columns.Get(5).Width = 101F;
            this.spdMatOrder_Sheet1.Columns.Get(6).Label = "Flow Seq Num";
            this.spdMatOrder_Sheet1.Columns.Get(6).Locked = true;
            this.spdMatOrder_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMatOrder_Sheet1.Columns.Get(6).Width = 100F;
            this.spdMatOrder_Sheet1.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdMatOrder_Sheet1.Columns.Get(7).Label = "Order Qty";
            this.spdMatOrder_Sheet1.Columns.Get(7).Locked = true;
            this.spdMatOrder_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMatOrder_Sheet1.Columns.Get(7).Width = 100F;
            this.spdMatOrder_Sheet1.Columns.Get(8).Label = "Res ID";
            this.spdMatOrder_Sheet1.Columns.Get(8).Locked = true;
            this.spdMatOrder_Sheet1.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMatOrder_Sheet1.Columns.Get(8).Width = 115F;
            this.spdMatOrder_Sheet1.Columns.Get(9).Label = "Bom Set ID";
            this.spdMatOrder_Sheet1.Columns.Get(9).Locked = true;
            this.spdMatOrder_Sheet1.Columns.Get(9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMatOrder_Sheet1.Columns.Get(9).Width = 121F;
            this.spdMatOrder_Sheet1.Columns.Get(10).Label = "Bom Set Version";
            this.spdMatOrder_Sheet1.Columns.Get(10).Locked = true;
            this.spdMatOrder_Sheet1.Columns.Get(10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMatOrder_Sheet1.Columns.Get(10).Width = 118F;
            this.spdMatOrder_Sheet1.Columns.Get(11).Label = "Customer ID";
            this.spdMatOrder_Sheet1.Columns.Get(11).Locked = true;
            this.spdMatOrder_Sheet1.Columns.Get(11).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMatOrder_Sheet1.Columns.Get(11).Width = 105F;
            this.spdMatOrder_Sheet1.Columns.Get(12).Label = "Customer Mat ID";
            this.spdMatOrder_Sheet1.Columns.Get(12).Locked = true;
            this.spdMatOrder_Sheet1.Columns.Get(12).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMatOrder_Sheet1.Columns.Get(12).Width = 127F;
            this.spdMatOrder_Sheet1.Columns.Get(13).Label = "Plan Due Time";
            this.spdMatOrder_Sheet1.Columns.Get(13).Locked = true;
            this.spdMatOrder_Sheet1.Columns.Get(13).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMatOrder_Sheet1.Columns.Get(13).Width = 125F;
            this.spdMatOrder_Sheet1.Columns.Get(14).Label = "Plan Start Time";
            this.spdMatOrder_Sheet1.Columns.Get(14).Locked = true;
            this.spdMatOrder_Sheet1.Columns.Get(14).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMatOrder_Sheet1.Columns.Get(14).Width = 125F;
            this.spdMatOrder_Sheet1.Columns.Get(15).Label = "Plan End Time";
            this.spdMatOrder_Sheet1.Columns.Get(15).Locked = true;
            this.spdMatOrder_Sheet1.Columns.Get(15).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMatOrder_Sheet1.Columns.Get(15).Width = 125F;
            this.spdMatOrder_Sheet1.Columns.Get(16).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdMatOrder_Sheet1.Columns.Get(16).Label = "Qty";
            this.spdMatOrder_Sheet1.Columns.Get(16).Locked = true;
            this.spdMatOrder_Sheet1.Columns.Get(16).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMatOrder_Sheet1.Columns.Get(16).Width = 100F;
            this.spdMatOrder_Sheet1.Columns.Get(17).Label = "Lot Type";
            this.spdMatOrder_Sheet1.Columns.Get(17).Locked = true;
            this.spdMatOrder_Sheet1.Columns.Get(17).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMatOrder_Sheet1.Columns.Get(17).Width = 70F;
            this.spdMatOrder_Sheet1.Columns.Get(18).Label = "Owner Code";
            this.spdMatOrder_Sheet1.Columns.Get(18).Locked = true;
            this.spdMatOrder_Sheet1.Columns.Get(18).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMatOrder_Sheet1.Columns.Get(18).Width = 92F;
            this.spdMatOrder_Sheet1.Columns.Get(19).Label = "Create Code";
            this.spdMatOrder_Sheet1.Columns.Get(19).Locked = true;
            this.spdMatOrder_Sheet1.Columns.Get(19).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMatOrder_Sheet1.Columns.Get(19).Width = 86F;
            this.spdMatOrder_Sheet1.Columns.Get(20).Label = "Lot Priority";
            this.spdMatOrder_Sheet1.Columns.Get(20).Locked = true;
            this.spdMatOrder_Sheet1.Columns.Get(20).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMatOrder_Sheet1.Columns.Get(20).Width = 82F;
            this.spdMatOrder_Sheet1.Columns.Get(21).Label = "Org Due Time";
            this.spdMatOrder_Sheet1.Columns.Get(21).Locked = true;
            this.spdMatOrder_Sheet1.Columns.Get(21).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMatOrder_Sheet1.Columns.Get(21).Width = 125F;
            this.spdMatOrder_Sheet1.Columns.Get(22).Label = "Ord Status Flag";
            this.spdMatOrder_Sheet1.Columns.Get(22).Locked = true;
            this.spdMatOrder_Sheet1.Columns.Get(22).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMatOrder_Sheet1.Columns.Get(22).Width = 97F;
            this.spdMatOrder_Sheet1.Columns.Get(23).Label = "Ord Ship Flag";
            this.spdMatOrder_Sheet1.Columns.Get(23).Locked = true;
            this.spdMatOrder_Sheet1.Columns.Get(23).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMatOrder_Sheet1.Columns.Get(23).Width = 98F;
            this.spdMatOrder_Sheet1.Columns.Get(24).Label = "Ord Start Time";
            this.spdMatOrder_Sheet1.Columns.Get(24).Locked = true;
            this.spdMatOrder_Sheet1.Columns.Get(24).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMatOrder_Sheet1.Columns.Get(24).Width = 125F;
            this.spdMatOrder_Sheet1.Columns.Get(25).Label = "Ord End Time";
            this.spdMatOrder_Sheet1.Columns.Get(25).Locked = true;
            this.spdMatOrder_Sheet1.Columns.Get(25).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMatOrder_Sheet1.Columns.Get(25).Width = 125F;
            this.spdMatOrder_Sheet1.Columns.Get(26).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdMatOrder_Sheet1.Columns.Get(26).Label = "Order In Qty";
            this.spdMatOrder_Sheet1.Columns.Get(26).Locked = true;
            this.spdMatOrder_Sheet1.Columns.Get(26).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMatOrder_Sheet1.Columns.Get(26).Width = 100F;
            this.spdMatOrder_Sheet1.Columns.Get(27).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdMatOrder_Sheet1.Columns.Get(27).Label = "Order Out Qty";
            this.spdMatOrder_Sheet1.Columns.Get(27).Locked = true;
            this.spdMatOrder_Sheet1.Columns.Get(27).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMatOrder_Sheet1.Columns.Get(27).Width = 100F;
            this.spdMatOrder_Sheet1.Columns.Get(28).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdMatOrder_Sheet1.Columns.Get(28).Label = "Order Loss Qty";
            this.spdMatOrder_Sheet1.Columns.Get(28).Locked = true;
            this.spdMatOrder_Sheet1.Columns.Get(28).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMatOrder_Sheet1.Columns.Get(28).Width = 100F;
            this.spdMatOrder_Sheet1.Columns.Get(29).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdMatOrder_Sheet1.Columns.Get(29).Label = "Order Rwk Qty";
            this.spdMatOrder_Sheet1.Columns.Get(29).Locked = true;
            this.spdMatOrder_Sheet1.Columns.Get(29).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMatOrder_Sheet1.Columns.Get(29).Width = 100F;
            this.spdMatOrder_Sheet1.Columns.Get(30).Label = "Create User";
            this.spdMatOrder_Sheet1.Columns.Get(30).Locked = true;
            this.spdMatOrder_Sheet1.Columns.Get(30).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMatOrder_Sheet1.Columns.Get(30).Width = 80F;
            this.spdMatOrder_Sheet1.Columns.Get(31).Label = "Create Time";
            this.spdMatOrder_Sheet1.Columns.Get(31).Locked = true;
            this.spdMatOrder_Sheet1.Columns.Get(31).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMatOrder_Sheet1.Columns.Get(31).Width = 125F;
            this.spdMatOrder_Sheet1.Columns.Get(32).Label = "Update User";
            this.spdMatOrder_Sheet1.Columns.Get(32).Locked = true;
            this.spdMatOrder_Sheet1.Columns.Get(32).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMatOrder_Sheet1.Columns.Get(32).Width = 80F;
            this.spdMatOrder_Sheet1.Columns.Get(33).Label = "Update Time";
            this.spdMatOrder_Sheet1.Columns.Get(33).Locked = true;
            this.spdMatOrder_Sheet1.Columns.Get(33).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMatOrder_Sheet1.Columns.Get(33).Width = 125F;
            this.spdMatOrder_Sheet1.FrozenColumnCount = 2;
            this.spdMatOrder_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdMatOrder_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdMatOrder_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdMatOrder_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdMatOrder_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdMatOrder_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdMatOrder_Sheet1.VisualStyles = FarPoint.Win.VisualStyles.Auto;
            this.spdMatOrder_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // cdvActiveStatus
            // 
            this.cdvActiveStatus.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvActiveStatus.BorderHotColor = System.Drawing.Color.Black;
            this.cdvActiveStatus.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvActiveStatus.BtnToolTipText = "";
            this.cdvActiveStatus.DescText = "";
            this.cdvActiveStatus.DisplaySubItemIndex = -1;
            this.cdvActiveStatus.DisplayText = "";
            this.cdvActiveStatus.Focusing = null;
            this.cdvActiveStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvActiveStatus.Index = 0;
            this.cdvActiveStatus.IsViewBtnImage = false;
            this.cdvActiveStatus.Location = new System.Drawing.Point(120, 16);
            this.cdvActiveStatus.MaxLength = 1;
            this.cdvActiveStatus.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvActiveStatus.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvActiveStatus.Name = "cdvActiveStatus";
            this.cdvActiveStatus.ReadOnly = false;
            this.cdvActiveStatus.SearchSubItemIndex = 0;
            this.cdvActiveStatus.SelectedDescIndex = -1;
            this.cdvActiveStatus.SelectedSubItemIndex = -1;
            this.cdvActiveStatus.SelectionStart = 0;
            this.cdvActiveStatus.Size = new System.Drawing.Size(200, 20);
            this.cdvActiveStatus.SmallImageList = null;
            this.cdvActiveStatus.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvActiveStatus.TabIndex = 1;
            this.cdvActiveStatus.TextBoxToolTipText = "";
            this.cdvActiveStatus.TextBoxWidth = 200;
            this.cdvActiveStatus.VisibleButton = true;
            this.cdvActiveStatus.VisibleColumnHeader = false;
            this.cdvActiveStatus.VisibleDescription = false;
            this.cdvActiveStatus.ButtonPress += new System.EventHandler(this.cdvActiveStatus_ButtonPress);
            // 
            // lblActiveStatus
            // 
            this.lblActiveStatus.AutoSize = true;
            this.lblActiveStatus.Location = new System.Drawing.Point(15, 19);
            this.lblActiveStatus.Name = "lblActiveStatus";
            this.lblActiveStatus.Size = new System.Drawing.Size(70, 13);
            this.lblActiveStatus.TabIndex = 0;
            this.lblActiveStatus.Text = "Active Status";
            // 
            // pnlPeriod
            // 
            this.pnlPeriod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
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
            this.cdvMaterial.Location = new System.Drawing.Point(15, 42);
            this.cdvMaterial.MaterialEnabled = true;
            this.cdvMaterial.MaterialReadOnly = false;
            this.cdvMaterial.Name = "cdvMaterial";
            this.cdvMaterial.SearchSubItemIndex = 0;
            this.cdvMaterial.SelectedDescIndex = -1;
            this.cdvMaterial.SelectedSubItemIndex = 0;
            this.cdvMaterial.Size = new System.Drawing.Size(305, 20);
            this.cdvMaterial.TabIndex = 2;
            this.cdvMaterial.VersionEnabled = true;
            this.cdvMaterial.VersionReadOnly = false;
            this.cdvMaterial.VisibleColumnHeader = false;
            this.cdvMaterial.VisibleDescription = false;
            this.cdvMaterial.VisibleMaterialButton = true;
            this.cdvMaterial.VisibleVersionButton = true;
            this.cdvMaterial.WidthButton = 20;
            this.cdvMaterial.WidthLabel = 105;
            this.cdvMaterial.WidthMaterialAndVersion = 200;
            this.cdvMaterial.WidthVersion = 50;
            // 
            // frmORDViewProductionOrder
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Name = "frmORDViewProductionOrder";
            this.Text = "View Production Order";
            this.Activated += new System.EventHandler(this.frmORDViewProductionOrder_Activated);
            this.pnlViewTop.ResumeLayout(false);
            this.grpOption.ResumeLayout(false);
            this.grpOption.PerformLayout();
            this.pnlViewMid.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.tabOrder.ResumeLayout(false);
            this.tbpOrder.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdOrder_Sheet1)).EndInit();
            this.tbpMaterial.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdMatOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdMatOrder_Sheet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvActiveStatus)).EndInit();
            this.pnlPeriod.ResumeLayout(false);
            this.pnlPeriod.PerformLayout();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Constant Definition "
        
        private const int COL_MAT = 0;
        private const int COL_WDATE = 1;
        private const int COL_ORD_QTY = 4;
        private const int COL_QTY = 13;
        private const int COL_ORD_IN = 23;
        private const int COL_ORD_OUT = 24;
        private const int COL_ORD_LOSS = 25;
        private const int COL_ORD_RWK = 26;
        
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
        
        private void CalTotalQty()
        {
            int i;
            
            double dTOQty;
            double dTQty;
            double dTOIQty;
            double dTOOQty;
            double dTOLQty;
            double dTORQty;
            
            double dMTOQty;
            double dMTQty;
            double dMTOIQty;
            double dMTOOQty;
            double dMTOLQty;
            double dMTORQty;
            
            double dTTOQty;
            double dTTQty;
            double dTTOIQty;
            double dTTOOQty;
            double dTTOLQty;
            double dTTORQty;
            
            FarPoint.Win.Spread.SheetView with_1 = spdMatOrder.Sheets[0];
            
            if (with_1.RowCount <= 0)
            {
                return;
            }
            
            i = 0;
            dTOQty = 0;
            dTQty = 0;
            dTOIQty = 0;
            dTOOQty = 0;
            dTOLQty = 0;
            dTORQty = 0;
            
            dMTOQty = 0;
            dMTQty = 0;
            dMTOIQty = 0;
            dMTOOQty = 0;
            dMTOLQty = 0;
            dMTORQty = 0;
            
            dTTOQty = 0;
            dTTQty = 0;
            dTTOIQty = 0;
            dTTOOQty = 0;
            dTTOLQty = 0;
            dTTORQty = 0;
            
            while (i < with_1.RowCount - 1)
            {
                dTOQty += MPCF.ToDbl(with_1.Cells[i, COL_ORD_QTY].Value);
                dTQty += MPCF.ToDbl(with_1.Cells[i, COL_QTY].Value);
                dTOIQty += MPCF.ToDbl(with_1.Cells[i, COL_ORD_IN].Value);
                dTOOQty += MPCF.ToDbl(with_1.Cells[i, COL_ORD_OUT].Value);
                dTOLQty += MPCF.ToDbl(with_1.Cells[i, COL_ORD_LOSS].Value);
                dTORQty += MPCF.ToDbl(with_1.Cells[i, COL_ORD_RWK].Value);
                
                if (with_1.Cells[i, COL_MAT].Text == with_1.Cells[i + 1, COL_MAT].Text)
                {
                    if (with_1.Cells[i, COL_WDATE].Text == with_1.Cells[i + 1, COL_WDATE].Text)
                    {
                        i++;
                    }
                    else
                    {
                        with_1.AddRows(i + 1, 1);
                        with_1.Cells[i + 1, COL_MAT].Value = with_1.Cells[i, COL_MAT].Value;
                        with_1.Cells[i + 1, COL_WDATE].Value = "DATE TOTAL";
                        with_1.Rows[i + 1].BackColor = Color.LightGoldenrodYellow;
                        with_1.Cells[i + 1, COL_ORD_QTY].Value = MPCF.Format("######,##0.###", dTOQty);
                        with_1.Cells[i + 1, COL_QTY].Value = MPCF.Format("######,##0.###", dTQty);
                        with_1.Cells[i + 1, COL_ORD_IN].Value = MPCF.Format("######,##0.###", dTOIQty);
                        with_1.Cells[i + 1, COL_ORD_OUT].Value = MPCF.Format("######,##0.###", dTOOQty);
                        with_1.Cells[i + 1, COL_ORD_LOSS].Value = MPCF.Format("######,##0.###", dTOLQty);
                        with_1.Cells[i + 1, COL_ORD_RWK].Value = MPCF.Format("######,##0.###", dTORQty);
                        
                        dMTOQty += dTOQty;
                        dMTQty += dTQty;
                        dMTOIQty += dTOIQty;
                        dMTOOQty += dTOOQty;
                        dMTOLQty += dTOLQty;
                        dMTORQty += dTORQty;
                        
                        i += 2;
                        
                        dTOQty = 0;
                        
                        dTQty = 0;
                        dTOIQty = 0;
                        dTOOQty = 0;
                        dTOLQty = 0;
                        dTORQty = 0;
                    }
                }
                else
                {
                    with_1.AddRows(i + 1, 1);
                    with_1.Cells[i + 1, COL_MAT].Value = with_1.Cells[i, COL_MAT].Value;
                    with_1.Cells[i + 1, COL_WDATE].Value = "DATE TOTAL";
                    with_1.Rows[i + 1].BackColor = Color.LightGoldenrodYellow;
                    with_1.Cells[i + 1, COL_ORD_QTY].Value = MPCF.Format("######,##0.###", dTOQty);
                    with_1.Cells[i + 1, COL_QTY].Value = MPCF.Format("######,##0.###", dTQty);
                    with_1.Cells[i + 1, COL_ORD_IN].Value = MPCF.Format("######,##0.###", dTOIQty);
                    with_1.Cells[i + 1, COL_ORD_OUT].Value = MPCF.Format("######,##0.###", dTOOQty);
                    with_1.Cells[i + 1, COL_ORD_LOSS].Value = MPCF.Format("######,##0.###", dTOLQty);
                    with_1.Cells[i + 1, COL_ORD_RWK].Value = MPCF.Format("######,##0.###", dTORQty);
                    
                    dMTOQty += dTOQty;
                    dMTQty += dTQty;
                    dMTOIQty += dTOIQty;
                    dMTOOQty += dTOOQty;
                    dMTOLQty += dTOLQty;
                    dMTORQty += dTORQty;
                    dTOQty = 0;
                    
                    dTQty = 0;
                    dTOIQty = 0;
                    dTOOQty = 0;
                    dTOLQty = 0;
                    dTORQty = 0;
                    
                    with_1.AddRows(i + 2, 1);
                    with_1.Cells[i + 2, COL_MAT].Value = "MAT TOTAL";
                    with_1.Rows[i + 2].BackColor = Color.Gainsboro;
                    with_1.Cells[i + 2, COL_ORD_QTY].Value = MPCF.Format("######,##0.###", dMTOQty);
                    with_1.Cells[i + 2, COL_QTY].Value = MPCF.Format("######,##0.###", dMTQty);
                    with_1.Cells[i + 2, COL_ORD_IN].Value = MPCF.Format("######,##0.###", dMTOIQty);
                    with_1.Cells[i + 2, COL_ORD_OUT].Value = MPCF.Format("######,##0.###", dMTOOQty);
                    with_1.Cells[i + 2, COL_ORD_LOSS].Value = MPCF.Format("######,##0.###", dMTOLQty);
                    with_1.Cells[i + 2, COL_ORD_RWK].Value = MPCF.Format("######,##0.###", dMTORQty);
                    
                    dTTOQty += dMTOQty;
                    dTTQty += dMTQty;
                    dTTOIQty += dMTOIQty;
                    dTTOOQty += dMTOOQty;
                    dTTOLQty += dMTOLQty;
                    dTTORQty += dMTORQty;
                    dMTOQty = 0;
                    
                    dMTQty = 0;
                    dMTOIQty = 0;
                    dMTOOQty = 0;
                    dMTOLQty = 0;
                    dMTORQty = 0;
                    
                    i += 3;
                }
            }
            
            dTOQty += MPCF.ToDbl(with_1.Cells[i, COL_ORD_QTY].Value);
            dTQty += MPCF.ToDbl(with_1.Cells[i, COL_QTY].Value);
            dTOIQty += MPCF.ToDbl(with_1.Cells[i, COL_ORD_IN].Value);
            dTOOQty += MPCF.ToDbl(with_1.Cells[i, COL_ORD_OUT].Value);
            dTOLQty += MPCF.ToDbl(with_1.Cells[i, COL_ORD_LOSS].Value);
            dTORQty += MPCF.ToDbl(with_1.Cells[i, COL_ORD_RWK].Value);
            
            i = with_1.RowCount;
            with_1.RowCount++;
            
            with_1.Cells[i, COL_MAT].Value = with_1.Cells[i - 1, COL_MAT].Value;
            with_1.Cells[i, COL_WDATE].Value = "DATE TOTAL";
            with_1.Rows[i].BackColor = Color.LightGoldenrodYellow;
            with_1.Cells[i, COL_ORD_QTY].Value = MPCF.Format("######,##0.###", dTOQty);
            with_1.Cells[i, COL_QTY].Value = MPCF.Format("######,##0.###", dTQty);
            with_1.Cells[i, COL_ORD_IN].Value = MPCF.Format("######,##0.###", dTOIQty);
            with_1.Cells[i, COL_ORD_OUT].Value = MPCF.Format("######,##0.###", dTOOQty);
            with_1.Cells[i, COL_ORD_LOSS].Value = MPCF.Format("######,##0.###", dTOLQty);
            with_1.Cells[i, COL_ORD_RWK].Value = MPCF.Format("######,##0.###", dTORQty);
            
            dMTOQty += dTOQty;
            dMTQty += dTQty;
            dMTOIQty += dTOIQty;
            dMTOOQty += dTOOQty;
            dMTOLQty += dTOLQty;
            dMTORQty += dTORQty;
            
            
            i = with_1.RowCount;
            with_1.RowCount++;
            
            with_1.Cells[i, COL_MAT].Value = "MAT TOTAL";
            with_1.Rows[i].BackColor = Color.Gainsboro;
            with_1.Cells[i, COL_ORD_QTY].Value = MPCF.Format("######,##0.###", dMTOQty);
            with_1.Cells[i, COL_QTY].Value = MPCF.Format("######,##0.###", dMTQty);
            with_1.Cells[i, COL_ORD_IN].Value = MPCF.Format("######,##0.###", dMTOIQty);
            with_1.Cells[i, COL_ORD_OUT].Value = MPCF.Format("######,##0.###", dMTOOQty);
            with_1.Cells[i, COL_ORD_LOSS].Value = MPCF.Format("######,##0.###", dMTOLQty);
            with_1.Cells[i, COL_ORD_RWK].Value = MPCF.Format("######,##0.###", dMTORQty);
            
            dTTOQty += dMTOQty;
            dTTQty += dMTQty;
            dTTOIQty += dMTOIQty;
            dTTOOQty += dMTOOQty;
            dTTOLQty += dMTOLQty;
            dTTORQty += dMTORQty;
            
            
            i = with_1.RowCount;
            with_1.RowCount++;
            
            with_1.Cells[i, 0].Value = "TOTAL";
            with_1.Rows[i].BackColor = Color.LightSteelBlue;
            with_1.Cells[i, COL_ORD_QTY].Value = MPCF.Format("######,##0.###", dTTOQty);
            with_1.Cells[i, COL_QTY].Value = MPCF.Format("######,##0.###", dTTQty);
            with_1.Cells[i, COL_ORD_IN].Value = MPCF.Format("######,##0.###", dTTOIQty);
            with_1.Cells[i, COL_ORD_OUT].Value = MPCF.Format("######,##0.###", dTTOOQty);
            with_1.Cells[i, COL_ORD_LOSS].Value = MPCF.Format("######,##0.###", dTTOLQty);
            with_1.Cells[i, COL_ORD_RWK].Value = MPCF.Format("######,##0.###", dTTORQty);
            
            
            
        }
        
        // View_Order_List_Detail()
        //       - View all Flow List
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal control As Control                    : Listê°€ ?¤ì–´ê°?control
        //        - ByVal c_step As String                        : ?•ìž¥ Process Step
        //        - Optional ByVal sFilter As String = ""        : sFilterë¡??œìž‘?˜ëŠ” Flow
        //        - Optional ByVal sOper As String = ""        : sOperë¥?ê°€ì§?Flow
        //        - Optional ByVal sMaterial As String = ""    : sMaterialë¥?ê°€ì§?Flow
        //        - Optional ByVal sTreeItem As String = ""    : TreeView ?ì„œ ì¶”ê???Node??Text
        //        - Optional ByVal sExt_Factory As String = "" : ?„ìž¬ Factoryê°€ ?„ë‹Œê²½ìš°???€??Factory
        //
        private bool View_Order_List_Detail()
        {
            
            FarPoint.Win.Spread.SheetView shtOrder;
            FarPoint.Win.Spread.SheetView shtMat;
            int i;
            int iRow;
            int iCol;

            MPCF.ClearList(spdOrder, true);
            MPCF.ClearList(spdMatOrder, true);
            
            TRSNode in_node = new TRSNode("View_Order_List_Detail_In");
            TRSNode out_node = new TRSNode("View_Order_List_Detail_Out");
            TRSNode order_list;
            
            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("FROM_DATE", MPCF.FromDate(dtpFrom));
            in_node.AddString("TO_DATE", MPCF.ToDate(dtpTo));
            in_node.AddChar("ORD_STATUS_FLAG", MPCF.ToChar(MPCF.Trim(cdvActiveStatus.Text)));
            in_node.AddString("MAT_ID", MPCF.Trim(cdvMaterial.Text));
            in_node.AddInt("MAT_VER", cdvMaterial.Version);
            in_node.AddString("MAT_TYPE", "");
            in_node.AddString("MAT_GRP", "");
            
            shtOrder = spdOrder.Sheets[0];
            shtMat = spdMatOrder.Sheets[0];
            
            do
            {
                if (MPCR.CallService("ORD", "ORD_View_Order_List_Detail", in_node, ref out_node) == false)
                {
                    return false;
                }
                
                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    order_list = out_node.GetList(0)[i];

                    iRow = shtOrder.RowCount;
                    
                    shtOrder.RowCount++;
                    shtMat.RowCount++;
                    
                    iCol = 0;

                    shtOrder.Cells[iRow, iCol].Value = MakeDate(order_list.GetString("WORK_DATE"));
                    shtMat.Cells[iRow, iCol].Value = MPCF.Trim(order_list.GetString("MAT_ID"));
                    
                    iCol++;
                    shtOrder.Cells[iRow, iCol].Value = MPCF.Trim(order_list.GetString("ORDER_ID"));
                    shtMat.Cells[iRow, iCol].Value = MPCF.Trim(order_list.GetInt("MAT_VER"));

                    iCol++;
                    shtOrder.Cells[iRow, iCol].Value = MPCF.Trim(order_list.GetString("ORDER_DESC"));
                    shtMat.Cells[iRow, iCol].Value = MakeDate(order_list.GetString("WORK_DATE"));

                    iCol++;
                    shtOrder.Cells[iRow, iCol].Value = MPCF.Trim(order_list.GetString("MAT_ID"));
                    shtMat.Cells[iRow, iCol].Value = MPCF.Trim(order_list.GetString("ORDER_ID"));

                    iCol++;
                    shtOrder.Cells[iRow, iCol].Value = MPCF.Trim(order_list.GetInt("MAT_VER"));
                    shtMat.Cells[iRow, iCol].Value = MPCF.Trim(order_list.GetString("ORDER_DESC"));
                    
                    iCol++;
                    shtOrder.Cells[iRow, iCol].Value = MPCF.Trim(order_list.GetString("FLOW"));
                    shtMat.Cells[iRow, iCol].Value = MPCF.Trim(order_list.GetString("FLOW"));

                    iCol++;
                    shtOrder.Cells[iRow, iCol].Value = MPCF.Trim(order_list.GetInt("FLOW_SEQ_NUM"));
                    shtMat.Cells[iRow, iCol].Value = MPCF.Trim(order_list.GetInt("FLOW_SEQ_NUM"));
                    
                    iCol++;
                    shtOrder.Cells[iRow, iCol].Value = MPCF.Format("#####,##0.###", order_list.GetDouble("ORD_QTY"));
                    shtMat.Cells[iRow, iCol].Value = MPCF.Format("#####,##0.###", order_list.GetDouble("ORD_QTY"));
                    
                    iCol++;
                    shtOrder.Cells[iRow, iCol].Value = MPCF.Trim(order_list.GetString("RES_ID"));
                    shtMat.Cells[iRow, iCol].Value = MPCF.Trim(order_list.GetString("RES_ID"));
                    
                    iCol++;
                    shtOrder.Cells[iRow, iCol].Value = MPCF.Trim(order_list.GetString("BOM_SET_ID"));
                    shtMat.Cells[iRow, iCol].Value = MPCF.Trim(order_list.GetString("BOM_SET_ID"));
                    
                    iCol++;
                    shtOrder.Cells[iRow, iCol].Value = MPCF.Trim(order_list.GetInt("BOM_SET_VERSION"));
                    shtMat.Cells[iRow, iCol].Value = MPCF.Trim(order_list.GetInt("BOM_SET_VERSION"));
                    
                    iCol++;
                    shtOrder.Cells[iRow, iCol].Value = MPCF.Trim(order_list.GetString("CUSTOMER_ID"));
                    shtMat.Cells[iRow, iCol].Value = MPCF.Trim(order_list.GetString("CUSTOMER_ID"));
                    
                    iCol++;
                    shtOrder.Cells[iRow, iCol].Value = MPCF.Trim(order_list.GetString("CUSTOMER_MAT_ID"));
                    shtMat.Cells[iRow, iCol].Value = MPCF.Trim(order_list.GetString("CUSTOMER_MAT_ID"));
                    
                    iCol++;
                    shtOrder.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(order_list.GetString("PLAN_DUE_TIME"));
                    shtMat.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(order_list.GetString("PLAN_DUE_TIME"));
                    
                    iCol++;
                    shtOrder.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(order_list.GetString("PLAN_START_TIME"));
                    shtMat.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(order_list.GetString("PLAN_START_TIME"));
                    
                    iCol++;
                    shtOrder.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(order_list.GetString("PLAN_END_TIME"));
                    shtMat.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(order_list.GetString("PLAN_END_TIME"));
                    
                    iCol++;
                    shtOrder.Cells[iRow, iCol].Value = MPCF.Format("#####,##0.###", order_list.GetDouble("QTY"));
                    shtMat.Cells[iRow, iCol].Value = MPCF.Format("#####,##0.###", order_list.GetDouble("QTY"));
                    
                    iCol++;
                    shtOrder.Cells[iRow, iCol].Value = MPCF.Trim(order_list.GetChar("LOT_TYPE"));
                    shtMat.Cells[iRow, iCol].Value = MPCF.Trim(order_list.GetChar("LOT_TYPE"));
                    
                    iCol++;
                    shtOrder.Cells[iRow, iCol].Value = MPCF.Trim(order_list.GetString("OWNER_CODE"));
                    shtMat.Cells[iRow, iCol].Value = MPCF.Trim(order_list.GetString("OWNER_CODE"));
                    
                    iCol++;
                    shtOrder.Cells[iRow, iCol].Value = MPCF.Trim(order_list.GetString("CREATE_CODE"));
                    shtMat.Cells[iRow, iCol].Value = MPCF.Trim(order_list.GetString("CREATE_CODE"));
                    
                    iCol++;
                    shtOrder.Cells[iRow, iCol].Value = MPCF.Trim(order_list.GetChar("LOT_PRIORITY"));
                    shtMat.Cells[iRow, iCol].Value = MPCF.Trim(order_list.GetChar("LOT_PRIORITY"));
                    
                    iCol++;
                    shtOrder.Cells[iRow, iCol].Value = MakeDate(order_list.GetString("ORG_DUE_TIME"));
                    shtMat.Cells[iRow, iCol].Value = MakeDate(order_list.GetString("ORG_DUE_TIME"));
                    
                    iCol++;
                    shtOrder.Cells[iRow, iCol].Value = MPCF.Trim(order_list.GetChar("ORD_STATUS_FLAG"));
                    shtMat.Cells[iRow, iCol].Value = MPCF.Trim(order_list.GetChar("ORD_STATUS_FLAG"));
                    
                    iCol++;
                    shtOrder.Cells[iRow, iCol].Value = MPCF.Trim(order_list.GetChar("ORD_SHIP_FLAG"));
                    shtMat.Cells[iRow, iCol].Value = MPCF.Trim(order_list.GetChar("ORD_SHIP_FLAG"));
                    
                    iCol++;
                    shtOrder.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(order_list.GetString("ORD_START_TIME"));
                    shtMat.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(order_list.GetString("ORD_START_TIME"));
                    
                    iCol++;
                    shtOrder.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(order_list.GetString("ORD_END_TIME"));
                    shtMat.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(order_list.GetString("ORD_END_TIME"));
                    
                    iCol++;
                    shtOrder.Cells[iRow, iCol].Value = MPCF.Format("#####,##0.###", order_list.GetDouble("ORD_IN_QTY"));
                    shtMat.Cells[iRow, iCol].Value = MPCF.Format("#####,##0.###", order_list.GetDouble("ORD_IN_QTY"));
                    
                    iCol++;
                    shtOrder.Cells[iRow, iCol].Value = MPCF.Format("#####,##0.###", order_list.GetDouble("ORD_OUT_QTY"));
                    shtMat.Cells[iRow, iCol].Value = MPCF.Format("#####,##0.###", order_list.GetDouble("ORD_OUT_QTY"));
                    
                    iCol++;
                    shtOrder.Cells[iRow, iCol].Value = MPCF.Format("#####,##0.###", order_list.GetDouble("ORD_LOSS_QTY"));
                    shtMat.Cells[iRow, iCol].Value = MPCF.Format("#####,##0.###", order_list.GetDouble("ORD_LOSS_QTY"));
                    
                    iCol++;
                    shtOrder.Cells[iRow, iCol].Value = MPCF.Format("#####,##0.###", order_list.GetDouble("ORD_RWK_QTY"));
                    shtMat.Cells[iRow, iCol].Value = MPCF.Format("#####,##0.###", order_list.GetDouble("ORD_RWK_QTY"));
                    
                    iCol++;
                    shtOrder.Cells[iRow, iCol].Value = MPCF.Trim(order_list.GetString("CREATE_USER_ID"));
                    shtMat.Cells[iRow, iCol].Value = MPCF.Trim(order_list.GetString("CREATE_USER_ID"));
                    
                    iCol++;
                    shtOrder.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(order_list.GetString("CREATE_TIME"));
                    shtMat.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(order_list.GetString("CREATE_TIME"));
                    
                    iCol++;
                    shtOrder.Cells[iRow, iCol].Value = MPCF.Trim(order_list.GetString("UPDATE_USER_ID"));
                    shtMat.Cells[iRow, iCol].Value = MPCF.Trim(order_list.GetString("UPDATE_USER_ID"));
                    
                    iCol++;
                    shtOrder.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(order_list.GetString("UPDATE_TIME"));
                    shtMat.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(order_list.GetString("UPDATE_TIME"));
                    
                    iCol++;
                    
                }

                //View_Order_List_Detail_In.next_order_id = View_Order_List_Detail_Out.next_order_id;
                in_node.SetString("NEXT_ORDER_ID", out_node.GetString("NEXT_ORDER_ID"));

            } while (in_node.GetString("NEXT_ORDER_ID") != "");
            
            FarPoint.Win.Spread.SortInfo[] sort = new FarPoint.Win.Spread.SortInfo[4];
            sort[0] = new FarPoint.Win.Spread.SortInfo(0, true);
            sort[1] = new FarPoint.Win.Spread.SortInfo(1, true);
            sort[2] = new FarPoint.Win.Spread.SortInfo(2, true);
            sort[3] = new FarPoint.Win.Spread.SortInfo(3, true);
            
            shtOrder.SortRows(0, shtOrder.RowCount, sort);
            shtMat.SortRows(0, shtMat.RowCount, sort);
            
            CalTotalQty();
            
            MPCF.FitColumnHeader(spdOrder);
            MPCF.FitColumnHeader(spdMatOrder);
            
            return true;
            
        }
        
        public virtual Control GetFisrtFocusItem()
        {
            
            try
            {
                return this.cdvActiveStatus;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }
            
        }
        
        #endregion
        
        private void frmORDViewProductionOrder_Activated(object sender, System.EventArgs e)
        {
            if (b_load_flag == false)
            {
                
                MPCF.FieldClear(this);
                MPCF.ClearList(spdOrder, true);
                MPCF.ClearList(spdMatOrder, true);
                MPCF.FitColumnHeader(spdOrder);
                MPCF.FitColumnHeader(spdMatOrder);
                
                dtpFrom.Value = DateTime.Today.AddMonths(- 1);
                dtpTo.Value = DateTime.Today;
                
                b_load_flag = true;
            }
            
        }
        
        private void btnView_Click(System.Object sender, System.EventArgs e)
        {
            if (CheckCondition("VIEW") == false)
            {
                return;
            }
            View_Order_List_Detail();
        }
        
        private void spdOrder_AutoSortedColumn(object sender, FarPoint.Win.Spread.AutoSortedColumnEventArgs e)
        {
            FarPoint.Win.Spread.SortInfo[] sort = new FarPoint.Win.Spread.SortInfo[4];
            
            if (e.Column == 0)
            {
                sort[0] = new FarPoint.Win.Spread.SortInfo(0, e.Ascending);
                sort[1] = new FarPoint.Win.Spread.SortInfo(1, true);
                sort[2] = new FarPoint.Win.Spread.SortInfo(2, true);
                sort[3] = new FarPoint.Win.Spread.SortInfo(3, true);
            }
            else if (e.Column == 1)
            {
                sort[0] = new FarPoint.Win.Spread.SortInfo(1, e.Ascending);
                sort[1] = new FarPoint.Win.Spread.SortInfo(0, true);
                sort[2] = new FarPoint.Win.Spread.SortInfo(2, true);
                sort[3] = new FarPoint.Win.Spread.SortInfo(3, true);
            }
            else
            {
                sort[0] = new FarPoint.Win.Spread.SortInfo(e.Column, e.Ascending);
                sort[1] = new FarPoint.Win.Spread.SortInfo(0, true);
                sort[2] = new FarPoint.Win.Spread.SortInfo(1, true);
                sort[3] = new FarPoint.Win.Spread.SortInfo(2, true);
            }
            
            spdOrder.Sheets[0].SortRows(0, spdOrder.Sheets[0].RowCount, sort);
            
        }
        
        private void btnExcel_Click(System.Object sender, System.EventArgs e)
        {
            string sCond;
            FarPoint.Win.Spread.FpSpread spdData = null;
            
            if (tabOrder.SelectedTab == tbpOrder)
            {
                spdData = spdOrder;
            }
            else if (tabOrder.SelectedTab == tbpMaterial)
            {
                spdData = spdMatOrder;
            }

            sCond = "Date : " + MPCF.MakeDateFormat(MPCF.FromDate(dtpFrom)) + " ~ " + MPCF.MakeDateFormat(MPCF.ToDate(dtpTo));
            MPCF.ExportToExcel(spdData, this.Text, sCond);
            
        }
        
        //private void cdvMaterial_MaterialButtonPress(object sender, System.EventArgs e)
        //{
        //    cdvMaterial.Init();
        //    MPCF.InitListView(cdvMaterial.MaterialGetListView);
        //    cdvMaterial.MaterialColumns.Add("Material", 50, HorizontalAlignment.Left);
        //    cdvMaterial.MaterialColumns.Add("Desc", 100, HorizontalAlignment.Left);
        //    cdvMaterial.SelectedSubItemIndex = 0;
        //    WIPLIST.ViewMaterialList(cdvMaterial.MaterialGetListView, '1');
        //}
        
        private void cdvActiveStatus_ButtonPress(object sender, System.EventArgs e)
        {
            cdvActiveStatus.Init();
            MPCF.InitListView(cdvActiveStatus.GetListView);
            cdvActiveStatus.Columns.Add("Status", 50, HorizontalAlignment.Left);
            cdvActiveStatus.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvActiveStatus.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMDataList(cdvActiveStatus.GetListView, '1', MPGC.MP_WIP_ORDER_STATUS);
        }
    }
    //#End If
}
