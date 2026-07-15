
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
//   File Name   : frmRASSetupSheet.cs
//   Description : Sheet Definition Form
//
//   MES Version : 4.1.0.0
//
//   Function List
//       - ClearData() : Intialize Form Field
//       - CheckCondition : Check the Conditions before Transaction
//       - View_Attached_Query() : View PM Sheet definition
//       - View_Attached_Query_List() : View all table list which is included in one factory
//       - Update_Function() : Create/Update/Delete PM Sheet definition
//       - View_User_Group_List() : View all user group list
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2008-02-26 : Created by James Kwon
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------

//Imports


namespace Miracom.RASCore
{
    public class frmRASSetupAttachQueryToCheck : Miracom.MESCore.SetupForm02
    {
        
        #region " Windows Form auto generated code "

        public frmRASSetupAttachQueryToCheck()
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
        private System.Windows.Forms.TextBox txtSheetName;
        private System.Windows.Forms.Label lblSheetName;
        private System.Windows.Forms.GroupBox grpSheetType;
        private Miracom.UI.Controls.MCListView.MCListView lisSheet;
        private GroupBox grpFuncGroup;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvGrpSheetType;
        private Label lblGrpResType;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvSheetType;
        private Label lblResType;
        private TabControl tabQuery;
        private TabPage tbpAttachQuery;
        private TabPage tbpViewQuery;
        private Panel pnlEventMid;
        private Panel pnlEventMidMid;
        private Button btnDel;
        private Button btnAdd;
        private Panel pnlEventMidRight;
        private Panel pnlEventMidLeft;
        private Miracom.UI.Controls.MCListView.MCListView lisQuery;
        private ColumnHeader ColumnHeader13;
        private ColumnHeader ColumnHeader14;
        private Label lblEvent;
        private FarPoint.Win.Spread.FpSpread spdQuery;
        private FarPoint.Win.Spread.SheetView spdQuery_Sheet1;
        private Miracom.UI.Controls.MCListView.MCListView lisQueryList;
        private ColumnHeader ColumnHeader15;
        private ColumnHeader ColumnHeader16;
        private Label lblEventList;
        private Panel panel1;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvQryType;
        private Label label1;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvSheetGrp10;
        private Label lblSheetGrp10;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvSheetGrp9;
        private Label lblSheetGrp9;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvSheetGrp8;
        private Label lblSheetGrp8;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvSheetGrp7;
        private Label lblSheetGrp7;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvSheetGrp6;
        private Label lblSheetGrp6;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvSheetGrp5;
        private Label lblSheetGrp5;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvSheetGrp4;
        private Label lblSheetGrp4;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvSheetGrp3;
        private Label lblSheetGrp3;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvSheetGrp2;
        private Label lblSheetGrp2;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvSheetGrp1;
        private Label lblSheetGrp1;
        protected Button btnQryExcel;
        private System.Windows.Forms.Panel pnlFuncName;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRASSetupAttachQueryToCheck));
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            this.lisSheet = new Miracom.UI.Controls.MCListView.MCListView();
            this.ColumnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.grbTable = new System.Windows.Forms.GroupBox();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.Label6 = new System.Windows.Forms.Label();
            this.txtSheetName = new System.Windows.Forms.TextBox();
            this.lblSheetName = new System.Windows.Forms.Label();
            this.pnlFuncName = new System.Windows.Forms.Panel();
            this.tabQuery = new System.Windows.Forms.TabControl();
            this.tbpAttachQuery = new System.Windows.Forms.TabPage();
            this.pnlEventMid = new System.Windows.Forms.Panel();
            this.pnlEventMidMid = new System.Windows.Forms.Panel();
            this.btnQryExcel = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.pnlEventMidRight = new System.Windows.Forms.Panel();
            this.lisQueryList = new Miracom.UI.Controls.MCListView.MCListView();
            this.ColumnHeader15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader16 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblEventList = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cdvQryType = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlEventMidLeft = new System.Windows.Forms.Panel();
            this.lisQuery = new Miracom.UI.Controls.MCListView.MCListView();
            this.ColumnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblEvent = new System.Windows.Forms.Label();
            this.tbpViewQuery = new System.Windows.Forms.TabPage();
            this.spdQuery = new FarPoint.Win.Spread.FpSpread();
            this.spdQuery_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.grpSheetType = new System.Windows.Forms.GroupBox();
            this.cdvSheetGrp10 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblSheetGrp10 = new System.Windows.Forms.Label();
            this.cdvSheetGrp9 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblSheetGrp9 = new System.Windows.Forms.Label();
            this.cdvSheetGrp8 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblSheetGrp8 = new System.Windows.Forms.Label();
            this.cdvSheetGrp7 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblSheetGrp7 = new System.Windows.Forms.Label();
            this.cdvSheetGrp6 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblSheetGrp6 = new System.Windows.Forms.Label();
            this.cdvSheetGrp5 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblSheetGrp5 = new System.Windows.Forms.Label();
            this.cdvSheetGrp4 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblSheetGrp4 = new System.Windows.Forms.Label();
            this.cdvSheetGrp3 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblSheetGrp3 = new System.Windows.Forms.Label();
            this.cdvSheetGrp2 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblSheetGrp2 = new System.Windows.Forms.Label();
            this.cdvSheetGrp1 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblSheetGrp1 = new System.Windows.Forms.Label();
            this.cdvSheetType = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblResType = new System.Windows.Forms.Label();
            this.grpFuncGroup = new System.Windows.Forms.GroupBox();
            this.cdvGrpSheetType = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblGrpResType = new System.Windows.Forms.Label();
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
            this.tabQuery.SuspendLayout();
            this.tbpAttachQuery.SuspendLayout();
            this.pnlEventMid.SuspendLayout();
            this.pnlEventMidMid.SuspendLayout();
            this.pnlEventMidRight.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvQryType)).BeginInit();
            this.pnlEventMidLeft.SuspendLayout();
            this.tbpViewQuery.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdQuery_Sheet1)).BeginInit();
            this.grpSheetType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvSheetGrp10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvSheetGrp9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvSheetGrp8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvSheetGrp7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvSheetGrp6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvSheetGrp5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvSheetGrp4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvSheetGrp3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvSheetGrp2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvSheetGrp1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvSheetType)).BeginInit();
            this.grpFuncGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGrpSheetType)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlFind
            // 
            this.pnlFind.TabIndex = 4;
            // 
            // btnExcel
            // 
            this.btnExcel.TabIndex = 3;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnNext
            // 
            this.btnNext.TabIndex = 1;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // txtFind
            // 
            this.txtFind.TabIndex = 0;
            this.txtFind.TextChanged += new System.EventHandler(this.txtFind_TextChanged);
            // 
            // splMain
            // 
            this.splMain.Size = new System.Drawing.Size(4, 513);
            this.splMain.TabIndex = 1;
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.pnlFuncName);
            this.pnlRight.Controls.Add(this.grbTable);
            this.pnlRight.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.pnlRight.Size = new System.Drawing.Size(506, 513);
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.lisSheet);
            this.pnlLeft.Controls.Add(this.grpFuncGroup);
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Padding = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.pnlLeft.Size = new System.Drawing.Size(232, 513);
            // 
            // btnCreate
            // 
            this.btnCreate.TabIndex = 0;
            this.btnCreate.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(467, 7);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Visible = false;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(558, 7);
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnClose
            // 
            this.btnClose.TabIndex = 3;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Location = new System.Drawing.Point(0, 513);
            // 
            // pnlCenter
            // 
            this.pnlCenter.Size = new System.Drawing.Size(742, 513);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "Function Setup";
            // 
            // lisSheet
            // 
            this.lisSheet.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader1,
            this.ColumnHeader2});
            this.lisSheet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisSheet.EnableSort = true;
            this.lisSheet.EnableSortIcon = true;
            this.lisSheet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisSheet.FullRowSelect = true;
            this.lisSheet.HideSelection = false;
            this.lisSheet.Location = new System.Drawing.Point(3, 43);
            this.lisSheet.MultiSelect = false;
            this.lisSheet.Name = "lisSheet";
            this.lisSheet.Size = new System.Drawing.Size(229, 467);
            this.lisSheet.TabIndex = 0;
            this.lisSheet.UseCompatibleStateImageBehavior = false;
            this.lisSheet.View = System.Windows.Forms.View.Details;
            this.lisSheet.SelectedIndexChanged += new System.EventHandler(this.lisSheet_SelectedIndexChanged);
            // 
            // ColumnHeader1
            // 
            this.ColumnHeader1.Text = "Check Name";
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
            this.grbTable.Controls.Add(this.txtSheetName);
            this.grbTable.Controls.Add(this.lblSheetName);
            this.grbTable.Dock = System.Windows.Forms.DockStyle.Top;
            this.grbTable.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grbTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbTable.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grbTable.Location = new System.Drawing.Point(3, 0);
            this.grbTable.Name = "grbTable";
            this.grbTable.Size = new System.Drawing.Size(500, 65);
            this.grbTable.TabIndex = 1;
            this.grbTable.TabStop = false;
            // 
            // txtDesc
            // 
            this.txtDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesc.Location = new System.Drawing.Point(99, 39);
            this.txtDesc.MaxLength = 200;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(389, 20);
            this.txtDesc.TabIndex = 3;
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label6.Location = new System.Drawing.Point(7, 42);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(60, 13);
            this.Label6.TabIndex = 2;
            this.Label6.Text = "Description";
            this.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSheetName
            // 
            this.txtSheetName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSheetName.Location = new System.Drawing.Point(99, 16);
            this.txtSheetName.MaxLength = 50;
            this.txtSheetName.Name = "txtSheetName";
            this.txtSheetName.Size = new System.Drawing.Size(177, 20);
            this.txtSheetName.TabIndex = 1;
            this.txtSheetName.TextChanged += new System.EventHandler(this.txtSheetName_TextChanged);
            // 
            // lblSheetName
            // 
            this.lblSheetName.AutoSize = true;
            this.lblSheetName.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblSheetName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSheetName.Location = new System.Drawing.Point(7, 20);
            this.lblSheetName.Name = "lblSheetName";
            this.lblSheetName.Size = new System.Drawing.Size(79, 13);
            this.lblSheetName.TabIndex = 0;
            this.lblSheetName.Text = "Check Name";
            this.lblSheetName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlFuncName
            // 
            this.pnlFuncName.Controls.Add(this.tabQuery);
            this.pnlFuncName.Controls.Add(this.grpSheetType);
            this.pnlFuncName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFuncName.Location = new System.Drawing.Point(3, 65);
            this.pnlFuncName.Name = "pnlFuncName";
            this.pnlFuncName.Size = new System.Drawing.Size(500, 445);
            this.pnlFuncName.TabIndex = 2;
            // 
            // tabQuery
            // 
            this.tabQuery.Controls.Add(this.tbpAttachQuery);
            this.tabQuery.Controls.Add(this.tbpViewQuery);
            this.tabQuery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabQuery.Location = new System.Drawing.Point(0, 40);
            this.tabQuery.Name = "tabQuery";
            this.tabQuery.SelectedIndex = 0;
            this.tabQuery.Size = new System.Drawing.Size(500, 405);
            this.tabQuery.TabIndex = 1;
            // 
            // tbpAttachQuery
            // 
            this.tbpAttachQuery.Controls.Add(this.pnlEventMid);
            this.tbpAttachQuery.Location = new System.Drawing.Point(4, 22);
            this.tbpAttachQuery.Name = "tbpAttachQuery";
            this.tbpAttachQuery.Padding = new System.Windows.Forms.Padding(3);
            this.tbpAttachQuery.Size = new System.Drawing.Size(492, 379);
            this.tbpAttachQuery.TabIndex = 0;
            this.tbpAttachQuery.Text = "Attach Query";
            // 
            // pnlEventMid
            // 
            this.pnlEventMid.Controls.Add(this.pnlEventMidMid);
            this.pnlEventMid.Controls.Add(this.pnlEventMidRight);
            this.pnlEventMid.Controls.Add(this.pnlEventMidLeft);
            this.pnlEventMid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlEventMid.Location = new System.Drawing.Point(3, 3);
            this.pnlEventMid.Name = "pnlEventMid";
            this.pnlEventMid.Size = new System.Drawing.Size(486, 373);
            this.pnlEventMid.TabIndex = 2;
            this.pnlEventMid.Resize += new System.EventHandler(this.pnlEventMid_Resize);
            // 
            // pnlEventMidMid
            // 
            this.pnlEventMidMid.Controls.Add(this.btnQryExcel);
            this.pnlEventMidMid.Controls.Add(this.btnDel);
            this.pnlEventMidMid.Controls.Add(this.btnAdd);
            this.pnlEventMidMid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlEventMidMid.Location = new System.Drawing.Point(218, 0);
            this.pnlEventMidMid.Name = "pnlEventMidMid";
            this.pnlEventMidMid.Size = new System.Drawing.Size(50, 373);
            this.pnlEventMidMid.TabIndex = 0;
            // 
            // btnQryExcel
            // 
            this.btnQryExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnQryExcel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnQryExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnQryExcel.Image")));
            this.btnQryExcel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnQryExcel.Location = new System.Drawing.Point(3, 346);
            this.btnQryExcel.Name = "btnQryExcel";
            this.btnQryExcel.Size = new System.Drawing.Size(24, 24);
            this.btnQryExcel.TabIndex = 22;
            this.btnQryExcel.Click += new System.EventHandler(this.btnQryExcel_Click);
            // 
            // btnDel
            // 
            this.btnDel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnDel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDel.Location = new System.Drawing.Point(13, 201);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(24, 24);
            this.btnDel.TabIndex = 1;
            this.btnDel.Text = ">";
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(13, 172);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(24, 24);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "<";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // pnlEventMidRight
            // 
            this.pnlEventMidRight.Controls.Add(this.lisQueryList);
            this.pnlEventMidRight.Controls.Add(this.lblEventList);
            this.pnlEventMidRight.Controls.Add(this.panel1);
            this.pnlEventMidRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlEventMidRight.Location = new System.Drawing.Point(268, 0);
            this.pnlEventMidRight.Name = "pnlEventMidRight";
            this.pnlEventMidRight.Size = new System.Drawing.Size(218, 373);
            this.pnlEventMidRight.TabIndex = 3;
            // 
            // lisQueryList
            // 
            this.lisQueryList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader15,
            this.ColumnHeader16});
            this.lisQueryList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisQueryList.EnableSort = true;
            this.lisQueryList.EnableSortIcon = true;
            this.lisQueryList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisQueryList.FullRowSelect = true;
            this.lisQueryList.Location = new System.Drawing.Point(0, 51);
            this.lisQueryList.Name = "lisQueryList";
            this.lisQueryList.Size = new System.Drawing.Size(218, 322);
            this.lisQueryList.TabIndex = 0;
            this.lisQueryList.UseCompatibleStateImageBehavior = false;
            this.lisQueryList.View = System.Windows.Forms.View.Details;
            // 
            // ColumnHeader15
            // 
            this.ColumnHeader15.Text = "Query ID";
            this.ColumnHeader15.Width = 100;
            // 
            // ColumnHeader16
            // 
            this.ColumnHeader16.Text = "Query";
            this.ColumnHeader16.Width = 150;
            // 
            // lblEventList
            // 
            this.lblEventList.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblEventList.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblEventList.Location = new System.Drawing.Point(0, 34);
            this.lblEventList.Name = "lblEventList";
            this.lblEventList.Size = new System.Drawing.Size(218, 17);
            this.lblEventList.TabIndex = 2;
            this.lblEventList.Text = "All Query";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cdvQryType);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(218, 34);
            this.panel1.TabIndex = 0;
            // 
            // cdvQryType
            // 
            this.cdvQryType.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvQryType.BorderHotColor = System.Drawing.Color.Black;
            this.cdvQryType.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvQryType.BtnToolTipText = "";
            this.cdvQryType.DescText = "";
            this.cdvQryType.DisplaySubItemIndex = -1;
            this.cdvQryType.DisplayText = "";
            this.cdvQryType.Focusing = null;
            this.cdvQryType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvQryType.Index = 0;
            this.cdvQryType.IsViewBtnImage = false;
            this.cdvQryType.Location = new System.Drawing.Point(73, 7);
            this.cdvQryType.MaxLength = 20;
            this.cdvQryType.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvQryType.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvQryType.Name = "cdvQryType";
            this.cdvQryType.ReadOnly = false;
            this.cdvQryType.SearchSubItemIndex = 0;
            this.cdvQryType.SelectedDescIndex = -1;
            this.cdvQryType.SelectedSubItemIndex = -1;
            this.cdvQryType.SelectionStart = 0;
            this.cdvQryType.Size = new System.Drawing.Size(142, 20);
            this.cdvQryType.SmallImageList = null;
            this.cdvQryType.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvQryType.TabIndex = 0;
            this.cdvQryType.TextBoxToolTipText = "";
            this.cdvQryType.TextBoxWidth = 142;
            this.cdvQryType.VisibleButton = true;
            this.cdvQryType.VisibleColumnHeader = false;
            this.cdvQryType.VisibleDescription = false;
            this.cdvQryType.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvQryType_SelectedItemChanged);
            this.cdvQryType.ButtonPress += new System.EventHandler(this.cdvQryType_ButtonPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.Location = new System.Drawing.Point(7, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "QRY Type";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlEventMidLeft
            // 
            this.pnlEventMidLeft.Controls.Add(this.lisQuery);
            this.pnlEventMidLeft.Controls.Add(this.lblEvent);
            this.pnlEventMidLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlEventMidLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlEventMidLeft.Name = "pnlEventMidLeft";
            this.pnlEventMidLeft.Size = new System.Drawing.Size(218, 373);
            this.pnlEventMidLeft.TabIndex = 1;
            // 
            // lisQuery
            // 
            this.lisQuery.AllowDrop = true;
            this.lisQuery.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader13,
            this.ColumnHeader14});
            this.lisQuery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisQuery.EnableSort = true;
            this.lisQuery.EnableSortIcon = true;
            this.lisQuery.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisQuery.FullRowSelect = true;
            this.lisQuery.Location = new System.Drawing.Point(0, 14);
            this.lisQuery.Name = "lisQuery";
            this.lisQuery.Size = new System.Drawing.Size(218, 359);
            this.lisQuery.TabIndex = 0;
            this.lisQuery.UseCompatibleStateImageBehavior = false;
            this.lisQuery.View = System.Windows.Forms.View.Details;
            // 
            // ColumnHeader13
            // 
            this.ColumnHeader13.Text = "Query ID";
            this.ColumnHeader13.Width = 79;
            // 
            // ColumnHeader14
            // 
            this.ColumnHeader14.Text = "Query";
            this.ColumnHeader14.Width = 175;
            // 
            // lblEvent
            // 
            this.lblEvent.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblEvent.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblEvent.Location = new System.Drawing.Point(0, 0);
            this.lblEvent.Name = "lblEvent";
            this.lblEvent.Size = new System.Drawing.Size(218, 14);
            this.lblEvent.TabIndex = 0;
            this.lblEvent.Text = "Attached Query";
            // 
            // tbpViewQuery
            // 
            this.tbpViewQuery.Controls.Add(this.spdQuery);
            this.tbpViewQuery.Location = new System.Drawing.Point(4, 22);
            this.tbpViewQuery.Name = "tbpViewQuery";
            this.tbpViewQuery.Padding = new System.Windows.Forms.Padding(3);
            this.tbpViewQuery.Size = new System.Drawing.Size(492, 379);
            this.tbpViewQuery.TabIndex = 1;
            this.tbpViewQuery.Text = "View Query";
            // 
            // spdQuery
            // 
            this.spdQuery.AccessibleDescription = "spdQuery, Sheet1, Row 0, Column 0, ";
            this.spdQuery.BackColor = System.Drawing.SystemColors.Control;
            this.spdQuery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdQuery.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdQuery.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdQuery.HorizontalScrollBar.Name = "";
            this.spdQuery.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdQuery.HorizontalScrollBar.TabIndex = 2;
            this.spdQuery.Location = new System.Drawing.Point(3, 3);
            this.spdQuery.Name = "spdQuery";
            this.spdQuery.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdQuery_Sheet1});
            this.spdQuery.Size = new System.Drawing.Size(486, 373);
            this.spdQuery.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdQuery.TabIndex = 0;
            this.spdQuery.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdQuery.VerticalScrollBar.Name = "";
            this.spdQuery.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdQuery.VerticalScrollBar.TabIndex = 3;
            this.spdQuery.SetActiveViewport(0, -1, -1);
            // 
            // spdQuery_Sheet1
            // 
            this.spdQuery_Sheet1.Reset();
            spdQuery_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdQuery_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdQuery_Sheet1.ColumnCount = 4;
            spdQuery_Sheet1.RowCount = 0;
            this.spdQuery_Sheet1.ActiveColumnIndex = -1;
            this.spdQuery_Sheet1.ActiveRowIndex = -1;
            this.spdQuery_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdQuery_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdQuery_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdQuery_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdQuery_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Quary ID";
            this.spdQuery_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Query";
            this.spdQuery_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Data Type";
            this.spdQuery_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Valid Table";
            this.spdQuery_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdQuery_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdQuery_Sheet1.ColumnHeader.Rows.Get(0).Height = 32F;
            this.spdQuery_Sheet1.Columns.Get(1).Label = "Query";
            this.spdQuery_Sheet1.Columns.Get(1).Width = 240F;
            this.spdQuery_Sheet1.Columns.Get(2).Label = "Data Type";
            this.spdQuery_Sheet1.Columns.Get(2).Width = 40F;
            this.spdQuery_Sheet1.Columns.Get(3).Label = "Valid Table";
            this.spdQuery_Sheet1.Columns.Get(3).Width = 91F;
            this.spdQuery_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.ReadOnly;
            this.spdQuery_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdQuery_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdQuery_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdQuery_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdQuery_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdQuery_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // grpSheetType
            // 
            this.grpSheetType.Controls.Add(this.cdvSheetGrp10);
            this.grpSheetType.Controls.Add(this.lblSheetGrp10);
            this.grpSheetType.Controls.Add(this.cdvSheetGrp9);
            this.grpSheetType.Controls.Add(this.lblSheetGrp9);
            this.grpSheetType.Controls.Add(this.cdvSheetGrp8);
            this.grpSheetType.Controls.Add(this.lblSheetGrp8);
            this.grpSheetType.Controls.Add(this.cdvSheetGrp7);
            this.grpSheetType.Controls.Add(this.lblSheetGrp7);
            this.grpSheetType.Controls.Add(this.cdvSheetGrp6);
            this.grpSheetType.Controls.Add(this.lblSheetGrp6);
            this.grpSheetType.Controls.Add(this.cdvSheetGrp5);
            this.grpSheetType.Controls.Add(this.lblSheetGrp5);
            this.grpSheetType.Controls.Add(this.cdvSheetGrp4);
            this.grpSheetType.Controls.Add(this.lblSheetGrp4);
            this.grpSheetType.Controls.Add(this.cdvSheetGrp3);
            this.grpSheetType.Controls.Add(this.lblSheetGrp3);
            this.grpSheetType.Controls.Add(this.cdvSheetGrp2);
            this.grpSheetType.Controls.Add(this.lblSheetGrp2);
            this.grpSheetType.Controls.Add(this.cdvSheetGrp1);
            this.grpSheetType.Controls.Add(this.lblSheetGrp1);
            this.grpSheetType.Controls.Add(this.cdvSheetType);
            this.grpSheetType.Controls.Add(this.lblResType);
            this.grpSheetType.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpSheetType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpSheetType.Location = new System.Drawing.Point(0, 0);
            this.grpSheetType.Name = "grpSheetType";
            this.grpSheetType.Size = new System.Drawing.Size(500, 40);
            this.grpSheetType.TabIndex = 0;
            this.grpSheetType.TabStop = false;
            // 
            // cdvSheetGrp10
            // 
            this.cdvSheetGrp10.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvSheetGrp10.BorderHotColor = System.Drawing.Color.Black;
            this.cdvSheetGrp10.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvSheetGrp10.BtnToolTipText = "";
            this.cdvSheetGrp10.DescText = "";
            this.cdvSheetGrp10.DisplaySubItemIndex = -1;
            this.cdvSheetGrp10.DisplayText = "";
            this.cdvSheetGrp10.Focusing = null;
            this.cdvSheetGrp10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvSheetGrp10.Index = 0;
            this.cdvSheetGrp10.IsViewBtnImage = false;
            this.cdvSheetGrp10.Location = new System.Drawing.Point(349, 131);
            this.cdvSheetGrp10.MaxLength = 30;
            this.cdvSheetGrp10.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvSheetGrp10.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvSheetGrp10.Name = "cdvSheetGrp10";
            this.cdvSheetGrp10.ReadOnly = false;
            this.cdvSheetGrp10.SearchSubItemIndex = 0;
            this.cdvSheetGrp10.SelectedDescIndex = -1;
            this.cdvSheetGrp10.SelectedSubItemIndex = -1;
            this.cdvSheetGrp10.SelectionStart = 0;
            this.cdvSheetGrp10.Size = new System.Drawing.Size(139, 20);
            this.cdvSheetGrp10.SmallImageList = null;
            this.cdvSheetGrp10.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvSheetGrp10.TabIndex = 21;
            this.cdvSheetGrp10.TextBoxToolTipText = "";
            this.cdvSheetGrp10.TextBoxWidth = 139;
            this.cdvSheetGrp10.Visible = false;
            this.cdvSheetGrp10.VisibleButton = true;
            this.cdvSheetGrp10.VisibleColumnHeader = false;
            this.cdvSheetGrp10.VisibleDescription = false;
            this.cdvSheetGrp10.ButtonPress += new System.EventHandler(this.cdvSheetGrp_ButtonPress);
            // 
            // lblSheetGrp10
            // 
            this.lblSheetGrp10.AutoSize = true;
            this.lblSheetGrp10.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblSheetGrp10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSheetGrp10.Location = new System.Drawing.Point(257, 134);
            this.lblSheetGrp10.Name = "lblSheetGrp10";
            this.lblSheetGrp10.Size = new System.Drawing.Size(62, 13);
            this.lblSheetGrp10.TabIndex = 20;
            this.lblSheetGrp10.Text = "Sheet Type";
            this.lblSheetGrp10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSheetGrp10.Visible = false;
            // 
            // cdvSheetGrp9
            // 
            this.cdvSheetGrp9.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvSheetGrp9.BorderHotColor = System.Drawing.Color.Black;
            this.cdvSheetGrp9.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvSheetGrp9.BtnToolTipText = "";
            this.cdvSheetGrp9.DescText = "";
            this.cdvSheetGrp9.DisplaySubItemIndex = -1;
            this.cdvSheetGrp9.DisplayText = "";
            this.cdvSheetGrp9.Focusing = null;
            this.cdvSheetGrp9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvSheetGrp9.Index = 0;
            this.cdvSheetGrp9.IsViewBtnImage = false;
            this.cdvSheetGrp9.Location = new System.Drawing.Point(99, 131);
            this.cdvSheetGrp9.MaxLength = 30;
            this.cdvSheetGrp9.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvSheetGrp9.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvSheetGrp9.Name = "cdvSheetGrp9";
            this.cdvSheetGrp9.ReadOnly = false;
            this.cdvSheetGrp9.SearchSubItemIndex = 0;
            this.cdvSheetGrp9.SelectedDescIndex = -1;
            this.cdvSheetGrp9.SelectedSubItemIndex = -1;
            this.cdvSheetGrp9.SelectionStart = 0;
            this.cdvSheetGrp9.Size = new System.Drawing.Size(139, 20);
            this.cdvSheetGrp9.SmallImageList = null;
            this.cdvSheetGrp9.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvSheetGrp9.TabIndex = 19;
            this.cdvSheetGrp9.TextBoxToolTipText = "";
            this.cdvSheetGrp9.TextBoxWidth = 139;
            this.cdvSheetGrp9.Visible = false;
            this.cdvSheetGrp9.VisibleButton = true;
            this.cdvSheetGrp9.VisibleColumnHeader = false;
            this.cdvSheetGrp9.VisibleDescription = false;
            this.cdvSheetGrp9.ButtonPress += new System.EventHandler(this.cdvSheetGrp_ButtonPress);
            // 
            // lblSheetGrp9
            // 
            this.lblSheetGrp9.AutoSize = true;
            this.lblSheetGrp9.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblSheetGrp9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSheetGrp9.Location = new System.Drawing.Point(7, 134);
            this.lblSheetGrp9.Name = "lblSheetGrp9";
            this.lblSheetGrp9.Size = new System.Drawing.Size(62, 13);
            this.lblSheetGrp9.TabIndex = 18;
            this.lblSheetGrp9.Text = "Sheet Type";
            this.lblSheetGrp9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSheetGrp9.Visible = false;
            // 
            // cdvSheetGrp8
            // 
            this.cdvSheetGrp8.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvSheetGrp8.BorderHotColor = System.Drawing.Color.Black;
            this.cdvSheetGrp8.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvSheetGrp8.BtnToolTipText = "";
            this.cdvSheetGrp8.DescText = "";
            this.cdvSheetGrp8.DisplaySubItemIndex = -1;
            this.cdvSheetGrp8.DisplayText = "";
            this.cdvSheetGrp8.Focusing = null;
            this.cdvSheetGrp8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvSheetGrp8.Index = 0;
            this.cdvSheetGrp8.IsViewBtnImage = false;
            this.cdvSheetGrp8.Location = new System.Drawing.Point(349, 108);
            this.cdvSheetGrp8.MaxLength = 30;
            this.cdvSheetGrp8.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvSheetGrp8.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvSheetGrp8.Name = "cdvSheetGrp8";
            this.cdvSheetGrp8.ReadOnly = false;
            this.cdvSheetGrp8.SearchSubItemIndex = 0;
            this.cdvSheetGrp8.SelectedDescIndex = -1;
            this.cdvSheetGrp8.SelectedSubItemIndex = -1;
            this.cdvSheetGrp8.SelectionStart = 0;
            this.cdvSheetGrp8.Size = new System.Drawing.Size(139, 20);
            this.cdvSheetGrp8.SmallImageList = null;
            this.cdvSheetGrp8.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvSheetGrp8.TabIndex = 17;
            this.cdvSheetGrp8.TextBoxToolTipText = "";
            this.cdvSheetGrp8.TextBoxWidth = 139;
            this.cdvSheetGrp8.Visible = false;
            this.cdvSheetGrp8.VisibleButton = true;
            this.cdvSheetGrp8.VisibleColumnHeader = false;
            this.cdvSheetGrp8.VisibleDescription = false;
            this.cdvSheetGrp8.ButtonPress += new System.EventHandler(this.cdvSheetGrp_ButtonPress);
            // 
            // lblSheetGrp8
            // 
            this.lblSheetGrp8.AutoSize = true;
            this.lblSheetGrp8.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblSheetGrp8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSheetGrp8.Location = new System.Drawing.Point(257, 111);
            this.lblSheetGrp8.Name = "lblSheetGrp8";
            this.lblSheetGrp8.Size = new System.Drawing.Size(62, 13);
            this.lblSheetGrp8.TabIndex = 16;
            this.lblSheetGrp8.Text = "Sheet Type";
            this.lblSheetGrp8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSheetGrp8.Visible = false;
            // 
            // cdvSheetGrp7
            // 
            this.cdvSheetGrp7.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvSheetGrp7.BorderHotColor = System.Drawing.Color.Black;
            this.cdvSheetGrp7.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvSheetGrp7.BtnToolTipText = "";
            this.cdvSheetGrp7.DescText = "";
            this.cdvSheetGrp7.DisplaySubItemIndex = -1;
            this.cdvSheetGrp7.DisplayText = "";
            this.cdvSheetGrp7.Focusing = null;
            this.cdvSheetGrp7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvSheetGrp7.Index = 0;
            this.cdvSheetGrp7.IsViewBtnImage = false;
            this.cdvSheetGrp7.Location = new System.Drawing.Point(99, 108);
            this.cdvSheetGrp7.MaxLength = 30;
            this.cdvSheetGrp7.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvSheetGrp7.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvSheetGrp7.Name = "cdvSheetGrp7";
            this.cdvSheetGrp7.ReadOnly = false;
            this.cdvSheetGrp7.SearchSubItemIndex = 0;
            this.cdvSheetGrp7.SelectedDescIndex = -1;
            this.cdvSheetGrp7.SelectedSubItemIndex = -1;
            this.cdvSheetGrp7.SelectionStart = 0;
            this.cdvSheetGrp7.Size = new System.Drawing.Size(139, 20);
            this.cdvSheetGrp7.SmallImageList = null;
            this.cdvSheetGrp7.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvSheetGrp7.TabIndex = 15;
            this.cdvSheetGrp7.TextBoxToolTipText = "";
            this.cdvSheetGrp7.TextBoxWidth = 139;
            this.cdvSheetGrp7.Visible = false;
            this.cdvSheetGrp7.VisibleButton = true;
            this.cdvSheetGrp7.VisibleColumnHeader = false;
            this.cdvSheetGrp7.VisibleDescription = false;
            this.cdvSheetGrp7.ButtonPress += new System.EventHandler(this.cdvSheetGrp_ButtonPress);
            // 
            // lblSheetGrp7
            // 
            this.lblSheetGrp7.AutoSize = true;
            this.lblSheetGrp7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblSheetGrp7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSheetGrp7.Location = new System.Drawing.Point(7, 111);
            this.lblSheetGrp7.Name = "lblSheetGrp7";
            this.lblSheetGrp7.Size = new System.Drawing.Size(62, 13);
            this.lblSheetGrp7.TabIndex = 14;
            this.lblSheetGrp7.Text = "Sheet Type";
            this.lblSheetGrp7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSheetGrp7.Visible = false;
            // 
            // cdvSheetGrp6
            // 
            this.cdvSheetGrp6.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvSheetGrp6.BorderHotColor = System.Drawing.Color.Black;
            this.cdvSheetGrp6.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvSheetGrp6.BtnToolTipText = "";
            this.cdvSheetGrp6.DescText = "";
            this.cdvSheetGrp6.DisplaySubItemIndex = -1;
            this.cdvSheetGrp6.DisplayText = "";
            this.cdvSheetGrp6.Focusing = null;
            this.cdvSheetGrp6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvSheetGrp6.Index = 0;
            this.cdvSheetGrp6.IsViewBtnImage = false;
            this.cdvSheetGrp6.Location = new System.Drawing.Point(349, 85);
            this.cdvSheetGrp6.MaxLength = 30;
            this.cdvSheetGrp6.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvSheetGrp6.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvSheetGrp6.Name = "cdvSheetGrp6";
            this.cdvSheetGrp6.ReadOnly = false;
            this.cdvSheetGrp6.SearchSubItemIndex = 0;
            this.cdvSheetGrp6.SelectedDescIndex = -1;
            this.cdvSheetGrp6.SelectedSubItemIndex = -1;
            this.cdvSheetGrp6.SelectionStart = 0;
            this.cdvSheetGrp6.Size = new System.Drawing.Size(139, 20);
            this.cdvSheetGrp6.SmallImageList = null;
            this.cdvSheetGrp6.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvSheetGrp6.TabIndex = 13;
            this.cdvSheetGrp6.TextBoxToolTipText = "";
            this.cdvSheetGrp6.TextBoxWidth = 139;
            this.cdvSheetGrp6.Visible = false;
            this.cdvSheetGrp6.VisibleButton = true;
            this.cdvSheetGrp6.VisibleColumnHeader = false;
            this.cdvSheetGrp6.VisibleDescription = false;
            this.cdvSheetGrp6.ButtonPress += new System.EventHandler(this.cdvSheetGrp_ButtonPress);
            // 
            // lblSheetGrp6
            // 
            this.lblSheetGrp6.AutoSize = true;
            this.lblSheetGrp6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblSheetGrp6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSheetGrp6.Location = new System.Drawing.Point(257, 88);
            this.lblSheetGrp6.Name = "lblSheetGrp6";
            this.lblSheetGrp6.Size = new System.Drawing.Size(62, 13);
            this.lblSheetGrp6.TabIndex = 12;
            this.lblSheetGrp6.Text = "Sheet Type";
            this.lblSheetGrp6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSheetGrp6.Visible = false;
            // 
            // cdvSheetGrp5
            // 
            this.cdvSheetGrp5.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvSheetGrp5.BorderHotColor = System.Drawing.Color.Black;
            this.cdvSheetGrp5.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvSheetGrp5.BtnToolTipText = "";
            this.cdvSheetGrp5.DescText = "";
            this.cdvSheetGrp5.DisplaySubItemIndex = -1;
            this.cdvSheetGrp5.DisplayText = "";
            this.cdvSheetGrp5.Focusing = null;
            this.cdvSheetGrp5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvSheetGrp5.Index = 0;
            this.cdvSheetGrp5.IsViewBtnImage = false;
            this.cdvSheetGrp5.Location = new System.Drawing.Point(99, 85);
            this.cdvSheetGrp5.MaxLength = 30;
            this.cdvSheetGrp5.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvSheetGrp5.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvSheetGrp5.Name = "cdvSheetGrp5";
            this.cdvSheetGrp5.ReadOnly = false;
            this.cdvSheetGrp5.SearchSubItemIndex = 0;
            this.cdvSheetGrp5.SelectedDescIndex = -1;
            this.cdvSheetGrp5.SelectedSubItemIndex = -1;
            this.cdvSheetGrp5.SelectionStart = 0;
            this.cdvSheetGrp5.Size = new System.Drawing.Size(139, 20);
            this.cdvSheetGrp5.SmallImageList = null;
            this.cdvSheetGrp5.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvSheetGrp5.TabIndex = 11;
            this.cdvSheetGrp5.TextBoxToolTipText = "";
            this.cdvSheetGrp5.TextBoxWidth = 139;
            this.cdvSheetGrp5.Visible = false;
            this.cdvSheetGrp5.VisibleButton = true;
            this.cdvSheetGrp5.VisibleColumnHeader = false;
            this.cdvSheetGrp5.VisibleDescription = false;
            this.cdvSheetGrp5.ButtonPress += new System.EventHandler(this.cdvSheetGrp_ButtonPress);
            // 
            // lblSheetGrp5
            // 
            this.lblSheetGrp5.AutoSize = true;
            this.lblSheetGrp5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblSheetGrp5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSheetGrp5.Location = new System.Drawing.Point(7, 88);
            this.lblSheetGrp5.Name = "lblSheetGrp5";
            this.lblSheetGrp5.Size = new System.Drawing.Size(62, 13);
            this.lblSheetGrp5.TabIndex = 10;
            this.lblSheetGrp5.Text = "Sheet Type";
            this.lblSheetGrp5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSheetGrp5.Visible = false;
            // 
            // cdvSheetGrp4
            // 
            this.cdvSheetGrp4.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvSheetGrp4.BorderHotColor = System.Drawing.Color.Black;
            this.cdvSheetGrp4.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvSheetGrp4.BtnToolTipText = "";
            this.cdvSheetGrp4.DescText = "";
            this.cdvSheetGrp4.DisplaySubItemIndex = -1;
            this.cdvSheetGrp4.DisplayText = "";
            this.cdvSheetGrp4.Focusing = null;
            this.cdvSheetGrp4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvSheetGrp4.Index = 0;
            this.cdvSheetGrp4.IsViewBtnImage = false;
            this.cdvSheetGrp4.Location = new System.Drawing.Point(349, 61);
            this.cdvSheetGrp4.MaxLength = 30;
            this.cdvSheetGrp4.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvSheetGrp4.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvSheetGrp4.Name = "cdvSheetGrp4";
            this.cdvSheetGrp4.ReadOnly = false;
            this.cdvSheetGrp4.SearchSubItemIndex = 0;
            this.cdvSheetGrp4.SelectedDescIndex = -1;
            this.cdvSheetGrp4.SelectedSubItemIndex = -1;
            this.cdvSheetGrp4.SelectionStart = 0;
            this.cdvSheetGrp4.Size = new System.Drawing.Size(139, 20);
            this.cdvSheetGrp4.SmallImageList = null;
            this.cdvSheetGrp4.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvSheetGrp4.TabIndex = 9;
            this.cdvSheetGrp4.TextBoxToolTipText = "";
            this.cdvSheetGrp4.TextBoxWidth = 139;
            this.cdvSheetGrp4.Visible = false;
            this.cdvSheetGrp4.VisibleButton = true;
            this.cdvSheetGrp4.VisibleColumnHeader = false;
            this.cdvSheetGrp4.VisibleDescription = false;
            this.cdvSheetGrp4.ButtonPress += new System.EventHandler(this.cdvSheetGrp_ButtonPress);
            // 
            // lblSheetGrp4
            // 
            this.lblSheetGrp4.AutoSize = true;
            this.lblSheetGrp4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblSheetGrp4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSheetGrp4.Location = new System.Drawing.Point(257, 64);
            this.lblSheetGrp4.Name = "lblSheetGrp4";
            this.lblSheetGrp4.Size = new System.Drawing.Size(62, 13);
            this.lblSheetGrp4.TabIndex = 8;
            this.lblSheetGrp4.Text = "Sheet Type";
            this.lblSheetGrp4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSheetGrp4.Visible = false;
            // 
            // cdvSheetGrp3
            // 
            this.cdvSheetGrp3.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvSheetGrp3.BorderHotColor = System.Drawing.Color.Black;
            this.cdvSheetGrp3.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvSheetGrp3.BtnToolTipText = "";
            this.cdvSheetGrp3.DescText = "";
            this.cdvSheetGrp3.DisplaySubItemIndex = -1;
            this.cdvSheetGrp3.DisplayText = "";
            this.cdvSheetGrp3.Focusing = null;
            this.cdvSheetGrp3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvSheetGrp3.Index = 0;
            this.cdvSheetGrp3.IsViewBtnImage = false;
            this.cdvSheetGrp3.Location = new System.Drawing.Point(99, 61);
            this.cdvSheetGrp3.MaxLength = 30;
            this.cdvSheetGrp3.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvSheetGrp3.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvSheetGrp3.Name = "cdvSheetGrp3";
            this.cdvSheetGrp3.ReadOnly = false;
            this.cdvSheetGrp3.SearchSubItemIndex = 0;
            this.cdvSheetGrp3.SelectedDescIndex = -1;
            this.cdvSheetGrp3.SelectedSubItemIndex = -1;
            this.cdvSheetGrp3.SelectionStart = 0;
            this.cdvSheetGrp3.Size = new System.Drawing.Size(139, 20);
            this.cdvSheetGrp3.SmallImageList = null;
            this.cdvSheetGrp3.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvSheetGrp3.TabIndex = 0;
            this.cdvSheetGrp3.TextBoxToolTipText = "";
            this.cdvSheetGrp3.TextBoxWidth = 139;
            this.cdvSheetGrp3.Visible = false;
            this.cdvSheetGrp3.VisibleButton = true;
            this.cdvSheetGrp3.VisibleColumnHeader = false;
            this.cdvSheetGrp3.VisibleDescription = false;
            this.cdvSheetGrp3.ButtonPress += new System.EventHandler(this.cdvSheetGrp_ButtonPress);
            // 
            // lblSheetGrp3
            // 
            this.lblSheetGrp3.AutoSize = true;
            this.lblSheetGrp3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblSheetGrp3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSheetGrp3.Location = new System.Drawing.Point(7, 64);
            this.lblSheetGrp3.Name = "lblSheetGrp3";
            this.lblSheetGrp3.Size = new System.Drawing.Size(62, 13);
            this.lblSheetGrp3.TabIndex = 6;
            this.lblSheetGrp3.Text = "Sheet Type";
            this.lblSheetGrp3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSheetGrp3.Visible = false;
            // 
            // cdvSheetGrp2
            // 
            this.cdvSheetGrp2.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvSheetGrp2.BorderHotColor = System.Drawing.Color.Black;
            this.cdvSheetGrp2.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvSheetGrp2.BtnToolTipText = "";
            this.cdvSheetGrp2.DescText = "";
            this.cdvSheetGrp2.DisplaySubItemIndex = -1;
            this.cdvSheetGrp2.DisplayText = "";
            this.cdvSheetGrp2.Focusing = null;
            this.cdvSheetGrp2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvSheetGrp2.Index = 0;
            this.cdvSheetGrp2.IsViewBtnImage = false;
            this.cdvSheetGrp2.Location = new System.Drawing.Point(349, 38);
            this.cdvSheetGrp2.MaxLength = 30;
            this.cdvSheetGrp2.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvSheetGrp2.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvSheetGrp2.Name = "cdvSheetGrp2";
            this.cdvSheetGrp2.ReadOnly = false;
            this.cdvSheetGrp2.SearchSubItemIndex = 0;
            this.cdvSheetGrp2.SelectedDescIndex = -1;
            this.cdvSheetGrp2.SelectedSubItemIndex = -1;
            this.cdvSheetGrp2.SelectionStart = 0;
            this.cdvSheetGrp2.Size = new System.Drawing.Size(139, 20);
            this.cdvSheetGrp2.SmallImageList = null;
            this.cdvSheetGrp2.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvSheetGrp2.TabIndex = 5;
            this.cdvSheetGrp2.TextBoxToolTipText = "";
            this.cdvSheetGrp2.TextBoxWidth = 139;
            this.cdvSheetGrp2.Visible = false;
            this.cdvSheetGrp2.VisibleButton = true;
            this.cdvSheetGrp2.VisibleColumnHeader = false;
            this.cdvSheetGrp2.VisibleDescription = false;
            this.cdvSheetGrp2.ButtonPress += new System.EventHandler(this.cdvSheetGrp_ButtonPress);
            // 
            // lblSheetGrp2
            // 
            this.lblSheetGrp2.AutoSize = true;
            this.lblSheetGrp2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblSheetGrp2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSheetGrp2.Location = new System.Drawing.Point(257, 41);
            this.lblSheetGrp2.Name = "lblSheetGrp2";
            this.lblSheetGrp2.Size = new System.Drawing.Size(62, 13);
            this.lblSheetGrp2.TabIndex = 4;
            this.lblSheetGrp2.Text = "Sheet Type";
            this.lblSheetGrp2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSheetGrp2.Visible = false;
            // 
            // cdvSheetGrp1
            // 
            this.cdvSheetGrp1.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvSheetGrp1.BorderHotColor = System.Drawing.Color.Black;
            this.cdvSheetGrp1.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvSheetGrp1.BtnToolTipText = "";
            this.cdvSheetGrp1.DescText = "";
            this.cdvSheetGrp1.DisplaySubItemIndex = -1;
            this.cdvSheetGrp1.DisplayText = "";
            this.cdvSheetGrp1.Focusing = null;
            this.cdvSheetGrp1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvSheetGrp1.Index = 0;
            this.cdvSheetGrp1.IsViewBtnImage = false;
            this.cdvSheetGrp1.Location = new System.Drawing.Point(99, 38);
            this.cdvSheetGrp1.MaxLength = 30;
            this.cdvSheetGrp1.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvSheetGrp1.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvSheetGrp1.Name = "cdvSheetGrp1";
            this.cdvSheetGrp1.ReadOnly = false;
            this.cdvSheetGrp1.SearchSubItemIndex = 0;
            this.cdvSheetGrp1.SelectedDescIndex = -1;
            this.cdvSheetGrp1.SelectedSubItemIndex = -1;
            this.cdvSheetGrp1.SelectionStart = 0;
            this.cdvSheetGrp1.Size = new System.Drawing.Size(139, 20);
            this.cdvSheetGrp1.SmallImageList = null;
            this.cdvSheetGrp1.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvSheetGrp1.TabIndex = 3;
            this.cdvSheetGrp1.TextBoxToolTipText = "";
            this.cdvSheetGrp1.TextBoxWidth = 139;
            this.cdvSheetGrp1.Visible = false;
            this.cdvSheetGrp1.VisibleButton = true;
            this.cdvSheetGrp1.VisibleColumnHeader = false;
            this.cdvSheetGrp1.VisibleDescription = false;
            this.cdvSheetGrp1.ButtonPress += new System.EventHandler(this.cdvSheetGrp_ButtonPress);
            // 
            // lblSheetGrp1
            // 
            this.lblSheetGrp1.AutoSize = true;
            this.lblSheetGrp1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblSheetGrp1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSheetGrp1.Location = new System.Drawing.Point(7, 41);
            this.lblSheetGrp1.Name = "lblSheetGrp1";
            this.lblSheetGrp1.Size = new System.Drawing.Size(62, 13);
            this.lblSheetGrp1.TabIndex = 2;
            this.lblSheetGrp1.Text = "Sheet Type";
            this.lblSheetGrp1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSheetGrp1.Visible = false;
            // 
            // cdvSheetType
            // 
            this.cdvSheetType.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvSheetType.BorderHotColor = System.Drawing.Color.Black;
            this.cdvSheetType.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvSheetType.BtnToolTipText = "";
            this.cdvSheetType.DescText = "";
            this.cdvSheetType.DisplaySubItemIndex = -1;
            this.cdvSheetType.DisplayText = "";
            this.cdvSheetType.Focusing = null;
            this.cdvSheetType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvSheetType.Index = 0;
            this.cdvSheetType.IsViewBtnImage = false;
            this.cdvSheetType.Location = new System.Drawing.Point(99, 14);
            this.cdvSheetType.MaxLength = 20;
            this.cdvSheetType.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvSheetType.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvSheetType.Name = "cdvSheetType";
            this.cdvSheetType.ReadOnly = false;
            this.cdvSheetType.SearchSubItemIndex = 0;
            this.cdvSheetType.SelectedDescIndex = -1;
            this.cdvSheetType.SelectedSubItemIndex = -1;
            this.cdvSheetType.SelectionStart = 0;
            this.cdvSheetType.Size = new System.Drawing.Size(139, 20);
            this.cdvSheetType.SmallImageList = null;
            this.cdvSheetType.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvSheetType.TabIndex = 1;
            this.cdvSheetType.TextBoxToolTipText = "";
            this.cdvSheetType.TextBoxWidth = 139;
            this.cdvSheetType.VisibleButton = true;
            this.cdvSheetType.VisibleColumnHeader = false;
            this.cdvSheetType.VisibleDescription = false;
            this.cdvSheetType.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvSheetType_SelectedItemChanged);
            this.cdvSheetType.ButtonPress += new System.EventHandler(this.cdvSheetType_ButtonPress);
            // 
            // lblResType
            // 
            this.lblResType.AutoSize = true;
            this.lblResType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblResType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResType.Location = new System.Drawing.Point(7, 16);
            this.lblResType.Name = "lblResType";
            this.lblResType.Size = new System.Drawing.Size(65, 13);
            this.lblResType.TabIndex = 0;
            this.lblResType.Text = "Check Type";
            this.lblResType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grpFuncGroup
            // 
            this.grpFuncGroup.Controls.Add(this.cdvGrpSheetType);
            this.grpFuncGroup.Controls.Add(this.lblGrpResType);
            this.grpFuncGroup.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpFuncGroup.Location = new System.Drawing.Point(3, 3);
            this.grpFuncGroup.Name = "grpFuncGroup";
            this.grpFuncGroup.Size = new System.Drawing.Size(229, 40);
            this.grpFuncGroup.TabIndex = 0;
            this.grpFuncGroup.TabStop = false;
            // 
            // cdvGrpSheetType
            // 
            this.cdvGrpSheetType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cdvGrpSheetType.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvGrpSheetType.BorderHotColor = System.Drawing.Color.Black;
            this.cdvGrpSheetType.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvGrpSheetType.BtnToolTipText = "";
            this.cdvGrpSheetType.DescText = "";
            this.cdvGrpSheetType.DisplaySubItemIndex = -1;
            this.cdvGrpSheetType.DisplayText = "";
            this.cdvGrpSheetType.Focusing = null;
            this.cdvGrpSheetType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvGrpSheetType.Index = 0;
            this.cdvGrpSheetType.IsViewBtnImage = false;
            this.cdvGrpSheetType.Location = new System.Drawing.Point(88, 12);
            this.cdvGrpSheetType.MaxLength = 20;
            this.cdvGrpSheetType.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvGrpSheetType.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvGrpSheetType.Name = "cdvGrpSheetType";
            this.cdvGrpSheetType.ReadOnly = false;
            this.cdvGrpSheetType.SearchSubItemIndex = 0;
            this.cdvGrpSheetType.SelectedDescIndex = -1;
            this.cdvGrpSheetType.SelectedSubItemIndex = -1;
            this.cdvGrpSheetType.SelectionStart = 0;
            this.cdvGrpSheetType.Size = new System.Drawing.Size(136, 20);
            this.cdvGrpSheetType.SmallImageList = null;
            this.cdvGrpSheetType.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvGrpSheetType.TabIndex = 1;
            this.cdvGrpSheetType.TextBoxToolTipText = "";
            this.cdvGrpSheetType.TextBoxWidth = 136;
            this.cdvGrpSheetType.VisibleButton = true;
            this.cdvGrpSheetType.VisibleColumnHeader = false;
            this.cdvGrpSheetType.VisibleDescription = false;
            this.cdvGrpSheetType.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvGrpSheetType_SelectedItemChanged);
            this.cdvGrpSheetType.ButtonPress += new System.EventHandler(this.cdvGrpSheetType_ButtonPress);
            // 
            // lblGrpResType
            // 
            this.lblGrpResType.AutoSize = true;
            this.lblGrpResType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblGrpResType.Location = new System.Drawing.Point(5, 14);
            this.lblGrpResType.Name = "lblGrpResType";
            this.lblGrpResType.Size = new System.Drawing.Size(65, 13);
            this.lblGrpResType.TabIndex = 0;
            this.lblGrpResType.Text = "Check Type";
            this.lblGrpResType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmRASSetupAttachQueryToCheck
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Name = "frmRASSetupAttachQueryToCheck";
            this.Text = "Attach Query To Check List";
            this.Activated += new System.EventHandler(this.frmRASSetupSheet_Activated);
            this.Load += new System.EventHandler(this.frmRASSetupSheet_Load);
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
            this.tabQuery.ResumeLayout(false);
            this.tbpAttachQuery.ResumeLayout(false);
            this.pnlEventMid.ResumeLayout(false);
            this.pnlEventMidMid.ResumeLayout(false);
            this.pnlEventMidRight.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvQryType)).EndInit();
            this.pnlEventMidLeft.ResumeLayout(false);
            this.tbpViewQuery.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdQuery_Sheet1)).EndInit();
            this.grpSheetType.ResumeLayout(false);
            this.grpSheetType.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvSheetGrp10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvSheetGrp9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvSheetGrp8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvSheetGrp7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvSheetGrp6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvSheetGrp5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvSheetGrp4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvSheetGrp3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvSheetGrp2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvSheetGrp1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvSheetType)).EndInit();
            this.grpFuncGroup.ResumeLayout(false);
            this.grpFuncGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGrpSheetType)).EndInit();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Constant Definition "

        private const int ID_COL = 0;
        private const int QUERY_COL = 1;
        private const int TYPE_COL = 2;
        private const int TABLE_COL = 3;
        
        #endregion
        
        #region " Variable Definition "
        
        bool b_load_flag;
        
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
                    txtSheetName.Text = "";
                    txtDesc.Text = "";
                    cdvSheetType.Text = "";
                }
            }
            catch (Exception)
            {
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
            
            switch (MPCF.Trim(FuncName))
            {
                case "Update_Function":

                    if (MPCF.CheckValue(txtSheetName, 1) == false) return false;

                    switch (ProcStep)
                    {
                        case MPGC.MP_STEP_UPDATE:
                            if (MPCF.CheckValue(cdvSheetType, 1) == false) return false;
                            break;
                            
                        case MPGC.MP_STEP_DELETE:
                            
                            break;
                            
                    }
                    break;
                    
            }
            
            return true;
            
        }
        
        //
        // View_Attached_Query()
        //       - View General Code Definition
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool View_Attached_Query()
        {
            TRSNode in_node = new TRSNode("View_Attached_Query_In");
            TRSNode out_node;
       
            ListViewItem itmX;
            int RowCount = 0;
            MPCF.ClearList(spdQuery);

            
            try
            {
                MPCF.FieldClear(pnlRight);

                txtSheetName.Text = lisSheet.SelectedItems[0].Text;
                    
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("SHEET_NAME", txtSheetName.Text);
                in_node.AddInt("NEXT_SEQ", 0);

                MPCF.InitListView(lisQuery);

                do
                {
                    out_node = new TRSNode("View_Attached_Query_Out");

                    if (MPCR.CallService("RAS", "RAS_View_Sheet", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    txtDesc.Text = out_node.GetString("SHEET_DESC");
                    cdvSheetType.Text = out_node.GetString("SHEET_TYPE");

                    cdvSheetGrp1.Text = out_node.GetString("SHEET_GRP_1");
                    cdvSheetGrp2.Text = out_node.GetString("SHEET_GRP_2");
                    cdvSheetGrp3.Text = out_node.GetString("SHEET_GRP_3");
                    cdvSheetGrp4.Text = out_node.GetString("SHEET_GRP_4");
                    cdvSheetGrp5.Text = out_node.GetString("SHEET_GRP_5");
                    cdvSheetGrp6.Text = out_node.GetString("SHEET_GRP_6");
                    cdvSheetGrp7.Text = out_node.GetString("SHEET_GRP_7");
                    cdvSheetGrp8.Text = out_node.GetString("SHEET_GRP_8");
                    cdvSheetGrp9.Text = out_node.GetString("SHEET_GRP_9");
                    cdvSheetGrp10.Text = out_node.GetString("SHEET_GRP_10");


                    if (spdQuery.Sheets[0].RowCount < out_node.GetList(0).Count)
                    {
                        spdQuery.Sheets[0].RowCount = out_node.GetList(0).Count;
                    }
                    else
                    {
                        spdQuery.Sheets[0].RowCount += out_node.GetList(0).Count;
                    }

                    for (int i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        itmX = new ListViewItem(MPCF.Trim(out_node.GetList(0)[i].GetString("DATA_CODE")), (int)SMALLICON_INDEX.IDX_MESSAGE);
                        itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("SHEET_DATA")));
                        lisQuery.Items.Add(itmX);

                        spdQuery.Sheets[0].SetValue(RowCount, ID_COL, MPCF.Trim(out_node.GetList(0)[i].GetString("DATA_CODE")));
                        spdQuery.Sheets[0].SetValue(RowCount, QUERY_COL, MPCF.Trim(out_node.GetList(0)[i].GetString("SHEET_DATA")).Replace("\r\n", " "));
                        spdQuery.Sheets[0].SetValue(RowCount, TYPE_COL, MPCF.Trim(out_node.GetList(0)[i].GetChar("RESULT_TYPE")));
                        spdQuery.Sheets[0].SetValue(RowCount, TABLE_COL, MPCF.Trim(out_node.GetList(0)[i].GetString("CHECK_VALUE")));

                        RowCount++;
                    }
                    in_node.SetInt("NEXT_SEQ", out_node.GetInt("NEXT_SEQ"));
                   
                  } while (in_node.GetInt("NEXT_SEQ") > 0 );


                itmX = lisQuery.Items.Insert(lisQuery.Items.Count, "Add here...", (int)SMALLICON_INDEX.IDX_MESSAGE);
                itmX.SubItems.Add("");
                itmX.SubItems.Add("");
                itmX.SubItems.Add("");
                //itmX = new ListViewItem("Add here...", (int)SMALLICON_INDEX.IDX_MESSAGE);
                //lisQuery.Items.Add(itmX);

                if (MPCF.Trim(cdvSheetType.Text) != "")
                {
                    View_Sheet_Group(MPCF.Trim(cdvSheetType.Text));

                    cdvSheetGrp1.Text = out_node.GetString("SHEET_GRP_1");
                    cdvSheetGrp2.Text = out_node.GetString("SHEET_GRP_2");
                    cdvSheetGrp3.Text = out_node.GetString("SHEET_GRP_3");
                    cdvSheetGrp4.Text = out_node.GetString("SHEET_GRP_4");
                    cdvSheetGrp5.Text = out_node.GetString("SHEET_GRP_5");
                    cdvSheetGrp6.Text = out_node.GetString("SHEET_GRP_6");
                    cdvSheetGrp7.Text = out_node.GetString("SHEET_GRP_7");
                    cdvSheetGrp8.Text = out_node.GetString("SHEET_GRP_8");
                    cdvSheetGrp9.Text = out_node.GetString("SHEET_GRP_9");
                    cdvSheetGrp10.Text = out_node.GetString("SHEET_GRP_10");

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
        // Update_Function()
        //       - Create/Update/Delete PM Sheet Definition
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String ("1" - Create, "2" - Update, "3" - Delete)
        //
        private bool Update_Function(char ProcStep)
        {
            ListViewItem itm;
            int idx;

            TRSNode in_node = new TRSNode("Update_Sheet_In");
            TRSNode out_node = new TRSNode("Cmn_Out");
            TRSNode list;
            
            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;

                in_node.AddString("SHEET_NAME", txtSheetName.Text);
                in_node.AddString("SHEET_DESC", txtDesc.Text);
                in_node.AddString("SHEET_TYPE", cdvSheetType.Text);
                in_node.AddString("SHEET_GRP_1", cdvSheetGrp1.Text);
                in_node.AddString("SHEET_GRP_2", cdvSheetGrp2.Text);
                in_node.AddString("SHEET_GRP_3", cdvSheetGrp3.Text);
                in_node.AddString("SHEET_GRP_4", cdvSheetGrp4.Text);
                in_node.AddString("SHEET_GRP_5", cdvSheetGrp5.Text);
                in_node.AddString("SHEET_GRP_6", cdvSheetGrp6.Text);
                in_node.AddString("SHEET_GRP_7", cdvSheetGrp7.Text);
                in_node.AddString("SHEET_GRP_8", cdvSheetGrp8.Text);
                in_node.AddString("SHEET_GRP_9", cdvSheetGrp9.Text);
                in_node.AddString("SHEET_GRP_10", cdvSheetGrp10.Text);

                for (int i = 0; i < lisQuery.Items.Count - 1; i++)
                {
                    if (MPCF.Trim(lisQuery.Items[i].Text) == "Add here...")
                        continue;

                    list = in_node.AddNode("DATA_LIST");

                    list.AddInt("DATA_SEQ", i + 1);
                    list.AddString("DATA_CODE", MPCF.Trim(lisQuery.Items[i].Text));
                }


                if (MPCR.CallService("RAS", "RAS_Update_Sheet", in_node, ref out_node) == false)
                {
                    return false;
                }
                            
                if (MPGV.gbListAutoRefresh == false)
                {
                    if (ProcStep == MPGC.MP_STEP_CREATE)
                    {
                        itm = lisSheet.Items.Add(txtSheetName.Text, (int)SMALLICON_INDEX.IDX_FUNCTION);
                        itm.SubItems.Add(txtDesc.Text);
                        itm.Selected = true;
                        lisSheet.Sorting = SortOrder.Ascending;
                        lisSheet.Sort();
                        itm.EnsureVisible();
                    }
                    else if (ProcStep == MPGC.MP_STEP_UPDATE)
                    {
                        if (MPCF.FindListItem(lisSheet, MPCF.Trim(txtSheetName.Text), false) == true)
                        {
                            lisSheet.SelectedItems[0].SubItems[1].Text = MPCF.Trim(txtDesc.Text);
                        }
                    }
                    else if (ProcStep == MPGC.MP_STEP_DELETE)
                    {
                        idx = MPCF.FindListItemIndex(lisSheet, MPCF.Trim(txtSheetName.Text), false);
                        if (idx != - 1)
                        {
                            lisSheet.Items[idx].Remove();
                        }
                    }
                    lblDataCount.Text = lisSheet.Items.Count.ToString();
                }
                MPCR.ShowSuccessMsg(out_node);
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
            
            return true;
            
        }
        
        //
        // View_Sheet_Group()
        //       - View Sheet Group
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal Sheet_Type As String
        //
        private bool View_Sheet_Group(string Sheet_Type)
        {
            int i;

            lblSheetGrp1.Visible = false;
            lblSheetGrp2.Visible = false;
            lblSheetGrp3.Visible = false;
            lblSheetGrp4.Visible = false;
            lblSheetGrp5.Visible = false;
            lblSheetGrp6.Visible = false;
            lblSheetGrp7.Visible = false;
            lblSheetGrp8.Visible = false;
            lblSheetGrp9.Visible = false;
            lblSheetGrp10.Visible = false;

            cdvSheetGrp1.Visible = false;
            cdvSheetGrp2.Visible = false;
            cdvSheetGrp3.Visible = false;
            cdvSheetGrp4.Visible = false;
            cdvSheetGrp5.Visible = false;
            cdvSheetGrp6.Visible = false;
            cdvSheetGrp7.Visible = false;
            cdvSheetGrp8.Visible = false;
            cdvSheetGrp9.Visible = false;
            cdvSheetGrp10.Visible = false;

            cdvSheetGrp1.VisibleButton = false;
            cdvSheetGrp2.VisibleButton = false;
            cdvSheetGrp3.VisibleButton = false;
            cdvSheetGrp4.VisibleButton = false;
            cdvSheetGrp5.VisibleButton = false;
            cdvSheetGrp6.VisibleButton = false;
            cdvSheetGrp7.VisibleButton = false;
            cdvSheetGrp8.VisibleButton = false;
            cdvSheetGrp9.VisibleButton = false;
            cdvSheetGrp10.VisibleButton = false;

            cdvSheetGrp1.Text = "";
            cdvSheetGrp2.Text = "";
            cdvSheetGrp3.Text = "";
            cdvSheetGrp4.Text = "";
            cdvSheetGrp5.Text = "";
            cdvSheetGrp6.Text = "";
            cdvSheetGrp7.Text = "";
            cdvSheetGrp8.Text = "";
            cdvSheetGrp9.Text = "";
            cdvSheetGrp10.Text = "";

            grpSheetType.Height = 41;

            if (MPCF.Trim(Sheet_Type) == "")
                return true;

            try
            {
                TRSNode in_node = new TRSNode("View_Sheet_Type_Def_In");
                TRSNode out_node = new TRSNode("View_Sheet_Type_Def_Out");

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("SHEET_TYPE", Sheet_Type);
                in_node.AddChar("TYPE_FLAG", 'S');


                if (MPCR.CallService("RAS", "RAS_View_Sheet_Type_Def", in_node, ref out_node) == false)
                {
                    return false;
                }
               
                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    switch (i)
                    {
                        case 0:
                            lblSheetGrp1.Visible = true;
                            lblSheetGrp1.Text = MPCF.Trim(out_node.GetList(0)[i].GetString("CAT_CAPTION"));
                            cdvSheetGrp1.Visible = true;

                            if (cdvSheetGrp1.Visible == true)
                            {
                                if (MPCF.Trim(out_node.GetList(0)[i].GetString("CAT_TABLE")) != "")
                                {
                                    cdvSheetGrp1.VisibleButton = true;
                                    cdvSheetGrp1.Tag = MPCF.Trim(out_node.GetList(0)[i].GetString("CAT_TABLE"));
                                }
                            }
                            break;
                        case 1:
                            lblSheetGrp2.Visible = true;
                            lblSheetGrp2.Text = MPCF.Trim(out_node.GetList(0)[i].GetString("CAT_CAPTION"));
                            cdvSheetGrp2.Visible = true;

                            if (cdvSheetGrp2.Visible == true)
                            {
                                if (MPCF.Trim(out_node.GetList(0)[i].GetString("CAT_TABLE")) != "")
                                {
                                    cdvSheetGrp2.VisibleButton = true;
                                    cdvSheetGrp2.Tag = MPCF.Trim(out_node.GetList(0)[i].GetString("CAT_TABLE"));
                                }
                            }
                            break;
                        case 2:
                            lblSheetGrp3.Visible = true;
                            lblSheetGrp3.Text = MPCF.Trim(out_node.GetList(0)[i].GetString("CAT_CAPTION"));
                            cdvSheetGrp3.Visible = true;

                            if (cdvSheetGrp3.Visible == true)
                            {
                                if (MPCF.Trim(out_node.GetList(0)[i].GetString("CAT_TABLE")) != "")
                                {
                                    cdvSheetGrp3.VisibleButton = true;
                                    cdvSheetGrp3.Tag = MPCF.Trim(out_node.GetList(0)[i].GetString("CAT_TABLE"));
                                }
                            }
                            break;
                        case 3:
                            lblSheetGrp4.Visible = true;
                            lblSheetGrp4.Text = MPCF.Trim(out_node.GetList(0)[i].GetString("CAT_CAPTION"));
                            cdvSheetGrp4.Visible = true;

                            if (cdvSheetGrp4.Visible == true)
                            {
                                if (MPCF.Trim(out_node.GetList(0)[i].GetString("CAT_TABLE")) != "")
                                {
                                    cdvSheetGrp4.VisibleButton = true;
                                    cdvSheetGrp4.Tag = MPCF.Trim(out_node.GetList(0)[i].GetString("CAT_TABLE"));
                                }
                            }
                            break;
                        case 4:
                            lblSheetGrp5.Visible = true;
                            lblSheetGrp5.Text = MPCF.Trim(out_node.GetList(0)[i].GetString("CAT_CAPTION"));
                            cdvSheetGrp5.Visible = true;

                            if (cdvSheetGrp5.Visible == true)
                            {
                                if (MPCF.Trim(out_node.GetList(0)[i].GetString("CAT_TABLE")) != "")
                                {
                                    cdvSheetGrp5.VisibleButton = true;
                                    cdvSheetGrp5.Tag = MPCF.Trim(out_node.GetList(0)[i].GetString("CAT_TABLE"));
                                }
                            }
                            break;
                        case 5:
                            lblSheetGrp6.Visible = true;
                            lblSheetGrp6.Text = MPCF.Trim(out_node.GetList(0)[i].GetString("CAT_CAPTION"));
                            cdvSheetGrp6.Visible = true;

                            if (cdvSheetGrp6.Visible == true)
                            {
                                if (MPCF.Trim(out_node.GetList(0)[i].GetString("CAT_TABLE")) != "")
                                {
                                    cdvSheetGrp6.VisibleButton = true;
                                    cdvSheetGrp6.Tag = MPCF.Trim(out_node.GetList(0)[i].GetString("CAT_TABLE"));
                                }
                            }
                            break;
                        case 6:
                            lblSheetGrp7.Visible = true;
                            lblSheetGrp7.Text = MPCF.Trim(out_node.GetList(0)[i].GetString("CAT_CAPTION"));
                            cdvSheetGrp7.Visible = true;

                            if (cdvSheetGrp7.Visible == true)
                            {
                                if (MPCF.Trim(out_node.GetList(0)[i].GetString("CAT_TABLE")) != "")
                                {
                                    cdvSheetGrp7.VisibleButton = true;
                                    cdvSheetGrp7.Tag = MPCF.Trim(out_node.GetList(0)[i].GetString("CAT_TABLE"));
                                }
                            }
                            break;
                        case 7:
                            lblSheetGrp8.Visible = true;
                            lblSheetGrp8.Text = MPCF.Trim(out_node.GetList(0)[i].GetString("CAT_CAPTION"));
                            cdvSheetGrp8.Visible = true;

                            if (cdvSheetGrp8.Visible == true)
                            {
                                if (MPCF.Trim(out_node.GetList(0)[i].GetString("CAT_TABLE")) != "")
                                {
                                    cdvSheetGrp8.VisibleButton = true;
                                    cdvSheetGrp8.Tag = MPCF.Trim(out_node.GetList(0)[i].GetString("CAT_TABLE"));
                                }
                            }
                            break;
                        case 8:
                            lblSheetGrp9.Visible = true;
                            lblSheetGrp9.Text = MPCF.Trim(out_node.GetList(0)[i].GetString("CAT_CAPTION"));
                            cdvSheetGrp9.Visible = true;

                            if (cdvSheetGrp9.Visible == true)
                            {
                                if (MPCF.Trim(out_node.GetList(0)[i].GetString("CAT_TABLE")) != "")
                                {
                                    cdvSheetGrp9.VisibleButton = true;
                                    cdvSheetGrp9.Tag = MPCF.Trim(out_node.GetList(0)[i].GetString("CAT_TABLE"));
                                }
                            }
                            break;
                        case 9:
                            lblSheetGrp10.Visible = true;
                            lblSheetGrp10.Text = MPCF.Trim(out_node.GetList(0)[i].GetString("CAT_CAPTION"));
                            cdvSheetGrp10.Visible = true;

                            if (cdvSheetGrp10.Visible == true)
                            {
                                if (MPCF.Trim(out_node.GetList(0)[i].GetString("CAT_TABLE")) != "")
                                {
                                    cdvSheetGrp10.VisibleButton = true;
                                    cdvSheetGrp10.Tag = MPCF.Trim(out_node.GetList(0)[i].GetString("CAT_TABLE"));
                                }
                            }
                            break;
                    }
                }

                switch ((int)((out_node.GetList(0).Count + 1) / 2))
                {
                    case 1:
                        grpSheetType.Height = 64;
                        break;

                    case 2:
                        grpSheetType.Height = 88;
                        break;

                    case 3:
                        grpSheetType.Height = 111;
                        break;

                    case 4:
                        grpSheetType.Height = 136;
                        break;

                    case 5:
                        grpSheetType.Height = 159;
                        break;
                }

                return true;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmPOPSetupLabelDesign.View_Data()\n" + ex.Message);
                return false;
            }
        }


        public virtual Control GetFisrtFocusItem()
        {
            
            try
            {
                return this.txtSheetName;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }
            
        }
        
        #endregion
        
        private void frmRASSetupSheet_Activated(object sender, System.EventArgs e)
        {
            
            try
            {
                if (b_load_flag == false)
                {
                    btnRefresh.PerformClick();

                    lisQueryList.Items.Clear();

                    if (RASLIST.ViewSheetQueryList(lisQueryList, '1', "") == false)
                    {
                        return;
                    }

                    ((Control)GetFisrtFocusItem()).Focus();

                    b_load_flag = true;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void frmRASSetupSheet_Load(object sender, System.EventArgs e)
        {
            ListViewItem itmX;

            try
            {
                MPCF.InitListView(lisSheet);
                MPCF.InitListView(lisQuery);
                MPCF.InitListView(lisQueryList);


                itmX = lisQuery.Items.Insert(lisQuery.Items.Count, "Add here...", (int)SMALLICON_INDEX.IDX_MESSAGE);
                itmX.SubItems.Add("");
                itmX.SubItems.Add("");
                itmX.SubItems.Add("");
                //itmX = new ListViewItem("Add here...", (int)SMALLICON_INDEX.IDX_MESSAGE);
                //lisQuery.Items.Add(itmX);
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

                    
                    btnRefresh.PerformClick();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }

        private void lisSheet_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                if (lisSheet.SelectedItems.Count > 0)
                {
                    View_Attached_Query();
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
                if (RASLIST.ViewSheetList(lisSheet, '1', cdvGrpSheetType.Text) == false)
                {
                    return;
                }
                lblDataCount.Text = lisSheet.Items.Count.ToString();
                if (lisSheet.Items.Count > 0)
                {
                    if (MPCF.Trim(txtSheetName.Text) == "")
                    {
                        lisSheet.Items[0].Selected = true;
                    }
                    else
                    {
                        MPCF.FindListItem(lisSheet, txtSheetName.Text, false);
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

            MPCF.ExportToExcel(lisSheet, this.Text, "");
            
        }
        
        private void btnNext_Click(System.Object sender, System.EventArgs e)
        {

            MPCF.FindListItemNextPartial(lisSheet, txtFind.Text, true, false);
            
        }
        
        private void txtFind_TextChanged(System.Object sender, System.EventArgs e)
        {

            MPCF.FindListItemPartial(lisSheet, txtFind.Text, 0, true, false);
            
        }

        private void cdvSheetType_ButtonPress(object sender, EventArgs e)
        {
            cdvSheetType.Init();
            MPCF.InitListView(cdvSheetType.GetListView);
            cdvSheetType.Columns.Add("Type", 50, HorizontalAlignment.Left);
            cdvSheetType.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvSheetType.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMDataList(cdvSheetType.GetListView, '1', MPGC.MP_SHEET_SHEET_TYPE);

            cdvSheetType.InsertEmptyRow(0, 1);
        }

        private void cdvSheetType_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            View_Sheet_Group(MPCF.Trim(cdvSheetType.Text));
        }

        private void cdvQryType_ButtonPress(object sender, EventArgs e)
        {
            cdvQryType.Init();
            MPCF.InitListView(cdvQryType.GetListView);
            cdvQryType.Columns.Add("Type", 50, HorizontalAlignment.Left);
            cdvQryType.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvQryType.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMDataList(cdvQryType.GetListView, '1', MPGC.MP_SHEET_QUERY_TYPE);

            cdvQryType.InsertEmptyRow(0, 1);
        }

        private void cdvQryType_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            lisQueryList.Items.Clear();

            if (MPCF.Trim(cdvQryType.Text) == "")
            {
                if (RASLIST.ViewSheetQueryList(lisQueryList, '1', cdvQryType.Text) == false)
                {
                    return;
                }
            }
            else
            {
                if (RASLIST.ViewSheetQueryList(lisQueryList, '2', cdvQryType.Text) == false)
                {
                    return;
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ListViewItem itmX;

            int i;
            int i_start_idx = 0;

            try
            {
                if (MPCF.Trim(txtSheetName.Text) == "")
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                    txtSheetName.Focus();
                    return;
                }

                if (lisQueryList.Items.Count < 1) return;
                if (lisQueryList.SelectedItems.Count < 1) return;

                if (lisQuery.SelectedItems.Count < 1) i_start_idx = 0;
                else i_start_idx = lisQuery.SelectedItems[0].Index;

                for (i = 0; i < lisQueryList.SelectedItems.Count; i++)
                {
                    if (MPCF.FindListItem(lisQuery, lisQueryList.SelectedItems[i].Text, false) == false)
                    {
                        itmX = new ListViewItem(lisQueryList.SelectedItems[i].Text, (int)SMALLICON_INDEX.IDX_MESSAGE);
                        itmX.SubItems.Add(lisQueryList.SelectedItems[i].SubItems[1].Text);
                        lisQuery.Items.Insert(i_start_idx, itmX);

                        i_start_idx++;
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            int i;

            try
            {
                if (lisQuery.Items.Count < 1) return;
                if (lisQuery.SelectedItems.Count < 1) return;

                for (i = lisQuery.SelectedItems.Count-1; i >= 0; i--)
                {
                    lisQuery.SelectedItems[i].Remove();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnUp_Click(object sender, EventArgs e)
        {

            ListViewItem itmX;

            int i;
            int i_next;
            int i_list_index;

            if (lisQuery.SelectedItems.Count < 1) return;

            try
            {
                i_next = 0;
                for (i = 0; i < lisQuery.Items.Count; i++)
                {
                    if (lisQuery.Items[i].Selected == true)
                    {
                        if (lisQuery.Items[i].Text == "Add here...")
                            continue;

                        i_list_index = lisQuery.Items[i].Index;
                        if (i_list_index > i_next)
                        {
                            itmX = new ListViewItem(lisQuery.Items[i_list_index].Text, (int)SMALLICON_INDEX.IDX_MESSAGE);
                            itmX.SubItems.Add(lisQuery.Items[i_list_index].SubItems[1].Text);

                            lisQuery.Items.RemoveAt(i_list_index);
                            lisQuery.Items.Insert(i_list_index - 1, itmX);

                            lisQuery.Items[i_list_index - 1].Selected = true;
                        }

                        if (i_list_index == i_next)
                        {
                            i_next++;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            ListViewItem itmX;

            int i;
            int i_next;
            int i_list_index;

            if (lisQuery.SelectedItems.Count < 1) return;

            try
            {
                i_next = lisQuery.Items.Count - 2;
                for (i = lisQuery.Items.Count - 2; i >= 0; i--)
                {
                    if (lisQuery.Items[i].Selected == true)
                    {
                        i_list_index = lisQuery.Items[i].Index;
                        if (i_list_index < i_next)
                        {
                            itmX = new ListViewItem(lisQuery.Items[i].Text, (int)SMALLICON_INDEX.IDX_MESSAGE);
                            itmX.SubItems.Add(lisQuery.Items[i].SubItems[1].Text);

                            lisQuery.Items.Insert(i_list_index + 2, itmX);
                            lisQuery.Items.RemoveAt(i_list_index);

                            lisQuery.Items[i_list_index+1].Selected = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void pnlEventMid_Resize(object sender, EventArgs e)
        {
            MPCF.FieldAdjust(pnlEventMid, pnlEventMidLeft, pnlEventMidRight, pnlEventMidMid, 40);
        }

        private void cdvGrpSheetType_ButtonPress(object sender, EventArgs e)
        {
            cdvGrpSheetType.Init();
            MPCF.InitListView(cdvGrpSheetType.GetListView);
            cdvGrpSheetType.Columns.Add("Type", 50, HorizontalAlignment.Left);
            cdvGrpSheetType.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvGrpSheetType.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMDataList(cdvGrpSheetType.GetListView, '1', MPGC.MP_SHEET_SHEET_TYPE);

            cdvGrpSheetType.InsertEmptyRow(0, 1);
        }

        private void cdvGrpSheetType_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            MPCF.FieldClear(this.pnlRight);

            if (MPCF.Trim(cdvGrpSheetType.Text) != "")
            {
                View_Sheet_Group(MPCF.Trim(cdvGrpSheetType.Text));
            }

            btnRefresh.PerformClick();
        }

        private void cdvSheetGrp_ButtonPress(object sender, EventArgs e)
        {
            Miracom.UI.Controls.MCCodeView.MCCodeView cdvTemp;

            cdvTemp = (Miracom.UI.Controls.MCCodeView.MCCodeView)sender;

            if (MPCF.Trim(cdvTemp.Tag) == "") return;

            cdvTemp.Init();
            MPCF.InitListView(cdvTemp.GetListView);
            cdvTemp.Columns.Add("Status", 50, HorizontalAlignment.Left);
            cdvTemp.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvTemp.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMDataList(cdvTemp.GetListView, '1', MPCF.Trim(cdvTemp.Tag));
        }

        private void txtSheetName_TextChanged(object sender, EventArgs e)
        {
            ListViewItem itmX;
            try
            {
                MPCF.InitListView(lisQuery);

                itmX = lisQuery.Items.Insert(lisQuery.Items.Count, "Add here...", (int)SMALLICON_INDEX.IDX_MESSAGE);
                itmX.SubItems.Add("");
                itmX.SubItems.Add("");
                itmX.SubItems.Add("");

                //itmX = new ListViewItem("Add here...", (int)SMALLICON_INDEX.IDX_MESSAGE);
                //lisQuery.Items.Add(itmX);
                lisQuery.Items[0].Selected = true;

                spdQuery.Sheets[0].ClearRange(0, 0, spdQuery.Sheets[0].RowCount - 1, spdQuery.Sheets[0].ColumnCount - 1, true);
                cdvSheetType.Text = "";
                return;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void btnQryExcel_Click(object sender, EventArgs e)
        {
            try
            {
                string sCond = string.Empty;


                sCond = "Function : " + lisSheet.SelectedItems[0].Text;


                MPCF.ExportToExcel(lisQuery, this.Text, sCond);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

    }
}
