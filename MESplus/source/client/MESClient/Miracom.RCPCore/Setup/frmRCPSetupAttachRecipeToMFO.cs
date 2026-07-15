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


//#If _RCP = True Then
//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmRCPSetupAttachRecipeToMFO.vb
//   Description : Attach Recipe To MFO Transaction Form
//
//   MES Version : 4.1.0.0
//
//   Function List
//       - ClearData() : Intialize Form Field
//       - CheckCondition() : Check the conditions before transaction
//       - View_MFO_Recipe_List() :View MFO-Recipe Set Relation
//       - Update_MFO_Recipe_List() : Attach/Detach Recipe to MFO, FO, O
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


namespace Miracom.RCPCore
{
    public class frmRCPSetupAttachRecipeToMFO : Miracom.MESCore.SetupForm01
    {
        
        #region " Windows Form auto generated code "
        
        public frmRCPSetupAttachRecipeToMFO()
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
        



        private System.Windows.Forms.Panel pnlTab;
        private System.Windows.Forms.TabControl tabMFO;
        private FarPoint.Win.Spread.FpSpread spdOper;
        private System.Windows.Forms.Panel pnlFOMid;
        private FarPoint.Win.Spread.FpSpread spdFO;
        private System.Windows.Forms.GroupBox grpFO;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvFlow;
        private System.Windows.Forms.Label lblFlowDesc;
        private System.Windows.Forms.Label lblFlow;
        private System.Windows.Forms.TextBox txtFlowDesc;
        private System.Windows.Forms.Panel pnlMFOMid;
        private FarPoint.Win.Spread.FpSpread spdMFO;
        private System.Windows.Forms.GroupBox grpMFO;
        private FarPoint.Win.Spread.SheetView spdOper_Sheet1;
        private FarPoint.Win.Spread.SheetView spdFO_Sheet1;
        private FarPoint.Win.Spread.SheetView spdMFO_Sheet1;
        private Miracom.UI.Controls.MCCodeView.MCSPCodeView cdvRecipe;
        private System.Windows.Forms.TabPage tbpOper;
        private System.Windows.Forms.TabPage tbpFO;
        private System.Windows.Forms.TabPage tbpMFO;
        private Miracom.MESCore.Controls.udcMaterial cdvMaterial;
        protected Button btnExcel;
        private System.Windows.Forms.Button btnRefresh;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType1 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.ButtonCellType buttonCellType1 = new FarPoint.Win.Spread.CellType.ButtonCellType();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer3 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer4 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType2 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType3 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType4 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.ButtonCellType buttonCellType2 = new FarPoint.Win.Spread.CellType.ButtonCellType();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer5 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer6 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType3 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType5 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType6 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.ButtonCellType buttonCellType3 = new FarPoint.Win.Spread.CellType.ButtonCellType();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRCPSetupAttachRecipeToMFO));
            this.pnlTab = new System.Windows.Forms.Panel();
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
            this.lblFlowDesc = new System.Windows.Forms.Label();
            this.lblFlow = new System.Windows.Forms.Label();
            this.txtFlowDesc = new System.Windows.Forms.TextBox();
            this.tbpMFO = new System.Windows.Forms.TabPage();
            this.pnlMFOMid = new System.Windows.Forms.Panel();
            this.spdMFO = new FarPoint.Win.Spread.FpSpread();
            this.spdMFO_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.grpMFO = new System.Windows.Forms.GroupBox();
            this.cdvMaterial = new Miracom.MESCore.Controls.udcMaterial();
            this.cdvRecipe = new Miracom.UI.Controls.MCCodeView.MCSPCodeView();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnExcel = new System.Windows.Forms.Button();
            this.pnlBottom.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlTab.SuspendLayout();
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
            ((System.ComponentModel.ISupportInitialize)(this.cdvRecipe)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(375, 5);
            this.btnCreate.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(467, 5);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Visible = false;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(559, 5);
            this.btnUpdate.TabIndex = 2;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(650, 5);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnExcel);
            this.pnlBottom.Controls.Add(this.btnRefresh);
            this.pnlBottom.Location = new System.Drawing.Point(0, 509);
            this.pnlBottom.Padding = new System.Windows.Forms.Padding(0, 0, 4, 0);
            this.pnlBottom.Size = new System.Drawing.Size(742, 37);
            this.pnlBottom.Controls.SetChildIndex(this.btnClose, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnUpdate, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnDelete, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnCreate, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnRefresh, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnExcel, 0);
            // 
            // pnlCenter
            // 
            this.pnlCenter.Enabled = false;
            this.pnlCenter.Size = new System.Drawing.Size(742, 546);
            this.pnlCenter.Visible = false;
            // 
            // pnlTop
            // 
            this.pnlTop.Padding = new System.Windows.Forms.Padding(1);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Location = new System.Drawing.Point(1, 1);
            this.lblFormTitle.Size = new System.Drawing.Size(740, 0);
            this.lblFormTitle.Text = "Attach Recipe to MFO";
            // 
            // pnlTab
            // 
            this.pnlTab.Controls.Add(this.tabMFO);
            this.pnlTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTab.Location = new System.Drawing.Point(0, 0);
            this.pnlTab.Name = "pnlTab";
            this.pnlTab.Padding = new System.Windows.Forms.Padding(3);
            this.pnlTab.Size = new System.Drawing.Size(742, 509);
            this.pnlTab.TabIndex = 0;
            // 
            // tabMFO
            // 
            this.tabMFO.Controls.Add(this.tbpOper);
            this.tabMFO.Controls.Add(this.tbpFO);
            this.tabMFO.Controls.Add(this.tbpMFO);
            this.tabMFO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMFO.ItemSize = new System.Drawing.Size(60, 18);
            this.tabMFO.Location = new System.Drawing.Point(3, 3);
            this.tabMFO.Name = "tabMFO";
            this.tabMFO.SelectedIndex = 0;
            this.tabMFO.Size = new System.Drawing.Size(736, 503);
            this.tabMFO.TabIndex = 0;
            this.tabMFO.SelectedIndexChanged += new System.EventHandler(this.tabMFO_SelectedIndexChanged);
            // 
            // tbpOper
            // 
            this.tbpOper.Controls.Add(this.spdOper);
            this.tbpOper.Location = new System.Drawing.Point(4, 22);
            this.tbpOper.Name = "tbpOper";
            this.tbpOper.Padding = new System.Windows.Forms.Padding(3);
            this.tbpOper.Size = new System.Drawing.Size(728, 477);
            this.tbpOper.TabIndex = 0;
            this.tbpOper.Text = "Operation";
            // 
            // spdOper
            // 
            this.spdOper.AccessibleDescription = "";
            this.spdOper.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdOper.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdOper.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdOper.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdOper.HorizontalScrollBar.Name = "";
            this.spdOper.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdOper.HorizontalScrollBar.TabIndex = 2;
            this.spdOper.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            this.spdOper.Location = new System.Drawing.Point(3, 3);
            this.spdOper.Name = "spdOper";
            this.spdOper.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdOper.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdOper.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdOper_Sheet1});
            this.spdOper.Size = new System.Drawing.Size(722, 471);
            this.spdOper.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdOper.TabIndex = 0;
            this.spdOper.TabStop = false;
            this.spdOper.TextTipDelay = 200;
            this.spdOper.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdOper.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdOper.VerticalScrollBar.Name = "";
            this.spdOper.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
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
            this.spdOper_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Recipe";
            this.spdOper_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdOper_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdOper_Sheet1.ColumnHeader.Rows.Get(0).Height = 18F;
            checkBoxCellType1.BackgroundImage = new FarPoint.Win.Picture(null, FarPoint.Win.RenderStyle.Normal, System.Drawing.Color.Empty, 0, FarPoint.Win.HorizontalAlignment.Center, FarPoint.Win.VerticalAlignment.Center);
            this.spdOper_Sheet1.Columns.Get(0).CellType = checkBoxCellType1;
            this.spdOper_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdOper_Sheet1.Columns.Get(0).Label = "Sel";
            this.spdOper_Sheet1.Columns.Get(0).Width = 27F;
            textCellType1.MaxLength = 20;
            this.spdOper_Sheet1.Columns.Get(1).CellType = textCellType1;
            this.spdOper_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdOper_Sheet1.Columns.Get(1).Label = "Operation";
            this.spdOper_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOper_Sheet1.Columns.Get(1).Width = 140F;
            this.spdOper_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdOper_Sheet1.Columns.Get(2).Label = "Description";
            this.spdOper_Sheet1.Columns.Get(2).Locked = false;
            this.spdOper_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOper_Sheet1.Columns.Get(2).Width = 240F;
            this.spdOper_Sheet1.Columns.Get(3).CellType = textCellType2;
            this.spdOper_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdOper_Sheet1.Columns.Get(3).Label = "Recipe";
            this.spdOper_Sheet1.Columns.Get(3).Locked = false;
            this.spdOper_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOper_Sheet1.Columns.Get(3).Width = 120F;
            buttonCellType1.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
            buttonCellType1.Text = "...";
            this.spdOper_Sheet1.Columns.Get(4).CellType = buttonCellType1;
            this.spdOper_Sheet1.Columns.Get(4).Locked = false;
            this.spdOper_Sheet1.Columns.Get(4).Width = 20F;
            this.spdOper_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdOper_Sheet1.RowHeader.Columns.Default.Resizable = true;
            this.spdOper_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdOper_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdOper_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdOper_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdOper_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // tbpFO
            // 
            this.tbpFO.Controls.Add(this.pnlFOMid);
            this.tbpFO.Controls.Add(this.grpFO);
            this.tbpFO.Location = new System.Drawing.Point(4, 22);
            this.tbpFO.Name = "tbpFO";
            this.tbpFO.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.tbpFO.Size = new System.Drawing.Size(728, 477);
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
            this.pnlFOMid.Size = new System.Drawing.Size(722, 427);
            this.pnlFOMid.TabIndex = 2;
            // 
            // spdFO
            // 
            this.spdFO.AccessibleDescription = "";
            this.spdFO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdFO.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdFO.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdFO.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdFO.HorizontalScrollBar.Name = "";
            this.spdFO.HorizontalScrollBar.Renderer = defaultScrollBarRenderer3;
            this.spdFO.HorizontalScrollBar.TabIndex = 2;
            this.spdFO.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            this.spdFO.Location = new System.Drawing.Point(0, 5);
            this.spdFO.Name = "spdFO";
            this.spdFO.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdFO.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdFO.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdFO_Sheet1});
            this.spdFO.Size = new System.Drawing.Size(722, 422);
            this.spdFO.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdFO.TabIndex = 0;
            this.spdFO.TabStop = false;
            this.spdFO.TextTipDelay = 200;
            this.spdFO.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdFO.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdFO.VerticalScrollBar.Name = "";
            this.spdFO.VerticalScrollBar.Renderer = defaultScrollBarRenderer4;
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
            this.spdFO_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Recipe";
            this.spdFO_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdFO_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdFO_Sheet1.ColumnHeader.Rows.Get(0).Height = 18F;
            checkBoxCellType2.BackgroundImage = new FarPoint.Win.Picture(null, FarPoint.Win.RenderStyle.Normal, System.Drawing.Color.Empty, 0, FarPoint.Win.HorizontalAlignment.Center, FarPoint.Win.VerticalAlignment.Center);
            this.spdFO_Sheet1.Columns.Get(0).CellType = checkBoxCellType2;
            this.spdFO_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdFO_Sheet1.Columns.Get(0).Label = "Sel";
            this.spdFO_Sheet1.Columns.Get(0).Width = 35F;
            textCellType3.MaxLength = 20;
            this.spdFO_Sheet1.Columns.Get(1).CellType = textCellType3;
            this.spdFO_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdFO_Sheet1.Columns.Get(1).Label = "Operation";
            this.spdFO_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdFO_Sheet1.Columns.Get(1).Width = 140F;
            this.spdFO_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdFO_Sheet1.Columns.Get(2).Label = "Description";
            this.spdFO_Sheet1.Columns.Get(2).Locked = false;
            this.spdFO_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdFO_Sheet1.Columns.Get(2).Width = 240F;
            this.spdFO_Sheet1.Columns.Get(3).CellType = textCellType4;
            this.spdFO_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdFO_Sheet1.Columns.Get(3).Label = "Recipe";
            this.spdFO_Sheet1.Columns.Get(3).Locked = false;
            this.spdFO_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdFO_Sheet1.Columns.Get(3).Width = 120F;
            buttonCellType2.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
            buttonCellType2.Text = "...";
            this.spdFO_Sheet1.Columns.Get(4).CellType = buttonCellType2;
            this.spdFO_Sheet1.Columns.Get(4).Width = 20F;
            this.spdFO_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdFO_Sheet1.RowHeader.Columns.Default.Resizable = true;
            this.spdFO_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdFO_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdFO_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdFO_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdFO_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // grpFO
            // 
            this.grpFO.Controls.Add(this.cdvFlow);
            this.grpFO.Controls.Add(this.lblFlowDesc);
            this.grpFO.Controls.Add(this.lblFlow);
            this.grpFO.Controls.Add(this.txtFlowDesc);
            this.grpFO.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpFO.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpFO.Location = new System.Drawing.Point(3, 0);
            this.grpFO.Name = "grpFO";
            this.grpFO.Size = new System.Drawing.Size(722, 47);
            this.grpFO.TabIndex = 0;
            this.grpFO.TabStop = false;
            // 
            // cdvFlow
            // 
            this.cdvFlow.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvFlow.BorderHotColor = System.Drawing.Color.Black;
            this.cdvFlow.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvFlow.BtnToolTipText = "";
            this.cdvFlow.DescText = "";
            this.cdvFlow.DisplaySubItemIndex = -1;
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
            this.cdvFlow.Size = new System.Drawing.Size(200, 20);
            this.cdvFlow.SmallImageList = null;
            this.cdvFlow.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvFlow.TabIndex = 1;
            this.cdvFlow.TextBoxToolTipText = "";
            this.cdvFlow.TextBoxWidth = 200;
            this.cdvFlow.VisibleButton = true;
            this.cdvFlow.VisibleColumnHeader = false;
            this.cdvFlow.VisibleDescription = false;
            this.cdvFlow.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvFlow_SelectedItemChanged);
            this.cdvFlow.ButtonPress += new System.EventHandler(this.cdvFlow_ButtonPress);
            // 
            // lblFlowDesc
            // 
            this.lblFlowDesc.AutoSize = true;
            this.lblFlowDesc.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblFlowDesc.Location = new System.Drawing.Point(296, 19);
            this.lblFlowDesc.Name = "lblFlowDesc";
            this.lblFlowDesc.Size = new System.Drawing.Size(60, 13);
            this.lblFlowDesc.TabIndex = 2;
            this.lblFlowDesc.Text = "Description";
            this.lblFlowDesc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            // txtFlowDesc
            // 
            this.txtFlowDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFlowDesc.Location = new System.Drawing.Point(372, 16);
            this.txtFlowDesc.MaxLength = 200;
            this.txtFlowDesc.Name = "txtFlowDesc";
            this.txtFlowDesc.ReadOnly = true;
            this.txtFlowDesc.Size = new System.Drawing.Size(344, 20);
            this.txtFlowDesc.TabIndex = 3;
            this.txtFlowDesc.TabStop = false;
            // 
            // tbpMFO
            // 
            this.tbpMFO.Controls.Add(this.pnlMFOMid);
            this.tbpMFO.Controls.Add(this.grpMFO);
            this.tbpMFO.Location = new System.Drawing.Point(4, 22);
            this.tbpMFO.Name = "tbpMFO";
            this.tbpMFO.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.tbpMFO.Size = new System.Drawing.Size(728, 477);
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
            this.pnlMFOMid.Size = new System.Drawing.Size(722, 427);
            this.pnlMFOMid.TabIndex = 3;
            // 
            // spdMFO
            // 
            this.spdMFO.AccessibleDescription = "spdMFO, Sheet1";
            this.spdMFO.BackColor = System.Drawing.SystemColors.Control;
            this.spdMFO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdMFO.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdMFO.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdMFO.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdMFO.HorizontalScrollBar.Name = "";
            this.spdMFO.HorizontalScrollBar.Renderer = defaultScrollBarRenderer5;
            this.spdMFO.HorizontalScrollBar.TabIndex = 2;
            this.spdMFO.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            this.spdMFO.Location = new System.Drawing.Point(0, 5);
            this.spdMFO.Name = "spdMFO";
            this.spdMFO.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdMFO.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdMFO.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdMFO_Sheet1});
            this.spdMFO.Size = new System.Drawing.Size(722, 422);
            this.spdMFO.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdMFO.TabIndex = 0;
            this.spdMFO.TabStop = false;
            this.spdMFO.TextTipDelay = 200;
            this.spdMFO.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdMFO.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdMFO.VerticalScrollBar.Name = "";
            this.spdMFO.VerticalScrollBar.Renderer = defaultScrollBarRenderer6;
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
            this.spdMFO_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Recipe";
            this.spdMFO_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdMFO_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdMFO_Sheet1.ColumnHeader.Rows.Get(0).Height = 18F;
            checkBoxCellType3.BackgroundImage = new FarPoint.Win.Picture(null, FarPoint.Win.RenderStyle.Normal, System.Drawing.Color.Empty, 0, FarPoint.Win.HorizontalAlignment.Center, FarPoint.Win.VerticalAlignment.Center);
            this.spdMFO_Sheet1.Columns.Get(0).CellType = checkBoxCellType3;
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
            textCellType5.MaxLength = 20;
            this.spdMFO_Sheet1.Columns.Get(3).CellType = textCellType5;
            this.spdMFO_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdMFO_Sheet1.Columns.Get(3).Label = "Operation";
            this.spdMFO_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMFO_Sheet1.Columns.Get(3).Width = 80F;
            this.spdMFO_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdMFO_Sheet1.Columns.Get(4).Label = "Oper Description";
            this.spdMFO_Sheet1.Columns.Get(4).Locked = false;
            this.spdMFO_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMFO_Sheet1.Columns.Get(4).Width = 120F;
            this.spdMFO_Sheet1.Columns.Get(5).CellType = textCellType6;
            this.spdMFO_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdMFO_Sheet1.Columns.Get(5).Label = "Recipe";
            this.spdMFO_Sheet1.Columns.Get(5).Locked = false;
            this.spdMFO_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMFO_Sheet1.Columns.Get(5).Width = 120F;
            buttonCellType3.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
            buttonCellType3.Text = "...";
            this.spdMFO_Sheet1.Columns.Get(6).CellType = buttonCellType3;
            this.spdMFO_Sheet1.Columns.Get(6).Locked = false;
            this.spdMFO_Sheet1.Columns.Get(6).Width = 20F;
            this.spdMFO_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdMFO_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdMFO_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdMFO_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdMFO_Sheet1.Rows.Default.Height = 18F;
            this.spdMFO_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdMFO_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdMFO_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // grpMFO
            // 
            this.grpMFO.Controls.Add(this.cdvMaterial);
            this.grpMFO.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpMFO.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpMFO.Location = new System.Drawing.Point(3, 0);
            this.grpMFO.Name = "grpMFO";
            this.grpMFO.Size = new System.Drawing.Size(722, 47);
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
            this.cdvMaterial.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvMaterial.LabelText = "Material";
            this.cdvMaterial.ListCond_ExtFactory = "";
            this.cdvMaterial.ListCond_StepMaterial = '1';
            this.cdvMaterial.ListCond_StepVersion = '1';
            this.cdvMaterial.Location = new System.Drawing.Point(6, 16);
            this.cdvMaterial.MaterialEnabled = true;
            this.cdvMaterial.MaterialReadOnly = false;
            this.cdvMaterial.Name = "cdvMaterial";
            this.cdvMaterial.SearchSubItemIndex = 0;
            this.cdvMaterial.SelectedDescIndex = 2;
            this.cdvMaterial.SelectedSubItemIndex = 0;
            this.cdvMaterial.Size = new System.Drawing.Size(710, 20);
            this.cdvMaterial.TabIndex = 4;
            this.cdvMaterial.VersionEnabled = true;
            this.cdvMaterial.VersionReadOnly = false;
            this.cdvMaterial.VisibleColumnHeader = false;
            this.cdvMaterial.VisibleDescription = true;
            this.cdvMaterial.VisibleMaterialButton = true;
            this.cdvMaterial.VisibleVersionButton = true;
            this.cdvMaterial.WidthButton = 20;
            this.cdvMaterial.WidthLabel = 80;
            this.cdvMaterial.WidthMaterialAndVersion = 226;
            this.cdvMaterial.WidthVersion = 50;
            this.cdvMaterial.MaterialSelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvMaterial_SelectedItemChanged);
            this.cdvMaterial.VersionSelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvMaterial_SelectedItemChanged);
            // 
            // cdvRecipe
            // 
            this.cdvRecipe.BackColor = System.Drawing.Color.PaleTurquoise;
            this.cdvRecipe.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvRecipe.BorderHotColor = System.Drawing.Color.Black;
            this.cdvRecipe.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cdvRecipe.Location = new System.Drawing.Point(429, 17);
            this.cdvRecipe.MCViewStyle.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvRecipe.MCViewStyle.BorderHotColor = System.Drawing.Color.Black;
            this.cdvRecipe.Name = "cdvRecipe";
            this.cdvRecipe.Size = new System.Drawing.Size(20, 20);
            this.cdvRecipe.SmallImageList = null;
            this.cdvRecipe.TabIndex = 0;
            this.cdvRecipe.TabStop = false;
            this.cdvRecipe.ViewPosition = new System.Drawing.Point(0, 0);
            this.cdvRecipe.Visible = false;
            this.cdvRecipe.VisibleColumnHeader = false;
            this.cdvRecipe.SelectedItemChanged += new Miracom.UI.MCSSCodeViewSelChangedHandler(this.cdvRecipe_SelectedItemChanged);
            // 
            // btnRefresh
            // 
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnRefresh.Location = new System.Drawing.Point(10, 6);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(24, 24);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExcel.Image")));
            this.btnExcel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnExcel.Location = new System.Drawing.Point(37, 6);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(24, 24);
            this.btnExcel.TabIndex = 5;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // frmRCPSetupAttachRecipeToMFO
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Controls.Add(this.pnlTab);
            this.Name = "frmRCPSetupAttachRecipeToMFO";
            this.Text = "Attach Recipe To MFO Setup";
            this.Activated += new System.EventHandler(this.frmRCPSetupAttachRecipeToMFO_Activated);
            this.Controls.SetChildIndex(this.pnlCenter, 0);
            this.Controls.SetChildIndex(this.pnlTop, 0);
            this.Controls.SetChildIndex(this.pnlBottom, 0);
            this.Controls.SetChildIndex(this.pnlTab, 0);
            this.pnlBottom.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlTab.ResumeLayout(false);
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
            ((System.ComponentModel.ISupportInitialize)(this.cdvRecipe)).EndInit();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Constant Definition "
        
        private const int MAX_MFO_COUNT = 5000;
        
        #endregion
        
        #region " Variable Definition "
        
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
        private void ClearData(char ProcStep)
        {
            //            int i = 0;
            
            try
            {
                if (ProcStep == '1')
                {
                    if (tabMFO.SelectedIndex == 0)
                    {
                        MPCF.ClearList(spdOper);
                    }
                    else if (tabMFO.SelectedIndex == 1)
                    {
                        MPCF.ClearList(spdFO);
                    }
                    else if (tabMFO.SelectedIndex == 2)
                    {
                        MPCF.ClearList(spdMFO);
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
            int i = 0;
            int iChkCnt = 0;
            
            try
            {
                switch (MPCF.Trim(FuncName))
                {
                    case "Update_MFO_Recipe_List":
                        
                        
                        if (tabMFO.SelectedIndex == 0)
                        {
                            for (i = 0; i <= spdOper.Sheets[0].RowCount - 1; i++)
                            {
                                if (spdOper.Sheets[0].GetValue(i, 0) != null && Convert.ToBoolean(spdOper.Sheets[0].GetValue(i, 0)) == true)
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
                                if (spdFO.Sheets[0].GetValue(i, 0) != null && Convert.ToBoolean(spdFO.Sheets[0].GetValue(i, 0)) == true)
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
                                if (spdMFO.Sheets[0].GetValue(i, 0) != null && Convert.ToBoolean(spdMFO.Sheets[0].GetValue(i, 0)) == true)
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
                        
                    case "View_MFO_Recipe_List":
                        
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
        // View_MFO_Recipe_List()
        //       - View MFO-Recipe Relation List
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String : Process Step
        //       - ByVal OptLevel As String : Option Level("1" : M-F-O, "2" : F-O, "3" : O)
        //
        private bool View_MFO_Recipe_List(char ProcStep, char OptLevel)
        {
            int i;
            int LastRow = 0;

            TRSNode in_node = new TRSNode("VIEW_MFO_RECIPE_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_MFO_RECIPE_LIST_OUT");
            
            try
            {
                ClearData('1');
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;
                in_node.AddChar("OPT_LEVEL", OptLevel);
                in_node.AddString("FLOW", "");
                in_node.AddString("MAT_ID", "");
                in_node.AddInt("MAT_VER", 0);
                in_node.AddString("OPER", "");
                in_node.AddInt("NEXT_SEQ", 0);
                
                if (OptLevel == '1')
                {
                    in_node.SetString("MAT_ID", cdvMaterial.Text);
                    in_node.SetInt("MAT_VER", cdvMaterial.Version);
                }
                else if (OptLevel == '2')
                {
                    in_node.SetString("FLOW", cdvFlow.Text);
                }
                                
                do
                {
                    if (MPCR.CallService("RCP", "RCP_View_MFO_Recipe_List", in_node, ref out_node) == false)
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
                                
                                with_1.SetValue(LastRow, 1, MPCF.Trim(out_node.GetList(0)[i].GetString("FLOW")));
                                with_1.SetValue(LastRow, 2, MPCF.Trim(out_node.GetList(0)[i].GetString("FLOW_DESC")));
                                with_1.SetValue(LastRow, 3, MPCF.Trim(out_node.GetList(0)[i].GetString("OPER")));
                                with_1.SetValue(LastRow, 4, MPCF.Trim(out_node.GetList(0)[i].GetString("OPER_DESC")));
                                with_1.SetValue(LastRow, 5, MPCF.Trim(out_node.GetList(0)[i].GetString("RECIPE")));
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
                                
                                with_2.SetValue(LastRow, 1, MPCF.Trim(out_node.GetList(0)[i].GetString("OPER")));
                                with_2.SetValue(LastRow, 2, MPCF.Trim(out_node.GetList(0)[i].GetString("OPER_DESC")));
                                with_2.SetValue(LastRow, 3, MPCF.Trim(out_node.GetList(0)[i].GetString("RECIPE")));
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
                                
                                with_3.SetValue(LastRow, 1, MPCF.Trim(out_node.GetList(0)[i].GetString("OPER")));
                                with_3.SetValue(LastRow, 2, MPCF.Trim(out_node.GetList(0)[i].GetString("OPER_DESC")));
                                with_3.SetValue(LastRow, 3, MPCF.Trim(out_node.GetList(0)[i].GetString("RECIPE")));
                            }

                            if (i > 0)
                                in_node.SetString("OPER", out_node.GetList(0)[i-1].GetString("OPER"));

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
        // Update_MFO_Recipe_List()
        //       - Attach/Detach Recipe to MFO
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String : Process Step
        //       - ByVal OptLevel As String : Option Level("1" : M-F-O, "2" : F-O, "3" : O)
        //
        private bool Update_MFO_Recipe_List(char ProcStep, char OptLevel)
        {
            int i = 0;

            TRSNode in_node = new TRSNode("UPDATE_MFO_RECIPE_LIST_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");
            TRSNode msg_list;

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;
                in_node.AddChar("OPT_LEVEL", OptLevel);
                in_node.AddInt("COUNT", 0);
                

                switch (OptLevel)
                {
                    case '1':
                        
                        for (i = 0; i <= spdMFO.Sheets[0].RowCount - 1; i++)
                        {
                            if (spdMFO.Sheets[0].GetValue(i, 0) != null && Convert.ToBoolean(spdMFO.Sheets[0].GetValue(i, 0)) == true)
                            {
                            }
                        }

                        for (i = 0; i <= spdMFO.Sheets[0].RowCount - 1; i++)
                        {
                            if (spdMFO.Sheets[0].GetValue(i, 0) != null && Convert.ToBoolean(spdMFO.Sheets[0].GetValue(i, 0)) == true)
                            {
                                msg_list = in_node.AddNode("MFO_RECIPE_LIST");

                                msg_list.AddString("MAT_ID", MPCF.Trim(cdvMaterial.Text));
                                msg_list.AddInt("MAT_VER", cdvMaterial.Version);
                                msg_list.AddString("FLOW", MPCF.Trim(spdMFO.Sheets[0].GetValue(i, 1)));
                                msg_list.AddString("OPER", MPCF.Trim(spdMFO.Sheets[0].GetValue(i, 3)));
                                msg_list.AddString("RECIPE", MPCF.Trim(spdMFO.Sheets[0].GetValue(i, 5)));
                            }
                        }
                        break;
                    case '2':
                        
                        for (i = 0; i <= spdFO.Sheets[0].RowCount - 1; i++)
                        {
                            if (spdFO.Sheets[0].GetValue(i, 0) != null && Convert.ToBoolean(spdFO.Sheets[0].GetValue(i, 0)) == true)
                            {
                            }
                        }

                        for (i = 0; i <= spdFO.Sheets[0].RowCount - 1; i++)
                        {
                            if (spdFO.Sheets[0].GetValue(i, 0) != null && Convert.ToBoolean(spdFO.Sheets[0].GetValue(i, 0)) == true)
                            {
                                msg_list = in_node.AddNode("MFO_RECIPE_LIST");

                                msg_list.AddString("FLOW", MPCF.Trim(cdvFlow.Text));
                                msg_list.AddString("OPER", MPCF.Trim(spdFO.Sheets[0].GetValue(i, 1)));
                                msg_list.AddString("RECIPE", MPCF.Trim(spdFO.Sheets[0].GetValue(i, 3)));
                            }
                        }
                        break;
                    case '3':
                        
                        for (i = 0; i <= spdOper.Sheets[0].RowCount - 1; i++)
                        {
                            if (spdOper.Sheets[0].GetValue(i, 0) != null && Convert.ToBoolean(spdOper.Sheets[0].GetValue(i, 0)) == true)
                            {
                            }
                        }

                        for (i = 0; i <= spdOper.Sheets[0].RowCount - 1; i++)
                        {
                            if (spdOper.Sheets[0].GetValue(i, 0) != null && Convert.ToBoolean(spdOper.Sheets[0].GetValue(i, 0)) == true)
                            {
                                msg_list = in_node.AddNode("MFO_RECIPE_LIST");

                                msg_list.AddString("OPER", MPCF.Trim(spdOper.Sheets[0].GetValue(i, 1)));
                                msg_list.AddString("RECIPE", MPCF.Trim(spdOper.Sheets[0].GetValue(i, 3)));
                            }
                        }
                        break;
                }

                if (MPCR.CallService("RCP", "RCP_Update_MFO_Recipe_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                View_MFO_Recipe_List('1', OptLevel);
                
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
        
        private void frmRCPSetupAttachRecipeToMFO_Activated(object sender, System.EventArgs e)
        {
            try
            {
                if (LoadFlag == false)
                {
                    tabMFO.SelectedIndex = 0;
                    
                    if (View_MFO_Recipe_List('1', '3') == false)
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
                if (CheckCondition("Update_MFO_Recipe_List", MPGC.MP_STEP_UPDATE) == true)
                {
                    if (tabMFO.SelectedIndex == 0)
                    {
                        Update_MFO_Recipe_List(MPGC.MP_STEP_UPDATE, '3');
                    }
                    else if (tabMFO.SelectedIndex == 1)
                    {
                        Update_MFO_Recipe_List(MPGC.MP_STEP_UPDATE, '2');
                    }
                    else if (tabMFO.SelectedIndex == 2)
                    {
                        Update_MFO_Recipe_List(MPGC.MP_STEP_UPDATE, '1');
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
                ClearData('1');
            }
            else
            {
                txtFlowDesc.Text = cdvFlow.SelectedItem.SubItems[1].Text;
                View_MFO_Recipe_List('1', '2');
            }
        }

        private void cdvMaterial_SelectedItemChanged(System.Object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            if (cdvMaterial.Text == "")
            {
                ClearData('1');
            }
            else
            {
                View_MFO_Recipe_List('1', '1');
            }
        }
        
        private void cdvFlow_ButtonPress(System.Object sender, System.EventArgs e)
        {
            cdvFlow.Init();
            MPCF.InitListView(cdvFlow.GetListView);
            cdvFlow.Columns.Add("Flow", 100, HorizontalAlignment.Left);
            cdvFlow.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvFlow.SelectedSubItemIndex = 0;
            cdvFlow.ReadOnly = true;
            WIPLIST.ViewFlowList(cdvFlow.GetListView, '1', "",0, "", null, "");
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
            
            if (e.Column == 4)
            {

                sOper = MPCF.Trim(spdOper.Sheets[0].GetValue(e.Row, 1));
                cdvRecipe.Init();
                cdvRecipe.ViewPosition = Control.MousePosition;
                MPCF.InitListView(cdvRecipe.GetListView);
                cdvRecipe.Columns.Add("Recipe", 50, HorizontalAlignment.Left);
                if (RCPLIST.ViewRecipeList(cdvRecipe.GetListView, '1', " ", sOper, null, "", -1, -1) == false)
                {
                    return;
                }
                if (cdvRecipe.ShowPopupList(e.Row, e.Column) == false)
                {
                    return;
                }
                
            }
        }
        
        private void spdMFO_ButtonClicked(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            string sOper;
            
            if (e.Column == 6)
            {

                sOper = MPCF.Trim(spdMFO.Sheets[0].GetValue(e.Row, 3));
                cdvRecipe.ViewPosition = Control.MousePosition;
                
                if (RCPLIST.ViewRecipeList(cdvRecipe.GetListView, '1', " ", sOper, null, "", -1, -1) == false)
                {
                    return;
                }
                if (cdvRecipe.ShowPopupList(e.Row, e.Column) == false)
                {
                    return;
                }
                
            }
        }
        
        private void spdFO_ButtonClicked(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            string sOper;
            
            if (e.Column == 4)
            {

                sOper = MPCF.Trim(spdFO.Sheets[0].GetValue(e.Row, 1));
                cdvRecipe.ViewPosition = Control.MousePosition;
                
                if (RCPLIST.ViewRecipeList(cdvRecipe.GetListView, '1', " ", sOper, null, "", -1, -1) == false)
                {
                    return;
                }
                if (cdvRecipe.ShowPopupList(e.Row, e.Column) == false)
                {
                    return;
                }
                
            }
        }
        
        private void cdvRecipe_SelectedItemChanged(System.Object sender, Miracom.UI.MCSSCodeViewSelChanged_EventArgs e)
        {
            
            try
            {
                if (MPCF.Trim(e.SelectedItem.SubItems[0].Text) == "")
                {
                    return;
                }
                
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
                if (View_MFO_Recipe_List('1', '3') == false)
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
                    btnExcel.Location = new Point(37, 6);
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
                string sCond;

                if (tabMFO.SelectedIndex == 0)  // Operation
                {
                    MPCF.ExportToExcel(spdOper, this.Text, "");
                }
                else if (tabMFO.SelectedIndex == 1) // Flow - Operation
                {
                    sCond = "Flow : " + cdvFlow.Text;

                    MPCF.ExportToExcel(spdFO, this.Text, sCond);
                }
                else if (tabMFO.SelectedIndex == 2) // Material - Flow - Operation
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
    //#End If
}
