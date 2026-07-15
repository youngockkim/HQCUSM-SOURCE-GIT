
using System.Diagnostics;
using System;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Text;

using Miracom.MsgHandler;
using System.Data;
using Miracom.MESCore;
using Miracom.CliFrx;
using Miracom.TRSCore;

//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmSECSetupFunction.vb
//   Description : Security Function Definition Form
//
//   MES Version : 4.1.0.0
//
//   Function List
//       - ClearData() : Intialize Form Field
//       - CheckCondition : Check the Conditions before Transaction
//       - View_Function() : View Security Function definition
//       - View_Function_List() : View all table list which is included in one factory
//       - Update_Function() : Create/Update/Delete Security Function definition
//       - View_User_Group_List() : View all user group list
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2004-06-07 : Created by SKJIN
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------

//Imports


namespace Miracom.SECCore
{
    public class frmSECSetupFunction : Miracom.MESCore.SetupForm02
    {
        
        #region " Windows Form auto generated code "
        
        public frmSECSetupFunction()
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
        private System.Windows.Forms.ColumnHeader ColumnHeader1;
        private System.Windows.Forms.ColumnHeader ColumnHeader2;
        private System.Windows.Forms.GroupBox grbTable;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.Label Label6;
        private System.Windows.Forms.TextBox txtFunc;
        private System.Windows.Forms.Label lblFunc;
        private Miracom.UI.Controls.MCListView.MCListView lisFunc;
        private GroupBox grpFuncGroup;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvGroup;
        private Label lblGroup;
        private TabControl tabCtrl;
        private TabPage tabFunction;
        private TabPage tabExport;
        private GroupBox grpFunction;
        private UI.Controls.MCCodeView.MCCodeView cdvInquiryID;
        private Label lblInquiryID;
        private TextBox txtAssemblyFile;
        private Label lblAssemblyFile;
        private UI.Controls.MCCodeView.MCCodeView cdvIconIndex;
        private ComboBox cboShortKey;
        private CheckBox chkShortSHIFT;
        private Label lblShortCut;
        private CheckBox chkShortALT;
        private CheckBox chkShortCTRL;
        private TextBox txtAssemblyName;
        private Label lblAssemblyName;
        private UI.Controls.MCCodeView.MCCodeView cdvFGroup;
        private Label lblFGroup;
        private Label lblFuncType;
        private TextBox txtUpdateTime;
        private TextBox txtCreateTime;
        private TextBox txtUpdateUser;
        private Label lblUpdate;
        private TextBox txtCreateUser;
        private Label lblCreate;
        private ComboBox cboFuncType;
        private TextBox txtHelpUrl;
        private Label Label5;
        private FarPoint.Win.Spread.FpSpread spdFunc;
        private FarPoint.Win.Spread.SheetView spdFunc_Sheet1;
        private GroupBox grpExport;
        private RadioButton rboAllTbl;
        private RadioButton rboGroup;
        private TextBox txtExpFile;
        private Button btnExpFile;
        private Label lblExpFile;
        private Button btnExpCopy;
        private TextBox txtExpFunc;
        private Label lblExpFunction;
        private Button btnExpStop;
        private Button btnExport;
        private Label lblExpGrp;
        private GroupBox grbExportCenter;
        private RichTextBox txtExport;
        private ProgressBar progressBarExport;
        private SaveFileDialog sfdFile;
        private UI.Controls.MCCodeView.MCCodeView cdvExpGrp;
        private RadioButton rboFunc;
        private TextBox txtExpFuncDesc;
        private System.Windows.Forms.Panel pnlFuncName;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            this.lisFunc = new Miracom.UI.Controls.MCListView.MCListView();
            this.ColumnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.grbTable = new System.Windows.Forms.GroupBox();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.Label6 = new System.Windows.Forms.Label();
            this.txtFunc = new System.Windows.Forms.TextBox();
            this.lblFunc = new System.Windows.Forms.Label();
            this.pnlFuncName = new System.Windows.Forms.Panel();
            this.tabCtrl = new System.Windows.Forms.TabControl();
            this.tabFunction = new System.Windows.Forms.TabPage();
            this.spdFunc = new FarPoint.Win.Spread.FpSpread();
            this.spdFunc_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.grpFunction = new System.Windows.Forms.GroupBox();
            this.cdvInquiryID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblInquiryID = new System.Windows.Forms.Label();
            this.txtAssemblyFile = new System.Windows.Forms.TextBox();
            this.lblAssemblyFile = new System.Windows.Forms.Label();
            this.cdvIconIndex = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cboShortKey = new System.Windows.Forms.ComboBox();
            this.chkShortSHIFT = new System.Windows.Forms.CheckBox();
            this.lblShortCut = new System.Windows.Forms.Label();
            this.chkShortALT = new System.Windows.Forms.CheckBox();
            this.chkShortCTRL = new System.Windows.Forms.CheckBox();
            this.txtAssemblyName = new System.Windows.Forms.TextBox();
            this.lblAssemblyName = new System.Windows.Forms.Label();
            this.cdvFGroup = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblFGroup = new System.Windows.Forms.Label();
            this.lblFuncType = new System.Windows.Forms.Label();
            this.txtUpdateTime = new System.Windows.Forms.TextBox();
            this.txtCreateTime = new System.Windows.Forms.TextBox();
            this.txtUpdateUser = new System.Windows.Forms.TextBox();
            this.lblUpdate = new System.Windows.Forms.Label();
            this.txtCreateUser = new System.Windows.Forms.TextBox();
            this.lblCreate = new System.Windows.Forms.Label();
            this.cboFuncType = new System.Windows.Forms.ComboBox();
            this.txtHelpUrl = new System.Windows.Forms.TextBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.tabExport = new System.Windows.Forms.TabPage();
            this.grbExportCenter = new System.Windows.Forms.GroupBox();
            this.txtExport = new System.Windows.Forms.RichTextBox();
            this.progressBarExport = new System.Windows.Forms.ProgressBar();
            this.grpExport = new System.Windows.Forms.GroupBox();
            this.txtExpFuncDesc = new System.Windows.Forms.TextBox();
            this.rboFunc = new System.Windows.Forms.RadioButton();
            this.cdvExpGrp = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.rboAllTbl = new System.Windows.Forms.RadioButton();
            this.rboGroup = new System.Windows.Forms.RadioButton();
            this.txtExpFile = new System.Windows.Forms.TextBox();
            this.btnExpFile = new System.Windows.Forms.Button();
            this.lblExpFile = new System.Windows.Forms.Label();
            this.btnExpCopy = new System.Windows.Forms.Button();
            this.txtExpFunc = new System.Windows.Forms.TextBox();
            this.lblExpFunction = new System.Windows.Forms.Label();
            this.btnExpStop = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.lblExpGrp = new System.Windows.Forms.Label();
            this.grpFuncGroup = new System.Windows.Forms.GroupBox();
            this.cdvGroup = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblGroup = new System.Windows.Forms.Label();
            this.sfdFile = new System.Windows.Forms.SaveFileDialog();
            this.pnlFind.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.grpFilter.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.grbTable.SuspendLayout();
            this.pnlFuncName.SuspendLayout();
            this.tabCtrl.SuspendLayout();
            this.tabFunction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdFunc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdFunc_Sheet1)).BeginInit();
            this.grpFunction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvInquiryID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvIconIndex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvFGroup)).BeginInit();
            this.tabExport.SuspendLayout();
            this.grbExportCenter.SuspendLayout();
            this.grpExport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvExpGrp)).BeginInit();
            this.grpFuncGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlFind
            // 
            this.pnlFind.TabIndex = 4;
            // 
            // btnExcel
            // 
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnNext
            // 
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // txtFind
            // 
            this.txtFind.TextChanged += new System.EventHandler(this.txtFind_TextChanged);
            // 
            // splMain
            // 
            this.splMain.TabIndex = 1;
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.pnlFuncName);
            this.pnlRight.Controls.Add(this.grbTable);
            this.pnlRight.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.lisFunc);
            this.pnlLeft.Controls.Add(this.grpFuncGroup);
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Padding = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.pnlLeft.Size = new System.Drawing.Size(232, 506);
            // 
            // btnCreate
            // 
            this.btnCreate.TabIndex = 0;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnClose
            // 
            this.btnClose.TabIndex = 3;
            // 
            // pnlBottom
            // 
            this.pnlBottom.TabIndex = 2;
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "Function Setup";
            // 
            // lisFunc
            // 
            this.lisFunc.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader1,
            this.ColumnHeader2});
            this.lisFunc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisFunc.EnableSort = true;
            this.lisFunc.EnableSortIcon = true;
            this.lisFunc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisFunc.FullRowSelect = true;
            this.lisFunc.HideSelection = false;
            this.lisFunc.Location = new System.Drawing.Point(3, 39);
            this.lisFunc.MultiSelect = false;
            this.lisFunc.Name = "lisFunc";
            this.lisFunc.Size = new System.Drawing.Size(229, 464);
            this.lisFunc.TabIndex = 1;
            this.lisFunc.UseCompatibleStateImageBehavior = false;
            this.lisFunc.View = System.Windows.Forms.View.Details;
            this.lisFunc.SelectedIndexChanged += new System.EventHandler(this.lisFunc_SelectedIndexChanged);
            // 
            // ColumnHeader1
            // 
            this.ColumnHeader1.Text = "Function";
            this.ColumnHeader1.Width = 100;
            // 
            // ColumnHeader2
            // 
            this.ColumnHeader2.Text = "Description";
            this.ColumnHeader2.Width = 300;
            // 
            // grbTable
            // 
            this.grbTable.Controls.Add(this.txtDesc);
            this.grbTable.Controls.Add(this.Label6);
            this.grbTable.Controls.Add(this.txtFunc);
            this.grbTable.Controls.Add(this.lblFunc);
            this.grbTable.Dock = System.Windows.Forms.DockStyle.Top;
            this.grbTable.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grbTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbTable.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grbTable.Location = new System.Drawing.Point(3, 0);
            this.grbTable.Name = "grbTable";
            this.grbTable.Size = new System.Drawing.Size(500, 65);
            this.grbTable.TabIndex = 0;
            this.grbTable.TabStop = false;
            // 
            // txtDesc
            // 
            this.txtDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesc.Location = new System.Drawing.Point(120, 38);
            this.txtDesc.MaxLength = 200;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(355, 20);
            this.txtDesc.TabIndex = 3;
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label6.Location = new System.Drawing.Point(16, 41);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(60, 13);
            this.Label6.TabIndex = 2;
            this.Label6.Text = "Description";
            this.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtFunc
            // 
            this.txtFunc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFunc.Location = new System.Drawing.Point(120, 14);
            this.txtFunc.MaxLength = 12;
            this.txtFunc.Name = "txtFunc";
            this.txtFunc.Size = new System.Drawing.Size(177, 20);
            this.txtFunc.TabIndex = 1;
            // 
            // lblFunc
            // 
            this.lblFunc.AutoSize = true;
            this.lblFunc.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblFunc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFunc.Location = new System.Drawing.Point(15, 17);
            this.lblFunc.Name = "lblFunc";
            this.lblFunc.Size = new System.Drawing.Size(92, 13);
            this.lblFunc.TabIndex = 0;
            this.lblFunc.Text = "Function Name";
            this.lblFunc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlFuncName
            // 
            this.pnlFuncName.Controls.Add(this.tabCtrl);
            this.pnlFuncName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFuncName.Location = new System.Drawing.Point(3, 65);
            this.pnlFuncName.Name = "pnlFuncName";
            this.pnlFuncName.Size = new System.Drawing.Size(500, 438);
            this.pnlFuncName.TabIndex = 1;
            // 
            // tabCtrl
            // 
            this.tabCtrl.Controls.Add(this.tabFunction);
            this.tabCtrl.Controls.Add(this.tabExport);
            this.tabCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabCtrl.Location = new System.Drawing.Point(0, 0);
            this.tabCtrl.Name = "tabCtrl";
            this.tabCtrl.SelectedIndex = 0;
            this.tabCtrl.Size = new System.Drawing.Size(500, 438);
            this.tabCtrl.TabIndex = 0;
            // 
            // tabFunction
            // 
            this.tabFunction.BackColor = System.Drawing.SystemColors.Control;
            this.tabFunction.Controls.Add(this.spdFunc);
            this.tabFunction.Controls.Add(this.grpFunction);
            this.tabFunction.Location = new System.Drawing.Point(4, 22);
            this.tabFunction.Name = "tabFunction";
            this.tabFunction.Padding = new System.Windows.Forms.Padding(3);
            this.tabFunction.Size = new System.Drawing.Size(492, 412);
            this.tabFunction.TabIndex = 0;
            this.tabFunction.Text = "Function";
            // 
            // spdFunc
            // 
            this.spdFunc.AccessibleDescription = "";
            this.spdFunc.BackColor = System.Drawing.Color.White;
            this.spdFunc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdFunc.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdFunc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdFunc.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdFunc.HorizontalScrollBar.Name = "";
            this.spdFunc.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdFunc.HorizontalScrollBar.TabIndex = 2;
            this.spdFunc.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdFunc.Location = new System.Drawing.Point(3, 236);
            this.spdFunc.Name = "spdFunc";
            this.spdFunc.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdFunc.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdFunc.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdFunc_Sheet1});
            this.spdFunc.Size = new System.Drawing.Size(486, 173);
            this.spdFunc.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdFunc.TabIndex = 3;
            this.spdFunc.TabStop = false;
            this.spdFunc.TextTipDelay = 200;
            this.spdFunc.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdFunc.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdFunc.VerticalScrollBar.Name = "";
            this.spdFunc.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdFunc.VerticalScrollBar.TabIndex = 3;
            this.spdFunc.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            // 
            // spdFunc_Sheet1
            // 
            this.spdFunc_Sheet1.Reset();
            spdFunc_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdFunc_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdFunc_Sheet1.ColumnCount = 3;
            spdFunc_Sheet1.RowCount = 10;
            this.spdFunc_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdFunc_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdFunc_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdFunc_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdFunc_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Control name";
            this.spdFunc_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Tab page name";
            this.spdFunc_Sheet1.ColumnHeader.Cells.Get(0, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdFunc_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Option name";
            this.spdFunc_Sheet1.ColumnHeader.Cells.Get(0, 2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdFunc_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdFunc_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdFunc_Sheet1.ColumnHeader.Rows.Get(0).Height = 18F;
            this.spdFunc_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdFunc_Sheet1.Columns.Get(0).Label = "Control name";
            this.spdFunc_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdFunc_Sheet1.Columns.Get(0).Width = 151F;
            this.spdFunc_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdFunc_Sheet1.Columns.Get(1).Label = "Tab page name";
            this.spdFunc_Sheet1.Columns.Get(1).Locked = false;
            this.spdFunc_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdFunc_Sheet1.Columns.Get(1).Width = 151F;
            this.spdFunc_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdFunc_Sheet1.Columns.Get(2).Label = "Option name";
            this.spdFunc_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdFunc_Sheet1.Columns.Get(2).Width = 151F;
            this.spdFunc_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdFunc_Sheet1.RowHeader.Columns.Default.Resizable = true;
            this.spdFunc_Sheet1.RowHeader.Columns.Get(0).Width = 34F;
            this.spdFunc_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdFunc_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdFunc_Sheet1.Rows.Get(0).Height = 18F;
            this.spdFunc_Sheet1.Rows.Get(1).Height = 18F;
            this.spdFunc_Sheet1.Rows.Get(2).Height = 18F;
            this.spdFunc_Sheet1.Rows.Get(3).Height = 18F;
            this.spdFunc_Sheet1.Rows.Get(4).Height = 18F;
            this.spdFunc_Sheet1.Rows.Get(5).Height = 18F;
            this.spdFunc_Sheet1.Rows.Get(6).Height = 18F;
            this.spdFunc_Sheet1.Rows.Get(7).Height = 18F;
            this.spdFunc_Sheet1.Rows.Get(8).Height = 18F;
            this.spdFunc_Sheet1.Rows.Get(9).Height = 18F;
            this.spdFunc_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdFunc_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdFunc_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // grpFunction
            // 
            this.grpFunction.Controls.Add(this.cdvInquiryID);
            this.grpFunction.Controls.Add(this.lblInquiryID);
            this.grpFunction.Controls.Add(this.txtAssemblyFile);
            this.grpFunction.Controls.Add(this.lblAssemblyFile);
            this.grpFunction.Controls.Add(this.cdvIconIndex);
            this.grpFunction.Controls.Add(this.cboShortKey);
            this.grpFunction.Controls.Add(this.chkShortSHIFT);
            this.grpFunction.Controls.Add(this.lblShortCut);
            this.grpFunction.Controls.Add(this.chkShortALT);
            this.grpFunction.Controls.Add(this.chkShortCTRL);
            this.grpFunction.Controls.Add(this.txtAssemblyName);
            this.grpFunction.Controls.Add(this.lblAssemblyName);
            this.grpFunction.Controls.Add(this.cdvFGroup);
            this.grpFunction.Controls.Add(this.lblFGroup);
            this.grpFunction.Controls.Add(this.lblFuncType);
            this.grpFunction.Controls.Add(this.txtUpdateTime);
            this.grpFunction.Controls.Add(this.txtCreateTime);
            this.grpFunction.Controls.Add(this.txtUpdateUser);
            this.grpFunction.Controls.Add(this.lblUpdate);
            this.grpFunction.Controls.Add(this.txtCreateUser);
            this.grpFunction.Controls.Add(this.lblCreate);
            this.grpFunction.Controls.Add(this.cboFuncType);
            this.grpFunction.Controls.Add(this.txtHelpUrl);
            this.grpFunction.Controls.Add(this.Label5);
            this.grpFunction.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpFunction.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpFunction.Location = new System.Drawing.Point(3, 3);
            this.grpFunction.Name = "grpFunction";
            this.grpFunction.Size = new System.Drawing.Size(486, 233);
            this.grpFunction.TabIndex = 2;
            this.grpFunction.TabStop = false;
            // 
            // cdvInquiryID
            // 
            this.cdvInquiryID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cdvInquiryID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvInquiryID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvInquiryID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvInquiryID.BtnToolTipText = "";
            this.cdvInquiryID.ButtonWidth = 20;
            this.cdvInquiryID.DescText = "";
            this.cdvInquiryID.DisplaySubItemIndex = -1;
            this.cdvInquiryID.DisplayText = "";
            this.cdvInquiryID.Enabled = false;
            this.cdvInquiryID.Focusing = null;
            this.cdvInquiryID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvInquiryID.Index = 0;
            this.cdvInquiryID.IsViewBtnImage = false;
            this.cdvInquiryID.Location = new System.Drawing.Point(120, 158);
            this.cdvInquiryID.MaxLength = 30;
            this.cdvInquiryID.MCViewStyle.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvInquiryID.MCViewStyle.BorderHotColor = System.Drawing.Color.Black;
            this.cdvInquiryID.MultiSelect = false;
            this.cdvInquiryID.Name = "cdvInquiryID";
            this.cdvInquiryID.ReadOnly = false;
            this.cdvInquiryID.SameWidthHeightOfButton = false;
            this.cdvInquiryID.SearchSubItemIndex = 0;
            this.cdvInquiryID.SelectedDescIndex = -1;
            this.cdvInquiryID.SelectedDescToQueryText = "";
            this.cdvInquiryID.SelectedSubItemIndex = -1;
            this.cdvInquiryID.SelectedValueToQueryText = "";
            this.cdvInquiryID.SelectionStart = 0;
            this.cdvInquiryID.Size = new System.Drawing.Size(348, 20);
            this.cdvInquiryID.SmallImageList = null;
            this.cdvInquiryID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvInquiryID.TabIndex = 18;
            this.cdvInquiryID.TextBoxToolTipText = "";
            this.cdvInquiryID.TextBoxWidth = 170;
            this.cdvInquiryID.VisibleButton = true;
            this.cdvInquiryID.VisibleColumnHeader = false;
            this.cdvInquiryID.VisibleDescription = true;
            this.cdvInquiryID.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvInquiryID_SelectedItemChanged);
            this.cdvInquiryID.ButtonPress += new System.EventHandler(this.cdvInquiryID_ButtonPress);
            // 
            // lblInquiryID
            // 
            this.lblInquiryID.AutoSize = true;
            this.lblInquiryID.Enabled = false;
            this.lblInquiryID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblInquiryID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInquiryID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblInquiryID.Location = new System.Drawing.Point(16, 161);
            this.lblInquiryID.Name = "lblInquiryID";
            this.lblInquiryID.Size = new System.Drawing.Size(52, 13);
            this.lblInquiryID.TabIndex = 17;
            this.lblInquiryID.Text = "Inquiry ID";
            // 
            // txtAssemblyFile
            // 
            this.txtAssemblyFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAssemblyFile.Location = new System.Drawing.Point(120, 60);
            this.txtAssemblyFile.MaxLength = 100;
            this.txtAssemblyFile.Name = "txtAssemblyFile";
            this.txtAssemblyFile.Size = new System.Drawing.Size(348, 20);
            this.txtAssemblyFile.TabIndex = 6;
            // 
            // lblAssemblyFile
            // 
            this.lblAssemblyFile.AutoSize = true;
            this.lblAssemblyFile.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAssemblyFile.Location = new System.Drawing.Point(16, 63);
            this.lblAssemblyFile.Name = "lblAssemblyFile";
            this.lblAssemblyFile.Size = new System.Drawing.Size(70, 13);
            this.lblAssemblyFile.TabIndex = 5;
            this.lblAssemblyFile.Text = "Assembly File";
            this.lblAssemblyFile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cdvIconIndex
            // 
            this.cdvIconIndex.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvIconIndex.BorderHotColor = System.Drawing.Color.Black;
            this.cdvIconIndex.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvIconIndex.BtnToolTipText = "";
            this.cdvIconIndex.ButtonWidth = 20;
            this.cdvIconIndex.DescText = "";
            this.cdvIconIndex.DisplaySubItemIndex = -1;
            this.cdvIconIndex.DisplayText = "";
            this.cdvIconIndex.Focusing = null;
            this.cdvIconIndex.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvIconIndex.Index = 0;
            this.cdvIconIndex.IsViewBtnImage = false;
            this.cdvIconIndex.Location = new System.Drawing.Point(398, 108);
            this.cdvIconIndex.MaxLength = 20;
            this.cdvIconIndex.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvIconIndex.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvIconIndex.MultiSelect = false;
            this.cdvIconIndex.Name = "cdvIconIndex";
            this.cdvIconIndex.ReadOnly = false;
            this.cdvIconIndex.SameWidthHeightOfButton = false;
            this.cdvIconIndex.SearchSubItemIndex = 0;
            this.cdvIconIndex.SelectedDescIndex = -1;
            this.cdvIconIndex.SelectedDescToQueryText = "";
            this.cdvIconIndex.SelectedSubItemIndex = -1;
            this.cdvIconIndex.SelectedValueToQueryText = "";
            this.cdvIconIndex.SelectionStart = 0;
            this.cdvIconIndex.Size = new System.Drawing.Size(70, 20);
            this.cdvIconIndex.SmallImageList = null;
            this.cdvIconIndex.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvIconIndex.TabIndex = 14;
            this.cdvIconIndex.TextBoxToolTipText = "";
            this.cdvIconIndex.TextBoxWidth = 70;
            this.cdvIconIndex.VisibleButton = true;
            this.cdvIconIndex.VisibleColumnHeader = false;
            this.cdvIconIndex.VisibleDescription = false;
            // 
            // cboShortKey
            // 
            this.cboShortKey.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboShortKey.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboShortKey.Items.AddRange(new object[] {
            "",
            "F1",
            "F2",
            "F3",
            "F4",
            "F5",
            "F6",
            "F7",
            "F8",
            "F9",
            "F10",
            "F11",
            "F12",
            "A",
            "B",
            "C",
            "D",
            "E",
            "F",
            "G",
            "H",
            "I",
            "J",
            "K",
            "L",
            "M",
            "N",
            "O",
            "P",
            "Q",
            "R",
            "S",
            "T",
            "U",
            "V",
            "W",
            "X",
            "Y",
            "Z",
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.cboShortKey.Location = new System.Drawing.Point(291, 108);
            this.cboShortKey.MaxDropDownItems = 10;
            this.cboShortKey.Name = "cboShortKey";
            this.cboShortKey.Size = new System.Drawing.Size(101, 21);
            this.cboShortKey.TabIndex = 13;
            this.cboShortKey.SelectedIndexChanged += new System.EventHandler(this.cboShortKey_SelectedIndexChanged);
            // 
            // chkShortSHIFT
            // 
            this.chkShortSHIFT.AutoSize = true;
            this.chkShortSHIFT.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkShortSHIFT.Location = new System.Drawing.Point(228, 110);
            this.chkShortSHIFT.Name = "chkShortSHIFT";
            this.chkShortSHIFT.Size = new System.Drawing.Size(63, 18);
            this.chkShortSHIFT.TabIndex = 12;
            this.chkShortSHIFT.Text = "SHIFT";
            // 
            // lblShortCut
            // 
            this.lblShortCut.AutoSize = true;
            this.lblShortCut.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblShortCut.Location = new System.Drawing.Point(16, 113);
            this.lblShortCut.Name = "lblShortCut";
            this.lblShortCut.Size = new System.Drawing.Size(80, 13);
            this.lblShortCut.TabIndex = 9;
            this.lblShortCut.Text = "Short Cut/ Icon";
            this.lblShortCut.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkShortALT
            // 
            this.chkShortALT.AutoSize = true;
            this.chkShortALT.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkShortALT.Location = new System.Drawing.Point(180, 110);
            this.chkShortALT.Name = "chkShortALT";
            this.chkShortALT.Size = new System.Drawing.Size(52, 18);
            this.chkShortALT.TabIndex = 11;
            this.chkShortALT.Text = "ALT";
            // 
            // chkShortCTRL
            // 
            this.chkShortCTRL.AutoSize = true;
            this.chkShortCTRL.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkShortCTRL.Location = new System.Drawing.Point(120, 110);
            this.chkShortCTRL.Name = "chkShortCTRL";
            this.chkShortCTRL.Size = new System.Drawing.Size(60, 18);
            this.chkShortCTRL.TabIndex = 10;
            this.chkShortCTRL.Text = "CTRL";
            // 
            // txtAssemblyName
            // 
            this.txtAssemblyName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAssemblyName.Location = new System.Drawing.Point(120, 84);
            this.txtAssemblyName.MaxLength = 100;
            this.txtAssemblyName.Name = "txtAssemblyName";
            this.txtAssemblyName.Size = new System.Drawing.Size(348, 20);
            this.txtAssemblyName.TabIndex = 8;
            this.txtAssemblyName.TextChanged += new System.EventHandler(this.txtAssemblyName_TextChanged);
            // 
            // lblAssemblyName
            // 
            this.lblAssemblyName.AutoSize = true;
            this.lblAssemblyName.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAssemblyName.Location = new System.Drawing.Point(16, 87);
            this.lblAssemblyName.Name = "lblAssemblyName";
            this.lblAssemblyName.Size = new System.Drawing.Size(82, 13);
            this.lblAssemblyName.TabIndex = 7;
            this.lblAssemblyName.Text = "Assembly Name";
            this.lblAssemblyName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cdvFGroup
            // 
            this.cdvFGroup.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvFGroup.BorderHotColor = System.Drawing.Color.Black;
            this.cdvFGroup.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvFGroup.BtnToolTipText = "";
            this.cdvFGroup.ButtonWidth = 20;
            this.cdvFGroup.DescText = "";
            this.cdvFGroup.DisplaySubItemIndex = -1;
            this.cdvFGroup.DisplayText = "";
            this.cdvFGroup.Focusing = null;
            this.cdvFGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvFGroup.Index = 0;
            this.cdvFGroup.IsViewBtnImage = false;
            this.cdvFGroup.Location = new System.Drawing.Point(120, 11);
            this.cdvFGroup.MaxLength = 20;
            this.cdvFGroup.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvFGroup.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvFGroup.MultiSelect = false;
            this.cdvFGroup.Name = "cdvFGroup";
            this.cdvFGroup.ReadOnly = false;
            this.cdvFGroup.SameWidthHeightOfButton = false;
            this.cdvFGroup.SearchSubItemIndex = 0;
            this.cdvFGroup.SelectedDescIndex = -1;
            this.cdvFGroup.SelectedDescToQueryText = "";
            this.cdvFGroup.SelectedSubItemIndex = -1;
            this.cdvFGroup.SelectedValueToQueryText = "";
            this.cdvFGroup.SelectionStart = 0;
            this.cdvFGroup.Size = new System.Drawing.Size(170, 20);
            this.cdvFGroup.SmallImageList = null;
            this.cdvFGroup.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvFGroup.TabIndex = 1;
            this.cdvFGroup.TextBoxToolTipText = "";
            this.cdvFGroup.TextBoxWidth = 170;
            this.cdvFGroup.VisibleButton = true;
            this.cdvFGroup.VisibleColumnHeader = false;
            this.cdvFGroup.VisibleDescription = false;
            this.cdvFGroup.ButtonPress += new System.EventHandler(this.cdvFuncGroup_ButtonPress);
            // 
            // lblFGroup
            // 
            this.lblFGroup.AutoSize = true;
            this.lblFGroup.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblFGroup.Location = new System.Drawing.Point(16, 13);
            this.lblFGroup.Name = "lblFGroup";
            this.lblFGroup.Size = new System.Drawing.Size(80, 13);
            this.lblFGroup.TabIndex = 0;
            this.lblFGroup.Text = "Function Group";
            this.lblFGroup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFuncType
            // 
            this.lblFuncType.AutoSize = true;
            this.lblFuncType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblFuncType.Location = new System.Drawing.Point(16, 38);
            this.lblFuncType.Name = "lblFuncType";
            this.lblFuncType.Size = new System.Drawing.Size(75, 13);
            this.lblFuncType.TabIndex = 2;
            this.lblFuncType.Text = "Function Type";
            this.lblFuncType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtUpdateTime
            // 
            this.txtUpdateTime.Location = new System.Drawing.Point(298, 206);
            this.txtUpdateTime.MaxLength = 30;
            this.txtUpdateTime.Name = "txtUpdateTime";
            this.txtUpdateTime.ReadOnly = true;
            this.txtUpdateTime.Size = new System.Drawing.Size(170, 20);
            this.txtUpdateTime.TabIndex = 24;
            this.txtUpdateTime.TabStop = false;
            // 
            // txtCreateTime
            // 
            this.txtCreateTime.Location = new System.Drawing.Point(298, 181);
            this.txtCreateTime.MaxLength = 30;
            this.txtCreateTime.Name = "txtCreateTime";
            this.txtCreateTime.ReadOnly = true;
            this.txtCreateTime.Size = new System.Drawing.Size(170, 20);
            this.txtCreateTime.TabIndex = 21;
            this.txtCreateTime.TabStop = false;
            // 
            // txtUpdateUser
            // 
            this.txtUpdateUser.Location = new System.Drawing.Point(120, 206);
            this.txtUpdateUser.MaxLength = 20;
            this.txtUpdateUser.Name = "txtUpdateUser";
            this.txtUpdateUser.ReadOnly = true;
            this.txtUpdateUser.Size = new System.Drawing.Size(170, 20);
            this.txtUpdateUser.TabIndex = 23;
            this.txtUpdateUser.TabStop = false;
            // 
            // lblUpdate
            // 
            this.lblUpdate.AutoSize = true;
            this.lblUpdate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUpdate.Location = new System.Drawing.Point(16, 209);
            this.lblUpdate.Name = "lblUpdate";
            this.lblUpdate.Size = new System.Drawing.Size(95, 13);
            this.lblUpdate.TabIndex = 22;
            this.lblUpdate.Text = "Update User/Time";
            this.lblUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCreateUser
            // 
            this.txtCreateUser.Location = new System.Drawing.Point(120, 181);
            this.txtCreateUser.MaxLength = 20;
            this.txtCreateUser.Name = "txtCreateUser";
            this.txtCreateUser.ReadOnly = true;
            this.txtCreateUser.Size = new System.Drawing.Size(170, 20);
            this.txtCreateUser.TabIndex = 20;
            this.txtCreateUser.TabStop = false;
            // 
            // lblCreate
            // 
            this.lblCreate.AutoSize = true;
            this.lblCreate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCreate.Location = new System.Drawing.Point(16, 184);
            this.lblCreate.Name = "lblCreate";
            this.lblCreate.Size = new System.Drawing.Size(91, 13);
            this.lblCreate.TabIndex = 19;
            this.lblCreate.Text = "Create User/Time";
            this.lblCreate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboFuncType
            // 
            this.cboFuncType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFuncType.Items.AddRange(new object[] {
            "Function",
            "Program",
            "Menu"});
            this.cboFuncType.Location = new System.Drawing.Point(120, 35);
            this.cboFuncType.Name = "cboFuncType";
            this.cboFuncType.Size = new System.Drawing.Size(170, 21);
            this.cboFuncType.TabIndex = 3;
            // 
            // txtHelpUrl
            // 
            this.txtHelpUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHelpUrl.Location = new System.Drawing.Point(120, 133);
            this.txtHelpUrl.MaxLength = 100;
            this.txtHelpUrl.Name = "txtHelpUrl";
            this.txtHelpUrl.Size = new System.Drawing.Size(348, 20);
            this.txtHelpUrl.TabIndex = 16;
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Label5.Location = new System.Drawing.Point(16, 136);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(54, 13);
            this.Label5.TabIndex = 15;
            this.Label5.Text = "Help URL";
            this.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabExport
            // 
            this.tabExport.BackColor = System.Drawing.SystemColors.Control;
            this.tabExport.Controls.Add(this.grbExportCenter);
            this.tabExport.Controls.Add(this.grpExport);
            this.tabExport.Location = new System.Drawing.Point(4, 22);
            this.tabExport.Name = "tabExport";
            this.tabExport.Padding = new System.Windows.Forms.Padding(3);
            this.tabExport.Size = new System.Drawing.Size(492, 412);
            this.tabExport.TabIndex = 1;
            this.tabExport.Text = "Export";
            // 
            // grbExportCenter
            // 
            this.grbExportCenter.Controls.Add(this.txtExport);
            this.grbExportCenter.Controls.Add(this.progressBarExport);
            this.grbExportCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbExportCenter.Location = new System.Drawing.Point(3, 123);
            this.grbExportCenter.Name = "grbExportCenter";
            this.grbExportCenter.Size = new System.Drawing.Size(486, 286);
            this.grbExportCenter.TabIndex = 1;
            this.grbExportCenter.TabStop = false;
            // 
            // txtExport
            // 
            this.txtExport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtExport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtExport.Location = new System.Drawing.Point(3, 16);
            this.txtExport.Name = "txtExport";
            this.txtExport.ReadOnly = true;
            this.txtExport.Size = new System.Drawing.Size(480, 244);
            this.txtExport.TabIndex = 0;
            this.txtExport.Text = "";
            this.txtExport.WordWrap = false;
            // 
            // progressBarExport
            // 
            this.progressBarExport.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBarExport.Location = new System.Drawing.Point(3, 260);
            this.progressBarExport.Name = "progressBarExport";
            this.progressBarExport.Size = new System.Drawing.Size(480, 23);
            this.progressBarExport.TabIndex = 1;
            // 
            // grpExport
            // 
            this.grpExport.Controls.Add(this.txtExpFuncDesc);
            this.grpExport.Controls.Add(this.rboFunc);
            this.grpExport.Controls.Add(this.cdvExpGrp);
            this.grpExport.Controls.Add(this.rboAllTbl);
            this.grpExport.Controls.Add(this.rboGroup);
            this.grpExport.Controls.Add(this.txtExpFile);
            this.grpExport.Controls.Add(this.btnExpFile);
            this.grpExport.Controls.Add(this.lblExpFile);
            this.grpExport.Controls.Add(this.btnExpCopy);
            this.grpExport.Controls.Add(this.txtExpFunc);
            this.grpExport.Controls.Add(this.lblExpFunction);
            this.grpExport.Controls.Add(this.btnExpStop);
            this.grpExport.Controls.Add(this.btnExport);
            this.grpExport.Controls.Add(this.lblExpGrp);
            this.grpExport.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpExport.Location = new System.Drawing.Point(3, 3);
            this.grpExport.Name = "grpExport";
            this.grpExport.Size = new System.Drawing.Size(486, 120);
            this.grpExport.TabIndex = 0;
            this.grpExport.TabStop = false;
            this.grpExport.Text = "DB Insert Script Create";
            // 
            // txtExpFuncDesc
            // 
            this.txtExpFuncDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtExpFuncDesc.Location = new System.Drawing.Point(253, 40);
            this.txtExpFuncDesc.MaxLength = 50;
            this.txtExpFuncDesc.Name = "txtExpFuncDesc";
            this.txtExpFuncDesc.ReadOnly = true;
            this.txtExpFuncDesc.Size = new System.Drawing.Size(215, 20);
            this.txtExpFuncDesc.TabIndex = 7;
            // 
            // rboFunc
            // 
            this.rboFunc.AutoSize = true;
            this.rboFunc.Checked = true;
            this.rboFunc.Location = new System.Drawing.Point(255, 19);
            this.rboFunc.Name = "rboFunc";
            this.rboFunc.Size = new System.Drawing.Size(66, 17);
            this.rboFunc.TabIndex = 2;
            this.rboFunc.TabStop = true;
            this.rboFunc.Text = "Function";
            this.rboFunc.UseVisualStyleBackColor = true;
            // 
            // cdvExpGrp
            // 
            this.cdvExpGrp.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvExpGrp.BorderHotColor = System.Drawing.Color.Black;
            this.cdvExpGrp.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvExpGrp.BtnToolTipText = "";
            this.cdvExpGrp.ButtonWidth = 20;
            this.cdvExpGrp.DescText = "";
            this.cdvExpGrp.DisplaySubItemIndex = -1;
            this.cdvExpGrp.DisplayText = "";
            this.cdvExpGrp.Focusing = null;
            this.cdvExpGrp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvExpGrp.Index = 0;
            this.cdvExpGrp.IsViewBtnImage = false;
            this.cdvExpGrp.Location = new System.Drawing.Point(113, 16);
            this.cdvExpGrp.MaxLength = 20;
            this.cdvExpGrp.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvExpGrp.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvExpGrp.MultiSelect = false;
            this.cdvExpGrp.Name = "cdvExpGrp";
            this.cdvExpGrp.ReadOnly = false;
            this.cdvExpGrp.SameWidthHeightOfButton = false;
            this.cdvExpGrp.SearchSubItemIndex = 0;
            this.cdvExpGrp.SelectedDescIndex = -1;
            this.cdvExpGrp.SelectedDescToQueryText = "";
            this.cdvExpGrp.SelectedSubItemIndex = -1;
            this.cdvExpGrp.SelectedValueToQueryText = "";
            this.cdvExpGrp.SelectionStart = 0;
            this.cdvExpGrp.Size = new System.Drawing.Size(136, 20);
            this.cdvExpGrp.SmallImageList = null;
            this.cdvExpGrp.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvExpGrp.TabIndex = 1;
            this.cdvExpGrp.TextBoxToolTipText = "";
            this.cdvExpGrp.TextBoxWidth = 136;
            this.cdvExpGrp.VisibleButton = true;
            this.cdvExpGrp.VisibleColumnHeader = false;
            this.cdvExpGrp.VisibleDescription = false;
            this.cdvExpGrp.ButtonPress += new System.EventHandler(this.cdvFuncGroup_ButtonPress);
            // 
            // rboAllTbl
            // 
            this.rboAllTbl.AutoSize = true;
            this.rboAllTbl.Location = new System.Drawing.Point(405, 18);
            this.rboAllTbl.Name = "rboAllTbl";
            this.rboAllTbl.Size = new System.Drawing.Size(66, 17);
            this.rboAllTbl.TabIndex = 4;
            this.rboAllTbl.Text = "All Table";
            this.rboAllTbl.UseVisualStyleBackColor = true;
            // 
            // rboGroup
            // 
            this.rboGroup.AutoSize = true;
            this.rboGroup.Location = new System.Drawing.Point(338, 18);
            this.rboGroup.Name = "rboGroup";
            this.rboGroup.Size = new System.Drawing.Size(54, 17);
            this.rboGroup.TabIndex = 3;
            this.rboGroup.Text = "Group";
            this.rboGroup.UseVisualStyleBackColor = true;
            // 
            // txtExpFile
            // 
            this.txtExpFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtExpFile.Location = new System.Drawing.Point(113, 64);
            this.txtExpFile.MaxLength = 1000;
            this.txtExpFile.Name = "txtExpFile";
            this.txtExpFile.ReadOnly = true;
            this.txtExpFile.Size = new System.Drawing.Size(332, 20);
            this.txtExpFile.TabIndex = 9;
            // 
            // btnExpFile
            // 
            this.btnExpFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExpFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExpFile.Location = new System.Drawing.Point(447, 63);
            this.btnExpFile.Name = "btnExpFile";
            this.btnExpFile.Size = new System.Drawing.Size(21, 21);
            this.btnExpFile.TabIndex = 10;
            this.btnExpFile.Text = "...";
            this.btnExpFile.Click += new System.EventHandler(this.btnExpFile_Click);
            // 
            // lblExpFile
            // 
            this.lblExpFile.AutoSize = true;
            this.lblExpFile.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblExpFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExpFile.Location = new System.Drawing.Point(17, 68);
            this.lblExpFile.Name = "lblExpFile";
            this.lblExpFile.Size = new System.Drawing.Size(56, 13);
            this.lblExpFile.TabIndex = 8;
            this.lblExpFile.Text = "Export File";
            // 
            // btnExpCopy
            // 
            this.btnExpCopy.Location = new System.Drawing.Point(287, 91);
            this.btnExpCopy.Name = "btnExpCopy";
            this.btnExpCopy.Size = new System.Drawing.Size(75, 23);
            this.btnExpCopy.TabIndex = 13;
            this.btnExpCopy.Text = "Clip Copy";
            this.btnExpCopy.Click += new System.EventHandler(this.btnExpCopy_Click);
            // 
            // txtExpFunc
            // 
            this.txtExpFunc.Location = new System.Drawing.Point(113, 40);
            this.txtExpFunc.MaxLength = 12;
            this.txtExpFunc.Name = "txtExpFunc";
            this.txtExpFunc.ReadOnly = true;
            this.txtExpFunc.Size = new System.Drawing.Size(136, 20);
            this.txtExpFunc.TabIndex = 6;
            // 
            // lblExpFunction
            // 
            this.lblExpFunction.AutoSize = true;
            this.lblExpFunction.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblExpFunction.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExpFunction.Location = new System.Drawing.Point(17, 44);
            this.lblExpFunction.Name = "lblExpFunction";
            this.lblExpFunction.Size = new System.Drawing.Size(79, 13);
            this.lblExpFunction.TabIndex = 5;
            this.lblExpFunction.Text = "Function Name";
            // 
            // btnExpStop
            // 
            this.btnExpStop.Location = new System.Drawing.Point(200, 91);
            this.btnExpStop.Name = "btnExpStop";
            this.btnExpStop.Size = new System.Drawing.Size(75, 23);
            this.btnExpStop.TabIndex = 12;
            this.btnExpStop.Text = "Stop";
            this.btnExpStop.Click += new System.EventHandler(this.btnExpStop_Click);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(113, 91);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 11;
            this.btnExport.Text = "Export";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // lblExpGrp
            // 
            this.lblExpGrp.AutoSize = true;
            this.lblExpGrp.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblExpGrp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExpGrp.Location = new System.Drawing.Point(17, 20);
            this.lblExpGrp.Name = "lblExpGrp";
            this.lblExpGrp.Size = new System.Drawing.Size(36, 13);
            this.lblExpGrp.TabIndex = 0;
            this.lblExpGrp.Text = "Group";
            // 
            // grpFuncGroup
            // 
            this.grpFuncGroup.Controls.Add(this.cdvGroup);
            this.grpFuncGroup.Controls.Add(this.lblGroup);
            this.grpFuncGroup.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpFuncGroup.Location = new System.Drawing.Point(3, 3);
            this.grpFuncGroup.Name = "grpFuncGroup";
            this.grpFuncGroup.Size = new System.Drawing.Size(229, 36);
            this.grpFuncGroup.TabIndex = 0;
            this.grpFuncGroup.TabStop = false;
            // 
            // cdvGroup
            // 
            this.cdvGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cdvGroup.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvGroup.BorderHotColor = System.Drawing.Color.Black;
            this.cdvGroup.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvGroup.BtnToolTipText = "";
            this.cdvGroup.ButtonWidth = 20;
            this.cdvGroup.DescText = "";
            this.cdvGroup.DisplaySubItemIndex = -1;
            this.cdvGroup.DisplayText = "";
            this.cdvGroup.Focusing = null;
            this.cdvGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvGroup.Index = 0;
            this.cdvGroup.IsViewBtnImage = false;
            this.cdvGroup.Location = new System.Drawing.Point(89, 11);
            this.cdvGroup.MaxLength = 20;
            this.cdvGroup.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvGroup.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvGroup.MultiSelect = false;
            this.cdvGroup.Name = "cdvGroup";
            this.cdvGroup.ReadOnly = false;
            this.cdvGroup.SameWidthHeightOfButton = false;
            this.cdvGroup.SearchSubItemIndex = 0;
            this.cdvGroup.SelectedDescIndex = -1;
            this.cdvGroup.SelectedDescToQueryText = "";
            this.cdvGroup.SelectedSubItemIndex = -1;
            this.cdvGroup.SelectedValueToQueryText = "";
            this.cdvGroup.SelectionStart = 0;
            this.cdvGroup.Size = new System.Drawing.Size(136, 20);
            this.cdvGroup.SmallImageList = null;
            this.cdvGroup.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvGroup.TabIndex = 0;
            this.cdvGroup.TextBoxToolTipText = "";
            this.cdvGroup.TextBoxWidth = 136;
            this.cdvGroup.VisibleButton = true;
            this.cdvGroup.VisibleColumnHeader = false;
            this.cdvGroup.VisibleDescription = false;
            this.cdvGroup.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvGroup_SelectedItemChanged);
            this.cdvGroup.ButtonPress += new System.EventHandler(this.cdvFuncGroup_ButtonPress);
            // 
            // lblGroup
            // 
            this.lblGroup.AutoSize = true;
            this.lblGroup.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblGroup.Location = new System.Drawing.Point(6, 13);
            this.lblGroup.Name = "lblGroup";
            this.lblGroup.Size = new System.Drawing.Size(80, 13);
            this.lblGroup.TabIndex = 0;
            this.lblGroup.Text = "Function Group";
            this.lblGroup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmSECSetupFunction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Name = "frmSECSetupFunction";
            this.Text = "Function Setup";
            this.Activated += new System.EventHandler(this.frmSECTBLDEF00_Activated);
            this.Load += new System.EventHandler(this.frmSECSetupFunction_Load);
            this.pnlFind.ResumeLayout(false);
            this.pnlFind.PerformLayout();
            this.pnlRight.ResumeLayout(false);
            this.pnlFilter.ResumeLayout(false);
            this.grpFilter.ResumeLayout(false);
            this.grpFilter.PerformLayout();
            this.pnlLeft.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.grbTable.ResumeLayout(false);
            this.grbTable.PerformLayout();
            this.pnlFuncName.ResumeLayout(false);
            this.tabCtrl.ResumeLayout(false);
            this.tabFunction.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdFunc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdFunc_Sheet1)).EndInit();
            this.grpFunction.ResumeLayout(false);
            this.grpFunction.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvInquiryID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvIconIndex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvFGroup)).EndInit();
            this.tabExport.ResumeLayout(false);
            this.grbExportCenter.ResumeLayout(false);
            this.grpExport.ResumeLayout(false);
            this.grpExport.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvExpGrp)).EndInit();
            this.grpFuncGroup.ResumeLayout(false);
            this.grpFuncGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup)).EndInit();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Constant Definition "
        
        private const int CTL_COL = 0;
        private const int TAB_COL = 1;
        private const int OPT_COL = 2;
        private const string FLEXIBLEINQUIRYMENU = "Miracom.BASCore.frmBASViewFlexibleInquiryMenu";        
        //Add by Kelly Jung 
        //Add MFO Option Setup
        private const string MFOMENU = "Miracom.TAPCore.frmTAPSetupMFOMenu";
        //Add by YoungBok Yoon
        //Add MFO Option Setup
        private const string PROCESSMENU = "Miracom.TAPCore.frmTAPSetupProcessControlMenu";
        #endregion
        
        #region " Variable Definition "
        
        private bool b_load_flag;
        private bool b_export_stop = false;
        #endregion
        
        #region " Function Definition "
        
        //
        // ClearData()
        //       - Initalize form fields
        // Return Value
        //       -
        // Arguments
        //       - Optional ByVal ProcStep As String ("1", "2")
        //
        private void ClearData(string ProcStep)
        {
            
            try
            {
                if (ProcStep == "1")
                {
                    MPCF.FieldClear(this);
                }
                else if (ProcStep == "2")
                {
                    txtCreateUser.Text = "";
                    txtCreateTime.Text = "";
                    txtUpdateUser.Text = "";
                    txtUpdateTime.Text = "";
                }
            }
            catch (Exception)
            {
            }
        }

        private void FillIconList()
        {
            int i;
            ListViewItem itm;

            cdvIconIndex.Init();
            MPCF.InitListView(cdvIconIndex.GetListView);
            cdvIconIndex.Columns.Add("Icon Index", 50, HorizontalAlignment.Left);
            cdvIconIndex.SelectedSubItemIndex = 0;
            cdvIconIndex.SmallImageList = MPGV.gIMdiForm.GetToolBarIconList();

            for (i = 0; i < cdvIconIndex.SmallImageList.Images.Count; i++)
            {
                itm = new ListViewItem(i.ToString(), i);
                cdvIconIndex.Items.Add(itm);
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
            int j = 0;
            
            switch (MPCF.Trim(FuncName))
            {
                case "Update_Function":

                    if (MPCF.CheckValue(txtFunc, 1) == false) return false;

                    if (chkShortCTRL.Checked == true || chkShortALT.Checked == true || chkShortSHIFT.Checked == true)
                    {
                        if (MPCF.CheckValue(cboShortKey, 1) == false) return false;
                    }

                    // F1 ~ F12 은 단독으로 선택 가능하지만 그외의 문자는 CTRL, ALT, SHIFT 조합이어야 한다.
                    if (cboShortKey.SelectedIndex > 11)
                    {
                        if (chkShortCTRL.Checked == false && chkShortALT.Checked == false && chkShortSHIFT.Checked == false)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(108));
                            chkShortCTRL.Focus();
                            return false;
                        }
                    }

                    switch (ProcStep)
                    {
                        case MPGC.MP_STEP_CREATE:
                            FarPoint.Win.Spread.SheetView with_1 = spdFunc.Sheets[0];
                            for (i = 0; i <= spdFunc.Sheets[0].RowCount - 1; i++)
                            {
                                for (j = i + 1; j <= spdFunc.Sheets[0].RowCount - 1; j++)
                                {
                                    if (MPCF.Trim(with_1.GetValue(i, CTL_COL)) != "" && MPCF.Trim(with_1.GetValue(i, CTL_COL)) == MPCF.Trim(with_1.GetValue(j, CTL_COL)))
                                    {
                                        MPCF.ShowMsgBox(MPCF.GetMessage(111));
                                        with_1.ActiveColumnIndex = CTL_COL;
                                        with_1.ActiveRowIndex = i;
                                        return false;
                                    }
                                    if (MPCF.Trim(with_1.GetValue(i, TAB_COL)) != "" && MPCF.Trim(with_1.GetValue(i, TAB_COL)) == MPCF.Trim(with_1.GetValue(j, TAB_COL)))
                                    {
                                        MPCF.ShowMsgBox(MPCF.GetMessage(111));
                                        with_1.ActiveColumnIndex = TAB_COL;
                                        with_1.ActiveRowIndex = i;
                                        return false;
                                    }
                                    if (MPCF.Trim(with_1.GetValue(i, OPT_COL)) != "" && MPCF.Trim(with_1.GetValue(i, OPT_COL)) == MPCF.Trim(with_1.GetValue(j, OPT_COL)))
                                    {
                                        MPCF.ShowMsgBox(MPCF.GetMessage(111));
                                        with_1.ActiveColumnIndex = OPT_COL;
                                        with_1.ActiveRowIndex = i;
                                        return false;
                                    }
                                }
                            }

                            //Modify by J.S. 2011.10.14 flexible inquiry 메뉴 통합
                            if (MPCF.Trim(txtAssemblyName.Text) == FLEXIBLEINQUIRYMENU || MPCF.Trim(txtAssemblyName.Text) == MFOMENU || MPCF.Trim(txtAssemblyName.Text) == PROCESSMENU)
                            {
                                cdvInquiryID.Enabled = true;
                                lblInquiryID.Enabled = true;

                                if (MPCF.CheckValue(cdvInquiryID, 1) == false) return false;
                            }
                            break;
                            
                            
                        case MPGC.MP_STEP_UPDATE:
                            
                            FarPoint.Win.Spread.SheetView with_2 = spdFunc.Sheets[0];
                            for (i = 0; i <= spdFunc.Sheets[0].RowCount - 1; i++)
                            {
                                for (j = i + 1; j <= spdFunc.Sheets[0].RowCount - 1; j++)
                                {
                                    if (MPCF.Trim(with_2.GetValue(i, CTL_COL)) != "" && MPCF.Trim(with_2.GetValue(i, CTL_COL)) == MPCF.Trim(with_2.GetValue(j, CTL_COL)))
                                    {
                                        MPCF.ShowMsgBox(MPCF.GetMessage(111));
                                        with_2.ActiveColumnIndex = CTL_COL;
                                        with_2.ActiveRowIndex = i;
                                        return false;
                                    }
                                    if (MPCF.Trim(with_2.GetValue(i, TAB_COL)) != "" && MPCF.Trim(with_2.GetValue(i, TAB_COL)) == MPCF.Trim(with_2.GetValue(j, TAB_COL)))
                                    {
                                        MPCF.ShowMsgBox(MPCF.GetMessage(111));
                                        with_2.ActiveColumnIndex = TAB_COL;
                                        with_2.ActiveRowIndex = i;
                                        return false;
                                    }
                                    if (MPCF.Trim(with_2.GetValue(i, OPT_COL)) != "" && MPCF.Trim(with_2.GetValue(i, OPT_COL)) == MPCF.Trim(with_2.GetValue(j, OPT_COL)))
                                    {
                                        MPCF.ShowMsgBox(MPCF.GetMessage(111));
                                        with_2.ActiveColumnIndex = OPT_COL;
                                        with_2.ActiveRowIndex = i;
                                        return false;
                                    }
                                }
                            }

                            //Modify by J.S. 2011.10.14 flexible inquiry 메뉴 통합
                            if (MPCF.Trim(txtAssemblyName.Text) == FLEXIBLEINQUIRYMENU || MPCF.Trim(txtAssemblyName.Text) == MFOMENU || MPCF.Trim(txtAssemblyName.Text) == PROCESSMENU)
                            {
                                cdvInquiryID.Enabled = true;
                                lblInquiryID.Enabled = true;

                                if (MPCF.CheckValue(cdvInquiryID, 1) == false) return false;
                            }
                            break;
                            
                        case MPGC.MP_STEP_DELETE:
                            
                            break;
                            
                    }
                    break;
                    
            }
            
            return true;
            
        }
        
        //
        // View_Function()
        //       - View General Code Definition
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool View_Function()
        {
            TRSNode in_node = new TRSNode("VIEW_FUNCTION_IN");
            TRSNode out_node = new TRSNode("VIEW_FUNCTION_OUT");
            
            try
            {
                //MPCF.FieldClear(pnlRight);
                MPCF.FieldClear(tabFunction);
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("FUNC_NAME", lisFunc.SelectedItems[0].Text);

                if (MPCR.CallService("SEC", "SEC_View_Function", in_node, ref out_node) == false)
                {
                    return false;
                }

                txtFunc.Text = MPCF.Trim(out_node.GetString("FUNC_NAME"));
                txtDesc.Text = MPCF.Trim(out_node.GetString("FUNC_DESC"));
                cdvFGroup.Text = MPCF.Trim(out_node.GetString("FUNC_GROUP"));
                txtAssemblyFile.Text = MPCF.Trim(out_node.GetString("ASSEMBLY_FILE"));
                txtAssemblyName.Text = MPCF.Trim(out_node.GetString("ASSEMBLY_NAME"));

                if (out_node.GetInt("ICON_INDEX") >= 0)
                    cdvIconIndex.Text = out_node.GetInt("ICON_INDEX").ToString();
                else
                    cdvIconIndex.Text = "";

                if (out_node.GetString("SHORT_CUT").Length > 3)
                {
                    chkShortCTRL.Checked = out_node.GetString("SHORT_CUT")[0] == 'C' ? true : false;
                    chkShortALT.Checked = out_node.GetString("SHORT_CUT")[1] == 'A' ? true : false;
                    chkShortSHIFT.Checked = out_node.GetString("SHORT_CUT")[2] == 'S' ? true : false;
                    cboShortKey.Text = out_node.GetString("SHORT_CUT").Substring(3);
                }
                else
                {
                    chkShortCTRL.Checked = false;
                    chkShortALT.Checked = false;
                    chkShortSHIFT.Checked = false;
                    cboShortKey.Text = "";
                }

                if (out_node.GetChar("FUNC_TYPE_FLAG") == 'F')
                {
                    cboFuncType.SelectedIndex = 0;
                }
                else if (out_node.GetChar("FUNC_TYPE_FLAG") == 'P')
                {
                    cboFuncType.SelectedIndex = 1;
                }
                else if (out_node.GetChar("FUNC_TYPE_FLAG") == 'M')
                {
                    cboFuncType.SelectedIndex = 2;
                }
                else
                {
                    cboFuncType.SelectedIndex = - 1;
                }

                spdFunc.Sheets[0].SetValue(0, CTL_COL, MPCF.Trim(out_node.GetString("CTL_NAME_1")));
                spdFunc.Sheets[0].SetValue(1, CTL_COL, MPCF.Trim(out_node.GetString("CTL_NAME_2")));
                spdFunc.Sheets[0].SetValue(2, CTL_COL, MPCF.Trim(out_node.GetString("CTL_NAME_3")));
                spdFunc.Sheets[0].SetValue(3, CTL_COL, MPCF.Trim(out_node.GetString("CTL_NAME_4")));
                spdFunc.Sheets[0].SetValue(4, CTL_COL, MPCF.Trim(out_node.GetString("CTL_NAME_5")));
                spdFunc.Sheets[0].SetValue(5, CTL_COL, MPCF.Trim(out_node.GetString("CTL_NAME_6")));
                spdFunc.Sheets[0].SetValue(6, CTL_COL, MPCF.Trim(out_node.GetString("CTL_NAME_7")));
                spdFunc.Sheets[0].SetValue(7, CTL_COL, MPCF.Trim(out_node.GetString("CTL_NAME_8")));
                spdFunc.Sheets[0].SetValue(8, CTL_COL, MPCF.Trim(out_node.GetString("CTL_NAME_9")));

                //Modify by J.S. 2011.10.14 flexible inquiry 메뉴 통합
                if (MPCF.Trim(txtAssemblyName.Text) == FLEXIBLEINQUIRYMENU)
                {
                    cdvInquiryID.Init();
                    cdvInquiryID.Enabled = true;
                    lblInquiryID.Enabled = true;
                    spdFunc.Sheets[0].SetValue(9, CTL_COL, "");
                    cdvInquiryID.Text = MPCF.Trim(out_node.GetString("CTL_NAME_10"));
                }
                //Add by Kelly Jung MOF Option Setup
                else if (MPCF.Trim(txtAssemblyName.Text) == MFOMENU)
                {
                    cdvInquiryID.Init();
                    cdvInquiryID.Enabled = true;
                    lblInquiryID.Enabled = true;
                    spdFunc.Sheets[0].SetValue(9, CTL_COL, "");
                    cdvInquiryID.Text = MPCF.Trim(out_node.GetString("CTL_NAME_10"));
                }
                //Add by YoungBok Yoon Process Control Setup
                else if (MPCF.Trim(txtAssemblyName.Text) == PROCESSMENU)
                {
                    cdvInquiryID.Init();
                    cdvInquiryID.Enabled = true;
                    lblInquiryID.Enabled = true;
                    spdFunc.Sheets[0].SetValue(9, CTL_COL, "");
                    cdvInquiryID.Text = MPCF.Trim(out_node.GetString("CTL_NAME_10"));
                }
                else
                {
                    cdvInquiryID.Enabled = false;
                    lblInquiryID.Enabled = false;
                    spdFunc.Sheets[0].SetValue(9, CTL_COL, MPCF.Trim(out_node.GetString("CTL_NAME_10")));
                }
                
                spdFunc.Sheets[0].SetValue(0, TAB_COL, MPCF.Trim(out_node.GetString("TAB_NAME_1")));
                spdFunc.Sheets[0].SetValue(1, TAB_COL, MPCF.Trim(out_node.GetString("TAB_NAME_2")));
                spdFunc.Sheets[0].SetValue(2, TAB_COL, MPCF.Trim(out_node.GetString("TAB_NAME_3")));
                spdFunc.Sheets[0].SetValue(3, TAB_COL, MPCF.Trim(out_node.GetString("TAB_NAME_4")));
                spdFunc.Sheets[0].SetValue(4, TAB_COL, MPCF.Trim(out_node.GetString("TAB_NAME_5")));
                spdFunc.Sheets[0].SetValue(5, TAB_COL, MPCF.Trim(out_node.GetString("TAB_NAME_6")));
                spdFunc.Sheets[0].SetValue(6, TAB_COL, MPCF.Trim(out_node.GetString("TAB_NAME_7")));
                spdFunc.Sheets[0].SetValue(7, TAB_COL, MPCF.Trim(out_node.GetString("TAB_NAME_8")));
                spdFunc.Sheets[0].SetValue(8, TAB_COL, MPCF.Trim(out_node.GetString("TAB_NAME_9")));
                spdFunc.Sheets[0].SetValue(9, TAB_COL, MPCF.Trim(out_node.GetString("TAB_NAME_10")));
                
                spdFunc.Sheets[0].SetValue(0, OPT_COL, MPCF.Trim(out_node.GetString("OPT_NAME_1")));
                spdFunc.Sheets[0].SetValue(1, OPT_COL, MPCF.Trim(out_node.GetString("OPT_NAME_2")));
                spdFunc.Sheets[0].SetValue(2, OPT_COL, MPCF.Trim(out_node.GetString("OPT_NAME_3")));
                spdFunc.Sheets[0].SetValue(3, OPT_COL, MPCF.Trim(out_node.GetString("OPT_NAME_4")));
                spdFunc.Sheets[0].SetValue(4, OPT_COL, MPCF.Trim(out_node.GetString("OPT_NAME_5")));
                spdFunc.Sheets[0].SetValue(5, OPT_COL, MPCF.Trim(out_node.GetString("OPT_NAME_6")));
                spdFunc.Sheets[0].SetValue(6, OPT_COL, MPCF.Trim(out_node.GetString("OPT_NAME_7")));
                spdFunc.Sheets[0].SetValue(7, OPT_COL, MPCF.Trim(out_node.GetString("OPT_NAME_8")));
                spdFunc.Sheets[0].SetValue(8, OPT_COL, MPCF.Trim(out_node.GetString("OPT_NAME_9")));
                spdFunc.Sheets[0].SetValue(9, OPT_COL, MPCF.Trim(out_node.GetString("OPT_NAME_10")));

                //Delete by ICBAE 2012.06.08 - Field Mask 기능 삭제
                //if (out_node.GetChar("FLD_EN_MASK_USE_FLAG") == 'Y')
                //{
                //    chkFldEnableMaskUseFlag.Checked = true;
                //}
                //else
                //{
                //    chkFldEnableMaskUseFlag.Checked = false;
                //}
                txtHelpUrl.Text = MPCF.Trim(out_node.GetString("HELP_URL"));
                txtCreateUser.Text = MPCF.Trim(out_node.GetString("CREATE_USER_ID"));
                txtCreateTime.Text = MPCF.MakeDateFormat(out_node.GetString("CREATE_TIME"));
                txtUpdateUser.Text = MPCF.Trim(out_node.GetString("UPDATE_USER_ID"));
                txtUpdateTime.Text = MPCF.MakeDateFormat(out_node.GetString("UPDATE_TIME"));
                
                cdvExpGrp.Text = MPCF.Trim(out_node.GetString("FUNC_GROUP"));
                txtExpFunc.Text = MPCF.Trim(out_node.GetString("FUNC_NAME"));
                txtExpFuncDesc.Text = MPCF.Trim(out_node.GetString("FUNC_DESC"));

                return true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
            
        }
        
        //
        // Update_Function()
        //       - Create/Update/Delete Security Function Definition
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String ("1" - Create, "2" - Update, "3" - Delete)
        //
        private bool Update_Function(char ProcStep)
        {
            ListViewItem itm;
            int idx;

            TRSNode in_node = new TRSNode("UPDATE_FUNCTION_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");
            
            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;
                in_node.AddString("FUNC_NAME", txtFunc.Text);
                in_node.AddString("FUNC_DESC", MPCF.Trim(txtDesc.Text));
                in_node.AddChar("FUNC_TYPE_FLAG", ((cboFuncType.Text == "") ? ' ' : MPCF.ToChar(cboFuncType.Text.Substring(0, 1))));
                in_node.AddString("FUNC_GROUP", MPCF.Trim(cdvFGroup.Text));
                in_node.AddString("ASSEMBLY_FILE", MPCF.Trim(txtAssemblyFile.Text));
                in_node.AddString("ASSEMBLY_NAME", MPCF.Trim(txtAssemblyName.Text));
                in_node.AddInt("ICON_INDEX", MPCF.Trim(cdvIconIndex.Text) == "" ? -1 : MPCF.ToInt(cdvIconIndex.Text));

                if (MPCF.Trim(cboShortKey.Text) != "")
                {
                    string sShort_Cut = "";
                    sShort_Cut = chkShortCTRL.Checked == true ? "C" : "-";
                    sShort_Cut += chkShortALT.Checked == true ? "A" : "-";
                    sShort_Cut += chkShortSHIFT.Checked == true ? "S" : "-";
                    sShort_Cut += MPCF.Trim(cboShortKey.Text);

                    in_node.AddString("SHORT_CUT", sShort_Cut);
                }

                in_node.AddString("CTL_NAME_1", MPCF.Trim(spdFunc.Sheets[0].GetValue(0, CTL_COL)));
                in_node.AddString("CTL_NAME_2", MPCF.Trim(spdFunc.Sheets[0].GetValue(1, CTL_COL)));
                in_node.AddString("CTL_NAME_3", MPCF.Trim(spdFunc.Sheets[0].GetValue(2, CTL_COL)));
                in_node.AddString("CTL_NAME_4", MPCF.Trim(spdFunc.Sheets[0].GetValue(3, CTL_COL)));
                in_node.AddString("CTL_NAME_5", MPCF.Trim(spdFunc.Sheets[0].GetValue(4, CTL_COL)));
                in_node.AddString("CTL_NAME_6", MPCF.Trim(spdFunc.Sheets[0].GetValue(5, CTL_COL)));
                in_node.AddString("CTL_NAME_7", MPCF.Trim(spdFunc.Sheets[0].GetValue(6, CTL_COL)));
                in_node.AddString("CTL_NAME_8", MPCF.Trim(spdFunc.Sheets[0].GetValue(7, CTL_COL)));
                in_node.AddString("CTL_NAME_9", MPCF.Trim(spdFunc.Sheets[0].GetValue(8, CTL_COL)));

                //Modify by J.S. 2011.10.14 flexible inquiry 메뉴 통합
                //Add by Kelly Jung MOF Option Setup
                if (MPCF.Trim(txtAssemblyName.Text) == FLEXIBLEINQUIRYMENU || MPCF.Trim(txtAssemblyName.Text) == MFOMENU || MPCF.Trim(txtAssemblyName.Text) == PROCESSMENU)
                {
                    in_node.AddString("CTL_NAME_10", MPCF.Trim(cdvInquiryID.Text));
                }
                else
                {
                    in_node.AddString("CTL_NAME_10", MPCF.Trim(spdFunc.Sheets[0].GetValue(9, CTL_COL)));
                }

                in_node.AddString("TAB_NAME_1", MPCF.Trim(spdFunc.Sheets[0].GetValue(0, TAB_COL)));
                in_node.AddString("TAB_NAME_2", MPCF.Trim(spdFunc.Sheets[0].GetValue(1, TAB_COL)));
                in_node.AddString("TAB_NAME_3", MPCF.Trim(spdFunc.Sheets[0].GetValue(2, TAB_COL)));
                in_node.AddString("TAB_NAME_4", MPCF.Trim(spdFunc.Sheets[0].GetValue(3, TAB_COL)));
                in_node.AddString("TAB_NAME_5", MPCF.Trim(spdFunc.Sheets[0].GetValue(4, TAB_COL)));
                in_node.AddString("TAB_NAME_6", MPCF.Trim(spdFunc.Sheets[0].GetValue(5, TAB_COL)));
                in_node.AddString("TAB_NAME_7", MPCF.Trim(spdFunc.Sheets[0].GetValue(6, TAB_COL)));
                in_node.AddString("TAB_NAME_8", MPCF.Trim(spdFunc.Sheets[0].GetValue(7, TAB_COL)));
                in_node.AddString("TAB_NAME_9", MPCF.Trim(spdFunc.Sheets[0].GetValue(8, TAB_COL)));
                in_node.AddString("TAB_NAME_10", MPCF.Trim(spdFunc.Sheets[0].GetValue(9, TAB_COL)));

                in_node.AddString("OPT_NAME_1", MPCF.Trim(spdFunc.Sheets[0].GetValue(0, OPT_COL)));
                in_node.AddString("OPT_NAME_2", MPCF.Trim(spdFunc.Sheets[0].GetValue(1, OPT_COL)));
                in_node.AddString("OPT_NAME_3", MPCF.Trim(spdFunc.Sheets[0].GetValue(2, OPT_COL)));
                in_node.AddString("OPT_NAME_4", MPCF.Trim(spdFunc.Sheets[0].GetValue(3, OPT_COL)));
                in_node.AddString("OPT_NAME_5", MPCF.Trim(spdFunc.Sheets[0].GetValue(4, OPT_COL)));
                in_node.AddString("OPT_NAME_6", MPCF.Trim(spdFunc.Sheets[0].GetValue(5, OPT_COL)));
                in_node.AddString("OPT_NAME_7", MPCF.Trim(spdFunc.Sheets[0].GetValue(6, OPT_COL)));
                in_node.AddString("OPT_NAME_8", MPCF.Trim(spdFunc.Sheets[0].GetValue(7, OPT_COL)));
                in_node.AddString("OPT_NAME_9", MPCF.Trim(spdFunc.Sheets[0].GetValue(8, OPT_COL)));
                in_node.AddString("OPT_NAME_10", MPCF.Trim(spdFunc.Sheets[0].GetValue(9, OPT_COL)));

                //Delete by ICBAE 2012.06.08 - Field Mask 기능 삭제
                //in_node.AddChar("FLD_EN_MASK_USE_FLAG", (chkFldEnableMaskUseFlag.Checked == true ? 'Y' : ' '));
                in_node.AddString("HELP_URL", MPCF.Trim(txtHelpUrl.Text));

                if (MPCR.CallService("SEC", "SEC_Update_Function", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCR.ShowSuccessMsg(out_node);

                if (MPGV.gbListAutoRefresh == false)
                {
                    if (ProcStep == MPGC.MP_STEP_CREATE)
                    {
                        itm = lisFunc.Items.Add(txtFunc.Text, (int)SMALLICON_INDEX.IDX_FUNCTION);
                        itm.SubItems.Add(txtDesc.Text);
                        itm.Selected = true;
                        lisFunc.Sorting = SortOrder.Ascending;
                        lisFunc.Sort();
                        itm.EnsureVisible();
                    }
                    else if (ProcStep == MPGC.MP_STEP_UPDATE)
                    {
                        if (MPCF.FindListItem(lisFunc, MPCF.Trim(txtFunc.Text), false) == true)
                        {
                            lisFunc.SelectedItems[0].SubItems[1].Text = MPCF.Trim(txtDesc.Text);
                        }
                    }
                    else if (ProcStep == MPGC.MP_STEP_DELETE)
                    {
                        idx = MPCF.FindListItemIndex(lisFunc, MPCF.Trim(txtFunc.Text), false);
                        if (idx != - 1)
                        {
                            lisFunc.Items[idx].Remove();
                        }
                    }
                    lblDataCount.Text = lisFunc.Items.Count.ToString();
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
                return this.txtFunc;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }
            
        }

        // Get_InquiryID_List()
        //       - Get InquiryID List
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool Get_InquiryID_List(ListView listView)
        {
            try
            {
                TRSNode in_node = new TRSNode("INQUIRY_ID_LIST_IN");
                TRSNode out_node = new TRSNode("INQUIRY_ID_LIST_OUT");
                ListViewItem viewItem;

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '3';
                //in_node.AddString("INQUIRY_GROUP", MPCF.Trim(cdvInquiryGrp.Text));

                if (MPCR.CallService("BAS", "BAS_View_Flexible_Condition_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (int i = 0; i < out_node.GetList(0).Count; i++)
                {
                    viewItem = listView.Items.Add(new ListViewItem(out_node.GetList(0)[i].GetString("INQUIRY_ID"), (int)SMALLICON_INDEX.IDX_MODULE));
                    viewItem.SubItems.Add(out_node.GetList(0)[i].GetString("INQUIRY_DESC1"));
                    viewItem.SubItems.Add(out_node.GetList(0)[i].GetString("INQUIRY_TITLE"));
                    viewItem.SubItems.Add(out_node.GetList(0)[i].GetString("SQL_ID_1"));
                }
                return true;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        //Add by Kelly Jung MOF Option Setup
        // Get_MFO_Inquiry_List()
        //       - Get MFO Inquiry List
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool Get_MFO_Inquiry_List(ListView listView)
        {
            try
            {
                TRSNode in_node = new TRSNode("MFO_INQUIRY_LIST_IN");
                TRSNode out_node = new TRSNode("MFO_INQUIRY_LIST_OUT");
                ListViewItem viewItem;

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                //in_node.AddString("INQUIRY_GROUP", MPCF.Trim(cdvInquiryGrp.Text));

                if (MPCR.CallService("WIP", "WIP_View_MFO_Option_Prompt_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (int i = 0; i < out_node.GetList(0).Count; i++)
                {
                    viewItem = listView.Items.Add(new ListViewItem(out_node.GetList(0)[i].GetString("OPTION_NAME"), (int)SMALLICON_INDEX.IDX_MODULE));
                    viewItem.SubItems.Add(out_node.GetList(0)[i].GetString("OPTION_DESC"));
                    //viewItem.SubItems.Add(out_node.GetList(0)[i].GetString("INQUIRY_TITLE"));
                    //viewItem.SubItems.Add(out_node.GetList(0)[i].GetString("SQL_ID_1"));
                }
                return true;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        #endregion
        
        private void frmSECTBLDEF00_Activated(object sender, System.EventArgs e)
        {
            
            try
            {
                if (b_load_flag == false)
                {
                    FillIconList();
                    btnRefresh.PerformClick();

                    ((Control)GetFisrtFocusItem()).Focus();

                    b_load_flag = true;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void frmSECSetupFunction_Load(object sender, System.EventArgs e)
        {
            
            try
            {
                MPCF.InitListView(lisFunc);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void btnCreate_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                if (CheckCondition("Update_Function", MPGC.MP_STEP_CREATE) == true)
                {
                    if (Update_Function(MPGC.MP_STEP_CREATE) == false)
                    {
                        return;
                    }
                    if (MPGV.gbListAutoRefresh == true)
                    {
                        btnRefresh.PerformClick();
                    }
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
                if (CheckCondition("Update_Function", MPGC.MP_STEP_UPDATE) == true)
                {
                    if (Update_Function(MPGC.MP_STEP_UPDATE) == false)
                    {
                        return;
                    }
                    if (MPGV.gbListAutoRefresh == true)
                    {
                        btnRefresh.PerformClick();
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void btnDelete_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                if (MPCF.ShowMsgBox(MPCF.GetMessage(54), MessageBoxButtons.YesNo, 2) != System.Windows.Forms.DialogResult.Yes)
                {
                    return;
                }
                if (CheckCondition("Update_Function", MPGC.MP_STEP_DELETE) == true)
                {
                    if (Update_Function(MPGC.MP_STEP_DELETE) == false)
                    {
                        return;
                    }
                    ClearData("1");
                    if (MPGV.gbListAutoRefresh == true)
                    {
                        btnRefresh.PerformClick();
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void lisFunc_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                if (lisFunc.SelectedItems.Count > 0)
                {
                    View_Function();
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
                lblDataCount.Text = "";
                if (SECLIST.ViewFunctionList(lisFunc, "", "", cdvGroup.Text) == false)
                {
                    return;
                }
                lblDataCount.Text = lisFunc.Items.Count.ToString();
                if (lisFunc.Items.Count > 0)
                {
                    if (MPCF.Trim(txtFunc.Text) == "")
                    {
                        lisFunc.Items[0].Selected = true;
                    }
                    else
                    {
                        MPCF.FindListItem(lisFunc, txtFunc.Text, false);
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void btnExcel_Click(System.Object sender, System.EventArgs e)
        {

            MPCF.ExportToExcel(lisFunc, this.Text, "");
            
        }
        
        private void btnNext_Click(System.Object sender, System.EventArgs e)
        {

            MPCF.FindListItemNextPartial(lisFunc, txtFind.Text, true, false);
            
        }
        
        private void txtFind_TextChanged(System.Object sender, System.EventArgs e)
        {

            MPCF.FindListItemPartial(lisFunc, txtFind.Text, 0, true, false);
            
        }

        private void cdvFuncGroup_ButtonPress(object sender, EventArgs e)
        {
            Miracom.UI.Controls.MCCodeView.MCCodeView cdv_view = (Miracom.UI.Controls.MCCodeView.MCCodeView)sender;

            cdv_view.Init();
            MPCF.InitListView(cdv_view.GetListView);
            cdv_view.Columns.Add("Group", 50, HorizontalAlignment.Left);
            cdv_view.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdv_view.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMDataList(cdv_view.GetListView, '1', MPGC.MP_SEC_FUNCTION_GROUP);
        }

        private void cdvGroup_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            btnRefresh.PerformClick();
        }

        private void cboShortKey_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (chkShortALT.Checked == false && chkShortCTRL.Checked == false && chkShortSHIFT.Checked == true)
            {
                if (cboShortKey.Text.Length == 1)
                {
                    if (cboShortKey.Text.CompareTo("0") >= 0)
                    {
                        MPCF.ShowMsgBox("Not Allowed Shortcut : Shift + " + cboShortKey.Text + "\nPlease select other one.");
                        cboShortKey.SelectedIndex = -1;
                        cboShortKey.Text = "";
                    }
                }
            }
        }

        private void cdvInquiryID_ButtonPress(object sender, EventArgs e)
        {
            cdvInquiryID.Init();
            MPCF.InitListView(cdvInquiryID.GetListView);
            cdvInquiryID.SelectedSubItemIndex = 0;

            //Modify by Kelly Jung 20121112
            //put MFO Inquiry
            if (MPCF.Trim(txtAssemblyName.Text) == FLEXIBLEINQUIRYMENU)
            {
                cdvInquiryID.Columns.Add("Inquiry ID", 50, HorizontalAlignment.Left);
                Get_InquiryID_List(cdvInquiryID.GetListView);
            }
            else if (MPCF.Trim(txtAssemblyName.Text) == MFOMENU)
            {
                cdvInquiryID.Columns.Add("MFO Type", 50, HorizontalAlignment.Left);
                Get_MFO_Inquiry_List(cdvInquiryID.GetListView);
            }
            else if (MPCF.Trim(txtAssemblyName.Text) == PROCESSMENU)
            {
                cdvInquiryID.Init();
                cdvInquiryID.Columns.Add("Code", 50, HorizontalAlignment.Left);
                cdvInquiryID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvInquiryID.SelectedSubItemIndex = 0;

                if (BASLIST.ViewGCMDataList(cdvInquiryID.GetListView, '1', MPGC.MP_PRIORITY_TYPE_TBL_DEF) == false)
                {
                    return;
                }
            }
            cdvInquiryID.ShowPopUp();
        }

        private void cdvInquiryID_SelectedItemChanged(object sender, UI.MCCodeViewSelChanged_EventArgs e)
        {
            cdvInquiryID.DescText = cdvInquiryID.SelectedItem.SubItems[1].Text;

        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            TRSNode in_node = new TRSNode("SQL_IN");
            TRSNode out_node = new TRSNode("SQL_OUT");

            string Query = null;
            string data;
            txtExport.Text = "";
            int i, j;
            string temp = null;
            string cmt = null;
            StringBuilder script = null;

            #region rdobutton 체크
            if (rboFunc.Checked == true)
            {
                Query = "SELECT * FROM MSECFUNDEF WHERE FUNC_NAME = '" + txtExpFunc.Text + "'";
                cmt = "MSECFUNDEF Table(FUNC_NAME) : " + txtExpFunc.Text + " - " + txtExpFuncDesc.Text;
            }
            else if (rboGroup.Checked == true)
            {
                Query = "SELECT * FROM MSECFUNDEF WHERE FUNC_GROUP = '" + cdvExpGrp.Text + "' ORDER BY FUNC_NAME";
                cmt = "MSECFUNDEF Table(FUNC_GROUP) : " + cdvExpGrp.Text;
            }
            else if (rboAllTbl.Checked == true)
            {
                Query = "SELECT * FROM MSECFUNDEF ORDER BY FUNC_NAME";
                cmt = "MSECFUNDEF Table(All Table) : MSECFUNDEF";
            }
            #endregion

            script = new StringBuilder();
            progressBarExport.Value = 0;

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("SQL", Query);

                do
                {
                    if (MPCR.CallService("BAS", "BAS_SQL_Query", in_node, ref out_node) == false)
                    {
                        return;
                    }

                    progressBarExport.Maximum = out_node.GetList("ROWS").Count;

                    #region 컬럼명 셋팅
                    temp = "INSERT INTO MSECFUNDEF(";

                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        temp += out_node.GetList(0)[i].GetString("NAME");
                        if (i < out_node.GetList(0).Count - 1) temp += ", ";
                    }
                    temp += ") VALUES(";
                    script.Append("/* Start [" + cmt + "] */\r\n");
                    script.Append(temp);
                    #endregion

                    if (out_node.GetList("ROWS").Count <= 0)
                    {
                        txtExport.Text = "No Data";
                        return;
                    }

                    //Request Reply Timeout 발생시 옵션에서 TimeOut시간을 늘려주어야함
                    #region Data값 받기
                    for (i = 0; i < out_node.GetList("ROWS").Count; i++)
                    {
                        for (j = 0; j < out_node.GetList("COLUMNS").Count; j++)
                        {
                            if (out_node.GetList("ROWS")[i].GetList("COLS")[j].GetString("DATA") == "")
                            {
                                script.Append("' ");
                                if (j < out_node.GetList(0).Count - 1) script.Append("', ");
                                else script.Append("'");
                            }
                            else
                            {
                                script.Append("'");
                                if (out_node.GetList("ROWS")[i].GetList("COLS")[j].GetString("DATA").Contains("'"))
                                {
                                    data = out_node.GetList("ROWS")[i].GetList("COLS")[j].GetString("DATA").Replace("'", "''");
                                }
                                else
                                {
                                    data = out_node.GetList("ROWS")[i].GetList("COLS")[j].GetString("DATA");
                                }
                                script.Append(data);
                                if (j < out_node.GetList(0).Count - 1) script.Append("', ");
                                else script.Append("'");
                            }
                        }
                        script.Append(");\r\n");
                        progressBarExport.Increment(1);

                        if (b_export_stop) //Stop 처리
                        {
                            txtExport.Focus();
                            txtExport.AppendText("<User Stop>..." + "\r\n");
                            b_export_stop = false;
                            return;
                        }
                        if (i < out_node.GetList("ROWS").Count - 1) script.Append(temp);
                        if (i >= out_node.GetList("ROWS").Count - 1) script.Append("/* End [" + cmt + "] */\r\n\r\n");
                    }
                    in_node.SetInt("NEXT_ROW", out_node.GetInt("NEXT_ROW"));
                } while (out_node.GetInt("NEXT_ROW") > 0);
                    #endregion

                txtExport.Text = script.ToString();
                txtExport.Select(0, txtExport.Text.Length);
                txtExport.SelectionFont = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular);
                progressBarExport.Increment(1);

                if (txtExpFile.Text != "")
                {
                    StreamWriter write = new StreamWriter(txtExpFile.Text, false, Encoding.GetEncoding("EUC-KR"));
                    write.Write(script);
                    write.Close();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            progressBarExport.Value = 0;
            return;
        }

        private void btnExpStop_Click(object sender, EventArgs e)
        {
            b_export_stop = true;
        }

        private void btnExpCopy_Click(object sender, EventArgs e)
        {
            try
            {
                if (MPCF.Trim(txtExport.Text) != "")
                {
                    Clipboard.SetText(txtExport.Text);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cboExpGrp_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void btnExpFile_Click(object sender, EventArgs e)
        {
            sfdFile.Filter = "SQL | *.sql";
            if (sfdFile.ShowDialog() == DialogResult.OK)
            {
                txtExpFile.Text = sfdFile.FileName;
                txtExport.Text = "";
            }
        }

        private void txtAssemblyName_TextChanged(object sender, EventArgs e)
        {
            cdvInquiryID.Enabled = false;
            lblInquiryID.Enabled = false;

            if (MPCF.Trim(txtAssemblyName.Text) == FLEXIBLEINQUIRYMENU || MPCF.Trim(txtAssemblyName.Text) == MFOMENU || MPCF.Trim(txtAssemblyName.Text) == PROCESSMENU)
            {
                cdvInquiryID.Enabled = true;
                lblInquiryID.Enabled = true;
            }
        }

    }
    
}
