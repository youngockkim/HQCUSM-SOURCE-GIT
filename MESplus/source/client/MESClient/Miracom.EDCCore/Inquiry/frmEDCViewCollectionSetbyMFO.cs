
using System.Diagnostics;
using System;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;

using Miracom.MsgHandler;
using System.Data;
using Miracom.MESCore;
using Miracom.CliFrx;
using FarPoint.Win.Spread;
using Miracom.TRSCore;

//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmEDCViewCollectionSetbyMFO.vb
//   Description : Collection Set Inquiry Form (which is attached to MFO )
//
//   MES Version : 4.1.0.0
//
//   Function List
//       - ClearData() : Intialize Form Field
//       - CheckCondition() : Check the conditions before transaction
//       - View_MFO_ColSet_List() :View MFO-Collection Set Relation
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2004-06-28 : Created by SKJIN
//       - 2008-01-18 : Modified by LAVERWON
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------

//Imports


namespace Miracom.EDCCore
{
    public class frmEDCViewCollectionSetbyMFO : Miracom.MESCore.TranForm01
    {

#if _EDC
        
#region " Windows Form auto generated code "
        
        public frmEDCViewCollectionSetbyMFO()
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
        



        private System.Windows.Forms.Panel pnlMiddle;
        private System.Windows.Forms.TabControl tabMFO;
        private System.Windows.Forms.Panel pnlFOTop;
        private System.Windows.Forms.GroupBox grpFO;
        private System.Windows.Forms.Label lblFlow;
        private System.Windows.Forms.Panel PnlMFOTop;
        private System.Windows.Forms.GroupBox grpMFO;
        private System.Windows.Forms.Panel pnlColSetListByMFO;
        public System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.TabPage tbpOper;
        private System.Windows.Forms.TabPage tbpFO;
        private System.Windows.Forms.TabPage tbpMFO;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvFlow;
        private Miracom.MESCore.Controls.udcMaterial cdvMaterial;
        private Miracom.MESCore.Controls.udcFlow cdvFlow2;
        private FpSpread spdOper;
        private SheetView spdOper_Sheet1;
        private FpSpread spdFO;
        private SheetView spdFO_Sheet1;
        private FpSpread spdMFO;
        private SheetView spdMFO_Sheet1;
        private TabPage tbpMO;
        private Panel pnlMOMid;
        private FpSpread spdMO;
        private SheetView spdMO_Sheet1;
        private Panel pnlMOTop;
        private GroupBox grpMO;
        private MESCore.Controls.udcMaterial cdvMaterial2;
        private System.Windows.Forms.Button btnRefresh;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer3 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer4 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer5 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer6 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.CellType.TextCellType textCellType3 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer7 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer8 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.CellType.TextCellType textCellType4 = new FarPoint.Win.Spread.CellType.TextCellType();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEDCViewCollectionSetbyMFO));
            this.pnlMiddle = new System.Windows.Forms.Panel();
            this.tabMFO = new System.Windows.Forms.TabControl();
            this.tbpOper = new System.Windows.Forms.TabPage();
            this.spdOper = new FarPoint.Win.Spread.FpSpread();
            this.spdOper_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.tbpFO = new System.Windows.Forms.TabPage();
            this.spdFO = new FarPoint.Win.Spread.FpSpread();
            this.spdFO_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.pnlFOTop = new System.Windows.Forms.Panel();
            this.grpFO = new System.Windows.Forms.GroupBox();
            this.cdvFlow = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblFlow = new System.Windows.Forms.Label();
            this.tbpMFO = new System.Windows.Forms.TabPage();
            this.pnlColSetListByMFO = new System.Windows.Forms.Panel();
            this.spdMFO = new FarPoint.Win.Spread.FpSpread();
            this.spdMFO_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.PnlMFOTop = new System.Windows.Forms.Panel();
            this.grpMFO = new System.Windows.Forms.GroupBox();
            this.cdvFlow2 = new Miracom.MESCore.Controls.udcFlow();
            this.cdvMaterial = new Miracom.MESCore.Controls.udcMaterial();
            this.tbpMO = new System.Windows.Forms.TabPage();
            this.pnlMOMid = new System.Windows.Forms.Panel();
            this.spdMO = new FarPoint.Win.Spread.FpSpread();
            this.spdMO_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.pnlMOTop = new System.Windows.Forms.Panel();
            this.grpMO = new System.Windows.Forms.GroupBox();
            this.cdvMaterial2 = new Miracom.MESCore.Controls.udcMaterial();
            this.btnExcel = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.pnlBottom.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlMiddle.SuspendLayout();
            this.tabMFO.SuspendLayout();
            this.tbpOper.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdOper)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdOper_Sheet1)).BeginInit();
            this.tbpFO.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdFO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdFO_Sheet1)).BeginInit();
            this.pnlFOTop.SuspendLayout();
            this.grpFO.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvFlow)).BeginInit();
            this.tbpMFO.SuspendLayout();
            this.pnlColSetListByMFO.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdMFO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdMFO_Sheet1)).BeginInit();
            this.PnlMFOTop.SuspendLayout();
            this.grpMFO.SuspendLayout();
            this.tbpMO.SuspendLayout();
            this.pnlMOMid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdMO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdMO_Sheet1)).BeginInit();
            this.pnlMOTop.SuspendLayout();
            this.grpMO.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnProcess
            // 
            this.btnProcess.Text = "View";
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnRefresh);
            this.pnlBottom.Controls.Add(this.btnExcel);
            this.pnlBottom.Location = new System.Drawing.Point(0, 513);
            this.pnlBottom.Controls.SetChildIndex(this.btnProcess, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnClose, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnExcel, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnRefresh, 0);
            // 
            // pnlCenter
            // 
            this.pnlCenter.Size = new System.Drawing.Size(742, 553);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "View Collection Set by MFO";
            // 
            // pnlMiddle
            // 
            this.pnlMiddle.Controls.Add(this.tabMFO);
            this.pnlMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMiddle.Location = new System.Drawing.Point(0, 0);
            this.pnlMiddle.Name = "pnlMiddle";
            this.pnlMiddle.Size = new System.Drawing.Size(742, 513);
            this.pnlMiddle.TabIndex = 1;
            // 
            // tabMFO
            // 
            this.tabMFO.Controls.Add(this.tbpOper);
            this.tabMFO.Controls.Add(this.tbpFO);
            this.tabMFO.Controls.Add(this.tbpMFO);
            this.tabMFO.Controls.Add(this.tbpMO);
            this.tabMFO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMFO.ItemSize = new System.Drawing.Size(60, 18);
            this.tabMFO.Location = new System.Drawing.Point(0, 0);
            this.tabMFO.Name = "tabMFO";
            this.tabMFO.SelectedIndex = 0;
            this.tabMFO.Size = new System.Drawing.Size(742, 513);
            this.tabMFO.TabIndex = 0;
            // 
            // tbpOper
            // 
            this.tbpOper.Controls.Add(this.spdOper);
            this.tbpOper.Location = new System.Drawing.Point(4, 22);
            this.tbpOper.Name = "tbpOper";
            this.tbpOper.Padding = new System.Windows.Forms.Padding(3);
            this.tbpOper.Size = new System.Drawing.Size(734, 487);
            this.tbpOper.TabIndex = 0;
            this.tbpOper.Text = "Operation";
            // 
            // spdOper
            // 
            this.spdOper.AccessibleDescription = "spdOper, Sheet1, Row 0, Column 0, ";
            this.spdOper.BackColor = System.Drawing.SystemColors.Control;
            this.spdOper.ButtonDrawMode = FarPoint.Win.Spread.ButtonDrawModes.CurrentRow;
            this.spdOper.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdOper.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdOper.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdOper.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdOper.HorizontalScrollBar.Name = "";
            this.spdOper.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdOper.HorizontalScrollBar.TabIndex = 2;
            this.spdOper.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdOper.Location = new System.Drawing.Point(3, 3);
            this.spdOper.Name = "spdOper";
            this.spdOper.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdOper.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdOper.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdOper_Sheet1});
            this.spdOper.Size = new System.Drawing.Size(728, 481);
            this.spdOper.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdOper.TabIndex = 1;
            this.spdOper.TabStop = false;
            this.spdOper.TextTipDelay = 200;
            this.spdOper.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdOper.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdOper.VerticalScrollBar.Name = "";
            this.spdOper.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdOper.VerticalScrollBar.TabIndex = 3;
            this.spdOper.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdOper.SetActiveViewport(0, -1, -1);
            // 
            // spdOper_Sheet1
            // 
            this.spdOper_Sheet1.Reset();
            spdOper_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdOper_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdOper_Sheet1.ColumnCount = 6;
            spdOper_Sheet1.RowCount = 0;
            this.spdOper_Sheet1.ActiveColumnIndex = -1;
            this.spdOper_Sheet1.ActiveRowIndex = -1;
            this.spdOper_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdOper_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdOper_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdOper_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdOper_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Operation";
            this.spdOper_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Description";
            this.spdOper_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Collection Set";
            this.spdOper_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Collection Mode";
            this.spdOper_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Default";
            this.spdOper_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Disable";
            this.spdOper_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdOper_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdOper_Sheet1.ColumnHeader.Rows.Get(0).Height = 18F;
            textCellType1.MaxLength = 20;
            this.spdOper_Sheet1.Columns.Get(0).CellType = textCellType1;
            this.spdOper_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdOper_Sheet1.Columns.Get(0).Label = "Operation";
            this.spdOper_Sheet1.Columns.Get(0).Locked = true;
            this.spdOper_Sheet1.Columns.Get(0).MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Always;
            this.spdOper_Sheet1.Columns.Get(0).ShowSortIndicator = false;
            this.spdOper_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOper_Sheet1.Columns.Get(0).Width = 70F;
            this.spdOper_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdOper_Sheet1.Columns.Get(1).Label = "Description";
            this.spdOper_Sheet1.Columns.Get(1).Locked = true;
            this.spdOper_Sheet1.Columns.Get(1).MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Restricted;
            this.spdOper_Sheet1.Columns.Get(1).ShowSortIndicator = false;
            this.spdOper_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOper_Sheet1.Columns.Get(1).Width = 200F;
            this.spdOper_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdOper_Sheet1.Columns.Get(2).Label = "Collection Set";
            this.spdOper_Sheet1.Columns.Get(2).Locked = true;
            this.spdOper_Sheet1.Columns.Get(2).ShowSortIndicator = false;
            this.spdOper_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOper_Sheet1.Columns.Get(2).Width = 185F;
            this.spdOper_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdOper_Sheet1.Columns.Get(3).Label = "Collection Mode";
            this.spdOper_Sheet1.Columns.Get(3).Locked = true;
            this.spdOper_Sheet1.Columns.Get(3).ShowSortIndicator = false;
            this.spdOper_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOper_Sheet1.Columns.Get(3).Width = 90F;
            this.spdOper_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdOper_Sheet1.Columns.Get(4).Label = "Default";
            this.spdOper_Sheet1.Columns.Get(4).Locked = true;
            this.spdOper_Sheet1.Columns.Get(4).ShowSortIndicator = false;
            this.spdOper_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOper_Sheet1.Columns.Get(4).Width = 45F;
            this.spdOper_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdOper_Sheet1.Columns.Get(5).Label = "Disable";
            this.spdOper_Sheet1.Columns.Get(5).Locked = true;
            this.spdOper_Sheet1.Columns.Get(5).ShowSortIndicator = false;
            this.spdOper_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOper_Sheet1.Columns.Get(5).Width = 45F;
            this.spdOper_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdOper_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;
            this.spdOper_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdOper_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdOper_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdOper_Sheet1.Rows.Default.Height = 18F;
            this.spdOper_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.spdOper_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdOper_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdOper_Sheet1.VisualStyles = FarPoint.Win.VisualStyles.Auto;
            this.spdOper_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // tbpFO
            // 
            this.tbpFO.Controls.Add(this.spdFO);
            this.tbpFO.Controls.Add(this.pnlFOTop);
            this.tbpFO.Location = new System.Drawing.Point(4, 22);
            this.tbpFO.Name = "tbpFO";
            this.tbpFO.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.tbpFO.Size = new System.Drawing.Size(734, 487);
            this.tbpFO.TabIndex = 1;
            this.tbpFO.Text = "Flow-Operation";
            this.tbpFO.Visible = false;
            // 
            // spdFO
            // 
            this.spdFO.AccessibleDescription = "spdFO, Sheet1, Row 0, Column 0, ";
            this.spdFO.BackColor = System.Drawing.SystemColors.Control;
            this.spdFO.ButtonDrawMode = FarPoint.Win.Spread.ButtonDrawModes.CurrentRow;
            this.spdFO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdFO.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdFO.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdFO.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdFO.HorizontalScrollBar.Name = "";
            this.spdFO.HorizontalScrollBar.Renderer = defaultScrollBarRenderer3;
            this.spdFO.HorizontalScrollBar.TabIndex = 2;
            this.spdFO.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdFO.Location = new System.Drawing.Point(3, 46);
            this.spdFO.Name = "spdFO";
            this.spdFO.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdFO.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdFO.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdFO_Sheet1});
            this.spdFO.Size = new System.Drawing.Size(728, 438);
            this.spdFO.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdFO.TabIndex = 2;
            this.spdFO.TabStop = false;
            this.spdFO.TextTipDelay = 200;
            this.spdFO.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdFO.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdFO.VerticalScrollBar.Name = "";
            this.spdFO.VerticalScrollBar.Renderer = defaultScrollBarRenderer4;
            this.spdFO.VerticalScrollBar.TabIndex = 3;
            this.spdFO.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdFO.SetActiveViewport(0, -1, -1);
            // 
            // spdFO_Sheet1
            // 
            this.spdFO_Sheet1.Reset();
            spdFO_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdFO_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdFO_Sheet1.ColumnCount = 6;
            spdFO_Sheet1.RowCount = 0;
            this.spdFO_Sheet1.ActiveColumnIndex = -1;
            this.spdFO_Sheet1.ActiveRowIndex = -1;
            this.spdFO_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdFO_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdFO_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdFO_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdFO_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Operation";
            this.spdFO_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Description";
            this.spdFO_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Collection Set";
            this.spdFO_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Collection Mode";
            this.spdFO_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Default";
            this.spdFO_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Disable";
            this.spdFO_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdFO_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdFO_Sheet1.ColumnHeader.Rows.Get(0).Height = 18F;
            textCellType2.MaxLength = 20;
            this.spdFO_Sheet1.Columns.Get(0).CellType = textCellType2;
            this.spdFO_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdFO_Sheet1.Columns.Get(0).Label = "Operation";
            this.spdFO_Sheet1.Columns.Get(0).Locked = true;
            this.spdFO_Sheet1.Columns.Get(0).MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Always;
            this.spdFO_Sheet1.Columns.Get(0).ShowSortIndicator = false;
            this.spdFO_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdFO_Sheet1.Columns.Get(0).Width = 70F;
            this.spdFO_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdFO_Sheet1.Columns.Get(1).Label = "Description";
            this.spdFO_Sheet1.Columns.Get(1).Locked = true;
            this.spdFO_Sheet1.Columns.Get(1).MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Restricted;
            this.spdFO_Sheet1.Columns.Get(1).ShowSortIndicator = false;
            this.spdFO_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdFO_Sheet1.Columns.Get(1).Width = 200F;
            this.spdFO_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdFO_Sheet1.Columns.Get(2).Label = "Collection Set";
            this.spdFO_Sheet1.Columns.Get(2).Locked = true;
            this.spdFO_Sheet1.Columns.Get(2).ShowSortIndicator = false;
            this.spdFO_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdFO_Sheet1.Columns.Get(2).Width = 185F;
            this.spdFO_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdFO_Sheet1.Columns.Get(3).Label = "Collection Mode";
            this.spdFO_Sheet1.Columns.Get(3).Locked = true;
            this.spdFO_Sheet1.Columns.Get(3).ShowSortIndicator = false;
            this.spdFO_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdFO_Sheet1.Columns.Get(3).Width = 90F;
            this.spdFO_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdFO_Sheet1.Columns.Get(4).Label = "Default";
            this.spdFO_Sheet1.Columns.Get(4).Locked = true;
            this.spdFO_Sheet1.Columns.Get(4).ShowSortIndicator = false;
            this.spdFO_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdFO_Sheet1.Columns.Get(4).Width = 45F;
            this.spdFO_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdFO_Sheet1.Columns.Get(5).Label = "Disable";
            this.spdFO_Sheet1.Columns.Get(5).Locked = true;
            this.spdFO_Sheet1.Columns.Get(5).ShowSortIndicator = false;
            this.spdFO_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdFO_Sheet1.Columns.Get(5).Width = 45F;
            this.spdFO_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdFO_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;
            this.spdFO_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdFO_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdFO_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdFO_Sheet1.Rows.Default.Height = 18F;
            this.spdFO_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.spdFO_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdFO_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdFO_Sheet1.VisualStyles = FarPoint.Win.VisualStyles.Auto;
            this.spdFO_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // pnlFOTop
            // 
            this.pnlFOTop.Controls.Add(this.grpFO);
            this.pnlFOTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFOTop.Location = new System.Drawing.Point(3, 0);
            this.pnlFOTop.Name = "pnlFOTop";
            this.pnlFOTop.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.pnlFOTop.Size = new System.Drawing.Size(728, 46);
            this.pnlFOTop.TabIndex = 0;
            // 
            // grpFO
            // 
            this.grpFO.Controls.Add(this.cdvFlow);
            this.grpFO.Controls.Add(this.lblFlow);
            this.grpFO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpFO.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpFO.Location = new System.Drawing.Point(0, 0);
            this.grpFO.Name = "grpFO";
            this.grpFO.Size = new System.Drawing.Size(728, 43);
            this.grpFO.TabIndex = 9;
            this.grpFO.TabStop = false;
            // 
            // cdvFlow
            // 
            this.cdvFlow.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cdvFlow.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvFlow.BorderHotColor = System.Drawing.Color.Black;
            this.cdvFlow.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvFlow.BtnToolTipText = "";
            this.cdvFlow.DescText = "";
            this.cdvFlow.DisplaySubItemIndex = 1;
            this.cdvFlow.DisplayText = "";
            this.cdvFlow.Focusing = null;
            this.cdvFlow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvFlow.Index = 0;
            this.cdvFlow.IsViewBtnImage = false;
            this.cdvFlow.Location = new System.Drawing.Point(122, 16);
            this.cdvFlow.MaxLength = 20;
            this.cdvFlow.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvFlow.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvFlow.Name = "cdvFlow";
            this.cdvFlow.ReadOnly = false;
            this.cdvFlow.SearchSubItemIndex = 0;
            this.cdvFlow.SelectedDescIndex = -1;
            this.cdvFlow.SelectedSubItemIndex = -1;
            this.cdvFlow.SelectionStart = 0;
            this.cdvFlow.Size = new System.Drawing.Size(598, 20);
            this.cdvFlow.SmallImageList = null;
            this.cdvFlow.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvFlow.TabIndex = 1;
            this.cdvFlow.TextBoxToolTipText = "";
            this.cdvFlow.TextBoxWidth = 200;
            this.cdvFlow.VisibleButton = true;
            this.cdvFlow.VisibleColumnHeader = false;
            this.cdvFlow.VisibleDescription = true;
            this.cdvFlow.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvFlow_SelectedItemChanged);
            this.cdvFlow.ButtonPress += new System.EventHandler(this.cdvFlow_ButtonPress);
            // 
            // lblFlow
            // 
            this.lblFlow.AutoSize = true;
            this.lblFlow.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblFlow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFlow.Location = new System.Drawing.Point(15, 19);
            this.lblFlow.Name = "lblFlow";
            this.lblFlow.Size = new System.Drawing.Size(33, 13);
            this.lblFlow.TabIndex = 0;
            this.lblFlow.Text = "Flow";
            this.lblFlow.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbpMFO
            // 
            this.tbpMFO.Controls.Add(this.pnlColSetListByMFO);
            this.tbpMFO.Controls.Add(this.PnlMFOTop);
            this.tbpMFO.Location = new System.Drawing.Point(4, 22);
            this.tbpMFO.Name = "tbpMFO";
            this.tbpMFO.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.tbpMFO.Size = new System.Drawing.Size(734, 487);
            this.tbpMFO.TabIndex = 2;
            this.tbpMFO.Text = "Material-Flow-Operation";
            this.tbpMFO.Visible = false;
            // 
            // pnlColSetListByMFO
            // 
            this.pnlColSetListByMFO.Controls.Add(this.spdMFO);
            this.pnlColSetListByMFO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlColSetListByMFO.Location = new System.Drawing.Point(3, 71);
            this.pnlColSetListByMFO.Name = "pnlColSetListByMFO";
            this.pnlColSetListByMFO.Size = new System.Drawing.Size(728, 413);
            this.pnlColSetListByMFO.TabIndex = 3;
            // 
            // spdMFO
            // 
            this.spdMFO.AccessibleDescription = "spdMFO, Sheet1, Row 0, Column 0, ";
            this.spdMFO.BackColor = System.Drawing.SystemColors.Control;
            this.spdMFO.ButtonDrawMode = FarPoint.Win.Spread.ButtonDrawModes.CurrentRow;
            this.spdMFO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdMFO.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdMFO.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdMFO.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdMFO.HorizontalScrollBar.Name = "";
            this.spdMFO.HorizontalScrollBar.Renderer = defaultScrollBarRenderer5;
            this.spdMFO.HorizontalScrollBar.TabIndex = 2;
            this.spdMFO.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdMFO.Location = new System.Drawing.Point(0, 0);
            this.spdMFO.Name = "spdMFO";
            this.spdMFO.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdMFO.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdMFO.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdMFO_Sheet1});
            this.spdMFO.Size = new System.Drawing.Size(728, 413);
            this.spdMFO.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdMFO.TabIndex = 2;
            this.spdMFO.TabStop = false;
            this.spdMFO.TextTipDelay = 200;
            this.spdMFO.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdMFO.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdMFO.VerticalScrollBar.Name = "";
            this.spdMFO.VerticalScrollBar.Renderer = defaultScrollBarRenderer6;
            this.spdMFO.VerticalScrollBar.TabIndex = 3;
            this.spdMFO.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdMFO.SetActiveViewport(0, -1, -1);
            // 
            // spdMFO_Sheet1
            // 
            this.spdMFO_Sheet1.Reset();
            spdMFO_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdMFO_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdMFO_Sheet1.ColumnCount = 6;
            spdMFO_Sheet1.RowCount = 0;
            this.spdMFO_Sheet1.ActiveColumnIndex = -1;
            this.spdMFO_Sheet1.ActiveRowIndex = -1;
            this.spdMFO_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdMFO_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdMFO_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdMFO_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdMFO_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Operation";
            this.spdMFO_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Description";
            this.spdMFO_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Collection Set";
            this.spdMFO_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Collection Mode";
            this.spdMFO_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Default";
            this.spdMFO_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Disable";
            this.spdMFO_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdMFO_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdMFO_Sheet1.ColumnHeader.Rows.Get(0).Height = 18F;
            textCellType3.MaxLength = 20;
            this.spdMFO_Sheet1.Columns.Get(0).CellType = textCellType3;
            this.spdMFO_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdMFO_Sheet1.Columns.Get(0).Label = "Operation";
            this.spdMFO_Sheet1.Columns.Get(0).Locked = true;
            this.spdMFO_Sheet1.Columns.Get(0).MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Always;
            this.spdMFO_Sheet1.Columns.Get(0).ShowSortIndicator = false;
            this.spdMFO_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMFO_Sheet1.Columns.Get(0).Width = 70F;
            this.spdMFO_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdMFO_Sheet1.Columns.Get(1).Label = "Description";
            this.spdMFO_Sheet1.Columns.Get(1).Locked = true;
            this.spdMFO_Sheet1.Columns.Get(1).MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Restricted;
            this.spdMFO_Sheet1.Columns.Get(1).ShowSortIndicator = false;
            this.spdMFO_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMFO_Sheet1.Columns.Get(1).Width = 200F;
            this.spdMFO_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdMFO_Sheet1.Columns.Get(2).Label = "Collection Set";
            this.spdMFO_Sheet1.Columns.Get(2).Locked = true;
            this.spdMFO_Sheet1.Columns.Get(2).ShowSortIndicator = false;
            this.spdMFO_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMFO_Sheet1.Columns.Get(2).Width = 185F;
            this.spdMFO_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdMFO_Sheet1.Columns.Get(3).Label = "Collection Mode";
            this.spdMFO_Sheet1.Columns.Get(3).Locked = true;
            this.spdMFO_Sheet1.Columns.Get(3).ShowSortIndicator = false;
            this.spdMFO_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMFO_Sheet1.Columns.Get(3).Width = 90F;
            this.spdMFO_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdMFO_Sheet1.Columns.Get(4).Label = "Default";
            this.spdMFO_Sheet1.Columns.Get(4).Locked = true;
            this.spdMFO_Sheet1.Columns.Get(4).ShowSortIndicator = false;
            this.spdMFO_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMFO_Sheet1.Columns.Get(4).Width = 45F;
            this.spdMFO_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdMFO_Sheet1.Columns.Get(5).Label = "Disable";
            this.spdMFO_Sheet1.Columns.Get(5).Locked = true;
            this.spdMFO_Sheet1.Columns.Get(5).ShowSortIndicator = false;
            this.spdMFO_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMFO_Sheet1.Columns.Get(5).Width = 45F;
            this.spdMFO_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdMFO_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;
            this.spdMFO_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdMFO_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdMFO_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdMFO_Sheet1.Rows.Default.Height = 18F;
            this.spdMFO_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.spdMFO_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdMFO_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdMFO_Sheet1.VisualStyles = FarPoint.Win.VisualStyles.Auto;
            this.spdMFO_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // PnlMFOTop
            // 
            this.PnlMFOTop.Controls.Add(this.grpMFO);
            this.PnlMFOTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlMFOTop.Location = new System.Drawing.Point(3, 0);
            this.PnlMFOTop.Name = "PnlMFOTop";
            this.PnlMFOTop.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.PnlMFOTop.Size = new System.Drawing.Size(728, 71);
            this.PnlMFOTop.TabIndex = 2;
            // 
            // grpMFO
            // 
            this.grpMFO.Controls.Add(this.cdvFlow2);
            this.grpMFO.Controls.Add(this.cdvMaterial);
            this.grpMFO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpMFO.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpMFO.Location = new System.Drawing.Point(0, 0);
            this.grpMFO.Name = "grpMFO";
            this.grpMFO.Size = new System.Drawing.Size(728, 68);
            this.grpMFO.TabIndex = 0;
            this.grpMFO.TabStop = false;
            // 
            // cdvFlow2
            // 
            this.cdvFlow2.AddEmptyRowToLast = false;
            this.cdvFlow2.AddEmptyRowToTop = false;
            this.cdvFlow2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cdvFlow2.ButtonWidth = 21;
            this.cdvFlow2.CodeViewBackColor = System.Drawing.SystemColors.Window;
            this.cdvFlow2.DisplaySubItemIndex = 0;
            this.cdvFlow2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvFlow2.LabelBackColor = System.Drawing.SystemColors.Control;
            this.cdvFlow2.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvFlow2.LabelText = "Flow";
            this.cdvFlow2.LabelWidth = 110;
            this.cdvFlow2.ListCond_ExtFactory = "";
            this.cdvFlow2.ListCond_Step = '3';
            this.cdvFlow2.Location = new System.Drawing.Point(12, 41);
            this.cdvFlow2.Name = "cdvFlow2";
            this.cdvFlow2.ReadOnly = false;
            this.cdvFlow2.SearchSubItemIndex = 0;
            this.cdvFlow2.SelectedDescIndex = 1;
            this.cdvFlow2.SelectedSubItemIndex = 0;
            this.cdvFlow2.Size = new System.Drawing.Size(708, 20);
            this.cdvFlow2.TabIndex = 3;
            this.cdvFlow2.TextBoxWidth = 200;
            this.cdvFlow2.VisibleButton = true;
            this.cdvFlow2.VisibleColumnHeader = false;
            this.cdvFlow2.VisibleDescription = true;
            this.cdvFlow2.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvFlow2_SelectedItemChanged);
            this.cdvFlow2.ButtonPress += new System.EventHandler(this.cdvFlow2_ButtonPress);
            // 
            // cdvMaterial
            // 
            this.cdvMaterial.AddEmptyRowToLast = false;
            this.cdvMaterial.AddEmptyRowToTop = false;
            this.cdvMaterial.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cdvMaterial.CodeViewBackColor = System.Drawing.SystemColors.Window;
            this.cdvMaterial.DisplaySubItemIndex = 0;
            this.cdvMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvMaterial.LabelBackColor = System.Drawing.SystemColors.Control;
            this.cdvMaterial.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvMaterial.LabelText = "Material";
            this.cdvMaterial.ListCond_ExtFactory = "";
            this.cdvMaterial.ListCond_StepMaterial = '1';
            this.cdvMaterial.ListCond_StepVersion = '1';
            this.cdvMaterial.Location = new System.Drawing.Point(12, 16);
            this.cdvMaterial.MaterialEnabled = true;
            this.cdvMaterial.MaterialReadOnly = false;
            this.cdvMaterial.Name = "cdvMaterial";
            this.cdvMaterial.SearchSubItemIndex = 0;
            this.cdvMaterial.SelectedDescIndex = 2;
            this.cdvMaterial.SelectedSubItemIndex = 0;
            this.cdvMaterial.Size = new System.Drawing.Size(708, 20);
            this.cdvMaterial.TabIndex = 0;
            this.cdvMaterial.VersionEnabled = true;
            this.cdvMaterial.VersionReadOnly = false;
            this.cdvMaterial.VisibleColumnHeader = false;
            this.cdvMaterial.VisibleDescription = true;
            this.cdvMaterial.VisibleMaterialButton = true;
            this.cdvMaterial.VisibleVersionButton = true;
            this.cdvMaterial.WidthButton = 20;
            this.cdvMaterial.WidthLabel = 110;
            this.cdvMaterial.WidthMaterialAndVersion = 200;
            this.cdvMaterial.WidthVersion = 50;
            this.cdvMaterial.MaterialSelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvMaterial_SelectedItemChanged);
            this.cdvMaterial.VersionSelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvMaterial_SelectedItemChanged);
            // 
            // tbpMO
            // 
            this.tbpMO.Controls.Add(this.pnlMOMid);
            this.tbpMO.Controls.Add(this.pnlMOTop);
            this.tbpMO.Location = new System.Drawing.Point(4, 22);
            this.tbpMO.Name = "tbpMO";
            this.tbpMO.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.tbpMO.Size = new System.Drawing.Size(734, 487);
            this.tbpMO.TabIndex = 3;
            this.tbpMO.Text = "Material-Operation";
            // 
            // pnlMOMid
            // 
            this.pnlMOMid.Controls.Add(this.spdMO);
            this.pnlMOMid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMOMid.Location = new System.Drawing.Point(3, 46);
            this.pnlMOMid.Name = "pnlMOMid";
            this.pnlMOMid.Size = new System.Drawing.Size(728, 438);
            this.pnlMOMid.TabIndex = 4;
            // 
            // spdMO
            // 
            this.spdMO.AccessibleDescription = "spdMO, Sheet1, Row 0, Column 0, ";
            this.spdMO.BackColor = System.Drawing.SystemColors.Control;
            this.spdMO.ButtonDrawMode = FarPoint.Win.Spread.ButtonDrawModes.CurrentRow;
            this.spdMO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdMO.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdMO.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdMO.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdMO.HorizontalScrollBar.Name = "";
            this.spdMO.HorizontalScrollBar.Renderer = defaultScrollBarRenderer7;
            this.spdMO.HorizontalScrollBar.TabIndex = 2;
            this.spdMO.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdMO.Location = new System.Drawing.Point(0, 0);
            this.spdMO.Name = "spdMO";
            this.spdMO.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdMO.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdMO.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdMO_Sheet1});
            this.spdMO.Size = new System.Drawing.Size(728, 438);
            this.spdMO.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdMO.TabIndex = 2;
            this.spdMO.TabStop = false;
            this.spdMO.TextTipDelay = 200;
            this.spdMO.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdMO.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdMO.VerticalScrollBar.Name = "";
            this.spdMO.VerticalScrollBar.Renderer = defaultScrollBarRenderer8;
            this.spdMO.VerticalScrollBar.TabIndex = 3;
            this.spdMO.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdMO.SetActiveViewport(0, -1, -1);
            // 
            // spdMO_Sheet1
            // 
            this.spdMO_Sheet1.Reset();
            spdMO_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdMO_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdMO_Sheet1.ColumnCount = 6;
            spdMO_Sheet1.RowCount = 0;
            this.spdMO_Sheet1.ActiveColumnIndex = -1;
            this.spdMO_Sheet1.ActiveRowIndex = -1;
            this.spdMO_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdMO_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdMO_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdMO_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdMO_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Operation";
            this.spdMO_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Description";
            this.spdMO_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Collection Set";
            this.spdMO_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Collection Mode";
            this.spdMO_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Default";
            this.spdMO_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Disable";
            this.spdMO_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdMO_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdMO_Sheet1.ColumnHeader.Rows.Get(0).Height = 18F;
            textCellType4.MaxLength = 20;
            this.spdMO_Sheet1.Columns.Get(0).CellType = textCellType4;
            this.spdMO_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdMO_Sheet1.Columns.Get(0).Label = "Operation";
            this.spdMO_Sheet1.Columns.Get(0).Locked = true;
            this.spdMO_Sheet1.Columns.Get(0).MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Always;
            this.spdMO_Sheet1.Columns.Get(0).ShowSortIndicator = false;
            this.spdMO_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMO_Sheet1.Columns.Get(0).Width = 70F;
            this.spdMO_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdMO_Sheet1.Columns.Get(1).Label = "Description";
            this.spdMO_Sheet1.Columns.Get(1).Locked = true;
            this.spdMO_Sheet1.Columns.Get(1).MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Restricted;
            this.spdMO_Sheet1.Columns.Get(1).ShowSortIndicator = false;
            this.spdMO_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMO_Sheet1.Columns.Get(1).Width = 200F;
            this.spdMO_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdMO_Sheet1.Columns.Get(2).Label = "Collection Set";
            this.spdMO_Sheet1.Columns.Get(2).Locked = true;
            this.spdMO_Sheet1.Columns.Get(2).ShowSortIndicator = false;
            this.spdMO_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMO_Sheet1.Columns.Get(2).Width = 185F;
            this.spdMO_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdMO_Sheet1.Columns.Get(3).Label = "Collection Mode";
            this.spdMO_Sheet1.Columns.Get(3).Locked = true;
            this.spdMO_Sheet1.Columns.Get(3).ShowSortIndicator = false;
            this.spdMO_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMO_Sheet1.Columns.Get(3).Width = 90F;
            this.spdMO_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdMO_Sheet1.Columns.Get(4).Label = "Default";
            this.spdMO_Sheet1.Columns.Get(4).Locked = true;
            this.spdMO_Sheet1.Columns.Get(4).ShowSortIndicator = false;
            this.spdMO_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMO_Sheet1.Columns.Get(4).Width = 45F;
            this.spdMO_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdMO_Sheet1.Columns.Get(5).Label = "Disable";
            this.spdMO_Sheet1.Columns.Get(5).Locked = true;
            this.spdMO_Sheet1.Columns.Get(5).ShowSortIndicator = false;
            this.spdMO_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMO_Sheet1.Columns.Get(5).Width = 45F;
            this.spdMO_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdMO_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;
            this.spdMO_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdMO_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdMO_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdMO_Sheet1.Rows.Default.Height = 18F;
            this.spdMO_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.spdMO_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdMO_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdMO_Sheet1.VisualStyles = FarPoint.Win.VisualStyles.Auto;
            this.spdMO_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // pnlMOTop
            // 
            this.pnlMOTop.Controls.Add(this.grpMO);
            this.pnlMOTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMOTop.Location = new System.Drawing.Point(3, 0);
            this.pnlMOTop.Name = "pnlMOTop";
            this.pnlMOTop.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.pnlMOTop.Size = new System.Drawing.Size(728, 46);
            this.pnlMOTop.TabIndex = 3;
            // 
            // grpMO
            // 
            this.grpMO.Controls.Add(this.cdvMaterial2);
            this.grpMO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpMO.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpMO.Location = new System.Drawing.Point(0, 0);
            this.grpMO.Name = "grpMO";
            this.grpMO.Size = new System.Drawing.Size(728, 43);
            this.grpMO.TabIndex = 0;
            this.grpMO.TabStop = false;
            // 
            // cdvMaterial2
            // 
            this.cdvMaterial2.AddEmptyRowToLast = false;
            this.cdvMaterial2.AddEmptyRowToTop = false;
            this.cdvMaterial2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cdvMaterial2.CodeViewBackColor = System.Drawing.SystemColors.Window;
            this.cdvMaterial2.DisplaySubItemIndex = 0;
            this.cdvMaterial2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvMaterial2.LabelBackColor = System.Drawing.SystemColors.Control;
            this.cdvMaterial2.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvMaterial2.LabelText = "Material";
            this.cdvMaterial2.ListCond_ExtFactory = "";
            this.cdvMaterial2.ListCond_StepMaterial = '1';
            this.cdvMaterial2.ListCond_StepVersion = '1';
            this.cdvMaterial2.Location = new System.Drawing.Point(12, 16);
            this.cdvMaterial2.MaterialEnabled = true;
            this.cdvMaterial2.MaterialReadOnly = false;
            this.cdvMaterial2.Name = "cdvMaterial2";
            this.cdvMaterial2.SearchSubItemIndex = 0;
            this.cdvMaterial2.SelectedDescIndex = 2;
            this.cdvMaterial2.SelectedSubItemIndex = 0;
            this.cdvMaterial2.Size = new System.Drawing.Size(708, 20);
            this.cdvMaterial2.TabIndex = 0;
            this.cdvMaterial2.VersionEnabled = true;
            this.cdvMaterial2.VersionReadOnly = false;
            this.cdvMaterial2.VisibleColumnHeader = false;
            this.cdvMaterial2.VisibleDescription = true;
            this.cdvMaterial2.VisibleMaterialButton = true;
            this.cdvMaterial2.VisibleVersionButton = true;
            this.cdvMaterial2.WidthButton = 20;
            this.cdvMaterial2.WidthLabel = 110;
            this.cdvMaterial2.WidthMaterialAndVersion = 200;
            this.cdvMaterial2.WidthVersion = 50;
            this.cdvMaterial2.MaterialSelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvMaterial2_MaterialSelectedItemChanged);
            this.cdvMaterial2.VersionSelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvMaterial2_VersionSelectedItemChanged);
            // 
            // btnExcel
            // 
            this.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExcel.Image")));
            this.btnExcel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnExcel.Location = new System.Drawing.Point(12, 8);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(24, 24);
            this.btnExcel.TabIndex = 2;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnRefresh.Location = new System.Drawing.Point(40, 8);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(24, 24);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // frmEDCViewCollectionSetbyMFO
            // 
            this.AcceptButton = this.btnRefresh;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Controls.Add(this.pnlMiddle);
            this.Name = "frmEDCViewCollectionSetbyMFO";
            this.Text = "View Collection Set by MFO";
            this.Activated += new System.EventHandler(this.frmEDCViewCollectionSetbyMFO_Activated);
            this.Controls.SetChildIndex(this.pnlCenter, 0);
            this.Controls.SetChildIndex(this.pnlTop, 0);
            this.Controls.SetChildIndex(this.pnlBottom, 0);
            this.Controls.SetChildIndex(this.pnlMiddle, 0);
            this.pnlBottom.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlMiddle.ResumeLayout(false);
            this.tabMFO.ResumeLayout(false);
            this.tbpOper.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdOper)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdOper_Sheet1)).EndInit();
            this.tbpFO.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdFO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdFO_Sheet1)).EndInit();
            this.pnlFOTop.ResumeLayout(false);
            this.grpFO.ResumeLayout(false);
            this.grpFO.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvFlow)).EndInit();
            this.tbpMFO.ResumeLayout(false);
            this.pnlColSetListByMFO.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdMFO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdMFO_Sheet1)).EndInit();
            this.PnlMFOTop.ResumeLayout(false);
            this.grpMFO.ResumeLayout(false);
            this.tbpMO.ResumeLayout(false);
            this.pnlMOMid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdMO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdMO_Sheet1)).EndInit();
            this.pnlMOTop.ResumeLayout(false);
            this.grpMO.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        
#endregion
        
#region " Constant Definition "

        private const int MAX_MFO_COUNT = 5000;

        private const int COL_OPER = 0;
        private const int COL_OPER_DESC = 1;
        private const int COL_COL_SET_ID = 2;
        private const int COL_COL_MODE = 3;
        private const int COL_DEFUALT_FLAG = 4;
        private const int COL_DISABLE_FLAG = 5;
        
#endregion
        
#region " Variable Definition "
        
        private struct Format
        {
            //private string Col_Fmt;
            //private int Col_Size;
        }
        
        Format[] FormatTbl = new Format[21];
        
        bool LoadFlag;
        //string sCellValue;
        
#endregion
        
#region " Function Definition "
        
        //
        // ClearData()
        //       - Initalize form fields
        // Return Value
        //       -
        // Arguments
        //       - Optional ByVal ProcStep As String ("1", "2", "3")
        //
        private void ClearData(char ProcStep)
        {
            try
            {
                if (ProcStep == '1')
                {
                    if (tabMFO.SelectedTab == tbpOper)
                    {
                        MPCF.ClearList(spdOper);
                    }
                    else if (tabMFO.SelectedTab == tbpFO)
                    {
                        MPCF.ClearList(spdFO);
                    }
                    else if (tabMFO.SelectedTab == tbpMFO)
                    {
                        MPCF.ClearList(spdMFO);
                    }
                    else if (tabMFO.SelectedTab == tbpMO)
                    {
                        MPCF.ClearList(spdMO);
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        
        //
        // View_MFO_ColSet_List()
        //       - View MFO-Collection Set Relation List
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool View_MFO_ColSet_List(char ProcStep, char OptLevel)
        {
            int i;
            int LastRow = 0;

            TRSNode in_node = new TRSNode("VIEW_MFO_COLSET_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_MFO_COLSET_LIST_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                ClearData('1');
                in_node.ProcStep = ProcStep;
                in_node.AddChar("OPT_LEVEL", OptLevel);

                FarPoint.Win.Spread.SheetView spdListView = null;

                if (OptLevel == '1')
                {
                    in_node.SetString("MAT_ID", MPCF.Trim(cdvMaterial.Text));
                    in_node.SetInt("MAT_VER", cdvMaterial.Version);
                    in_node.SetString("FLOW", MPCF.Trim(cdvFlow2.Text));

                    spdListView = spdMFO.Sheets[0];
                }
                else if (OptLevel == '2')
                {
                    in_node.SetString("FLOW", MPCF.Trim(cdvFlow.Text));

                    spdListView = spdFO.Sheets[0];
                }
                else if (OptLevel == '3')
                {
                    in_node.SetString("FLOW", MPCF.Trim(cdvFlow.Text));

                    spdListView = spdOper.Sheets[0];
                }
                else if (OptLevel == '4')
                {
                    in_node.SetString("MAT_ID", MPCF.Trim(cdvMaterial2.Text));
                    in_node.SetInt("MAT_VER", cdvMaterial2.Version);

                    spdListView = spdMO.Sheets[0];
                }
                else
                {
                    return false;
                }

                do
                {
                    if (MPCR.CallService("EDC", "EDC_View_MFO_ColSet_List", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        spdListView.RowCount++;
                        LastRow = spdListView.RowCount - 1;

                        spdListView.SetValue(LastRow, COL_OPER, MPCF.Trim(out_node.GetList(0)[i].GetString("OPER")));
                        spdListView.SetValue(LastRow, COL_OPER_DESC, MPCF.Trim(out_node.GetList(0)[i].GetString("OPER_DESC")));
                        spdListView.SetValue(LastRow, COL_COL_SET_ID, MPCF.Trim(out_node.GetList(0)[i].GetString("COL_SET_ID")));
                        if (MPCF.Trim(out_node.GetList(0)[i].GetChar("COLLECTION_MODE")) == "A")
                        {
                            spdListView.SetValue(LastRow, COL_COL_MODE, "Auto");
                        }
                        else if (MPCF.Trim(out_node.GetList(0)[i].GetChar("COLLECTION_MODE")) == "M")
                        {
                            spdListView.SetValue(LastRow, COL_COL_MODE, "Manual");
                        }

                        spdListView.SetValue(LastRow, COL_DEFUALT_FLAG, MPCF.Trim(out_node.GetList(0)[i].GetChar("DEFAULT_FLAG")));
                        spdListView.SetValue(LastRow, COL_DISABLE_FLAG, MPCF.Trim(out_node.GetList(0)[i].GetChar("DISABLE_FLAG")));
                    }

                    in_node.SetString("NEXT_OPER", out_node.GetString("NEXT_OPER"));
                    in_node.SetInt("NEXT_SEQ", out_node.GetInt("NEXT_SEQ"));
                    in_node.SetString("NEXT_COL_SET_ID", out_node.GetString("NEXT_COL_SET_ID"));

                } while (in_node.GetString("NEXT_OPER") != "" ||
                        in_node.GetInt("NEXT_SEQ") > 0 ||
                        in_node.GetString("NEXT_COL_SET_ID") != "");
                                
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
                return this.tabMFO;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }
            
        }
        
#endregion

        private void frmEDCViewCollectionSetbyMFO_Activated(object sender, System.EventArgs e)
        {
            
            try
            {
                if (LoadFlag == false)
                {
                    tabMFO.SelectedTab = tbpOper;
                    
                    if (View_MFO_ColSet_List('1', '3') == false)
                    {
                        return;
                    }
                    LoadFlag = true;
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void cdvFlow_SelectedItemChanged(System.Object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {

            try
            {
                if (cdvFlow.Text == "")
                {
                    ClearData('1');
                }
                else
                {
                    View_MFO_ColSet_List('1', '2');
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }

        private void cdvMaterial_SelectedItemChanged(System.Object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {

            try
            {
                if (cdvMaterial.Text == "")
                {
                    ClearData('1');
                    cdvFlow2.Text = "";
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }

        private void cdvFlow_ButtonPress(object sender, System.EventArgs e)
        {

            try
            {
                cdvFlow.Init();
                MPCF.InitListView(cdvFlow.GetListView);
                cdvFlow.Columns.Add("Flow", 100, HorizontalAlignment.Left);
                cdvFlow.Columns.Add("Desc", 200, HorizontalAlignment.Left);
                cdvFlow.SelectedSubItemIndex = 0;
                cdvFlow.DisplaySubItemIndex = 0;
                cdvFlow.SelectedDescIndex = 1;
                cdvFlow.ReadOnly = true;
                WIPLIST.ViewFlowList(cdvFlow.GetListView, '1', "", 0, "", null, "");

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }

        private void cdvFlow2_ButtonPress(object sender, System.EventArgs e)
        {
            try
            {
                if (cdvMaterial.CheckValue() == false) return;

                cdvFlow2.ListCond_MatID = cdvMaterial.Text;
                cdvFlow2.ListCond_MatVersion = cdvMaterial.Version;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }

        private void cdvFlow2_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            try
            {
                if (cdvMaterial.Text != "" && cdvFlow2.Text != "")
                {
                    ClearData('1');
                    View_MFO_ColSet_List('1', '1');
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }

        private void cdvMaterial2_MaterialSelectedItemChanged(object sender, UI.MCCodeViewSelChanged_EventArgs e)
        {
            try
            {
                if (cdvMaterial2.Text != "")
                {
                    ClearData('1');
                    View_MFO_ColSet_List('1', '4');
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvMaterial2_VersionSelectedItemChanged(object sender, UI.MCCodeViewSelChanged_EventArgs e)
        {
            cdvMaterial2_MaterialSelectedItemChanged(null, null);
        }

        private void btnExcel_Click(System.Object sender, System.EventArgs e)
        {
            string sCond = "";
            FarPoint.Win.Spread.FpSpread spdTmp = new FpSpread();

            try
            {
                if (tabMFO.SelectedTab == tbpOper)
                {
                    spdTmp = spdOper;
                }
                else if (tabMFO.SelectedTab == tbpFO)
                {
                    sCond = "Flow : " + cdvFlow.Text;
                    spdTmp = spdFO;
                }
                else if (tabMFO.SelectedTab == tbpMFO)
                {
                    sCond = "Material : " + cdvMaterial.Text + ", Flow : " + cdvFlow2.Text;
                    spdTmp = spdMFO;
                }
                else if (tabMFO.SelectedTab == tbpMO)
                {
                    sCond = "Material : " + cdvMaterial2.Text;
                    spdTmp = spdMO;
                }

                if (MPCF.ExportToExcel(spdTmp, this.Text, sCond, true, true, true, -1, -1) == false)
                {
                    return;
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void btnProcess_Click(System.Object sender, System.EventArgs e)
        {

            try
            {
                if (tabMFO.SelectedTab == tbpOper)
                {
                    View_MFO_ColSet_List('1', '3');
                }
                else if (tabMFO.SelectedTab == tbpFO)
                {
                    if (MPCF.CheckValue(cdvFlow, 1) == false)
                    {
                        return;
                    }
                    View_MFO_ColSet_List('1', '2');
                }
                else if (tabMFO.SelectedTab == tbpMFO)
                {
                    if (cdvMaterial.CheckValue() == false)
                    {
                        return;
                    }
                    View_MFO_ColSet_List('1', '1');
                }
                else if (tabMFO.SelectedTab == tbpMO)
                {
                    if (cdvMaterial2.CheckValue() == false)
                    {
                        return;
                    }
                    View_MFO_ColSet_List('1', '4');
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void btnRefresh_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                if (tabMFO.SelectedTab == this.tbpOper)
                {
                    View_MFO_ColSet_List('1', '3');
                }
                else if (tabMFO.SelectedTab == this.tbpFO)
                {
                    View_MFO_ColSet_List('1', '2');
                }
                else if (tabMFO.SelectedTab == this.tbpMFO)
                {
                    View_MFO_ColSet_List('1', '1');
                }
                else if (tabMFO.SelectedTab == this.tbpMO)
                {
                    View_MFO_ColSet_List('1', '4');
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        
#endif // _EDC

    }
    
}
