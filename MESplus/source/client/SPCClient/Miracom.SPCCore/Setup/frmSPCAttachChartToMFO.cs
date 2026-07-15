
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
using FarPoint.Win.Spread;
using Miracom.TRSCore;

//#If _SPC = True Then

//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmSPCAttachChartToMFO.vb
//   Description : Attach Chart To MFO
//
//   MES Version : 4.1.0.0
//
//   Function List
//       - ClearData() : Intialize Form Field
//       - CheckCondition() : Check the conditions before transaction
//       - Update_MFO_Chart_List() : Attach/Detach Collection Sets to MFO, FO, O
//       - View_MFO_Chart_List() :View MFO-Collection Set Relation
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2006-01-19 : Created by H.K.Kim
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------

//Imports
namespace Miracom.SPCCore
{
    public class frmSPCAttachChartToMFO : System.Windows.Forms.Form
    {
        
        #region " Windows Form auto generated code "
        
        public frmSPCAttachChartToMFO()
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
        public System.Windows.Forms.Button btnUpdate;
        public System.Windows.Forms.Button btnClose;
        internal System.Windows.Forms.Panel pnlFill;
        internal System.Windows.Forms.TabControl tabMFO;
        internal System.Windows.Forms.TabPage tbpOper;
        internal FarPoint.Win.Spread.FpSpread spdOper;
        internal System.Windows.Forms.TabPage tbpFO;
        internal System.Windows.Forms.Panel pnlFOMid;
        internal FarPoint.Win.Spread.FpSpread spdFO;
        internal System.Windows.Forms.GroupBox grpFO;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvFlow;
        internal System.Windows.Forms.Label lblFlow;
        internal System.Windows.Forms.TabPage tbpMFO;
        internal System.Windows.Forms.Panel pnlMFOMid;
        internal FarPoint.Win.Spread.FpSpread spdMFO;
        internal System.Windows.Forms.GroupBox grpMFO;
        internal FarPoint.Win.Spread.SheetView spdOper_Sheet1;
        internal FarPoint.Win.Spread.SheetView spdFO_Sheet1;
        internal FarPoint.Win.Spread.SheetView spdMFO_Sheet1;
        internal Miracom.UI.Controls.MCCodeView.MCSPCodeView cdvChart;
        private Miracom.MESCore.Controls.udcMaterial cdvMaterial;
        internal System.Windows.Forms.Button btnRefresh;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSPCAttachChartToMFO));
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType1 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.ComboBoxCellType comboBoxCellType1 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            FarPoint.Win.Spread.CellType.ButtonCellType buttonCellType1 = new FarPoint.Win.Spread.CellType.ButtonCellType();
            FarPoint.Win.Spread.CellType.ComboBoxCellType comboBoxCellType2 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer3 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer4 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType2 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.ComboBoxCellType comboBoxCellType3 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            FarPoint.Win.Spread.CellType.ButtonCellType buttonCellType2 = new FarPoint.Win.Spread.CellType.ButtonCellType();
            FarPoint.Win.Spread.CellType.ComboBoxCellType comboBoxCellType4 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer5 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer6 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType3 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType3 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.ComboBoxCellType comboBoxCellType5 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            FarPoint.Win.Spread.CellType.ButtonCellType buttonCellType3 = new FarPoint.Win.Spread.CellType.ButtonCellType();
            FarPoint.Win.Spread.CellType.ComboBoxCellType comboBoxCellType6 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.cdvChart = new Miracom.UI.Controls.MCCodeView.MCSPCodeView();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.pnlFill = new System.Windows.Forms.Panel();
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
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChart)).BeginInit();
            this.pnlFill.SuspendLayout();
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
            this.SuspendLayout();
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnRefresh);
            this.pnlBottom.Controls.Add(this.cdvChart);
            this.pnlBottom.Controls.Add(this.btnUpdate);
            this.pnlBottom.Controls.Add(this.btnClose);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 506);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Padding = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.pnlBottom.Size = new System.Drawing.Size(742, 40);
            this.pnlBottom.TabIndex = 1;
            // 
            // btnRefresh
            // 
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnRefresh.Location = new System.Drawing.Point(10, 6);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(24, 24);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // cdvChart
            // 
            this.cdvChart.BackColor = System.Drawing.Color.PaleTurquoise;
            this.cdvChart.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvChart.BorderHotColor = System.Drawing.Color.Black;
            this.cdvChart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvChart.Location = new System.Drawing.Point(17, 17);
            this.cdvChart.MCViewStyle.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvChart.MCViewStyle.BorderHotColor = System.Drawing.Color.Black;
            this.cdvChart.Name = "cdvChart";
            this.cdvChart.Size = new System.Drawing.Size(20, 20);
            this.cdvChart.SmallImageList = null;
            this.cdvChart.TabIndex = 5;
            this.cdvChart.TabStop = false;
            this.cdvChart.ViewPosition = new System.Drawing.Point(0, 0);
            this.cdvChart.Visible = false;
            this.cdvChart.VisibleColumnHeader = false;
            this.cdvChart.SelectedItemChanged += new Miracom.UI.MCSSCodeViewSelChangedHandler(this.cdvChart_SelectedItemChanged);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnUpdate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnUpdate.Location = new System.Drawing.Point(558, 8);
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
            this.btnClose.Location = new System.Drawing.Point(650, 8);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(88, 26);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pnlFill
            // 
            this.pnlFill.Controls.Add(this.tabMFO);
            this.pnlFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFill.Location = new System.Drawing.Point(0, 0);
            this.pnlFill.Name = "pnlFill";
            this.pnlFill.Padding = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.pnlFill.Size = new System.Drawing.Size(742, 506);
            this.pnlFill.TabIndex = 0;
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
            this.tabMFO.TabStop = false;
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
            this.spdOper.ButtonDrawMode = FarPoint.Win.Spread.ButtonDrawModes.CurrentRow;
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
            this.spdOper.ButtonClicked += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.spdOper_ButtonClicked);
            this.spdOper.ComboCloseUp += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.spdOper_ComboCloseUp);
            this.spdOper.EditChange += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.spdOper_EditChange);
            this.spdOper.SetActiveViewport(0, -1, -1);
            // 
            // spdOper_Sheet1
            // 
            this.spdOper_Sheet1.Reset();
            spdOper_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdOper_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdOper_Sheet1.ColumnCount = 7;
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
            this.spdOper_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Chart Flag";
            this.spdOper_Sheet1.ColumnHeader.Cells.Get(0, 4).ColumnSpan = 2;
            this.spdOper_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Chart ID";
            this.spdOper_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Override";
            this.spdOper_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdOper_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdOper_Sheet1.ColumnHeader.Rows.Get(0).Height = 18F;
            checkBoxCellType1.BackgroundImage = new FarPoint.Win.Picture(null, FarPoint.Win.RenderStyle.Normal, System.Drawing.Color.Empty, 0, FarPoint.Win.HorizontalAlignment.Center, FarPoint.Win.VerticalAlignment.Center);
            checkBoxCellType1.TextAlign = FarPoint.Win.ButtonTextAlign.TextLeftPictRight;
            this.spdOper_Sheet1.Columns.Get(0).CellType = checkBoxCellType1;
            this.spdOper_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdOper_Sheet1.Columns.Get(0).Label = "Sel";
            this.spdOper_Sheet1.Columns.Get(0).Width = 35F;
            textCellType1.MaxLength = 20;
            this.spdOper_Sheet1.Columns.Get(1).CellType = textCellType1;
            this.spdOper_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdOper_Sheet1.Columns.Get(1).Label = "Operation";
            this.spdOper_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOper_Sheet1.Columns.Get(1).Width = 130F;
            this.spdOper_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdOper_Sheet1.Columns.Get(2).Label = "Description";
            this.spdOper_Sheet1.Columns.Get(2).Locked = false;
            this.spdOper_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOper_Sheet1.Columns.Get(2).Width = 180F;
            comboBoxCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            comboBoxCellType1.Items = new string[] {
        "",
        "Chart",
        "Chart Set"};
            this.spdOper_Sheet1.Columns.Get(3).CellType = comboBoxCellType1;
            this.spdOper_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdOper_Sheet1.Columns.Get(3).Label = "Chart Flag";
            this.spdOper_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOper_Sheet1.Columns.Get(3).Width = 80F;
            this.spdOper_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdOper_Sheet1.Columns.Get(4).Label = "Chart ID";
            this.spdOper_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOper_Sheet1.Columns.Get(4).Width = 150F;
            buttonCellType1.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
            buttonCellType1.Text = "...";
            this.spdOper_Sheet1.Columns.Get(5).CellType = buttonCellType1;
            this.spdOper_Sheet1.Columns.Get(5).Resizable = false;
            this.spdOper_Sheet1.Columns.Get(5).Width = 20F;
            comboBoxCellType2.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            comboBoxCellType2.Items = new string[] {
        "",
        "Yes"};
            this.spdOper_Sheet1.Columns.Get(6).CellType = comboBoxCellType2;
            this.spdOper_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdOper_Sheet1.Columns.Get(6).Label = "Override";
            this.spdOper_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOper_Sheet1.Columns.Get(6).Width = 70F;
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
            this.spdFO.ButtonDrawMode = FarPoint.Win.Spread.ButtonDrawModes.CurrentRow;
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
            this.spdFO.ButtonClicked += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.spdOper_ButtonClicked);
            this.spdFO.ComboCloseUp += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.spdFO_ComboCloseUp);
            this.spdFO.EditChange += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.spdFO_EditChange);
            this.spdFO.SetActiveViewport(0, -1, -1);
            // 
            // spdFO_Sheet1
            // 
            this.spdFO_Sheet1.Reset();
            spdFO_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdFO_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdFO_Sheet1.ColumnCount = 7;
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
            this.spdFO_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Chart Flag";
            this.spdFO_Sheet1.ColumnHeader.Cells.Get(0, 4).ColumnSpan = 2;
            this.spdFO_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Chart ID";
            this.spdFO_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Override";
            this.spdFO_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdFO_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdFO_Sheet1.ColumnHeader.Rows.Get(0).Height = 18F;
            checkBoxCellType2.BackgroundImage = new FarPoint.Win.Picture(null, FarPoint.Win.RenderStyle.Normal, System.Drawing.Color.Empty, 0, FarPoint.Win.HorizontalAlignment.Center, FarPoint.Win.VerticalAlignment.Center);
            checkBoxCellType2.TextAlign = FarPoint.Win.ButtonTextAlign.TextLeftPictRight;
            this.spdFO_Sheet1.Columns.Get(0).CellType = checkBoxCellType2;
            this.spdFO_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdFO_Sheet1.Columns.Get(0).Label = "Sel";
            this.spdFO_Sheet1.Columns.Get(0).Width = 35F;
            textCellType2.MaxLength = 20;
            this.spdFO_Sheet1.Columns.Get(1).CellType = textCellType2;
            this.spdFO_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdFO_Sheet1.Columns.Get(1).Label = "Operation";
            this.spdFO_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdFO_Sheet1.Columns.Get(1).Width = 130F;
            this.spdFO_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdFO_Sheet1.Columns.Get(2).Label = "Description";
            this.spdFO_Sheet1.Columns.Get(2).Locked = false;
            this.spdFO_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdFO_Sheet1.Columns.Get(2).Width = 180F;
            comboBoxCellType3.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            comboBoxCellType3.Items = new string[] {
        "",
        "Chart",
        "Chart Set"};
            this.spdFO_Sheet1.Columns.Get(3).CellType = comboBoxCellType3;
            this.spdFO_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdFO_Sheet1.Columns.Get(3).Label = "Chart Flag";
            this.spdFO_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdFO_Sheet1.Columns.Get(3).Width = 80F;
            this.spdFO_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdFO_Sheet1.Columns.Get(4).Label = "Chart ID";
            this.spdFO_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdFO_Sheet1.Columns.Get(4).Width = 150F;
            buttonCellType2.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
            buttonCellType2.Text = "...";
            this.spdFO_Sheet1.Columns.Get(5).CellType = buttonCellType2;
            this.spdFO_Sheet1.Columns.Get(5).Resizable = false;
            this.spdFO_Sheet1.Columns.Get(5).Width = 20F;
            comboBoxCellType4.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            comboBoxCellType4.Items = new string[] {
        "",
        "Yes"};
            this.spdFO_Sheet1.Columns.Get(6).CellType = comboBoxCellType4;
            this.spdFO_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdFO_Sheet1.Columns.Get(6).Label = "Override";
            this.spdFO_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdFO_Sheet1.Columns.Get(6).Width = 70F;
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
            this.grpFO.Size = new System.Drawing.Size(722, 47);
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
            this.cdvFlow.Size = new System.Drawing.Size(622, 20);
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
            this.spdMFO.AccessibleDescription = "";
            this.spdMFO.ButtonDrawMode = FarPoint.Win.Spread.ButtonDrawModes.CurrentRow;
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
            this.spdMFO.ButtonClicked += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.spdOper_ButtonClicked);
            this.spdMFO.ComboCloseUp += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.spdMFO_ComboCloseUp);
            this.spdMFO.EditChange += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.spdMFO_EditChange);
            this.spdMFO.SetActiveViewport(0, -1, -1);
            // 
            // spdMFO_Sheet1
            // 
            this.spdMFO_Sheet1.Reset();
            spdMFO_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdMFO_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdMFO_Sheet1.ColumnCount = 9;
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
            this.spdMFO_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Chart Flag";
            this.spdMFO_Sheet1.ColumnHeader.Cells.Get(0, 6).ColumnSpan = 2;
            this.spdMFO_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Chart ID";
            this.spdMFO_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "Override";
            this.spdMFO_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdMFO_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdMFO_Sheet1.ColumnHeader.Rows.Get(0).Height = 18F;
            checkBoxCellType3.BackgroundImage = new FarPoint.Win.Picture(null, FarPoint.Win.RenderStyle.Normal, System.Drawing.Color.Empty, 0, FarPoint.Win.HorizontalAlignment.Center, FarPoint.Win.VerticalAlignment.Center);
            checkBoxCellType3.TextAlign = FarPoint.Win.ButtonTextAlign.TextLeftPictRight;
            this.spdMFO_Sheet1.Columns.Get(0).CellType = checkBoxCellType3;
            this.spdMFO_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdMFO_Sheet1.Columns.Get(0).Label = "Sel";
            this.spdMFO_Sheet1.Columns.Get(0).Width = 35F;
            this.spdMFO_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdMFO_Sheet1.Columns.Get(1).Label = "Flow";
            this.spdMFO_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMFO_Sheet1.Columns.Get(1).Width = 90F;
            this.spdMFO_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdMFO_Sheet1.Columns.Get(2).Label = "Flow Description";
            this.spdMFO_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMFO_Sheet1.Columns.Get(2).Width = 100F;
            textCellType3.MaxLength = 20;
            this.spdMFO_Sheet1.Columns.Get(3).CellType = textCellType3;
            this.spdMFO_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdMFO_Sheet1.Columns.Get(3).Label = "Operation";
            this.spdMFO_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMFO_Sheet1.Columns.Get(3).Width = 75F;
            this.spdMFO_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdMFO_Sheet1.Columns.Get(4).Label = "Oper Description";
            this.spdMFO_Sheet1.Columns.Get(4).Locked = false;
            this.spdMFO_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMFO_Sheet1.Columns.Get(4).Width = 100F;
            comboBoxCellType5.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            comboBoxCellType5.Items = new string[] {
        "",
        "Chart",
        "Chart Set"};
            this.spdMFO_Sheet1.Columns.Get(5).CellType = comboBoxCellType5;
            this.spdMFO_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdMFO_Sheet1.Columns.Get(5).Label = "Chart Flag";
            this.spdMFO_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMFO_Sheet1.Columns.Get(5).Width = 70F;
            this.spdMFO_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdMFO_Sheet1.Columns.Get(6).Label = "Chart ID";
            this.spdMFO_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMFO_Sheet1.Columns.Get(6).Width = 110F;
            buttonCellType3.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
            buttonCellType3.Text = "...";
            this.spdMFO_Sheet1.Columns.Get(7).CellType = buttonCellType3;
            this.spdMFO_Sheet1.Columns.Get(7).Resizable = false;
            this.spdMFO_Sheet1.Columns.Get(7).Width = 20F;
            comboBoxCellType6.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            comboBoxCellType6.Items = new string[] {
        "",
        "Yes"};
            this.spdMFO_Sheet1.Columns.Get(8).CellType = comboBoxCellType6;
            this.spdMFO_Sheet1.Columns.Get(8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdMFO_Sheet1.Columns.Get(8).Label = "Override";
            this.spdMFO_Sheet1.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMFO_Sheet1.Columns.Get(8).Width = 64F;
            this.spdMFO_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdMFO_Sheet1.RowHeader.Columns.Default.Resizable = true;
            this.spdMFO_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdMFO_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
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
            this.cdvMaterial.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvMaterial.LabelText = "Material";
            this.cdvMaterial.ListCond_ExtFactory = "";
            this.cdvMaterial.ListCond_StepMaterial = '1';
            this.cdvMaterial.ListCond_StepVersion = '1';
            this.cdvMaterial.Location = new System.Drawing.Point(6, 19);
            this.cdvMaterial.MaterialEnabled = true;
            this.cdvMaterial.MaterialReadOnly = false;
            this.cdvMaterial.Name = "cdvMaterial";
            this.cdvMaterial.SearchSubItemIndex = 0;
            this.cdvMaterial.SelectedDescIndex = 2;
            this.cdvMaterial.SelectedSubItemIndex = 0;
            this.cdvMaterial.Size = new System.Drawing.Size(710, 20);
            this.cdvMaterial.TabIndex = 0;
            this.cdvMaterial.VersionEnabled = true;
            this.cdvMaterial.VersionReadOnly = false;
            this.cdvMaterial.VisibleColumnHeader = false;
            this.cdvMaterial.VisibleDescription = true;
            this.cdvMaterial.VisibleMaterialButton = true;
            this.cdvMaterial.VisibleVersionButton = true;
            this.cdvMaterial.WidthButton = 20;
            this.cdvMaterial.WidthLabel = 80;
            this.cdvMaterial.WidthMaterialAndVersion = 230;
            this.cdvMaterial.WidthVersion = 50;
            this.cdvMaterial.MaterialSelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvMaterial_MaterialSelectedItemChanged);
            this.cdvMaterial.MaterialButtonPress += new System.EventHandler(this.cdvMaterial_MaterialButtonPress);
            this.cdvMaterial.VersionChanged += new System.EventHandler(this.cdvMaterial_VersionChanged);
            // 
            // frmSPCAttachChartToMFO
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Controls.Add(this.pnlFill);
            this.Controls.Add(this.pnlBottom);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(750, 580);
            this.Name = "frmSPCAttachChartToMFO";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Attach Chart to MFO";
            this.Activated += new System.EventHandler(this.frmSPCAttachChartToMFO_Activated);
            this.Load += new System.EventHandler(this.frmSPCAttachChartToMFO_Load);
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cdvChart)).EndInit();
            this.pnlFill.ResumeLayout(false);
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
        private void ClearData(string ProcStep)
        {
            try
            {
                if (ProcStep == "1")
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
            int i_returnValue = - 1;
            try
            {
                switch (MPCF.Trim(FuncName))
                {
                    case "Update_MFO_Chart_List":
                        
                        
                        if (tabMFO.SelectedIndex == 0)
                        {
                            for (i = 0; i <= spdOper.Sheets[0].RowCount - 1; i++)
                            {
                                if (spdOper.Sheets[0].GetValue(i, 0) != null &&
                                    Convert.ToBoolean(spdOper.Sheets[0].GetValue(i, 0)) == true)
                                {
                                    iChkCnt++;
                                }
                                if (spdOper.Sheets[0].GetValue(i, 0) != null &&
                                    Convert.ToBoolean(spdOper.Sheets[0].GetValue(i, 0)) == true)
                                {
                                    if (MPCF.Trim(spdOper.Sheets[0].GetValue(i, 3)) != "")
                                    {
                                        if (MPCF.Trim(spdOper.Sheets[0].GetValue(i, 4)) == "")
                                        {
                                            MPCF.ShowMsgBox(MPCF.GetMessage(108));
                                            spdOper.Sheets[0].SetActiveCell(i, 4);
                                            return false;
                                        }
                                        if (MPCF.Trim(spdOper.Sheets[0].GetValue(i, 3)) == "Chart Set")
                                        {
                                            i_returnValue = GetAttachChartCount(MPCF.Trim(spdOper.Sheets[0].GetValue(i, 4)));
                                            if (i_returnValue == 0)
                                            {
                                                MPCF.ShowMsgBox(MPCF.GetMessage(242));
                                                spdOper.Sheets[0].SetActiveCell(i, 4);
                                                return false;
                                            }
                                            else if (i_returnValue == - 1)
                                            {
                                                return false;
                                            }
                                        }
                                    }
                                }
                            }
                            
                            if (iChkCnt == 0)
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(133));
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
                                if (spdFO.Sheets[0].GetValue(i, 0) != null &&
                                    Convert.ToBoolean(spdFO.Sheets[0].GetValue(i, 0)) == true)
                                {
                                    if (MPCF.Trim(spdFO.Sheets[0].GetValue(i, 3)) != "")
                                    {
                                        if (MPCF.Trim(spdFO.Sheets[0].GetValue(i, 4)) == "")
                                        {
                                            MPCF.ShowMsgBox(MPCF.GetMessage(108));
                                            spdFO.Sheets[0].SetActiveCell(i, 4);
                                            return false;
                                        }
                                        if (MPCF.Trim(spdFO.Sheets[0].GetValue(i, 3)) == "Chart Set")
                                        {
                                            i_returnValue = GetAttachChartCount(MPCF.Trim(spdFO.Sheets[0].GetValue(i, 4)));
                                            if (i_returnValue == 0)
                                            {
                                                MPCF.ShowMsgBox(MPCF.GetMessage(242));
                                                spdFO.Sheets[0].SetActiveCell(i, 4);
                                                return false;
                                            }
                                            else if (i_returnValue == 0)
                                            {
                                                return false;
                                            }
                                        }
                                    }
                                }
                            }
                            
                            if (iChkCnt == 0)
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(133));
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
                            if (cdvMaterial.CheckValue() == false) return false;
                            
                            for (i = 0; i <= spdMFO.Sheets[0].RowCount - 1; i++)
                            {
                                if (spdMFO.Sheets[0].GetValue(i, 0) != null &&
                                    Convert.ToBoolean(spdMFO.Sheets[0].GetValue(i, 0)) == true)
                                {
                                    iChkCnt++;
                                }
                                if (spdMFO.Sheets[0].GetValue(i, 0) != null &&
                                    Convert.ToBoolean(spdMFO.Sheets[0].GetValue(i, 0)) == true)
                                {
                                    if (MPCF.Trim(spdMFO.Sheets[0].GetValue(i, 5)) != "")
                                    {
                                        if (MPCF.Trim(spdMFO.Sheets[0].GetValue(i, 6)) == "")
                                        {
                                            MPCF.ShowMsgBox(MPCF.GetMessage(108));
                                            spdMFO.Sheets[0].SetActiveCell(i, 6);
                                            return false;
                                        }
                                        if (MPCF.Trim(spdMFO.Sheets[0].GetValue(i, 5)) == "Chart Set")
                                        {
                                            i_returnValue = GetAttachChartCount(MPCF.Trim(spdMFO.Sheets[0].GetValue(i, 6)));
                                            if (i_returnValue == 0)
                                            {
                                                MPCF.ShowMsgBox(MPCF.GetMessage(242));
                                                spdMFO.Sheets[0].SetActiveCell(i, 6);
                                                return false;
                                            }
                                            else if (i_returnValue == - 1)
                                            {
                                                return false;
                                            }
                                        }
                                    }
                                }
                            }
                            
                            if (iChkCnt == 0)
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(133));
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
                        
                    case "View_MFO_Chart_List":
                        
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
        // View_MFO_Chart_List()
        //       - View MFO-Collection Set Relation List
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool View_MFO_Chart_List(char ProcStep, char OptLevel)
        {
            int i;
            int LastRow = 0;

            TRSNode in_node = new TRSNode("View_MFO_Chart_List_In");
            TRSNode out_node;
            ArrayList a_list = new ArrayList();
            try
            {
                ClearData("1");

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;
                in_node.AddChar("OPT_LEVEL", OptLevel);
                in_node.AddString("MAT_ID", "");
                in_node.AddInt("MAT_VER", 0);
                in_node.AddString("FLOW", "");
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
                    out_node = new TRSNode("View_MFO_Chart_List_Out");
                    if (MPCR.CallService("SPC", "SPC_View_MFO_Chart_List", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                     a_list.Add(out_node);
                                        
                    in_node.SetInt("NEXT_SEQ", out_node.GetInt("NEXT_SEQ"));

                } while (in_node.GetInt("NEXT_SEQ") > 0);

                foreach (object obj in a_list)
                {
                    out_node = null;
                    out_node = (TRSNode)obj;
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
                                if (MPCF.Trim(out_node.GetList(0)[i].GetChar("CHART_FLAG")) == "C")
                                {
                                    with_1.SetValue(LastRow, 5, "Chart");
                                }
                                else if (MPCF.Trim(out_node.GetList(0)[i].GetChar("CHART_FLAG")) == "S")
                                {
                                    with_1.SetValue(LastRow, 5, "Chart Set");
                                }
                                else
                                {
                                    with_1.SetValue(LastRow, 5, "");
                                }
                                with_1.SetValue(LastRow, 6, MPCF.Trim(out_node.GetList(0)[i].GetString("CHART_ID")));
                                if (MPCF.Trim(out_node.GetList(0)[i].GetChar("OVR_FLAG")) == "Y")
                                {
                                    with_1.SetValue(LastRow, 8, "Yes");
                                }
                                else
                                {
                                    with_1.SetValue(LastRow, 8, "");
                                }
                                
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
                                if (MPCF.Trim(out_node.GetList(0)[i].GetChar("CHART_FLAG")) == "C")
                                {
                                    with_2.SetValue(LastRow, 3, "Chart");
                                }
                                else if (MPCF.Trim(out_node.GetList(0)[i].GetChar("CHART_FLAG")) == "S")
                                {
                                    with_2.SetValue(LastRow, 3, "Chart Set");
                                }
                                else
                                {
                                    with_2.SetValue(LastRow, 3, "");
                                }
                                with_2.SetValue(LastRow, 4, MPCF.Trim(out_node.GetList(0)[i].GetString("CHART_ID")));
                                if (MPCF.Trim(out_node.GetList(0)[i].GetChar("OVR_FLAG")) == "Y")
                                {
                                    with_2.SetValue(LastRow, 6, "Yes");
                                }
                                else
                                {
                                    with_2.SetValue(LastRow, 6, "");
                                }
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
                                if (MPCF.Trim(out_node.GetList(0)[i].GetChar("CHART_FLAG")) == "C")
                                {
                                    with_3.SetValue(LastRow, 3, "Chart");
                                }
                                else if (MPCF.Trim(out_node.GetList(0)[i].GetChar("CHART_FLAG")) == "S")
                                {
                                    with_3.SetValue(LastRow, 3, "Chart Set");
                                }
                                else
                                {
                                    with_3.SetValue(LastRow, 3, "");
                                }
                                with_3.SetValue(LastRow, 4, MPCF.Trim(out_node.GetList(0)[i].GetString("CHART_ID")));
                                if (MPCF.Trim(out_node.GetList(0)[i].GetChar("OVR_FLAG")) == "Y")
                                {
                                    with_3.SetValue(LastRow, 6, "Yes");
                                }
                                else
                                {
                                    with_3.SetValue(LastRow, 6, "");
                                }
                            }

                            break;
                    }
                    
                }

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
        
        // Update_MFO_Chart_List()
        //       - Attach/Detach Collection Set to MFO
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String : Process Step
        //
        private bool Update_MFO_Chart_List(char ProcStep, char OptLevel)
        {
            int i = 0;
            int iIndex = 0;

            TRSNode in_node = new TRSNode("Update_MFO_Chart_List_In");
            TRSNode out_node = new TRSNode("Cmn_Out");
            
            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;
                in_node.AddChar("OPT_LEVEL", OptLevel);

                iIndex = 0;
                switch (OptLevel)
                {
                    case '1':

                        for (i = 0; i <= spdMFO.Sheets[0].RowCount - 1; i++)
                        {
                            if (spdMFO.Sheets[0].GetValue(i, 0) != null &&
                                Convert.ToBoolean(spdMFO.Sheets[0].GetValue(i, 0)) == true)
                            {
                                iIndex++;
                            }
                        }

                        iIndex = 0;
                        for (i = 0; i <= spdMFO.Sheets[0].RowCount - 1; i++)
                        {
                            if (spdMFO.Sheets[0].GetValue(i, 0) != null &&
                                Convert.ToBoolean(spdMFO.Sheets[0].GetValue(i, 0)) == true)
                            {
                                TRSNode list = in_node.AddNode("COL_LIST");
                                list.AddString("MAT_ID", MPCF.Trim(cdvMaterial.Text));
                                list.AddInt("MAT_VER", cdvMaterial.Version);
                                list.AddString("FLOW", MPCF.Trim(spdMFO.Sheets[0].GetValue(i, 1)));
                                list.AddString("OPER", MPCF.Trim(spdMFO.Sheets[0].GetValue(i, 3)));

                                if (MPCF.Trim(spdMFO.Sheets[0].GetValue(i, 5)) == "Chart")
                                {
                                    list.AddChar("CHART_FLAG", 'C');
                                }
                                else if (MPCF.Trim(spdMFO.Sheets[0].GetValue(i, 5)) == "Chart Set")
                                {
                                    list.AddChar("CHART_FLAG", 'S');
                                }
                                else
                                {
                                    list.AddChar("CHART_FLAG", ' ');
                                }
                                list.AddString("CHART_ID", MPCF.Trim(spdMFO.Sheets[0].GetValue(i, 6)));
                                
                                if (MPCF.Trim(spdMFO.Sheets[0].GetValue(i, 6)) != "")
                                {
                                    list.AddChar("OVR_FLAG", MPCF.Trim(spdMFO.Sheets[0].GetValue(i, 8)) == "" ? ' ' : 'Y');
                                }
                                iIndex++;
                            }
                        }
                        break;
                    case '2':

                        for (i = 0; i <= spdFO.Sheets[0].RowCount - 1; i++)
                        {
                            if (spdFO.Sheets[0].GetValue(i, 0) != null && 
                                Convert.ToBoolean(spdFO.Sheets[0].GetValue(i, 0)) == true)
                            {
                                iIndex++;
                            }
                        }
                        iIndex = 0;
                        for (i = 0; i <= spdFO.Sheets[0].RowCount - 1; i++)
                        {
                            if (spdFO.Sheets[0].GetValue(i, 0) != null &&
                                Convert.ToBoolean(spdFO.Sheets[0].GetValue(i, 0)) == true)
                            {
                                TRSNode list = in_node.AddNode("COL_LIST");
                                list.AddString("FLOW", MPCF.Trim(cdvFlow.Text));
                                list.AddString("OPER", MPCF.Trim(spdFO.Sheets[0].GetValue(i, 1)));
                                
                                if (MPCF.Trim(spdFO.Sheets[0].GetValue(i, 3)) == "Chart")
                                {
                                    list.AddChar("CHART_FLAG", 'C');
                                }
                                else if (MPCF.Trim(spdFO.Sheets[0].GetValue(i, 3)) == "Chart Set")
                                {
                                    list.AddChar("CHART_FLAG", 'S');
                                }
                                else
                                {
                                    list.AddChar("CHART_FLAG", ' ');
                                }
                                list.AddString("CHART_ID", MPCF.Trim(spdFO.Sheets[0].GetValue(i, 4)));
                                if (MPCF.Trim(spdFO.Sheets[0].GetValue(i, 4)) != "")
                                {
                                    list.AddChar("OVR_FLAG", MPCF.Trim(spdFO.Sheets[0].GetValue(i, 6)) == "" ? ' ' : 'Y');
                                }
                                iIndex++;
                            }
                        }
                        break;
                    case '3':

                        for (i = 0; i <= spdOper.Sheets[0].RowCount - 1; i++)
                        {
                            if (spdOper.Sheets[0].GetValue(i, 0) != null &&
                                Convert.ToBoolean(spdOper.Sheets[0].GetValue(i, 0)) == true)
                            {
                                iIndex++;
                            }
                        }

                        iIndex = 0;
                        for (i = 0; i <= spdOper.Sheets[0].RowCount - 1; i++)
                        {
                            if (spdOper.Sheets[0].GetValue(i, 0) != null &&
                                Convert.ToBoolean(spdOper.Sheets[0].GetValue(i, 0)) == true)
                            {
                                TRSNode list = in_node.AddNode("COL_LIST");
                                list.AddString("OPER", MPCF.Trim(spdOper.Sheets[0].GetValue(i, 1)));
                                if (MPCF.Trim(spdOper.Sheets[0].GetValue(i, 3)) == "Chart")
                                {
                                    list.AddChar("CHART_FLAG", 'C');
                                }
                                else if (MPCF.Trim(spdOper.Sheets[0].GetValue(i, 3)) == "Chart Set")
                                {
                                    list.AddChar("CHART_FLAG", 'S');
                                }
                                else
                                {
                                    list.AddChar("CHART_FLAG", ' ');
                                }
                                list.AddString("CHART_ID", MPCF.Trim(spdOper.Sheets[0].GetValue(i, 4)));
                                if (MPCF.Trim(spdOper.Sheets[0].GetValue(i, 4)) != "")
                                {
                                    list.AddChar("OVR_FLAG", MPCF.Trim(spdOper.Sheets[0].GetValue(i, 6)) == "" ? ' ' : 'Y');
                                }
                                iIndex++;
                            }
                        }
                        break;
                }
                if (MPCR.CallService("SPC", "SPC_Update_MFO_Chart_List", in_node, ref out_node) == false)
                {
                    return false;
                }
                MPCR.ShowSuccessMsg(out_node);
                
                View_MFO_Chart_List('1', OptLevel);
                
                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
            
        }
        
        // GetAttachChartCount()
        //       - Get Attach Chart Count
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal sChartSetID As String : Chart Set ID
        //
        private int GetAttachChartCount(string sChartSetID)
        {
            
            try
            {
                TRSNode in_node = new TRSNode("View_Attach_Chart_Set_List_In");
                TRSNode out_node = new TRSNode("View_Attach_Chart_Set_List_Out"); 

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("CHART_SET_ID", sChartSetID);
                in_node.AddString("NEXT_CHART_ID", "");

                if (MPCR.CallService("SPC", "SPC_View_Attach_Chart_Set_List", in_node, ref out_node) == false)
                {
                    return -1;
                }

                return out_node.GetList(0).Count;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCAttachChartToMFO.GetAttachChartCount()\n" + ex.Message);
                return - 1;
            }
            
        }
        #endregion
        
        private void frmSPCAttachChartToMFO_Activated(object sender, System.EventArgs e)
        {
            try
            {
                if (LoadFlag == false)
                {
                    tabMFO.SelectedIndex = 0;
                    
                    
                    if (View_MFO_Chart_List('1', '3') == false)
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
                if (CheckCondition("Update_MFO_Chart_List", MPGC.MP_STEP_UPDATE) == true)
                {
                    if (tabMFO.SelectedIndex == 0)
                    {
                        Update_MFO_Chart_List(MPGC.MP_STEP_UPDATE, '3');
                    }
                    else if (tabMFO.SelectedIndex == 1)
                    {
                        Update_MFO_Chart_List(MPGC.MP_STEP_UPDATE, '2');
                    }
                    else if (tabMFO.SelectedIndex == 2)
                    {
                        Update_MFO_Chart_List(MPGC.MP_STEP_UPDATE, '1');
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        
        private void frmSPCAttachChartToMFO_Load(System.Object sender, System.EventArgs e)
        {
            try
            {
                MPGV.gIBaseFormEvent.Form_Load(this, e);
                
                cdvFlow.Init();
                MPCF.InitListView(cdvFlow.GetListView);
                cdvFlow.Columns.Add("Flow", 100, HorizontalAlignment.Left);
                cdvFlow.Columns.Add("Desc", 200, HorizontalAlignment.Left);
                cdvFlow.SelectedSubItemIndex = 0;
                cdvFlow.DisplaySubItemIndex = 0;
                cdvFlow.SelectedDescIndex = 1;
                cdvFlow.ReadOnly = true;
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
                cdvFlow.DescText = "";
            }
            else
            {
                View_MFO_Chart_List('1', '2');
            }
        }
        
    
        private void cdvFlow_ButtonPress(object sender, System.EventArgs e)
        {
            WIPLIST.ViewFlowList(cdvFlow.GetListView, '1', "", 0, "", null, "");
        }
        
        
        private void spdOper_EditChange(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            if (e.Column > 0 && e.Row >= 0)
            {
                spdOper.Sheets[0].SetValue(e.Row, 0, true);
            }
        }
        
        private void spdFO_EditChange(System.Object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            if (e.Column > 0 && e.Row >= 0)
            {
                spdFO.Sheets[0].SetValue(e.Row, 0, true);
            }
        }
        
        private void spdMFO_EditChange(System.Object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            if (e.Column > 0 && e.Row >= 0)
            {
                spdMFO.Sheets[0].SetValue(e.Row, 0, true);
            }
        }
        
        private void spdMFO_ComboCloseUp(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            try
            {
                if (e.Column == 5)
                {
                    spdMFO.Sheets[0].Cells[e.Row, 6].Value = "";
                    spdMFO.Sheets[0].Cells[e.Row, 8].Value = "";
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        
        private void spdOper_ComboCloseUp(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            try
            {
                if (e.Column == 3)
                {
                    spdOper.Sheets[0].Cells[e.Row, 4].Value = "";
                    spdOper.Sheets[0].Cells[e.Row, 6].Value = "";
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        
        private void spdFO_ComboCloseUp(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            try
            {
                if (e.Column == 3)
                {
                    spdFO.Sheets[0].Cells[e.Row, 4].Value = "";
                    spdFO.Sheets[0].Cells[e.Row, 6].Value = "";
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        
        private void btnClose_Click(object sender, System.EventArgs e)
        {
            
            try
            {
                this.Dispose();
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void spdOper_ButtonClicked(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            try
            {
                string sMatID = "";
                int iMatVer = 0;
                string sOper = "";
                string sFlow = "";
                if (tabMFO.SelectedTab == tbpOper)
                {
                    if (e.Column != 5)
                    {
                        return;
                    }
                    sMatID = "";
                    iMatVer = 0;
                    sOper = spdOper.Sheets[0].Cells[e.Row, 1].Text;
                    sFlow = "";
                }
                else if (tabMFO.SelectedTab == tbpFO)
                {
                    if (e.Column != 5)
                    {
                        return;
                    }
                    sMatID = "";
                    iMatVer = 0;
                    sOper = spdFO.Sheets[0].Cells[e.Row, 1].Text;
                    sFlow = cdvFlow.Text;
                }
                else if (tabMFO.SelectedTab == tbpMFO)
                {
                    if (e.Column != 7)
                    {
                        return;
                    }
                    sMatID = cdvMaterial.Text;
                    iMatVer = cdvMaterial.Version;
                    sOper = spdMFO.Sheets[0].Cells[e.Row, 3].Text;
                    sFlow = spdMFO.Sheets[0].Cells[e.Row, 1].Text;
                }
                cdvChart.Init();
                cdvChart.ViewPosition = Control.MousePosition;
                cdvChart.Columns.Add("Table Name", 100, HorizontalAlignment.Left);
                cdvChart.Columns.Add("Table Desc", 100, HorizontalAlignment.Left);
                if (((FarPoint.Win.Spread.FpSpread)(sender)).Sheets[0].Cells[e.Row, e.Column - 2].Text == "Chart")
                {
                    SPCLIST.ViewChartList(cdvChart.GetListView, '4', sMatID,iMatVer, sOper,"","", 'L',' ',"", sFlow,-1,-1,null,"");
                }
                else if (((FarPoint.Win.Spread.FpSpread)(sender)).Sheets[0].Cells[e.Row, e.Column - 2].Text == "Chart Set")
                {
                    SPCLIST.ViewChartSetList(cdvChart.GetListView, '1', "" ,0, "","", 'L', "",-1,-1,"");
                }
                if (cdvChart.Items.Count > 0)
                {
                    cdvChart.AddEmptyRow(1);
                    if (cdvChart.ShowPopupList(e.Row, e.Column) == false)
                    {
                        return;
                    }
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        
        private void cdvChart_SelectedItemChanged(object sender, UI.MCSSCodeViewSelChanged_EventArgs e)
        {
            try
            {
                if (tabMFO.SelectedTab == tbpOper)
                {
                    spdOper.Sheets[0].Cells[e.Row, e.Col - 1].Value = e.SelectedItem.SubItems[0].Text;
                    if (e.Col > 0 && e.Row >= 0)
                    {
                        spdOper.Sheets[0].SetValue(e.Row, 0, true);
                    }
                }
                else if (tabMFO.SelectedTab == tbpFO)
                {
                    spdFO.Sheets[0].Cells[e.Row, e.Col - 1].Value = e.SelectedItem.SubItems[0].Text;
                    if (e.Col > 0 && e.Row >= 0)
                    {
                        spdFO.Sheets[0].SetValue(e.Row, 0, true);
                    }
                }
                else if (tabMFO.SelectedTab == tbpMFO)
                {
                    spdMFO.Sheets[0].Cells[e.Row, e.Col - 1].Value = e.SelectedItem.SubItems[0].Text;
                    if (e.Col > 0 && e.Row >= 0)
                    {
                        spdMFO.Sheets[0].SetValue(e.Row, 0, true);
                    }
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
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
        
        private void btnRefresh_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                if (View_MFO_Chart_List('1', '3') == false)
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
                }
                else if (tabMFO.SelectedTab == this.tbpFO)
                {
                    btnRefresh.Visible = false;
                }
                else if (tabMFO.SelectedTab == this.tbpMFO)
                {
                    btnRefresh.Visible = false;
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvMaterial_MaterialButtonPress(object sender, EventArgs e)
        {
            cdvMaterial.ListCond_StepMaterial = '1';
        }

        private void cdvMaterial_MaterialSelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            if (MPCF.Trim(cdvMaterial.Text) == "")
            {
                cdvMaterial.DescText = "";
                ClearData("1");                
            }
            else
            {
                View_MFO_Chart_List('1', '1');
            }
        }

        private void cdvMaterial_VersionButtonPress(object sender, EventArgs e)
        {

        }

        private void cdvMaterial_VersionChanged(object sender, EventArgs e)
        {
            if (MPCF.Trim(cdvMaterial.Version) == "")
            {
                cdvMaterial.DescText = "";
                ClearData("1");                
            }
            else
            {
                View_MFO_Chart_List('1', '1');
            }
        }
        
    }
    
    //#End If
    
}
