
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
//   File Name   : frmORDViewProductionPlan.vb
//   Description : MES Cient Form View Production Plan
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
    public class frmORDViewPlannedLot : Miracom.MESCore.ViewForm01
    {
        
        #region " Windows Form auto generated code "
        
        public frmORDViewPlannedLot()
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
        


        //ì½”ë“œ ?¸ì§‘ê¸°ë? ?¬ìš©?˜ì—¬ ?˜ì •?˜ì? ë§ˆì‹­?œì˜¤.
        private System.Windows.Forms.TabPage tbpLot;
        private System.Windows.Forms.TabPage tbpMaterial;
        private FarPoint.Win.Spread.FpSpread spdPlannedLot;
        private FarPoint.Win.Spread.SheetView spdPlannedLot_Sheet1;
        private FarPoint.Win.Spread.FpSpread spdMatPlannedLot;
        private FarPoint.Win.Spread.SheetView spdMatPlannedLot_Sheet1;
        private System.Windows.Forms.Panel pnlPeriod;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label lblPeriod;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label lblTo;
        private Miracom.MESCore.Controls.udcMaterial cdvMaterial;
        private System.Windows.Forms.TabControl tabPlannedLot;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer3 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer4 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            this.tabPlannedLot = new System.Windows.Forms.TabControl();
            this.tbpLot = new System.Windows.Forms.TabPage();
            this.spdPlannedLot = new FarPoint.Win.Spread.FpSpread();
            this.spdPlannedLot_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.tbpMaterial = new System.Windows.Forms.TabPage();
            this.spdMatPlannedLot = new FarPoint.Win.Spread.FpSpread();
            this.spdMatPlannedLot_Sheet1 = new FarPoint.Win.Spread.SheetView();
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
            this.tabPlannedLot.SuspendLayout();
            this.tbpLot.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdPlannedLot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdPlannedLot_Sheet1)).BeginInit();
            this.tbpMaterial.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdMatPlannedLot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdMatPlannedLot_Sheet1)).BeginInit();
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
            // pnlViewTop
            // 
            this.pnlViewTop.Size = new System.Drawing.Size(742, 47);
            // 
            // grpOption
            // 
            this.grpOption.Controls.Add(this.cdvMaterial);
            this.grpOption.Controls.Add(this.pnlPeriod);
            this.grpOption.Size = new System.Drawing.Size(742, 47);
            // 
            // pnlViewMid
            // 
            this.pnlViewMid.Controls.Add(this.tabPlannedLot);
            this.pnlViewMid.Location = new System.Drawing.Point(0, 47);
            this.pnlViewMid.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.pnlViewMid.Size = new System.Drawing.Size(742, 466);
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
            this.lblFormTitle.Text = "View Planned Lot";
            // 
            // tabPlannedLot
            // 
            this.tabPlannedLot.Controls.Add(this.tbpLot);
            this.tabPlannedLot.Controls.Add(this.tbpMaterial);
            this.tabPlannedLot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPlannedLot.ItemSize = new System.Drawing.Size(60, 18);
            this.tabPlannedLot.Location = new System.Drawing.Point(0, 3);
            this.tabPlannedLot.Name = "tabPlannedLot";
            this.tabPlannedLot.SelectedIndex = 0;
            this.tabPlannedLot.Size = new System.Drawing.Size(742, 463);
            this.tabPlannedLot.TabIndex = 0;
            // 
            // tbpLot
            // 
            this.tbpLot.Controls.Add(this.spdPlannedLot);
            this.tbpLot.Location = new System.Drawing.Point(4, 22);
            this.tbpLot.Name = "tbpLot";
            this.tbpLot.Size = new System.Drawing.Size(734, 437);
            this.tbpLot.TabIndex = 0;
            this.tbpLot.Text = "Lot ID";
            // 
            // spdPlannedLot
            // 
            this.spdPlannedLot.AccessibleDescription = "spdPlannedLot, Sheet1, Row 0, Column 0, ";
            this.spdPlannedLot.BackColor = System.Drawing.SystemColors.Control;
            this.spdPlannedLot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdPlannedLot.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdPlannedLot.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdPlannedLot.HorizontalScrollBar.Name = "";
            this.spdPlannedLot.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdPlannedLot.HorizontalScrollBar.TabIndex = 2;
            this.spdPlannedLot.Location = new System.Drawing.Point(0, 0);
            this.spdPlannedLot.Name = "spdPlannedLot";
            this.spdPlannedLot.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdPlannedLot.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdPlannedLot.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdPlannedLot_Sheet1});
            this.spdPlannedLot.Size = new System.Drawing.Size(734, 437);
            this.spdPlannedLot.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdPlannedLot.TabIndex = 0;
            this.spdPlannedLot.TabStop = false;
            this.spdPlannedLot.TextTipDelay = 200;
            this.spdPlannedLot.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdPlannedLot.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdPlannedLot.VerticalScrollBar.Name = "";
            this.spdPlannedLot.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdPlannedLot.VerticalScrollBar.TabIndex = 3;
            this.spdPlannedLot.SetViewportLeftColumn(0, 0, 2);
            this.spdPlannedLot.SetActiveViewport(0, 0, -1);
            // 
            // spdPlannedLot_Sheet1
            // 
            this.spdPlannedLot_Sheet1.Reset();
            spdPlannedLot_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdPlannedLot_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdPlannedLot_Sheet1.ColumnCount = 24;
            spdPlannedLot_Sheet1.RowCount = 5;
            this.spdPlannedLot_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdPlannedLot_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdPlannedLot_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdPlannedLot_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdPlannedLot_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Work Date";
            this.spdPlannedLot_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Lot ID";
            this.spdPlannedLot_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Lot Desc";
            this.spdPlannedLot_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Mat ID";
            this.spdPlannedLot_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Mat Ver";
            this.spdPlannedLot_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Flow";
            this.spdPlannedLot_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Flow Seq Num";
            this.spdPlannedLot_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "Oper";
            this.spdPlannedLot_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "Qty 1";
            this.spdPlannedLot_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "Qty 2";
            this.spdPlannedLot_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "Qty 3";
            this.spdPlannedLot_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "Lot Type";
            this.spdPlannedLot_Sheet1.ColumnHeader.Cells.Get(0, 12).Value = "Owner Code";
            this.spdPlannedLot_Sheet1.ColumnHeader.Cells.Get(0, 13).Value = "Create Code";
            this.spdPlannedLot_Sheet1.ColumnHeader.Cells.Get(0, 14).Value = "Priority";
            this.spdPlannedLot_Sheet1.ColumnHeader.Cells.Get(0, 15).Value = "Org Due Date";
            this.spdPlannedLot_Sheet1.ColumnHeader.Cells.Get(0, 16).Value = "Res ID";
            this.spdPlannedLot_Sheet1.ColumnHeader.Cells.Get(0, 17).Value = "Order ID";
            this.spdPlannedLot_Sheet1.ColumnHeader.Cells.Get(0, 18).Value = "Lot Create Flag";
            this.spdPlannedLot_Sheet1.ColumnHeader.Cells.Get(0, 19).Value = "Lot Create Time";
            this.spdPlannedLot_Sheet1.ColumnHeader.Cells.Get(0, 20).Value = "Create User";
            this.spdPlannedLot_Sheet1.ColumnHeader.Cells.Get(0, 21).Value = "Create Time";
            this.spdPlannedLot_Sheet1.ColumnHeader.Cells.Get(0, 22).Value = "Update User";
            this.spdPlannedLot_Sheet1.ColumnHeader.Cells.Get(0, 23).Value = "Update Time";
            this.spdPlannedLot_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdPlannedLot_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdPlannedLot_Sheet1.ColumnHeader.Rows.Get(0).Height = 18F;
            this.spdPlannedLot_Sheet1.Columns.Get(0).Label = "Work Date";
            this.spdPlannedLot_Sheet1.Columns.Get(0).Locked = true;
            this.spdPlannedLot_Sheet1.Columns.Get(0).MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Restricted;
            this.spdPlannedLot_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdPlannedLot_Sheet1.Columns.Get(0).Width = 86F;
            this.spdPlannedLot_Sheet1.Columns.Get(1).Label = "Lot ID";
            this.spdPlannedLot_Sheet1.Columns.Get(1).Locked = true;
            this.spdPlannedLot_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdPlannedLot_Sheet1.Columns.Get(1).Width = 110F;
            this.spdPlannedLot_Sheet1.Columns.Get(2).Label = "Lot Desc";
            this.spdPlannedLot_Sheet1.Columns.Get(2).Locked = true;
            this.spdPlannedLot_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdPlannedLot_Sheet1.Columns.Get(2).Width = 223F;
            this.spdPlannedLot_Sheet1.Columns.Get(3).Label = "Mat ID";
            this.spdPlannedLot_Sheet1.Columns.Get(3).Locked = true;
            this.spdPlannedLot_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdPlannedLot_Sheet1.Columns.Get(3).Width = 109F;
            this.spdPlannedLot_Sheet1.Columns.Get(4).Label = "Mat Ver";
            this.spdPlannedLot_Sheet1.Columns.Get(4).Locked = true;
            this.spdPlannedLot_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdPlannedLot_Sheet1.Columns.Get(5).Label = "Flow";
            this.spdPlannedLot_Sheet1.Columns.Get(5).Locked = true;
            this.spdPlannedLot_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdPlannedLot_Sheet1.Columns.Get(5).Width = 92F;
            this.spdPlannedLot_Sheet1.Columns.Get(6).Label = "Flow Seq Num";
            this.spdPlannedLot_Sheet1.Columns.Get(6).Locked = true;
            this.spdPlannedLot_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdPlannedLot_Sheet1.Columns.Get(6).Width = 100F;
            this.spdPlannedLot_Sheet1.Columns.Get(7).Label = "Oper";
            this.spdPlannedLot_Sheet1.Columns.Get(7).Locked = true;
            this.spdPlannedLot_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdPlannedLot_Sheet1.Columns.Get(7).Width = 77F;
            this.spdPlannedLot_Sheet1.Columns.Get(8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdPlannedLot_Sheet1.Columns.Get(8).Label = "Qty 1";
            this.spdPlannedLot_Sheet1.Columns.Get(8).Locked = true;
            this.spdPlannedLot_Sheet1.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdPlannedLot_Sheet1.Columns.Get(9).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdPlannedLot_Sheet1.Columns.Get(9).Label = "Qty 2";
            this.spdPlannedLot_Sheet1.Columns.Get(9).Locked = true;
            this.spdPlannedLot_Sheet1.Columns.Get(9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdPlannedLot_Sheet1.Columns.Get(10).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdPlannedLot_Sheet1.Columns.Get(10).Label = "Qty 3";
            this.spdPlannedLot_Sheet1.Columns.Get(10).Locked = true;
            this.spdPlannedLot_Sheet1.Columns.Get(10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdPlannedLot_Sheet1.Columns.Get(11).Label = "Lot Type";
            this.spdPlannedLot_Sheet1.Columns.Get(11).Locked = true;
            this.spdPlannedLot_Sheet1.Columns.Get(11).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdPlannedLot_Sheet1.Columns.Get(11).Width = 70F;
            this.spdPlannedLot_Sheet1.Columns.Get(12).Label = "Owner Code";
            this.spdPlannedLot_Sheet1.Columns.Get(12).Locked = true;
            this.spdPlannedLot_Sheet1.Columns.Get(12).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdPlannedLot_Sheet1.Columns.Get(12).Width = 113F;
            this.spdPlannedLot_Sheet1.Columns.Get(13).Label = "Create Code";
            this.spdPlannedLot_Sheet1.Columns.Get(13).Locked = true;
            this.spdPlannedLot_Sheet1.Columns.Get(13).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdPlannedLot_Sheet1.Columns.Get(13).Width = 98F;
            this.spdPlannedLot_Sheet1.Columns.Get(14).Label = "Priority";
            this.spdPlannedLot_Sheet1.Columns.Get(14).Locked = true;
            this.spdPlannedLot_Sheet1.Columns.Get(14).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdPlannedLot_Sheet1.Columns.Get(14).Width = 66F;
            this.spdPlannedLot_Sheet1.Columns.Get(15).Label = "Org Due Date";
            this.spdPlannedLot_Sheet1.Columns.Get(15).Locked = true;
            this.spdPlannedLot_Sheet1.Columns.Get(15).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdPlannedLot_Sheet1.Columns.Get(15).Width = 125F;
            this.spdPlannedLot_Sheet1.Columns.Get(16).Label = "Res ID";
            this.spdPlannedLot_Sheet1.Columns.Get(16).Locked = true;
            this.spdPlannedLot_Sheet1.Columns.Get(16).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdPlannedLot_Sheet1.Columns.Get(16).Width = 67F;
            this.spdPlannedLot_Sheet1.Columns.Get(17).Label = "Order ID";
            this.spdPlannedLot_Sheet1.Columns.Get(17).Locked = true;
            this.spdPlannedLot_Sheet1.Columns.Get(17).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdPlannedLot_Sheet1.Columns.Get(17).Width = 73F;
            this.spdPlannedLot_Sheet1.Columns.Get(18).Label = "Lot Create Flag";
            this.spdPlannedLot_Sheet1.Columns.Get(18).Locked = true;
            this.spdPlannedLot_Sheet1.Columns.Get(18).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdPlannedLot_Sheet1.Columns.Get(18).Width = 116F;
            this.spdPlannedLot_Sheet1.Columns.Get(19).Label = "Lot Create Time";
            this.spdPlannedLot_Sheet1.Columns.Get(19).Locked = true;
            this.spdPlannedLot_Sheet1.Columns.Get(19).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdPlannedLot_Sheet1.Columns.Get(19).Width = 125F;
            this.spdPlannedLot_Sheet1.Columns.Get(20).Label = "Create User";
            this.spdPlannedLot_Sheet1.Columns.Get(20).Locked = true;
            this.spdPlannedLot_Sheet1.Columns.Get(20).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdPlannedLot_Sheet1.Columns.Get(20).Width = 100F;
            this.spdPlannedLot_Sheet1.Columns.Get(21).Label = "Create Time";
            this.spdPlannedLot_Sheet1.Columns.Get(21).Locked = true;
            this.spdPlannedLot_Sheet1.Columns.Get(21).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdPlannedLot_Sheet1.Columns.Get(21).Width = 125F;
            this.spdPlannedLot_Sheet1.Columns.Get(22).Label = "Update User";
            this.spdPlannedLot_Sheet1.Columns.Get(22).Locked = true;
            this.spdPlannedLot_Sheet1.Columns.Get(22).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdPlannedLot_Sheet1.Columns.Get(22).Width = 100F;
            this.spdPlannedLot_Sheet1.Columns.Get(23).Label = "Update Time";
            this.spdPlannedLot_Sheet1.Columns.Get(23).Locked = true;
            this.spdPlannedLot_Sheet1.Columns.Get(23).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdPlannedLot_Sheet1.Columns.Get(23).Width = 125F;
            this.spdPlannedLot_Sheet1.FrozenColumnCount = 2;
            this.spdPlannedLot_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdPlannedLot_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdPlannedLot_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdPlannedLot_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdPlannedLot_Sheet1.Rows.Get(0).Height = 18F;
            this.spdPlannedLot_Sheet1.Rows.Get(1).Height = 18F;
            this.spdPlannedLot_Sheet1.Rows.Get(2).Height = 18F;
            this.spdPlannedLot_Sheet1.Rows.Get(3).Height = 18F;
            this.spdPlannedLot_Sheet1.Rows.Get(4).Height = 18F;
            this.spdPlannedLot_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdPlannedLot_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdPlannedLot_Sheet1.VisualStyles = FarPoint.Win.VisualStyles.Auto;
            this.spdPlannedLot_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // tbpMaterial
            // 
            this.tbpMaterial.Controls.Add(this.spdMatPlannedLot);
            this.tbpMaterial.Location = new System.Drawing.Point(4, 22);
            this.tbpMaterial.Name = "tbpMaterial";
            this.tbpMaterial.Size = new System.Drawing.Size(734, 437);
            this.tbpMaterial.TabIndex = 1;
            this.tbpMaterial.Text = "Material";
            // 
            // spdMatPlannedLot
            // 
            this.spdMatPlannedLot.AccessibleDescription = "spdMatPlannedLot, Sheet1, Row 0, Column 0, ";
            this.spdMatPlannedLot.BackColor = System.Drawing.SystemColors.Control;
            this.spdMatPlannedLot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdMatPlannedLot.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdMatPlannedLot.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdMatPlannedLot.HorizontalScrollBar.Name = "";
            this.spdMatPlannedLot.HorizontalScrollBar.Renderer = defaultScrollBarRenderer3;
            this.spdMatPlannedLot.HorizontalScrollBar.TabIndex = 2;
            this.spdMatPlannedLot.Location = new System.Drawing.Point(0, 0);
            this.spdMatPlannedLot.Name = "spdMatPlannedLot";
            this.spdMatPlannedLot.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdMatPlannedLot.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdMatPlannedLot.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdMatPlannedLot_Sheet1});
            this.spdMatPlannedLot.Size = new System.Drawing.Size(734, 437);
            this.spdMatPlannedLot.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdMatPlannedLot.TabIndex = 1;
            this.spdMatPlannedLot.TabStop = false;
            this.spdMatPlannedLot.TextTipDelay = 200;
            this.spdMatPlannedLot.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdMatPlannedLot.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdMatPlannedLot.VerticalScrollBar.Name = "";
            this.spdMatPlannedLot.VerticalScrollBar.Renderer = defaultScrollBarRenderer4;
            this.spdMatPlannedLot.VerticalScrollBar.TabIndex = 3;
            this.spdMatPlannedLot.SetViewportLeftColumn(0, 0, 3);
            this.spdMatPlannedLot.SetActiveViewport(0, 0, -1);
            // 
            // spdMatPlannedLot_Sheet1
            // 
            this.spdMatPlannedLot_Sheet1.Reset();
            spdMatPlannedLot_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdMatPlannedLot_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdMatPlannedLot_Sheet1.ColumnCount = 24;
            spdMatPlannedLot_Sheet1.RowCount = 5;
            this.spdMatPlannedLot_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdMatPlannedLot_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdMatPlannedLot_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdMatPlannedLot_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdMatPlannedLot_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Mat ID";
            this.spdMatPlannedLot_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Mat Ver";
            this.spdMatPlannedLot_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Work Date";
            this.spdMatPlannedLot_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Lot ID";
            this.spdMatPlannedLot_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Lot Desc";
            this.spdMatPlannedLot_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Flow";
            this.spdMatPlannedLot_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Flow Seq Num";
            this.spdMatPlannedLot_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "Oper";
            this.spdMatPlannedLot_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "Qty 1";
            this.spdMatPlannedLot_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "Qty 2";
            this.spdMatPlannedLot_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "Qty 3";
            this.spdMatPlannedLot_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "Lot Type";
            this.spdMatPlannedLot_Sheet1.ColumnHeader.Cells.Get(0, 12).Value = "Owner Code";
            this.spdMatPlannedLot_Sheet1.ColumnHeader.Cells.Get(0, 13).Value = "Create Code";
            this.spdMatPlannedLot_Sheet1.ColumnHeader.Cells.Get(0, 14).Value = "Priority";
            this.spdMatPlannedLot_Sheet1.ColumnHeader.Cells.Get(0, 15).Value = "Org Due Date";
            this.spdMatPlannedLot_Sheet1.ColumnHeader.Cells.Get(0, 16).Value = "Res ID";
            this.spdMatPlannedLot_Sheet1.ColumnHeader.Cells.Get(0, 17).Value = "Order ID";
            this.spdMatPlannedLot_Sheet1.ColumnHeader.Cells.Get(0, 18).Value = "Lot Create Flag";
            this.spdMatPlannedLot_Sheet1.ColumnHeader.Cells.Get(0, 19).Value = "Lot Create Time";
            this.spdMatPlannedLot_Sheet1.ColumnHeader.Cells.Get(0, 20).Value = "Create User";
            this.spdMatPlannedLot_Sheet1.ColumnHeader.Cells.Get(0, 21).Value = "Create Time";
            this.spdMatPlannedLot_Sheet1.ColumnHeader.Cells.Get(0, 22).Value = "Update User";
            this.spdMatPlannedLot_Sheet1.ColumnHeader.Cells.Get(0, 23).Value = "Update Time";
            this.spdMatPlannedLot_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdMatPlannedLot_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdMatPlannedLot_Sheet1.ColumnHeader.Rows.Get(0).Height = 18F;
            this.spdMatPlannedLot_Sheet1.Columns.Get(0).Label = "Mat ID";
            this.spdMatPlannedLot_Sheet1.Columns.Get(0).Locked = true;
            this.spdMatPlannedLot_Sheet1.Columns.Get(0).MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Restricted;
            this.spdMatPlannedLot_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMatPlannedLot_Sheet1.Columns.Get(0).Width = 111F;
            this.spdMatPlannedLot_Sheet1.Columns.Get(1).Label = "Mat Ver";
            this.spdMatPlannedLot_Sheet1.Columns.Get(1).Locked = true;
            this.spdMatPlannedLot_Sheet1.Columns.Get(1).MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Restricted;
            this.spdMatPlannedLot_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMatPlannedLot_Sheet1.Columns.Get(2).Label = "Work Date";
            this.spdMatPlannedLot_Sheet1.Columns.Get(2).Locked = true;
            this.spdMatPlannedLot_Sheet1.Columns.Get(2).MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Restricted;
            this.spdMatPlannedLot_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMatPlannedLot_Sheet1.Columns.Get(2).Width = 86F;
            this.spdMatPlannedLot_Sheet1.Columns.Get(3).Label = "Lot ID";
            this.spdMatPlannedLot_Sheet1.Columns.Get(3).Locked = true;
            this.spdMatPlannedLot_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMatPlannedLot_Sheet1.Columns.Get(3).Width = 110F;
            this.spdMatPlannedLot_Sheet1.Columns.Get(4).Label = "Lot Desc";
            this.spdMatPlannedLot_Sheet1.Columns.Get(4).Locked = true;
            this.spdMatPlannedLot_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMatPlannedLot_Sheet1.Columns.Get(4).Width = 223F;
            this.spdMatPlannedLot_Sheet1.Columns.Get(5).Label = "Flow";
            this.spdMatPlannedLot_Sheet1.Columns.Get(5).Locked = true;
            this.spdMatPlannedLot_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMatPlannedLot_Sheet1.Columns.Get(5).Width = 103F;
            this.spdMatPlannedLot_Sheet1.Columns.Get(6).Label = "Flow Seq Num";
            this.spdMatPlannedLot_Sheet1.Columns.Get(6).Locked = true;
            this.spdMatPlannedLot_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMatPlannedLot_Sheet1.Columns.Get(6).Width = 100F;
            this.spdMatPlannedLot_Sheet1.Columns.Get(7).Label = "Oper";
            this.spdMatPlannedLot_Sheet1.Columns.Get(7).Locked = true;
            this.spdMatPlannedLot_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMatPlannedLot_Sheet1.Columns.Get(7).Width = 86F;
            this.spdMatPlannedLot_Sheet1.Columns.Get(8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdMatPlannedLot_Sheet1.Columns.Get(8).Label = "Qty 1";
            this.spdMatPlannedLot_Sheet1.Columns.Get(8).Locked = true;
            this.spdMatPlannedLot_Sheet1.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMatPlannedLot_Sheet1.Columns.Get(9).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdMatPlannedLot_Sheet1.Columns.Get(9).Label = "Qty 2";
            this.spdMatPlannedLot_Sheet1.Columns.Get(9).Locked = true;
            this.spdMatPlannedLot_Sheet1.Columns.Get(9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMatPlannedLot_Sheet1.Columns.Get(10).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdMatPlannedLot_Sheet1.Columns.Get(10).Label = "Qty 3";
            this.spdMatPlannedLot_Sheet1.Columns.Get(10).Locked = true;
            this.spdMatPlannedLot_Sheet1.Columns.Get(10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMatPlannedLot_Sheet1.Columns.Get(11).Label = "Lot Type";
            this.spdMatPlannedLot_Sheet1.Columns.Get(11).Locked = true;
            this.spdMatPlannedLot_Sheet1.Columns.Get(11).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMatPlannedLot_Sheet1.Columns.Get(11).Width = 70F;
            this.spdMatPlannedLot_Sheet1.Columns.Get(12).Label = "Owner Code";
            this.spdMatPlannedLot_Sheet1.Columns.Get(12).Locked = true;
            this.spdMatPlannedLot_Sheet1.Columns.Get(12).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMatPlannedLot_Sheet1.Columns.Get(12).Width = 113F;
            this.spdMatPlannedLot_Sheet1.Columns.Get(13).Label = "Create Code";
            this.spdMatPlannedLot_Sheet1.Columns.Get(13).Locked = true;
            this.spdMatPlannedLot_Sheet1.Columns.Get(13).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMatPlannedLot_Sheet1.Columns.Get(13).Width = 98F;
            this.spdMatPlannedLot_Sheet1.Columns.Get(14).Label = "Priority";
            this.spdMatPlannedLot_Sheet1.Columns.Get(14).Locked = true;
            this.spdMatPlannedLot_Sheet1.Columns.Get(14).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMatPlannedLot_Sheet1.Columns.Get(14).Width = 66F;
            this.spdMatPlannedLot_Sheet1.Columns.Get(15).Label = "Org Due Date";
            this.spdMatPlannedLot_Sheet1.Columns.Get(15).Locked = true;
            this.spdMatPlannedLot_Sheet1.Columns.Get(15).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMatPlannedLot_Sheet1.Columns.Get(15).Width = 125F;
            this.spdMatPlannedLot_Sheet1.Columns.Get(16).Label = "Res ID";
            this.spdMatPlannedLot_Sheet1.Columns.Get(16).Locked = true;
            this.spdMatPlannedLot_Sheet1.Columns.Get(16).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMatPlannedLot_Sheet1.Columns.Get(16).Width = 67F;
            this.spdMatPlannedLot_Sheet1.Columns.Get(17).Label = "Order ID";
            this.spdMatPlannedLot_Sheet1.Columns.Get(17).Locked = true;
            this.spdMatPlannedLot_Sheet1.Columns.Get(17).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMatPlannedLot_Sheet1.Columns.Get(17).Width = 73F;
            this.spdMatPlannedLot_Sheet1.Columns.Get(18).Label = "Lot Create Flag";
            this.spdMatPlannedLot_Sheet1.Columns.Get(18).Locked = true;
            this.spdMatPlannedLot_Sheet1.Columns.Get(18).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMatPlannedLot_Sheet1.Columns.Get(18).Width = 116F;
            this.spdMatPlannedLot_Sheet1.Columns.Get(19).Label = "Lot Create Time";
            this.spdMatPlannedLot_Sheet1.Columns.Get(19).Locked = true;
            this.spdMatPlannedLot_Sheet1.Columns.Get(19).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMatPlannedLot_Sheet1.Columns.Get(19).Width = 125F;
            this.spdMatPlannedLot_Sheet1.Columns.Get(20).Label = "Create User";
            this.spdMatPlannedLot_Sheet1.Columns.Get(20).Locked = true;
            this.spdMatPlannedLot_Sheet1.Columns.Get(20).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMatPlannedLot_Sheet1.Columns.Get(20).Width = 100F;
            this.spdMatPlannedLot_Sheet1.Columns.Get(21).Label = "Create Time";
            this.spdMatPlannedLot_Sheet1.Columns.Get(21).Locked = true;
            this.spdMatPlannedLot_Sheet1.Columns.Get(21).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMatPlannedLot_Sheet1.Columns.Get(21).Width = 125F;
            this.spdMatPlannedLot_Sheet1.Columns.Get(22).Label = "Update User";
            this.spdMatPlannedLot_Sheet1.Columns.Get(22).Locked = true;
            this.spdMatPlannedLot_Sheet1.Columns.Get(22).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMatPlannedLot_Sheet1.Columns.Get(22).Width = 100F;
            this.spdMatPlannedLot_Sheet1.Columns.Get(23).Label = "Update Time";
            this.spdMatPlannedLot_Sheet1.Columns.Get(23).Locked = true;
            this.spdMatPlannedLot_Sheet1.Columns.Get(23).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMatPlannedLot_Sheet1.Columns.Get(23).Width = 125F;
            this.spdMatPlannedLot_Sheet1.FrozenColumnCount = 3;
            this.spdMatPlannedLot_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdMatPlannedLot_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdMatPlannedLot_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdMatPlannedLot_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdMatPlannedLot_Sheet1.Rows.Get(0).Height = 18F;
            this.spdMatPlannedLot_Sheet1.Rows.Get(1).Height = 18F;
            this.spdMatPlannedLot_Sheet1.Rows.Get(2).Height = 18F;
            this.spdMatPlannedLot_Sheet1.Rows.Get(3).Height = 18F;
            this.spdMatPlannedLot_Sheet1.Rows.Get(4).Height = 18F;
            this.spdMatPlannedLot_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdMatPlannedLot_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdMatPlannedLot_Sheet1.VisualStyles = FarPoint.Win.VisualStyles.Auto;
            this.spdMatPlannedLot_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // pnlPeriod
            // 
            this.pnlPeriod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlPeriod.Controls.Add(this.dtpFrom);
            this.pnlPeriod.Controls.Add(this.lblPeriod);
            this.pnlPeriod.Controls.Add(this.dtpTo);
            this.pnlPeriod.Controls.Add(this.lblTo);
            this.pnlPeriod.Location = new System.Drawing.Point(475, 16);
            this.pnlPeriod.Name = "pnlPeriod";
            this.pnlPeriod.Size = new System.Drawing.Size(257, 20);
            this.pnlPeriod.TabIndex = 1;
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
            this.cdvMaterial.Location = new System.Drawing.Point(12, 16);
            this.cdvMaterial.MaterialEnabled = true;
            this.cdvMaterial.MaterialReadOnly = false;
            this.cdvMaterial.Name = "cdvMaterial";
            this.cdvMaterial.SearchSubItemIndex = 0;
            this.cdvMaterial.SelectedDescIndex = -1;
            this.cdvMaterial.SelectedSubItemIndex = 0;
            this.cdvMaterial.Size = new System.Drawing.Size(308, 20);
            this.cdvMaterial.TabIndex = 0;
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
            // frmORDViewPlannedLot
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Name = "frmORDViewPlannedLot";
            this.Text = "View Planned Lot";
            this.Activated += new System.EventHandler(this.frmORDViewPlannedLot_Activated);
            this.Load += new System.EventHandler(this.frmORDViewPlannedLot_Load);
            this.pnlViewTop.ResumeLayout(false);
            this.grpOption.ResumeLayout(false);
            this.pnlViewMid.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.tabPlannedLot.ResumeLayout(false);
            this.tbpLot.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdPlannedLot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdPlannedLot_Sheet1)).EndInit();
            this.tbpMaterial.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdMatPlannedLot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdMatPlannedLot_Sheet1)).EndInit();
            this.pnlPeriod.ResumeLayout(false);
            this.pnlPeriod.PerformLayout();
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
            double dTotQty1;
            double dTotQty2;
            double dTotQty3;
            
            double dMTotQty1;
            double dMTotQty2;
            double dMTotQty3;
            
            double dTTotQty1;
            double dTTotQty2;
            double dTTotQty3;
            
            
            FarPoint.Win.Spread.SheetView with_1 = spdPlannedLot.Sheets[0];
            
            if (with_1.RowCount <= 0)
            {
                return;
            }
            
            i = 0;
            dTotQty1 = 0;
            dTotQty2 = 0;
            dTotQty3 = 0;
            dTTotQty1 = 0;
            dTTotQty2 = 0;
            dTTotQty3 = 0;
            
            while (i < with_1.RowCount - 1)
            {
                dTotQty1 += MPCF.ToDbl(with_1.Cells[i, 6].Value);
                dTotQty2 += MPCF.ToDbl(with_1.Cells[i, 7].Value);
                dTotQty3 += MPCF.ToDbl(with_1.Cells[i, 8].Value);
                
                if (with_1.Cells[i, 0].Text == with_1.Cells[i + 1, 0].Text)
                {
                    i++;
                }
                else
                {
                    with_1.AddRows(i + 1, 1);
                    with_1.Cells[i + 1, 0].Value = "DATE TOTAL";
                    with_1.Rows[i + 1].BackColor = Color.LightGoldenrodYellow;
                    with_1.Cells[i + 1, 6].Value = MPCF.Format("######,##0.###", dTotQty1);
                    with_1.Cells[i + 1, 7].Value = MPCF.Format("######,##0.###", dTotQty2);
                    with_1.Cells[i + 1, 8].Value = MPCF.Format("######,##0.###", dTotQty3);
                    
                    dTTotQty1 += dTotQty1;
                    dTTotQty2 += dTotQty2;
                    dTTotQty3 += dTotQty3;
                    
                    i += 2;
                    
                    dTotQty1 = 0;
                    
                    dTotQty2 = 0;
                    dTotQty3 = 0;
                }
            }
            
            dTotQty1 += MPCF.ToDbl(with_1.Cells[i, 6].Value);
            dTotQty2 += MPCF.ToDbl(with_1.Cells[i, 7].Value);
            dTotQty3 += MPCF.ToDbl(with_1.Cells[i, 8].Value);
            
            i = with_1.RowCount;
            with_1.RowCount++;
            
            with_1.Cells[i, 0].Value = "DATE TOTAL";
            with_1.Rows[i].BackColor = Color.LightGoldenrodYellow;
            with_1.Cells[i, 6].Value = MPCF.Format("######,##0.###", dTotQty1);
            with_1.Cells[i, 7].Value = MPCF.Format("######,##0.###", dTotQty2);
            with_1.Cells[i, 8].Value = MPCF.Format("######,##0.###", dTotQty3);
            
            dTTotQty1 += dTotQty1;
            dTTotQty2 += dTotQty2;
            dTTotQty3 += dTotQty3;
            
            i = with_1.RowCount;
            with_1.RowCount++;
            
            with_1.Cells[i, 0].Value = "TOTAL";
            with_1.Rows[i].BackColor = Color.Gainsboro;
            with_1.Cells[i, 6].Value = MPCF.Format("######,##0.###", dTTotQty1);
            with_1.Cells[i, 7].Value = MPCF.Format("######,##0.###", dTTotQty2);
            with_1.Cells[i, 8].Value = MPCF.Format("######,##0.###", dTTotQty3);
            
            FarPoint.Win.Spread.SheetView with_2 = spdMatPlannedLot.Sheets[0];
            
            i = 0;
            dTotQty1 = 0;
            dTotQty2 = 0;
            dTotQty3 = 0;
            dMTotQty1 = 0;
            dMTotQty2 = 0;
            dMTotQty3 = 0;
            dTTotQty1 = 0;
            dTTotQty2 = 0;
            dTTotQty3 = 0;
            
            while (i < with_2.RowCount - 1)
            {
                dTotQty1 += MPCF.ToDbl(with_2.Cells[i, 6].Value);
                dTotQty2 += MPCF.ToDbl(with_2.Cells[i, 7].Value);
                dTotQty3 += MPCF.ToDbl(with_2.Cells[i, 8].Value);
                
                if (with_2.Cells[i, 0].Text == with_2.Cells[i + 1, 0].Text)
                {
                    if (with_2.Cells[i, 1].Text == with_2.Cells[i + 1, 1].Text)
                    {
                        i++;
                    }
                    else
                    {
                        with_2.AddRows(i + 1, 1);
                        with_2.Cells[i + 1, 0].Value = with_2.Cells[i, 0].Value;
                        with_2.Cells[i + 1, 1].Value = "DATE TOTAL";
                        with_2.Rows[i + 1].BackColor = Color.LightGoldenrodYellow;
                        with_2.Cells[i + 1, 6].Value = MPCF.Format("######,##0.###", dTotQty1);
                        with_2.Cells[i + 1, 7].Value = MPCF.Format("######,##0.###", dTotQty2);
                        with_2.Cells[i + 1, 8].Value = MPCF.Format("######,##0.###", dTotQty3);
                        
                        dMTotQty1 += dTotQty1;
                        dMTotQty2 += dTotQty2;
                        dMTotQty3 += dTotQty3;
                        
                        i += 2;
                        
                        dTotQty1 = 0;
                        
                        dTotQty2 = 0;
                        dTotQty3 = 0;
                    }
                }
                else
                {
                    with_2.AddRows(i + 1, 1);
                    with_2.Cells[i + 1, 0].Value = with_2.Cells[i, 0].Value;
                    with_2.Cells[i + 1, 1].Value = "DATE TOTAL";
                    with_2.Rows[i + 1].BackColor = Color.LightGoldenrodYellow;
                    with_2.Cells[i + 1, 6].Value = MPCF.Format("######,##0.###", dTotQty1);
                    with_2.Cells[i + 1, 7].Value = MPCF.Format("######,##0.###", dTotQty2);
                    with_2.Cells[i + 1, 8].Value = MPCF.Format("######,##0.###", dTotQty3);
                    
                    dMTotQty1 += dTotQty1;
                    dMTotQty2 += dTotQty2;
                    dMTotQty3 += dTotQty3;
                    dTotQty1 = 0;
                    
                    dTotQty2 = 0;
                    dTotQty3 = 0;
                    
                    with_2.AddRows(i + 2, 1);
                    with_2.Cells[i + 2, 0].Value = "MAT TOTAL";
                    with_2.Rows[i + 2].BackColor = Color.Gainsboro;
                    with_2.Cells[i + 2, 6].Value = MPCF.Format("######,##0.###", dMTotQty1);
                    with_2.Cells[i + 2, 7].Value = MPCF.Format("######,##0.###", dMTotQty2);
                    with_2.Cells[i + 2, 8].Value = MPCF.Format("######,##0.###", dMTotQty3);
                    
                    dTTotQty1 += dMTotQty1;
                    dTTotQty2 += dMTotQty2;
                    dTTotQty3 += dMTotQty3;
                    dMTotQty1 = 0;
                    
                    dMTotQty2 = 0;
                    dMTotQty3 = 0;
                    
                    i += 3;
                }
            }
            
            dTotQty1 += MPCF.ToDbl(with_2.Cells[i, 6].Value);
            dTotQty2 += MPCF.ToDbl(with_2.Cells[i, 7].Value);
            dTotQty3 += MPCF.ToDbl(with_2.Cells[i, 8].Value);
            
            i = with_2.RowCount;
            with_2.RowCount++;
            
            with_2.Cells[i, 0].Value = with_2.Cells[i - 1, 0].Value;
            with_2.Cells[i, 1].Value = "DATE TOTAL";
            with_2.Rows[i].BackColor = Color.LightGoldenrodYellow;
            with_2.Cells[i, 6].Value = MPCF.Format("######,##0.###", dTotQty1);
            with_2.Cells[i, 7].Value = MPCF.Format("######,##0.###", dTotQty2);
            with_2.Cells[i, 8].Value = MPCF.Format("######,##0.###", dTotQty3);
            
            dMTotQty1 += dTotQty1;
            dMTotQty2 += dTotQty2;
            dMTotQty3 += dTotQty3;
            
            
            i = with_2.RowCount;
            with_2.RowCount++;
            
            with_2.Cells[i, 0].Value = "MAT TOTAL";
            with_2.Rows[i].BackColor = Color.Gainsboro;
            with_2.Cells[i, 6].Value = MPCF.Format("######,##0.###", dMTotQty1);
            with_2.Cells[i, 7].Value = MPCF.Format("######,##0.###", dMTotQty2);
            with_2.Cells[i, 8].Value = MPCF.Format("######,##0.###", dMTotQty3);
            
            dTTotQty1 += dMTotQty1;
            dTTotQty2 += dMTotQty2;
            dTTotQty3 += dMTotQty3;
            
            
            i = with_2.RowCount;
            with_2.RowCount++;
            
            with_2.Cells[i, 0].Value = "TOTAL";
            with_2.Rows[i].BackColor = Color.LightSteelBlue;
            with_2.Cells[i, 6].Value = MPCF.Format("######,##0.###", dTTotQty1);
            with_2.Cells[i, 7].Value = MPCF.Format("######,##0.###", dTTotQty2);
            with_2.Cells[i, 8].Value = MPCF.Format("######,##0.###", dTTotQty3);
            
        }
        
        // View_PlannedLot_List_Detail()
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
        private bool View_PlannedLot_List_Detail()
        {
            
            FarPoint.Win.Spread.SheetView shtLot;
            FarPoint.Win.Spread.SheetView shtMat;
            int i;
            int iRow;
            int iCol;

            MPCF.ClearList(spdPlannedLot, true);
            MPCF.ClearList(spdMatPlannedLot, true);


            TRSNode in_node = new TRSNode("View_PlannedLot_List_Detail_In");
            TRSNode out_node = new TRSNode("View_PlannedLot_List_Detail_Out");
            TRSNode lot_list;


            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("FROM_DATE", MPCF.FromDate(dtpFrom));
            in_node.AddString("TO_DATE", MPCF.ToDate(dtpTo));
            in_node.AddString("MAT_ID", MPCF.Trim(cdvMaterial.Text));
            in_node.AddInt("MAT_VER", cdvMaterial.Version);
            in_node.AddString("MAT_TYPE", "");
            in_node.AddString("MAT_GRP", "");
            in_node.AddString("NEXT_LOT_ID", "");
                        
            shtLot = spdPlannedLot.Sheets[0];
            shtMat = spdMatPlannedLot.Sheets[0];
            
            do
            {
                if (MPCR.CallService("ORD", "ORD_View_PlannedLot_List_Detail", in_node, ref out_node) == false)
                {
                    return false;
                }
                
                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    lot_list = out_node.GetList(0)[i];
                    iRow = shtLot.RowCount;
                    
                    shtLot.RowCount++;
                    shtMat.RowCount++;
                    
                    iCol = 0;

                    shtLot.Cells[iRow, iCol].Value = MakeDate(lot_list.GetString("WORK_DATE"));
                    shtMat.Cells[iRow, iCol].Value = MPCF.Trim(lot_list.GetString("MAT_ID"));
                    
                    iCol++;
                    shtLot.Cells[iRow, iCol].Value = MPCF.Trim(lot_list.GetString("LOT_ID"));
                    shtMat.Cells[iRow, iCol].Value = MPCF.Trim(lot_list.GetInt("MAT_VER"));

                    iCol++;
                    shtLot.Cells[iRow, iCol].Value = MPCF.Trim(lot_list.GetString("LOT_DESC"));
                    shtMat.Cells[iRow, iCol].Value = MakeDate(lot_list.GetString("WORK_DATE"));

                    iCol++;
                    shtLot.Cells[iRow, iCol].Value = MPCF.Trim(lot_list.GetString("MAT_ID"));
                    shtMat.Cells[iRow, iCol].Value = MPCF.Trim(lot_list.GetString("LOT_ID"));
                    
                    iCol++;
                    shtLot.Cells[iRow, iCol].Value = MPCF.Trim(lot_list.GetInt("MAT_VER"));
                    shtMat.Cells[iRow, iCol].Value = MPCF.Trim(lot_list.GetString("LOT_DESC"));

                    iCol++;
                    shtLot.Cells[iRow, iCol].Value = MPCF.Trim(lot_list.GetString("FLOW"));
                    shtMat.Cells[iRow, iCol].Value = MPCF.Trim(lot_list.GetString("FLOW"));

                    iCol++;
                    shtLot.Cells[iRow, iCol].Value = MPCF.Trim(lot_list.GetInt("FLOW_SEQ_NUM"));
                    shtMat.Cells[iRow, iCol].Value = MPCF.Trim(lot_list.GetInt("FLOW_SEQ_NUM"));
                    
                    iCol++;
                    shtLot.Cells[iRow, iCol].Value = MPCF.Trim(lot_list.GetString("OPER"));
                    shtMat.Cells[iRow, iCol].Value = MPCF.Trim(lot_list.GetString("OPER"));
                    
                    iCol++;
                    shtLot.Cells[iRow, iCol].Value = MPCF.Format("#####,##0.###", lot_list.GetDouble("QTY_1"));
                    shtMat.Cells[iRow, iCol].Value = MPCF.Format("#####,##0.###", lot_list.GetDouble("QTY_1"));
                    
                    iCol++;
                    shtLot.Cells[iRow, iCol].Value = MPCF.Format("#####,##0.###", lot_list.GetDouble("QTY_2"));
                    shtMat.Cells[iRow, iCol].Value = MPCF.Format("#####,##0.###", lot_list.GetDouble("QTY_2"));
                    
                    iCol++;
                    shtLot.Cells[iRow, iCol].Value = MPCF.Format("#####,##0.###", lot_list.GetDouble("QTY_3"));
                    shtMat.Cells[iRow, iCol].Value = MPCF.Format("#####,##0.###", lot_list.GetDouble("QTY_3"));
                    
                    iCol++;
                    shtLot.Cells[iRow, iCol].Value = MPCF.Trim(lot_list.GetChar("LOT_TYPE"));
                    shtMat.Cells[iRow, iCol].Value = MPCF.Trim(lot_list.GetChar("LOT_TYPE"));
                    
                    iCol++;
                    shtLot.Cells[iRow, iCol].Value = MPCF.Trim(lot_list.GetString("OWNER_CODE"));
                    shtMat.Cells[iRow, iCol].Value = MPCF.Trim(lot_list.GetString("OWNER_CODE"));
                    
                    iCol++;
                    shtLot.Cells[iRow, iCol].Value = MPCF.Trim(lot_list.GetString("CREATE_CODE"));
                    shtMat.Cells[iRow, iCol].Value = MPCF.Trim(lot_list.GetString("CREATE_CODE"));
                    
                    iCol++;
                    shtLot.Cells[iRow, iCol].Value = MPCF.Trim(lot_list.GetChar("LOT_PRIORITY"));
                    shtMat.Cells[iRow, iCol].Value = MPCF.Trim(lot_list.GetChar("LOT_PRIORITY"));
                    
                    iCol++;
                    shtLot.Cells[iRow, iCol].Value = MakeDate(lot_list.GetString("ORG_DUE_TIME"));
                    shtMat.Cells[iRow, iCol].Value = MakeDate(lot_list.GetString("ORG_DUE_TIME"));
                    
                    iCol++;
                    shtLot.Cells[iRow, iCol].Value = MPCF.Trim(lot_list.GetString("RES_ID"));
                    shtMat.Cells[iRow, iCol].Value = MPCF.Trim(lot_list.GetString("RES_ID"));
                    
                    iCol++;
                    shtLot.Cells[iRow, iCol].Value = MPCF.Trim(lot_list.GetString("ORDER_ID"));
                    shtMat.Cells[iRow, iCol].Value = MPCF.Trim(lot_list.GetString("ORDER_ID"));
                    
                    iCol++;
                    shtLot.Cells[iRow, iCol].Value = MPCF.Trim(lot_list.GetChar("LOT_CREATE_FLAG"));
                    shtMat.Cells[iRow, iCol].Value = MPCF.Trim(lot_list.GetChar("LOT_CREATE_FLAG"));
                    
                    iCol++;
                    shtLot.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(lot_list.GetString("LOT_CREATE_TIME"));
                    shtMat.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(lot_list.GetString("LOT_CREATE_TIME"));
                    
                    iCol++;
                    shtLot.Cells[iRow, iCol].Value = MPCF.Trim(lot_list.GetString("CREATE_USER_ID"));
                    shtMat.Cells[iRow, iCol].Value = MPCF.Trim(lot_list.GetString("CREATE_USER_ID"));
                    
                    iCol++;
                    shtLot.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(lot_list.GetString("CREATE_TIME"));
                    shtMat.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(lot_list.GetString("CREATE_TIME"));
                    
                    iCol++;
                    shtLot.Cells[iRow, iCol].Value = MPCF.Trim(lot_list.GetString("UPDATE_USER_ID"));
                    shtMat.Cells[iRow, iCol].Value = MPCF.Trim(lot_list.GetString("UPDATE_USER_ID"));
                    
                    iCol++;
                    shtLot.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(lot_list.GetString("UPDATE_TIME"));
                    shtMat.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(lot_list.GetString("UPDATE_TIME"));
                    
                    iCol++;
                    
                }

                //View_PlannedLot_List_Detail_In.next_lot_id = View_PlannedLot_List_Detail_Out.next_lot_id;
                //View_PlannedLot_List_Detail_In.from_date = View_PlannedLot_List_Detail_Out.next_from_date;

                in_node.SetString("NEXT_LOT_ID", out_node.GetString("NEXT_LOT_ID"));
                in_node.SetString("FROM_DATE", out_node.GetString("NEXT_FROM_DATE"));
                
            } while (in_node.GetString("NEXT_LOT_ID") != "" || in_node.GetString("FROM_DATE") != "");
            
            FarPoint.Win.Spread.SortInfo[] sort = new FarPoint.Win.Spread.SortInfo[4];
            sort[0] = new FarPoint.Win.Spread.SortInfo(0, true);
            sort[1] = new FarPoint.Win.Spread.SortInfo(1, true);
            sort[2] = new FarPoint.Win.Spread.SortInfo(3, true);
            sort[3] = new FarPoint.Win.Spread.SortInfo(4, true);
            shtLot.SortRows(0, shtLot.RowCount, sort);
            
            sort[0].Index = 0;
            
            sort[0].Ascending = true;
            sort[1].Index = 1;
            
            sort[1].Ascending = true;
            sort[2].Index = 2;
            
            sort[2].Ascending = true;
            sort[3].Index = 4;
            
            sort[3].Ascending = true;
            shtMat.SortRows(0, shtMat.RowCount, sort);
            
            CalTotalQty();
            
            MPCF.FitColumnHeader(spdPlannedLot);
            MPCF.FitColumnHeader(spdMatPlannedLot);
            
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
        
        private void frmORDViewPlannedLot_Load(object sender, System.EventArgs e)
        {
            
        }
        
        private void frmORDViewPlannedLot_Activated(object sender, System.EventArgs e)
        {
            if (b_load_flag == false)
            {
                
                MPCF.FieldClear(this);
                MPCF.ClearList(spdPlannedLot, true);
                MPCF.ClearList(spdMatPlannedLot, true);
                MPCF.FitColumnHeader(spdPlannedLot);
                MPCF.FitColumnHeader(spdMatPlannedLot);
                
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
            View_PlannedLot_List_Detail();
        }
        
        private void btnExcel_Click(System.Object sender, System.EventArgs e)
        {
            string sCond;
            FarPoint.Win.Spread.FpSpread spdData = null;
            
            if (tabPlannedLot.SelectedTab == tbpLot)
            {
                spdData = spdPlannedLot;
            }
            else if (tabPlannedLot.SelectedTab == tbpMaterial)
            {
                spdData = spdMatPlannedLot;
            }

            sCond = "Material : " + MPCF.Trim(cdvMaterial.Text) + "\r";
            sCond = sCond + "Date : " + MPCF.MakeDateFormat(MPCF.FromDate(dtpFrom)) + " ~ " + MPCF.MakeDateFormat(MPCF.ToDate(dtpTo));
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
    }
    //#End If
}
