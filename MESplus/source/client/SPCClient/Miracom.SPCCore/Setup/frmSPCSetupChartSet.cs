
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
using Miracom.TRSCore;
//#If _SPC = True Then

//-----------------------------------------------------------------------------
//
//   System      : SPCClient
//   File Name   : frmSPCSetupChartSet.vb
//   Description :
//
//   SPC Version : 1.0.0
//
//   Function List
//       - CheckCondition() : Check the Conditions before Transaction
//       - View_ChartSet() : View Chart Set Information
//       - Update_ChartSet() : Create/Update/Delete Chart Set
//       - Attach_Chart() : Create/Update/Delete Chart - Chart Set Relation
//
//
//
//   Detail Description
//       -
//       -
//
//   History
//       - 2005-04-27 : Created by H.K.Kim
//
//
//   Copyright(C) 1998-2004 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------
namespace Miracom.SPCCore
{
    public class frmSPCSetupChartSet : System.Windows.Forms.Form
    {
        
        #region " Windows Form auto generated code "
        
        public frmSPCSetupChartSet()
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
        public System.Windows.Forms.Panel pnlFind;
        public System.Windows.Forms.Button btnExcel;
        public System.Windows.Forms.Button btnRefresh;
        public System.Windows.Forms.Button btnNext;
        public Infragistics.Win.UltraWinEditors.UltraTextEditor txtFind;
        public System.Windows.Forms.Button btnCreate;
        public System.Windows.Forms.Button btnDelete;
        public System.Windows.Forms.Button btnUpdate;
        public System.Windows.Forms.Button btnClose;
        public System.Windows.Forms.Panel pnlLeft;
        internal System.Windows.Forms.ColumnHeader ColumnHeader1;
        internal System.Windows.Forms.ColumnHeader ColumnHeader2;
        internal System.Windows.Forms.Panel pnlRight;
        internal System.Windows.Forms.Splitter splMain;
        internal Miracom.UI.Controls.MCListView.MCListView lisChartSet;
        internal System.Windows.Forms.GroupBox grpChart;
        internal System.Windows.Forms.Label lblDesc;
        internal Infragistics.Win.UltraWinEditors.UltraTextEditor txtDesc;
        internal System.Windows.Forms.Label lblChartSet;
        internal Infragistics.Win.UltraWinEditors.UltraTextEditor txtChartSet;
        public System.Windows.Forms.Label lblDataCountBack;
        public System.Windows.Forms.Label lblDataCount;
        internal System.Windows.Forms.TabControl tabChartSet;
        internal System.Windows.Forms.TabPage tbpGeneral;
        internal System.Windows.Forms.GroupBox grpRight;
        internal System.Windows.Forms.Panel pnlMid;
        internal System.Windows.Forms.Panel pnlMidRight;
        internal Miracom.UI.Controls.MCListView.MCListView lisChart;
        internal System.Windows.Forms.Panel pnlFilter;
        internal System.Windows.Forms.GroupBox grpFilter;
        public System.Windows.Forms.Button btnView;
        internal Infragistics.Win.UltraWinEditors.UltraTextEditor txtFilter;
        internal System.Windows.Forms.RadioButton rbnAll;
        internal System.Windows.Forms.RadioButton rbnFilter;
        internal System.Windows.Forms.Label lblChartList;
        internal System.Windows.Forms.Panel pnlAttach;
        internal System.Windows.Forms.Button btnDel;
        internal System.Windows.Forms.Button btnAdd;
        internal System.Windows.Forms.Panel pnlMidLeft;
        internal Miracom.UI.Controls.MCListView.MCListView lisAttachChart;
        internal System.Windows.Forms.Label lblAttachChart;
        internal System.Windows.Forms.ColumnHeader ColumnHeader5;
        internal System.Windows.Forms.ColumnHeader ColumnHeader6;
        internal System.Windows.Forms.ColumnHeader ColumnHeader3;
        internal System.Windows.Forms.ColumnHeader ColumnHeader4;
        internal System.Windows.Forms.GroupBox grpComment;
        internal System.Windows.Forms.Label lblComment;
        internal Infragistics.Win.UltraWinEditors.UltraTextEditor txtComment;
        internal System.Windows.Forms.GroupBox grpLotResource;
        internal System.Windows.Forms.RadioButton rbnResource;
        internal System.Windows.Forms.RadioButton rbnLot;
        internal System.Windows.Forms.TabPage tbpGroup;
        internal System.Windows.Forms.TabPage tbpCMF;
        internal System.Windows.Forms.GroupBox grpGroup;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvGrp10;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvGrp9;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvGrp8;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvGrp7;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvGrp6;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvGrp5;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvGrp4;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvGrp3;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvGrp2;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvGrp1;
        internal System.Windows.Forms.Label lblGrp10;
        internal System.Windows.Forms.Label lblGrp9;
        internal System.Windows.Forms.Label lblGrp8;
        internal System.Windows.Forms.Label lblGrp7;
        internal System.Windows.Forms.Label lblGrp6;
        internal System.Windows.Forms.Label lblGrp5;
        internal System.Windows.Forms.Label lblGrp4;
        internal System.Windows.Forms.Label lblGrp3;
        internal System.Windows.Forms.Label lblGrp2;
        internal System.Windows.Forms.Label lblGrp1;
        internal System.Windows.Forms.GroupBox grpCMF;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF10;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF9;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF8;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF7;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF6;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF5;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF4;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF3;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF2;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF1;
        internal System.Windows.Forms.Label lblCMF10;
        internal System.Windows.Forms.Label lblCMF9;
        internal System.Windows.Forms.Label lblCMF8;
        internal System.Windows.Forms.Label lblCMF7;
        internal System.Windows.Forms.Label lblCMF6;
        internal System.Windows.Forms.Label lblCMF5;
        internal System.Windows.Forms.Label lblCMF4;
        internal System.Windows.Forms.Label lblCMF3;
        internal System.Windows.Forms.Label lblCMF2;
        internal System.Windows.Forms.Label lblCMF1;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSPCSetupChartSet));
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.pnlFind = new System.Windows.Forms.Panel();
            this.lblDataCount = new System.Windows.Forms.Label();
            this.lblDataCountBack = new System.Windows.Forms.Label();
            this.btnExcel = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.txtFind = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.lisChartSet = new Miracom.UI.Controls.MCListView.MCListView();
            this.ColumnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlRight = new System.Windows.Forms.Panel();
            this.tabChartSet = new System.Windows.Forms.TabControl();
            this.tbpGeneral = new System.Windows.Forms.TabPage();
            this.grpRight = new System.Windows.Forms.GroupBox();
            this.pnlMid = new System.Windows.Forms.Panel();
            this.pnlMidRight = new System.Windows.Forms.Panel();
            this.lisChart = new Miracom.UI.Controls.MCListView.MCListView();
            this.ColumnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.grpFilter = new System.Windows.Forms.GroupBox();
            this.btnView = new System.Windows.Forms.Button();
            this.txtFilter = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.rbnAll = new System.Windows.Forms.RadioButton();
            this.rbnFilter = new System.Windows.Forms.RadioButton();
            this.lblChartList = new System.Windows.Forms.Label();
            this.pnlAttach = new System.Windows.Forms.Panel();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.pnlMidLeft = new System.Windows.Forms.Panel();
            this.lisAttachChart = new Miracom.UI.Controls.MCListView.MCListView();
            this.ColumnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblAttachChart = new System.Windows.Forms.Label();
            this.grpComment = new System.Windows.Forms.GroupBox();
            this.lblComment = new System.Windows.Forms.Label();
            this.txtComment = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.grpLotResource = new System.Windows.Forms.GroupBox();
            this.rbnResource = new System.Windows.Forms.RadioButton();
            this.rbnLot = new System.Windows.Forms.RadioButton();
            this.tbpGroup = new System.Windows.Forms.TabPage();
            this.grpGroup = new System.Windows.Forms.GroupBox();
            this.cdvGrp10 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvGrp9 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvGrp8 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvGrp7 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvGrp6 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvGrp5 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvGrp4 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvGrp3 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvGrp2 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvGrp1 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblGrp10 = new System.Windows.Forms.Label();
            this.lblGrp9 = new System.Windows.Forms.Label();
            this.lblGrp8 = new System.Windows.Forms.Label();
            this.lblGrp7 = new System.Windows.Forms.Label();
            this.lblGrp6 = new System.Windows.Forms.Label();
            this.lblGrp5 = new System.Windows.Forms.Label();
            this.lblGrp4 = new System.Windows.Forms.Label();
            this.lblGrp3 = new System.Windows.Forms.Label();
            this.lblGrp2 = new System.Windows.Forms.Label();
            this.lblGrp1 = new System.Windows.Forms.Label();
            this.tbpCMF = new System.Windows.Forms.TabPage();
            this.grpCMF = new System.Windows.Forms.GroupBox();
            this.cdvCMF10 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF9 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF8 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF7 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF6 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF5 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF4 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF3 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF2 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF1 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblCMF10 = new System.Windows.Forms.Label();
            this.lblCMF9 = new System.Windows.Forms.Label();
            this.lblCMF8 = new System.Windows.Forms.Label();
            this.lblCMF7 = new System.Windows.Forms.Label();
            this.lblCMF6 = new System.Windows.Forms.Label();
            this.lblCMF5 = new System.Windows.Forms.Label();
            this.lblCMF4 = new System.Windows.Forms.Label();
            this.lblCMF3 = new System.Windows.Forms.Label();
            this.lblCMF2 = new System.Windows.Forms.Label();
            this.lblCMF1 = new System.Windows.Forms.Label();
            this.grpChart = new System.Windows.Forms.GroupBox();
            this.lblDesc = new System.Windows.Forms.Label();
            this.lblChartSet = new System.Windows.Forms.Label();
            this.txtDesc = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.txtChartSet = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.splMain = new System.Windows.Forms.Splitter();
            this.pnlBottom.SuspendLayout();
            this.pnlFind.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFind)).BeginInit();
            this.pnlLeft.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.tabChartSet.SuspendLayout();
            this.tbpGeneral.SuspendLayout();
            this.grpRight.SuspendLayout();
            this.pnlMid.SuspendLayout();
            this.pnlMidRight.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.grpFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFilter)).BeginInit();
            this.pnlAttach.SuspendLayout();
            this.pnlMidLeft.SuspendLayout();
            this.grpComment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtComment)).BeginInit();
            this.grpLotResource.SuspendLayout();
            this.tbpGroup.SuspendLayout();
            this.grpGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGrp10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGrp9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGrp8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGrp7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGrp6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGrp5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGrp4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGrp3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGrp2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGrp1)).BeginInit();
            this.tbpCMF.SuspendLayout();
            this.grpCMF.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF1)).BeginInit();
            this.grpChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDesc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtChartSet)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.pnlFind);
            this.pnlBottom.Controls.Add(this.btnCreate);
            this.pnlBottom.Controls.Add(this.btnDelete);
            this.pnlBottom.Controls.Add(this.btnUpdate);
            this.pnlBottom.Controls.Add(this.btnClose);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 506);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(742, 40);
            this.pnlBottom.TabIndex = 2;
            // 
            // pnlFind
            // 
            this.pnlFind.Controls.Add(this.lblDataCount);
            this.pnlFind.Controls.Add(this.lblDataCountBack);
            this.pnlFind.Controls.Add(this.btnExcel);
            this.pnlFind.Controls.Add(this.btnRefresh);
            this.pnlFind.Controls.Add(this.btnNext);
            this.pnlFind.Controls.Add(this.txtFind);
            this.pnlFind.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlFind.Location = new System.Drawing.Point(0, 0);
            this.pnlFind.Name = "pnlFind";
            this.pnlFind.Size = new System.Drawing.Size(232, 40);
            this.pnlFind.TabIndex = 4;
            // 
            // lblDataCount
            // 
            this.lblDataCount.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblDataCount.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblDataCount.Location = new System.Drawing.Point(7, 13);
            this.lblDataCount.Name = "lblDataCount";
            this.lblDataCount.Size = new System.Drawing.Size(36, 16);
            this.lblDataCount.TabIndex = 5;
            this.lblDataCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDataCountBack
            // 
            this.lblDataCountBack.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDataCountBack.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblDataCountBack.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblDataCountBack.Location = new System.Drawing.Point(4, 8);
            this.lblDataCountBack.Name = "lblDataCountBack";
            this.lblDataCountBack.Size = new System.Drawing.Size(42, 24);
            this.lblDataCountBack.TabIndex = 0;
            this.lblDataCountBack.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnExcel
            // 
            this.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExcel.Image")));
            this.btnExcel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnExcel.Location = new System.Drawing.Point(200, 8);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(24, 24);
            this.btnExcel.TabIndex = 3;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnRefresh.Location = new System.Drawing.Point(174, 8);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(24, 24);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnNext
            // 
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNext.Image = ((System.Drawing.Image)(resources.GetObject("btnNext.Image")));
            this.btnNext.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnNext.Location = new System.Drawing.Point(148, 8);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(24, 24);
            this.btnNext.TabIndex = 1;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // txtFind
            // 
            this.txtFind.AutoSize = false;
            this.txtFind.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFind.Location = new System.Drawing.Point(48, 8);
            this.txtFind.Name = "txtFind";
            this.txtFind.Size = new System.Drawing.Size(96, 24);
            this.txtFind.TabIndex = 0;
            this.txtFind.TextChanged += new System.EventHandler(this.txtFind_TextChanged);
            // 
            // btnCreate
            // 
            this.btnCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCreate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCreate.Location = new System.Drawing.Point(374, 8);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(88, 26);
            this.btnCreate.TabIndex = 0;
            this.btnCreate.Text = "Create";
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnDelete.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnDelete.Location = new System.Drawing.Point(558, 8);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(88, 26);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnUpdate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnUpdate.Location = new System.Drawing.Point(466, 8);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(88, 26);
            this.btnUpdate.TabIndex = 1;
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
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.lisChartSet);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Padding = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.pnlLeft.Size = new System.Drawing.Size(232, 506);
            this.pnlLeft.TabIndex = 0;
            // 
            // lisChartSet
            // 
            this.lisChartSet.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader1,
            this.ColumnHeader2});
            this.lisChartSet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisChartSet.EnableSort = true;
            this.lisChartSet.EnableSortIcon = true;
            this.lisChartSet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisChartSet.FullRowSelect = true;
            this.lisChartSet.Location = new System.Drawing.Point(3, 3);
            this.lisChartSet.MultiSelect = false;
            this.lisChartSet.Name = "lisChartSet";
            this.lisChartSet.Size = new System.Drawing.Size(229, 500);
            this.lisChartSet.TabIndex = 0;
            this.lisChartSet.TabStop = false;
            this.lisChartSet.UseCompatibleStateImageBehavior = false;
            this.lisChartSet.View = System.Windows.Forms.View.Details;
            this.lisChartSet.SelectedIndexChanged += new System.EventHandler(this.lisChartSet_SelectedIndexChanged);
            // 
            // ColumnHeader1
            // 
            this.ColumnHeader1.Text = "Chart Set";
            this.ColumnHeader1.Width = 100;
            // 
            // ColumnHeader2
            // 
            this.ColumnHeader2.Text = "Description";
            this.ColumnHeader2.Width = 300;
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.tabChartSet);
            this.pnlRight.Controls.Add(this.grpChart);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.Location = new System.Drawing.Point(232, 0);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Padding = new System.Windows.Forms.Padding(5, 3, 3, 0);
            this.pnlRight.Size = new System.Drawing.Size(510, 506);
            this.pnlRight.TabIndex = 1;
            // 
            // tabChartSet
            // 
            this.tabChartSet.Controls.Add(this.tbpGeneral);
            this.tabChartSet.Controls.Add(this.tbpGroup);
            this.tabChartSet.Controls.Add(this.tbpCMF);
            this.tabChartSet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabChartSet.Location = new System.Drawing.Point(5, 74);
            this.tabChartSet.Name = "tabChartSet";
            this.tabChartSet.SelectedIndex = 0;
            this.tabChartSet.Size = new System.Drawing.Size(502, 432);
            this.tabChartSet.TabIndex = 1;
            // 
            // tbpGeneral
            // 
            this.tbpGeneral.Controls.Add(this.grpRight);
            this.tbpGeneral.Controls.Add(this.grpComment);
            this.tbpGeneral.Controls.Add(this.grpLotResource);
            this.tbpGeneral.Location = new System.Drawing.Point(4, 22);
            this.tbpGeneral.Name = "tbpGeneral";
            this.tbpGeneral.Size = new System.Drawing.Size(494, 406);
            this.tbpGeneral.TabIndex = 0;
            this.tbpGeneral.Text = "General";
            // 
            // grpRight
            // 
            this.grpRight.Controls.Add(this.pnlMid);
            this.grpRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpRight.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpRight.Location = new System.Drawing.Point(0, 48);
            this.grpRight.Name = "grpRight";
            this.grpRight.Size = new System.Drawing.Size(494, 314);
            this.grpRight.TabIndex = 4;
            this.grpRight.TabStop = false;
            this.grpRight.Resize += new System.EventHandler(this.grpRight_Resize);
            // 
            // pnlMid
            // 
            this.pnlMid.Controls.Add(this.pnlMidRight);
            this.pnlMid.Controls.Add(this.pnlAttach);
            this.pnlMid.Controls.Add(this.pnlMidLeft);
            this.pnlMid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMid.Location = new System.Drawing.Point(3, 16);
            this.pnlMid.Name = "pnlMid";
            this.pnlMid.Size = new System.Drawing.Size(488, 295);
            this.pnlMid.TabIndex = 1;
            // 
            // pnlMidRight
            // 
            this.pnlMidRight.Controls.Add(this.lisChart);
            this.pnlMidRight.Controls.Add(this.pnlFilter);
            this.pnlMidRight.Controls.Add(this.lblChartList);
            this.pnlMidRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlMidRight.Location = new System.Drawing.Point(264, 0);
            this.pnlMidRight.Name = "pnlMidRight";
            this.pnlMidRight.Size = new System.Drawing.Size(224, 295);
            this.pnlMidRight.TabIndex = 2;
            // 
            // lisChart
            // 
            this.lisChart.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader5,
            this.ColumnHeader6});
            this.lisChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisChart.EnableSort = true;
            this.lisChart.EnableSortIcon = true;
            this.lisChart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisChart.FullRowSelect = true;
            this.lisChart.Location = new System.Drawing.Point(0, 52);
            this.lisChart.Name = "lisChart";
            this.lisChart.Size = new System.Drawing.Size(224, 243);
            this.lisChart.TabIndex = 2;
            this.lisChart.TabStop = false;
            this.lisChart.UseCompatibleStateImageBehavior = false;
            this.lisChart.View = System.Windows.Forms.View.Details;
            // 
            // ColumnHeader5
            // 
            this.ColumnHeader5.Text = "Chart";
            this.ColumnHeader5.Width = 100;
            // 
            // ColumnHeader6
            // 
            this.ColumnHeader6.Text = "Description";
            this.ColumnHeader6.Width = 300;
            // 
            // pnlFilter
            // 
            this.pnlFilter.Controls.Add(this.grpFilter);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(0, 12);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Padding = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.pnlFilter.Size = new System.Drawing.Size(224, 40);
            this.pnlFilter.TabIndex = 4;
            // 
            // grpFilter
            // 
            this.grpFilter.Controls.Add(this.btnView);
            this.grpFilter.Controls.Add(this.txtFilter);
            this.grpFilter.Controls.Add(this.rbnAll);
            this.grpFilter.Controls.Add(this.rbnFilter);
            this.grpFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpFilter.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpFilter.Location = new System.Drawing.Point(0, 0);
            this.grpFilter.Name = "grpFilter";
            this.grpFilter.Size = new System.Drawing.Size(224, 38);
            this.grpFilter.TabIndex = 0;
            this.grpFilter.TabStop = false;
            // 
            // btnView
            // 
            this.btnView.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnView.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnView.Location = new System.Drawing.Point(184, 13);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(36, 20);
            this.btnView.TabIndex = 2;
            this.btnView.Text = "View";
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // txtFilter
            // 
            this.txtFilter.Location = new System.Drawing.Point(26, 13);
            this.txtFilter.MaxLength = 30;
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(98, 20);
            this.txtFilter.TabIndex = 0;
            this.txtFilter.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            // 
            // rbnAll
            // 
            this.rbnAll.AutoSize = true;
            this.rbnAll.Location = new System.Drawing.Point(131, 16);
            this.rbnAll.Name = "rbnAll";
            this.rbnAll.Size = new System.Drawing.Size(36, 17);
            this.rbnAll.TabIndex = 1;
            this.rbnAll.Text = "All";
            // 
            // rbnFilter
            // 
            this.rbnFilter.AutoSize = true;
            this.rbnFilter.Location = new System.Drawing.Point(8, 16);
            this.rbnFilter.Name = "rbnFilter";
            this.rbnFilter.Size = new System.Drawing.Size(14, 13);
            this.rbnFilter.TabIndex = 5;
            // 
            // lblChartList
            // 
            this.lblChartList.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblChartList.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblChartList.Location = new System.Drawing.Point(0, 0);
            this.lblChartList.Name = "lblChartList";
            this.lblChartList.Size = new System.Drawing.Size(224, 12);
            this.lblChartList.TabIndex = 0;
            this.lblChartList.Text = "All Chart List";
            // 
            // pnlAttach
            // 
            this.pnlAttach.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlAttach.Controls.Add(this.btnDel);
            this.pnlAttach.Controls.Add(this.btnAdd);
            this.pnlAttach.Location = new System.Drawing.Point(229, 92);
            this.pnlAttach.Name = "pnlAttach";
            this.pnlAttach.Size = new System.Drawing.Size(31, 127);
            this.pnlAttach.TabIndex = 1;
            // 
            // btnDel
            // 
            this.btnDel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnDel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDel.Location = new System.Drawing.Point(3, 66);
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
            this.btnAdd.Location = new System.Drawing.Point(3, 37);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(24, 24);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "<";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // pnlMidLeft
            // 
            this.pnlMidLeft.Controls.Add(this.lisAttachChart);
            this.pnlMidLeft.Controls.Add(this.lblAttachChart);
            this.pnlMidLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMidLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlMidLeft.Name = "pnlMidLeft";
            this.pnlMidLeft.Size = new System.Drawing.Size(224, 295);
            this.pnlMidLeft.TabIndex = 0;
            // 
            // lisAttachChart
            // 
            this.lisAttachChart.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader3,
            this.ColumnHeader4});
            this.lisAttachChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisAttachChart.EnableSort = true;
            this.lisAttachChart.EnableSortIcon = true;
            this.lisAttachChart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisAttachChart.FullRowSelect = true;
            this.lisAttachChart.Location = new System.Drawing.Point(0, 14);
            this.lisAttachChart.Name = "lisAttachChart";
            this.lisAttachChart.Size = new System.Drawing.Size(224, 281);
            this.lisAttachChart.TabIndex = 2;
            this.lisAttachChart.TabStop = false;
            this.lisAttachChart.UseCompatibleStateImageBehavior = false;
            this.lisAttachChart.View = System.Windows.Forms.View.Details;
            // 
            // ColumnHeader3
            // 
            this.ColumnHeader3.Text = "Chart";
            this.ColumnHeader3.Width = 100;
            // 
            // ColumnHeader4
            // 
            this.ColumnHeader4.Text = "Description";
            this.ColumnHeader4.Width = 300;
            // 
            // lblAttachChart
            // 
            this.lblAttachChart.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblAttachChart.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAttachChart.Location = new System.Drawing.Point(0, 0);
            this.lblAttachChart.Name = "lblAttachChart";
            this.lblAttachChart.Size = new System.Drawing.Size(224, 14);
            this.lblAttachChart.TabIndex = 1;
            this.lblAttachChart.Text = "Attached Chart List";
            // 
            // grpComment
            // 
            this.grpComment.Controls.Add(this.lblComment);
            this.grpComment.Controls.Add(this.txtComment);
            this.grpComment.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpComment.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpComment.Location = new System.Drawing.Point(0, 362);
            this.grpComment.Name = "grpComment";
            this.grpComment.Size = new System.Drawing.Size(494, 44);
            this.grpComment.TabIndex = 5;
            this.grpComment.TabStop = false;
            // 
            // lblComment
            // 
            this.lblComment.AutoSize = true;
            this.lblComment.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblComment.Location = new System.Drawing.Point(8, 19);
            this.lblComment.Name = "lblComment";
            this.lblComment.Size = new System.Drawing.Size(51, 13);
            this.lblComment.TabIndex = 0;
            this.lblComment.Text = "Comment";
            // 
            // txtComment
            // 
            this.txtComment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtComment.Location = new System.Drawing.Point(84, 16);
            this.txtComment.MaxLength = 200;
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(401, 20);
            this.txtComment.TabIndex = 0;
            // 
            // grpLotResource
            // 
            this.grpLotResource.Controls.Add(this.rbnResource);
            this.grpLotResource.Controls.Add(this.rbnLot);
            this.grpLotResource.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpLotResource.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpLotResource.Location = new System.Drawing.Point(0, 0);
            this.grpLotResource.Name = "grpLotResource";
            this.grpLotResource.Size = new System.Drawing.Size(494, 48);
            this.grpLotResource.TabIndex = 0;
            this.grpLotResource.TabStop = false;
            this.grpLotResource.Text = "Lot or Resource";
            // 
            // rbnResource
            // 
            this.rbnResource.AutoSize = true;
            this.rbnResource.Location = new System.Drawing.Point(329, 20);
            this.rbnResource.Name = "rbnResource";
            this.rbnResource.Size = new System.Drawing.Size(71, 17);
            this.rbnResource.TabIndex = 1;
            this.rbnResource.Text = "Resource";
            // 
            // rbnLot
            // 
            this.rbnLot.AutoSize = true;
            this.rbnLot.Location = new System.Drawing.Point(84, 21);
            this.rbnLot.Name = "rbnLot";
            this.rbnLot.Size = new System.Drawing.Size(40, 17);
            this.rbnLot.TabIndex = 0;
            this.rbnLot.Text = "Lot";
            // 
            // tbpGroup
            // 
            this.tbpGroup.Controls.Add(this.grpGroup);
            this.tbpGroup.Location = new System.Drawing.Point(4, 22);
            this.tbpGroup.Name = "tbpGroup";
            this.tbpGroup.Size = new System.Drawing.Size(494, 406);
            this.tbpGroup.TabIndex = 1;
            this.tbpGroup.Text = "Group Setup";
            // 
            // grpGroup
            // 
            this.grpGroup.Controls.Add(this.cdvGrp10);
            this.grpGroup.Controls.Add(this.cdvGrp9);
            this.grpGroup.Controls.Add(this.cdvGrp8);
            this.grpGroup.Controls.Add(this.cdvGrp7);
            this.grpGroup.Controls.Add(this.cdvGrp6);
            this.grpGroup.Controls.Add(this.cdvGrp5);
            this.grpGroup.Controls.Add(this.cdvGrp4);
            this.grpGroup.Controls.Add(this.cdvGrp3);
            this.grpGroup.Controls.Add(this.cdvGrp2);
            this.grpGroup.Controls.Add(this.cdvGrp1);
            this.grpGroup.Controls.Add(this.lblGrp10);
            this.grpGroup.Controls.Add(this.lblGrp9);
            this.grpGroup.Controls.Add(this.lblGrp8);
            this.grpGroup.Controls.Add(this.lblGrp7);
            this.grpGroup.Controls.Add(this.lblGrp6);
            this.grpGroup.Controls.Add(this.lblGrp5);
            this.grpGroup.Controls.Add(this.lblGrp4);
            this.grpGroup.Controls.Add(this.lblGrp3);
            this.grpGroup.Controls.Add(this.lblGrp2);
            this.grpGroup.Controls.Add(this.lblGrp1);
            this.grpGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpGroup.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpGroup.Location = new System.Drawing.Point(0, 0);
            this.grpGroup.Name = "grpGroup";
            this.grpGroup.Size = new System.Drawing.Size(494, 406);
            this.grpGroup.TabIndex = 2;
            this.grpGroup.TabStop = false;
            // 
            // cdvGrp10
            // 
            this.cdvGrp10.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvGrp10.BorderHotColor = System.Drawing.Color.Black;
            this.cdvGrp10.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvGrp10.BtnToolTipText = "";
            this.cdvGrp10.DescText = "";
            this.cdvGrp10.DisplaySubItemIndex = -1;
            this.cdvGrp10.DisplayText = "";
            this.cdvGrp10.Focusing = null;
            this.cdvGrp10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvGrp10.Index = 0;
            this.cdvGrp10.IsViewBtnImage = false;
            this.cdvGrp10.Location = new System.Drawing.Point(172, 232);
            this.cdvGrp10.MaxLength = 30;
            this.cdvGrp10.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvGrp10.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvGrp10.Name = "cdvGrp10";
            this.cdvGrp10.ReadOnly = false;
            this.cdvGrp10.SearchSubItemIndex = 0;
            this.cdvGrp10.SelectedDescIndex = -1;
            this.cdvGrp10.SelectedSubItemIndex = -1;
            this.cdvGrp10.SelectionStart = 0;
            this.cdvGrp10.Size = new System.Drawing.Size(200, 20);
            this.cdvGrp10.SmallImageList = null;
            this.cdvGrp10.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvGrp10.TabIndex = 19;
            this.cdvGrp10.TextBoxToolTipText = "";
            this.cdvGrp10.TextBoxWidth = 200;
            this.cdvGrp10.VisibleButton = true;
            this.cdvGrp10.VisibleColumnHeader = false;
            this.cdvGrp10.VisibleDescription = false;
            this.cdvGrp10.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            // 
            // cdvGrp9
            // 
            this.cdvGrp9.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvGrp9.BorderHotColor = System.Drawing.Color.Black;
            this.cdvGrp9.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvGrp9.BtnToolTipText = "";
            this.cdvGrp9.DescText = "";
            this.cdvGrp9.DisplaySubItemIndex = -1;
            this.cdvGrp9.DisplayText = "";
            this.cdvGrp9.Focusing = null;
            this.cdvGrp9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvGrp9.Index = 0;
            this.cdvGrp9.IsViewBtnImage = false;
            this.cdvGrp9.Location = new System.Drawing.Point(172, 208);
            this.cdvGrp9.MaxLength = 30;
            this.cdvGrp9.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvGrp9.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvGrp9.Name = "cdvGrp9";
            this.cdvGrp9.ReadOnly = false;
            this.cdvGrp9.SearchSubItemIndex = 0;
            this.cdvGrp9.SelectedDescIndex = -1;
            this.cdvGrp9.SelectedSubItemIndex = -1;
            this.cdvGrp9.SelectionStart = 0;
            this.cdvGrp9.Size = new System.Drawing.Size(200, 20);
            this.cdvGrp9.SmallImageList = null;
            this.cdvGrp9.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvGrp9.TabIndex = 17;
            this.cdvGrp9.TextBoxToolTipText = "";
            this.cdvGrp9.TextBoxWidth = 200;
            this.cdvGrp9.VisibleButton = true;
            this.cdvGrp9.VisibleColumnHeader = false;
            this.cdvGrp9.VisibleDescription = false;
            this.cdvGrp9.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            // 
            // cdvGrp8
            // 
            this.cdvGrp8.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvGrp8.BorderHotColor = System.Drawing.Color.Black;
            this.cdvGrp8.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvGrp8.BtnToolTipText = "";
            this.cdvGrp8.DescText = "";
            this.cdvGrp8.DisplaySubItemIndex = -1;
            this.cdvGrp8.DisplayText = "";
            this.cdvGrp8.Focusing = null;
            this.cdvGrp8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvGrp8.Index = 0;
            this.cdvGrp8.IsViewBtnImage = false;
            this.cdvGrp8.Location = new System.Drawing.Point(172, 184);
            this.cdvGrp8.MaxLength = 30;
            this.cdvGrp8.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvGrp8.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvGrp8.Name = "cdvGrp8";
            this.cdvGrp8.ReadOnly = false;
            this.cdvGrp8.SearchSubItemIndex = 0;
            this.cdvGrp8.SelectedDescIndex = -1;
            this.cdvGrp8.SelectedSubItemIndex = -1;
            this.cdvGrp8.SelectionStart = 0;
            this.cdvGrp8.Size = new System.Drawing.Size(200, 20);
            this.cdvGrp8.SmallImageList = null;
            this.cdvGrp8.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvGrp8.TabIndex = 15;
            this.cdvGrp8.TextBoxToolTipText = "";
            this.cdvGrp8.TextBoxWidth = 200;
            this.cdvGrp8.VisibleButton = true;
            this.cdvGrp8.VisibleColumnHeader = false;
            this.cdvGrp8.VisibleDescription = false;
            this.cdvGrp8.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            // 
            // cdvGrp7
            // 
            this.cdvGrp7.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvGrp7.BorderHotColor = System.Drawing.Color.Black;
            this.cdvGrp7.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvGrp7.BtnToolTipText = "";
            this.cdvGrp7.DescText = "";
            this.cdvGrp7.DisplaySubItemIndex = -1;
            this.cdvGrp7.DisplayText = "";
            this.cdvGrp7.Focusing = null;
            this.cdvGrp7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvGrp7.Index = 0;
            this.cdvGrp7.IsViewBtnImage = false;
            this.cdvGrp7.Location = new System.Drawing.Point(172, 160);
            this.cdvGrp7.MaxLength = 30;
            this.cdvGrp7.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvGrp7.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvGrp7.Name = "cdvGrp7";
            this.cdvGrp7.ReadOnly = false;
            this.cdvGrp7.SearchSubItemIndex = 0;
            this.cdvGrp7.SelectedDescIndex = -1;
            this.cdvGrp7.SelectedSubItemIndex = -1;
            this.cdvGrp7.SelectionStart = 0;
            this.cdvGrp7.Size = new System.Drawing.Size(200, 20);
            this.cdvGrp7.SmallImageList = null;
            this.cdvGrp7.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvGrp7.TabIndex = 13;
            this.cdvGrp7.TextBoxToolTipText = "";
            this.cdvGrp7.TextBoxWidth = 200;
            this.cdvGrp7.VisibleButton = true;
            this.cdvGrp7.VisibleColumnHeader = false;
            this.cdvGrp7.VisibleDescription = false;
            this.cdvGrp7.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            // 
            // cdvGrp6
            // 
            this.cdvGrp6.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvGrp6.BorderHotColor = System.Drawing.Color.Black;
            this.cdvGrp6.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvGrp6.BtnToolTipText = "";
            this.cdvGrp6.DescText = "";
            this.cdvGrp6.DisplaySubItemIndex = -1;
            this.cdvGrp6.DisplayText = "";
            this.cdvGrp6.Focusing = null;
            this.cdvGrp6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvGrp6.Index = 0;
            this.cdvGrp6.IsViewBtnImage = false;
            this.cdvGrp6.Location = new System.Drawing.Point(172, 136);
            this.cdvGrp6.MaxLength = 30;
            this.cdvGrp6.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvGrp6.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvGrp6.Name = "cdvGrp6";
            this.cdvGrp6.ReadOnly = false;
            this.cdvGrp6.SearchSubItemIndex = 0;
            this.cdvGrp6.SelectedDescIndex = -1;
            this.cdvGrp6.SelectedSubItemIndex = -1;
            this.cdvGrp6.SelectionStart = 0;
            this.cdvGrp6.Size = new System.Drawing.Size(200, 20);
            this.cdvGrp6.SmallImageList = null;
            this.cdvGrp6.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvGrp6.TabIndex = 11;
            this.cdvGrp6.TextBoxToolTipText = "";
            this.cdvGrp6.TextBoxWidth = 200;
            this.cdvGrp6.VisibleButton = true;
            this.cdvGrp6.VisibleColumnHeader = false;
            this.cdvGrp6.VisibleDescription = false;
            this.cdvGrp6.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            // 
            // cdvGrp5
            // 
            this.cdvGrp5.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvGrp5.BorderHotColor = System.Drawing.Color.Black;
            this.cdvGrp5.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvGrp5.BtnToolTipText = "";
            this.cdvGrp5.DescText = "";
            this.cdvGrp5.DisplaySubItemIndex = -1;
            this.cdvGrp5.DisplayText = "";
            this.cdvGrp5.Focusing = null;
            this.cdvGrp5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvGrp5.Index = 0;
            this.cdvGrp5.IsViewBtnImage = false;
            this.cdvGrp5.Location = new System.Drawing.Point(172, 112);
            this.cdvGrp5.MaxLength = 30;
            this.cdvGrp5.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvGrp5.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvGrp5.Name = "cdvGrp5";
            this.cdvGrp5.ReadOnly = false;
            this.cdvGrp5.SearchSubItemIndex = 0;
            this.cdvGrp5.SelectedDescIndex = -1;
            this.cdvGrp5.SelectedSubItemIndex = -1;
            this.cdvGrp5.SelectionStart = 0;
            this.cdvGrp5.Size = new System.Drawing.Size(200, 20);
            this.cdvGrp5.SmallImageList = null;
            this.cdvGrp5.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvGrp5.TabIndex = 9;
            this.cdvGrp5.TextBoxToolTipText = "";
            this.cdvGrp5.TextBoxWidth = 200;
            this.cdvGrp5.VisibleButton = true;
            this.cdvGrp5.VisibleColumnHeader = false;
            this.cdvGrp5.VisibleDescription = false;
            this.cdvGrp5.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            // 
            // cdvGrp4
            // 
            this.cdvGrp4.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvGrp4.BorderHotColor = System.Drawing.Color.Black;
            this.cdvGrp4.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvGrp4.BtnToolTipText = "";
            this.cdvGrp4.DescText = "";
            this.cdvGrp4.DisplaySubItemIndex = -1;
            this.cdvGrp4.DisplayText = "";
            this.cdvGrp4.Focusing = null;
            this.cdvGrp4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvGrp4.Index = 0;
            this.cdvGrp4.IsViewBtnImage = false;
            this.cdvGrp4.Location = new System.Drawing.Point(172, 88);
            this.cdvGrp4.MaxLength = 30;
            this.cdvGrp4.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvGrp4.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvGrp4.Name = "cdvGrp4";
            this.cdvGrp4.ReadOnly = false;
            this.cdvGrp4.SearchSubItemIndex = 0;
            this.cdvGrp4.SelectedDescIndex = -1;
            this.cdvGrp4.SelectedSubItemIndex = -1;
            this.cdvGrp4.SelectionStart = 0;
            this.cdvGrp4.Size = new System.Drawing.Size(200, 20);
            this.cdvGrp4.SmallImageList = null;
            this.cdvGrp4.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvGrp4.TabIndex = 7;
            this.cdvGrp4.TextBoxToolTipText = "";
            this.cdvGrp4.TextBoxWidth = 200;
            this.cdvGrp4.VisibleButton = true;
            this.cdvGrp4.VisibleColumnHeader = false;
            this.cdvGrp4.VisibleDescription = false;
            this.cdvGrp4.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            // 
            // cdvGrp3
            // 
            this.cdvGrp3.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvGrp3.BorderHotColor = System.Drawing.Color.Black;
            this.cdvGrp3.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvGrp3.BtnToolTipText = "";
            this.cdvGrp3.DescText = "";
            this.cdvGrp3.DisplaySubItemIndex = -1;
            this.cdvGrp3.DisplayText = "";
            this.cdvGrp3.Focusing = null;
            this.cdvGrp3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvGrp3.Index = 0;
            this.cdvGrp3.IsViewBtnImage = false;
            this.cdvGrp3.Location = new System.Drawing.Point(172, 64);
            this.cdvGrp3.MaxLength = 30;
            this.cdvGrp3.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvGrp3.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvGrp3.Name = "cdvGrp3";
            this.cdvGrp3.ReadOnly = false;
            this.cdvGrp3.SearchSubItemIndex = 0;
            this.cdvGrp3.SelectedDescIndex = -1;
            this.cdvGrp3.SelectedSubItemIndex = -1;
            this.cdvGrp3.SelectionStart = 0;
            this.cdvGrp3.Size = new System.Drawing.Size(200, 20);
            this.cdvGrp3.SmallImageList = null;
            this.cdvGrp3.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvGrp3.TabIndex = 5;
            this.cdvGrp3.TextBoxToolTipText = "";
            this.cdvGrp3.TextBoxWidth = 200;
            this.cdvGrp3.VisibleButton = true;
            this.cdvGrp3.VisibleColumnHeader = false;
            this.cdvGrp3.VisibleDescription = false;
            this.cdvGrp3.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            // 
            // cdvGrp2
            // 
            this.cdvGrp2.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvGrp2.BorderHotColor = System.Drawing.Color.Black;
            this.cdvGrp2.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvGrp2.BtnToolTipText = "";
            this.cdvGrp2.DescText = "";
            this.cdvGrp2.DisplaySubItemIndex = -1;
            this.cdvGrp2.DisplayText = "";
            this.cdvGrp2.Focusing = null;
            this.cdvGrp2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvGrp2.Index = 0;
            this.cdvGrp2.IsViewBtnImage = false;
            this.cdvGrp2.Location = new System.Drawing.Point(172, 40);
            this.cdvGrp2.MaxLength = 30;
            this.cdvGrp2.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvGrp2.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvGrp2.Name = "cdvGrp2";
            this.cdvGrp2.ReadOnly = false;
            this.cdvGrp2.SearchSubItemIndex = 0;
            this.cdvGrp2.SelectedDescIndex = -1;
            this.cdvGrp2.SelectedSubItemIndex = -1;
            this.cdvGrp2.SelectionStart = 0;
            this.cdvGrp2.Size = new System.Drawing.Size(200, 20);
            this.cdvGrp2.SmallImageList = null;
            this.cdvGrp2.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvGrp2.TabIndex = 3;
            this.cdvGrp2.TextBoxToolTipText = "";
            this.cdvGrp2.TextBoxWidth = 200;
            this.cdvGrp2.VisibleButton = true;
            this.cdvGrp2.VisibleColumnHeader = false;
            this.cdvGrp2.VisibleDescription = false;
            this.cdvGrp2.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            // 
            // cdvGrp1
            // 
            this.cdvGrp1.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvGrp1.BorderHotColor = System.Drawing.Color.Black;
            this.cdvGrp1.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvGrp1.BtnToolTipText = "";
            this.cdvGrp1.DescText = "";
            this.cdvGrp1.DisplaySubItemIndex = -1;
            this.cdvGrp1.DisplayText = "";
            this.cdvGrp1.Focusing = null;
            this.cdvGrp1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvGrp1.Index = 0;
            this.cdvGrp1.IsViewBtnImage = false;
            this.cdvGrp1.Location = new System.Drawing.Point(172, 16);
            this.cdvGrp1.MaxLength = 30;
            this.cdvGrp1.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvGrp1.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvGrp1.Name = "cdvGrp1";
            this.cdvGrp1.ReadOnly = false;
            this.cdvGrp1.SearchSubItemIndex = 0;
            this.cdvGrp1.SelectedDescIndex = -1;
            this.cdvGrp1.SelectedSubItemIndex = -1;
            this.cdvGrp1.SelectionStart = 0;
            this.cdvGrp1.Size = new System.Drawing.Size(200, 20);
            this.cdvGrp1.SmallImageList = null;
            this.cdvGrp1.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvGrp1.TabIndex = 1;
            this.cdvGrp1.TextBoxToolTipText = "";
            this.cdvGrp1.TextBoxWidth = 200;
            this.cdvGrp1.VisibleButton = true;
            this.cdvGrp1.VisibleColumnHeader = false;
            this.cdvGrp1.VisibleDescription = false;
            this.cdvGrp1.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            // 
            // lblGrp10
            // 
            this.lblGrp10.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblGrp10.Location = new System.Drawing.Point(15, 235);
            this.lblGrp10.Name = "lblGrp10";
            this.lblGrp10.Size = new System.Drawing.Size(150, 14);
            this.lblGrp10.TabIndex = 18;
            // 
            // lblGrp9
            // 
            this.lblGrp9.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblGrp9.Location = new System.Drawing.Point(15, 211);
            this.lblGrp9.Name = "lblGrp9";
            this.lblGrp9.Size = new System.Drawing.Size(150, 14);
            this.lblGrp9.TabIndex = 16;
            // 
            // lblGrp8
            // 
            this.lblGrp8.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblGrp8.Location = new System.Drawing.Point(15, 187);
            this.lblGrp8.Name = "lblGrp8";
            this.lblGrp8.Size = new System.Drawing.Size(150, 14);
            this.lblGrp8.TabIndex = 14;
            // 
            // lblGrp7
            // 
            this.lblGrp7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblGrp7.Location = new System.Drawing.Point(15, 163);
            this.lblGrp7.Name = "lblGrp7";
            this.lblGrp7.Size = new System.Drawing.Size(150, 14);
            this.lblGrp7.TabIndex = 12;
            // 
            // lblGrp6
            // 
            this.lblGrp6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblGrp6.Location = new System.Drawing.Point(15, 139);
            this.lblGrp6.Name = "lblGrp6";
            this.lblGrp6.Size = new System.Drawing.Size(150, 14);
            this.lblGrp6.TabIndex = 10;
            // 
            // lblGrp5
            // 
            this.lblGrp5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblGrp5.Location = new System.Drawing.Point(15, 115);
            this.lblGrp5.Name = "lblGrp5";
            this.lblGrp5.Size = new System.Drawing.Size(150, 14);
            this.lblGrp5.TabIndex = 8;
            // 
            // lblGrp4
            // 
            this.lblGrp4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblGrp4.Location = new System.Drawing.Point(15, 91);
            this.lblGrp4.Name = "lblGrp4";
            this.lblGrp4.Size = new System.Drawing.Size(150, 14);
            this.lblGrp4.TabIndex = 6;
            // 
            // lblGrp3
            // 
            this.lblGrp3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblGrp3.Location = new System.Drawing.Point(15, 67);
            this.lblGrp3.Name = "lblGrp3";
            this.lblGrp3.Size = new System.Drawing.Size(150, 14);
            this.lblGrp3.TabIndex = 4;
            // 
            // lblGrp2
            // 
            this.lblGrp2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblGrp2.Location = new System.Drawing.Point(15, 43);
            this.lblGrp2.Name = "lblGrp2";
            this.lblGrp2.Size = new System.Drawing.Size(150, 14);
            this.lblGrp2.TabIndex = 2;
            // 
            // lblGrp1
            // 
            this.lblGrp1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblGrp1.Location = new System.Drawing.Point(15, 19);
            this.lblGrp1.Name = "lblGrp1";
            this.lblGrp1.Size = new System.Drawing.Size(150, 14);
            this.lblGrp1.TabIndex = 0;
            // 
            // tbpCMF
            // 
            this.tbpCMF.Controls.Add(this.grpCMF);
            this.tbpCMF.Location = new System.Drawing.Point(4, 22);
            this.tbpCMF.Name = "tbpCMF";
            this.tbpCMF.Size = new System.Drawing.Size(494, 406);
            this.tbpCMF.TabIndex = 2;
            this.tbpCMF.Text = "Customized Field";
            // 
            // grpCMF
            // 
            this.grpCMF.Controls.Add(this.cdvCMF10);
            this.grpCMF.Controls.Add(this.cdvCMF9);
            this.grpCMF.Controls.Add(this.cdvCMF8);
            this.grpCMF.Controls.Add(this.cdvCMF7);
            this.grpCMF.Controls.Add(this.cdvCMF6);
            this.grpCMF.Controls.Add(this.cdvCMF5);
            this.grpCMF.Controls.Add(this.cdvCMF4);
            this.grpCMF.Controls.Add(this.cdvCMF3);
            this.grpCMF.Controls.Add(this.cdvCMF2);
            this.grpCMF.Controls.Add(this.cdvCMF1);
            this.grpCMF.Controls.Add(this.lblCMF10);
            this.grpCMF.Controls.Add(this.lblCMF9);
            this.grpCMF.Controls.Add(this.lblCMF8);
            this.grpCMF.Controls.Add(this.lblCMF7);
            this.grpCMF.Controls.Add(this.lblCMF6);
            this.grpCMF.Controls.Add(this.lblCMF5);
            this.grpCMF.Controls.Add(this.lblCMF4);
            this.grpCMF.Controls.Add(this.lblCMF3);
            this.grpCMF.Controls.Add(this.lblCMF2);
            this.grpCMF.Controls.Add(this.lblCMF1);
            this.grpCMF.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpCMF.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpCMF.Location = new System.Drawing.Point(0, 0);
            this.grpCMF.Name = "grpCMF";
            this.grpCMF.Size = new System.Drawing.Size(494, 406);
            this.grpCMF.TabIndex = 2;
            this.grpCMF.TabStop = false;
            // 
            // cdvCMF10
            // 
            this.cdvCMF10.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF10.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF10.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF10.BtnToolTipText = "";
            this.cdvCMF10.DescText = "";
            this.cdvCMF10.DisplaySubItemIndex = -1;
            this.cdvCMF10.DisplayText = "";
            this.cdvCMF10.Focusing = null;
            this.cdvCMF10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF10.Index = 0;
            this.cdvCMF10.IsViewBtnImage = false;
            this.cdvCMF10.Location = new System.Drawing.Point(172, 232);
            this.cdvCMF10.MaxLength = 30;
            this.cdvCMF10.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF10.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF10.Name = "cdvCMF10";
            this.cdvCMF10.ReadOnly = false;
            this.cdvCMF10.SearchSubItemIndex = 0;
            this.cdvCMF10.SelectedDescIndex = -1;
            this.cdvCMF10.SelectedSubItemIndex = -1;
            this.cdvCMF10.SelectionStart = 0;
            this.cdvCMF10.Size = new System.Drawing.Size(200, 20);
            this.cdvCMF10.SmallImageList = null;
            this.cdvCMF10.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF10.TabIndex = 19;
            this.cdvCMF10.TextBoxToolTipText = "";
            this.cdvCMF10.TextBoxWidth = 200;
            this.cdvCMF10.VisibleButton = true;
            this.cdvCMF10.VisibleColumnHeader = false;
            this.cdvCMF10.VisibleDescription = false;
            this.cdvCMF10.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            this.cdvCMF10.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvCMF9
            // 
            this.cdvCMF9.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF9.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF9.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF9.BtnToolTipText = "";
            this.cdvCMF9.DescText = "";
            this.cdvCMF9.DisplaySubItemIndex = -1;
            this.cdvCMF9.DisplayText = "";
            this.cdvCMF9.Focusing = null;
            this.cdvCMF9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF9.Index = 0;
            this.cdvCMF9.IsViewBtnImage = false;
            this.cdvCMF9.Location = new System.Drawing.Point(172, 208);
            this.cdvCMF9.MaxLength = 30;
            this.cdvCMF9.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF9.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF9.Name = "cdvCMF9";
            this.cdvCMF9.ReadOnly = false;
            this.cdvCMF9.SearchSubItemIndex = 0;
            this.cdvCMF9.SelectedDescIndex = -1;
            this.cdvCMF9.SelectedSubItemIndex = -1;
            this.cdvCMF9.SelectionStart = 0;
            this.cdvCMF9.Size = new System.Drawing.Size(200, 20);
            this.cdvCMF9.SmallImageList = null;
            this.cdvCMF9.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF9.TabIndex = 17;
            this.cdvCMF9.TextBoxToolTipText = "";
            this.cdvCMF9.TextBoxWidth = 200;
            this.cdvCMF9.VisibleButton = true;
            this.cdvCMF9.VisibleColumnHeader = false;
            this.cdvCMF9.VisibleDescription = false;
            this.cdvCMF9.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            this.cdvCMF9.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvCMF8
            // 
            this.cdvCMF8.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF8.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF8.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF8.BtnToolTipText = "";
            this.cdvCMF8.DescText = "";
            this.cdvCMF8.DisplaySubItemIndex = -1;
            this.cdvCMF8.DisplayText = "";
            this.cdvCMF8.Focusing = null;
            this.cdvCMF8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF8.Index = 0;
            this.cdvCMF8.IsViewBtnImage = false;
            this.cdvCMF8.Location = new System.Drawing.Point(172, 184);
            this.cdvCMF8.MaxLength = 30;
            this.cdvCMF8.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF8.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF8.Name = "cdvCMF8";
            this.cdvCMF8.ReadOnly = false;
            this.cdvCMF8.SearchSubItemIndex = 0;
            this.cdvCMF8.SelectedDescIndex = -1;
            this.cdvCMF8.SelectedSubItemIndex = -1;
            this.cdvCMF8.SelectionStart = 0;
            this.cdvCMF8.Size = new System.Drawing.Size(200, 20);
            this.cdvCMF8.SmallImageList = null;
            this.cdvCMF8.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF8.TabIndex = 15;
            this.cdvCMF8.TextBoxToolTipText = "";
            this.cdvCMF8.TextBoxWidth = 200;
            this.cdvCMF8.VisibleButton = true;
            this.cdvCMF8.VisibleColumnHeader = false;
            this.cdvCMF8.VisibleDescription = false;
            this.cdvCMF8.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            this.cdvCMF8.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvCMF7
            // 
            this.cdvCMF7.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF7.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF7.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF7.BtnToolTipText = "";
            this.cdvCMF7.DescText = "";
            this.cdvCMF7.DisplaySubItemIndex = -1;
            this.cdvCMF7.DisplayText = "";
            this.cdvCMF7.Focusing = null;
            this.cdvCMF7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF7.Index = 0;
            this.cdvCMF7.IsViewBtnImage = false;
            this.cdvCMF7.Location = new System.Drawing.Point(172, 160);
            this.cdvCMF7.MaxLength = 30;
            this.cdvCMF7.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF7.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF7.Name = "cdvCMF7";
            this.cdvCMF7.ReadOnly = false;
            this.cdvCMF7.SearchSubItemIndex = 0;
            this.cdvCMF7.SelectedDescIndex = -1;
            this.cdvCMF7.SelectedSubItemIndex = -1;
            this.cdvCMF7.SelectionStart = 0;
            this.cdvCMF7.Size = new System.Drawing.Size(200, 20);
            this.cdvCMF7.SmallImageList = null;
            this.cdvCMF7.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF7.TabIndex = 13;
            this.cdvCMF7.TextBoxToolTipText = "";
            this.cdvCMF7.TextBoxWidth = 200;
            this.cdvCMF7.VisibleButton = true;
            this.cdvCMF7.VisibleColumnHeader = false;
            this.cdvCMF7.VisibleDescription = false;
            this.cdvCMF7.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            this.cdvCMF7.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvCMF6
            // 
            this.cdvCMF6.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF6.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF6.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF6.BtnToolTipText = "";
            this.cdvCMF6.DescText = "";
            this.cdvCMF6.DisplaySubItemIndex = -1;
            this.cdvCMF6.DisplayText = "";
            this.cdvCMF6.Focusing = null;
            this.cdvCMF6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF6.Index = 0;
            this.cdvCMF6.IsViewBtnImage = false;
            this.cdvCMF6.Location = new System.Drawing.Point(172, 136);
            this.cdvCMF6.MaxLength = 30;
            this.cdvCMF6.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF6.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF6.Name = "cdvCMF6";
            this.cdvCMF6.ReadOnly = false;
            this.cdvCMF6.SearchSubItemIndex = 0;
            this.cdvCMF6.SelectedDescIndex = -1;
            this.cdvCMF6.SelectedSubItemIndex = -1;
            this.cdvCMF6.SelectionStart = 0;
            this.cdvCMF6.Size = new System.Drawing.Size(200, 20);
            this.cdvCMF6.SmallImageList = null;
            this.cdvCMF6.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF6.TabIndex = 11;
            this.cdvCMF6.TextBoxToolTipText = "";
            this.cdvCMF6.TextBoxWidth = 200;
            this.cdvCMF6.VisibleButton = true;
            this.cdvCMF6.VisibleColumnHeader = false;
            this.cdvCMF6.VisibleDescription = false;
            this.cdvCMF6.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            this.cdvCMF6.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvCMF5
            // 
            this.cdvCMF5.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF5.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF5.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF5.BtnToolTipText = "";
            this.cdvCMF5.DescText = "";
            this.cdvCMF5.DisplaySubItemIndex = -1;
            this.cdvCMF5.DisplayText = "";
            this.cdvCMF5.Focusing = null;
            this.cdvCMF5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF5.Index = 0;
            this.cdvCMF5.IsViewBtnImage = false;
            this.cdvCMF5.Location = new System.Drawing.Point(172, 112);
            this.cdvCMF5.MaxLength = 30;
            this.cdvCMF5.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF5.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF5.Name = "cdvCMF5";
            this.cdvCMF5.ReadOnly = false;
            this.cdvCMF5.SearchSubItemIndex = 0;
            this.cdvCMF5.SelectedDescIndex = -1;
            this.cdvCMF5.SelectedSubItemIndex = -1;
            this.cdvCMF5.SelectionStart = 0;
            this.cdvCMF5.Size = new System.Drawing.Size(200, 20);
            this.cdvCMF5.SmallImageList = null;
            this.cdvCMF5.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF5.TabIndex = 9;
            this.cdvCMF5.TextBoxToolTipText = "";
            this.cdvCMF5.TextBoxWidth = 200;
            this.cdvCMF5.VisibleButton = true;
            this.cdvCMF5.VisibleColumnHeader = false;
            this.cdvCMF5.VisibleDescription = false;
            this.cdvCMF5.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            this.cdvCMF5.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvCMF4
            // 
            this.cdvCMF4.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF4.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF4.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF4.BtnToolTipText = "";
            this.cdvCMF4.DescText = "";
            this.cdvCMF4.DisplaySubItemIndex = -1;
            this.cdvCMF4.DisplayText = "";
            this.cdvCMF4.Focusing = null;
            this.cdvCMF4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF4.Index = 0;
            this.cdvCMF4.IsViewBtnImage = false;
            this.cdvCMF4.Location = new System.Drawing.Point(172, 88);
            this.cdvCMF4.MaxLength = 30;
            this.cdvCMF4.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF4.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF4.Name = "cdvCMF4";
            this.cdvCMF4.ReadOnly = false;
            this.cdvCMF4.SearchSubItemIndex = 0;
            this.cdvCMF4.SelectedDescIndex = -1;
            this.cdvCMF4.SelectedSubItemIndex = -1;
            this.cdvCMF4.SelectionStart = 0;
            this.cdvCMF4.Size = new System.Drawing.Size(200, 20);
            this.cdvCMF4.SmallImageList = null;
            this.cdvCMF4.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF4.TabIndex = 7;
            this.cdvCMF4.TextBoxToolTipText = "";
            this.cdvCMF4.TextBoxWidth = 200;
            this.cdvCMF4.VisibleButton = true;
            this.cdvCMF4.VisibleColumnHeader = false;
            this.cdvCMF4.VisibleDescription = false;
            this.cdvCMF4.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            this.cdvCMF4.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvCMF3
            // 
            this.cdvCMF3.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF3.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF3.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF3.BtnToolTipText = "";
            this.cdvCMF3.DescText = "";
            this.cdvCMF3.DisplaySubItemIndex = -1;
            this.cdvCMF3.DisplayText = "";
            this.cdvCMF3.Focusing = null;
            this.cdvCMF3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF3.Index = 0;
            this.cdvCMF3.IsViewBtnImage = false;
            this.cdvCMF3.Location = new System.Drawing.Point(172, 64);
            this.cdvCMF3.MaxLength = 30;
            this.cdvCMF3.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF3.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF3.Name = "cdvCMF3";
            this.cdvCMF3.ReadOnly = false;
            this.cdvCMF3.SearchSubItemIndex = 0;
            this.cdvCMF3.SelectedDescIndex = -1;
            this.cdvCMF3.SelectedSubItemIndex = -1;
            this.cdvCMF3.SelectionStart = 0;
            this.cdvCMF3.Size = new System.Drawing.Size(200, 20);
            this.cdvCMF3.SmallImageList = null;
            this.cdvCMF3.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF3.TabIndex = 5;
            this.cdvCMF3.TextBoxToolTipText = "";
            this.cdvCMF3.TextBoxWidth = 200;
            this.cdvCMF3.VisibleButton = true;
            this.cdvCMF3.VisibleColumnHeader = false;
            this.cdvCMF3.VisibleDescription = false;
            this.cdvCMF3.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            this.cdvCMF3.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvCMF2
            // 
            this.cdvCMF2.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF2.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF2.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF2.BtnToolTipText = "";
            this.cdvCMF2.DescText = "";
            this.cdvCMF2.DisplaySubItemIndex = -1;
            this.cdvCMF2.DisplayText = "";
            this.cdvCMF2.Focusing = null;
            this.cdvCMF2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF2.Index = 0;
            this.cdvCMF2.IsViewBtnImage = false;
            this.cdvCMF2.Location = new System.Drawing.Point(172, 40);
            this.cdvCMF2.MaxLength = 30;
            this.cdvCMF2.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF2.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF2.Name = "cdvCMF2";
            this.cdvCMF2.ReadOnly = false;
            this.cdvCMF2.SearchSubItemIndex = 0;
            this.cdvCMF2.SelectedDescIndex = -1;
            this.cdvCMF2.SelectedSubItemIndex = -1;
            this.cdvCMF2.SelectionStart = 0;
            this.cdvCMF2.Size = new System.Drawing.Size(200, 20);
            this.cdvCMF2.SmallImageList = null;
            this.cdvCMF2.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF2.TabIndex = 3;
            this.cdvCMF2.TextBoxToolTipText = "";
            this.cdvCMF2.TextBoxWidth = 200;
            this.cdvCMF2.VisibleButton = true;
            this.cdvCMF2.VisibleColumnHeader = false;
            this.cdvCMF2.VisibleDescription = false;
            this.cdvCMF2.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            this.cdvCMF2.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvCMF1
            // 
            this.cdvCMF1.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF1.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF1.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF1.BtnToolTipText = "";
            this.cdvCMF1.DescText = "";
            this.cdvCMF1.DisplaySubItemIndex = -1;
            this.cdvCMF1.DisplayText = "";
            this.cdvCMF1.Focusing = null;
            this.cdvCMF1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF1.Index = 0;
            this.cdvCMF1.IsViewBtnImage = false;
            this.cdvCMF1.Location = new System.Drawing.Point(172, 16);
            this.cdvCMF1.MaxLength = 30;
            this.cdvCMF1.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF1.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF1.Name = "cdvCMF1";
            this.cdvCMF1.ReadOnly = false;
            this.cdvCMF1.SearchSubItemIndex = 0;
            this.cdvCMF1.SelectedDescIndex = -1;
            this.cdvCMF1.SelectedSubItemIndex = -1;
            this.cdvCMF1.SelectionStart = 0;
            this.cdvCMF1.Size = new System.Drawing.Size(200, 20);
            this.cdvCMF1.SmallImageList = null;
            this.cdvCMF1.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF1.TabIndex = 1;
            this.cdvCMF1.TextBoxToolTipText = "";
            this.cdvCMF1.TextBoxWidth = 200;
            this.cdvCMF1.VisibleButton = true;
            this.cdvCMF1.VisibleColumnHeader = false;
            this.cdvCMF1.VisibleDescription = false;
            this.cdvCMF1.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            this.cdvCMF1.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // lblCMF10
            // 
            this.lblCMF10.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF10.Location = new System.Drawing.Point(15, 235);
            this.lblCMF10.Name = "lblCMF10";
            this.lblCMF10.Size = new System.Drawing.Size(150, 14);
            this.lblCMF10.TabIndex = 18;
            // 
            // lblCMF9
            // 
            this.lblCMF9.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF9.Location = new System.Drawing.Point(15, 211);
            this.lblCMF9.Name = "lblCMF9";
            this.lblCMF9.Size = new System.Drawing.Size(150, 14);
            this.lblCMF9.TabIndex = 16;
            // 
            // lblCMF8
            // 
            this.lblCMF8.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF8.Location = new System.Drawing.Point(15, 187);
            this.lblCMF8.Name = "lblCMF8";
            this.lblCMF8.Size = new System.Drawing.Size(150, 14);
            this.lblCMF8.TabIndex = 14;
            // 
            // lblCMF7
            // 
            this.lblCMF7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF7.Location = new System.Drawing.Point(15, 163);
            this.lblCMF7.Name = "lblCMF7";
            this.lblCMF7.Size = new System.Drawing.Size(150, 14);
            this.lblCMF7.TabIndex = 12;
            // 
            // lblCMF6
            // 
            this.lblCMF6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF6.Location = new System.Drawing.Point(15, 139);
            this.lblCMF6.Name = "lblCMF6";
            this.lblCMF6.Size = new System.Drawing.Size(150, 14);
            this.lblCMF6.TabIndex = 10;
            // 
            // lblCMF5
            // 
            this.lblCMF5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF5.Location = new System.Drawing.Point(15, 115);
            this.lblCMF5.Name = "lblCMF5";
            this.lblCMF5.Size = new System.Drawing.Size(150, 14);
            this.lblCMF5.TabIndex = 8;
            // 
            // lblCMF4
            // 
            this.lblCMF4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF4.Location = new System.Drawing.Point(15, 91);
            this.lblCMF4.Name = "lblCMF4";
            this.lblCMF4.Size = new System.Drawing.Size(150, 14);
            this.lblCMF4.TabIndex = 6;
            // 
            // lblCMF3
            // 
            this.lblCMF3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF3.Location = new System.Drawing.Point(15, 67);
            this.lblCMF3.Name = "lblCMF3";
            this.lblCMF3.Size = new System.Drawing.Size(150, 14);
            this.lblCMF3.TabIndex = 4;
            // 
            // lblCMF2
            // 
            this.lblCMF2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF2.Location = new System.Drawing.Point(15, 43);
            this.lblCMF2.Name = "lblCMF2";
            this.lblCMF2.Size = new System.Drawing.Size(150, 14);
            this.lblCMF2.TabIndex = 2;
            // 
            // lblCMF1
            // 
            this.lblCMF1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF1.Location = new System.Drawing.Point(15, 19);
            this.lblCMF1.Name = "lblCMF1";
            this.lblCMF1.Size = new System.Drawing.Size(150, 14);
            this.lblCMF1.TabIndex = 0;
            // 
            // grpChart
            // 
            this.grpChart.Controls.Add(this.lblDesc);
            this.grpChart.Controls.Add(this.lblChartSet);
            this.grpChart.Controls.Add(this.txtDesc);
            this.grpChart.Controls.Add(this.txtChartSet);
            this.grpChart.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpChart.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpChart.Location = new System.Drawing.Point(5, 3);
            this.grpChart.Name = "grpChart";
            this.grpChart.Size = new System.Drawing.Size(502, 71);
            this.grpChart.TabIndex = 0;
            this.grpChart.TabStop = false;
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblDesc.Location = new System.Drawing.Point(15, 43);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(60, 13);
            this.lblDesc.TabIndex = 2;
            this.lblDesc.Text = "Description";
            // 
            // lblChartSet
            // 
            this.lblChartSet.AutoSize = true;
            this.lblChartSet.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblChartSet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChartSet.Location = new System.Drawing.Point(15, 19);
            this.lblChartSet.Name = "lblChartSet";
            this.lblChartSet.Size = new System.Drawing.Size(77, 13);
            this.lblChartSet.TabIndex = 0;
            this.lblChartSet.Text = "Chart Set ID";
            // 
            // txtDesc
            // 
            this.txtDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDesc.Location = new System.Drawing.Point(120, 40);
            this.txtDesc.MaxLength = 50;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(360, 20);
            this.txtDesc.TabIndex = 1;
            // 
            // txtChartSet
            // 
            this.txtChartSet.Location = new System.Drawing.Point(120, 16);
            this.txtChartSet.MaxLength = 30;
            this.txtChartSet.Name = "txtChartSet";
            this.txtChartSet.Size = new System.Drawing.Size(200, 20);
            this.txtChartSet.TabIndex = 0;
            this.txtChartSet.TextChanged += new System.EventHandler(this.txtChartSet_TextChanged);
            // 
            // splMain
            // 
            this.splMain.Location = new System.Drawing.Point(232, 0);
            this.splMain.Name = "splMain";
            this.splMain.Size = new System.Drawing.Size(3, 506);
            this.splMain.TabIndex = 1;
            this.splMain.TabStop = false;
            // 
            // frmSPCSetupChartSet
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Controls.Add(this.splMain);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.pnlBottom);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(750, 580);
            this.Name = "frmSPCSetupChartSet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Chart Set Setup";
            this.Activated += new System.EventHandler(this.frmSPCSetupChartSet_Activated);
            this.Load += new System.EventHandler(this.frmSPCSetupChartSet_Load);
            this.pnlBottom.ResumeLayout(false);
            this.pnlFind.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtFind)).EndInit();
            this.pnlLeft.ResumeLayout(false);
            this.pnlRight.ResumeLayout(false);
            this.tabChartSet.ResumeLayout(false);
            this.tbpGeneral.ResumeLayout(false);
            this.grpRight.ResumeLayout(false);
            this.pnlMid.ResumeLayout(false);
            this.pnlMidRight.ResumeLayout(false);
            this.pnlFilter.ResumeLayout(false);
            this.grpFilter.ResumeLayout(false);
            this.grpFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFilter)).EndInit();
            this.pnlAttach.ResumeLayout(false);
            this.pnlMidLeft.ResumeLayout(false);
            this.grpComment.ResumeLayout(false);
            this.grpComment.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtComment)).EndInit();
            this.grpLotResource.ResumeLayout(false);
            this.grpLotResource.PerformLayout();
            this.tbpGroup.ResumeLayout(false);
            this.grpGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cdvGrp10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGrp9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGrp8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGrp7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGrp6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGrp5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGrp4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGrp3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGrp2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGrp1)).EndInit();
            this.tbpCMF.ResumeLayout(false);
            this.grpCMF.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF1)).EndInit();
            this.grpChart.ResumeLayout(false);
            this.grpChart.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDesc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtChartSet)).EndInit();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Variable Definition"
        
        bool b_load_flag;
        
        #endregion
        
        #region " Function Implementations"
        
        // CheckCondition()
        //       - Check the conditions before transaction
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal FuncName As String : Function Name
        //
        private bool CheckCondition(string FuncName)
        {
            
            try
            {
                if (txtChartSet.Text == "")
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                    txtChartSet.Focus();
                    return false;
                }

                switch (FuncName)
                {
                    case "I":
                        if (rbnLot.Checked == false && rbnResource.Checked == false)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(108));
                            rbnLot.Focus();
                            return false;
                        }
                        
                        if (MPCR.CheckGRPCMFValue("lblGrp", "cdvGrp", grpGroup) == false)
                        {
                            return false;
                        }
                        if (MPCR.CheckGRPCMFValue("lblCMF", "cdvCMF", grpCMF) == false)
                        {
                            return false;
                        }
                        break;
                        
                    case "U":
                        
                        if (rbnLot.Checked == false && rbnResource.Checked == false)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(108));
                            rbnLot.Focus();
                            return false;
                        }
                        
                        if (MPCR.CheckGRPCMFValue("lblGrp", "cdvGrp", grpGroup) == false)
                        {
                            return false;
                        }
                        if (MPCR.CheckGRPCMFValue("lblCMF", "cdvCMF", grpCMF) == false)
                        {
                            return false;
                        }
                        break;
                    case "ATTACH":
                        
                        if (lisChartSet.SelectedItems.Count <= 0)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(109));
                            if (lisChartSet.Items.Count > 0)
                            {
                                lisChartSet.Items[0].Selected = true;
                                lisChartSet.Focus();
                            }
                            return false;
                        }
                        if (lisChart.SelectedItems.Count <= 0)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(109));
                            if (lisChart.Items.Count > 0)
                            {
                                lisChart.Items[0].Selected = true;
                                lisChart.Focus();
                            }
                            return false;
                        }
                        break;
                    case "DETACH":
                        
                        if (lisChartSet.SelectedItems.Count <= 0)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(109));
                            if (lisChartSet.Items.Count > 0)
                            {
                                lisChartSet.Items[0].Selected = true;
                                lisChartSet.Focus();
                            }
                            return false;
                        }
                        if (lisAttachChart.SelectedItems.Count <= 0)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(109));
                            if (lisAttachChart.Items.Count > 0)
                            {
                                lisAttachChart.Items[0].Selected = true;
                                lisAttachChart.Focus();
                            }
                            return false;
                        }
                        break;
                }
                
                return true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCSetupChartSet.CheckCondition()\n" + ex.Message);
                return false;
            }
            
        }
        
        // SetGroupCmfItem()
        //       - Set Group / Cmf Property to control
        // Return Value
        //       -
        // Arguments
        //        -
        private void SetGroupCmfItem()
        {
            string[] sGrpTableName = new string[10];
            
            sGrpTableName[0] = MPGC.MP_GCM_CHTSET_GRP_1;
            sGrpTableName[1] = MPGC.MP_GCM_CHTSET_GRP_2;
            sGrpTableName[2] = MPGC.MP_GCM_CHTSET_GRP_3;
            sGrpTableName[3] = MPGC.MP_GCM_CHTSET_GRP_4;
            sGrpTableName[4] = MPGC.MP_GCM_CHTSET_GRP_5;
            sGrpTableName[5] = MPGC.MP_GCM_CHTSET_GRP_6;
            sGrpTableName[6] = MPGC.MP_GCM_CHTSET_GRP_7;
            sGrpTableName[7] = MPGC.MP_GCM_CHTSET_GRP_8;
            sGrpTableName[8] = MPGC.MP_GCM_CHTSET_GRP_9;
            sGrpTableName[9] = MPGC.MP_GCM_CHTSET_GRP_10;
            
            MPCR.SetGRPItem(MPGC.MP_GRP_CHART_SET, "lblGrp", "cdvGrp", grpGroup, sGrpTableName);
            MPCR.SetCMFItem(MPGC.MP_CMF_CHART_SET, "lblCmf", "cdvCmf", grpCMF);
            
        }
        
        // Update_ChartSet()
        //       - Create/Update/Delete Chart Set
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal c_step As String : Process Step
        //
        private bool Update_ChartSet(char c_step)
        {
            
            try
            {
                TRSNode in_node = new TRSNode("Update_Chart_Set_In");
                TRSNode out_node = new TRSNode("Cmn_Out");
                
                int idx;
                ListViewItem itm;

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = c_step;
                in_node.AddString("CHART_SET_ID", MPCF.Trim(txtChartSet.Text));
                in_node.AddString("CHART_SET_DESC", MPCF.Trim(txtDesc.Text));

                in_node.AddChar("LOT_RES_FLAG", (rbnLot.Checked == true ? 'L' : 'R'));
                in_node.AddString("CHART_COMMENT", MPCF.Trim(txtComment.Text));

                in_node.AddString("CHTSET_GRP_1", MPCF.Trim(cdvGrp1.Text));
                in_node.AddString("CHTSET_GRP_2", MPCF.Trim(cdvGrp2.Text));
                in_node.AddString("CHTSET_GRP_3", MPCF.Trim(cdvGrp3.Text));
                in_node.AddString("CHTSET_GRP_4", MPCF.Trim(cdvGrp4.Text));
                in_node.AddString("CHTSET_GRP_5", MPCF.Trim(cdvGrp5.Text));
                in_node.AddString("CHTSET_GRP_6", MPCF.Trim(cdvGrp6.Text));
                in_node.AddString("CHTSET_GRP_7", MPCF.Trim(cdvGrp7.Text));
                in_node.AddString("CHTSET_GRP_8", MPCF.Trim(cdvGrp8.Text));
                in_node.AddString("CHTSET_GRP_9", MPCF.Trim(cdvGrp9.Text));
                in_node.AddString("CHTSET_GRP_10", MPCF.Trim(cdvGrp10.Text));

                in_node.AddString("CHTSET_CMF_1", MPCF.Trim(cdvCMF1.Text));
                in_node.AddString("CHTSET_CMF_2", MPCF.Trim(cdvCMF2.Text));
                in_node.AddString("CHTSET_CMF_3", MPCF.Trim(cdvCMF3.Text));
                in_node.AddString("CHTSET_CMF_4", MPCF.Trim(cdvCMF4.Text));
                in_node.AddString("CHTSET_CMF_5", MPCF.Trim(cdvCMF5.Text));
                in_node.AddString("CHTSET_CMF_6", MPCF.Trim(cdvCMF6.Text));
                in_node.AddString("CHTSET_CMF_7", MPCF.Trim(cdvCMF7.Text));
                in_node.AddString("CHTSET_CMF_8", MPCF.Trim(cdvCMF8.Text));
                in_node.AddString("CHTSET_CMF_9", MPCF.Trim(cdvCMF9.Text));
                in_node.AddString("CHTSET_CMF_10", MPCF.Trim(cdvCMF10.Text));

                if (MPCR.CallService("SPC", "SPC_Update_Chart_Set", in_node, ref out_node) == false)
                {
                    return false;
                }
                MPCR.ShowSuccessMsg(out_node);
                if (MPGV.gbListAutoRefresh == false)
                {
                    if (c_step == MPGC.MP_STEP_CREATE)
                    {
                        itm = lisChartSet.Items.Add(txtChartSet.Text, (int)SMALLICON_INDEX.IDX_CHART_LINE);
                        itm.SubItems.Add(txtDesc.Text);
                        itm.Selected = true;
                        lisChartSet.Sorting = SortOrder.Ascending;
                        lisChartSet.Sort();
                        itm.EnsureVisible();
                    }
                    else if (c_step == MPGC.MP_STEP_UPDATE)
                    {
                        if (MPCF.FindListItem(lisChartSet, MPCF.Trim(txtChartSet.Text), false) == true)
                        {
                            lisChartSet.SelectedItems[0].SubItems[1].Text = MPCF.Trim(txtDesc.Text);
                        }
                    }
                    else if (c_step == MPGC.MP_STEP_DELETE)
                    {
                        idx = MPCF.FindListItemIndex(lisChartSet, MPCF.Trim(txtChartSet.Text), false);
                        if (idx != - 1)
                        {
                            lisChartSet.Items[idx].Remove();
                        }
                        lblDataCount.Text = lisChartSet.Items.Count.ToString();
                    }
                }
                
                return true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCSetupChartSet.Update_ChartSet()\n" + ex.Message);
                return false;
            }
            
        }
        
        // View_ChartSet()
        //       - View Chart Set information
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool View_ChartSet()
        {
            
            try
            {
                TRSNode in_node = new TRSNode("View_Chart_Set_In");
                TRSNode out_node = new TRSNode("View_Chart_Set_Out");

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("CHART_SET_ID", MPCF.Trim(txtChartSet.Text));

                if (MPCR.CallService("SPC", "SPC_View_Chart_Set", in_node, ref out_node) == false)
                {
                    return false;
                }

                txtDesc.Text = out_node.GetString("CHART_SET_DESC");

                txtComment.Text = out_node.GetString("CHART_COMMENT");

                cdvGrp1.Text = out_node.GetString("CHTSET_GRP_1");
                cdvGrp2.Text = out_node.GetString("CHTSET_GRP_2");
                cdvGrp3.Text = out_node.GetString("CHTSET_GRP_3");
                cdvGrp4.Text = out_node.GetString("CHTSET_GRP_4");
                cdvGrp5.Text = out_node.GetString("CHTSET_GRP_5");
                cdvGrp6.Text = out_node.GetString("CHTSET_GRP_6");
                cdvGrp7.Text = out_node.GetString("CHTSET_GRP_7");
                cdvGrp8.Text = out_node.GetString("CHTSET_GRP_8");
                cdvGrp9.Text = out_node.GetString("CHTSET_GRP_9");
                cdvGrp10.Text = out_node.GetString("CHTSET_GRP_10");

                cdvCMF1.Text = out_node.GetString("CHTSET_CMF_1");
                cdvCMF2.Text = out_node.GetString("CHTSET_CMF_2");
                cdvCMF3.Text = out_node.GetString("CHTSET_CMF_3");
                cdvCMF4.Text = out_node.GetString("CHTSET_CMF_4");
                cdvCMF5.Text = out_node.GetString("CHTSET_CMF_5");
                cdvCMF6.Text = out_node.GetString("CHTSET_CMF_6");
                cdvCMF7.Text = out_node.GetString("CHTSET_CMF_7");
                cdvCMF8.Text = out_node.GetString("CHTSET_CMF_8");
                cdvCMF9.Text = out_node.GetString("CHTSET_CMF_9");
                cdvCMF10.Text = out_node.GetString("CHTSET_CMF_10");

                if (out_node.GetChar("LOT_RES_FLAG") == 'L')
                {
                    rbnLot.Checked = true;
                }
                else
                {
                    rbnResource.Checked = true;
                }
                
                return true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCSetupChartSet.View_ChartSet()\n" + ex.Message);
                return false;
            }
            
        }
        
        // Attach_Chart()
        //       - Create/Update/Delete Chart - Chart Set Relation
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal c_step As String : Process Step
        //       - ByVal sChart As String : Chart
        //       - ByVal sChartSet As String : Chart Set
        //
        private bool Attach_Chart(char c_step, string sChart, string sChartSet)
        {
            
            try
            {
                TRSNode in_node = new TRSNode("Attach_Chart_Set_In");
                TRSNode out_node = new TRSNode("Cmn_Out");

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = c_step;
                in_node.AddString("CHART_ID", MPCF.Trim(sChart));
                in_node.AddString("CHART_SET_ID", MPCF.Trim(sChartSet));


                if (MPCR.CallService("SPC", "SPC_Attach_Chart_Set", in_node, ref out_node) == false)
                {
                    return false;
                }
                MPCR.ShowSuccessMsg(out_node);

                return true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCSetupChartSet.Attach_Chart()\n" + ex.Message);
                return false;
            }
            
        }
        
        //
        // View_Material_Desc()
        //       - View Material description
        // Return Value
        //       - string : desc
        // Arguments
        //        -
        private string View_Material_Desc(string sMatID, int iMatVer)
        {
            TRSNode in_node = new TRSNode("View_In");
            TRSNode out_node = new TRSNode("View_Out");
            
            if (sMatID == "")
            {
                return "";
            }
            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("MAT_ID", MPCF.Trim(sMatID));
            in_node.AddInt("MAT_VER", iMatVer);

            if (MPCR.CallService("WIP", "WIP_View_Material", in_node, ref out_node) == false)
            {
                return "";
            }
                        
            return MPCF.Trim(out_node.GetString("MAT_DESC"));
            
        }
        
        //
        // View_Flow_Desc()
        //       - View Flow description
        // Return Value
        //       - string : desc
        // Arguments
        //        -
        private string View_Flow_Desc(string sFlow)
        {
            TRSNode in_node = new TRSNode("View_In");
            TRSNode out_node = new TRSNode("View_Out");
                
            if (sFlow == "")
            {
                return "";
            }

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("FLOW", MPCF.Trim(sFlow));

            if (MPCR.CallService("WIP", "WIP_View_Flow", in_node, ref out_node) == false)
            {
                return "";
            }
            
            return MPCF.Trim(out_node.GetString("FLOW_DESC"));
            
        }
        
        //
        // View_Oper_Desc()
        //       - View Oper description
        // Return Value
        //       - string : desc
        // Arguments
        //        -
        private string View_Oper_Desc(string sOper)
        {
            TRSNode in_node = new TRSNode("View_In");
            TRSNode out_node = new TRSNode("View_Out");
            
            if (sOper == "")
            {
                return "";
            }

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("OPER", MPCF.Trim(sOper));

            if (MPCR.CallService("WIP", "WIP_View_Operation", in_node, ref out_node) == false)
            {
                return "";
            }

            return MPCF.Trim(out_node.GetString("OPER_DESC"));
            
        }
        
        //
        // View_Res_Desc()
        //       - View Oper description
        // Return Value
        //       - string : desc
        // Arguments
        //        -
        private string View_Res_Desc(string sResID)
        {
            TRSNode in_node = new TRSNode("View_In");
            TRSNode out_node = new TRSNode("View_Out");
                        
            if (sResID == "")
            {
                return "";
            }
            
            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("RES_ID", MPCF.Trim(sResID));


            if (MPCR.CallService("RAS", "RAS_View_Resource", in_node, ref out_node) == false)
            {
                return "";
            }
            
            return MPCF.Trim(out_node.GetString("RES_DESC"));
            
        }
        
        public virtual Control GetFisrtFocusItem()
        {
            
            try
            {
                return this.lisChartSet;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }
            
        }
        
    
        #endregion
        
        #region " Event Implematations"
        
        private void frmSPCSetupChartSet_Load(object sender, System.EventArgs e)
        {
            
            try
            {
                MPGV.gIBaseFormEvent.Form_Load(this, e);
                MPCF.SetTextboxStyle(this.Controls);
                
                MPCF.InitListView(lisChartSet);
                MPCF.InitListView(lisChart);
                MPCF.InitListView(lisAttachChart);
                
                rbnFilter.Checked = true;
                txtFilter.Text = modSPCFunctions.GetFilterKey();
                
                rbnLot.Checked = true;
                
                SetGroupCmfItem();
                                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCSetupChartSet.frmSPCSetupChartSet_Load()\n" + ex.Message);
            }
            
        }
        
        private void frmSPCSetupChartSet_Activated(object sender, System.EventArgs e)
        {
            
            try
            {
                if (b_load_flag == false)
                {
                    lblDataCount.Text = "";
                    if (SPCLIST.ViewChartSetList(lisChartSet, '1', "", 0, "", "", ' ', "", -1, -1, "") == true)
                    {
                        lblDataCount.Text = lisChartSet.Items.Count.ToString();
                        if (lisChartSet.Items.Count > 0)
                        {
                            lisChartSet.Items[0].Selected = true;
                        }
                    }
                    else
                    {
                        return;
                    }
                    b_load_flag = true;
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCSetupChartSet.frmSPCSetupChartSet_Activated()\n" + ex.Message);
            }
            
        }
        
        private void btnCreate_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                if (CheckCondition("I") == false)
                {
                    return;
                }
                if (Update_ChartSet(MPGC.MP_STEP_CREATE) == false)
                {
                    return;
                }
                if (MPGV.gbListAutoRefresh == true)
                {
                    btnRefresh.PerformClick();
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCSetupChartSet.btnCreate_Click()\n" + ex.Message);
            }
            
        }
        
        private void btnUpdate_Click(object sender, System.EventArgs e)
        {
            
            try
            {
                if (CheckCondition("I") == false)
                {
                    return;
                }
                if (Update_ChartSet(MPGC.MP_STEP_UPDATE) == false)
                {
                    return;
                }
                if (MPGV.gbListAutoRefresh == true)
                {
                    btnRefresh.PerformClick();
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCSetupChartSet.btnUpdate_Click()\n" + ex.Message);
            }
            
        }
        
        private void btnDelete_Click(object sender, System.EventArgs e)
        {
            
            try
            {
                if (CheckCondition("D") == false)
                {
                    return;
                }
                if (MPCF.ShowMsgBox(MPCF.GetMessage(54), MessageBoxButtons.YesNo, 1) != System.Windows.Forms.DialogResult.Yes)
                {
                    return;
                }
                if (Update_ChartSet(MPGC.MP_STEP_DELETE) == false)
                {
                    return;
                }
                MPCF.FieldClear(this.pnlRight);
                if (MPGV.gbListAutoRefresh == true)
                {
                    btnRefresh.PerformClick();
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCSetupChartSet.btnDelete_Click()\n" + ex.Message);
            }
            
        }
        
        
        
        private void lisChartSet_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            
            try
            {
                MPCF.FieldClear(this.grpComment);
                MPCF.FieldClear(this.grpGroup);
                MPCF.FieldClear(this.grpCMF);
                if (lisChartSet.SelectedItems.Count > 0)
                {
                    txtChartSet.Text = lisChartSet.SelectedItems[0].Text;
                    View_ChartSet();
                    SPCLIST.ViewSPCAttachChartList(lisAttachChart, '1', lisChartSet.SelectedItems[0].Text, "");
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCSetupChartSet.lisChartSet_SelectedIndexChanged()\n" + ex.Message);
            }
            
        }
        
        
        private void btnAdd_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                string sChart;
                string sChartSet;
                string[] sSelect = null;
                int i;
                int j;
                int iIdx = 0;
                sSelect = new string[lisChart.SelectedItems.Count];
                
                MPCF.SelectClear(lisAttachChart);
                if (CheckCondition("ATTACH") == false)
                {
                    return;
                }
                for (i = 0; i <= lisChart.SelectedItems.Count - 1; i++)
                {
                    sChart = lisChart.SelectedItems[i].Text;
                    sChartSet = MPCF.Trim(txtChartSet.Text);
                    if (MPCF.FindListItem(lisAttachChart, sChart, false) == false)
                    {
                        if (Attach_Chart(MPGC.MP_STEP_CREATE, sChart, sChartSet) == true)
                        {
                            sSelect[i] = sChart;
                            iIdx = lisChart.SelectedItems[i].Index;
                        }
                        else
                        {
                            for (j = 0; j <= sSelect.Length - 1; j++)
                            {
                                MPCF.FindListItem(lisAttachChart, sSelect[j], false);
                            }
                            MPCF.SelectClear(lisChart);
                            return;
                        }
                    }
                    else
                    {
                        sSelect[i] = sChart;
                        iIdx = lisChart.SelectedItems[i].Index;
                    }
                }
                if (SPCLIST.ViewSPCAttachChartList(lisAttachChart, '1', lisChartSet.SelectedItems[0].Text, "") == false)
                {
                    return;
                }
                MPCF.SelectClear(lisChart);
                if (sSelect.Length == 1)
                {
                    if (iIdx < lisChart.Items.Count - 1)
                    {
                        lisChart.Items[iIdx + 1].Selected = true;
                    }
                }
                for (i = 0; i <= sSelect.Length - 1; i++)
                {
                    MPCF.FindListItem(lisAttachChart, sSelect[i], false);
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCSetupChartSet.btnAdd_Click()\n" + ex.Message);
            }
            
        }
        
        private void btnDel_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                string sChart;
                string sChartSet;
                int iIdx = 0;
                int i;
                int iCount;
                
                if (CheckCondition("DETACH") == false)
                {
                    return;
                }
                iCount = lisAttachChart.SelectedItems.Count;
                MPCF.SelectClear(lisChart);
                for (i = lisAttachChart.SelectedItems.Count - 1; i >= 0; i--)
                {
                    sChart = lisAttachChart.SelectedItems[i].Text;
                    sChartSet = MPCF.Trim(txtChartSet.Text);
                    
                    if (Attach_Chart(MPGC.MP_STEP_DELETE, sChart, sChartSet) == true)
                    {
                        iIdx = lisAttachChart.SelectedItems[i].Index;
                        lisAttachChart.Items.RemoveAt(iIdx);
                        MPCF.FindListItem(lisChart, sChart, false);
                    }
                }
                if (iCount == 1)
                {
                    if (iIdx < lisAttachChart.Items.Count)
                    {
                        lisAttachChart.Items[iIdx].Selected = true;
                    }
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCSetupChartSet.btnDel_Click()\n" + ex.Message);
            }
            
        }
        
        private void grpRight_Resize(object sender, System.EventArgs e)
        {
            
            try
            {
                MPCF.FieldAdjust(pnlMid, pnlMidLeft, pnlMidRight, pnlAttach, 40);
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCSetupChartSet.grpRight_Resize()\n" + ex.Message);
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
                MPCF.ShowMsgBox("frmSPCSetupChartSet.btnClose_Click()\n" + ex.Message);
            }
            
        }
        
        private void txtChartSet_TextChanged(object sender, System.EventArgs e)
        {
            
            try
            {
                MPCF.InitListView(lisAttachChart);
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCSetupChartSet.txtChartSet_TextChanged()\n" + ex.Message);
            }
            
        }
        
        private void btnRefresh_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                lblDataCount.Text = "";
                if (SPCLIST.ViewChartSetList(lisChartSet, '1', "", 0,"", "", ' ', "", -1, -1, "") == false)
                {
                    return;
                }
                
                lblDataCount.Text = lisChartSet.Items.Count.ToString();
                if (lisChartSet.Items.Count > 0)
                {
                    MPCF.FindListItem(lisChartSet, txtChartSet.Text, false);
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCSetupChartSet.btnRefresh_Click()\n" + ex.Message);
            }
            
        }
        
        private void btnExcel_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                MPCF.ExportToExcel(lisChartSet, this.Text, "");
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCSetupChartSet.btnExcel_Click()\n" + ex.Message);
            }
            
        }
        
        private void btnNext_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                MPCF.FindListItemNextPartial(lisChartSet, txtFind.Text, true, false);
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCSetupChartSet.btnNext_Click()\n" + ex.Message);
            }
            
        }
        
        private void txtFind_TextChanged(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                MPCF.FindListItemPartial(lisChartSet, txtFind.Text, 0, true, false);
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCSetupChartSet.txtFind_TextChanged()\n" + ex.Message);
            }
            
        }
        
        private void btnView_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                modSPCFunctions.SaveFilterKey(MPCF.Trim(txtFilter.Text));
                
                if (rbnFilter.Checked == true && MPCF.Trim(txtFilter.Text) == "")
                {
                    lisChart.Items.Clear();
                    return;
                }
                if (rbnLot.Checked == true)
                {
                    SPCLIST.ViewChartList(lisChart, '2', "", 0, "", "", "", 'L', ' ', (rbnAll.Checked == true ? "" : (MPCF.Trim(txtFilter.Text))), "", -1, -1, null, "");
                }
                else
                {
                    SPCLIST.ViewChartList(lisChart, '2', "",0, "","", "", 'R', ' ', (rbnAll.Checked == true ? "" : (MPCF.Trim(txtFilter.Text))), "", -1, -1, null, "");
                }
                if (lisChart.Items.Count > 0)
                {
                    lisChart.Items[0].Selected = true;
                    
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCSetupChartSet.btnView_Click()\n" + ex.Message);
            }
            
        }
        
        private void txtFilter_TextChanged(object sender, System.EventArgs e)
        {
            
            try
            {
                rbnFilter.Checked = true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCSetupChartSet.txtFilter_TextChanged()\n" + ex.Message);
            }
            
        }
        
        
        private void cdvGrpCmf_ButtonPress(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                MPCR.ProcGRPCMFButtonPress(sender);
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCSetupChartSet.cdvGrpCmf_ButtonPress()\n" + ex.Message);
            }
            
        }
        
        private void cdvCMF_TextBoxKeyPress(System.Object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            
            try
            {
                MPCR.CheckCMFKeyPress(sender, e);
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCSetupChartSet.cdvGrpCmf_ButtonPress()\n" + ex.Message);
            }
            
        }
        
        #endregion

       
        
    }
    
    
    //#End If
    
}
