
//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmWIPSetupBatchKeepMFO.vb
//   Description : Batch Keep Flag Setup
//
//   MES Version : 4.1.0.0
//
//   Function List
//       - ClearData() : Intialize Form Field
//       - CheckCondition() : Check the conditions before transaction
//       - View_MFO_Batch_Keep_List() :View MFO-Recipe Set Relation
//       - Update_MFO_Batch_Keep_List() : Attach/Detach Recipe to MFO, FO, O
//       - initCodeView() : initial CodeView Control
//
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2005-06-29 : Created by HS KIM
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------

//Imports
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


namespace Miracom.WIPCore
{
    public class frmWIPSetupBatchKeepMFO : Miracom.MESCore.SetupForm01
    {
        
        #region " Windows Form auto generated code "
        
        public frmWIPSetupBatchKeepMFO()
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
        



        private System.Windows.Forms.TabControl tabMFO;
        private System.Windows.Forms.TabPage tbpOper;
        private FarPoint.Win.Spread.FpSpread spdOper;
        private System.Windows.Forms.TabPage tbpFO;
        private System.Windows.Forms.Panel pnlFOMid;
        private FarPoint.Win.Spread.FpSpread spdFO;
        private System.Windows.Forms.GroupBox grpFO;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvFlow;
        private System.Windows.Forms.Label lblFlow;
        private System.Windows.Forms.TabPage tbpMFO;
        private System.Windows.Forms.Panel pnlMFOMid;
        private FarPoint.Win.Spread.FpSpread spdMFO;
        private System.Windows.Forms.GroupBox grpMFO;
        private FarPoint.Win.Spread.SheetView spdOper_Sheet1;
        private FarPoint.Win.Spread.SheetView spdFO_Sheet1;
        private FarPoint.Win.Spread.SheetView spdMFO_Sheet1;
        private Miracom.UI.Controls.MCCodeView.MCSPCodeView cdvBatch;
        private Miracom.MESCore.Controls.udcMaterial cdvMaterial;
        protected Button btnExcel;
        private System.Windows.Forms.Button btnRefresh;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer2 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer7 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer8 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType4 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType7 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType8 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.ButtonCellType buttonCellType4 = new FarPoint.Win.Spread.CellType.ButtonCellType();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType5 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType9 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType10 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.ButtonCellType buttonCellType5 = new FarPoint.Win.Spread.CellType.ButtonCellType();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer3 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer4 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType6 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType11 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType12 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.ButtonCellType buttonCellType6 = new FarPoint.Win.Spread.CellType.ButtonCellType();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWIPSetupBatchKeepMFO));
            this.tabMFO = new System.Windows.Forms.TabControl();
            this.tbpOper = new System.Windows.Forms.TabPage();
            this.spdOper = new FarPoint.Win.Spread.FpSpread();
            this.spdOper_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.tbpFO = new System.Windows.Forms.TabPage();
            this.pnlFOMid = new System.Windows.Forms.Panel();
            this.spdFO = new FarPoint.Win.Spread.FpSpread();
            this.spdFO_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.grpFO = new System.Windows.Forms.GroupBox();
            this.cdvFlow = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblFlow = new System.Windows.Forms.Label();
            this.tbpMFO = new System.Windows.Forms.TabPage();
            this.pnlMFOMid = new System.Windows.Forms.Panel();
            this.spdMFO = new FarPoint.Win.Spread.FpSpread();
            this.spdMFO_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.grpMFO = new System.Windows.Forms.GroupBox();
            this.cdvMaterial = new Miracom.MESCore.Controls.udcMaterial();
            this.cdvBatch = new Miracom.UI.Controls.MCCodeView.MCSPCodeView();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnExcel = new System.Windows.Forms.Button();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.tabMFO.SuspendLayout();
            this.tbpOper.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdOper)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdOper_Sheet1)).BeginInit();
            this.tbpFO.SuspendLayout();
            this.pnlFOMid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdFO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdFO_Sheet1)).BeginInit();
            this.grpFO.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvFlow)).BeginInit();
            this.tbpMFO.SuspendLayout();
            this.pnlMFOMid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdMFO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdMFO_Sheet1)).BeginInit();
            this.grpMFO.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvBatch)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCreate
            // 
            this.btnCreate.TabIndex = 1;
            this.btnCreate.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(467, 7);
            this.btnDelete.Visible = false;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(558, 7);
            this.btnUpdate.TabIndex = 3;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnClose
            // 
            this.btnClose.TabIndex = 4;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnExcel);
            this.pnlBottom.Controls.Add(this.btnRefresh);
            this.pnlBottom.Location = new System.Drawing.Point(0, 513);
            this.pnlBottom.TabIndex = 0;
            this.pnlBottom.Controls.SetChildIndex(this.btnClose, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnUpdate, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnDelete, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnCreate, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnRefresh, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnExcel, 0);
            // 
            // pnlCenter
            // 
            this.pnlCenter.Controls.Add(this.tabMFO);
            this.pnlCenter.Size = new System.Drawing.Size(742, 513);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "Batch Keep Flag Setup";
            // 
            // tabMFO
            // 
            this.tabMFO.Controls.Add(this.tbpOper);
            this.tabMFO.Controls.Add(this.tbpFO);
            this.tabMFO.Controls.Add(this.tbpMFO);
            this.tabMFO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMFO.ItemSize = new System.Drawing.Size(60, 18);
            this.tabMFO.Location = new System.Drawing.Point(0, 0);
            this.tabMFO.Name = "tabMFO";
            this.tabMFO.SelectedIndex = 0;
            this.tabMFO.Size = new System.Drawing.Size(742, 513);
            this.tabMFO.TabIndex = 0;
            this.tabMFO.SelectedIndexChanged += new System.EventHandler(this.tabMFO_SelectedIndexChanged);
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
            this.spdOper.AccessibleDescription = "";
            this.spdOper.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdOper.FocusRenderer = defaultFocusIndicatorRenderer2;
            this.spdOper.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdOper.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdOper.HorizontalScrollBar.Name = "";
            this.spdOper.HorizontalScrollBar.Renderer = defaultScrollBarRenderer7;
            this.spdOper.HorizontalScrollBar.TabIndex = 2;
            this.spdOper.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            this.spdOper.Location = new System.Drawing.Point(3, 3);
            this.spdOper.Name = "spdOper";
            this.spdOper.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdOper.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdOper.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdOper_Sheet1});
            this.spdOper.Size = new System.Drawing.Size(728, 481);
            this.spdOper.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdOper.TabIndex = 0;
            this.spdOper.TabStop = false;
            this.spdOper.TextTipDelay = 200;
            this.spdOper.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdOper.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdOper.VerticalScrollBar.Name = "";
            this.spdOper.VerticalScrollBar.Renderer = defaultScrollBarRenderer8;
            this.spdOper.VerticalScrollBar.TabIndex = 3;
            this.spdOper.Change += new FarPoint.Win.Spread.ChangeEventHandler(this.spdOper_Change);
            this.spdOper.ButtonClicked += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.spdOper_ButtonClicked);
            this.spdOper.SetActiveViewport(0, -1, -1);
            // 
            // spdOper_Sheet1
            // 
            this.spdOper_Sheet1.Reset();
            spdOper_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdOper_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdOper_Sheet1.ColumnCount = 5;
            spdOper_Sheet1.RowCount = 0;
            this.spdOper_Sheet1.ActiveColumnIndex = -1;
            this.spdOper_Sheet1.ActiveRowIndex = -1;
            this.spdOper_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdOper_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdOper_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdOper_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdOper_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Sel";
            this.spdOper_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Operation";
            this.spdOper_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Description";
            this.spdOper_Sheet1.ColumnHeader.Cells.Get(0, 3).ColumnSpan = 2;
            this.spdOper_Sheet1.ColumnHeader.Cells.Get(0, 3).Locked = false;
            this.spdOper_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Keep Flag";
            this.spdOper_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdOper_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdOper_Sheet1.ColumnHeader.Rows.Get(0).Height = 18F;
            checkBoxCellType4.BackgroundImage = new FarPoint.Win.Picture(null, FarPoint.Win.RenderStyle.Normal, System.Drawing.Color.Empty, 0, FarPoint.Win.HorizontalAlignment.Center, FarPoint.Win.VerticalAlignment.Center);
            this.spdOper_Sheet1.Columns.Get(0).CellType = checkBoxCellType4;
            this.spdOper_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdOper_Sheet1.Columns.Get(0).Label = "Sel";
            this.spdOper_Sheet1.Columns.Get(0).Width = 27F;
            textCellType7.MaxLength = 20;
            this.spdOper_Sheet1.Columns.Get(1).CellType = textCellType7;
            this.spdOper_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdOper_Sheet1.Columns.Get(1).Label = "Operation";
            this.spdOper_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOper_Sheet1.Columns.Get(1).Width = 140F;
            this.spdOper_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdOper_Sheet1.Columns.Get(2).Label = "Description";
            this.spdOper_Sheet1.Columns.Get(2).Locked = false;
            this.spdOper_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOper_Sheet1.Columns.Get(2).Width = 240F;
            this.spdOper_Sheet1.Columns.Get(3).CellType = textCellType8;
            this.spdOper_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdOper_Sheet1.Columns.Get(3).Label = "Keep Flag";
            this.spdOper_Sheet1.Columns.Get(3).Locked = false;
            this.spdOper_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOper_Sheet1.Columns.Get(3).Width = 120F;
            buttonCellType4.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
            buttonCellType4.Text = "...";
            this.spdOper_Sheet1.Columns.Get(4).CellType = buttonCellType4;
            this.spdOper_Sheet1.Columns.Get(4).Locked = false;
            this.spdOper_Sheet1.Columns.Get(4).Width = 20F;
            this.spdOper_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdOper_Sheet1.RowHeader.Columns.Default.Resizable = true;
            this.spdOper_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdOper_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdOper_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdOper_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdOper_Sheet1.VisualStyles = FarPoint.Win.VisualStyles.Auto;
            this.spdOper_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // tbpFO
            // 
            this.tbpFO.Controls.Add(this.pnlFOMid);
            this.tbpFO.Controls.Add(this.grpFO);
            this.tbpFO.Location = new System.Drawing.Point(4, 22);
            this.tbpFO.Name = "tbpFO";
            this.tbpFO.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.tbpFO.Size = new System.Drawing.Size(734, 487);
            this.tbpFO.TabIndex = 1;
            this.tbpFO.Text = "Flow-Operation";
            this.tbpFO.Visible = false;
            // 
            // pnlFOMid
            // 
            this.pnlFOMid.Controls.Add(this.spdFO);
            this.pnlFOMid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFOMid.Location = new System.Drawing.Point(3, 47);
            this.pnlFOMid.Name = "pnlFOMid";
            this.pnlFOMid.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.pnlFOMid.Size = new System.Drawing.Size(728, 437);
            this.pnlFOMid.TabIndex = 1;
            // 
            // spdFO
            // 
            this.spdFO.AccessibleDescription = "";
            this.spdFO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdFO.FocusRenderer = defaultFocusIndicatorRenderer2;
            this.spdFO.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdFO.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdFO.HorizontalScrollBar.Name = "";
            this.spdFO.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdFO.HorizontalScrollBar.TabIndex = 2;
            this.spdFO.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            this.spdFO.Location = new System.Drawing.Point(0, 5);
            this.spdFO.Name = "spdFO";
            this.spdFO.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdFO.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdFO.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdFO_Sheet1});
            this.spdFO.Size = new System.Drawing.Size(728, 432);
            this.spdFO.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdFO.TabIndex = 0;
            this.spdFO.TabStop = false;
            this.spdFO.TextTipDelay = 200;
            this.spdFO.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdFO.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdFO.VerticalScrollBar.Name = "";
            this.spdFO.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdFO.VerticalScrollBar.TabIndex = 3;
            this.spdFO.Change += new FarPoint.Win.Spread.ChangeEventHandler(this.spdFO_Change);
            this.spdFO.ButtonClicked += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.spdFO_ButtonClicked);
            this.spdFO.SetActiveViewport(0, -1, -1);
            // 
            // spdFO_Sheet1
            // 
            this.spdFO_Sheet1.Reset();
            spdFO_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdFO_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdFO_Sheet1.ColumnCount = 5;
            spdFO_Sheet1.RowCount = 0;
            this.spdFO_Sheet1.ActiveColumnIndex = -1;
            this.spdFO_Sheet1.ActiveRowIndex = -1;
            this.spdFO_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdFO_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdFO_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdFO_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdFO_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Sel";
            this.spdFO_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Operation";
            this.spdFO_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Description";
            this.spdFO_Sheet1.ColumnHeader.Cells.Get(0, 3).ColumnSpan = 2;
            this.spdFO_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Keep Flag";
            this.spdFO_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdFO_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdFO_Sheet1.ColumnHeader.Rows.Get(0).Height = 18F;
            checkBoxCellType5.BackgroundImage = new FarPoint.Win.Picture(null, FarPoint.Win.RenderStyle.Normal, System.Drawing.Color.Empty, 0, FarPoint.Win.HorizontalAlignment.Center, FarPoint.Win.VerticalAlignment.Center);
            this.spdFO_Sheet1.Columns.Get(0).CellType = checkBoxCellType5;
            this.spdFO_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdFO_Sheet1.Columns.Get(0).Label = "Sel";
            this.spdFO_Sheet1.Columns.Get(0).Width = 35F;
            textCellType9.MaxLength = 20;
            this.spdFO_Sheet1.Columns.Get(1).CellType = textCellType9;
            this.spdFO_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdFO_Sheet1.Columns.Get(1).Label = "Operation";
            this.spdFO_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdFO_Sheet1.Columns.Get(1).Width = 140F;
            this.spdFO_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdFO_Sheet1.Columns.Get(2).Label = "Description";
            this.spdFO_Sheet1.Columns.Get(2).Locked = false;
            this.spdFO_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdFO_Sheet1.Columns.Get(2).Width = 240F;
            this.spdFO_Sheet1.Columns.Get(3).CellType = textCellType10;
            this.spdFO_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdFO_Sheet1.Columns.Get(3).Label = "Keep Flag";
            this.spdFO_Sheet1.Columns.Get(3).Locked = false;
            this.spdFO_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdFO_Sheet1.Columns.Get(3).Width = 120F;
            buttonCellType5.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
            buttonCellType5.Text = "...";
            this.spdFO_Sheet1.Columns.Get(4).CellType = buttonCellType5;
            this.spdFO_Sheet1.Columns.Get(4).Width = 20F;
            this.spdFO_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdFO_Sheet1.RowHeader.Columns.Default.Resizable = true;
            this.spdFO_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdFO_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdFO_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdFO_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdFO_Sheet1.VisualStyles = FarPoint.Win.VisualStyles.Auto;
            this.spdFO_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // grpFO
            // 
            this.grpFO.Controls.Add(this.cdvFlow);
            this.grpFO.Controls.Add(this.lblFlow);
            this.grpFO.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpFO.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpFO.Location = new System.Drawing.Point(3, 0);
            this.grpFO.Name = "grpFO";
            this.grpFO.Size = new System.Drawing.Size(728, 47);
            this.grpFO.TabIndex = 0;
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
            this.cdvFlow.Location = new System.Drawing.Point(90, 16);
            this.cdvFlow.MaxLength = 20;
            this.cdvFlow.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvFlow.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvFlow.Name = "cdvFlow";
            this.cdvFlow.ReadOnly = false;
            this.cdvFlow.SearchSubItemIndex = 0;
            this.cdvFlow.SelectedDescIndex = -1;
            this.cdvFlow.SelectedSubItemIndex = -1;
            this.cdvFlow.SelectionStart = 0;
            this.cdvFlow.Size = new System.Drawing.Size(630, 20);
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
            this.lblFlow.Location = new System.Drawing.Point(14, 19);
            this.lblFlow.Name = "lblFlow";
            this.lblFlow.Size = new System.Drawing.Size(33, 13);
            this.lblFlow.TabIndex = 0;
            this.lblFlow.Text = "Flow";
            this.lblFlow.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbpMFO
            // 
            this.tbpMFO.Controls.Add(this.pnlMFOMid);
            this.tbpMFO.Controls.Add(this.grpMFO);
            this.tbpMFO.Location = new System.Drawing.Point(4, 22);
            this.tbpMFO.Name = "tbpMFO";
            this.tbpMFO.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.tbpMFO.Size = new System.Drawing.Size(734, 487);
            this.tbpMFO.TabIndex = 2;
            this.tbpMFO.Text = "Material-Flow-Operation";
            this.tbpMFO.Visible = false;
            // 
            // pnlMFOMid
            // 
            this.pnlMFOMid.Controls.Add(this.spdMFO);
            this.pnlMFOMid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMFOMid.Location = new System.Drawing.Point(3, 47);
            this.pnlMFOMid.Name = "pnlMFOMid";
            this.pnlMFOMid.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.pnlMFOMid.Size = new System.Drawing.Size(728, 437);
            this.pnlMFOMid.TabIndex = 1;
            // 
            // spdMFO
            // 
            this.spdMFO.AccessibleDescription = "spdMFO, Sheet1";
            this.spdMFO.BackColor = System.Drawing.SystemColors.Control;
            this.spdMFO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdMFO.FocusRenderer = defaultFocusIndicatorRenderer2;
            this.spdMFO.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdMFO.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdMFO.HorizontalScrollBar.Name = "";
            this.spdMFO.HorizontalScrollBar.Renderer = defaultScrollBarRenderer3;
            this.spdMFO.HorizontalScrollBar.TabIndex = 2;
            this.spdMFO.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            this.spdMFO.Location = new System.Drawing.Point(0, 5);
            this.spdMFO.Name = "spdMFO";
            this.spdMFO.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdMFO.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdMFO.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdMFO_Sheet1});
            this.spdMFO.Size = new System.Drawing.Size(728, 432);
            this.spdMFO.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdMFO.TabIndex = 0;
            this.spdMFO.TabStop = false;
            this.spdMFO.TextTipDelay = 200;
            this.spdMFO.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdMFO.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdMFO.VerticalScrollBar.Name = "";
            this.spdMFO.VerticalScrollBar.Renderer = defaultScrollBarRenderer4;
            this.spdMFO.VerticalScrollBar.TabIndex = 3;
            this.spdMFO.Change += new FarPoint.Win.Spread.ChangeEventHandler(this.spdMFO_Change);
            this.spdMFO.ButtonClicked += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.spdMFO_ButtonClicked);
            this.spdMFO.SetActiveViewport(0, -1, -1);
            // 
            // spdMFO_Sheet1
            // 
            this.spdMFO_Sheet1.Reset();
            spdMFO_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdMFO_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdMFO_Sheet1.ColumnCount = 7;
            spdMFO_Sheet1.RowCount = 0;
            this.spdMFO_Sheet1.ActiveColumnIndex = -1;
            this.spdMFO_Sheet1.ActiveRowIndex = -1;
            this.spdMFO_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdMFO_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdMFO_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdMFO_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdMFO_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Sel";
            this.spdMFO_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Flow";
            this.spdMFO_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Flow Description";
            this.spdMFO_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Operation";
            this.spdMFO_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Oper Description";
            this.spdMFO_Sheet1.ColumnHeader.Cells.Get(0, 5).ColumnSpan = 2;
            this.spdMFO_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Keep Flag";
            this.spdMFO_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdMFO_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdMFO_Sheet1.ColumnHeader.Rows.Get(0).Height = 18F;
            checkBoxCellType6.BackgroundImage = new FarPoint.Win.Picture(null, FarPoint.Win.RenderStyle.Normal, System.Drawing.Color.Empty, 0, FarPoint.Win.HorizontalAlignment.Center, FarPoint.Win.VerticalAlignment.Center);
            this.spdMFO_Sheet1.Columns.Get(0).CellType = checkBoxCellType6;
            this.spdMFO_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdMFO_Sheet1.Columns.Get(0).Label = "Sel";
            this.spdMFO_Sheet1.Columns.Get(0).Width = 35F;
            this.spdMFO_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdMFO_Sheet1.Columns.Get(1).Label = "Flow";
            this.spdMFO_Sheet1.Columns.Get(1).MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Always;
            this.spdMFO_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMFO_Sheet1.Columns.Get(1).Width = 100F;
            this.spdMFO_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdMFO_Sheet1.Columns.Get(2).Label = "Flow Description";
            this.spdMFO_Sheet1.Columns.Get(2).MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Always;
            this.spdMFO_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMFO_Sheet1.Columns.Get(2).Width = 126F;
            textCellType11.MaxLength = 20;
            this.spdMFO_Sheet1.Columns.Get(3).CellType = textCellType11;
            this.spdMFO_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdMFO_Sheet1.Columns.Get(3).Label = "Operation";
            this.spdMFO_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMFO_Sheet1.Columns.Get(3).Width = 80F;
            this.spdMFO_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdMFO_Sheet1.Columns.Get(4).Label = "Oper Description";
            this.spdMFO_Sheet1.Columns.Get(4).Locked = false;
            this.spdMFO_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMFO_Sheet1.Columns.Get(4).Width = 120F;
            this.spdMFO_Sheet1.Columns.Get(5).CellType = textCellType12;
            this.spdMFO_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdMFO_Sheet1.Columns.Get(5).Label = "Keep Flag";
            this.spdMFO_Sheet1.Columns.Get(5).Locked = false;
            this.spdMFO_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMFO_Sheet1.Columns.Get(5).Width = 120F;
            buttonCellType6.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
            buttonCellType6.Text = "...";
            this.spdMFO_Sheet1.Columns.Get(6).CellType = buttonCellType6;
            this.spdMFO_Sheet1.Columns.Get(6).Locked = false;
            this.spdMFO_Sheet1.Columns.Get(6).Width = 20F;
            this.spdMFO_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdMFO_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdMFO_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdMFO_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdMFO_Sheet1.Rows.Default.Height = 18F;
            this.spdMFO_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdMFO_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdMFO_Sheet1.VisualStyles = FarPoint.Win.VisualStyles.Auto;
            this.spdMFO_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // grpMFO
            // 
            this.grpMFO.Controls.Add(this.cdvMaterial);
            this.grpMFO.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpMFO.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpMFO.Location = new System.Drawing.Point(3, 0);
            this.grpMFO.Name = "grpMFO";
            this.grpMFO.Size = new System.Drawing.Size(728, 47);
            this.grpMFO.TabIndex = 0;
            this.grpMFO.TabStop = false;
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
            this.cdvMaterial.WidthLabel = 78;
            this.cdvMaterial.WidthMaterialAndVersion = 200;
            this.cdvMaterial.WidthVersion = 50;
            this.cdvMaterial.MaterialSelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvMaterial_SelectedItemChanged);
            this.cdvMaterial.VersionSelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvMaterial_SelectedItemChanged);
            // 
            // cdvBatch
            // 
            this.cdvBatch.BackColor = System.Drawing.Color.PaleTurquoise;
            this.cdvBatch.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvBatch.BorderHotColor = System.Drawing.Color.Black;
            this.cdvBatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cdvBatch.Location = new System.Drawing.Point(429, 17);
            this.cdvBatch.MCViewStyle.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvBatch.MCViewStyle.BorderHotColor = System.Drawing.Color.Black;
            this.cdvBatch.Name = "cdvBatch";
            this.cdvBatch.Size = new System.Drawing.Size(20, 20);
            this.cdvBatch.SmallImageList = null;
            this.cdvBatch.TabIndex = 0;
            this.cdvBatch.TabStop = false;
            this.cdvBatch.ViewPosition = new System.Drawing.Point(0, 0);
            this.cdvBatch.Visible = false;
            this.cdvBatch.VisibleColumnHeader = false;
            this.cdvBatch.SelectedItemChanged += new Miracom.UI.MCSSCodeViewSelChangedHandler(this.cdvBatch_SelectedItemChanged);
            // 
            // btnRefresh
            // 
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnRefresh.Location = new System.Drawing.Point(10, 6);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(24, 24);
            this.btnRefresh.TabIndex = 9;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExcel.Image")));
            this.btnExcel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnExcel.Location = new System.Drawing.Point(40, 6);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(24, 24);
            this.btnExcel.TabIndex = 10;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // frmWIPSetupBatchKeepMFO
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Name = "frmWIPSetupBatchKeepMFO";
            this.Text = "Batch Keep Flag Setup";
            this.Activated += new System.EventHandler(this.frmWIPSetupBatchKeepMFO_Activated);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.tabMFO.ResumeLayout(false);
            this.tbpOper.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdOper)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdOper_Sheet1)).EndInit();
            this.tbpFO.ResumeLayout(false);
            this.pnlFOMid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdFO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdFO_Sheet1)).EndInit();
            this.grpFO.ResumeLayout(false);
            this.grpFO.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvFlow)).EndInit();
            this.tbpMFO.ResumeLayout(false);
            this.pnlMFOMid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdMFO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdMFO_Sheet1)).EndInit();
            this.grpMFO.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cdvBatch)).EndInit();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Constant Definition "
        
        private const int MAX_MFO_COUNT = 1000;
        
        #endregion
        
        #region " Variable Definition "
        
        //private struct Format
        //{
        //    private string Col_Fmt;
        //    private int Col_Size;
        //}
        
        //Format[] FormatTbl = new Format[21];
        
        bool LoadFlag;
        
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
        private void ClearData(string ProcStep)
        {
            try
            {
                if (ProcStep == "1")
                {
                    if (tabMFO.SelectedIndex == 0)
                    {
                        spdOper.Sheets[0].RowCount = 0;
                    }
                    else if (tabMFO.SelectedIndex == 1)
                    {
                        spdFO.Sheets[0].RowCount = 0;
                    }
                    else if (tabMFO.SelectedIndex == 2)
                    {
                        spdMFO.Sheets[0].RowCount = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        
        //
        // CheckCondition()
        //       - Check the conditions before transaction
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal FuncName As String : Function Name
        //       - Optional ByVal ProcStep As String : Process Step
        //
        private bool CheckCondition(string FuncName, char ProcStep)
        {
            //bool returnValue;
            
            int i = 0;
            int iChkCnt = 0;
            
            try
            {
                //returnValue = false;

                switch (MPCF.Trim(FuncName))
                {
                    case "UPDATE":
                        
                        
                        if (tabMFO.SelectedIndex == 0)
                        {
                            for (i = 0; i <= spdOper.Sheets[0].RowCount - 1; i++)
                            {
                                if (spdOper.Sheets[0].GetValue(i, 0) != null && 
                                    Convert.ToBoolean(spdOper.Sheets[0].GetValue(i, 0)) == true)
                                {
                                    iChkCnt++;
                                }
                            }
                            
                            if (iChkCnt == 0)
                            {
                                MPCF.ShowMsgBox("Please select at least 1 Data.");
                                spdOper.Select();
                                return false;
                            }
                            else if (iChkCnt > MAX_MFO_COUNT)
                            {
                                MPCF.ShowMsgBox("data exceed Max Data Limit.");
                                spdOper.Select();
                                return false;
                            }
                            
                        }
                        else if (tabMFO.SelectedIndex == 1)
                        {
                            if (cdvFlow.Text == "")
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                                cdvFlow.Select();
                                return false;
                            }
                            
                            for (i = 0; i <= spdFO.Sheets[0].RowCount - 1; i++)
                            {
                                if (spdFO.Sheets[0].GetValue(i, 0) != null &&
                                    Convert.ToBoolean(spdFO.Sheets[0].GetValue(i, 0)) == true)
                                {
                                    iChkCnt++;
                                }
                            }
                            
                            if (iChkCnt == 0)
                            {
                                MPCF.ShowMsgBox("Please select at least 1 Data.");
                                spdFO.Select();
                                return false;
                            }
                            else if (iChkCnt > MAX_MFO_COUNT)
                            {
                                MPCF.ShowMsgBox("data exceed Max Data Limit.");
                                spdFO.Select();
                                return false;
                            }
                            
                        }
                        else if (tabMFO.SelectedIndex == 2)
                        {
                            if (cdvMaterial.Text == "")
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                                cdvMaterial.Select();
                                return false;
                            }
                            
                            for (i = 0; i <= spdMFO.Sheets[0].RowCount - 1; i++)
                            {
                                if (spdMFO.Sheets[0].GetValue(i, 0) != null &&
                                    Convert.ToBoolean(spdMFO.Sheets[0].GetValue(i, 0)) == true)
                                {
                                    iChkCnt++;
                                }
                            }
                            
                            if (iChkCnt == 0)
                            {
                                MPCF.ShowMsgBox("Please select at least 1 Data.");
                                spdMFO.Select();
                                return false;
                            }
                            else if (iChkCnt > MAX_MFO_COUNT)
                            {
                                MPCF.ShowMsgBox("data exceed Max Data Limit.");
                                spdMFO.Select();
                                return false;
                            }
                        }
                        break;
                        
                    case "VIEW":
                        
                        break;
                        
                }
                return true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }
        
        //
        // View_MFO_Batch_Keep_List()
        //       - View MFO-Recipe Relation List
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String : Process Step
        //       - ByVal OptLevel As String : Option Level("1" : M-F-O, "2" : F-O, "3" : O)
        //
        private bool View_MFO_Batch_Keep_List(char ProcStep, char OptLevel)
        {
            int i;
            int LastRow = 0;

            TRSNode in_node = new TRSNode("VIEW_MFO_BATCH_KEEP_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_MFO_BATCH_KEEP_LIST_OUT");

            try
            {
                ClearData("1");

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;

                in_node.AddChar("OPT_LEVEL", OptLevel);

                if (OptLevel == '1')
                {
                    in_node.AddString("MAT_ID", cdvMaterial.Text);
                    in_node.AddInt("MAT_VER", cdvMaterial.Version);
                }
                else if (OptLevel == '2')
                {
                    in_node.AddString("FLOW", cdvFlow.Text);
                }


                do
                {
                    if (MPCR.CallService("WIP", "WIP_View_MFO_Batch_Keep_List", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    switch (OptLevel)
                    {
                        case '1':

                            for (i = 0; i < out_node.GetList(0).Count; i++)
                            {

                                spdMFO.Sheets[0].RowCount++;
                                LastRow = spdMFO.Sheets[0].RowCount - 1;

                                FarPoint.Win.Spread.SheetView with_1 = spdMFO.Sheets[0];
                                with_1.Cells[LastRow, 0].CellType = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
                                with_1.Cells[LastRow, 1].Locked = true;
                                with_1.Cells[LastRow, 2].Locked = true;
                                with_1.Cells[LastRow, 3].Locked = true;
                                with_1.Cells[LastRow, 4].Locked = true;

                                with_1.SetValue(LastRow, 1, out_node.GetList(0)[i].GetString("FLOW"));
                                with_1.SetValue(LastRow, 2, out_node.GetList(0)[i].GetString("FLOW_DESC"));
                                with_1.SetValue(LastRow, 3, out_node.GetList(0)[i].GetString("OPER"));
                                with_1.SetValue(LastRow, 4, out_node.GetList(0)[i].GetString("OPER_DESC"));
                                with_1.SetValue(LastRow, 5, out_node.GetList(0)[i].GetChar("BATCH_KEEP_FLAG"));
                            }

                            break;

                        case '2':

                            for (i = 0; i < out_node.GetList(0).Count; i++)
                            {

                                spdFO.Sheets[0].RowCount++;
                                LastRow = spdFO.Sheets[0].RowCount - 1;

                                FarPoint.Win.Spread.SheetView with_2 = spdFO.Sheets[0];
                                with_2.Cells[LastRow, 0].CellType = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
                                with_2.Cells[LastRow, 1].Locked = true;
                                with_2.Cells[LastRow, 2].Locked = true;

                                with_2.SetValue(LastRow, 1, out_node.GetList(0)[i].GetString("OPER"));
                                with_2.SetValue(LastRow, 2, out_node.GetList(0)[i].GetString("OPER_DESC"));
                                with_2.SetValue(LastRow, 3, out_node.GetList(0)[i].GetChar("BATCH_KEEP_FLAG"));
                            }

                            break;

                        case '3':

                            for (i = 0; i < out_node.GetList(0).Count; i++)
                            {

                                spdOper.Sheets[0].RowCount++;
                                LastRow = spdOper.Sheets[0].RowCount - 1;

                                FarPoint.Win.Spread.SheetView with_3 = spdOper.Sheets[0];
                                with_3.Cells[LastRow, 0].CellType = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
                                with_3.Cells[LastRow, 1].Locked = true;
                                with_3.Cells[LastRow, 2].Locked = true;

                                with_3.SetValue(LastRow, 1, out_node.GetList(0)[i].GetString("OPER"));
                                with_3.SetValue(LastRow, 2, out_node.GetList(0)[i].GetString("OPER_DESC"));
                                with_3.SetValue(LastRow, 3, out_node.GetList(0)[i].GetChar("BATCH_KEEP_FLAG"));
                            }

                            break;

                    }

                    in_node.SetInt("NEXT_SEQ", out_node.GetInt("NEXT_SEQ"));
                } while (in_node.GetInt("NEXT_SEQ") > 0);

                switch (OptLevel)
                {
                    case '1':

                        spdMFO.Sheets[0].Columns.Get(1).BackColor = System.Drawing.Color.WhiteSmoke;
                        spdMFO.Sheets[0].Columns.Get(2).BackColor = System.Drawing.Color.WhiteSmoke;
                        spdMFO.Sheets[0].Columns.Get(3).BackColor = System.Drawing.Color.WhiteSmoke;
                        spdMFO.Sheets[0].Columns.Get(4).BackColor = System.Drawing.Color.WhiteSmoke;
                        break;

                    case '2':

                        spdFO.Sheets[0].Columns.Get(1).BackColor = System.Drawing.Color.WhiteSmoke;
                        spdFO.Sheets[0].Columns.Get(2).BackColor = System.Drawing.Color.WhiteSmoke;
                        break;

                    case '3':

                        spdOper.Sheets[0].Columns.Get(1).BackColor = System.Drawing.Color.WhiteSmoke;
                        spdOper.Sheets[0].Columns.Get(2).BackColor = System.Drawing.Color.WhiteSmoke;
                        break;

                }

                return true;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

        }

        //
        // Update_MFO_Batch_Keep_List()
        //       - Attach/Detach Recipe to MFO
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String : Process Step
        //       - ByVal OptLevel As String : Option Level("1" : M-F-O, "2" : F-O, "3" : O)
        //
        private bool Update_MFO_Batch_Keep_List(char ProcStep, char OptLevel)
        {
            int i = 0;

            TRSNode in_node = new TRSNode("UPDATE_MFO_BATCH_KEEP_LIST_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");
            TRSNode list_item;

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;
                in_node.AddChar("OPT_LEVEL", OptLevel);

                switch (OptLevel)
                {
                    case '1':

                        for (i = 0; i < spdMFO.Sheets[0].RowCount; i++)
                        {
                            if (spdMFO.Sheets[0].GetValue(i, 0) != null && Convert.ToBoolean(spdMFO.Sheets[0].GetValue(i, 0)) == true)
                            {
                                list_item = in_node.AddNode("LIST");

                                list_item.AddString("MAT_ID", MPCF.Trim(cdvMaterial.Text));
                                list_item.AddInt("MAT_VER", cdvMaterial.Version);
                                list_item.AddString("FLOW", MPCF.Trim(spdMFO.Sheets[0].GetValue(i, 1)));
                                list_item.AddString("OPER", MPCF.Trim(spdMFO.Sheets[0].GetValue(i, 3)));
                                list_item.AddChar("BATCH_KEEP_FLAG", MPCF.ToChar(spdMFO.Sheets[0].GetValue(i, 5)));
                            }
                        }
                        break;
                    case '2':

                        for (i = 0; i < spdFO.Sheets[0].RowCount; i++)
                        {
                            if (spdFO.Sheets[0].GetValue(i, 0) != null && Convert.ToBoolean(spdFO.Sheets[0].GetValue(i, 0)) == true)
                            {
                                list_item = in_node.AddNode("LIST");

                                list_item.AddString("FLOW", MPCF.Trim(cdvFlow.Text));
                                list_item.AddString("OPER", MPCF.Trim(spdFO.Sheets[0].GetValue(i, 1)));
                                list_item.AddChar("BATCH_KEEP_FLAG", MPCF.ToChar(spdFO.Sheets[0].GetValue(i, 3)));
                            }
                        }
                        break;
                    case '3':

                        for (i = 0; i < spdOper.Sheets[0].RowCount; i++)
                        {
                            if (spdOper.Sheets[0].GetValue(i, 0) != null && Convert.ToBoolean(spdOper.Sheets[0].GetValue(i, 0)) == true)
                            {
                                list_item = in_node.AddNode("LIST");

                                list_item.AddString("OPER", MPCF.Trim(spdOper.Sheets[0].GetValue(i, 1)));
                                list_item.AddChar("BATCH_KEEP_FLAG", MPCF.ToChar(spdOper.Sheets[0].GetValue(i, 3)));
                            }
                        }
                        break;
                }

                if (MPCR.CallService("WIP", "WIP_Update_MFO_Batch_Keep_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCR.ShowSuccessMsg(out_node);

                View_MFO_Batch_Keep_List('1', OptLevel);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

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
        
        private void frmWIPSetupBatchKeepMFO_Activated(object sender, System.EventArgs e)
        {
            
            try
            {
                if (LoadFlag == false)
                {
                    tabMFO.SelectedIndex = 0;
                    
                    if (View_MFO_Batch_Keep_List('1', '3') == false)
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
        
        private void btnUpdate_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                if (CheckCondition("UPDATE", MPGC.MP_STEP_UPDATE) == true)
                {
                    if (tabMFO.SelectedIndex == 0)
                    {
                        Update_MFO_Batch_Keep_List(MPGC.MP_STEP_UPDATE, '3');
                    }
                    else if (tabMFO.SelectedIndex == 1)
                    {
                        Update_MFO_Batch_Keep_List(MPGC.MP_STEP_UPDATE, '2');
                    }
                    else if (tabMFO.SelectedIndex == 2)
                    {
                        Update_MFO_Batch_Keep_List(MPGC.MP_STEP_UPDATE, '1');
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        
        private void cdvFlow_SelectedItemChanged(System.Object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            if (cdvFlow.Text == "")
            {
                ClearData("1");
            }
            else
            {
                View_MFO_Batch_Keep_List('1', '2');
            }
        }
        
        private void cdvMaterial_SelectedItemChanged(System.Object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            if (cdvMaterial.Text == "")
            {
                ClearData("1");
            }
            else
            {
                View_MFO_Batch_Keep_List('1', '1');
            }
        }
        
        private void cdvFlow_ButtonPress(System.Object sender, System.EventArgs e)
        {
            cdvFlow.Init();
            MPCF.InitListView(cdvFlow.GetListView);
            cdvFlow.Columns.Add("Flow", 100, HorizontalAlignment.Left);
            cdvFlow.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvFlow.SelectedSubItemIndex = 0;
            cdvFlow.DisplaySubItemIndex = 0;
            cdvFlow.SelectedDescIndex = 1;
            cdvFlow.ReadOnly = true;
            WIPLIST.ViewFlowList(cdvFlow.GetListView, '1', "", 0,"", null, "");
        }
        
        private void spdOper_Change(System.Object sender, FarPoint.Win.Spread.ChangeEventArgs e)
        {
            if (e.Column > 0 && e.Row >= 0)
            {
                spdOper.Sheets[0].SetValue(e.Row, 0, true);
            }
        }
        
        private void spdFO_Change(System.Object sender, FarPoint.Win.Spread.ChangeEventArgs e)
        {
            if (e.Column > 0 && e.Row >= 0)
            {
                spdFO.Sheets[0].SetValue(e.Row, 0, true);
            }
        }
        
        private void spdMFO_Change(System.Object sender, FarPoint.Win.Spread.ChangeEventArgs e)
        {
            if (e.Column > 0 && e.Row >= 0)
            {
                spdMFO.Sheets[0].SetValue(e.Row, 0, true);
            }
        }
        
        private void spdOper_ButtonClicked(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            string sOper;
            ListViewItem itmX;
            
            if (e.Column == 4)
            {

                sOper = MPCF.Trim(spdOper.Sheets[0].GetValue(e.Row, 1));
                
                //If ViewRecipeList(cdvBatch.GetListView, '1', " ", sOper) = False Then
                //    Exit Sub
                //End If
                //?¬ê¸°??" ", 'Y'ì¶”ê?
                cdvBatch.Init();
                cdvBatch.ViewPosition = Control.MousePosition;
                MPCF.InitListView(cdvBatch.GetListView);
                cdvBatch.Columns.Add("Batch", 50, HorizontalAlignment.Left);
                cdvBatch.Columns.Add("Desc", 200, HorizontalAlignment.Left);
                
                itmX = new ListViewItem(" ", (int)SMALLICON_INDEX.IDX_STATUS);
                itmX.SubItems.Add("AUTO RELEASE BATCH");
                ((ListView) cdvBatch.GetListView).Items.Add(itmX);
                
                itmX = new ListViewItem("Y", (int)SMALLICON_INDEX.IDX_STATUS);
                itmX.SubItems.Add("KEEP BATCH");
                ((ListView) cdvBatch.GetListView).Items.Add(itmX);
                
                if (cdvBatch.ShowPopupList(e.Row, e.Column) == false)
                {
                    return;
                }
                
            }
        }
        
        private void spdMFO_ButtonClicked(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            string sOper;
            ListViewItem itmX;
            
            if (e.Column == 6)
            {
                cdvBatch.ViewPosition = Control.MousePosition;
                sOper = MPCF.Trim(spdMFO.Sheets[0].GetValue(e.Row, 3));
                
                //If ViewRecipeList(cdvRecipe.GetListView, '1', " ", sOper) = False Then
                //    Exit Sub
                //End If
                cdvBatch.Init();
                MPCF.InitListView(cdvBatch.GetListView);
                cdvBatch.Columns.Add("Code", 40, HorizontalAlignment.Left);
                cdvBatch.Columns.Add("Desc", 80, HorizontalAlignment.Left);

                itmX = new ListViewItem(" ", (int)SMALLICON_INDEX.IDX_STATUS);
                itmX.SubItems.Add("AUTO RELEASE BATCH");
                ((ListView) cdvBatch.GetListView).Items.Add(itmX);
                
                itmX = new ListViewItem("Y", (int)SMALLICON_INDEX.IDX_STATUS);
                itmX.SubItems.Add("KEEP BATCH");
                ((ListView) cdvBatch.GetListView).Items.Add(itmX);
                
                if (cdvBatch.ShowPopupList(e.Row, e.Column) == false)
                {
                    return;
                }
                
            }
        }
        
        private void spdFO_ButtonClicked(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            string sOper;
            ListViewItem itmX;
            
            if (e.Column == 4)
            {
                cdvBatch.ViewPosition = Control.MousePosition;
                sOper = MPCF.Trim(spdFO.Sheets[0].GetValue(e.Row, 1));
                
                //If ViewRecipeList(cdvRecipe.GetListView, '1', " ", sOper) = False Then
                //    Exit Sub
                //End If
                MPCF.InitListView(cdvBatch.GetListView);
                
                itmX = new ListViewItem(" ", (int)SMALLICON_INDEX.IDX_STATUS);
                itmX.SubItems.Add("AUTO RELEASE BATCH");
                ((ListView) cdvBatch.GetListView).Items.Add(itmX);
                
                itmX = new ListViewItem("Y", (int)SMALLICON_INDEX.IDX_STATUS);
                itmX.SubItems.Add("KEEP BATCH");
                ((ListView) cdvBatch.GetListView).Items.Add(itmX);
                
                if (cdvBatch.ShowPopupList(e.Row, e.Column) == false)
                {
                    return;
                }
                
            }
        }
        
        private void cdvBatch_SelectedItemChanged(System.Object sender, Miracom.UI.MCSSCodeViewSelChanged_EventArgs e)
        {
            
            try
            {
                //If Trim(e.SelectedItem.SubItems(0).Text) = "" Then Exit Sub
                
                if (tabMFO.SelectedTab == tbpOper)
                {
                    spdOper.Sheets[0].Cells[e.Row, e.Col - 1].Value = e.SelectedItem.SubItems[0].Text;
                    spdOper.Sheets[0].SetValue(e.Row, 0, true);
                }
                else if (tabMFO.SelectedTab == tbpFO)
                {
                    spdFO.Sheets[0].Cells[e.Row, e.Col - 1].Value = e.SelectedItem.SubItems[0].Text;
                    spdFO.Sheets[0].SetValue(e.Row, 0, true);
                }
                else if (tabMFO.SelectedTab == tbpMFO)
                {
                    spdMFO.Sheets[0].Cells[e.Row, e.Col - 1].Value = e.SelectedItem.SubItems[0].Text;
                    spdMFO.Sheets[0].SetValue(e.Row, 0, true);
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
                if (View_MFO_Batch_Keep_List('1', '3') == false)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        
        private void tabMFO_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            try
            {
                if (tabMFO.SelectedTab == this.tbpOper)
                {
                    btnRefresh.Visible = true;
                    btnExcel.Location = new Point(40, 6); 
                }
                else if (tabMFO.SelectedTab == this.tbpFO)
                {
                    btnRefresh.Visible = false;
                    btnExcel.Location = new Point(10, 6);
                }
                else if (tabMFO.SelectedTab == this.tbpMFO)
                {
                    btnRefresh.Visible = false;
                    btnExcel.Location = new Point(10, 6);
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                string sCond = string.Empty;

                if (tabMFO.SelectedIndex == 0)
                {
                    MPCF.ExportToExcel(spdOper, this.Text, "");
                }
                else if (tabMFO.SelectedIndex == 1)
                {
                    sCond = "Flow : " + cdvFlow.Text;
                    MPCF.ExportToExcel(spdFO, this.Text, sCond);
                }
                else if (tabMFO.SelectedIndex == 2)
                {
                    sCond = "Material : " + cdvMaterial.Text;
                    MPCF.ExportToExcel(spdMFO, this.Text, sCond);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
     }
    
}
